using System.Text;
using Newtonsoft.Json;

namespace DoCoMoPlayer.Resources
{
    internal class GameConfigurationResources
    {
        private static readonly Lazy<GameConfigurationResources> Lazy = new(new GameConfigurationResources());
        public static GameConfigurationResources Instance => Lazy.Value;

        private const string CONFIG_FOLDER = "resources\\configs";
        private const string DEFAULT_LOCALE = "en";

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

        public string? GetEncodingName() => GetValue("Encoding");

        public string? GetEncodingName(string locale) => GetValue("Encoding", locale);

        private string? GetValue(string name)
        {
            // Return named value of current locale
            string? localizedValue = GetValue(name, CurrentLocale);
            if (localizedValue != null)
                return localizedValue;

            // Otherwise, return named value of default locale
            localizedValue = GetValue(name, DEFAULT_LOCALE);
            if (localizedValue != null)
                return localizedValue;

            // Otherwise, return null
            return null;
        }

        private string? GetValue(string name, string locale)
        {
            if (!string.IsNullOrEmpty(locale) && _configurations[locale].ContainsKey(name))
                return _configurations[locale][name];

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
