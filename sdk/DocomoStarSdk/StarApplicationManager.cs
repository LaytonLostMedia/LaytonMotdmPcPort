using DocomoCsJavaBridge;
using java.lang;

namespace com.nttdocomostar
{
    public class StarApplicationManager
    {
        public static JavaString[] GetArgs() => AppInfo.GetAppParam().Select(s => (JavaString)s).ToArray() ?? [];
        public static JavaString GetSourceURL() => AppInfo.GetPackageUrl();
    }
}
