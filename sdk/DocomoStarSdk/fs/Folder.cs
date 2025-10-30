using DocomoCsJavaBridge;
using java.lang;

namespace com.nttdocomostar.fs;

public class Folder
{
    private readonly AccessToken _token;

    public Folder(AccessToken token)
    {
        _token = token;
    }

    public File CreateFile(JavaString filePath /*, SDBindingEncryptionAttribute[] encryptionAttr*/)
    {
        filePath = Path.Combine(PathProvider.Instance.GetStoragePath(), filePath);
        using Stream file = System.IO.File.Create(filePath);

        return GetFile(filePath);
    }
    public File GetFile(JavaString filePath) => new(Path.Combine(PathProvider.Instance.GetStoragePath(), filePath));
    public int GetFreeSize() => int.MaxValue;
}
