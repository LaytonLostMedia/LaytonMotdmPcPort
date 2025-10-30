namespace com.nttdocomo.io
{
    public class FileEntity
    {
        private readonly Stream _fileStream;

        public FileEntity(Stream fileStream)
        {
            _fileStream = fileStream;
        }

        public FileDataOutput OpenDataOutput() => new(_fileStream);
        public FileDataInput OpenDataInput() => new(_fileStream);

        public void SetBufferSize(int bufferSize) { }
        public void Close() => _fileStream.Close();
    }
}
