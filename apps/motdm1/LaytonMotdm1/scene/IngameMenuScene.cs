using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm1.c;
using LaytonMotdm1.c.Managers;
using LaytonMotdm1.c.Resources;

namespace LaytonMotdm1.scene;

[ClassName("scene", "e")]
public class IngameMenuScene : IScene
{
    [MemberName("a")]
    private int a;
    [MemberName("b")]
    private int b = 0;
    [MemberName("c")]
    private int c;
    [MemberName("d")]
    private GameFileManager d;
    [MemberName("e")]
    private ResourceBase[] e2 = new ResourceBase[21];
    [MemberName("f")]
    private ResourceBase[] f = new ResourceBase[11];
    [MemberName("g")]
    private ResourceBase[] g = new ResourceBase[1];
    [MemberName("h")]
    private ResourceBase[] h = new ResourceBase[2];
    [MemberName("i")]
    private bool i = false;
    [MemberName("j")]
    private int j;
    [MemberName("k")]
    private int k;
    [MemberName("l")]
    private int l;
    [MemberName("m")]
    private int m;
    [MemberName("n")]
    private int n;
    [MemberName("o")]
    private int o;
    [MemberName("p")]
    private int p;
    [MemberName("q")]
    private int q;
    [MemberName("r")]
    private int[][] r = new int[][] { new int[] { 11, 40 }, new int[] { 70, 82 }, new int[] { 125, 40 }, new int[] { 175, 75 } };

    [MemberName("s")]
    private static IngameMenuScene Instance = new();
    [MemberName("t")]
    private static int[][] t = new int[][] { new int[] { 41, 97 }, new int[] { 131, 97 } };

    [ConstructorName("e")]
    private IngameMenuScene()
    {
    }

    [FunctionName("a")]
    public static IngameMenuScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        c = gameContext.SaveData.z1();
        ScreenResource var2 = gameContext.ScreenResource;
        d = new GameFileManager();
        j = 0;
        if (!i)
        {
            k = j;
        }

