using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm6.c;
using LaytonMotdm6.c.Managers;
using LaytonMotdm6.c.Resources;

namespace LaytonMotdm6.scene;

[ClassName("scene", "c")]
public class ButtonControlScene : ControlScene
{
    [MemberName("v")]
    private static ButtonControlScene Instance = null;
    [MemberName("w")]
    private nazo.PuzzleFactory w = null;
    
    [MemberName("a")]
    protected JavaString a = "";

    [FunctionName("a")]
    public static ButtonControlScene GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ButtonControlScene();
        }

        return Instance;
    }

    [FunctionName("b")]
    public override void b1()
    {
    }

    [ConstructorName("c")]
    private ButtonControlScene()
    {
    }

    [FunctionName("a")]
    public override int a1(GameContext var1, object[] var2)
    {
        w = (nazo.PuzzleFactory)var2[0];
        w.a1(f);
        return 1;
    }

    [FunctionName("d")]
    public override void UpdateInternal(GameContext var1)
    {
        if (!a.Equals(""))
        {
            a = GetPressedButtonCaption(var1);
        }
        else
        {
            JavaString var2;
            if ((var2 = a1(var1, w)).Equals(""))
            {
                if (var1.IsKeyPressed(Display.KEY_MAIN))
                {
                }

                a = GetPressedButtonCaption(var1);
            }
            else
            {
                AudioManager.PlaySound(1, n[1], 100);
                if (var2.Equals("true"))
                {
                    a1(var1, true);
                }
                else
                {
                    if (var2.Equals("false"))
                    {
                        a1(var1, false);
                    }

                }
            }
        }
    }

    [FunctionName("a")]
    public override void a1(ScreenResource var1)
    {
        w.a1(var1, centerPosX, centerPosY);
    }

    [FunctionName("c")]
    public override void c1()
    {
        w.b1();
    }

    [FunctionName("d")]
    public override void d1()
    {
        w.d1();
        w.g1();
    }

    [FunctionName("e")]
    public override void e1()
    {
        w.f1();
    }

    [FunctionName("f")]
    public override void ResetInternal()
    {
        if (w != null)
        {
            w.Reset();
            w = null;
        }
    }
}