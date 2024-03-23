using ImGui.Forms.Localization;
using Newtonsoft.Json;
using System.Text;

namespace LaytonMotdm.Resources
{
    class Localizer : ILocalizer
    {
        private const string LANG_FOLDER = "langs";
        private const string DEFAULT_LOCALE = "en";

        private const string NAME_VALUE = "Name";

        private const string UNDEFINED = "<undefined>";

        private readonly IDictionary<string, IDictionary<string, string>> _localizations;

        public string CurrentLocale { get; private set; } = DEFAULT_LOCALE;

        public Localizer()
        {
            // Load localizations
            _localizations = GetLocalizations();

            // Set default locale
            if (_localizations.Count == 0)
                CurrentLocale = string.Empty;
            else if (!_localizations.ContainsKey(DEFAULT_LOCALE))
                CurrentLocale = _localizations.FirstOrDefault().Key;
        }

        public IList<string> GetLocales()
        {
            return _localizations.Keys.ToArray();
        }

        public string GetLanguageName(string locale)
        {
            if (!_localizations.ContainsKey(locale) || !_localizations[locale].ContainsKey(NAME_VALUE))
                return UNDEFINED;

            return _localizations[locale][NAME_VALUE];
        }

        public string GetLocaleByName(string name)
        {
            foreach (string locale in GetLocales())
                if (GetLanguageName(locale) == name)
                    return locale;

            return UNDEFINED;
        }

        public void ChangeLocale(string locale)
        {
            // Do nothing, if locale was not found
            if (!_localizations.ContainsKey(locale))
                return;

            CurrentLocale = locale;
        }

        public string Localize(string name, params object[] args)
        {
            // Return localization of current locale
            if (!string.IsNullOrEmpty(CurrentLocale) && _localizations[CurrentLocale].ContainsKey(name))
                return string.Format(_localizations[CurrentLocale][name], args);

            // Otherwise, return localization of default locale
            if (!string.IsNullOrEmpty(DEFAULT_LOCALE) && _localizations[DEFAULT_LOCALE].ContainsKey(name))
                return string.Format(_localizations[DEFAULT_LOCALE][name], args);

            // Otherwise, return localization placeholder
            return UNDEFINED;
        }

        private IDictionary<string, IDictionary<string, string>> GetLocalizations()
        {
            var result = new Dictionary<string, IDictionary<string, string>>();

            if (!Directory.Exists(LANG_FOLDER))
                return result;

            foreach (string langFile in Directory.GetFiles(LANG_FOLDER, "*.json", SearchOption.TopDirectoryOnly))
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
