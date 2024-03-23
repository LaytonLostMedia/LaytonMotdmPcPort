namespace com.nttdocomo.ui;

public class MediaSound : MediaResource, IDisposable
{
    private readonly byte[] _data;

    public MediaSound(byte[] data)
    {
        _data = data;
    }

    public void Use() { }

    public void Dispose()
    {
    }
}
