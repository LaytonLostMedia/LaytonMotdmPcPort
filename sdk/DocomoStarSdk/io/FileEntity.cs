namespace com.nttdocomostar.io
{
    public class FileEntity
    {
        private readonly Stream _fileStream;

        public FileEntity(Stream fileStream)
        {
            _fileStream = fileStream;
        }

        public Stream OpenOutputStream() => _fileStream;
        public Stream OpenInputStream() => _fileStream;

        public FileDataOutput OpenDataOutput() => new(_fileStream);
        public FileDataInput OpenDataInput() => new(_fileStream);

        public void SetBufferSize(int bufferSize) { }
        public void Close() => _fileStream.Close();
    }
}
