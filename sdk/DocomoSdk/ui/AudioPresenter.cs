namespace com.nttdocomo.ui;

public class AudioPresenter : MediaPresenter
{
    public void Pause() { }
    public void Stop() { }

    public static AudioPresenter GetAudioPresenter() => new();

    public MediaResource GetMediaResource() => null;
    public void SetSound(MediaSound sound) { }
    public void Play(int t) { }

    public void SetAttribute(int a, int b) { }

    public void SetMediaListener(MediaListener mediaListener){}
}
