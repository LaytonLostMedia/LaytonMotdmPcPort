using com.nttdocomo.ui;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using DocomoLayton.game.Resources;
using DocomoLayton.data;
using DocomoLayton.game;
using DocomoLayton.game.Managers;

namespace DocomoLayton.scene;

[ClassName("scene", "h")]
public class RoomScene : IScene
{
    [MemberName("b")]
    private int _state;
    [MemberName("c")]
    private ResourceBase[] _resources = new ResourceBase[16];
    [MemberName("d")]
    private ResourceBase _backgroundResource;
    [MemberName("e")]
    private ResourceBase[] _backgroundObjectResources;
    [MemberName("f")]
    private ResourceBase _cursorResource;
    [MemberName("g")]
    private bool _hasExits;

    [MemberName("a")]
    protected GameFileManager a;

    [MemberName("h")]
    private int _selectedButton;
    [MemberName("i")]
    private int i;
    [MemberName("j")]
    private int j;
    [MemberName("k")]
    private bool k;
    [MemberName("l")]
    private int l;
    [MemberName("m")]
    private RoomData _roomData;

    [MemberName("n")]
    private static RoomScene Instance = new();

    [ConstructorName("h")]
    private RoomScene()
    {
    }

    [FunctionName("a")]
    public static RoomScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        ScreenResource screen = gameContext.ScreenResource;
        _roomData = gameContext.RoomData;

        gameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));

        gameContext.RoomData.ClearExits();
        gameContext.RoomData.ClearEvents();
        gameContext.RoomData.u1();
        gameContext.RoomData.ClearEventTexts();

        _selectedButton = 0;
        _state = 0;

        int roomId = gameContext.SaveData.GetRoomId();
        JavaString[] var5 = new JavaString[1];
        if (roomId < 10)
        {
            var5[0] = "room_" + Helper.ToStringPad(roomId, 2) + ".dat";
        }
        else
        {
            var5[0] = "room_" + (char)roomId + ".dat";
        }

        if (GameContext.RoomId != roomId)
        {
            gameContext.ScriptFileManager.Reset();
            if (!gameContext.ScriptFileManager.LoadFiles(var5))
            {
                return;
            }

            gameContext.RoomData.SetRoomEntered(1);
            gameContext.RoomData.a1(true);
        }

        byte[] var6 = gameContext.ScriptFileManager.GetLoadedData(var5[0]);
        ScriptExecutor scriptEngine;
        (scriptEngine = new ScriptExecutor()).ExecuteAll(var6, gameContext);
        if (scriptEngine.shouldStopExecution)
        {
            GameContext.RoomId = -1;
            scriptEngine.shouldStopExecution = false;
            _state = 99;
            _selectedButton = 99;
        }
        else
        {
            _hasExits = true;
            if (gameContext.RoomData.GetExitCount() == 0)
            {
                _hasExits = false;
            }

            JavaString[] var8 = new JavaString[]
            {
                "i_main30.gif", "i_main31.gif", "i_main32.gif", "i_main40.gif", "i_main41.gif", "i_main42.gif", "i_main20.gif", "i_main21.gif", "i_main22.gif", 
                "i_main10.gif", "i_main11.gif", "i_main12.gif", "t_main30.gif", "t_main40.gif", "t_main20.gif", "t_main10.gif"
            };
            if (GameContext.RoomId != roomId)
            {
                if (gameContext.ScriptResourceFileManager != null)
                {
                    gameContext.ScriptResourceFileManager.Reset();
                    gameContext.RoomData.w1();
                }

                gameContext.RoomData.ResourceNames = scriptEngine.ResourceFileNames;
                if (gameContext.RoomData.ResourceNames != null && !gameContext.ScriptResourceFileManager.LoadFiles(_roomData.ResourceNames))
                {
                    return;
                }

                GameContext.RoomId = roomId;
                GameContext.RoomEventId = -1;
            }

            int var9;
            for (var9 = 0; var9 < 16; ++var9)
            {
                _resources[0 + var9] = ImageResource.Create(GameContext.FileManager.GetLoadedImage(var8[var9]));
            }

            _cursorResource = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            _backgroundResource = ImageResource.Create(gameContext.ScriptResourceFileManager.GetLoadedImage(_roomData.GetBackground()));
            if (_roomData.IsBackgroundFlipped())
            {
                ((ImageResource)_backgroundResource).SetFlipMode(Graphics.FLIP_HORIZONTAL);
            }
            else
            {
                ((ImageResource)_backgroundResource).SetFlipMode(Graphics.FLIP_NONE);
            }

            screen.AddChild(_backgroundResource, (240 - ((ImageResource)_backgroundResource).GetWidth()) / 2, 0);

            if ((var9 = _roomData.GetBackgroundObjectCount()) > 0)
            {
                JavaString bgojName = "bgoj_" + Helper.ToStringPad(roomId, 3) + ".dat";
                _backgroundObjectResources = gameContext.RoomData.a1(gameContext.ScriptResourceFileManager, bgojName);

                for (int var11 = 0; var11 < var9; ++var11)
                {
                    if (gameContext.RoomData.IsBackgroundObjectFlipped(var11))
                    {
                        ((AnimatedImageResource)_backgroundObjectResources[var11]).SetFlipMode(Graphics.FLIP_HORIZONTAL);
                    }
                    else
                    {
                        ((AnimatedImageResource)_backgroundObjectResources[var11]).SetFlipMode(Graphics.FLIP_NONE);
                    }

                    int[] bgPos = _roomData.GetBackgroundPosition(var11);
                    _backgroundResource.AddChild(_backgroundObjectResources[var11], bgPos[0], bgPos[1]);
                }
            }

            bool var14 = false;

            for (int var16 = 0; var16 < 12; ++var16)
            {
                if (_hasExits || !_hasExits && (var16 < 3 || var16 > 5))
                {
                    _backgroundResource.AddChild(_resources[0 + var16]);
                }

                if (var16 % 3 != 0)
                {
                    _resources[0 + var16].SetIsVisible(false);
                }

                int var13 = var16 / 3;
                int var15 = 27 + var13 * 54;
                _resources[0 + var16].SetPosition(var15, 196);
            }

            _backgroundResource.AddChild(_resources[12], 21, 226);
            if (_hasExits)
            {
                _backgroundResource.AddChild(_resources[13], 78, 226);
            }

            _backgroundResource.AddChild(_resources[14], 130, 226);
            _backgroundResource.AddChild(_resources[15], 188, 226);
            _backgroundResource.AddChild(_cursorResource);
            ((ImageResource)_resources[0]).SetSize(_resources[0].GetWidth() / 2, _resources[0].GetHeight() / 2);
            UpdateButtonStates(0);
            if (roomId == 100)
            {
                _state = 99;
                _selectedButton = 0;
            }

            if (screen._transitionState == 2)
            {
                screen.ExecuteTransition(1);
            }

            AudioManager.a1(0, GameContext.FileManager.GetLoadedSound(scriptEngine.SoundFile), 100);
        }
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        switch (_state)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    _state = 3;
                }
                break;
            case 1:
                if (var2._transitionState == 2)
                {
                    _state = 3;
                    var2.ExecuteTransition(1);
                }
                break;
            case 2:
                ++i;
                if (i > 5)
                {
                    i = 0;
                    if (_selectedButton > 1)
                    {
                        var2.ExecuteTransition(0);
                    }

                    _state = 99;
                }
                break;
            case 3:
                if (k)
                {
                    ++l;
                    if (l > 20)
                    {
                        _state = 4;
                        l = 0;
                        k = false;
                        UpdateButtonStates(false);
                        break;
                    }
                }

                UpdateButtonStates(0);

                if (gameContext.IsKeyPressed(Display.KEY_LEFT))
                {
                    --_selectedButton;

                    if (!_hasExits && _selectedButton == 1)
                    {
                        _selectedButton = 0;
                    }

                    if (_selectedButton < 0)
                    {
                        _selectedButton = 0;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100);
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_RIGHT))
                {
                    ++_selectedButton;

                    if (!_hasExits && _selectedButton == 1)
                    {
                        _selectedButton = 2;
                    }

                    if (_selectedButton > 3)
                    {
                        _selectedButton = 3;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100);
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    _state = 2;
                    UpdateButtonStates(1);
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                }
                else if (gameContext.IsKeyPressed(Display.KEY_ONE))
                {
                    _selectedButton = 0;
                    _state = 2;
                    UpdateButtonStates(1);
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                }
                else if (gameContext.IsKeyPressed(Display.KEY_TWO))
                {
                    if (_hasExits)
                    {
                        _selectedButton = 1;
                        _state = 2;
                        UpdateButtonStates(1);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_THREE))
                {
                    _selectedButton = 2;
                    _state = 2;
                    UpdateButtonStates(1);
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                }
                else if (gameContext.IsKeyPressed(Display.KEY_FOUR))
                {
                    _selectedButton = 3;
                    _state = 2;
                    UpdateButtonStates(1);
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                }
                break;
            case 99:
                if (_selectedButton == 0)
                {
                    RoomEventsScene var3 = RoomEventsScene.GetInstance();
                    gameContext.SetCurrentScene(var3);
                }

                if (_selectedButton == 1)
                {
                    RoomExitsScene var4 = RoomExitsScene.GetInstance();
                    gameContext.SetCurrentScene(var4);
                }

                if (_selectedButton == 2 && var2._transitionState == 2)
                {
                    gameContext.SetCurrentScene(IngameMenuScene.GetInstance());
                }

                if (_selectedButton == 3 && var2._transitionState == 2)
                {
                    gameContext.SetCurrentScene(MapScene.GetInstance());
                }

                if (_selectedButton == 99)
                {
                    gameContext.RoomData.SetPlayerState(0);
                    EventScene var5 = EventScene.GetInstance();
                    gameContext.SetCurrentScene(var5);
                }
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        if (_backgroundResource != null)
        {
            int var2;
            for (var2 = 0; var2 < 16; ++var2)
            {
                _backgroundResource.RemoveChild(_resources[var2]);
                _resources[var2] = null;
            }

            if (_backgroundObjectResources != null)
            {
                for (var2 = 0; var2 < _backgroundObjectResources.Length; ++var2)
                {
                    _backgroundResource.RemoveChild(_backgroundObjectResources[var2]);
                    _backgroundObjectResources[var2] = null;
                }
            }

            _backgroundResource.RemoveChild(_cursorResource);
            _cursorResource = null;

            var1.ScreenResource.RemoveChild(_backgroundResource);
            _backgroundResource = null;

            if (a != null)
            {
                a.Reset();
                a = null;
            }
        }
    }

    [FunctionName("a")]
    private void UpdateButtonStates(int selectedButtonState)
    {
        int var2;
        for (var2 = 0; var2 < 4; ++var2)
        {
            _resources[0 + var2 * 3].SetIsVisible(true);
            _resources[1 + var2 * 3].SetIsVisible(false);
            _resources[2 + var2 * 3].SetIsVisible(false);
        }

        _resources[0 + _selectedButton * 3].SetIsVisible(false);
        if (selectedButtonState == 0)
        {
            _resources[1 + _selectedButton * 3].SetIsVisible(true);
        }
        else
        {
            _resources[2 + _selectedButton * 3].SetIsVisible(true);
        }

        var2 = _resources[1 + _selectedButton * 3]._posX - 12;
        int var3 = _resources[1 + _selectedButton * 3]._posY + 8;
        ((ImageResource)_cursorResource).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
        _cursorResource.SetPosition(var2, var3);
        GameContext.a1((ImageResource)_cursorResource, var2, var3, j);
        ++j;
    }

    [FunctionName("a")]
    private void UpdateButtonStates(bool var1)
    {
        for (int var2 = 0; var2 < 4; ++var2)
        {
            _resources[0 + var2 * 3].SetIsVisible(var1);
            _resources[1 + var2 * 3].SetIsVisible(var1);
            _resources[12 + var2].SetIsVisible(var1);
        }

        _cursorResource.SetIsVisible(var1);
    }
}
