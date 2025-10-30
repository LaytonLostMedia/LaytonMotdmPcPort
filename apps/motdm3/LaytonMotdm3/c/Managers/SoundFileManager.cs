using com.nttdocomo.opt.device;
using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm3.c.Managers;

[ClassName("c", "t")]
public class SoundFileManager
{
    [MemberName("a")]
    private MediaPlayer _mediaPlayer = MediaPlayer.GetMediaPlayer();

    [ConstructorName("t")]
    public SoundFileManager()
    {
    }

    [FunctionName("a")]
    public void Play(com.nttdocomo.fs.File paramFile)
    {
        try
        {
            switch (_mediaPlayer.Play(paramFile))
            {
                case 97:
                case 98:
                    return;
            }
        }
        catch { }
    }
}
