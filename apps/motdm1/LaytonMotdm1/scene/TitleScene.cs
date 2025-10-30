using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm1.c;
using LaytonMotdm1.c.Managers;
using LaytonMotdm1.c.Resources;
using LaytonMotdm1.data;

namespace LaytonMotdm1.scene;

[ClassName("scene", "g")]
public class TitleScene : IScene
{
    [MemberName("k")]
    private static TitleScene Instance = new();

    [MemberName("b")]
    private int _state;
    [MemberName("c")]
    private readonly ResourceBase[] _resources = new ResourceBase[22];
    [MemberName("d")]
    private ResourceBase _presenterResource;
    [MemberName("e")]
    private GameFileManager _fileManager;
    [MemberName("f")]
    private int _selectedMenu;
    [MemberName("g")]
    private bool _hasSaveData;
    [MemberName("h")]
    private int h;
    [MemberName("i")]
    private int _animationStep;
    [MemberName("j")]
    private int _frameCount;
    [MemberName("l")]
    private bool _loadDifferentFont;

    [MemberName("a")]
    protected SaveData[] _saveData;

    [ConstructorName("g")]
    private TitleScene()
    {
    }

    [FunctionName("a")]
    public static TitleScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        ScreenResource screen = gameContext.ScreenResource;

        _fileManager = new GameFileManager();
        _hasSaveData = false;
        _selectedMenu = 0;
        _saveData = new SaveData[1];

        for (var i = 0; i < 1; ++i)
        {
            _saveData[i] = new SaveData();
            _saveData[i].LoadSlot(i);

            if (!JavaString.IsNullOrEmpty(_saveData[i].GetName()))
            {
                _selectedMenu = 1;
                _hasSaveData = true;
            }
        }

        _saveData = null;
        _animationStep = 0;
        _frameCount = 0;
        gameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        _state = 5;

        JavaString[] titleResourceNames =
        {
            "title_btn_a0.gif", "title_btn_a1.gif", "title_btn_b0.gif", "title_btn_b1.gif", "title_btn_e0.gif", "title_btn_e1.gif", "title_btn_c0.gif", "title_btn_c1.gif",
            "btn_3.gif",
            "bg_title.jpg", "bg_title_chara.gif", "bg_title2.gif",
            "title_btn_a0.gif",
            "kenri.gif",
            "bg_001.mld"
        };

        _loadDifferentFont = false;
        int gameId = gameContext.GetGameId();
        if (gameId != 2040)
        {
            _loadDifferentFont = true;
            titleResourceNames[12] = "font_title" + (gameId - 2040) + ".gif";
        }

