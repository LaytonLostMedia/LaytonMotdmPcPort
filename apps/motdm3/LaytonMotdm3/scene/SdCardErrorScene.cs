using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Resources;

namespace LaytonMotdm3.scene;

[ClassName("scene", "d")]
public class SdCardErrorScene : IScene
{
    [MemberName("a")]
    private static SdCardErrorScene Instance = null;

    [ConstructorName("d")]
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
    public void Setup(GameContext gameContext)
    {
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2;
        if ((var2 = gameContext.ScreenResource)._transitionState == 0)
        {
            if (gameContext.ShowSystemMessage(4) == null)
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
            gameContext.ShowSystemMessage(4);
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
    }
}