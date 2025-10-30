using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm3.c;

[ClassName("c", "Main")]
public class Main : IApplication
{
    [FunctionName("start")]
    public override void start()
    {
        GameContext.GetInstance().Start();
    }

    [FunctionName("resume")]
    public override void resume()
    {
        GameContext.GetInstance().Resume();
    }
}
