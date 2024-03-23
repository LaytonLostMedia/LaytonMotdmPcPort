using com.nttdocomo.ui;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using DocomoLayton.game;
using DocomoLayton.game.Managers;
using DocomoLayton.game.Resources;

namespace DocomoLayton.scene;

[ClassName("scene", "q")]
public class SelectionControlScene : ControlScene
{
    [MemberName("a")]
    private ImageResource a = null;
    [MemberName("v")]
    private ImageResource[] v = null;
    [MemberName("w")]
    private ImageResource w = null;
    [MemberName("x")]
    private ScreenResource x = null;
    [MemberName("y")]
    private bool y;
    [MemberName("z")]
    private int z;
    [MemberName("A")]
    private int A;
    [MemberName("B")]
    private int[] B;
    [MemberName("C")]
    private int C;
    [MemberName("D")]
    private Image D;
    [MemberName("E")]
    private Image[] E;
    [MemberName("F")]
    private int[] F;
    [MemberName("G")]
    private int[] G;
    [MemberName("H")]
    private int[] H;
    [MemberName("I")]
    private int[] I;
    [MemberName("J")]
    private int[] J;
    [MemberName("K")]
    private int[] K;
    [MemberName("L")]
    private int[] L;
    [MemberName("M")]
    private int[] M;
    [MemberName("N")]
    private int[] N;
    [MemberName("O")]
    private int[] O;
    [MemberName("P")]
    private JavaString[] P;

    [FunctionName("a")]
    public static SelectionControlScene Create()
    {
        return new SelectionControlScene();
    }

    [ConstructorName("q")]
    private SelectionControlScene()
    {
    }

    [FunctionName("a")]
    public override int a1(GameContext var1, object[] var2)
    {
        SelectionControlScene var3 = (SelectionControlScene)var2[0];
        D = var3.D;
        E = var3.E;
        F = var3.F;
        G = var3.G;
        H = var3.H;
        I = var3.I;
        J = var3.J;
        K = var3.K;
        L = var3.L;
        M = var3.M;
        N = var3.N;
        O = var3.O;
        P = var3.P;
        return 1;
    }

    [FunctionName("b")]
    public override void b1()
    {
        w.SetIsVisible(true);
        a.AddChild((ResourceBase)w);
    }

    [FunctionName("d")]
    public override void d1(GameContext var1)
    {
        JavaString var2;
        if (!(var2 = e1(var1)).Equals("answer"))
        {
            if (var2.Equals("pre_return"))
            {
                w.SetIsVisible(false);
            }
            else if (var2.Equals("return"))
            {
                w.SetIsVisible(false);
            }
            else if (var2.Equals("reset"))
            {
                c1();
                e1();
                b1();
            }
            else
            {
                int var7;
                if (var1.IsKeyPressed(Display.KEY_MAIN))
                {
                    if (C == -1)
                    {
                        if (B[z] != -1)
                        {
                            C = B[z];
                            v[C]._posY = I[z] + -10;
                            a.a1(v[C], 1);
                            w._posY = L[z];
                            B[z] = -1;
                            AudioManager.b1(1, n[1], 100);
                            A = 0;
                        }
                    }
                    else
                    {
                        if (B[z] != -1)
                        {
                            var7 = B[z];
                            B[z] = C;
                            v[B[z]].SetPosition(H[z], I[z]);
                            C = var7;
                            v[C]._posY = I[z] + -10;
                            a.a1(v[C], 1);
                        }
                        else
                        {
                            B[z] = C;
                            v[B[z]].SetPosition(H[z], I[z]);
                            C = -1;
                        }

                        AudioManager.b1(1, n[1], 100);
                    }
                }
                else if ((var7 = var1.MoveCursor(z, N, M, false)) != -1)
                {
                    z = var7;
                    w.SetPosition(K[z], L[z]);
                    w.SetFlipMode(J[z]);
                    if (C != -1)
                    {
                        v[C].SetPosition(H[z], I[z] + -10);
                    }

                    AudioManager.b1(1, n[8], 100);
                    A = 0;
                }

                if (C == -1)
                {
                    GameContext.a1(w, K[z], L[z], A);
                    ++A;
                }

            }
        }
        else
        {
            if (C != -1)
            {
                if (B[z] != -1)
                {
                    return;
                }

                B[z] = C;
                v[B[z]].SetPosition(H[z], I[z]);
                C = -1;
            }

            JavaString[] var3 = new JavaString[B.Length];

            bool var5;
            int var6;
            for (int var4 = 0; var4 < B.Length; ++var4)
            {
                var5 = false;

                for (var6 = 0; var6 < P.Length; ++var6)
                {
                    if (a1(P[var6], var4))
                    {
                        var5 = true;
                        break;
                    }
                }

                JavaString var10 = var5 ? "-" : (B[var4] == -1 ? "x" : G[B[var4]].ToString());
                var3[O[var4]] = var10;
            }

            JavaString var8 = "";

            for (int var9 = 0; var9 < var3.Length; ++var9)
            {
                if (var9 != 0)
                {
                    var8 = var8 + ",";
                }

                var8 = var8 + var3[var9];
            }

            var5 = false;

            for (var6 = 0; var6 < P.Length; ++var6)
            {
                if (var8.Equals(P[var6]))
                {
                    var5 = true;
                    break;
                }
            }

            if (var5)
            {
                a1(var1, true);
            }
            else
            {
                a1(var1, false);
            }
        }
    }

