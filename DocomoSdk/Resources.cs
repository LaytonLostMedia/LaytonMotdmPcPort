namespace com.nttdocomo
{
    public static class Resources
    {
        public static Stream Open(string path, bool canWrite)
        {
            Directory.CreateDirectory("resources/");

            string resourcePath = Path.Combine("resources", AppInfo.GetApplicationName(), Path.GetRelativePath("/",path));
            FileAccess access = canWrite ? FileAccess.Write : FileAccess.Read;

            return File.Open(resourcePath, FileMode.OpenOrCreate, access);
        }
    }
}
