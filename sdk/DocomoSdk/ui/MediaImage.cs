namespace com.nttdocomo.ui;

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
