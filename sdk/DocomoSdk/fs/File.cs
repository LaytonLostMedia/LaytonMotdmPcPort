using com.nttdocomo.io;
using java.lang;

namespace com.nttdocomo.fs;

public class File
{
    private readonly JavaString _filePath;

    public File(JavaString filePath)
    {
        _filePath = filePath;
    }

    public int Length => (int)new FileInfo(_filePath).Length;

    public FileEntity Open(int mode)
    {
        if(!System.IO.File.Exists(_filePath))
            java.util.System.Out.Error($"Media file {_filePath} not found.");

        return new(System.IO.File.Open(_filePath, FileMode.Open, FileAccess.ReadWrite));
    }

    public void Delete()
    {
        if (!System.IO.File.Exists(_filePath))
            java.util.System.Out.Error($"Media file {_filePath} not found.");

        System.IO.File.Delete(_filePath);
    }
}
