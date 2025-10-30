using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm5.c;
using LaytonMotdm5.c.Managers;
using LaytonMotdm5.c.Resources;

namespace LaytonMotdm5.scene;

[ClassName("scene", "k")]
public class MemoScene : IScene
{
    [MemberName("a")]
    private static MemoScene Instance = new();
    [MemberName("b")]
    private static int _selectedMenu;
    [MemberName("c")]
    private int c;
    [MemberName("d")]
    private JavaString[][] d;
    [MemberName("e")]
    private int[] e;
    [MemberName("f")]
    private static int[][] f = new int[][] { new int[] { 16, 31 }, new int[] { 16, 60 }, new int[] { 16, 89 }, new int[] { 16, 118 }, new int[] { 16, 147 } };
    [MemberName("g")]
    private ResourceBase[] g = new ResourceBase[9];
    [MemberName("h")]
    private GameFileManager h;

    [ConstructorName("k")]
    private MemoScene()
    {
    }

    [FunctionName("a")]
    public static MemoScene GetInstance(int selectedState)
    {
        _selectedMenu = selectedState;
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        h = new GameFileManager();
        GameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        e = new int[5];
        if (_selectedMenu == 0)
        {
            GameContext.SaveData.v1();
        }

        for (int var3 = 0; var3 < 5; ++var3)
        {
            e[var3] = GameContext.SaveData.f1(var3 + 1);
        }

        JavaString[] var5 = new JavaString[] { "bg_suiri.gif", "memo.dat" };
        if (!h.LoadFiles(var5))
        {
            c = 99;
        }
        else
        {
            c = 0;
            a1();
            g[0] = ImageResource.Create(h.GetLoadedImage("bg_suiri.gif"));
            var2.AddChild(g[0], (240 - g[0].GetWidth()) / 2, 0);
            g[1] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            ((ImageResource)g[1]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            g[0].AddChild(g[1], 180, 175);
            g[2] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
            g[3] = ImageResource.Create((ImageResource)g[2]);
            ((ImageResource)g[2]).ClipRect(0, 0, 40, 15);
            ((ImageResource)g[3]).ClipRect(40, 0, 40, 15);
            g[0].AddChild(g[3], 190, 175);
            g[0].AddChild(g[2], 190, 175);

            for (int var4 = 0; var4 < 5; ++var4)
            {
                g[4 + var4] = ScriptTextResource.Create(b1(var4 + e[var4] * 5));
                g[0].AddChild(g[4 + var4], f[var4][0], f[var4][1]);
            }

            var2.ExecuteTransition(1);
        }
    }

    [FunctionName("b")]
    public bool Update(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        bool var3 = false;
        switch (c)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    c = 1;
                }
                break;
            case 1:
                if (var2._transitionState == 2)
                {
                    var2.ExecuteTransition(1);
                }

                if (var2._transitionState == 0)
                {
                    if (GameContext.IsKeyPressed(Display.KEY_MAIN))
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        var3 = true;
                    }

                    if (GameContext.IsKeyPressed(Display.KEY_TWO))
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        var3 = true;
                    }
                }

                if (var3)
                {
                    g[2].SetPosition(192, 177);
                    g[3].SetPosition(192, 177);
                    c = 99;
                    var2.ExecuteTransition(0);
                }
                break;
            case 99:
                if (var2._transitionState == 2)
                {
                    if (_selectedMenu == 1)
                    {
                        GameContext.RoomData.ToggleBitFlag(100, false);
                        GameContext.SetCurrentScene(IngameMenuScene.GetInstance());
                    }
                    else if (_selectedMenu == 0)
                    {
                        GameContext.SetCurrentScene(TitleScene.GetInstance());
                    }
                }
                break;
        }

        return true;
    }

    [FunctionName("b")]
    private JavaString b1(int var1)
    {
        return d[var1][1];
    }

    [FunctionName("a")]
    private void a1()
    {
        var var1 = new JavaString(h.GetLoadedData("memo.dat"));
        d = new JavaString[15][];
        int var2 = 0;
        bool var3 = false;

        for (int var4 = 0; var4 < 15; ++var4)
        {
            int var8 = var1.IndexOf("[TITLE-", var2);
            var8 += 7;
            var2 = var1.IndexOf("]", var8);
            JavaString var6;
            int var5 = int.Parse(var6 = var1.Substring(var8, var2));
            var8 += var6.Length + 3;
            var2 = var1.IndexOf("\r\n", var8);
            d[var5 - 1] = new JavaString[2];
            d[var5 - 1][0] = var1.Substring(var8, var2);
            int var7 = d[var5 - 1][0].Length + 9;
            var8 += var7;
            var2 = var1.IndexOf("[end]", var8);
            d[var5 - 1][1] = var1.Substring(var8, var2 + 5);
            var2 += 2;
        }
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        for (int var2 = 8; var2 >= 0; --var2)
        {
            if (g[var2] != null)
            {
                g[var2].h1();
                g[var2] = null;
            }
        }

        e = null;
        d = (JavaString[][])null;

        try
        {
            h.Reset();
        }
        catch (Exception var3)
        {
        }

        h = null;
    }
}
