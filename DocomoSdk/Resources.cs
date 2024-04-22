namespace com.nttdocomo
{
    public static class Resources
    {
        public static Stream Open(string path, bool canWrite)
        {
            string resourcePath = Path.Combine(PathProvider.Instance.GetResourcePath(), Path.GetRelativePath("/", path));
            FileAccess access = canWrite ? FileAccess.Write : FileAccess.Read;

            return File.Open(resourcePath, FileMode.OpenOrCreate, access);
        }
    }
}