        if (!_fileManager.LoadFiles(titleResourceNames))
        {
            _state = 99;
        }
        else
        {
            // Load title_btn_*.gif
            for (var ii = 0; ii < 8; ++ii)
                _resources[ii] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[ii]));

            // Load btn_3.gif, inactive
            _resources[8] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[8]));
            ((ImageResource)_resources[8]).ClipRect(0, 0, _resources[8].GetWidth() / 2, _resources[8].GetHeight());

            // Load btn_3.gif, active
            _resources[9] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[8]));
            ((ImageResource)_resources[9]).ClipRect(_resources[9].GetWidth() / 2, 0, _resources[9].GetWidth() / 2, _resources[9].GetHeight());

            // Load i_cur.gif, flipped right
            _resources[10] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            ((ImageResource)_resources[10]).SetFlipMode(Graphics.FLIP_ROTATE_LEFT);

            // Load i_cur.gif, flipped left
            _resources[11] = ImageResource.Create((ImageResource)_resources[10]);
            ((ImageResource)_resources[11]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);

            _resources[10].SetIsVisible(false);
            _resources[11].SetIsVisible(false);

            // Load bg_title* resources
            _resources[16] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[9]));
            _resources[17] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[10]));
            _resources[19] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[11]));

            // Load kenri.gif (copyright notice)
            _resources[21] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[13]));

            // Load PRESS SELECT KEY text
            _resources[18] = TextResource.Create("PRESS SELECT KEY");
            ((TextResource)_resources[18]).SetAnchorType(ResourceBase.ANCHOR_CENTER);
            ((TextResource)_resources[18]).SetOutlineMode(TextResource.OUTLINE_FULL);
            ((TextResource)_resources[18]).SetTextColor(255, 255, 255);

            _resources[16].AddChild(_resources[18], _resources[16].GetWidth() / 2, 160);
            _resources[18].SetIsVisible(false);

            gameContext.b1(3);
            screen.AddChild(_resources[16], 0, 0);

            _resources[16].AddChild(_resources[17], _resources[16].GetWidth() - _resources[17].GetWidth(), _resources[16].GetHeight() - _resources[17].GetHeight());
            _resources[16].AddChild(_resources[19], (_resources[16].GetWidth() - _resources[19].GetWidth()) / 2, 4);
            _resources[16].AddChild(_resources[21], 2, 181);

            _resources[17].ExecuteTransition(0);
            _resources[19].ExecuteTransition(0);
            _resources[21].ExecuteTransition(0);

            _resources[16].SetIsVisible(false);
            _resources[17].SetIsVisible(false);
            _resources[19].SetIsVisible(false);
            _resources[21].SetIsVisible(false);

            if (_loadDifferentFont)
            {
                _resources[20] = ImageResource.Create(_fileManager.GetLoadedImage(titleResourceNames[12]));
                _resources[16].AddChild(_resources[20], (_resources[16].GetWidth() - _resources[20].GetWidth()) / 2, 71);
                _resources[20].ExecuteTransition(0);
                _resources[20].SetIsVisible(false);
            }

            _presenterResource = RectangleResource.Create(240, 192, RectangleResource.RECT_FILL, 255, 255, 255, 255);
            screen.AddChild(_presenterResource, 0, 0);
            _presenterResource.SetIsVisible(false);

            for (var ii = 0; ii < 5; ++ii)
            {
                // Place button resources below each other
                // Centered in width; Starting from height 94px, in steps of 19px
                _resources[16].AddChild(_resources[ii * 2], (240 - _resources[ii * 2].GetWidth()) / 2, 94 + ii * 19);
                _resources[16].AddChild(_resources[ii * 2 + 1], (240 - _resources[ii * 2 + 1].GetWidth()) / 2, 94 + ii * 19);

                _resources[ii * 2].SetIsVisible(false);
                _resources[ii * 2 + 1].SetIsVisible(false);
            }

            screen.AddChild(_resources[11], (240 - _resources[11].GetWidth()) / 2 - 70, 30 + 30 * _selectedMenu);
            screen.AddChild(_resources[10], (240 - _resources[10].GetWidth()) / 2 + 70, 30 + 30 * _selectedMenu);

            _resources[15] = RectangleResource.Create(240, 240, RectangleResource.RECT_FILL, 255, 255, 255, 128);
            _resources[12] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small1.gif"));
            _resources[14] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
            _resources[13] = TextResource.Create("セーブデータがありません…。");

            screen.AddChild(_resources[15], (240 - _resources[15].GetWidth()) / 2, 0);

            _resources[15].AddChild(_resources[12], (240 - _resources[12].GetWidth()) / 2, 70);
            _resources[15].AddChild(_resources[14], 205, 133);
            _resources[12].AddChild(_resources[13], (_resources[12].GetWidth() - _resources[13].GetWidth()) / 2, (_resources[12].GetHeight() - _resources[13].GetHeight()) / 2);

            ((ImageResource)_resources[14]).b1(0, 0, _resources[14].GetWidth() / 2, _resources[14].GetHeight());
            ((ImageResource)_resources[14]).b1(1, 3);
            _resources[15].SetIsVisible(false);

            AudioManager.a1(0, _fileManager.GetLoadedSound("bg_001.mld"), 100, 0);
        }
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;

        _resources[10].SetPosition(_resources[_selectedMenu * 2].posX + _resources[0 + _selectedMenu * 2].GetWidth() + 1, 95 + _selectedMenu * 19);
        _resources[11].SetPosition(_resources[_selectedMenu * 2].posX - 9, 95 + _selectedMenu * 19);

        switch (_state)
        {
            // Intro animation transition -> _state 1
            case 0:
                if (var2._transitionState == 0)
                {
                    _state = 1;
                }
                break;

            // Menu control -> _state 2 or 3 on main button
            case 1:
                // Key up
                if (gameContext.IsKeyPressed(Display.KEY_UP))
                {
                    --_selectedMenu;
                    if (_selectedMenu < 0)
                    {
                        _selectedMenu = 0;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                }

                // Key down
                if (gameContext.IsKeyPressed(Display.KEY_DOWN))
                {
                    ++_selectedMenu;
                    if (_selectedMenu > 4)
                    {
                        _selectedMenu = 4;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                }

                // Main button
                if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    _resources[0 + _selectedMenu * 2].SetIsVisible(false);
                    _resources[1 + _selectedMenu * 2].SetIsVisible(true);

                    if (_selectedMenu == 1)
                    {
                        _state = !_hasSaveData ? 3 : 2;
                    }
                    else
                    {
                        _state = 2;
                    }

                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                }
                break;

            // Select menu transition -> _state 99
            case 2:
                _state = 99;
                var2.ExecuteTransition(0);
                break;

            // If no save data is present -> _state 1 on main button
            case 3:
                _resources[15].SetIsVisible(true);

                if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);

                    _resources[15].SetIsVisible(false);
                    _resources[0 + _selectedMenu * 2].SetIsVisible(true);
                    _resources[1 + _selectedMenu * 2].SetIsVisible(false);

                    _state = 1;
                }
                break;

            // Intro animation -> _state 0
            case 5:
                if (_animationStep == 0)
                {
                    ++_frameCount;
                    if (_frameCount > 20)
                    {
                        _frameCount = 0;
                        _animationStep = 1;
                        _resources[16].SetIsVisible(true);
                        gameContext.ScreenResource.ExecuteTransition(1);
                    }
                }
                else if (_animationStep == 1)
                {
                    if (var2._transitionState == 0)
                    {
                        ++_frameCount;
                        if (_frameCount > 60)
                        {
                            _frameCount = 0;
                            _animationStep = 2;
                            _presenterResource.SetIsVisible(false);
                        }
                        else if (_frameCount > 51)
                        {
                            _presenterResource.SetIsVisible(false);
                        }
                        else if (_frameCount > 50)
                        {
                            _presenterResource.SetIsVisible(true);
                        }
                        else if (_frameCount > 21)
                        {
                            _presenterResource.SetIsVisible(false);
                        }
                        else if (_frameCount > 20)
                        {
                            _presenterResource.SetIsVisible(true);
                        }
                    }
                }
                else if (_animationStep == 2)
                {
                    _resources[17].SetIsVisible(true);
                    _resources[17].ExecuteTransition(1);
                    _animationStep = 3;
                }
                else if (_animationStep == 3)
                {
                    if (_resources[17]._transitionState == 0)
                    {
                        ++_frameCount;
                        if (_frameCount > 5)
                        {
                            _frameCount = 0;
                            _animationStep = 4;
                        }
                    }
                }
                else if (_animationStep == 4)
                {
                    _resources[19].SetIsVisible(true);
                    _resources[19].ExecuteTransition(1);
                    _resources[21].SetIsVisible(true);
                    _resources[21].ExecuteTransition(1);

                    if (_loadDifferentFont)
                    {
                        _resources[20].SetIsVisible(true);
                        _resources[20].ExecuteTransition(1);
                    }

                    _animationStep = 5;
                }
                else if (_animationStep == 5)
                {
                    if (_resources[19]._transitionState == 0)
                    {
                        ++_frameCount;
                        if (_frameCount > 5)
                        {
                            _frameCount = 0;
                            _animationStep = 6;
                        }
                    }
                }
                else if (_animationStep == 6)
                {
                    _frameCount += gameContext.d1();
                    if (_frameCount >= 500)
                    {
                        if (_frameCount >= 1000)
                        {
                            _frameCount = 0;
                        }

                        _resources[18].SetIsVisible(true);
                    }
                    else
                    {
                        _resources[18].SetIsVisible(false);
                    }
                }

                if (_animationStep == 7 && var2._transitionState == 2)
                {
                    _presenterResource.SetIsVisible(false);
                    _resources[16].SetIsVisible(true);
                    _resources[17].SetIsVisible(true);
                    _resources[17].ExecuteTransition(1);
                    _resources[19].SetIsVisible(true);
                    _resources[19].ExecuteTransition(1);
                    _resources[21].SetIsVisible(true);
                    _resources[21].ExecuteTransition(1);
                    if (_loadDifferentFont)
                    {
                        _resources[20].SetIsVisible(true);
                        _resources[20].ExecuteTransition(1);
                    }

                    for (int var7 = 0; var7 < 5; ++var7)
                    {
                        _resources[0 + var7 * 2].SetIsVisible(true);
                    }

                    _resources[10].SetIsVisible(true);
                    _resources[11].SetIsVisible(true);
                    _resources[18].SetIsVisible(false);
                    _state = 0;
                    var2.ExecuteTransition(1);
                    _animationStep = 0;
                }

                // If main button pressed, jump to end of animation
                if (gameContext.IsKeyPadPressed(Display.KEY_MAIN) && var2._transitionState == 0)
                {
                    var2.ExecuteTransition(0);
                    _animationStep = 7;
                }
                break;

            // Change screen presenter
            case 99:
                if (var2._transitionState == 2)
                {
                    switch (_selectedMenu)
                    {
                        // New game
                        case 0:
                            gameContext.Reset();
                            gameContext.RoomData.SetEventId(0);
                            gameContext.SetCurrentScene(EventScene.GetInstance());
                            AudioManager.StopSound(0);
                            break;

                        // Load save
                        case 1:
                            gameContext.Reset();
                            gameContext.SaveData.LoadSlot(0);
                            gameContext.RoomData.Load(gameContext);
                            gameContext.SetCurrentScene(RoomScene.GetInstance());
                            break;

                        // Open memo
                        case 2:
                            gameContext.SetCurrentScene(MemoScene.GetInstance(0));
                            break;

                        // Open settings
                        case 3:
                            gameContext.SetCurrentScene(SettingsScene.GetInstance(GetInstance()));
                            break;

                        case 4:
                            DownloadManager.d1();
                            _state = 0;
                            _resources[0 + _selectedMenu * 2].SetIsVisible(true);
                            _resources[1 + _selectedMenu * 2].SetIsVisible(false);
                            gameContext.ScreenResource.ExecuteTransition(1);
                            break;

                        case 5:
                            break;
                    }
                }
                break;

            // ?
            case 555:
                JavaString var3 = gameContext.ShowSystemMessage(h);
                if (var2._transitionState == 0)
                {
                    if (var3 == null)
                    {
                        IApplication.GetCurrentApp().Terminate();
                    }
                    else if (var3.Equals("はい"))
                    {
                        JavaString[] var4 = { "http://www.i.t-net-jp.com/~devteam3/oshida/layton/webto/index.html" };

                        try
                        {
                            IApplication.GetCurrentApp().Launch(1, var4);
                        }
                        catch (Exception var6)
                        {
                            java.util.System.Out.Fatal(var6, "URL:{0}", var4[0]);
                        }

                        gameContext.ResetPressedKeys();
                    }
                    else if (var3.Equals("いいえ"))
                    {
                        IApplication.GetCurrentApp().Terminate();
                    }
                }
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        for (var ii = 0; ii < 22; ++ii)
        {
            var1.ScreenResource.RemoveChild(_resources[ii]);
            _resources[ii] = null;
        }

        try
        {
            _fileManager.Reset();
        }
        catch { }

        _fileManager = null;
    }
}
