using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm1.c;
using LaytonMotdm1.c.Resources;

namespace LaytonMotdm1.nazo;

[ClassName("nazo", "b")]
public class PuzzleResource : ResourceBase
{
    [MemberName("a")]
    public int a;
    [MemberName("k")]
    public ResourceBase[] k;
    [MemberName("l")]
    public ResourceBase l;
    [MemberName("m")]
    public int m;
    [MemberName("n")]
    public int n;
    [MemberName("o")]
    public int o;
    [MemberName("p")]
    public int p;
    [MemberName("q")]
    public int q;
    [MemberName("r")]
    public int r;
    [MemberName("s")]
    public int s;
    [MemberName("t")]
    public int t;
    [MemberName("u")]
    public JavaString u;
    [MemberName("v")]
    public int v;
    [MemberName("w")]
    public int w;
    [MemberName("x")]
    public int x;
    [MemberName("y")]
    public int y;
    [MemberName("z")]
    public int z;
    [MemberName("A")]
    public int A;
    [MemberName("B")]
    private int _state;

    [MemberName("C")]
    private static ScreenResource _screenResource = null;

    [FunctionName("a")]
    public static void a1(ScreenResource var0)
    {
        _screenResource = var0;
    }

    [FunctionName("b")]
    private void b1(int var1)
    {
        v = var1;
        y = var1;
    }

    [FunctionName("c")]
    public void c()
    {
        w = 0;
        x = 0;

        for (int var1 = 0; var1 < k.Length; ++var1)
        {
            y = v;
            k[var1].SetIsVisible(false);
        }

        switch (_state)
        {
            case 2:
                return;
            case 3:
                k[0].SetIsVisible(true);
                break;
            default:
                break;
        }
    }

    [FunctionName("a")]
    public int a1(int var1)
    {
        int var2;
        switch (_state)
        {
            case 2:
                if (a != var1)
                {
                    for (var2 = 0; var2 <= k.Length - 1; ++var2)
                    {
                        k[var2].SetIsVisible(false);
                    }

                    y = z;
                }
                else if (y == -1)
                {
                    for (var2 = 0; var2 <= k.Length - 1; ++var2)
                    {
                        k[var2].SetIsVisible(true);
                    }

                    y = -2;
                    if (A == 1 || A == 2)
                    {
                        _screenResource.ExecuteTransition(1);
                    }
                }
                else if (y == -2)
                {
                    if (_screenResource._transitionState == 2 || _screenResource._transitionState == 0)
                    {
                        return 2;
                    }
                }
                else
                {
                    if (y == z)
                    {
                        for (var2 = 0; var2 <= k.Length - 1; ++var2)
                        {
                            k[var2].SetIsVisible(true);
                        }

                        if (A == 1 || A == 2)
                        {
                            _screenResource.ExecuteTransition(1);
                        }
                    }

                    if (y > 0)
                    {
                        if (y == 1 && (A == 0 || A == 2))
                        {
                            _screenResource.ExecuteTransition(0);
                        }

                        --y;
                    }
                    else
                    {
                        if (y != 0)
                        {
                            break;
                        }

                        if (A == -1)
                        {
                            y = z;

                            for (var2 = 0; var2 <= k.Length - 1; ++var2)
                            {
                                k[var2].SetIsVisible(false);
                            }

                            return 1;
                        }

                        if (_screenResource._transitionState != 2 && _screenResource._transitionState != 0)
                        {
                            break;
                        }

                        y = z;
                        c();
                        return 1;
                    }
                }
                break;
            case 3:
                if (y == 2)
                {
                    k[1].SetIsVisible(false);
                    k[y].SetIsVisible(true);
                }
                else
                {
                    if (a == var1)
                    {
                        k[y].SetIsVisible(false);
                        y = 1;
                        k[y].SetIsVisible(true);
                        l.SetIsVisible(true);
                        GameContext.a1((ImageResource)l, m, n, o++);
                        return 1;
                    }

                    if (y == 1)
                    {
                        k[y].SetIsVisible(false);
                        l.SetIsVisible(false);
                        y = 0;
                        k[y].SetIsVisible(true);
                    }
                }
                break;
            case 4:
                if (a == var1)
                {
                    for (var2 = 0; var2 <= k.Length - 1; ++var2)
                    {
                        k[var2].SetIsVisible(true);
                    }

                    y = 1;
                }
                else
                {
                    for (var2 = 0; var2 <= k.Length - 1; ++var2)
                    {
                        k[var2].SetIsVisible(false);
                    }

                    y = 0;
                }
                break;
        }

        return 0;
    }

    [ConstructorName("b")]
    private PuzzleResource()
    {
    }

    [FunctionName("a")]
    public static PuzzleResource Create(int var0, Image img1, int var2, int var3)
    {
        PuzzleResource var4;
        (var4 = new PuzzleResource()).k = new ImageResource[1];
        var4.k[0] = ImageResource.Create(img1);
        var4.AddChild(var4.k[0]);
        var4.a = var0;
        var4._state = 4;
        var4.SetPosition(var2, var3);
        return var4;
    }

