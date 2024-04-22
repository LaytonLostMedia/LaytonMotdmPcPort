namespace com.nttdocomo
{
    public class PathProvider
    {
        private string? _scratchPadSubDirectory;
        private string? _resourceSubDirectory;

        public static readonly PathProvider Instance = new();

        public string GetScratchPadPath()
        {
            var dir = "scratchpad";
            if (!string.IsNullOrEmpty(_scratchPadSubDirectory))
                dir = Path.Combine(dir, _scratchPadSubDirectory);

            Directory.CreateDirectory(dir);

            return Path.Combine(dir, $"{AppInfo.GetApplicationName()}.sp");
        }

        public string GetResourcePath()
        {
            var dir = "resources";
            if (!string.IsNullOrEmpty(_resourceSubDirectory))
                dir = Path.Combine(dir, _resourceSubDirectory);

            Directory.CreateDirectory(dir);

            return Path.Combine(dir, AppInfo.GetApplicationName());
        }

        public void SetScratchPadSubDirectory(string path)
        {
            _scratchPadSubDirectory = path;
        }

        public void SetResourceSubDirectory(string path)
        {
            _resourceSubDirectory = path;
        }
    }
}
