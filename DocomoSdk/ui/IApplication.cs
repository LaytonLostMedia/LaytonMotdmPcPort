namespace com.nttdocomo.ui;

public class IApplication
{
    private static readonly IApplication _instance = new();

    public static IApplication GetCurrentApp() => _instance;

    public void Launch(int a, string[] args){}

    public void Terminate()
    {
        Environment.Exit(0);
    }

    public string GetSourceUrl() => "http://nothing.com";
}
