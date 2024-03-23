using com.nttdocomo.ui;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using DocomoLayton.game;
using DocomoLayton.game.Resources;

namespace DocomoLayton.nazo;

[ClassName("nazo", "a")]
public class PuzzleFactory
{
    [MemberName("f")]
    private static ScreenResource f = null;

    [MemberName("g")]
    private object[] g;
    [MemberName("h")]
    private int[] h;

    [MemberName("a")]
    public int a2;
    [MemberName("b")]
    public ImageResource ImageResource = null;

    [MemberName("i")]
    private static int[] i = new int[] { 2, 4, 16, 32 };

    [MemberName("c")]
    public int c;
    [MemberName("d")]
    public int d = 0;
    [MemberName("j")]
    private JavaString j = "null";
    [MemberName("e")]
    public int e;

    [ConstructorName("a")]
    public PuzzleFactory()
    {
    }

    [FunctionName("a")]
    public void Reset()
    {
        if (g != null)
        {
            ImageResource.Destroy();
            f.RemoveChild(ImageResource);

            for (int var1 = 0; var1 < e; ++var1)
            {
                if (g[var1] != null)
                {
                    ((PuzzleResource)g[var1]).Reset();
                    g[var1] = null;
                }
            }

            e = 0;
            g = null;
            d = 0;
        }

        if (ImageResource != null)
        {
            ImageResource.Create((Image)null);
            ImageResource = null;
        }

        h = null;
    }

    [FunctionName("a")]
    public void a1(ScreenResource var1, JavaString var2, int var3, Image var4)
    {
        if (d != 0)
        {
            Dialog var5;
            (var5 = new Dialog(2, "oObjectItem initial")).SetText("解放されていません。\nnow obj = " + d + "+\nnew obj = " + var3 + "\n" + j);
            var5.Show();
            Reset();
        }

        f = var1;
        j = var2;
        e = 0;
        g = new object[255];
        a2 = 0;
        d = var3;
        b1(var4);
    }

    [FunctionName("b")]
    public void b1()
    {
        a2 = 0;
        g1();

        for (int var1 = 0; var1 < e; ++var1)
        {
            PuzzleResource var2;
            if ((var2 = (PuzzleResource)g[var1]) != null)
            {
                var2.c();
            }
        }
    }

    [FunctionName("c")]
    public bool c1()
    {
        for (int var1 = 0; var1 < e; ++var1)
        {
            PuzzleResource var2;
            int var3;
            if ((var2 = (PuzzleResource)g[var1]) != null && (var3 = var2.a1(a2)) != 0)
            {
                switch (d)
                {
                    case 2:
                        if (var3 == 2)
                        {
                            return true;
                        }

                        if (var3 == 1)
                        {
                            do
                            {
                                ++a2;
                            } while (c1(a2));

                            if (a2 == e)
                            {
                                a2 = 0;
                            }
                        }
                        break;
                    case 3:
                    case 4:
                        break;
                }
            }
        }

        return false;
    }

    [FunctionName("c")]
    private bool c1(int var1)
    {
        if (h != null)
        {
            for (int var2 = 0; var2 < h.Length; ++var2)
            {
                if (h[var2] == var1)
                {
                    return true;
                }
            }
        }

        return false;
    }

    [FunctionName("a")]
    public void a1(int[] var1)
    {
        h = var1;
    }

    [FunctionName("a")]
    public PuzzleResource a1(int var1)
    {
        return (PuzzleResource)g[var1];
    }

    [FunctionName("a")]
    public PuzzleResource a1(JavaString var1)
    {
        PuzzleResource var2 = null;

        for (int var3 = 0; var3 < e; ++var3)
        {
            PuzzleResource var4;
            if ((var4 = (PuzzleResource)g[var3]).u.Equals(var1))
            {
                var2 = var4;
            }
        }

        return var2;
    }

    [FunctionName("a")]
    public void a1(Image var1)
    {
        for (int var2 = 0; var2 < e; ++var2)
        {
            ((PuzzleResource)g[var2]).a1(var1);
        }
    }

