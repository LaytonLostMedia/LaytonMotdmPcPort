using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm4.c;
using LaytonMotdm4.c.Files;
using LaytonMotdm4.c.Managers;
using LaytonMotdm4.c.Resources;

namespace LaytonMotdm4.scene;

[ClassName("scene", "t")]
public class EventScene : IScene
{
    [MemberName("t")]
    private int _state;
    [MemberName("u")]
    private int _previousState;
    [MemberName("v")]
    private ResourceBase _textWindowResource;
    [MemberName("w")]
    private ResourceBase _upCursorResource2;
    [MemberName("x")]
    private ResourceBase[] _yesSelectedBtnResources;
    [MemberName("y")]
    private ResourceBase _rightCursorResource;
    [MemberName("z")]
    private ResourceBase z;
    [MemberName("A")]
    private ResourceBase A;
    [MemberName("B")]
    private ResourceBase[] B;
    [MemberName("C")]
    private int C = 0;
    [MemberName("D")]
    private int D = 0;
    [MemberName("E")]
    private int E = 0;
    [MemberName("F")]
    private int F = 0;
    [MemberName("G")]
    private int G = 0;

    [MemberName("a")]
    protected bool a = true;

    [MemberName("H")]
    private int[] H;
    [MemberName("I")]
    private int[] I;

    [MemberName("b")]
    protected ScriptExecutor scriptExecutor;

    [MemberName("J")]
    private int J = 0;
    [MemberName("K")]
    private int K = 0;
    [MemberName("L")]
    private int L = 0;
    [MemberName("M")]
    private int M = 0;

    [MemberName("c")]
    protected ScriptTextResource _scriptText;
    [MemberName("d")]
    protected ResourceBase _addedPuzzleTextResource;
    [MemberName("e")]
    protected ResourceBase[] e = new ResourceBase[2];
    [MemberName("f")]
    protected ResourceBase _upCursorResource;
    [MemberName("g")]
    protected ResourceBase _blackBackgroundResource;
    [MemberName("h")]
    protected ResourceBase _resourceBase;

    [MemberName("N")]
    private int _animatedImageCount = 0;
    [MemberName("O")]
    private int[] O;
    [MemberName("P")]
    private int[] P;
    [MemberName("Q")]
    private int[] Q;
    [MemberName("R")]
    private int[] R;
    [MemberName("S")]
    private int[] S;
    [MemberName("T")]
    private int[] T;
    [MemberName("U")]
    private ResourceBase[] U;

    [MemberName("i")]
    protected CharacterResourceFile i;

    [MemberName("V")]
    private static EventScene Instance = new();

    [MemberName("j")]
    protected int _scriptOffset = 0;
    [MemberName("k")]
    protected byte[] _scriptData;
    [MemberName("l")]
    protected GameFileManager _defaultFileManager = new();
    [MemberName("m")]
    protected GameFileManager _scriptResourceFileManager = new();
    [MemberName("n")]
    protected GameFileManager _scriptFileManager = new();
    [MemberName("o")]
    protected GameFileManager _gameFileManager;
    [MemberName("p")]
    protected GameFileManager p;
    [MemberName("q")]
    protected GameFileManager q;
    [MemberName("r")]
    protected JavaString[] _defaultResources = new JavaString[] { "win_small1.gif", "na_plate_waku.gif", "na_plate_name.gif", "intro_balloon.gif", "i_event4.gif" };

    [MemberName("W")]
    private bool W = false;
    [MemberName("X")]
    private bool X = true;
    [MemberName("Y")]
    private int Y = 0;
    [MemberName("Z")]
    private int Z = 0;
    [MemberName("aa")]
    private int _laytonAnimationIndex = -1;
    [MemberName("ab")]
    private int _lukeAnimationIndex = -1;

    [MemberName("s")]
    protected JavaString[] resourceFileNames;

    [MemberName("ac")]
    private int ac = 0;
    [MemberName("ad")]
    private bool ad = false;
    [MemberName("ae")]
    private bool ae = false;
    [MemberName("af")]
    private IScene _solutionInputControl = null;
    [MemberName("ag")]
    private bool ag = false;
    [MemberName("ah")]
    private ResourceBase _textBoxResource;
    [MemberName("ai")]
    private ResourceBase _textBoxTalkingResource;
    [MemberName("aj")]
    private ResourceBase _textNameBackgroundResource;
    [MemberName("ak")]
    private ResourceBase _textNameResource;
    [MemberName("al")]
    private ResourceBase _textContinueMarkerResource;
    [MemberName("am")]
    private ResourceBase _textContinueMarkerResource2;
    [MemberName("an")]
    private ResourceBase _textContinueMarkerResource3;
    [MemberName("ao")]
    private int ao = 0;
    [MemberName("ap")]
    private bool ap = false;

    [ConstructorName("t")]
    private EventScene()
    {
    }

