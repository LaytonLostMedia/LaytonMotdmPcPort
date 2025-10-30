using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm1.c;

[ClassName("c", "n")]
public class Helper
{
    [MemberName("a")]
    private static readonly Random _random = new();

    [FunctionName("a")]
    public static int GetRandomInt(int maxValue)
    {
        return (_random.Next() >>> 1) % maxValue;
    }

    [FunctionName("a")]
    public static JavaString ToStringPad(int value, int digits)
    {
        return ToStringPad(value, digits, true);
    }

    [FunctionName("a")]
    private static JavaString ToStringPad(int value, int digits, bool padZeroes)
    {
        if (padZeroes)
            return $"{value}".PadLeft(digits, '0');

        return $"{value}".PadLeft(digits, ' ');
    }

    [FunctionName("c")]
    private static int Count(JavaString text, JavaString subText)
    {
        int i = 0;
        byte b = 0;
        while (true)
        {
            if ((i = text.IndexOf(subText, i)) != -1)
            {
                b++;
                i++;
            }
            if (i == -1)
                return b;
        }
    }

    [FunctionName("a")]
    public static JavaString[] a1(JavaString paramString, JavaString paramString2)
    {
        return a1(0, paramString, paramString2);
    }

    [FunctionName("b")]
    public static JavaString[] b1(JavaString paramString, JavaString paramString2)
    {
        return a1(1, paramString, paramString2);
    }

    [FunctionName("a")]
    private static JavaString[] a1(int maxValue, JavaString paramString, JavaString paramString2)
    {
        JavaString[] arrayOfString;
        int i = 0;
        int j = 0;
        int k = 0;
        JavaString str;
        k = Count(str = paramString, paramString2);
        if (maxValue == 0)
        {
            arrayOfString = new JavaString[k];
        }
        else
        {
            arrayOfString = new JavaString[k + 1];
        }
        if (k == 0)
        {
            arrayOfString[0] = paramString;
        }
        else
        {
            k = 0;
            while ((j = str.IndexOf(paramString2)) != -1)
            {
                arrayOfString[k] = str.Substring(0, j);
                k++;
                i = j + paramString2.Length;
                str = str.Substring(i, str.Length);
            }
            if (maxValue == 1)
                arrayOfString[^1] = str;
        }
        return arrayOfString;
    }

    [FunctionName("a")]
    public static JavaString ConvertStringDigitsWide(JavaString text)
    {
        byte[] textBytes = JavaString.GetBytes(text);
        for (byte b1 = 0; b1 < textBytes.Length; b1++)
        {
            if (textBytes[b1] < '0' || textBytes[b1] > '9')
                return "error";
        }

        var wideBuffer = new byte[textBytes.Length * 2];
        byte b2 = 0;
        byte b3 = 0;
        while (b2 < wideBuffer.Length)
        {
            if (b2 % 2 == 0)
            {
                wideBuffer[b2] = 0x82;
            }
            else
            {
                wideBuffer[b2] = (byte)(textBytes[b3] + 31);
                b3++;
            }
            b2++;
        }
        return new JavaString(wideBuffer);
    }
}


/* Location:              D:\Users\Kirito\Desktop\Layton_Motdm\tools\DeathlyMirrorPortableEmu\Chapters\Emulator\Games\deathmirror\bin\deathmirror.jar!\c\n.class
 * Java compiler version: 1 (45.3)
 * JD-Core Version:       1.1.3
 */