namespace com.nttdocomo.io
{
    public class FileDataOutput
    {
        private readonly Stream _fileStream;

        public FileDataOutput(Stream fileStream)
        {
            _fileStream = fileStream;
        }

        public void Write(byte[] buffer) => _fileStream.Write(buffer);

        public void SetBufferSize(int bufferSize) => _fileStream.SetLength(bufferSize);

        public void Flush() => _fileStream.Flush();
        public void Close() => _fileStream.Close();
    }
}
