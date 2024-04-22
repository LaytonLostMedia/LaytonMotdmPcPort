using Newtonsoft.Json;
using System.Text;

namespace LaytonMotdm.Resources
{
    internal class GameConfigurationResources
    {
        private static readonly Lazy<GameConfigurationResources> Lazy = new(new GameConfigurationResources());
        public static GameConfigurationResources Instance => Lazy.Value;

        private const string CONFIG_FOLDER = "configs";
        private const string DEFAULT_LOCALE = "jp";

        private const string NAME_VALUE = "Name";
        private const string UNDEFINED = "<undefined>";

        private readonly IDictionary<string, IDictionary<string, string>> _configurations;

        public string CurrentLocale { get; private set; } = DEFAULT_LOCALE;

        public GameConfigurationResources()
        {
            // Load configurations
            _configurations = GetConfigurations();

            // Set default locale
            if (_configurations.Count == 0)
                CurrentLocale = string.Empty;
            else if (!_configurations.ContainsKey(DEFAULT_LOCALE))
                CurrentLocale = _configurations.FirstOrDefault().Key;
        }

        public IList<string> GetLocales()
        {
            return _configurations.Keys.ToArray();
        }

        public string GetLanguageName(string locale)
        {
            if (!_configurations.ContainsKey(locale) || !_configurations[locale].ContainsKey(NAME_VALUE))
                return UNDEFINED;

            return _configurations[locale][NAME_VALUE];
        }

        public void ChangeLocale(string locale)
        {
            // Do nothing, if locale was not found
            if (!_configurations.ContainsKey(locale))
                return;

            CurrentLocale = locale;
        }

        public string? GetResourceFolder() => GetValue("Subfolder.Resources");

        public string? GetScratchPadFolder() => GetValue("Subfolder.Scratchpad");

        public string? GetEncodingName() => GetValue("Encoding");

        private string? GetValue(string name)
        {
            // Return named value of current locale
            if (!string.IsNullOrEmpty(CurrentLocale) && _configurations[CurrentLocale].ContainsKey(name))
                return _configurations[CurrentLocale][name];

            // Otherwise, return named value of default locale
            if (!string.IsNullOrEmpty(DEFAULT_LOCALE) && _configurations[DEFAULT_LOCALE].ContainsKey(name))
                return _configurations[DEFAULT_LOCALE][name];

            // Otherwise, return null
            return null;
        }

        private IDictionary<string, IDictionary<string, string>> GetConfigurations()
        {
            var result = new Dictionary<string, IDictionary<string, string>>();

            if (!Directory.Exists(CONFIG_FOLDER))
                return result;

            foreach (string langFile in Directory.GetFiles(CONFIG_FOLDER, "*.json", SearchOption.TopDirectoryOnly))
            {
                using Stream langFileStream = File.OpenRead(langFile);

                var reader = new StreamReader(langFileStream, Encoding.UTF8);
                string json = reader.ReadToEnd();

                string locale = GetLocale(langFile);
                result.Add(locale, JsonConvert.DeserializeObject<IDictionary<string, string>>(json));
            }

            return result;
        }

        private string GetLocale(string langFilePath)
        {
            return Path.GetFileNameWithoutExtension(langFilePath);
        }
    }
}
