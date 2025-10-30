using java.lang;

namespace com.nttdocomostar.io
{
    public class HttpConnection
    {
        private JavaString _url;
        private JavaString _method;

        internal HttpConnection(JavaString url) => _url = url;

        public void SetRequestMethod(JavaString method) => _method = method;
        public JavaString GetHeaderField(JavaString headerName) => "";

        public Stream OpenInputStream()
        {
            return new MemoryStream();
        }

        public void Connect() { }
        public void Close() { }
    }
}