    [FunctionName("a")]
    public static PuzzleResource Create(ResourceBase[] var0, int var1, int var2, int var3, int var4, int imgPosX, int imgPosY)
    {
        PuzzleResource var7;
        (var7 = new PuzzleResource()).k = var0;

        for (int var8 = 0; var8 <= var7.k.Length - 1; ++var8)
        {
            ResourceBase var10000 = var7.k[var8];
            var10000.posX += imgPosX;
            var10000 = var7.k[var8];
            var10000.posY += imgPosY;
            var7.AddChild(var7.k[var8]);
        }

        var7.a = var1;
        var7._state = var2;
        switch (var7._state)
        {
            case 2:
                var7.b1(var3);
                var7.A = var4;
                var7.z = var7.y;
                break;
            case 3:
            default:
                var7.SetPosition(imgPosX, imgPosY);
                var7.c();
                return var7;
        }

        return var7;
    }

    [FunctionName("a")]
    public static PuzzleResource Create(int var0, Image img1, int var2, int var3, int imgPosX, int imgPosY)
    {
        PuzzleResource var6;
        (var6 = new PuzzleResource()).b1(var2);
        var6.z = var6.y;
        var6.k = new ImageResource[1];
        var6.k[0] = ImageResource.Create(img1);
        ((ImageResource)var6.k[0]).SetPosition(imgPosX, imgPosY);
        var6.AddChild(var6.k[0]);
        var6.k[0].SetIsVisible(false);
        var6.a = var0;
        var6._state = 2;
        var6.A = var3;
        var6.c();
        return var6;
    }

    [FunctionName("a")]
    public static PuzzleResource Create(int var0, Image img1, Image img2, Image img3, int imgPosX, int imgPosY, int flipMode, int resPosX, int var8, int var9, int var10, JavaString var11)
    {
        PuzzleResource var12;
        (var12 = new PuzzleResource()).b1(0);
        var12.k = new ImageResource[4];
        var12.k[0] = ImageResource.Create(img1);
        ImageResource var13 = (ImageResource)var12.k[0];
        var12.AddChild(var13, imgPosX, imgPosY);
        var13.SetIsVisible(true);
        var12.k[1] = ImageResource.Create(img2);
        var13 = (ImageResource)var12.k[1];
        var12.AddChild(var13, imgPosX, imgPosY);
        var13.SetIsVisible(false);
        var12.k[2] = ImageResource.Create(img3);
        var13 = (ImageResource)var12.k[2];
        var12.AddChild(var13, imgPosX, imgPosY);
        var13.SetIsVisible(false);
        var12.k[3] = ImageResource.Create((Image)null);
        var13 = (ImageResource)var12.k[3];
        var12.AddChild(var13, resPosX, var8);
        var13.SetFlipMode(flipMode);
        var13.SetIsVisible(true);
        var12.m = resPosX;
        var12.n = var8;
        var12.l = var12.k[3];
        var12.a = var0;
        var12._state = 3;
        var12.p = flipMode;
        var12.q = resPosX;
        var12.r = var8;
        var12.s = var9;
        var12.t = var10;
        var12.u = var11;
        var12.c();
        return var12;
    }

    [FunctionName("a")]
    public static PuzzleResource Create(int var0, ImageResource var1, ImageResource var2, ImageResource var3, int imgPosX, int imgPosY, int flipMode, int resPosX, int var8, JavaString var9)
    {
        PuzzleResource var10;
        (var10 = new PuzzleResource()).b1(0);
        var10.k = new ImageResource[4];
        var10.k[0] = var1;
        ImageResource var11 = (ImageResource)var10.k[0];
        var10.AddChild(var11);
        var11.SetIsVisible(true);
        var10.k[1] = var2;
        var11 = (ImageResource)var10.k[1];
        var10.AddChild(var11);
        var11.SetIsVisible(false);
        var10.k[2] = var3;
        var11 = (ImageResource)var10.k[2];
        var10.AddChild(var11);
        var11.SetIsVisible(false);
        var10.k[3] = ImageResource.Create((Image)null);
        var11 = (ImageResource)var10.k[3];
        var10.AddChild(var11, imgPosY, flipMode);
        var11.SetFlipMode(imgPosX);
        var11.SetIsVisible(true);
        var10.m = imgPosY;
        var10.n = flipMode;
        var10.l = var10.k[3];
        var10.a = var0;
        var10._state = 3;
        var10.p = imgPosX;
        var10.q = imgPosY;
        var10.r = flipMode;
        var10.s = resPosX;
        var10.t = var8;
        var10.u = var9;
        var10.c();
        return var10;
    }

    [FunctionName("d")]
    public void Reset()
    {
        if (k != null)
        {
            for (int var1 = 0; var1 < k.Length; ++var1)
            {
                if (k[var1] != null)
                {
                    try
                    {
                        ((ImageResource)k[var1]).Destroy();
                    }
                    catch (Exception var3)
                    {
                    }

                    k[var1] = null;
                }
            }

            k = null;
        }

        if (l != null)
        {
            ImageResource var4;
            (var4 = (ImageResource)l).Destroy();
            var4.Dispose();
            l = null;
        }

        y = 0;
        a = 0;
        u = null;
    }

    [FunctionName("a")]
    public void a1(Image var1)
    {
        if ((float)p != -1.0F || q != -1 || r != -1)
        {
            ((ImageResource)l).SetImage(var1);
        }
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        if (_state != 4)
        {
            SetPosition(w, this.x);
        }
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return k[0].GetWidth();
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return k[0].GetHeight();
    }

    [FunctionName("a")]
    protected override void Update(Graphics var1)
    {
    }
}
