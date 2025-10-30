using com.nttdocomostar.ui;

namespace com.nttdocomostar.media;

public class MediaImage
{
    private readonly byte[] data;

    public MediaImage(byte[] data)
    {
        this.data = data;
    }

    public void Use() { }

    public Image GetImage() => new(data);
}
