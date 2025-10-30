using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm1.c;
using LaytonMotdm1.c.Managers;
using LaytonMotdm1.c.Resources;

namespace LaytonMotdm1.scene;

// Scene for moving to other rooms from the current room

[ClassName("scene", "i")]
public class RoomExitsScene : IScene
{
    [MemberName("a")]
    private int a;
    [MemberName("b")]
    private ResourceBase[] b;
    [MemberName("c")]
    private ResourceBase c;
    [MemberName("d")]
    private ResourceBase d;
    [MemberName("e")]
    private ResourceBase[] e;
    [MemberName("f")]
    private ResourceBase[] f;
    [MemberName("g")]
    private ResourceBase g;
    [MemberName("h")]
    private int h;
    [MemberName("i")]
    private int i2;
    [MemberName("j")]
    private int j;
    [MemberName("k")]
    private int _exitIndex = 0;
    [MemberName("l")]
    private int l = 0;
    [MemberName("m")]
    private int m = 0;
    [MemberName("n")]
    private int n = 0;
    [MemberName("o")]
    private int o = 0;

    [MemberName("p")]
    private static RoomExitsScene Instance = new();

    [ConstructorName("i")]
    private RoomExitsScene()
    {
    }

    [FunctionName("a")]
    public static RoomExitsScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        _exitIndex = 0;
        gameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        a = 0;
        l = gameContext.RoomData.GetExitCount();
        b = new ResourceBase[l];

