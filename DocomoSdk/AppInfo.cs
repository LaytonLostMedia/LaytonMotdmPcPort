namespace com.nttdocomo
{
    public static class AppInfo
    {
        private static bool _isInitialized;

        private static string _appName = string.Empty;

        public static void Setup(string appName)
        {
            _appName = appName;

            _isInitialized = true;
        }

        public static string GetApplicationName()
        {
            if (!_isInitialized)
                throw new InvalidOperationException("AppInfo was not setup.");

            return _appName;
        }
    }
}
