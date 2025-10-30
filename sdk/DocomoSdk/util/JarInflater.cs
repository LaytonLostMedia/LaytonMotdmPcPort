using System.IO.Compression;
using java.lang;

namespace com.nttdocomo.util
{
    // https://www.multiphasicapps.net/file?name=modules/vendor-api-ntt-docomo-doja/src/main/java/com/nttdocomo/util/JarInflater.java
    public class JarInflater
    {
        private readonly ZipArchive _jarData;
        private bool _isDisposed;

        public JarInflater(byte[] jarData) => _jarData = new ZipArchive(new MemoryStream(jarData));

        public int GetSize(JavaString fileName)
        {
            if (_isDisposed)
                return 0;

            ZipArchiveEntry? entry = _jarData.GetEntry(fileName);
            if (entry == null)
                return 0;

            return (int)entry.Length;
        }

        public Stream GetInputStream(JavaString fileName)
        {
            if (_isDisposed)
                return null;

            ZipArchiveEntry? entry = _jarData.GetEntry(fileName);
            if (entry == null)
                return null;

            var ms = new MemoryStream();
            using Stream entryStream = entry.Open();

            entryStream.CopyTo(ms);
            ms.Position = 0;

            return ms;
        }

        public void Close()
        {
            _jarData.Dispose();
            _isDisposed = true;
        }
    }
}
