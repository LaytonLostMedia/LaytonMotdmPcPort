using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm5.c;
using LaytonMotdm5.c.Managers;
using LaytonMotdm5.c.Resources;

namespace LaytonMotdm5.scene;

[ClassName("scene", "q")]
public class StartupScene : IScene
{
    [MemberName("a")]
    private int _state;
    [MemberName("b")]
    private ResourceBase[] b = new ResourceBase[1];
    [MemberName("c")]
    private ResourceBase c;
    [MemberName("d")]
    private ResourceBase[] d = new ResourceBase[8];
    [MemberName("e")]
    private ResourceBase e;
    [MemberName("f")]
    private Image f;
    [MemberName("g")]
    private bool g = true;
    [MemberName("h")]
    private int h;
    [MemberName("i")]
    private GameFileManager _fileManager;
    [MemberName("j")]
    private int j;
    [MemberName("k")]
    private int k;
    [MemberName("l")]
    private bool l;

    [MemberName("m")]
    private static bool m;
    [MemberName("n")]
    private static StartupScene instance = new();

    [MemberName("o")]
    private int o;

    [ConstructorName("q")]
    private StartupScene()
    {
    }

    [FunctionName("a")]
    public static StartupScene GetInstance(bool var0)
    {
        m = var0;
        return instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext GameContext)
    {
        GameContext.SetGameId(2045);
        GameContext.SetGameVersion(1000);

        DownloadManager.d = false;
        if (m)
        {
            DownloadManager.Initialize(GameContext.GetGameId(), GameContext.GetGameVersion());
            DownloadManager.c1();
        }

        _fileManager = new GameFileManager();
        l = false;
        g = true;
        GameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        if (!m)
        {
            SetState(88);
        }
        else
        {
            SetState(-2);
            o = GameContext.b1();
            GameContext.ScreenResource.ExecuteTransition(1);

            try
            {
                PhoneSystem.GetAttribute(5);
            }
            catch (Exception var4)
            {
                k = 9;
                SetState(66);
            }
        }
    }

    [FunctionName("a")]
    private void a1(int var1)
    {
        b[0].SetIsVisible(false);
        b[0 + var1].SetIsVisible(true);
    }

    [FunctionName("b")]
    private void SetState(int var1)
    {
        _state = var1;
        j = 0;
    }

    [FunctionName("b")]
    public bool Update(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        JavaString var3;
        switch (_state)
        {
            case -2:
                if (k > 0)
                {
                    if (l)
                    {
                        if (var2._transitionState == 2)
                        {
                            GameContext.j1();
                            GameContext.ScreenResource.ExecuteTransition(1);
                            if (0 == PhoneSystem.GetAttribute(5))
                            {
                                k = 2;
                            }
                            else
                            {
                                k = 0;
                            }

                            l = false;
                        }
                    }
                    else
                    {
                        var3 = GameContext.ShowSystemMessage(k);
                        if (var2._transitionState == 0)
                        {
                            if (var3 == null)
                            {
                                IApplication.GetCurrentApp().Terminate();
                            }
                            else if (!var3.Equals("はい") && !var3.Equals("リトライ"))
                            {
                                if (var3.Equals("いいえ") || var3.Equals("アプリ終了"))
                                {
                                    IApplication.GetCurrentApp().Terminate();
                                }
                            }
                            else
                            {
                                l = true;
                                GameContext.ScreenResource.ExecuteTransition(0);
                            }
                        }
                    }
                }
                else
                {
                    int var6;
                    if ((var6 = GameFileManager.InitializeBaseDirectories()) == 1)
                    {
                        var2.ExecuteTransition(0);
                        SetState(-1);
                    }
                    else if (var6 < 0)
                    {
                        GameFileManager.DeleteGameData();
                        GameContext.a1(1);
                        k = var6 * -1;
                        break;
                    }

                    if (GameFileManager.GetBaseDirectoryCount() > o || GameFileManager.GetBaseDirectoryCount() == GameFileManager.GetBaseDirectories().Length)
                    {
                        GameContext.a1(GameFileManager.GetBaseDirectoryCount());
                    }
                }
                break;

            case -1:
                if (var2._transitionState == 2 || !m)
                {
                    JavaString[] var5 = { "bg_title0.gif", "SP_logo_001.mld" };
                    if (_fileManager.LoadFiles(var5))
                    {
                        for (int var4 = 0; var4 < 1; ++var4)
                        {
                            b[0 + var4] = ImageResource.Create(_fileManager.GetLoadedImage(var5[var4]));
                        }

                        var2.AddChild(b[0], (240 - ((ImageResource)b[0]).GetWidth()) / 2, 0);
                        var2.ExecuteTransition(1);
                        SetState(0);
                        a1(_state);
                    }
                    else
                    {
                        SetState(99);
                    }
                }
                break;

            case 0:
                if (var2._transitionState == 0)
                {
                    if (g)
                    {
                        AudioManager.b1(1, _fileManager.GetLoadedSound("SP_logo_001.mld"), 100, 0);
                        g = false;
                    }

                    j += GameContext.d1();
                    if (j >= 1500)
                    {
                        var2.ExecuteTransition(0);
                        SetState(99);
                    }
                }
                break;

            case 66:
                var3 = GameContext.ShowSystemMessage(k);
                if (var2._transitionState == 0 && var3 == null)
                {
                    IApplication.GetCurrentApp().Terminate();
                }
                break;

            case 88:
                ++h;
                if (h > 20)
                {
                    h = 0;
                    SetState(-1);
                }
                break;

            case 99:
                if (var2._transitionState == 2)
                {
                    GameContext.SetCurrentScene(TitleScene.GetInstance());
                }
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        var1.ScreenResource.RemoveChild(b[0]);
        var1.ScreenResource.RemoveChild(c);
        if (e != null)
        {
            var1.ScreenResource.RemoveChild(e);
            e = null;
            f.Dispose();
            f = null;
        }

        int var2;
        for (var2 = 0; var2 < 1; ++var2)
        {
            b[var2] = null;
        }

        for (var2 = 0; var2 < d.Length; ++var2)
        {
            d[var2] = null;
        }

        c = null;

        try
        {
            _fileManager.Reset();
        }
        catch (Exception var3)
        {
        }

        _fileManager = null;
    }
}
