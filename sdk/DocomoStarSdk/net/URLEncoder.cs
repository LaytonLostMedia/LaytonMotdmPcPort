using java.lang;
using System.Web;

namespace com.nttdocomostar.net
{
    public class URLEncoder
    {
        public static JavaString Encode(JavaString url) => HttpUtility.UrlEncode(url);
    }
}
