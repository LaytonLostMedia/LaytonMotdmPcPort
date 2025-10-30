namespace com.nttdocomo.ui;

public class MediaManager
{
    public static MediaImage GetImage(byte[] data) => new(data);
    public static MediaImage GetImage(string path)
    {
        Stream stream = Connector.OpenInputStream(path);
        var buffer = new byte[stream.Length];

        _ = stream.Read(buffer);
        return GetImage(buffer);
    }

    public static MediaSound GetSound(byte[] data) => new(data);
}