using com.nttdocomo.ui;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using DocomoLayton.game;
using DocomoLayton.game.Managers;
using DocomoLayton.game.Resources;

namespace DocomoLayton.scene;

[ClassName("scene", "c")]
public class SettingsScene : IScene
{
    [MemberName("a")]
    private static SettingsScene Instance = new();
    [MemberName("b")]
    private static IScene _returnPresenter;

    [MemberName("c")]
    private int c2;
    [MemberName("d")]
    private ResourceBase[] d = new ResourceBase[20];
    [MemberName("e")]
    private ResourceBase e;
    [MemberName("f")]
    private ResourceBase f;
    [MemberName("g")]
    private int g;
    [MemberName("h")]
    private bool h;
    [MemberName("i")]
    private int i;
    [MemberName("j")]
    private int j;
    [MemberName("k")]
    private int k;
    [MemberName("l")]
    private GameFileManager _fileManager;
    [MemberName("m")]
    private int[] m = new int[] { 68, 108, 167 };
    [MemberName("n")]
    private int[] n = new int[] { 173, 173, 179 };

    [ConstructorName("c")]
    private SettingsScene()
    {
    }

    [FunctionName("a")]
    public static SettingsScene GetInstance(IScene returnPresenter)
    {
        _returnPresenter = returnPresenter;
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        ScreenResource screen = gameContext.ScreenResource;

        _fileManager = new GameFileManager();
        gameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        i = 0;
        j = 1;
        g = AudioManager.c1();
        h = PhoneManager.a;
        data.RoomData.F1(1);
        c2 = 0;

        JavaString[] var3 = new JavaString[]
        {
            "bg_hanyou.jpg", "bg_option0.gif",
            "i_option0.gif", "i_option1.gif", "i_option2.gif", "i_option3.gif", "i_option4.gif", "i_option4.gif",
            "i_end.gif"
        };

        if (!_fileManager.LoadFiles(var3))
        {
            c2 = 99;
        }
        else
        {
            for (int var4 = 0; var4 < var3.Length; ++var4)
            {
                d[0 + var4] = ImageResource.Create(_fileManager.GetLoadedImage(var3[var4]));
            }

            d[13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
            ((ImageResource)d[13]).ClipRect(0, 0, 40, 15);
            d[14] = ImageResource.Create((ImageResource)d[13]);
            ((ImageResource)d[14]).ClipRect(40, 0, 40, 15);
            d[17] = ImageResource.Create(_fileManager.GetLoadedImage("i_end.gif"));
            ((ImageResource)d[17]).ClipRect(0, 0, 55, 15);
            d[18] = ImageResource.Create((ImageResource)d[17]);
            ((ImageResource)d[18]).ClipRect(55, 0, 55, 15);
            d[15] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            ((ImageResource)d[15]).SetFlipMode(Graphics.FLIP_ROTATE_LEFT);
            d[16] = ImageResource.Create((ImageResource)d[15]);
            ((ImageResource)d[16]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            d[19] = ImageResource.Create((ImageResource)d[15]);
            ((ImageResource)d[19]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            e = TextResource.Create("アプリを終了しますか？");
            d[8] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small1.gif"));
            d[9] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
            d[10] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
            d[11] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
            d[12] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));
            d[8].AddChild(e, (d[8].GetWidth() - e.GetWidth()) / 2, 24);
            d[8].AddChild(d[9], 20, 45);
            d[8].AddChild(d[10], 20, 45);
            d[8].AddChild(d[11], 115, 45);
            d[8].AddChild(d[12], 115, 45);
            d[8].AddChild(d[19], 103, 51);
            d[10].SetIsVisible(false);
            d[12].SetIsVisible(true);
            d[8].SetIsVisible(false);
            ((ImageResource)d[0]).SetAnchorType(ResourceBase.ANCHOR_CENTER);
            screen.AddChild(d[0], 120, 0);
            d[0].AddChild(d[1], (240 - d[1].GetWidth() - d[0].GetWidth()) / 2, 0);
            d[0].AddChild(d[2], 154 - d[0].GetWidth() / 2, 67);
            d[0].AddChild(d[3], 154 - d[0].GetWidth() / 2, 67);
            d[0].AddChild(d[4], 154 - d[0].GetWidth() / 2, 67);
            d[0].AddChild(d[6], 154 - d[0].GetWidth() / 2, 67);
            d[0].AddChild(d[5], 154 - d[0].GetWidth() / 2, 107);
            d[0].AddChild(d[7], 154 - d[0].GetWidth() / 2, 107);
            d[0].AddChild(d[14], 190 - d[0].GetWidth() / 2, 167);
            d[0].AddChild(d[13], 190 - d[0].GetWidth() / 2, 167);
            d[0].AddChild(d[18], 10 - d[0].GetWidth() / 2, 167);
            d[0].AddChild(d[17], 10 - d[0].GetWidth() / 2, 167);
            d[0].AddChild(d[15]);
            d[0].AddChild(d[16]);
            f = RectangleResource.Create(d[0].GetWidth(), 240, 1, 255, 255, 255, 200);
            d[0].AddChild(f, -d[0].GetWidth() / 2, 0);
            f.SetIsVisible(false);
            f.AddChild(d[8], (f.GetWidth() - d[8].GetWidth()) / 2, 70);
            a1(g);
            a1(h);
            a1(j, i);
            screen.ExecuteTransition(1);
            gameContext.b1(0);
        }
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        g = AudioManager.c1();
        a1(g);
        a1(h);
        a1(j, i);
        switch (c2)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    c2 = 1;
                }
                break;
            case 1:
                if (gameContext.IsKeyPressed(Display.KEY_UP))
                {
                    if (j == 1)
                    {
                        --i;
                        if (i < 0)
                        {
                            i = 0;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_DOWN))
                {
                    if (j == 1)
                    {
                        ++i;
                        if (i > 2)
                        {
                            i = 2;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_LEFT))
                {
                    if (j == 1)
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }

                    if (i == 0)
                    {
                        --g;
                        if (g < 0)
                        {
                            g = 3;
                        }

                        AudioManager.b1(g);
                        data.RoomData.F1(0);
                        if (g != 0)
                        {
                            data.RoomData.G1(g);
                        }
                    }
                    else if (i == 1)
                    {
                        h = !h;
                        if (h)
                        {
                            h = true;
                            PhoneManager.a1(5);
                        }

                        PhoneManager.a = h;
                        data.RoomData.F1(1);
                    }
                    else if (i == 2)
                    {
                        j = 0;
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_RIGHT))
                {
                    if (i != 2 || i == 2 && j == 0)
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }

                    if (i == 0)
                    {
                        ++g;
                        if (g > 3)
                        {
                            g = 0;
                        }

                        AudioManager.b1(g);
                        data.RoomData.F1(0);
                        if (g != 0)
                        {
                            data.RoomData.G1(g);
                        }
                    }
                    else if (i == 1)
                    {
                        h = !h;
                        if (!h)
                        {
                            h = false;
                        }
                        else
                        {
                            PhoneManager.a1(5);
                        }

                        PhoneManager.a = h;
                        data.RoomData.F1(1);
                    }
                    else if (i == 2)
                    {
                        j = 1;
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    if (i == 2)
                    {
                        if (j == 1)
                        {
                            a1(var2);
                        }
                        else
                        {
                            a1();
                        }
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_ONE))
                {
                    a1();
                }
                else if (gameContext.IsKeyPressed(Display.KEY_TWO))
                {
                    a1(var2);
                }
                break;
            case 2:
                if (gameContext.IsKeyPressed(Display.KEY_LEFT))
                {
                    if (k == 1)
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }

                    k = 0;
                    d[19].SetPosition(8, 51);
                    d[10].SetIsVisible(true);
                    d[12].SetIsVisible(false);
                }
                else if (gameContext.IsKeyPressed(Display.KEY_RIGHT))
                {
                    if (k == 0)
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }

                    k = 1;
                    d[19].SetPosition(103, 51);
                    d[10].SetIsVisible(false);
                    d[12].SetIsVisible(true);
                }
                else if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    c2 = 3;
                    if (k == 0)
                    {
                        d[9].SetPosition(d[9]._posX + 2, d[9]._posY + 2);
                        d[10].SetPosition(d[10]._posX + 2, d[10]._posY + 2);
                    }
                    else
                    {
                        d[11].SetPosition(d[11]._posX + 2, d[11]._posY + 2);
                        d[12].SetPosition(d[12]._posX + 2, d[12]._posY + 2);
                    }
                }
                break;
            case 3:
                c2 = 4;
                if (k == 0)
                {
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                }
                else
                {
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                }
                break;
            case 4:
                if (k == 0)
                {
                    if (AudioManager.d1(1) != 1)
                    {
                        IApplication.GetCurrentApp().Terminate();
                    }
                }
                else
                {
                    d[17].SetPosition(d[17]._posX - 2, d[17]._posY - 2);
                    d[18].SetPosition(d[18]._posX - 2, d[18]._posY - 2);
                    d[11].SetPosition(d[11]._posX - 2, d[11]._posY - 2);
                    d[12].SetPosition(d[12]._posX - 2, d[12]._posY - 2);
                    f.SetIsVisible(false);
                    d[8].SetIsVisible(false);
                    c2 = 1;
                }
                break;
            case 99:
                if (var2._transitionState == 2)
                {
                    gameContext.SetCurrentScene(_returnPresenter);
                }
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        for (int var2 = 19; var2 >= 0; --var2)
        {
            if (d[var2] != null)
            {
                var1.ScreenResource.RemoveChild(d[var2]);
                d[var2] = null;
            }
        }

        e = null;

        try
        {
            _fileManager.Reset();
        }
        catch (Exception var3)
        {
        }

        _fileManager = null;
    }

    [FunctionName("a")]
    private void a1(int var1)
    {
        d[2].SetIsVisible(false);
        d[3].SetIsVisible(false);
        d[4].SetIsVisible(false);
        d[6].SetIsVisible(false);
        switch (var1)
        {
            case 0:
                d[6].SetIsVisible(true);
                return;
            case 1:
                d[4].SetIsVisible(true);
                return;
            case 2:
                d[3].SetIsVisible(true);
                return;
            case 3:
                d[2].SetIsVisible(true);
                break;
            default:
                break;
        }
    }

    [FunctionName("a")]
    private void a1(bool var1)
    {
        if (!var1)
        {
            d[5].SetIsVisible(false);
            d[7].SetIsVisible(true);
        }
        else
        {
            d[5].SetIsVisible(true);
            d[7].SetIsVisible(false);
        }
    }

    [FunctionName("a")]
    private void a1(int var1, int var2)
    {
        if (var2 == 2)
        {
            if (var1 == 0)
            {
                d[18].SetIsVisible(true);
                d[14].SetIsVisible(false);
                d[15].SetIsVisible(true);
                d[15].SetPosition(68 - d[0].GetWidth() / 2, m[i]);
                d[16].SetIsVisible(false);
            }
            else
            {
                d[14].SetIsVisible(true);
                d[18].SetIsVisible(false);
                d[15].SetIsVisible(false);
                d[15].SetPosition(n[i] - 30 - d[0].GetWidth() / 2, m[i]);
                d[16].SetIsVisible(true);
                d[16].SetPosition(n[i] - d[0].GetWidth() / 2, m[i]);
            }
        }
        else
        {
            d[14].SetIsVisible(false);
            d[15].SetIsVisible(true);
            d[18].SetIsVisible(false);
            d[15].SetPosition(n[i] - 30 - d[0].GetWidth() / 2, m[i]);
            d[16].SetPosition(n[i] - d[0].GetWidth() / 2, m[i]);
        }
    }

    [FunctionName("a")]
    private void a1(ScreenResource var1)
    {
        i = 2;
        j = 1;
        a1(j, i);
        d[13].SetPosition(d[13]._posX + 2, d[13]._posY + 2);
        d[14].SetPosition(d[14]._posX + 2, d[14]._posY + 2);
        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
        c2 = 99;
        var1.ExecuteTransition(0);
    }

    [FunctionName("a")]
    private void a1()
    {
        i = 2;
        j = 0;
        a1(j, i);
        f.SetIsVisible(true);
        d[8].SetIsVisible(true);
        k = 1;
        d[19].SetPosition(103, 51);
        d[10].SetIsVisible(false);
        d[12].SetIsVisible(true);
        d[17].SetPosition(d[17]._posX + 2, d[17]._posY + 2);
        d[18].SetPosition(d[18]._posX + 2, d[18]._posY + 2);
        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
        c2 = 2;
    }
}