    [FunctionName("a")]
    public override void a1(ScreenResource var1)
    {
        x = var1;
        if (a == null)
        {
            a = ImageResource.Create(D);
        }

        if (v == null)
        {
            v = new ImageResource[E.Length];

            for (int var2 = 0; var2 < v.Length; ++var2)
            {
                v[var2] = ImageResource.Create(E[var2]);
            }
        }

        if (w == null)
        {
            w = ImageResource.Create(f);
            w.SetIsVisible(false);
        }

        x.SetIsVisible(true);
        y = false;
        B = new int[H.Length];
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

            for (var1 = 0; var1 < v.Length; ++var1)
            {
                a.RemoveChild(v[var1]);
            }

            a.RemoveChild(w);
        }

        if (g1() != 9 && g1() != 4 && g1() != 11)
        {
            for (var1 = 0; var1 < B.Length; ++var1)
            {
                B[var1] = -1;

                for (int var2 = 0; var2 < v.Length; ++var2)
                {
                    if (F[var2] == var1)
                    {
                        B[var1] = var2;
                        break;
                    }
                }
            }

            for (var1 = 0; var1 < v.Length; ++var1)
            {
                v[var1].SetPosition(H[F[var1]], I[F[var1]]);
            }

            C = -1;
            A = 0;

            for (var1 = 0; var1 < H.Length; ++var1)
            {
                if (M[var1] == 0 && N[var1] == 0)
                {
                    z = var1;
                    w.SetPosition(K[z], L[z]);
                    w.SetFlipMode(J[z]);
                    break;
                }
            }
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

            for (int var1 = 0; var1 < v.Length; ++var1)
            {
                a.AddChild((ResourceBase)v[var1]);
            }

            if (C != -1)
            {
                a.AddChild((ResourceBase)v[C]);
            }
        }

        y = false;
    }

    [FunctionName("f")]
    public override void f1()
    {
        if (a != null)
        {
            a.d();
            a = null;
        }

        int var1;
        if (v != null)
        {
            for (var1 = 0; var1 < v.Length; ++var1)
            {
                v[var1].d();
            }

            v = null;
        }

        if (w != null)
        {
            w.d();
            w = null;
        }

        x = null;
        B = null;
        if (D != null)
        {
            D.Dispose();
            D = null;
        }

        if (E != null)
        {
            for (var1 = 0; var1 < E.Length; ++var1)
            {
                E[var1].Dispose();
            }

            E = null;
        }

        F = null;
        G = null;
        H = null;
        I = null;
        J = null;
        K = null;
        L = null;
        M = null;
        N = null;
        O = null;
        P = null;
    }

    [FunctionName("a")]
    private static bool a1(JavaString var0, int var1)
    {
        int var2 = 0;

        for (int var3 = 0; var3 < var0.Length; ++var3)
        {
            if (var0[var3] == ',')
            {
                if (var2 == var1)
                {
                    if (var0[var3 - 1] == '-')
                    {
                        return true;
                    }

                    return false;
                }

                ++var2;
            }
            else if (var3 == var0.Length - 1 && var1 == var2 + 1)
            {
                if (var0[var3] == '-')
                {
                    return true;
                }

                return false;
            }
        }

        return false;
    }

    [FunctionName("a")]
    public static object Read(nazo.PuzzleManager var0, BinaryReader var1)
    {
        SelectionControlScene var2 = Create();

        try
        {
            var0.ReadString(var1);
            int var4 = var0.ReadInt32(var1.BaseStream);
            var2.D = var0.GetLoadedImage(var4);
            int var6 = var0.ReadInt32(var1.BaseStream);
            int var7 = var0.ReadInt32(var1.BaseStream);
            int var8 = var0.ReadInt32(var1.BaseStream);
            var2.E = new Image[var6];
            var2.F = new int[var6];
            var2.G = new int[var6];

            int var9;
            for (var9 = 0; var9 < var6; ++var9)
            {
                var2.E[var9] = var0.GetLoadedImage(var0.ReadInt32(var1.BaseStream));
                var2.F[var9] = var0.ReadInt32(var1.BaseStream);
                var2.G[var9] = var0.ReadInt32(var1.BaseStream);
            }

            var2.H = new int[var7];
            var2.I = new int[var7];
            var2.J = new int[var7];
            var2.K = new int[var7];
            var2.L = new int[var7];
            var2.M = new int[var7];
            var2.N = new int[var7];
            var2.O = new int[var7];

            for (var9 = 0; var9 < var7; ++var9)
            {
                var2.H[var9] = var0.ReadInt32(var1.BaseStream);
                var2.I[var9] = var0.ReadInt32(var1.BaseStream);
                var2.J[var9] = var0.ReadInt32(var1.BaseStream);
                var2.K[var9] = var0.ReadInt32(var1.BaseStream);
                var2.L[var9] = var0.ReadInt32(var1.BaseStream);
                var2.M[var9] = var0.ReadInt32(var1.BaseStream);
                var2.N[var9] = var0.ReadInt32(var1.BaseStream);
                var2.O[var9] = var0.ReadInt32(var1.BaseStream);
            }

            var2.P = new JavaString[var8];

            for (var9 = 0; var9 < var8; ++var9)
            {
                var2.P[var9] = var0.ReadString(var1);
            }
        }
        catch (Exception var10)
        {
            var2 = null;
        }

        return var2;
    }
}
