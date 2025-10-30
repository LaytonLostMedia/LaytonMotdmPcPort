using java.lang;

namespace com.nttdocomostar.io
{
    public class FileDataInput
    {
        private readonly Stream _fileStream;
        private readonly StreamReader _reader;

        public FileDataInput(Stream fileStream)
        {
            _fileStream = fileStream;
            _reader = new StreamReader(fileStream);
        }

        public JavaString ReadLine() => _reader.ReadLine();

        public void SetPosition(int position) => _fileStream.Position = position;

        public void ReadFully(byte[] buffer) => _ = _fileStream.Read(buffer);
        public int ReadByte() => _fileStream.ReadByte();

        public void Close() => _reader.Close();
    }
}
