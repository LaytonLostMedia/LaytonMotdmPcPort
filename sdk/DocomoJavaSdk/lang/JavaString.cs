using System.Diagnostics;

namespace java.lang
{
    [DebuggerDisplay("{_value}")]
    public readonly struct JavaString
    {
        public static readonly JavaString Empty = string.Empty;

        private readonly string _value;

        public char this[int i] => _value[i];
        public string this[Range r] => _value[r];

        public int Length => _value.Length;

        public JavaString(byte[] data) : this(data.AsSpan()) { }

        public JavaString(Span<byte> data)
        {
            _value = DocomoCsJavaBridge.Providers.EncodingProvider.Instance.GetEncoding().GetString(data);
        }

        private JavaString(string value)
        {
            _value = value;
        }

        public byte[] GetBytes()
        {
            return DocomoCsJavaBridge.Providers.EncodingProvider.Instance.GetEncoding().GetBytes(_value);
        }

        public int IndexOf(char needle)
        {
            return _value.IndexOf(needle);
        }

        public int IndexOf(JavaString needle)
        {
            return _value.IndexOf(needle);
        }

        public int IndexOf(char needle, int startIndex)
        {
            return _value.IndexOf(needle, startIndex);
        }

        public int IndexOf(JavaString needle, int startIndex)
        {
            return _value.IndexOf(needle, startIndex);
        }

        public JavaString Substring(int startIndex, int endIndex)
        {
            return new JavaString(_value[startIndex..endIndex]);
        }

        public JavaString Substring(int startIndex)
        {
            return new JavaString(_value[startIndex..]);
        }

        public JavaString Trim()
        {
            /*
             Trim specification in Java: https://docs.oracle.com/javase/8/docs/api/java/lang/String.html

             If this String object represents an empty character sequence, or the first and last characters of character sequence represented
             by this String object both have codes greater than '\u0020' (the space character), then a reference to this String object is returned.

             Otherwise, if there is no character with a code greater than '\u0020' in the string, then a String object representing an empty string is returned.

             Otherwise, let k be the index of the first character in the string whose code is greater than '\u0020', and let m be the index of the last
             character in the string whose code is greater than '\u0020'. A String object is returned, representing the substring of this string that begins
             with the character at index k and ends with the character at index m-that is, the result of this.substring(k, m + 1).
            */

            if (string.IsNullOrEmpty(_value) || _value[0] > 0x20 && _value[^1] > 0x20)
                return new JavaString(_value);

            int k = _value.Length;
            for (var i = 0; i < _value.Length; i++)
            {
                if (_value[i] <= 0x20)
                    continue;

                k = i;
                break;
            }

            if (k >= _value.Length)
                return new JavaString(string.Empty);

            int m = _value.Length - 1;
            for (var i = _value.Length - 1; i > k; i--)
            {
                if (_value[i] <= 0x20)
                    continue;

                m = i;
                break;
            }

            return new JavaString(_value[k..(m + 1)]);
        }

        public static byte[] GetBytes(JavaString value)
        {
            return DocomoCsJavaBridge.Providers.EncodingProvider.Instance.GetEncoding().GetBytes(value);
        }

        public static JavaString Concat(params char[] chars)
        {
            return new JavaString(string.Concat(chars));
        }

        public static bool IsNullOrEmpty(JavaString value)
        {
            return string.IsNullOrEmpty(value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is JavaString javaString)
                return javaString._value == _value;

            return _value.Equals(obj);
        }

        public static implicit operator string(JavaString s) => s._value;

        public static implicit operator JavaString(string s) => new(s);

        public override string ToString()
        {
            return _value;
        }
    }
}
