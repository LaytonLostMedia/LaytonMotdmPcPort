namespace com.nttdocomo.opt.device;

public class MediaPlayer
{
    private static readonly MediaPlayer _instance = new();

    public static MediaPlayer GetMediaPlayer() => _instance;

    public int Play(fs.File file) => 98;
}
