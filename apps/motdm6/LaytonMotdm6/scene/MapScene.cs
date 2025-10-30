using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm6.c;
using LaytonMotdm6.c.Managers;
using LaytonMotdm6.c.Resources;

namespace LaytonMotdm6.scene;

[ClassName("scene", "o")]
public class MapScene : IScene
{
    [MemberName("a")]
    private static MapScene Instance = new();
    [MemberName("b")]
    private int b;
    [MemberName("c")]
    private int c;
    [MemberName("d")]
    private ResourceBase[] d = new ResourceBase[5];
    [MemberName("e")]
    private TextResource[] e = new TextResource[2];
    [MemberName("f")] 
    private ResourceBase f;
    [MemberName("g")] 
    private ResourceBase[] g = new ResourceBase[2];
    [MemberName("h")] 
    private ResourceBase _resourceBase;
    [MemberName("i")] 
    private int i = 0;
    [MemberName("j")] 
    private int j;
    [MemberName("k")] 
    private int k;
    [MemberName("l")] 
    private GameFileManager l;
    [MemberName("m")] 
    private JavaString m;
    [MemberName("n")] 
    private JavaString n2;
    [MemberName("o")] 
    private int[] o = new int[2];
    [MemberName("p")] 
    private int p;

    [ConstructorName("o")]
    private MapScene()
    {
    }

    [FunctionName("a")]
    public static MapScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        l = new GameFileManager();
        GameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        b = 0;
        JavaString[] var3 = new JavaString[] { "map_01.jpg", "font7.gif", "i_mapico.gif", "i_toketa.gif", "map_basyo.gif", "map_mokuteki.gif", "map.dat", "target.dat" };
        if (l.LoadFiles(var3))
        {
            b = 0;
            e[0] = TextResource.Create("");
            e[1] = TextResource.Create("");
            c = GameContext.SaveData.GetRoomId() - 1;
            a1(c);
            int var4 = GameContext.RoomData.f1() - 1;
            b1(var4);
            d[0] = ImageResource.Create(l.GetLoadedImage(var3[0 + p]));
            ((ImageResource)d[0]).SetAnchorType(ResourceBase.ANCHOR_CENTER);
            var2.AddChild(d[0], 120, 0);
            d[3] = ImageResource.Create(l.GetLoadedImage("map_basyo.gif"));
            d[0].AddChild(d[3], 66 - d[0].GetWidth() / 2, 1);
            d[4] = ImageResource.Create(l.GetLoadedImage("map_mokuteki.gif"));
            d[0].AddChild(d[4], (240 - d[4].GetWidth() - d[0].GetWidth()) / 2, 192);
            d[1] = ImageResource.Create(l.GetLoadedImage("i_mapico.gif"));
            d[0].AddChild(d[1], o[0] - d[0].GetWidth() / 2, o[1]);
            e[1].SetText(n2);
            d[3].AddChild(e[1], (d[3].GetWidth() - e[1].GetWidth()) / 2, e[1].GetHeight() / 2 - 2);
            e[0].SetText(m);
            d[4].AddChild(e[0], (d[4].GetWidth() - e[0].GetWidth()) / 2, 6);
            d[2] = ImageResource.Create(l.GetLoadedImage("i_toketa.gif"));
            d[0].AddChild(d[2], 164 - d[0].GetWidth() / 2, 220);
            f = KeyboardResource.Create(l.GetLoadedImage("font7.gif"), 9, 12, 10, 0);
            d[0].AddChild(f, 209 - d[0].GetWidth() / 2, 221);
            ((KeyboardResource)f).b1(0);
            ((KeyboardResource)f).a1(GameContext.SaveData.GetQuestionsSolvedCount().ToString());
            g[0] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
            g[1] = ImageResource.Create((ImageResource)g[0]);
            ((ImageResource)g[0]).ClipRect(0, 0, 40, 15);
            ((ImageResource)g[1]).ClipRect(40, 0, 40, 15);
            int var5 = d[0].GetWidth() / 2 - g[0].GetWidth() - 22;
            int var6 = d[0].GetHeight() - g[0].GetHeight() - 9;
            d[0].AddChild(g[1], var5, var6);
            d[0].AddChild(g[0], var5, var6);
            _resourceBase = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            ((ImageResource)_resourceBase).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            j = var5 - 17;
            k = var6 + 2;
            d[0].AddChild(_resourceBase, j, k);
            var2.ExecuteTransition(1);
        }
        else
        {
            b = 99;
        }
    }

    [FunctionName("b")]
    public bool Update(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        bool var3 = false;
        switch (b)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    b = 1;
                }
                break;
            case 1:
                GameContext.a1((ImageResource)_resourceBase, j, k, i);
                ++i;
                if (GameContext.IsKeyPressed(Display.KEY_MAIN) || GameContext.IsKeyPressed(Display.KEY_TWO))
                {
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                    var3 = true;
                }

                if (var3)
                {
                    b = 99;
                    var2.ExecuteTransition(0);
                }
                break;
            case 99:
                if (var2._transitionState == 2)
                {
                    GameContext.SetCurrentScene(RoomScene.GetInstance());
                }
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        if (_resourceBase != null)
        {
            _resourceBase.h1();
            _resourceBase = null;
        }

        int var2;
        for (var2 = g.Length - 1; var2 >= 0; --var2)
        {
            if (g[var2] != null)
            {
                g[var2].h1();
                g[var2] = null;
            }
        }

        if (f != null)
        {
            f.h1();
            f = null;
        }

        for (var2 = e.Length - 1; var2 >= 0; --var2)
        {
            if (e[var2] != null)
            {
                e[var2].h1();
                e[var2] = null;
            }
        }

        for (var2 = 4; var2 >= 0; --var2)
        {
            if (d[var2] != null)
            {
                var1.ScreenResource.RemoveChild(d[var2]);
                d[var2].h1();
                d[var2] = null;
            }
        }

        try
        {
            l.Reset();
        }
        catch (Exception var3)
        {
        }

        l = null;
    }

    [FunctionName("a")]
    private void a1(int var1)
    {
        JavaString[] var3 = Helper.a1(new JavaString(l.GetLoadedData("map.dat")), "\r\n");
        if (var1 < 0 || var1 >= var3.Length)
        {
            java.util.System.Out.Error("現在地の値が不正です:{0}", var1);
            var1 = 0;
        }

        JavaString[] var4 = Helper.b1(var3[var1], ",");
        p = int.Parse(var4[0]) - 1;
        n2 = var4[1];
        o[0] = int.Parse(var4[2]);
        o[1] = int.Parse(var4[3]);
    }

    [FunctionName("b")]
    private void b1(int var1)
    {
        JavaString[] var3 = Helper.a1(new JavaString(l.GetLoadedData("target.dat")), "\r\n");
        if (var1 < 0 || var1 >= var3.Length)
        {
            java.util.System.Out.Error("目的IDの値が不正です:{0}", var1);
            var1 = 0;
        }

        m = var3[var1];
    }
}
