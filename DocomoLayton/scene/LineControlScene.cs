using com.nttdocomo.ui;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using DocomoLayton.game;
using DocomoLayton.game.Managers;
using DocomoLayton.game.Resources;

namespace DocomoLayton.scene;

[ClassName("scene", "k")]
public class LineControlScene : ControlScene
{
    [MemberName("a")]
    private ImageResource a = null;
    [MemberName("v")]
    private ImageResource v = null;
    [MemberName("w")]
    private LineResource[] w = null;
    [MemberName("x")]
    private ScreenResource x = null;
    [MemberName("y")]
    private bool y;
    [MemberName("z")]
    private int z;
    [MemberName("A")]
    private int[] A = new int[] { -16, -11 };
    [MemberName("B")]
    private int B;
    [MemberName("C")]
    private int C;
    [MemberName("D")]
    private JavaString[] D;
    [MemberName("E")]
    private Image E;
    [MemberName("F")]
    private int[] F;
    [MemberName("G")]
    private int[] G;
    [MemberName("H")]
    private int[] H;
    [MemberName("I")]
    private int[] I;
    [MemberName("J")]
    private JavaString[] J;
    [MemberName("K")]
    private JavaString[] K;
    [MemberName("L")]
    private JavaString[] L;

    [FunctionName("a")]
    public static LineControlScene Create()
    {
        return new LineControlScene();
    }

    [ConstructorName("k")]
    private LineControlScene()
    {
    }

    [FunctionName("a")]
    public override int a1(GameContext var1, object[] var2)
    {
        LineControlScene var3 = (LineControlScene)var2[0];
        E = var3.E;
        F = var3.F;
        G = var3.G;
        H = var3.H;
        I = var3.I;
        J = var3.J;
        K = var3.K;
        L = var3.L;
        return 1;
    }

    [FunctionName("d")]
    public override void d1(GameContext var1)
    {
        JavaString var2;
        int var3;
        if (!(var2 = e1(var1)).Equals("answer"))
        {
            if (var2.Equals("pre_return"))
            {
                v.SetIsVisible(false);
            }
            else if (var2.Equals("return"))
            {
                v.SetIsVisible(false);
            }
            else if (var2.Equals("reset"))
            {
                c1();
                e1();
                b1();
            }
            else
            {
                if (var1.IsKeyPressed(Display.KEY_MAIN))
                {
                    switch (z)
                    {
                        case 0:
                            z = 1;
                            break;
                        case 1:
                            z = 0;
                            break;
                    }

                    v._posY = j();
                    AudioManager.b1(1, n[1], 100);
                    C = 0;
                }
                else
                {
                    if (((var3 = var1.f1()) & 131072) != 0)
                    {
                        b(I[B], H[B] - 1);
                    }

                    if ((var3 & 524288) != 0)
                    {
                        b(I[B], H[B] + 1);
                    }

                    if ((var3 & 262144) != 0)
                    {
                        b(I[B] + 1, H[B]);
                    }

                    if ((var3 & 65536) != 0)
                    {
                        b(I[B] - 1, H[B]);
                    }
                }

                if (z == 0)
                {
                    ++C;
                }

            }
        }
        else if (D.Length != J.Length)
        {
            a1(var1, false);
        }
        else
        {
            var3 = 0;

            for (int var4 = 0; var4 < J.Length; ++var4)
            {
                for (int var5 = 0; var5 < D.Length; ++var5)
                {
                    if (J[var4].Equals(D[var5]))
                    {
                        ++var3;
                    }
                }
            }

            if (var3 == J.Length)
            {
                a1(var1, true);
            }
            else
            {
                a1(var1, false);
            }
        }
    }

    [FunctionName("i")]
    private int i()
    {
        return F[B] - 9;
    }

    [FunctionName("j")]
    private int j()
    {
        return G[B] + A[z];
    }

