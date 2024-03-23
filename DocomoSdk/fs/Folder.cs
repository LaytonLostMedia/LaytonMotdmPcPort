namespace com.nttdocomo.fs;

public class Folder
{
    private readonly AccessToken _token;

    public Folder(AccessToken token)
    {
        _token = token;
    }

    public File GetFile(string filePath) => new(filePath);
}
