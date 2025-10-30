using System.Text;
using DocomoCsJavaBridge;
using DoCoMoPlayer.Models;
using DoCoMoPlayer.Resources;

namespace DoCoMoPlayer
{
    internal class AppProvider
    {
        private readonly IDictionary<string, IList<AppContainerData>> _apps;

        private AppProvider(IDictionary<string, IList<AppContainerData>> apps)
        {
            _apps = apps;
        }

        public static AppProvider Create()
        {
            IDictionary<string, IList<AppContainerData>> apps = DetermineApps();
            return new AppProvider(apps);
        }

        public IReadOnlyList<AppContainerData> GetApps(string locale)
        {
            if (_apps.TryGetValue(locale, out IList<AppContainerData>? localeApps))
                return localeApps.AsReadOnly();

            return Array.Empty<AppContainerData>();
        }

        private static IDictionary<string, IList<AppContainerData>> DetermineApps()
        {
            var result = new Dictionary<string, IList<AppContainerData>>();
            if (!Directory.Exists("apps"))
                return result;

            string storedLocale = GameConfigurationResources.Instance.CurrentLocale;

            foreach (string appDirectory in Directory.GetDirectories("apps", "*", SearchOption.TopDirectoryOnly))
            {
                string appName = Path.GetFileName(appDirectory)!;
                foreach (string appLocaleDirectory in Directory.GetDirectories(appDirectory, "*", SearchOption.TopDirectoryOnly))
                {
                    string jamPath = Path.Combine(appLocaleDirectory, appName + ".jam");
                    if (!File.Exists(jamPath))
                        continue;

                    string executablePath = Path.Combine(appLocaleDirectory, "Game.dll");
                    if (!File.Exists(executablePath))
                        continue;

                    string locale = Path.GetFileName(appLocaleDirectory)!;
                    string? encodingName = GameConfigurationResources.Instance.GetEncodingName(locale);

                    if (!string.IsNullOrEmpty(encodingName))
                        DocomoCsJavaBridge.Providers.EncodingProvider.Instance.SetEncoding(Encoding.GetEncoding(encodingName));

                    JamData jamData = JamResource.Load(File.OpenRead(jamPath));

                    if (!result.TryGetValue(locale, out IList<AppContainerData>? localeApps))
                        result[locale] = localeApps = new List<AppContainerData>();

                    localeApps.Add(new AppContainerData
                    {
                        Locale = locale,
                        AppName = appName,
                        AppPath = appLocaleDirectory,
                        AppExecutablePath = executablePath,
                        AppData = jamData
                    });
                }
            }

            GameConfigurationResources.Instance.ChangeLocale(storedLocale);

            return result;
        }
    }
}