    [FunctionName("d")]
    public void d1()
    {
        for (int var1 = 0; var1 < e; ++var1)
        {
            ((PuzzleResource)g[var1]).l.SetIsVisible(false);
        }
    }

    [FunctionName("a")]
    private void a1(ResourceBase var1)
    {
        g[e] = var1;
        ++e;
    }

    [FunctionName("a")]
    public void a1(ScreenResource var1, int var2, int var3)
    {
        ResourceBase var4 = null;

        for (int var5 = e - 1; var5 >= 0; --var5)
        {
            var4 = (ResourceBase)g[var5];
            ImageResource.AddChild(var4);
        }

        var1.AddChild(ImageResource, var2, var3);
    }

    [FunctionName("e")]
    public void e1()
    {
        ImageResource.AddChild((ResourceBase)g[a2]);
    }

    [FunctionName("f")]
    public void f1()
    {
        ImageResource.SetIsVisible(true);
        f.AddChild(ImageResource);
    }

    [FunctionName("g")]
    public void g1()
    {
        ImageResource.SetIsVisible(false);
    }

    [FunctionName("b")]
    private void b1(Image var1)
    {
        ImageResource = ImageResource.Create(var1);
    }

    [FunctionName("a")]
    public void a1(Image var1, int var2, int var3, int imgPosX, int imgPosY)
    {
        if (d != 2)
        {
            Dialog var7;
            (var7 = new Dialog(2, "oObjectItem addAnime")).SetText("ボタン以外がセットされました\n" + j);
            var7.Show();
        }
        else
        {
            PuzzleResource var6;
            (var6 = PuzzleResource.Create(e, var1, var2, var3, imgPosX, imgPosY)).SetIsVisible(true);
            if ((var3 == 0 || var3 == 1 || var3 == 2) && f != null)
            {
                PuzzleResource.a1(f);
            }

            a1((ResourceBase)var6);
        }
    }

    [FunctionName("a")]
    public void a1(Image[] var1, int var2, int var3, int imgPosX)
    {
        for (int var5 = 0; var5 < var1.Length; ++var5)
        {
            int var6;
            PuzzleResource var7 = PuzzleResource.Create(var6 = e, var1[var5], var2, var3);
            if (imgPosX == 0)
            {
                var7.t = var6;
            }
            else
            {
                var7.s = var6;
            }

            var7.SetIsVisible(true);
            a1((ResourceBase)var7);
        }

    }

    [FunctionName("a")]
    public void a1(ResourceBase[] var1, int var2, int var3, int imgPosX, int imgPosY)
    {
        PuzzleResource var6 = PuzzleResource.Create(var1, e, d, var2, var3, imgPosX, imgPosY);
        a1((ResourceBase)var6);
    }

    [FunctionName("a")]
    public void a1(Image var1, Image var2, Image var3, int imgPosX, int imgPosY, int flipMode, int var7, int var8, int var9, int var10, JavaString var11)
    {
        try
        {
            if (d == 3)
            {
                PuzzleResource var13;
                (var13 = PuzzleResource.Create(e, var1, var2, var3, imgPosX, imgPosY, flipMode, var7, var8, var9, var10, var11)).SetIsVisible(true);
                a1((ResourceBase)var13);
            }
            else
            {
                Dialog var12;
                (var12 = new Dialog(2, "oObjectItem addButton")).SetText("ボタン以外がセットされました\n" + j);
                var12.Show();
            }

        }
        catch (Exception var14)
        {
        }
    }

    [FunctionName("a")]
    public void a1(ImageResource var1, ImageResource var2, ImageResource var3, int imgPosX, int imgPosY, int flipMode, int var7, int var8, int var9, int var10, JavaString var11)
    {
        if (d == 3)
        {
            PuzzleResource var13;
            (var13 = PuzzleResource.Create(e, var1, var2, var3, flipMode, var7, var8, var9, var10, var11)).SetIsVisible(true);
            a1((ResourceBase)var13);
        }
        else
        {
            Dialog var12;
            (var12 = new Dialog(2, "oObjectItem addButton")).SetText("ボタン以外がセットされました\n" + j);
            var12.Show();
        }
    }

