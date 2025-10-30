using com.nttdocomo;
using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm2.c.Managers;

[ClassName("c", "l")]
public class ScratchPadManager
{
    [ConstructorName("l")]
    private ScratchPadManager()
    {
    }

    [FunctionName("a")]
    public static byte[] Read(int pos, int dataSize)
    {
        var result = new byte[dataSize];
        try
        {
            Stream inputStream = Connector.OpenInputStream($"scratchpad:///0;pos={pos}");
            inputStream.Read(result);

            inputStream.Close();
        }
        catch
        {
            result = null;
        }

        return result;
    }

    [FunctionName("a")]
    public static bool Write(int pos, byte[] data)
    {
        try
        {
            Stream outputStream = Connector.OpenOutputStream($"scratchpad:///0;pos={pos}");
            outputStream.Write(data);

            outputStream.Close();

            return true;
        }
        catch { }

        return false;
    }

    [FunctionName("a")]
    public static bool Write(int pos, byte value)
    {
        return Write(pos, new[] { value });
    }
}
