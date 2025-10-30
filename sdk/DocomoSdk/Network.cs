using DocomoCsJavaBridge;

namespace com.nttdocomo
{
    public static class Network
    {
        public static Stream Open(string url)
        {
            string networkDir = PathProvider.Instance.GetNetworkPath();
            string networkPath = Path.Combine(networkDir, url);

            if (!File.Exists(networkPath))
                java.util.System.Out.Error($"Network resource {Path.GetRelativePath(networkDir, networkPath)} not found.");

            return File.OpenRead(networkPath);
        }
    }
}
