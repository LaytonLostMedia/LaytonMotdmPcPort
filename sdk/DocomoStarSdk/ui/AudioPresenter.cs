using com.nttdocomostar.media;

namespace com.nttdocomostar.ui;

public class AudioPresenter : MediaPresenter
{
    public void Pause() { }
    public void Stop() { }

    public static AudioPresenter GetAudioPresenter() => new();
    public static AudioPresenter GetAudioPresenter(int var1) => new();

    public MediaResource GetMediaResource() => null;
    public void SetSound(MediaSound sound) { }
    public void Play(int t) { }
    public void Play() { }

    public void SetAttribute(int a, int b) { }

    public void SetMediaListener(MediaListener mediaListener) { }

    public int GetCurrentTime() => 0;
}