    [FunctionName("a")]
    public static EventScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext GameContext)
    {
        ScreenResource screen = GameContext.ScreenResource;

        _laytonAnimationIndex = -1;
        _lukeAnimationIndex = -1;
        ag = false;
        _animatedImageCount = 0;
        O = new int[16];
        P = new int[16];
        Q = new int[16];
        R = new int[16];
        S = new int[16];
        T = new int[16];
        U = new ResourceBase[16];

        SetState(3);

        GameContext.b1(3);
        if (_defaultFileManager.LoadFiles(_defaultResources))
        {
            JavaString[] var3;
            (var3 = new JavaString[1])[0] = "event_" + Helper.ToStringPad(GameContext.RoomData.GetEventId(), 3) + ".dat";
            if (GameContext.EventId != GameContext.RoomData.GetEventId())
            {
                if (_scriptFileManager != null)
                {
                    _scriptFileManager.Reset();
                }

                if (!_scriptFileManager.LoadFiles(var3))
                {
                    return;
                }

                GameContext.EventId = GameContext.RoomData.GetEventId();
                X = false;
            }

            _scriptData = _scriptFileManager.GetLoadedData(var3[0]);
            _scriptOffset = 0;

            _upCursorResource2 = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            screen.AddChild(_upCursorResource2, 0, 0);

            _blackBackgroundResource = RectangleResource.Create(240, 240, RectangleResource.RECT_FILL, 0, 0, 0, 0);
            screen.AddChild(_blackBackgroundResource, 0, 0);

            _textContinueMarkerResource = ImageResource.Create(_defaultFileManager.GetLoadedImage("i_event4.gif"));
            ((ImageResource)_textContinueMarkerResource).b1(0, 0, 14, 14);

            _textContinueMarkerResource2 = ImageResource.Create(_defaultFileManager.GetLoadedImage("i_event4.gif"));
            ((ImageResource)_textContinueMarkerResource2).b1(0, 0, 14, 14);
            _textContinueMarkerResource2.SetIsVisible(false);

            _textContinueMarkerResource3 = ImageResource.Create(_defaultFileManager.GetLoadedImage("i_event4.gif"));
            ((ImageResource)_textContinueMarkerResource3).b1(0, 0, 14, 14);
            _textContinueMarkerResource3.SetIsVisible(false);

            _textWindowResource = ImageResource.Create(_defaultFileManager.GetLoadedImage("win_small1.gif"));
            screen.AddChild(_textWindowResource, (240 - _textWindowResource.GetWidth()) / 2, (192 - _textWindowResource.GetHeight()) / 2);

            _addedPuzzleTextResource = TextResource.Create("がナゾ辞典に追加された！");
            e[0] = TextResource.Create("");
            e[1] = TextResource.Create("");

            _upCursorResource = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            _upCursorResource.SetIsVisible(false);

            _yesSelectedBtnResources = new ResourceBase[2];
            _yesSelectedBtnResources[0] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
            _yesSelectedBtnResources[1] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
            _textWindowResource.AddChild(_yesSelectedBtnResources[0], 20, 60);
            _textWindowResource.AddChild(_yesSelectedBtnResources[1], 140, 60);
            _yesSelectedBtnResources[0].SetIsVisible(false);
            _yesSelectedBtnResources[1].SetIsVisible(false);

            _rightCursorResource = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            ((ImageResource)_rightCursorResource).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);

            _textWindowResource.AddChild(_rightCursorResource, 7, 66);
            _rightCursorResource.SetIsVisible(false);
            ((TextResource)_addedPuzzleTextResource).SetAnchorType(ResourceBase.ANCHOR_CENTER);
            ((TextResource)e[0]).SetAnchorType(ResourceBase.ANCHOR_CENTER);
            ((TextResource)e[1]).SetAnchorType(ResourceBase.ANCHOR_CENTER);

            _textWindowResource.AddChild(e[0], _textWindowResource.GetWidth() / 2, 20);
            _textWindowResource.AddChild(e[1], _textWindowResource.GetWidth() / 2, 45);
            _textWindowResource.AddChild(_addedPuzzleTextResource, _textWindowResource.GetWidth() / 2, 70);
            _textWindowResource.AddChild(_upCursorResource, (_textWindowResource.GetWidth() - _upCursorResource.GetWidth()) / 2, 20);
            _textWindowResource.AddChild(_textContinueMarkerResource3, _textWindowResource.GetWidth() - _textContinueMarkerResource3.GetWidth() - 3, _textWindowResource.GetHeight() - _textContinueMarkerResource3.GetHeight() - 3);
            _textWindowResource.SetIsVisible(false);
            _textWindowResource.ExecuteFullTransition(0, 1);

            _textBoxResource = ImageResource.Create(_defaultFileManager.GetLoadedImage("intro_balloon.gif"));
            ((ImageResource)_textBoxResource).ClipRect(0, 0, 240, 64);

            _textBoxTalkingResource = ImageResource.Create(_defaultFileManager.GetLoadedImage("intro_balloon.gif"));
            ((ImageResource)_textBoxTalkingResource).ClipRect(0, 64, 240, 10);
            _textBoxResource.AddChild(_textBoxTalkingResource);

            _textNameBackgroundResource = ImageResource.Create(_defaultFileManager.GetLoadedImage("na_plate_waku.gif"));
            _textNameResource = ImageResource.Create(_defaultFileManager.GetLoadedImage("na_plate_name.gif"));
            ((ImageResource)_textNameResource).ClipRect(0, 0, 62, 14);

            _scriptText = ScriptTextResource.Create(" [end]");
            _textBoxResource.AddChild(_textNameBackgroundResource, 2, -7);
            _textBoxResource.AddChild(_scriptText, 18, 18);
            _textBoxResource.AddChild(_textNameResource, 2, -6);
            _textBoxResource.AddChild(_textContinueMarkerResource, _textBoxResource.GetWidth() - _textContinueMarkerResource.GetWidth() - 3, _textBoxResource.GetHeight() - _textContinueMarkerResource.GetHeight() - 3);
            _textContinueMarkerResource.SetIsVisible(false);
            _textBoxResource.ExecuteFullTransition(0, 1);
            screen.AddChild(_textBoxResource, 0, 176);
            scriptExecutor = new ScriptExecutor();
            screen.AddChild(_textContinueMarkerResource2, 353, 220);
            screen.a1(_textContinueMarkerResource2, 0);
        }
    }

    [FunctionName("a")]
    private void SetState(int var1)
    {
        _previousState = _state;
        _state = var1;
    }

    [FunctionName("b")]
    public bool Update(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        GameContext.b1(3);
        int var3;
        int var4;
        int var5;
        JavaString[] var10;
        JavaString var11;
        switch (_state)
        {
            case 2:
                ++M;
                if (M > ac)
                {
                    M = 0;
                    SetState(_previousState);
                }
                break;

            // Execute script
            case 3:
                if (_scriptOffset < _scriptData.Length)
                {
                    _scriptOffset = scriptExecutor.ExecuteNext(_scriptData, _scriptOffset, GameContext);

                    try
                    {
                        if (scriptExecutor.Identifier.Equals("ObjFadeIn") && (var3 = a1(scriptExecutor.CmdMetadata, scriptExecutor.w)) >= 0)
                        {
                            U[var3].ExecuteTransition(1, scriptExecutor.FrameCounter);
                        }

                        if (scriptExecutor.Identifier.Equals("ObjFadeOut") && (var3 = a1(scriptExecutor.CmdMetadata, scriptExecutor.w)) >= 0)
                        {
                            U[var3].ExecuteTransition(0, scriptExecutor.FrameCounter);
                        }

                        if (scriptExecutor.Identifier.Equals("SpFadeIn") && (var3 = b1(scriptExecutor.CmdMetadata)) >= 0)
                        {
                            U[var3].ExecuteFullTransition(1, scriptExecutor.FrameCounter);
                        }

                        if (scriptExecutor.Identifier.Equals("SpFadeOut") && (var3 = b1(scriptExecutor.CmdMetadata)) >= 0)
                        {
                            U[var3].ExecuteFullTransition(0, scriptExecutor.FrameCounter);
                        }

                        int[] var15;
                        if (scriptExecutor.Identifier.Equals("PluralIn") && scriptExecutor.O.Length > 0)
                        {
                            var15 = new int[scriptExecutor.O.Length];

                            for (var4 = 0; var4 < scriptExecutor.O.Length; ++var4)
                            {
                                var15[var4] = b1(scriptExecutor.O[var4]);
                                if (var15[var4] >= 0)
                                {
                                    U[var15[var4]].ExecuteFullTransition(1, scriptExecutor.FrameCounter);
                                }
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("PluralOut") && scriptExecutor.O.Length > 0)
                        {
                            var15 = new int[scriptExecutor.O.Length];

                            for (var4 = 0; var4 < scriptExecutor.O.Length; ++var4)
                            {
                                var15[var4] = b1(scriptExecutor.O[var4]);
                                if (var15[var4] >= 0)
                                {
                                    U[var15[var4]].ExecuteFullTransition(0, scriptExecutor.FrameCounter);
                                }
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("FadeIn"))
                        {
                            var2.ExecuteTransition(1, scriptExecutor.FrameCounter);
                            SetState(7);
                        }

                        if (scriptExecutor.Identifier.Equals("FadeOut"))
                        {
                            var2.ExecuteTransition(0, scriptExecutor.FrameCounter);
                            SetState(7);
                        }

                        if (scriptExecutor.Identifier.Equals("Wait"))
                        {
                            ac = scriptExecutor.FrameCounter;
                            SetState(2);
                        }

                        if (scriptExecutor.Identifier.Equals("KeyWait"))
                        {
                            SetState(8);
                        }

                        if (scriptExecutor.Identifier.Equals("Shake"))
                        {
                            D = _upCursorResource2.posX;
                            E = _upCursorResource2.posY;
                            ad = true;
                            if ((var3 = b1(scriptExecutor.CmdMetadata)) >= 0)
                            {
                                F = U[var3].posX;
                                G = U[var3].posY;
                                ae = true;
                            }

                            ac = scriptExecutor.FrameCounter;
                            SetState(6);
                        }

                        if (scriptExecutor.Identifier.Equals("ShakeBG"))
                        {
                            D = _upCursorResource2.posX;
                            E = _upCursorResource2.posY;
                            ad = true;
                            ac = scriptExecutor.FrameCounter;
                            SetState(6);
                        }

                        if (scriptExecutor.Identifier.Equals("ShakeSP"))
                        {
                            if ((var3 = b1(scriptExecutor.CmdMetadata)) >= 0)
                            {
                                F = U[var3].posX;
                                G = U[var3].posY;
                                ae = true;
                            }

                            ac = scriptExecutor.FrameCounter;
                            SetState(6);
                        }

                        if (scriptExecutor.Identifier.Equals("ShakeALL") && _animatedImageCount > 0)
                        {
                            H = new int[_animatedImageCount];
                            I = new int[_animatedImageCount];

                            for (var3 = 0; var3 < _animatedImageCount; ++var3)
                            {
                                H[var3] = U[var3].posX;
                                I[var3] = U[var3].posY;
                            }

                            ac = scriptExecutor.FrameCounter;
                            SetState(13);
                        }

                        if (scriptExecutor.Identifier.Equals("Vibe"))
                        {
                            PhoneManager.a1(scriptExecutor.FrameCounter);
                        }

                        byte[] var16;
                        if (scriptExecutor.Identifier.Equals("AddObject"))
                        {
                            if (a1(scriptExecutor.CmdMetadata, scriptExecutor.w) != -1)
                            {
                                var3 = a1(scriptExecutor.CmdMetadata, scriptExecutor.w);
                                P[var3] = scriptExecutor._posX;
                                Q[var3] = scriptExecutor._posY;
                                R[var3] = scriptExecutor.n;
                                T[var3] = scriptExecutor.x;
                                ((AnimatedImageResource)U[var3]).SetAnimationIndex(R[var3]);
                                if (scriptExecutor.x == 0)
                                {
                                    ((AnimatedImageResource)U[var3]).SetAnimationBehaviour(0);
                                }
                                else if (scriptExecutor.x == 1)
                                {
                                    ((AnimatedImageResource)U[var3]).SetAnimationBehaviour(1);
                                }
                                else
                                {
                                    ((AnimatedImageResource)U[var3]).SetAnimationBehaviour(2);
                                }

                                U[var3].SetPosition(P[var3], Q[var3]);
                            }
                            else
                            {
                                O[_animatedImageCount] = scriptExecutor.CmdMetadata;
                                P[_animatedImageCount] = scriptExecutor._posX;
                                Q[_animatedImageCount] = scriptExecutor._posY;
                                R[_animatedImageCount] = scriptExecutor.n;
                                S[_animatedImageCount] = scriptExecutor.w;
                                T[_animatedImageCount] = scriptExecutor.x;
                                var10 = null;
                                var11 = null;
                                if (scriptExecutor.CmdMetadata > 51 && scriptExecutor.CmdMetadata < 56)
                                {
                                    var11 = "bg_op" + Helper.ToStringPad(scriptExecutor.CmdMetadata - 51, 2) + ".dat";
                                }
                                else if (scriptExecutor.CmdMetadata == 50)
                                {
                                    var11 = "op_layton.dat";
                                }
                                else if (scriptExecutor.CmdMetadata == 51)
                                {
                                    var11 = "op_luke.dat";
                                }
                                else
                                {
                                    var11 = "c" + Helper.ToStringPad(scriptExecutor.CmdMetadata, 2) + ".dat";
                                }

                                if ((var16 = _scriptResourceFileManager.GetLoadedData(var11)) != null)
                                {
                                    i = CharacterResourceFile.Read(var16);
                                    U[_animatedImageCount] = i.GetAnimatedImage(S[_animatedImageCount]);
                                    ((AnimatedImageResource)U[_animatedImageCount]).SetAnimationIndex(scriptExecutor.n);
                                    if (scriptExecutor.x == 0)
                                    {
                                        ((AnimatedImageResource)U[_animatedImageCount]).SetAnimationBehaviour(0);
                                    }
                                    else if (scriptExecutor.x == 1)
                                    {
                                        ((AnimatedImageResource)U[_animatedImageCount]).SetAnimationBehaviour(1);
                                    }
                                    else
                                    {
                                        ((AnimatedImageResource)U[_animatedImageCount]).SetAnimationBehaviour(2);
                                    }

                                    var2.AddChild(U[_animatedImageCount], scriptExecutor._posX, scriptExecutor._posY);
                                }

                                ++_animatedImageCount;
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("AddSprite"))
                        {
                            if (b1(scriptExecutor.CmdMetadata) == -1)
                            {
                                O[_animatedImageCount] = scriptExecutor.CmdMetadata;
                                P[_animatedImageCount] = scriptExecutor._posX;
                                Q[_animatedImageCount] = scriptExecutor._posY;
                                R[_animatedImageCount] = scriptExecutor.n;
                                S[_animatedImageCount] = 0;
                                S[_animatedImageCount] = 0;
                                var10 = null;
                                var11 = "c" + Helper.ToStringPad(scriptExecutor.CmdMetadata, 2) + ".dat";
                                if (scriptExecutor.CmdMetadata == 50)
                                {
                                    var11 = "op_layton.dat";
                                    _laytonAnimationIndex = _animatedImageCount;
                                }

                                if (scriptExecutor.CmdMetadata == 51)
                                {
                                    var11 = "op_luke.dat";
                                    _lukeAnimationIndex = _animatedImageCount;
                                }

                                if ((var16 = _scriptResourceFileManager.GetLoadedData(var11)) != null)
                                {
                                    i = CharacterResourceFile.Read(var16);
                                    U[_animatedImageCount] = i.GetAnimatedImage(S[_animatedImageCount]);
                                    ((AnimatedImageResource)U[_animatedImageCount]).SetAnimationIndex(scriptExecutor.n);
                                    if (scriptExecutor.CmdMetadata != 50 && scriptExecutor.CmdMetadata != 51)
                                    {
                                        ((AnimatedImageResource)U[_animatedImageCount]).SetAnimationBehaviour(0);
                                        ((AnimatedImageResource)U[_animatedImageCount]).SetLastAnimationStep();
                                    }
                                    else
                                    {
                                        ((AnimatedImageResource)U[_animatedImageCount]).SetAnimationBehaviour(257);
                                    }

                                    var2.AddChild(U[_animatedImageCount], scriptExecutor._posX, scriptExecutor._posY);
                                }

                                ++_animatedImageCount;
                            }
                            else
                            {
                                var3 = b1(scriptExecutor.CmdMetadata);
                                P[var3] = scriptExecutor._posX;
                                Q[var3] = scriptExecutor._posY;
                                R[var3] = scriptExecutor.n;
                                T[var3] = 0;
                                Z = scriptExecutor.n;
                                ((AnimatedImageResource)U[var3]).SetAnimationIndex(scriptExecutor.n);
                                ((AnimatedImageResource)U[var3]).SetAnimationBehaviour(257);
                                U[var3].SetPosition(P[var3], Q[var3]);
                            }

                            if ((var3 = b1(scriptExecutor.CmdMetadata)) != -1)
                            {
                                U[var3].SetIsVisible(true);
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("ChangeAni"))
                        {
                            var3 = b1(scriptExecutor.CmdMetadata);
                            ((AnimatedImageResource)U[var3]).SetAnimationIndex(scriptExecutor.n);
                            ((AnimatedImageResource)U[var3]).SetAnimationBehaviour(257);
                        }

                        if (scriptExecutor.Identifier.Equals("reverseSP"))
                        {
                            var3 = b1(scriptExecutor.CmdMetadata);
                            var4 = ((AnimatedImageResource)U[var3]).GetFlipMode() == Graphics.FLIP_NONE ? Graphics.FLIP_HORIZONTAL : Graphics.FLIP_NONE;
                            ((AnimatedImageResource)U[var3]).SetFlipMode(var4);
                        }

                        if (scriptExecutor.Identifier.Equals("InfoWindow"))
                        {
                            K = scriptExecutor.n;
                            L = scriptExecutor.CmdMetadata;
                            if (K == 0)
                            {
                                if (!GameContext.SaveData.f1())
                                {
                                    break;
                                }

                                GameContext.SaveData.a1(false);
                            }

                            a1(K, L, GameContext);
                            if (ag)
                            {
                                GameContext.RoomData.SetEventId(100);
                                GameContext.RoomData.SetGameMode(1);
                                SetState(9);
                                var2.ExecuteTransition(0);
                                ag = false;
                                return true;
                            }

                            var2.a1(_textWindowResource, 0);
                            SetState(20);
                        }

                        if (scriptExecutor.Identifier.Equals("TextWindow"))
                        {
                            a1(scriptExecutor.n, scriptExecutor.CmdMetadata, scriptExecutor.v);
                            SetState(10);
                        }

                        if (scriptExecutor.Identifier.Equals("BGMask"))
                        {
                            ((RectangleResource)_blackBackgroundResource).SetColor(scriptExecutor.r, scriptExecutor.s, scriptExecutor.t, scriptExecutor.u);
                        }

                        if (scriptExecutor.Identifier.Equals("PlaySound"))
                        {
                            if (scriptExecutor.B)
                            {
                                AudioManager.a1(scriptExecutor.y, GameContext.FileManager.GetLoadedSound(scriptExecutor.SoundFile), 100);
                            }
                            else
                            {
                                AudioManager.PlaySound(scriptExecutor.y, GameContext.FileManager.GetLoadedSound(scriptExecutor.SoundFile), 100);
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("StopSound"))
                        {
                            AudioManager.StopSound(scriptExecutor.y);
                        }

                        if (scriptExecutor.Identifier.Equals("PlayRSound"))
                        {
                            if (scriptExecutor.B)
                            {
                                AudioManager.a1(scriptExecutor.y, _scriptResourceFileManager.GetLoadedSound(scriptExecutor.SoundFile), 100);
                            }
                            else
                            {
                                AudioManager.PlaySound(scriptExecutor.y, _scriptResourceFileManager.GetLoadedSound(scriptExecutor.SoundFile), 100);
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("PlayMovie"))
                        {
                            SetState(4);
                        }

                        if (scriptExecutor.Identifier.Equals("SetBG"))
                        {
                            ((ImageResource)_upCursorResource2).SetImage(_scriptResourceFileManager.GetLoadedImage(resourceFileNames[scriptExecutor.CmdMetadata]));
                            ((ImageResource)_upCursorResource2).SetFlipMode(Graphics.FLIP_NONE);
                            if (X && _animatedImageCount > 0 && _laytonAnimationIndex >= 0 && _lukeAnimationIndex >= 0)
                            {
                                U[_laytonAnimationIndex].SetIsVisible(false);
                                U[_lukeAnimationIndex].SetIsVisible(false);
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("reverseBG"))
                        {
                            if (((ImageResource)_upCursorResource2).GetFlipMode() == 0)
                            {
                                ((ImageResource)_upCursorResource2).SetFlipMode(Graphics.FLIP_HORIZONTAL);
                            }
                            else
                            {
                                ((ImageResource)_upCursorResource2).SetFlipMode(Graphics.FLIP_NONE);
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("LoadData"))
                        {
                            resourceFileNames = scriptExecutor.ResourceFileNames;
                            if (!_scriptResourceFileManager.LoadFiles(resourceFileNames))
                            {
                                return false;
                            }
                        }

                        if (scriptExecutor.Identifier.Equals("Choice"))
                        {
                            SetState(70);
                            C = 0;
                        }

                        if (scriptExecutor.Identifier.Equals("endChoice"))
                        {
                            SetState(75);
                            C = 0;
                        }

                        if (scriptExecutor.Identifier.Equals("EndScript"))
                        {
                            SetState(99);
                        }
                    }
                    catch (Exception var9)
                    {
                        var11 = "event_" + Helper.ToStringPad(GameContext.RoomData.GetEventId(), 3) + ".dat";
                        java.util.System.Out.Fatal(var9, "{0}\n[{1}]を実行中に例外発生:{2}", var11, scriptExecutor.Identifier, var9.Message);
                    }
                }
                else
                {
                    SetState(99);
                }
                break;

            case 4:
                SystemFileManager var13 = new SystemFileManager();

                try
                {
                    SoundFileManager var12 = new SoundFileManager();
                    com.nttdocomo.fs.File var14;
                    if ((var14 = var13.OpenFile(scriptExecutor.I)) == null)
                    {
                        var13.DeleteFile(scriptExecutor.I);
                        GameContext.SetCurrentScene(SdCardErrorScene.GetInstance());
                        return true;
                    }

                    var12.Play(var14);
                    SetState(3);
                    break;
                }
                catch (Exception var7)
                {
                    var13.DeleteFile(scriptExecutor.I);
                    GameContext.SetCurrentScene(SdCardErrorScene.GetInstance());
                    return true;
                }
            case 6:
                try
                {
                    var3 = b1(scriptExecutor.CmdMetadata);
                    if (a)
                    {
                        if (ad)
                        {
                            _upCursorResource2.SetPosition(D - 1, E - 1);
                        }

                        if (ae)
                        {
                            U[var3].SetPosition(F + 1, G + 1);
                        }
                    }
                    else
                    {
                        if (ad)
                        {
                            _upCursorResource2.SetPosition(D + 1, E + 1);
                        }

                        if (ae)
                        {
                            U[var3].SetPosition(F - 1, G - 1);
                        }
                    }

                    a = !a;
                    ++M;
                    if (M > ac)
                    {
                        M = 0;
                        if (ad)
                        {
                            _upCursorResource2.SetPosition(D, E);
                        }

                        if (ae)
                        {
                            U[var3].SetPosition(F, G);
                        }

                        ad = false;
                        ae = false;
                        SetState(_previousState);
                    }
                }
                catch (Exception var8)
                {
                }
                break;
            case 7:
                if (var2._transitionState == 2)
                {
                    SetState(3);
                }

                if (var2._transitionState == 0)
                {
                    SetState(3);
                }
                break;
            case 8:
                if (!_textContinueMarkerResource2.IsVisible())
                {
                    _textContinueMarkerResource2.SetIsVisible(true);
                    _textContinueMarkerResource2.ExecuteTransition(1);
                }

                if (_textContinueMarkerResource2._transitionState == 2)
                {
                    _textContinueMarkerResource2.SetIsVisible(false);
                    SetState(3);
                }

                if (_textContinueMarkerResource2._transitionState == 0 && GameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    _textContinueMarkerResource2.ExecuteTransition(0);
                }
                break;
            case 9:
                if (var2._transitionState == 2)
                {
                    SetState(99);
                }

                if (var2._transitionState == 0)
                {
                    SetState(99);
                }
                break;
            case 10:
                if (_textBoxResource._transitionState == 0)
                {
                    _textBoxResource.ExecuteFullTransition(1);
                    _textBoxResource.SetIsVisible(true);
                    var2.a1(_textBoxResource, 0);
                }
                else if (_textBoxResource._transitionState == 4)
                {
                    try
                    {
                        if (!X)
                        {
                            if ((var3 = b1(scriptExecutor.CmdMetadata)) >= 0)
                            {
                                ((AnimatedImageResource)U[var3]).SetAnimationBehaviour(257);
                            }

                            AudioManager.PlaySound(2, GameContext.FileManager.GetLoadedSound("se_041.mld"), 100);
                        }

                        _textContinueMarkerResource.SetIsVisible(false);
                        _textContinueMarkerResource.d1(0);
                    }
                    catch (Exception var6)
                    {
                    }

                    SetState(12);
                }
                break;
            case 11:
                if (_textBoxResource._transitionState == 0)
                {
                    _textBoxResource.ExecuteFullTransition(0);
                    _textContinueMarkerResource.SetIsVisible(false);
                    _textContinueMarkerResource.ExecuteTransition(0, 1);
                }
                else if (_textBoxResource._transitionState == 2)
                {
                    _textContinueMarkerResource.SetIsVisible(false);
                    SetState(3);
                }
                break;
            case 12:
                if (AudioManager.d1(3) != 1 && W)
                {
                    if (Z > 0 && Z % 2 != 0)
                    {
                        ((AnimatedImageResource)U[Y]).SetAnimationIndex(Z - 1);
                        ((AnimatedImageResource)U[Y]).SetAnimationBehaviour(257);
                    }

                    W = false;
                }

                if (_textContinueMarkerResource._transitionState == 2 && _textContinueMarkerResource.IsVisible())
                {
                    _textContinueMarkerResource.SetIsVisible(false);
                }

                if ((var10 = _scriptText.c()) != null)
                {
                    if (var10[0].Equals("KeyWait"))
                    {
                        if (!X)
                        {
                            if ((var4 = b1(scriptExecutor.CmdMetadata)) >= 0 && b1(scriptExecutor.CmdMetadata, ((AnimatedImageResource)U[var4]).GetAnimationIndex()))
                            {
                                ((AnimatedImageResource)U[var4]).SetAnimationBehaviour(0);
                                ((AnimatedImageResource)U[var4]).SetLastAnimationStep();
                            }

                            AudioManager.StopSound(2);
                        }

                        if (!_textContinueMarkerResource.IsVisible())
                        {
                            _textContinueMarkerResource.SetIsVisible(true);
                            _textContinueMarkerResource.ExecuteTransition(1);
                        }
                    }
                    else if (var10[0].Equals("ChangeAnime"))
                    {
                        var4 = int.Parse(var10[1]);
                        if ((var5 = b1(scriptExecutor.CmdMetadata)) >= 0)
                        {
                            ((AnimatedImageResource)U[var5]).SetAnimationIndex(var4);
                            ((AnimatedImageResource)U[var5]).SetAnimationBehaviour(257);
                        }

                        _scriptText.d();
                    }
                    else if (var10[0].Equals("ChangeLimitAnime"))
                    {
                        var4 = int.Parse(var10[1]);
                        if ((var5 = b1(scriptExecutor.CmdMetadata)) >= 0)
                        {
                            ((AnimatedImageResource)U[var5]).SetAnimationIndex(var4);
                            ((AnimatedImageResource)U[var5]).SetAnimationBehaviour(274);
                        }

                        _scriptText.d();
                    }
                    else if (var10[0].Equals("Vibe"))
                    {
                        PhoneManager.a1(int.Parse(var10[1]));
                        _scriptText.d();
                    }
                    else if (var10[0].Equals("Voice"))
                    {
                        var11 = var10[1];
                        if (W && Y != b1(scriptExecutor.CmdMetadata + 50) && Z > 0 && Z % 2 != 0)
                        {
                            ((AnimatedImageResource)U[Y]).SetAnimationIndex(Z - 1);
                            ((AnimatedImageResource)U[Y]).SetAnimationBehaviour(257);
                        }

                        AudioManager.PlaySound(3, _scriptResourceFileManager.GetLoadedSound(var11), 100);
                        _scriptText.d();
                        W = true;
                        Z = int.Parse(var10[2]);
                        if (Z >= 0)
                        {
                            Y = b1(scriptExecutor.CmdMetadata + 50);
                            ((AnimatedImageResource)U[Y]).SetAnimationIndex(Z);
                            ((AnimatedImageResource)U[Y]).SetAnimationBehaviour(257);
                        }
                    }
                }

                if (_scriptText.e1())
                {
                    if (!X)
                    {
                        if ((var5 = b1(scriptExecutor.CmdMetadata)) >= 0 && b1(scriptExecutor.CmdMetadata, ((AnimatedImageResource)U[var5]).GetAnimationIndex()))
                        {
                            ((AnimatedImageResource)U[var5]).SetAnimationBehaviour(0);
                            ((AnimatedImageResource)U[var5]).SetLastAnimationStep();
                        }

                        AudioManager.StopSound(2);
                    }

                    if (!_textContinueMarkerResource.IsVisible())
                    {
                        _textContinueMarkerResource.SetIsVisible(true);
                        _textContinueMarkerResource.ExecuteTransition(1);
                    }
                }

                if (GameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    if (_scriptText.d())
                    {
                        if (!X)
                        {
                            if ((var5 = b1(scriptExecutor.CmdMetadata)) >= 0)
                            {
                                if (b1())
                                {
                                    ((AnimatedImageResource)U[var5]).SetAnimationBehaviour(274);
                                }
                                else
                                {
                                    ((AnimatedImageResource)U[var5]).SetAnimationBehaviour(257);
                                }
                            }

                            AudioManager.PlaySound(2, GameContext.FileManager.GetLoadedSound("se_041.mld"), 100);
                        }

                        _textContinueMarkerResource.SetIsVisible(false);
                        _textContinueMarkerResource.ExecuteTransition(0, 1);
                    }
                    else
                    {
                        SetState(11);
                    }
                }
                break;
            case 13:
                if (a)
                {
                    for (var3 = 0; var3 < _animatedImageCount; ++var3)
                    {
                        U[var3].SetPosition(H[var3] + 1, I[var3] + 1);
                    }
                }
                else
                {
                    for (var3 = 0; var3 < _animatedImageCount; ++var3)
                    {
                        U[var3].SetPosition(H[var3] - 1, I[var3] - 1);
                    }
                }

                a = !a;
                ++M;
                if (M > ac)
                {
                    M = 0;

                    for (var3 = 0; var3 < _animatedImageCount; ++var3)
                    {
                        U[var3].SetPosition(H[var3], I[var3]);
                    }

                    SetState(_previousState);
                }
                break;
            case 20:
                if (_textWindowResource._transitionState == 0)
                {
                    _textWindowResource.ExecuteFullTransition(1);
                    _textWindowResource.SetIsVisible(true);
                }
                else if (_textWindowResource._transitionState == 4)
                {
                    if (K == 11)
                    {
                        AudioManager.PlaySound(2, _defaultFileManager.GetLoadedSound("se_034.mld"), 100);
                    }
                    else
                    {
                        AudioManager.PlaySound(2, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                    }

                    SetState(22);
                }
                break;
            case 21:
                if (_textWindowResource._transitionState == 0)
                {
                    _textWindowResource.ExecuteFullTransition(0);
                }
                else if (_textWindowResource._transitionState == 2)
                {
                    _textContinueMarkerResource3.SetIsVisible(false);
                    ((ImageResource)_upCursorResource).SetImage(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
                    if (p != null)
                    {
                        p.Reset();
                        p = null;
                    }

                    SetState(3);
                }
                break;
            case 22:
                if (K == 7)
                {
                    if (var2._transitionState == 0)
                    {
                        if (GameContext.IsKeyPressed(Display.KEY_MAIN))
                        {
                            if (_rightCursorResource.posX == 15)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                var2.ExecuteTransition(0);
                                _yesSelectedBtnResources[0].SetPosition(_yesSelectedBtnResources[0].posX + 2, _yesSelectedBtnResources[0].posY + 2);
                            }
                            else
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                                SetState(21);
                                _yesSelectedBtnResources[1].SetPosition(_yesSelectedBtnResources[1].posX + 2, _yesSelectedBtnResources[1].posY + 2);
                            }
                        }
                        else if (GameContext.IsKeyPressed(Display.KEY_LEFT))
                        {
                            if (_rightCursorResource.posX != 15)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }

                            ((ImageResource)_yesSelectedBtnResources[0]).SetImage(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
                            ((ImageResource)_yesSelectedBtnResources[1]).SetImage(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
                            _rightCursorResource.SetPosition(15, 50);
                        }
                        else if (GameContext.IsKeyPressed(Display.KEY_RIGHT))
                        {
                            if (_rightCursorResource.posX != 105)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }

                            ((ImageResource)_yesSelectedBtnResources[0]).SetImage(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
                            ((ImageResource)_yesSelectedBtnResources[1]).SetImage(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));
                            _rightCursorResource.SetPosition(105, 50);
                        }
                    }

                    if (var2._transitionState == 2)
                    {
                        GameContext.SetCurrentScene(SaveGameScene.GetInstance(2));
                    }
                }
                else if (K == 0)
                {
                    if (_textWindowResource._transitionState == 0 && GameContext.IsKeyPressed(Display.KEY_MAIN))
                    {
                        if (GameContext.SaveData.w1())
                        {
                            _textWindowResource.ExecuteFullTransition(0);
                        }
                        else
                        {
                            SetState(21);
                        }
                    }

                    if (_textWindowResource._transitionState == 2)
                    {
                        K = 9;
                        a1(K, L, GameContext);
                        SetState(20);
                    }
                }
                else if (GameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    SetState(21);
                }
                break;
            case 50:
                if (_resourceBase == null)
                {
                    _resourceBase = FormattedTextResource.a1(GameContext, 0, true, 0, true, "あなた自身の[br]名前を入れてください。[end]");
                    var2.AddChild(_resourceBase, 0, 0);
                    var2.ExecuteTransition(1);
                }
                else
                {
                    if (GameContext.IsKeyPressed(Display.KEY_UP))
                    {
                        ((FormattedTextResource)_resourceBase).a1(0);
                    }

                    if (GameContext.IsKeyPressed(Display.KEY_DOWN))
                    {
                        ((FormattedTextResource)_resourceBase).a1(1);
                    }

                    if (GameContext.IsKeyPressed(Display.KEY_LEFT))
                    {
                        ((FormattedTextResource)_resourceBase).a1(2);
                    }

                    if (GameContext.IsKeyPressed(Display.KEY_RIGHT))
                    {
                        ((FormattedTextResource)_resourceBase).a1(3);
                    }

                    if (GameContext.IsKeyPressed(Display.KEY_MAIN))
                    {
                        ((FormattedTextResource)_resourceBase).a1(4);
                    }

                    if (GameContext.IsKeyPressed(Display.KEY_FIVE))
                    {
                        ((FormattedTextResource)_resourceBase).a1(5);
                    }

                    if (GameContext.IsKeyPressed(Display.KEY_TWO))
                    {
                        ((FormattedTextResource)_resourceBase).a1(6);
                    }

                    if (!((FormattedTextResource)_resourceBase).d().Equals(""))
                    {
                        GameContext.SaveData.SetName(((FormattedTextResource)_resourceBase).d());
                        var2.ExecuteTransition(0);
                        ((FormattedTextResource)_resourceBase).c();
                    }

                    if (var2._transitionState == 2)
                    {
                        _resourceBase.SetIsVisible(false);
                        var2.RemoveChild(_resourceBase);
                        ((FormattedTextResource)_resourceBase).Reset();
                        _resourceBase = null;
                    }
                }
                break;
            case 70:
                e1(GameContext);
                break;
            case 75:
                if (var2._transitionState == 0)
                {
                    var2.ExecuteTransition(0);
                }

                if (var2._transitionState == 2)
                {
                    if (scriptExecutor.J == null)
                    {
                        _upCursorResource2.RemoveChild(z);
                        z = null;
                        _upCursorResource2.RemoveChild(A);
                        A = null;

                        for (var5 = 0; var5 < B.Length; ++var5)
                        {
                            _upCursorResource2.RemoveChild(B[var5]);
                            B[var5] = null;
                        }

                        q.Reset();
                        q = null;
                        ((ImageResource)_upCursorResource2).SetImage(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
                    }

                    SetState(3);
                    C = 0;
                }
                break;

            // Exit script
            case 99:
                ExitScript(GameContext);
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        TryReset(var1);
        ap = false;
    }

    [FunctionName("d")]
    private void ExitScript(GameContext var1)
    {
        switch (var1.RoomData.GetGameMode())
        {
            // Load room after script ends
            case 0:
                if (var1.ScreenResource._transitionState == 0)
                {
                    var1.ScreenResource.ExecuteTransition(0);
                    return;
                }

                if (var1.ScreenResource._transitionState == 2)
                {
                    var1.SetCurrentScene(RoomScene.GetInstance());
                    return;
                }
                break;

            // Load event after script ends
            case 1:
                var1.RoomData.SetPlayerState(0);
                var1.SetCurrentScene(GetInstance());
                return;

            // Load input control of set puzzle
            case 2:
                if (var1.ScreenResource._transitionState == 0)
                {
                    var1.ScreenResource.MarkVisible();
                    var1.ScreenResource.ExecuteTransition(0);
                    return;
                }

                if (var1.ScreenResource._transitionState == 2)
                {
                    if (var1.ScreenResource._visible)
                    {
                        TryReset(var1);
                        JavaString[] var2;
                        (var2 = new JavaString[2])[0] = "nazo.dat";
                        var2[1] = Helper.ToStringPad(var1.RoomData.GetQuestionId(), 3) + ".dat";
                        _gameFileManager = new GameFileManager();
                        if (!_gameFileManager.LoadFiles(var2))
                        {
                            return;
                        }

                        byte[] nazoData = _gameFileManager.GetLoadedData("nazo.dat");
                        byte[] puzzleData = _gameFileManager.GetLoadedData(Helper.ToStringPad(var1.RoomData.GetQuestionId(), 3) + ".dat");
                        _gameFileManager.Reset();
                        _gameFileManager = null;

                        _solutionInputControl = nazo.PuzzleManager.GetSolutionInputControl(var1.ScreenResource, nazoData, puzzleData, 0);
                        var1.SetCurrentScene(_solutionInputControl);
                        return;
                    }

                    var1.ScreenResource.SetVisible();
                }
                break;

            case 3:
                SetState(4);
                return;

            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            default:
                break;

            case 9:
                var1.SetCurrentScene(IngameMenuScene.GetInstance());
                return;

            case 10:
                var1.SetCurrentScene(MinigameScene.GetInstance());
                return;

            // Return to startup
            case 11:
                var1.SetCurrentScene(StartupScene.GetInstance(false));
                return;

            // Return to title screen
            case 12:
                var1.SetCurrentScene(TitleScene.GetInstance());
                break;
        }
    }

    [FunctionName("a")]
    private void a1(int var1, int var2, GameContext var3)
    {
        if (var1 == 10 && !var3.RoomData.GetBitFlag(0))
        {
            var3.RoomData.SetBitFlag(0);
            ag = true;
        }
        else
        {
            JavaString var4 = "";
            JavaString[] var5 = new JavaString[1];
            if (var1 == 1 || var1 == 2 || var1 == 3 || var1 == 4 || var1 == 5 || var1 == 6 || var1 == 10 || var1 == 12)
            {
                p = new GameFileManager();
                if (var1 == 1)
                {
                    var5[0] = "i_dog" + Helper.ToStringPad(var2 - 1, 2) + ".gif";
                }

                if (var1 == 2)
                {
                    var5[0] = "i_piece.gif";
                }

                if (var1 == 3 || var1 == 4)
                {
                    var5[0] = "i_house" + Helper.ToStringPad(var2, 2) + ".gif";
                }

                if (var1 == 5)
                {
                    var5[0] = "i_fish.gif";
                }

                if (var1 == 6)
                {
                    var5[0] = "i_clock.gif";
                }

                if (var1 == 10)
                {
                    var5[0] = "icon_memotuika.gif";
                }

                if (var1 == 12)
                {
                    int var6 = 0;
                    if (var2 == 0)
                    {
                        var5[0] = "p_key.gif";
                        var4 = "カギ";
                        var6 = 1 + var2;
                    }
                    else if (var2 < 4)
                    {
                        var5[0] = "p_hammer2.gif";
                        var4 = "ハンマー";
                        var6 = 1 + var2;
                    }
                    else if (var2 == 4)
                    {
                        var5[0] = "p_saya.gif";
                        var4 = "武器の鞘";
                        var6 = 5;
                    }
                    else if (var2 == 5)
                    {
                        var5[0] = "p_machine.gif";
                        var4 = "いれかえ装置";
                        var6 = 6;
                    }

                    var3.SaveData.k1(var6);
                }

                if (!p.LoadFiles(var5))
                {
                    return;
                }
            }

            ((TextResource)e[0]).SetText("");
            ((TextResource)e[1]).SetText("");
            ((TextResource)_addedPuzzleTextResource).SetText("");
            bool var7 = true;
            bool var8 = false;
            bool var9 = true;
            if (var1 == 0)
            {
                ((TextResource)e[0]).SetText("すいりメッセージが");
                e[0].SetPosition(_textWindowResource.GetWidth() / 2, 24);
                ((TextResource)_addedPuzzleTextResource).SetText("更新されました！");
                _addedPuzzleTextResource.SetPosition(_textWindowResource.GetWidth() / 2, 43);
                var7 = false;
            }

            if (var1 == 7)
            {
                ((TextResource)e[0]).SetText("これまでの経過を記録しますか？");
                e[0].SetPosition(_textWindowResource.GetWidth() / 2, 12);
                ((TextResource)_addedPuzzleTextResource).SetText("以前のデータは上書きされます。");
                _addedPuzzleTextResource.SetPosition(_textWindowResource.GetWidth() / 2, 12 + GameContext.Font.GetHeight() + 2);
                ((ImageResource)_yesSelectedBtnResources[0]).SetImage(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
                ((ImageResource)_yesSelectedBtnResources[1]).SetImage(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));
                _yesSelectedBtnResources[0].SetPosition(25, 44);
                _yesSelectedBtnResources[1].SetPosition(115, 44);
                _rightCursorResource.SetPosition(105, 50);
                var8 = true;
                var7 = false;
                var9 = false;
            }

            if (var1 == 9)
            {
                ((TextResource)e[0]).SetText("すべてのすいりメッセージが");
                e[0].SetPosition(_textWindowResource.GetWidth() / 2, 24);
                ((TextResource)e[1]).SetText("解きあかされました！");
                e[1].SetPosition(_textWindowResource.GetWidth() / 2, 43);
                var7 = false;
            }

            if (var1 == 12)
            {
                ((TextResource)_addedPuzzleTextResource).SetText(var4 + "を手に入れました。");
                _addedPuzzleTextResource.SetPosition(_textWindowResource.GetWidth() / 2, 50);
                ((ImageResource)_upCursorResource).SetImage(p.GetLoadedImage(var5[0]));
                _upCursorResource.SetPosition((_textWindowResource.GetWidth() - _upCursorResource.GetWidth()) / 2, 14);
            }

            _upCursorResource.SetIsVisible(var7);
            _yesSelectedBtnResources[0].SetIsVisible(var8);
            _yesSelectedBtnResources[1].SetIsVisible(var8);
            _rightCursorResource.SetIsVisible(var8);
            _textContinueMarkerResource3.SetIsVisible(var9);
            ((TextResource)_addedPuzzleTextResource).SetAnchorType(1);
            ((TextResource)e[0]).SetAnchorType(1);
            ((TextResource)e[1]).SetAnchorType(1);
        }
    }

    [FunctionName("a")]
    private void a1(int var1, int var2, JavaString var3)
    {
        if (var1 == 2)
        {
            _textBoxTalkingResource.SetIsVisible(false);
        }
        else
        {
            ((ImageResource)_textBoxTalkingResource).ClipRect(0, 74 - var1 * 10, 240, 10);
            _textBoxTalkingResource.SetIsVisible(true);
        }

        if (var2 >= 39)
        {
            _textNameBackgroundResource.SetIsVisible(false);
            _textNameResource.SetIsVisible(false);
        }
        else
        {
            _textNameBackgroundResource.SetIsVisible(true);
            _textNameResource.SetIsVisible(true);
            int var4 = var2 % 5;
            int var5 = var2 / 5;
            ((ImageResource)_textNameResource).ClipRect(var4 * 62, var5 * 14, 62, 14);
        }

        _scriptText.SetText(var3);
    }

    [FunctionName("b")]
    private int b1(int var1)
    {
        bool var2 = false;

        for (int var3 = 0; var3 < _animatedImageCount; ++var3)
        {
            if (O[var3] == var1)
            {
                return var3;
            }
        }

        return -1;
    }

    [FunctionName("a")]
    private int a1(int var1, int var2)
    {
        for (int var3 = 0; var3 < _animatedImageCount; ++var3)
        {
            if (O[var3] == var1 && S[var3] == var2)
            {
                return var3;
            }
        }

        return -1;
    }

    [FunctionName("e")]
    private void e1(GameContext var1)
    {
        int var4;
        if (C == 0)
        {
            if (q != null)
            {
                ((ImageResource)_upCursorResource2).SetImage(q.GetLoadedImage("bg_choice.jpg"));
                z.SetIsVisible(true);
                A.SetIsVisible(true);

                for (var4 = 0; var4 < B.Length; ++var4)
                {
                    B[var4].SetIsVisible(true);
                }
            }
            else
            {
                var1.RoomData.B1(scriptExecutor.LoadFileCount);
                JavaString[] var2 = new JavaString[] { "bg_choice.jpg" };
                q = new GameFileManager();
                if (!q.LoadFiles(var2))
                {
                    return;
                }

                ((ImageResource)_upCursorResource2).SetImage(q.GetLoadedImage("bg_choice.jpg"));
                ao = 0;
                if (scriptExecutor.LoadFileCount == 2)
                {
                    ao = 80;
                }
                else
                {
                    ao = 55;
                }

                z = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
                ((ImageResource)z).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
                _upCursorResource2.AddChild(z, 10, ao - 1);
                A = TextResource.Create(scriptExecutor.J);
                _upCursorResource2.AddChild(A, (_upCursorResource2.GetWidth() - A.GetWidth()) / 2, 15);
                B = new ResourceBase[scriptExecutor.LoadFileCount];

                for (int var3 = 0; var3 < scriptExecutor.LoadFileCount; ++var3)
                {
                    B[var3] = TextResource.Create(scriptExecutor.K[var3]);
                    _upCursorResource2.AddChild(B[var3], 23, ao + var3 * 50);
                }

                J = 0;
            }

            C = 1;
            var1.ScreenResource.ExecuteTransition(1);
        }

        if (var1.ScreenResource._transitionState == 0)
        {
            if (var1.IsKeyPressed(Display.KEY_MAIN))
            {
                AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                var1.RoomData.C1(J);
                var1.RoomData.D1(J);
                var1.ScreenResource.ExecuteTransition(0);
            }
            else if (var1.IsKeyPressed(Display.KEY_UP))
            {
                AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100);
                --J;
                if (J < 0)
                {
                    J = scriptExecutor.LoadFileCount - 1;
                }

                z.SetPosition(10, ao - 1 + J * 50);
            }
            else if (var1.IsKeyPressed(Display.KEY_DOWN))
            {
                AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100);
                ++J;
                if (J >= scriptExecutor.LoadFileCount)
                {
                    J = 0;
                }

                z.SetPosition(10, ao - 1 + J * 50);
            }

            for (var4 = 0; var4 < scriptExecutor.LoadFileCount; ++var4)
            {
                ((TextResource)B[var4]).SetTextColor(0, 0, 0);
                if (var1.RoomData.E1(var4) != 0)
                {
                    ((TextResource)B[var4]).SetTextColor(0, 255, 0);
                }

                if (var1.RoomData.GetBitFlag(18) && scriptExecutor.LoadFileCount == 2 && scriptExecutor.L != var4 + 1)
                {
                    ((TextResource)B[var4]).SetTextColor(0, 255, 0);
                }

                if (J == var4)
                {
                    ((TextResource)B[var4]).SetTextColor(255, 0, 0);
                }
            }
        }

        if (var1.ScreenResource._transitionState == 2)
        {
            z.SetIsVisible(false);
            A.SetIsVisible(false);

            for (var4 = 0; var4 < B.Length; ++var4)
            {
                B[var4].SetIsVisible(false);
            }

            SetState(3);
        }

    }

    [FunctionName("f")]
    private void TryReset(GameContext var1)
    {
        try
        {
            if (!ap)
            {
                ap = true;
                var1.ScreenResource.RemoveChild(_textContinueMarkerResource2);
                _textContinueMarkerResource2 = null;
                _textWindowResource.RemoveChild(_textContinueMarkerResource3);
                _textContinueMarkerResource3 = null;
                _textWindowResource.RemoveChild(_addedPuzzleTextResource);
                _addedPuzzleTextResource = null;
                int var2;
                if (e != null)
                {
                    for (var2 = 0; var2 < e.Length; ++var2)
                    {
                        _textWindowResource.RemoveChild(e[var2]);
                        e[var2] = null;
                    }
                }

                _textWindowResource.RemoveChild(_upCursorResource);
                _upCursorResource = null;
                _textWindowResource.RemoveChild(_rightCursorResource);
                _rightCursorResource = null;
                if (_yesSelectedBtnResources != null)
                {
                    for (var2 = 0; var2 < _yesSelectedBtnResources.Length; ++var2)
                    {
                        _textWindowResource.RemoveChild(_yesSelectedBtnResources[var2]);
                        _yesSelectedBtnResources[var2] = null;
                    }
                }

                var1.ScreenResource.RemoveChild(_textWindowResource);
                _textWindowResource = null;
                _textBoxResource.RemoveChild(_textBoxTalkingResource);
                _textBoxTalkingResource = null;
                _textBoxResource.RemoveChild(_textNameBackgroundResource);
                _textNameBackgroundResource = null;
                _textBoxResource.RemoveChild(_textNameResource);
                _textNameResource = null;
                _textBoxResource.RemoveChild(_textContinueMarkerResource);
                _textContinueMarkerResource = null;
                _textBoxResource.RemoveChild(_scriptText);
                _scriptText = null;
                var1.ScreenResource.RemoveChild(_textBoxResource);
                _textBoxResource = null;
                if (_resourceBase != null)
                {
                    var1.ScreenResource.RemoveChild(_resourceBase);
                    ((FormattedTextResource)_resourceBase).Reset();
                    _resourceBase = null;
                }

                _upCursorResource2.RemoveChild(z);
                z = null;
                _upCursorResource2.RemoveChild(A);
                A = null;
                if (B != null)
                {
                    for (var2 = 0; var2 < B.Length; ++var2)
                    {
                        _upCursorResource2.RemoveChild(B[var2]);
                        B[var2] = null;
                    }
                }

                if (i != null)
                {
                    i.Destroy();
                }

                for (var2 = 0; var2 < _animatedImageCount; ++var2)
                {
                    var1.ScreenResource.RemoveChild(U[var2]);
                    U[var2] = null;
                }

                _animatedImageCount = 0;
                O = null;
                P = null;
                Q = null;
                R = null;
                var1.ScreenResource.RemoveChild(_blackBackgroundResource);
                _blackBackgroundResource = null;
                var1.ScreenResource.RemoveChild(_upCursorResource2);
                _upCursorResource2 = null;
                _defaultFileManager.Reset();
                _scriptResourceFileManager.Reset();
                if (p != null)
                {
                    p.Reset();
                    p = null;
                }

                if (q != null)
                {
                    q.Reset();
                    q = null;
                }
            }
        }
        catch (Exception var3)
        {
            java.util.System.Out.Fatal(var3, "イベントの解放で例外発生:{0}",var3.Message);
        }
    }

    [FunctionName("b")]
    private static bool b1(int var0, int var1)
    {
        bool var2 = true;
        switch (var0)
        {
            case 2:
                if (var1 == 10)
                {
                    var2 = false;
                }

                goto default;
            default:
                return var2;
        }
    }

    [FunctionName("b")]
    private static bool b1()
    {
        return false;
    }
}
