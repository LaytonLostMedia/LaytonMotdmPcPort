using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using LaytonMotdm4.c;
using LaytonMotdm4.c.Resources;

namespace LaytonMotdm4.scene;

[ClassName("scene", "e")]
public class SdCardErrorScene : IScene
{
    [MemberName("a")]
    private static SdCardErrorScene Instance = null;

    [ConstructorName("e")]
    public SdCardErrorScene()
    {
    }

    [FunctionName("a")]
    public static SdCardErrorScene GetInstance()
    {
        if (Instance == null)
        {
            Instance = new SdCardErrorScene();
        }

        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext GameContext)
    {
    }

    [FunctionName("b")]
    public bool Update(GameContext GameContext)
    {
        ScreenResource var2;
        if ((var2 = GameContext.ScreenResource)._transitionState == 0)
        {
            if (GameContext.ShowSystemMessage(4) == null)
            {
                IApplication.GetCurrentApp().Terminate();
            }
        }
        else if (var2._transitionState == 2)
        {
            var2.ExecuteTransition(1);
        }
        else if (var2._transitionState == 3)
        {
            GameContext.ShowSystemMessage(4);
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
    }
}