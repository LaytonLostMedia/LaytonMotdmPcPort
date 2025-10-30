using DocomoCsJavaBridge;

namespace DocomoCsJavaBridge
{
    public class PathProvider
    {
        private string? _subDirectory;

        public static readonly PathProvider Instance = new();

        public string GetScratchPadPath()
        {
            string dir = EnsureSubDirectory("scratchpad");

            return Path.Combine(dir, $"{AppInfo.GetApplicationName()}.sp");
        }

        public string GetResourcePath()
        {
            return EnsureSubDirectory("resources");
        }

        public string GetStoragePath()
        {
            return EnsureSubDirectory("storage");
        }

        public string GetNetworkPath()
        {
            return EnsureSubDirectory("network");
        }

        public void SetAppSubDirectory(string path)
        {
            _subDirectory = path;
        }

        private string EnsureSubDirectory(string dir)
        {
            if (!string.IsNullOrEmpty(_subDirectory))
                dir = Path.Combine(_subDirectory, dir);

            Directory.CreateDirectory(dir);

            return dir;
        }
    }
}
