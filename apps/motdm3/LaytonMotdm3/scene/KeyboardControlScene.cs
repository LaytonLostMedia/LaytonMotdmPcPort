using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Resources;

namespace LaytonMotdm3.scene;

[ClassName("scene", "f")]
public class KeyboardControlScene : ControlScene
{
    [MemberName("a")]
    private int a;
    [MemberName("v")]
    private ResourceBase v;
    [MemberName("w")]
    private ScreenResource w;
    [MemberName("x")]
    private ImageResource x = null;
    [MemberName("y")]
    private int y = 0;
    [MemberName("z")]
    private Image z;
    [MemberName("A")]
    private JavaString[] A;
    [MemberName("B")]
    private int B;

    [FunctionName("a")]
    public static KeyboardControlScene Create()
    {
        return new KeyboardControlScene();
    }

    [ConstructorName("f")]
    private KeyboardControlScene()
    {
    }

    [FunctionName("b")]
    public override void b1()
    {
    }

    [FunctionName("a")]
    public override int a1(GameContext var1, object[] var2)
    {
        KeyboardControlScene var3 = (KeyboardControlScene)var2[0];
        z = var3.z;
        A = var3.A;
        B = var3.B;
        a = 0;
        if (x == null)
        {
            x = ImageResource.Create(z);
        }

        byte[] var4 = null;

        try
        {
            var4 = JavaString.GetBytes(A[0]);
        }
        catch (Exception var6)
        {
        }

        if (var4 != null)
        {
            int var5;
            if ((var5 = var4[0] << 8 & '\uff00' | var4[1] & 255) <= 33368)
            {
                v = FormattedTextResource.a1(var1, 6, false, B, false, (JavaString)null);
            }
            else if (var5 <= 33434)
            {
                v = FormattedTextResource.a1(var1, 5, false, B, false, (JavaString)null);
            }
            else if (var5 <= 33521)
            {
                v = FormattedTextResource.a1(var1, 3, false, B, false, (JavaString)null);
            }
            else if (var5 <= 33686)
            {
                v = FormattedTextResource.a1(var1, 4, false, B, false, (JavaString)null);
            }
        }

        return 1;
    }

    [FunctionName("d")]
    public override void UpdateInternal(GameContext var1)
    {
        switch (y)
        {
            case 0:
                y = 1;
                goto case 1;
            case 1:
                v.SetIsVisible(true);
                if (a == 0)
                {
                    if (var1.IsKeyPressed(Display.KEY_UP))
                    {
                        ((FormattedTextResource)v).a1(0);
                    }

                    if (var1.IsKeyPressed(Display.KEY_DOWN))
                    {
                        ((FormattedTextResource)v).a1(1);
                    }

                    if (var1.IsKeyPressed(Display.KEY_LEFT))
                    {
                        ((FormattedTextResource)v).a1(2);
                    }

                    if (var1.IsKeyPressed(Display.KEY_RIGHT))
                    {
                        ((FormattedTextResource)v).a1(3);
                    }

                    if (var1.IsKeyPressed(Display.KEY_MAIN))
                    {
                        ((FormattedTextResource)v).a1(4);
                    }
                    else if (var1.IsKeyPressed(Display.KEY_FIVE))
                    {
                        ((FormattedTextResource)v).a1(5);
                    }
                    else if (var1.IsKeyPressed(Display.KEY_TWO))
                    {
                        ((FormattedTextResource)v).a1(6);
                    }
                }

                if (!((FormattedTextResource)v).d().Equals(""))
                {
                    a += var1.d1();
                    if (a > 300)
                    {
                        v.SetIsVisible(false);
                        JavaString var2 = ((FormattedTextResource)v).d();

                        for (int var3 = 0; var3 < A.Length; ++var3)
                        {
                            if (var2.Equals(A[var3]))
                            {
                                a1(var1, true);
                                ((FormattedTextResource)v).c();
                                return;
                            }
                        }

                        a1(var1, false);
                        ((FormattedTextResource)v).b(true);
                        ((FormattedTextResource)v).c();
                        a = 0;
                        return;
                    }
                }
                else if (GetPressedButtonCaption(var1).Equals("pre_return"))
                {
                    y = 2;
                    return;
                }
                break;
            case 2:
                if (GetPressedButtonCaption(var1).Equals("return"))
                {
                    c1();
                }
                break;
        }
    }

    [FunctionName("a")]
    public override void a1(ScreenResource var1)
    {
        w = var1;
        var1.AddChild(x, centerPosX, centerPosY);
        var1.AddChild(v, centerPosX, centerPosY);
        v.SetIsVisible(false);
    }

    [FunctionName("d")]
    public override void d1()
    {
        x.SetIsVisible(false);
    }

    [FunctionName("c")]
    public override void c1()
    {
        if (v != null)
        {
            v.SetIsVisible(false);
        }

        y = 0;
    }

    [FunctionName("e")]
    public override void e1()
    {
        x.SetIsVisible(true);
    }

    [FunctionName("f")]
    public override void ResetInternal()
    {
        w.RemoveChild(x);
        x.Dispose();
        x = null;
        z.Dispose();
        z = null;
        A = null;
        v.f1();
        v = null;
        w = null;
    }

    [FunctionName("a")]
    public static object Read(nazo.PuzzleManager var0, BinaryReader var1)
    {
        KeyboardControlScene var2 = Create();

        try
        {
            var0.ReadInt32(var1.BaseStream);
            int var4 = var0.ReadInt32(var1.BaseStream);
            var2.z = var0.GetLoadedImage(var4);
            var2.A = new JavaString[var0.ReadInt32(var1.BaseStream)];

            for (int var5 = 0; var5 < var2.A.Length; ++var5)
            {
                var2.A[var5] = var0.ReadString(var1);
            }

            var2.B = var0.ReadInt32(var1.BaseStream);
        }
        catch (Exception var6)
        {
            var2 = null;
        }

        return var2;
    }
}
