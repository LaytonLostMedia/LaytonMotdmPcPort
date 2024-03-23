using com.nttdocomo.ui;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using DocomoLayton.game;
using DocomoLayton.game.Managers;
using DocomoLayton.game.Resources;

namespace DocomoLayton.scene;

[ClassName("scene", "l")]
public class SwitchControlScene : ControlScene
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
    private int[] z;
    [MemberName("A")]
    private int A;
    [MemberName("B")]
    private int B;
    [MemberName("C")]
    private Image C;
    [MemberName("D")]
    private Image[][] D;
    [MemberName("E")]
    private int[] E;
    [MemberName("F")]
    private int[] F;
    [MemberName("G")]
    private int[] _flipModes;
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

    [FunctionName("a")]
    public static SwitchControlScene Create()
    {
        return new SwitchControlScene();
    }

    [ConstructorName("l")]
    private SwitchControlScene()
    {
    }

    [FunctionName("a")]
    public override int a1(GameContext var1, object[] var2)
    {
        SwitchControlScene var3 = (SwitchControlScene)var2[0];
        C = var3.C;
        D = var3.D;
        E = var3.E;
        F = var3.F;
        _flipModes = var3._flipModes;
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
        if ((var2 = e1(var1)).Equals("answer"))
        {
            var3 = 0;

            for (int var4 = 0; var4 < E.Length; ++var4)
            {
                if (L[var4] == z[var4])
                {
                    ++var3;
                }
            }

            if (var3 == E.Length)
            {
                a1(var1, true);
            }
            else
            {
                a1(var1, false);
            }
        }
        else
        {
            if (var2.Equals("reset"))
            {
                c1();
                e1();
                b1();
            }
            else if (var2.Equals("pre_return"))
            {
                w.SetIsVisible(false);
            }
            else if (var2.Equals("return"))
            {
                w.SetIsVisible(false);
            }
            else if (var1.IsKeyPressed(Display.KEY_MAIN))
            {
                int var10002 = z[A]++;
                if (z[A] >= D[A].Length)
                {
                    z[A] = 0;
                }

                v[A].SetImage(D[A][z[A]]);
                AudioManager.b1(1, n[1], 100);
            }
            else if ((var3 = var1.MoveCursor(A, K, J, false)) != -1)
            {
                A = var3;
                w.SetPosition(H[A], I[A]);
                w.SetFlipMode(_flipModes[A]);
                AudioManager.b1(1, n[8], 100);
                B = 0;
            }

            GameContext.a1(w, H[A], I[A], B);
            ++B;
        }
    }

    [FunctionName("a")]
    public override void a1(ScreenResource var1)
    {
        x = var1;
        if (a == null)
        {
            a = ImageResource.Create(C);
        }

        if (v == null)
        {
            v = new ImageResource[E.Length];

            for (int var2 = 0; var2 < v.Length; ++var2)
            {
                v[var2] = ImageResource.Create(D[var2][0]);
                v[var2].SetPosition(E[var2], F[var2]);
            }
        }

        if (w == null)
        {
            w = ImageResource.Create(f);
            w.SetIsVisible(false);
        }

        x.SetIsVisible(true);
        y = false;
        z = new int[E.Length];
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

        for (var1 = 0; var1 < z.Length; ++var1)
        {
            z[var1] = 0;
            v[var1].SetImage(D[var1][0]);
        }

        for (var1 = 0; var1 < E.Length; ++var1)
        {
            if (J[var1] == 0 && K[var1] == 0)
            {
                A = var1;
                w.SetPosition(H[A], I[A]);
                w.SetFlipMode(_flipModes[A]);
                break;
            }
        }

        B = 0;
        y = true;
    }

    [FunctionName("b")]
    public override void b1()
    {
        w.SetIsVisible(true);
        a.AddChild((ResourceBase)w);
    }

    [FunctionName("d")]
    public override void d1()
    {
        if (!y)
        {
            x.SetIsVisible(false);
        }
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
        z = null;
        if (C != null)
        {
            C.Dispose();
            C = null;
        }

        if (D != null)
        {
            for (var1 = 0; var1 < D.Length; ++var1)
            {
                for (int var2 = 0; var2 < D[var1].Length; ++var2)
                {
                    if (D[var1][var2] != null)
                    {
                        D[var1][var2].Dispose();
                    }
                }
            }

            D = (Image[][])null;
        }

        E = null;
        F = null;
        _flipModes = null;
        H = null;
        I = null;
        J = null;
        K = null;
        L = null;
    }

    [FunctionName("a")]
    public static object Read(nazo.PuzzleManager var0, BinaryReader var1)
    {
        SwitchControlScene var2 = Create();

        try
        {
            int var3 = var0.ReadInt32(var1.BaseStream);
            int var4 = var0.ReadInt32(var1.BaseStream);
            bool var5 = false;
            var2.C = var0.GetLoadedImage(var4);
            int var9 = 1;
            var2.D = new Image[var3 - 1][];
            var2.E = new int[var3 - 1];
            var2.F = new int[var3 - 1];
            var2._flipModes = new int[var3 - 1];
            var2.H = new int[var3 - 1];
            var2.I = new int[var3 - 1];
            var2.J = new int[var3 - 1];
            var2.K = new int[var3 - 1];

            for (var2.L = new int[var3 - 1]; var9 < var3; ++var9)
            {
                int var6 = var0.ReadInt32(var1.BaseStream);
                var2.D[var9 - 1] = new Image[var6];

                for (int var7 = 0; var7 < var6; ++var7)
                {
                    var2.D[var9 - 1][var7] = var0.GetLoadedImage(var0.ReadInt32(var1.BaseStream));
                }

                var2.E[var9 - 1] = var0.ReadInt32(var1.BaseStream);
                var2.F[var9 - 1] = var0.ReadInt32(var1.BaseStream);
                var2._flipModes[var9 - 1] = var0.ReadInt32(var1.BaseStream);
                var2.H[var9 - 1] = var0.ReadInt32(var1.BaseStream);
                var2.I[var9 - 1] = var0.ReadInt32(var1.BaseStream);
                var2.J[var9 - 1] = var0.ReadInt32(var1.BaseStream);
                var2.K[var9 - 1] = var0.ReadInt32(var1.BaseStream);
                var2.L[var9 - 1] = var0.ReadInt32(var1.BaseStream);
            }
        }
        catch (Exception var8)
        {
            var2 = null;
        }

        return var2;
    }
}