    [FunctionName("h")]
    public JavaString h1()
    {
        JavaString var1 = "";
        if (d == 3)
        {
            for (int var2 = 0; var2 < e; ++var2)
            {
                PuzzleResource var3;
                if ((var3 = (PuzzleResource)g[var2]).y == 1 || var3.y == 2)
                {
                    var3.y = 2;
                    var1 = var3.u;
                    if (c == 1)
                    {
                        var3.w = 1;
                        var3.x = 1;
                    }
                }
            }
        }

        return var1;
    }

    [FunctionName("b")]
    public void b1(JavaString var1)
    {
        if (d == 3)
        {
            for (int var2 = 0; var2 < e; ++var2)
            {
                PuzzleResource var3;
                if ((var3 = (PuzzleResource)g[var2]).u.Equals(var1))
                {
                    var3.c();
                }
            }

            c1();
        }
    }

    [FunctionName("a")]
    public bool a1(GameContext var1)
    {
        bool var2 = true;
        int[] var3 = new int[e];
        int[] var4 = new int[e];

        int var5;
        for (var5 = 0; var5 < e; ++var5)
        {
            PuzzleResource var6 = (PuzzleResource)g[var5];
            var3[var5] = var6.s;
            var4[var5] = var6.t;
        }

        var5 = -1;
        int var9 = -1;

        int var7;
        PuzzleResource var8;
        for (var7 = 0; var7 < e; ++var7)
        {
            if ((var8 = (PuzzleResource)g[var7]).y == 1)
            {
                var5 = var8.s;
                var9 = var8.t;
                break;
            }
        }

        if (var5 == -1 && var9 == -1)
        {
            return false;
        }
        else
        {
            if ((var7 = var1.MoveCursor(var5, var9, var3, var4, true)) != -1 && ((PuzzleResource)g[var7]).IsVisible())
            {
                a2 = var7;
                var8 = (PuzzleResource)g[var7];
                ImageResource.AddChild(var8);
            }
            else
            {
                if (d == 4)
                {
                    var8 = (PuzzleResource)g[a2];
                    ImageResource.AddChild(var8);
                }

                var2 = false;
            }

            return var2;
        }
    }

    [FunctionName("b")]
    public bool b1(GameContext var1)
    {
        bool var2 = true;
        int[] var3 = new int[e];
        int[] var4 = new int[e];

        int var5;
        for (var5 = 0; var5 < e; ++var5)
        {
            PuzzleResource var6 = (PuzzleResource)g[var5];
            var3[var5] = var6.s;
            var4[var5] = var6.t;
        }

        var5 = -1;
        int var9 = -1;

        int var7;
        PuzzleResource var8;
        for (var7 = 0; var7 < e; ++var7)
        {
            if ((var8 = (PuzzleResource)g[var7]).y == 1)
            {
                var5 = var8.s;
                var9 = var8.t;
                break;
            }
        }

        if (var5 == -1 && var9 == -1)
        {
            return false;
        }
        else
        {
            if ((var7 = var1.MoveCursor(var5, var9, var3, var4, d == 4)) != -1 && ((PuzzleResource)g[var7]).IsVisible())
            {
                a2 = var7;
                var8 = (PuzzleResource)g[var7];
                ImageResource.AddChild(var8);
            }
            else
            {
                if (d == 4)
                {
                    var8 = (PuzzleResource)g[a2];
                    ImageResource.AddChild(var8);
                }

                var2 = false;
            }

            return var2;
        }
    }

    [FunctionName("b")]
    public JavaString b1(int var1)
    {
        JavaString var2 = "";

        for (int var3 = 0; var3 < e; ++var3)
        {
            PuzzleResource var4;
            if ((var4 = (PuzzleResource)g[var3]).IsVisible())
            {
                int var5 = var4.s + var4.t * 2;
                if ((var1 & i[var5]) != 0)
                {
                    var2 = var4.u;
                    a2 = var3;
                }
            }
        }

        return var2;
    }

    [FunctionName("toString")]
    public JavaString toString()
    {
        return "oObjectItem";
    }
}
