using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm1.c.Managers;

[ClassName("c","q")]
public abstract class FileManagerBase
{
    [MemberName("b")]
    protected static JavaString[] baseDirectories = null;
    [MemberName("c")]
    protected static JavaString indexFileName = "";
    [MemberName("d")]
    protected static JavaString dataFileName = "";

    [ConstructorName("q")]
    protected FileManagerBase()
    {
    }

    [FunctionName("f")]
    protected static void Initialize()
    {
        baseDirectories = new JavaString[1];
        baseDirectories[0] = "resource:///tbl/";
        indexFileName = "0.dat";
        dataFileName = "1.dat";
    }
}
