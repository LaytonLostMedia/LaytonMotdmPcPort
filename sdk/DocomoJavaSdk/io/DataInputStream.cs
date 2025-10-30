using System.Buffers.Binary;

namespace java.io
{
    public class DataInputStream
    {
        private readonly byte[] _buffer = new byte[8];

        private readonly Stream _stream;
        private readonly bool _bigEndian;

        public DataInputStream(Stream baseStream, bool bigEndian)
        {
            _stream = baseStream;
            _bigEndian = bigEndian;
        }

        public int Read(byte[] buffer, int offset, int size)
        {
            return Read(buffer.AsSpan(offset, size));
        }

        public int Read(Span<byte> buffer)
        {
            return _stream.Read(buffer);
        }

        public int ReadByte()
        {
            return _stream.ReadByte();
        }

        public short ReadShort()
        {
            _stream.Read(_buffer, 0, 2);
            return _bigEndian ?
                BinaryPrimitives.ReadInt16BigEndian(_buffer) :
                BinaryPrimitives.ReadInt16LittleEndian(_buffer);
        }

        public ushort ReadUnsignedShort()
        {
            _stream.Read(_buffer, 0, 2);
            return _bigEndian ?
                BinaryPrimitives.ReadUInt16BigEndian(_buffer) :
                BinaryPrimitives.ReadUInt16LittleEndian(_buffer);
        }

        public int ReadInt()
        {
            _stream.Read(_buffer, 0, 4);
            return _bigEndian ?
                BinaryPrimitives.ReadInt32BigEndian(_buffer) :
                BinaryPrimitives.ReadInt32LittleEndian(_buffer);
        }

        public long ReadLong()
        {
            _stream.Read(_buffer, 0, 8);
            return _bigEndian ?
                BinaryPrimitives.ReadInt64BigEndian(_buffer) :
                BinaryPrimitives.ReadInt64LittleEndian(_buffer);
        }

        public void Close()
        {
            _stream.Close();
        }
    }
}
