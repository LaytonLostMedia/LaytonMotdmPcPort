using DocomoCsJavaBridge;

namespace DoCoMoPlayer.Models
{
    internal class AppContainerData
    {
        public string Locale { get; set; }
        public string AppName { get; set; }

        public string AppPath { get; set; }

        public string AppExecutablePath { get; set; }
        public JamData AppData { get; set; }
    }
}