        int var13;
        int var14;
        for (var13 = 0; var13 < l; ++var13)
        {
            if ((var14 = gameContext.RoomData.h1(var13)) == 5)
            {
                b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_move2.gif"));
            }
            else if (var14 == 6)
            {
                b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
                ((ImageResource)b[var13]).ClipRect(0, 0, 40, 15);
            }
            else if (var14 == 0)
            {
                b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_move0.gif"));
            }
            else
            {
                b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_move1.gif"));
                if (var14 == 3)
                {
                    ((ImageResource)b[var13]).SetFlipMode(Graphics.FLIP_VERTICAL);
                }

                if (var14 == 4)
                {
                    ((ImageResource)b[var13]).SetFlipMode(Graphics.FLIP_ROTATE_LEFT);
                }

                if (var14 == 2)
                {
                    ((ImageResource)b[var13]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
                }
            }
        }

        d = ImageResource.Create(gameContext.ScriptResourceFileManager.GetLoadedImage(gameContext.RoomData.GetBackground()));
        if (gameContext.RoomData.IsBackgroundFlipped())
        {
            ((ImageResource)d).SetFlipMode(Graphics.FLIP_HORIZONTAL);
        }
        else
        {
            ((ImageResource)d).SetFlipMode(Graphics.FLIP_NONE);
        }

        var2.AddChild(d, (240 - d.GetWidth()) / 2, 0);
        int var15;
        int[] var16;
        if ((var13 = gameContext.RoomData.GetBackgroundObjectCount()) > 0)
        {
            JavaString var20 = "bgoj_" + Helper.ToStringPad(gameContext.SaveData.GetRoomId() + 1, 3) + ".dat";
            e = gameContext.RoomData.a1(gameContext.ScriptResourceFileManager, var20);

            for (var15 = 0; var15 < var13; ++var15)
            {
                if (gameContext.RoomData.IsBackgroundObjectFlipped(var15))
                {
                    ((AnimatedImageResource)e[var15]).SetFlipMode(Graphics.FLIP_HORIZONTAL);
                }
                else
                {
                    ((AnimatedImageResource)e[var15]).SetFlipMode(Graphics.FLIP_NONE);
                }

                var16 = gameContext.RoomData.GetBackgroundPosition(var15);
                d.AddChild(e[var15], var16[0], var16[1]);
            }
        }

        int var17;
        int var24;
        if ((var14 = gameContext.RoomData.GetPotCount()) > 0)
        {
            JavaString var21 = "bgoj_" + Helper.ToStringPad(gameContext.SaveData.GetRoomId(), 3) + ".dat";
            e = gameContext.RoomData.LoadBackgroundResource(gameContext.ScriptResourceFileManager, var21, 0);
            int var22 = 0;

            for (var17 = 0; var22 < var14; ++var22)
            {
                if (gameContext.RoomData.GetPotAmount(var22) == 0)
                {
                    int[] var18 = gameContext.RoomData.GetPotPos(var22);
                    d.AddChild(e[var17], var18[0], var18[1]);
                    ++var17;
                }
            }

            f = new ResourceBase[e.Length];
            var22 = gameContext.RoomData.I1();
            int[][] var23 = new int[f.Length][];
            var24 = 0;

            int var19;
            for (var19 = 0; var24 < var14; ++var24)
            {
                var23[var19] = new int[2];
                if (gameContext.RoomData.GetPotAmount(var24) == 0)
                {
                    var23[var19] = gameContext.RoomData.GetPotPos(var24);
                    ++var19;
                }
            }

            for (var24 = 0; var24 < f.Length; ++var24)
            {
                var19 = int.Parse(gameContext.RoomData.c[var22][0]);
                var22 = gameContext.RoomData.A1(var22);
                f[var24] = KeyboardResource.Create(gameContext.ScriptResourceFileManager.GetLoadedImage("save_number.gif"), 7, 10, 10, Helper.ToStringPad(var19, 3));
                if (var24 < 4)
                {
                    d.AddChild(f[var24], var23[var24][0] + 3, 75 - var24 % 2 * 15);
                }
                else
                {
                    d.AddChild(f[var24], var23[var24][0] + 3, 156 - var24 % 2 * 15);
                }
            }

            gameContext.RoomData.a1(false);
        }

        g = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
        ((ImageResource)g).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
        g.SetIsVisible(false);
        j = -1;

        for (var15 = 0; var15 < l; ++var15)
        {
            var17 = (var16 = gameContext.RoomData.GetExitPosition(var15))[0];
            var24 = var16[1];
            if (gameContext.RoomData.h1(var15) == 6)
            {
                j = var15;
                var17 = d.GetWidth() - b[var15].GetWidth() - 22;
                var24 = d.GetHeight() - b[var15].GetHeight() - 9;
                b[var15].SetPosition(var17, var24);
                c = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
                c.SetIsVisible(false);
                ((ImageResource)c).ClipRect(40, 0, 40, 15);
                d.AddChild(c, var17, var24);
                h = var17 - 17;
                i2 = var24 + 1;
                d.AddChild(g, h, i2);
            }

            d.AddChild(b[var15], var17, var24);
        }

        gameContext.b1(0);
        b1();
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        switch (a)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    a = 1;
                }
                break;
            case 1:
                int var3 = gameContext.MoveCursor(_exitIndex, gameContext.RoomData.i1(), gameContext.RoomData.j1(), false);
                if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    if (j != _exitIndex)
                    {
                        a = 99;
                        var2.ExecuteTransition(0);
                        gameContext.SaveData.SetRoomId(gameContext.RoomData.GetRoomId(_exitIndex));
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                    }
                    else
                    {
                        c1();
                        gameContext.SetCurrentScene(RoomScene.GetInstance());
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_TWO))
                {
                    if (j >= 0)
                    {
                        _exitIndex = j;
                        a = 98;
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                        c1();
                    }
                }
                else if (var3 != -1)
                {
                    _exitIndex = var3;
                    AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100);
                }

                b1();
                break;
            case 98:
                ++m;
                if (m > 3)
                {
                    m = 0;
                    gameContext.SetCurrentScene(RoomScene.GetInstance());
                }
                break;
            case 99:
                if (var2._transitionState == 2 && AudioManager.d1(1) != 1)
                {
                    gameContext.SetCurrentScene(RoomScene.GetInstance());
                }
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        int var2;
        if (e != null)
        {
            for (var2 = 0; var2 < e.Length; ++var2)
            {
                d.RemoveChild(e[var2]);
                e[var2] = null;
            }
        }

        if (f != null)
        {
            for (var2 = 0; var2 < f.Length; ++var2)
            {
                d.RemoveChild(f[var2]);
                f[var2] = null;
            }
        }

        for (var2 = 0; var2 < b.Length; ++var2)
        {
            d.RemoveChild(b[var2]);
            b[var2] = null;
        }

        d.RemoveChild(c);
        c = null;
        d.RemoveChild(g);
        g = null;
        var1.ScreenResource.RemoveChild(d);
        d = null;
    }

    [FunctionName("b")]
    private void b1()
    {
        int var1;
        if (_exitIndex != j)
        {
            ++o;
            if (o < 10)
            {
                b[_exitIndex].SetIsVisible(!b[_exitIndex].IsVisible());
                b[_exitIndex].SetIsVisible(true);
            }
            else if (o < 20)
            {
                b[_exitIndex].SetIsVisible(false);
            }
            else
            {
                o = 0;
            }

            g.SetIsVisible(false);
            if (j >= 0)
            {
                ((ImageResource)b[j]).ClipRect(0, 0, 40, 15);
                c.SetIsVisible(false);
            }

            for (var1 = 0; var1 < b.Length; ++var1)
            {
                if (_exitIndex != var1)
                {
                    b[var1].SetIsVisible(true);
                }
            }

        }
        else
        {
            for (var1 = 0; var1 < b.Length; ++var1)
            {
                b[var1].SetIsVisible(true);
            }

            g.SetIsVisible(true);
            if (j >= 0)
            {
                c.SetIsVisible(true);
            }

            GameContext.a1((ImageResource)g, h, i2, n);
            ++n;
        }
    }

    [FunctionName("c")]
    private void c1()
    {
        b[j].SetPosition(b[j].posX + 2, b[j].posY + 2);
        c.SetPosition(c.posX + 2, c.posY + 2);
    }
}
