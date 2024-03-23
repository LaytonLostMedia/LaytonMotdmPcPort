using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace DocomoLayton.game;

[ClassName("c", "Main")]
public class Main : IApplication
{
    [FunctionName("start")]
    public void start()
    {
        GameContext.GetInstance().Start();
    }

    [FunctionName("resume")]
    public void resume()
    {
        GameContext.GetInstance().Resume();
    }
}