    [FunctionName("b")]
    private void b(int var1, int var2)
    {
        for (int var3 = 0; var3 < F.Length; ++var3)
        {
            if (H[var3] == var2 && I[var3] == var1)
            {
                int var4;
                int var5;
                if (B < var3)
                {
                    var4 = B;
                    var5 = var3;
                }
                else
                {
                    var4 = var3;
                    var5 = B;
                }

                JavaString var6 = var4 + "," + var5;
                bool var7 = true;

                for (int var8 = 0; var8 < L.Length; ++var8)
                {
                    if (var6.Equals(L[var8]))
                    {
                        var7 = false;
                        break;
                    }
                }

                if (var7)
                {
                    if (z == 1)
                    {
                        bool var11 = true;

                        for (int var9 = 0; var9 < K.Length; ++var9)
                        {
                            if (var6.Equals(K[var9]))
                            {
                                var11 = false;
                                break;
                            }
                        }

                        if (var11)
                        {
                            bool var12 = true;

                            for (int var10 = 0; var10 < D.Length; ++var10)
                            {
                                if (D[var10].Equals(var6))
                                {
                                    a.RemoveChild(w[var10]);
                                    D = a1(D, var10);
                                    w = a1(w, var10);
                                    var12 = false;
                                    break;
                                }
                            }

                            if (var12)
                            {
                                D = a1(D, var6);
                                w = a1(w, LineResource.Create(F[var4], G[var4], F[var5], G[var5], 255, 0, 0));
                                a.AddChild(w[0]);
                                a.a1(w[0], -1);
                            }
                        }

                        AudioManager.b1(1, n[8], 100);
                    }
                    else
                    {
                        AudioManager.b1(1, n[8], 100);
                    }

                    B = var3;
                    v.SetPosition(i(), j());
                    C = 0;
                    return;
                }
                break;
            }
        }
    }

    [FunctionName("a")]
    private static JavaString[] a1(JavaString[] var0, JavaString var1)
    {
        if (var0.Length == 0)
        {
            return new JavaString[] { var1 };
        }
        else
        {
            JavaString[] var2 = new JavaString[var0.Length];
            JavaString[] var3 = new JavaString[var0.Length];
            Array.Copy(var0, 0, var2, 0, var0.Length);
            Array.Copy(var0, 0, var3, 0, var0.Length);
            (var2 = new JavaString[var3.Length + 1])[0] = var1;
            Array.Copy(var3, 0, var2, 1, var3.Length);
            return var2;
        }
    }

    [FunctionName("a")]
    private static LineResource[] a1(LineResource[] var0, LineResource var1)
    {
        if (var0.Length == 0)
        {
            return new LineResource[] { var1 };
        }
        else
        {
            LineResource[] var2 = new LineResource[var0.Length];
            LineResource[] var3 = new LineResource[var0.Length];
            Array.Copy(var0, 0, var2, 0, var0.Length);
            Array.Copy(var0, 0, var3, 0, var0.Length);
            (var2 = new LineResource[var3.Length + 1])[0] = var1;
            Array.Copy(var3, 0, var2, 1, var3.Length);
            return var2;
        }
    }

    [FunctionName("a")]
    private static JavaString[] a1(JavaString[] var0, int var1)
    {
        if (var0.Length == 1)
        {
            return new JavaString[0];
        }
        else
        {
            JavaString[] var2 = new JavaString[var0.Length];
            Array.Copy(var0, 0, var2, 0, var0.Length);
            JavaString[] var3 = new JavaString[var2.Length - 1];
            if (var1 == 0)
            {
                Array.Copy(var2, 1, var3, 0, var3.Length);
            }
            else if (var1 == var3.Length)
            {
                Array.Copy(var2, 0, var3, 0, var3.Length);
            }
            else
            {
                Array.Copy(var2, 0, var3, 0, var1);
                Array.Copy(var2, var1 + 1, var3, var1, var3.Length - var1);
            }

            return var3;
        }
    }

    [FunctionName("a")]
    private static LineResource[] a1(LineResource[] var0, int var1)
    {
        if (var0.Length == 1)
        {
            return new LineResource[0];
        }
        else
        {
            LineResource[] var2 = new LineResource[var0.Length];
            Array.Copy(var0, 0, var2, 0, var0.Length);
            LineResource[] var3 = new LineResource[var2.Length - 1];
            if (var1 == 0)
            {
                Array.Copy(var2, 1, var3, 0, var3.Length);
            }
            else if (var1 == var3.Length)
            {
                Array.Copy(var2, 0, var3, 0, var3.Length);
            }
            else
            {
                Array.Copy(var2, 0, var3, 0, var1);
                Array.Copy(var2, var1 + 1, var3, var1, var3.Length - var1);
            }

            return var3;
        }
    }