        b = 0;
        l = k;
        o = 0;
        p = 1;
        q = 0;
        gameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        JavaString[] var3 = new JavaString[] { "bag.gif", "i_bag_mono3.gif", "i_bag_suiri0.gif", "i_bag_suiri1.gif", "i_bag_suiri2.gif", "i_bag_mono0.gif", "i_bag_mono1.gif", "i_bag_mono2.gif", "i_bag80.gif", "i_bag81.gif", "i_bag82.gif", "i_bag40.gif", "i_bag41.gif", "i_bag42.gif", "i_bag_mono4.gif", "i_bag_mono5.gif", "i_bag_mono6.gif", "new_spr.gif", "i_bag_close.gif", "i_bag_return.gif" };
        if (!d.LoadFiles(var3))
        {
            n = 4;
            a = 99;
        }
        else
        {
            a = 0;

            int var4;
            for (var4 = 0; var4 < 17; ++var4)
            {
                e2[0 + var4] = ImageResource.Create(d.GetLoadedImage(var3[var4]));
            }

            var2.AddChild(e2[0], (240 - ((ImageResource)e2[0]).GetWidth()) / 2, 0);

            for (var4 = 0; var4 < 3; ++var4)
            {
                for (int var5 = 0; var5 < 4; ++var5)
                {
                    e2[0].AddChild(e2[2 + var4 + var5 * 3], r[var5][0], r[var5][1]);
                    if (var4 > 0)
                    {
                        ((ImageResource)e2[2 + var4 + var5 * 3]).SetIsVisible(false);
                    }
                }
            }

            for (var4 = 0; var4 < 3; ++var4)
            {
                e2[0].AddChild(e2[14 + var4], r[1][0], r[1][1]);
                if (c != 3)
                {
                    ((ImageResource)e2[14 + var4]).SetIsVisible(false);
                }
                else
                {
                    ((ImageResource)e2[6]).SetIsVisible(false);
                    e2[15].SetIsVisible(false);
                    e2[16].SetIsVisible(false);
                }
            }

            e2[17] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            e2[18] = ImageResource.Create((ImageResource)e2[17]);
            e2[0].AddChild(e2[17], e2[0].GetWidth() / 2, 0);
            e2[0].AddChild(e2[18], 164, 164);
            ((ImageResource)e2[17]).SetFlipMode(Graphics.FLIP_VERTICAL);
            ((ImageResource)e2[18]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            if (gameContext.SaveData.i1() == 0)
            {
                e2[0].AddChild(e2[1], r[1][0], r[1][1]);
                e2[5].SetIsVisible(false);
            }

            if (gameContext.SaveData.i1() == 3)
            {
                e2[5].SetIsVisible(false);
            }

            h[0] = ImageResource.Create(d.GetLoadedImage("new_spr.gif"));
            h[1] = ImageResource.Create(d.GetLoadedImage("new_spr.gif"));
            ((ImageResource)h[0]).b1(0, 0, 30, 10);
            ((ImageResource)h[1]).b1(0, 0, 30, 10);
            if (gameContext.RoomData.GetBitFlag(100))
            {
                e2[0].AddChild(h[0], 40, 60);
            }

            if (gameContext.SaveData.i1() == 1)
            {
                e2[0].AddChild(h[1], 100, 100);
            }

            e2[19] = ImageResource.Create(d.GetLoadedImage("i_bag_close.gif"));
            e2[20] = ImageResource.Create((ImageResource)e2[19]);
            e2[0].AddChild(e2[20], 173, 154);
            e2[0].AddChild(e2[19], 173, 154);
            ((ImageResource)e2[20]).ClipRect(54, 0, 54, 31);
            ((ImageResource)e2[19]).ClipRect(0, 0, 54, 31);
            f[8] = ImageResource.Create((ImageResource)e2[17]);
            e2[0].AddChild(f[8], 203, 8);
            ((ImageResource)f[8]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            f[8].SetIsVisible(false);
            f[0] = ImageResource.Create(d.GetLoadedImage("i_bag_return.gif"));
            f[1] = ImageResource.Create((ImageResource)f[0]);
            e2[0].AddChild(f[0], 214, 2);
            e2[0].AddChild(f[1], 214, 2);
            ((ImageResource)f[0]).ClipRect(0, 0, 24, 24);
            ((ImageResource)f[1]).ClipRect(24, 0, 24, 24);
            f[1].SetIsVisible(false);
            g[0] = RectangleResource.Create(e2[0].GetWidth(), e2[0].GetHeight(), 1, 255, 255, 255, 128);
            e2[0].AddChild(g[0]);
            g[0].SetIsVisible(false);
            f[2] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small1.gif"));
            g[0].AddChild(f[2], (240 - f[2].GetWidth()) / 2, 50);
            f[3] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
            f[4] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
            g[0].AddChild(f[3], t[0][0], t[0][1]);
            g[0].AddChild(f[4], t[0][0], t[0][1]);
            f[4].SetIsVisible(false);
            f[5] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
            f[6] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));
            g[0].AddChild(f[5], t[1][0], t[1][1]);
            g[0].AddChild(f[6], t[1][0], t[1][1]);
            f[7] = ImageResource.Create((ImageResource)e2[17]);
            g[0].AddChild(f[7], 122, 104);
            ((ImageResource)f[7]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            f[9] = TextResource.Create("タイトル画面へ戻りますか？");
            f[10] = TextResource.Create("※現在のデータはセーブされません。", TextResource.FONT_TINY);
            g[0].AddChild(f[9], g[0].GetWidth() / 2, 62);
            g[0].AddChild(f[10], g[0].GetWidth() / 2, 74);
            ((TextResource)f[9]).SetAnchorType(1);
            ((TextResource)f[10]).SetAnchorType(1);
            a1(0);
            if (c == 3)
            {
                b1(0);
            }

            var2.ExecuteTransition(1);
        }
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        bool var3 = false;
        switch (a)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    a = 2;
                }
                break;
            case 1:
                ++o;
                if (o > 5)
                {
                    o = 0;
                    var2.ExecuteTransition(0);
                    a = 99;
                }
                break;
            case 2:
                if (gameContext.IsKeyPressed(Display.KEY_UP))
                {
                    if (l == 4)
                    {
                        l = m;
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                    else
                    {
                        if (b == 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }

                        b = 1;
                    }
                }

                if (gameContext.IsKeyPressed(Display.KEY_DOWN))
                {
                    if (b == 0)
                    {
                        if (l != 4)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            m = l;
                        }

                        l = 4;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        b = 0;
                    }
                }

