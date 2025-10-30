using DocomoCsJavaBridge;

namespace com.nttdocomostar
{
    internal static class Resources
    {
        public static Stream Open(string path, bool canWrite)
        {
            if (!path.StartsWith("/"))
                throw new ArgumentException("Path has to be absolute.", nameof(path));

            string resourceDir = PathProvider.Instance.GetResourcePath();
            string resourcePath = Path.Combine(resourceDir, Path.GetRelativePath("/", path));
            FileAccess access = canWrite ? FileAccess.ReadWrite : FileAccess.Read;

            if (!File.Exists(resourcePath))
                java.util.System.Out.Error($"Resource file {Path.GetRelativePath(resourceDir, resourcePath)} not found.");

            return File.Open(resourcePath, FileMode.OpenOrCreate, access);
        }
    }
}