    [FunctionName("a")]
    public override void a1(ScreenResource var1)
    {
        x = var1;
        if (a == null)
        {
            a = ImageResource.Create(E);
        }

        if (v == null)
        {
            v = ImageResource.Create(f);
            v.SetIsVisible(false);
        }

        if (w == null)
        {
            w = new LineResource[0];
            D = new JavaString[0];
        }

        x.SetIsVisible(true);
        y = false;
    }

    [FunctionName("d")]
    public override void d1()
    {
        if (!y)
        {
            x.SetIsVisible(false);
        }
    }

    [FunctionName("c")]
    public override void c1()
    {
        int var1;
        if (x != null)
        {
            x.RemoveChild(a);
            a.RemoveChild(v);
            if (w != null)
            {
                for (var1 = 0; var1 < w.Length; ++var1)
                {
                    a.RemoveChild(w[var1]);
                }

                w = new LineResource[0];
            }
        }

        z = 0;
        C = 0;

        for (var1 = 0; var1 < F.Length; ++var1)
        {
            if (H[var1] == 0 && I[var1] == 0)
            {
                B = var1;
                v.SetPosition(i(), j());
                v.SetFlipMode(Graphics.FLIP_ROTATE_180);
                break;
            }
        }

        if (D != null)
        {
            D = new JavaString[0];
        }

        y = true;
    }

    [FunctionName("e")]
    public override void e1()
    {
        x.SetIsVisible(true);
        if (x != null)
        {
            x.AddChild(a, centerPosX, centerPosY);
            x.a1(a, -2);
        }

        y = false;
    }

    [FunctionName("b")]
    public override void b1()
    {
        v.SetIsVisible(true);
        a.AddChild((ResourceBase)v);
    }

    [FunctionName("f")]
    public override void f1()
    {
        if (a != null)
        {
            a.d();
            a = null;
        }

        if (v != null)
        {
            v.d();
            v = null;
        }

        w = null;
        x = null;
        D = null;
        if (E != null)
        {
            E.Dispose();
            E = null;
        }

        F = null;
        G = null;
        H = null;
        I = null;
        J = null;
    }

    [FunctionName("a")]
    public static object Read(nazo.PuzzleManager var0, BinaryReader var1)
    {
        LineControlScene var2 = Create();

        try
        {
            var0.ReadString(var1);
            int var4 = var0.ReadInt32(var1.BaseStream);
            var2.E = var0.GetLoadedImage(var4);
            int var6 = var0.ReadInt32(var1.BaseStream);
            int var7 = var0.ReadInt32(var1.BaseStream);
            int var8 = var0.ReadInt32(var1.BaseStream);
            int var9 = var0.ReadInt32(var1.BaseStream);
            var2.F = new int[var6];
            var2.G = new int[var6];
            var2.H = new int[var6];
            var2.I = new int[var6];

            int var10;
            for (var10 = 0; var10 < var6; ++var10)
            {
                var2.F[var10] = var0.ReadInt32(var1.BaseStream);
                var2.G[var10] = var0.ReadInt32(var1.BaseStream);
                var2.H[var10] = var0.ReadInt32(var1.BaseStream);
                var2.I[var10] = var0.ReadInt32(var1.BaseStream);
            }

            var2.J = new JavaString[var7];

            for (var10 = 0; var10 < var7; ++var10)
            {
                var2.J[var10] = var0.ReadString(var1);
            }

            var2.K = new JavaString[var8];

            for (var10 = 0; var10 < var8; ++var10)
            {
                var2.K[var10] = var0.ReadString(var1);
            }

            var2.L = new JavaString[var9];

            for (var10 = 0; var10 < var9; ++var10)
            {
                var2.L[var10] = var0.ReadString(var1);
            }
        }
        catch (Exception var11)
        {
            var2 = null;
        }

        return var2;
    }
}
