using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm5.c.Storage;

[ClassName("c", "g")]
public class StandardFileStorage
{
    [MemberName("a")]
    public static JavaString[] FileNames = new JavaString[]
    {
        "i_cur.gif", "i_back.gif",
        "syouon0.gif", "syouon1.gif",
        "bg_002.mld", "bg_003.mld", "bg_004.mld", "bg_005.mld", "bg_006.mld",
        "se_004.mld", "se_011.mld", "se_018.mld", "se_041.mld",
        "i_main20.gif", "i_main21.gif", "i_main22.gif",
        "i_main40.gif", "i_main41.gif", "i_main42.gif",
        "i_main10.gif", "i_main11.gif", "i_main12.gif",
        "i_main30.gif", "i_main31.gif", "i_main32.gif",
        "t_main20.gif", "t_main40.gif", "t_main10.gif", "t_main30.gif",
        "win_small1.gif", "win_small2.gif",
        "i_event0.gif", "i_event4.gif",
        "c00_bg_0.gif", "c01_bg_0.gif",
        "yesno_btn0.gif", "yesno_btn1.gif", "yesno_btn0f.gif", "yesno_btn1f.gif",
        "intro_balloon.gif",
        "na_plate_waku.gif", "na_plate_name.gif",
        "hakken.gif",
        "i_move0.gif", "i_move1.gif", "i_move2.gif"
    };

    [ConstructorName("g")]
    public StandardFileStorage()
    {
    }
}