                if (gameContext.IsKeyPressed(Display.KEY_LEFT) && b == 0)
                {
                    if (l == 2 && gameContext.SaveData.i1() == 0)
                    {
                        l -= 2;
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                    else if (l != 4)
                    {
                        --l;
                        if (l < j)
                        {
                            l = j;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                }

                if (gameContext.IsKeyPressed(Display.KEY_RIGHT) && b == 0)
                {
                    if (l == 0 && gameContext.SaveData.i1() == 0)
                    {
                        l += 2;
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                    else if (l != 4)
                    {
                        ++l;
                        if (l > 3)
                        {
                            l = 3;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                }

                if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    if (b == 0)
                    {
                        n = l;
                        if (l != 4)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        }

                        var3 = true;
                    }
                    else if (f[1].posX == 214)
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        f[1].SetPosition(f[1].posX + 2, f[1].posY + 2);
                        f[0].SetPosition(f[0].posX + 2, f[0].posY + 2);
                    }
                }

                if (gameContext.IsKeyPressed(Display.KEY_TWO))
                {
                    l = n = 4;
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                    b = 0;
                    var3 = true;
                }

                a1(0);
                if (c == 3)
                {
                    b1(0);
                }

                if (b == 0)
                {
                    f[8].SetIsVisible(false);
                    f[1].SetIsVisible(false);
                }
                else if (b == 1)
                {
                    for (int var4 = 0; var4 < 4; ++var4)
                    {
                        e2[3 + var4 * 3].SetIsVisible(false);
                    }

                    e2[17].SetIsVisible(false);
                    f[8].SetIsVisible(true);
                    f[1].SetIsVisible(true);
                }

                if (f[1].posX == 216)
                {
                    q += gameContext.d1();
                    if (q > 300)
                    {
                        q = 0;
                        g[0].SetIsVisible(true);
                        a = 4;
                        f[1].SetPosition(f[1].posX - 2, f[1].posY - 2);
                        f[0].SetPosition(f[0].posX - 2, f[0].posY - 2);
                    }
                }

                if (var3)
                {
                    a = 1;
                    a1(1);
                    if (c == 3)
                    {
                        b1(1);
                    }
                }
                break;
            case 4:
                if (gameContext.IsKeyPressed(Display.KEY_LEFT) && q == 0)
                {
                    --p;
                    if (p < 0)
                    {
                        p = 0;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                }

                if (gameContext.IsKeyPressed(Display.KEY_RIGHT) && q == 0)
                {
                    ++p;
                    if (p > 1)
                    {
                        p = 1;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                }

                if (gameContext.IsKeyPressed(Display.KEY_MAIN) && q == 0)
                {
                    if (p == 0)
                    {
                        f[3].SetPosition(t[0][0] + 2, t[0][1] + 2);
                        f[4].SetPosition(t[0][0] + 2, t[0][1] + 2);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else
                    {
                        f[5].SetPosition(t[1][0] + 2, t[1][1] + 2);
                        f[6].SetPosition(t[1][0] + 2, t[1][1] + 2);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                    }
                }

                c1(p);
                d1(gameContext);
                break;

            case 99:
                if (var2._transitionState == 2)
                {
                    switch (n)
                    {
                        // Open the memo
                        case 0:
                            i = true;
                            gameContext.SetCurrentScene(MemoScene.GetInstance(1));
                            break;

                        case 1:
                            i = true;
                            gameContext.SetCurrentScene(MinigameScene.GetInstance());
                            break;

                        // Open the settings menu
                        case 2:
                            i = true;
                            gameContext.SetCurrentScene(SettingsScene.GetInstance(GetInstance()));
                            break;

                        // Open the save menu
                        case 3:
                            i = true;
                            gameContext.SetCurrentScene(SaveGameScene.GetInstance(0));
                            break;

                        // Return to the room the menu was accessed from
                        case 4:
                            i = false;
                            gameContext.SetCurrentScene(RoomScene.GetInstance());
                            break;

                        // Return to the title screen
                        case 5:
                            i = false;
                            gameContext.SetCurrentScene(TitleScene.GetInstance());
                            break;

                        // Return to the room the menu was accessed from, if no valid option was selected
                        default:
                            i = false;
                            gameContext.SetCurrentScene(RoomScene.GetInstance());
                            java.util.System.Out.Error("例外数値計測:{0}", n);
                            break;
                    }
                }
                break;
        }

        return true;
    }

    [FunctionName("a")]
    private void a1(int var1)
    {
        for (int var2 = 0; var2 < 4; ++var2)
        {
            e2[3 + var2 * 3].SetIsVisible(false);
        }

        e2[20].SetIsVisible(false);
        if (var1 == 0)
        {
            if (l < 4)
            {
                e2[3 + l * 3].SetIsVisible(true);
            }
            else
            {
                e2[20].SetIsVisible(true);
            }
        }
        else if (l < 4)
        {
            e2[2 + l * 3].SetIsVisible(false);
            e2[4 + l * 3].SetIsVisible(true);
            e2[4 + l * 3].SetPosition(e2[4 + l * 3].posX + 2, e2[4 + l * 3].posY + 2);
        }
        else
        {
            e2[20].SetIsVisible(true);
            e2[19].SetPosition(e2[19].posX + 2, e2[19].posY + 2);
            e2[20].SetPosition(e2[20].posX + 2, e2[20].posY + 2);
            ((ImageResource)e2[19]).ClipRect(108, 0, 54, 31);
            ((ImageResource)e2[20]).ClipRect(162, 0, 54, 31);
        }

        if (l == 4)
        {
            e2[17].SetIsVisible(false);
            e2[18].SetIsVisible(true);
        }
        else
        {
            e2[18].SetIsVisible(false);
            e2[17].SetIsVisible(true);
            e2[17].SetPosition(r[l][0] + 15, r[l][1] - e2[17].GetHeight() - 3);
        }
    }

    [FunctionName("b")]
    private void b1(int var1)
    {
        e2[5].SetIsVisible(false);
        e2[6].SetIsVisible(false);
        e2[7].SetIsVisible(false);
        e2[15].SetIsVisible(false);
        if (l == 1 && b != 1)
        {
            if (var1 == 0)
            {
                e2[15].SetIsVisible(true);
                return;
            }

            e2[14].SetIsVisible(false);
            e2[16].SetIsVisible(true);
            e2[16].SetPosition(e2[16].posX + 2, e2[16].posY + 2);
        }
    }

    [FunctionName("c")]
    private void c1(int var1)
    {
        int[][] var2 = new int[][] { new int[] { 32, 104 }, new int[] { 122, 104 } };
        f[7].SetPosition(var2[var1][0], var2[var1][1]);
        f[4].SetIsVisible(false);
        f[6].SetIsVisible(false);
        if (var1 == 0)
        {
            f[4].SetIsVisible(true);
        }
        else
        {
            f[6].SetIsVisible(true);
        }
    }

    [FunctionName("d")]
    private void d1(GameContext var1)
    {
        byte var2 = 0;
        if (f[3].posX == t[0][0] + 2)
        {
            var2 = 1;
        }

        if (f[5].posX == t[1][0] + 2)
        {
            var2 = 2;
        }

        if (var2 != 0)
        {
            q += var1.d1();
            if (q > 300)
            {
                q = 0;
                f[5].SetPosition(t[1][0], t[1][1]);
                f[6].SetPosition(t[1][0], t[1][1]);
                if (var2 == 1)
                {
                    n = 5;
                    a = 1;
                    return;
                }

                g[0].SetIsVisible(false);
                a = 2;
            }
        }
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        k = l;

        int var2;
        for (var2 = 1; var2 >= 0; --var2)
        {
            if (h[var2] != null)
            {
                h[var2].f1();
                h[var2] = null;
            }
        }

        for (var2 = 20; var2 >= 0; --var2)
        {
            if (e2[var2] != null)
            {
                var1.ScreenResource.RemoveChild(e2[0]);
                e2[var2].f1();
                e2[var2] = null;
            }
        }

        for (var2 = 10; var2 >= 0; --var2)
        {
            if (f[var2] != null)
            {
                f[var2].f1();
                f[var2] = null;
            }
        }

        for (var2 = 0; var2 >= 0; --var2)
        {
            if (g[var2] != null)
            {
                g[var2].f1();
                g[var2] = null;
            }
        }

        try
        {
            d.Reset();
        }
        catch (Exception var3)
        {
        }

        d = null;
    }
}
