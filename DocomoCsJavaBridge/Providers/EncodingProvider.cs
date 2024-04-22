using System.Text;

namespace DocomoCsJavaBridge.Providers
{
    public class EncodingProvider
    {
        private Encoding _encoding = Encoding.UTF8;

        public static readonly EncodingProvider Instance = new();

        public void SetEncoding(Encoding encoding)
        {
            _encoding = encoding;
        }

        public Encoding GetEncoding()
        {
            return _encoding;
        }
    }
}
