namespace com.nttdocomo.ui;

public class MediaManager
{
    public static MediaImage GetImage(byte[] data) => new(data);
    public static MediaSound GetSound(byte[] data) => new(data);
}