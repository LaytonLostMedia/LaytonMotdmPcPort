using DocomoCsJavaBridge;
using System.Buffers.Binary;

namespace com.nttdocomostar
{
    internal static class ScratchPad
    {
        public static Stream Open(int pos, bool canWrite)
        {
            string scratchPadPath = PathProvider.Instance.GetScratchPadPath();
            FileAccess access = canWrite ? FileAccess.Write : FileAccess.Read;

            if (!File.Exists(scratchPadPath))
                java.util.System.Out.Error($"Scratchpad file {scratchPadPath} not found.");

            Stream scratchPadFileStream = File.Open(scratchPadPath, FileMode.OpenOrCreate, access);

            Stream scratchPadStream = new ScratchPadStream(scratchPadFileStream);
            scratchPadStream.Position = pos;

            return scratchPadStream;
        }

        class ScratchPadStream : Stream
        {
            private const int HEADER_SIZE = 0x40;

            private readonly Stream _baseStream;

            public override bool CanRead => _baseStream.CanRead;
            public override bool CanSeek => _baseStream.CanSeek;
            public override bool CanWrite => _baseStream.CanWrite;
            public override long Length => _baseStream.Length - HEADER_SIZE;

            public override long Position
            {
                get => _baseStream.Position - HEADER_SIZE;
                set => _baseStream.Position = value + HEADER_SIZE;
            }

            public ScratchPadStream(Stream baseStream)
            {
                _baseStream = baseStream;
                _baseStream.Position = HEADER_SIZE;

                WriteHeader();
            }

            public override void Flush() => _baseStream.Flush();

            public override long Seek(long offset, SeekOrigin origin)
            {
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        return Position = offset;

                    case SeekOrigin.Current:
                        return Position += offset;

                    case SeekOrigin.End:
                        return Position = Length + offset;
                }

                return -1;
            }

            public override void SetLength(long value)
            {
                _baseStream.SetLength(value + HEADER_SIZE);

                WriteHeader();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _baseStream.Read(buffer, offset, count);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                _baseStream.Write(buffer, offset, count);

                WriteHeader();
            }

            protected override void Dispose(bool disposing)
            {
                _baseStream.Dispose();
            }

            private void WriteHeader()
            {
                WriteLength();
                WriteHeaderPadding();
            }

            private void WriteLength()
            {
                if (!_baseStream.CanWrite)
                    return;

                var buffer = new byte[4];
                BinaryPrimitives.WriteInt32LittleEndian(buffer, (int)(_baseStream.Length - HEADER_SIZE));

                long pos = _baseStream.Position;

                _baseStream.Position = 0;
                _baseStream.Write(buffer);
                _baseStream.Position = pos;
            }

            private void WriteHeaderPadding()
            {
                if (!_baseStream.CanWrite || _baseStream.Length >= HEADER_SIZE)
                    return;

                var buffer = new byte[HEADER_SIZE - 4];
                Array.Fill(buffer, byte.MaxValue);

                long pos = _baseStream.Position;

                _baseStream.Position = 4;
                _baseStream.Write(buffer);
                _baseStream.Position = pos;
            }
        }
    }
}
