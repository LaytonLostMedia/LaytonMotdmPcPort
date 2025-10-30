using System.Numerics;

namespace DocomoCsJavaBridge
{
    public static class AppInfo
    {
        private static bool _isInitialized;

        private static string _appName = string.Empty;
        private static JamData? _jamData;

        public static void Setup(string appName, JamData jamData)
        {
            _appName = appName;
            _jamData = jamData;

            _isInitialized = true;
        }

        public static string GetApplicationName()
        {
            AssertInitialized();

            return _appName;
        }

        public static Vector2 GetAppSize()
        {
            AssertInitialized();

            return _jamData!.DrawArea;
        }

        public static int GetAppWidth()
        {
            AssertInitialized();

            return (int)_jamData!.DrawArea.X;
        }

        public static int GetAppHeight()
        {
            AssertInitialized();

            return (int)_jamData!.DrawArea.Y;
        }

        public static string[] GetAppParam()
        {
            AssertInitialized();

            return _jamData!.AppParam ?? Array.Empty<string>();
        }

        public static string GetPackageUrl()
        {
            AssertInitialized();

            return _jamData!.PackageUrl;
        }

        private static void AssertInitialized()
        {
            if (!_isInitialized)
                throw new InvalidOperationException("AppInfo was not setup.");
        }
    }
}
