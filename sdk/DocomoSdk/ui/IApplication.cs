using DocomoCsJavaBridge;
using java.lang;

namespace com.nttdocomo.ui;

public abstract class IApplication
{
    private static IApplication _instance;

    private JavaString[] _args;

    public static IApplication GetCurrentApp() => _instance;

    public void Launch(int a, JavaString[] args)
    {
        _args = args;
        _instance = this;

        start();
    }

    public JavaString[] GetArgs() => _args;

    public JavaString GetSourceUrl() => AppInfo.GetPackageUrl();

    public abstract void start();
    public abstract void resume();

    public void Terminate()
    {
        Environment.Exit(0);
    }
}
