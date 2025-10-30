using System.Buffers.Binary;

namespace java.io
{
    public class DataOutputStreram
    {
        private readonly byte[] _buffer = new byte[8];

        private readonly Stream _stream;
        private readonly bool _bigEndian;

        public DataOutputStreram(Stream baseStream, bool bigEndian)
        {
            _stream = baseStream;
            _bigEndian = bigEndian;
        }

        public void Write(byte[] buffer, int offset, int size)
        {
            Write(buffer.AsSpan(offset, size));
        }

        public void Write(Span<byte> buffer)
        {
            _stream.Write(buffer);
        }

        public void WriteByte(int value)
        {
            _stream.WriteByte((byte)value);
        }

        public void WriteShort(int value)
        {
            if (_bigEndian)
                BinaryPrimitives.WriteInt16BigEndian(_buffer, (short)value);
            else
                BinaryPrimitives.WriteInt16LittleEndian(_buffer, (short)value);

            _stream.Write(_buffer, 0, 2);
        }

        public void WriteInt(int value)
        {
            if (_bigEndian)
                BinaryPrimitives.WriteInt32BigEndian(_buffer, value);
            else
                BinaryPrimitives.WriteInt32LittleEndian(_buffer, value);

            _stream.Write(_buffer, 0, 4);
        }

        public void WriteLong(long value)
        {
            if (_bigEndian)
                BinaryPrimitives.WriteInt64BigEndian(_buffer, value);
            else
                BinaryPrimitives.WriteInt64LittleEndian(_buffer, value);

            _stream.Write(_buffer, 0, 8);
        }

        public void Close()
        {
            _stream.Close();
        }
    }
}
