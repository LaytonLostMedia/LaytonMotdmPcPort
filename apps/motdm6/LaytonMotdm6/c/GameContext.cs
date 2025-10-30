using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm6.c.Managers;
using LaytonMotdm6.c.Resources;
using LaytonMotdm6.c.Storage;
using LaytonMotdm6.data;
using LaytonMotdm6.scene;

namespace LaytonMotdm6.c;

[ClassName("c", "y")]
public class GameContext : Canvas, ISystemMessageStorage
{
    [MemberName("p")]
    private int _pressedKeyBuffer = 0;
    [MemberName("q")]
    private int _keypadState;
    [MemberName("r")]
    private int _pressedKeys;
    [MemberName("s")]
    private int s;

    [MemberName("a")]
    public Graphics ScreenGraphics;

    [MemberName("b")]
    public static Font Font = Font.GetFont(0x70000400);

    [MemberName("c")]
    public ScreenResource ScreenResource = new(240, 240);

    [MemberName("t")]
    private int[] t;

    [MemberName("d")]
    public static int FontAscent = Font.GetAscent();

    [MemberName("u")]
    private int u;
    [MemberName("v")]
    private bool v;
    [MemberName("w")]
    private IScene _previousScene;
    [MemberName("x")]
    private IScene _scene;

    [MemberName("y")]
    private static GameContext? Instance;

    [MemberName("e")]
    public static int RoomId;
    [MemberName("f")]
    public static int RoomEventId;
    [MemberName("g")]
    public static int EventId;

    [MemberName("z")]
    private bool z = false;

    [MemberName("A")]
    private int _gameId = 2040;
    [MemberName("B")]
    private int _gameVersion = 1000;

    [MemberName("h")]
    public SaveData SaveData;
    [MemberName("i")]
    public RoomData RoomData;

    [MemberName("j")]
    public static GameFileManager FileManager;

    [MemberName("k")]
    private long _lastPressedKeyTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

    [MemberName("l")]
    public GameFileManager ScriptFileManager;
    [MemberName("m")]
    public GameFileManager ScriptResourceFileManager;

    [MemberName("C")]
    private ResourceBase[] C = new ResourceBase[4];
    [MemberName("D")]
    private ResourceBase _soundToggledIconResource = null;

    [MemberName("E")]
    private int _soundToggledIconFrameCount = 0;

    [MemberName("n")]
    private int n = 0;

    [MemberName("F")]
    private TextSelectionResource F = null;

    [FunctionName("a")]
    public static GameContext GetInstance()
    {
        return Instance ??= new GameContext();
    }

    [FunctionName("b")]
    public static int b1()
    {
        return ScratchPadManager.Read(1, 1)[0];
    }

    [FunctionName("a")]
    public static void a1(int paramInt)
    {
        if (paramInt == 0)
            return;
        if (paramInt == (GameFileManager.GetBaseDirectories()).Length)
        {
            ScratchPadManager.Write(1, (byte)paramInt);
            return;
        }
        ScratchPadManager.Write(1, (byte)1);
    }

    [ConstructorName("y")]
    private GameContext()
    {
        ScreenGraphics = GetGraphics();
        ScreenGraphics.SetFont(Font);
    }

    [FunctionName("b")]
    public void b1(int paramInt) { }

    [FunctionName("paint")]
    public void paint(Graphics paramGraphics)
    {
        if (DownloadManager.a1())
            return;
    }

    [FunctionName("processEvent")]
    protected override void processEvent(int eventType, int eventArg)
    {
        if (DownloadManager.b1())
            return;

        if (eventType == Display.EVENT_KEY_PRESSED)
            _pressedKeyBuffer |= 1 << eventArg;
    }

    [FunctionName("m")]
    private void UpdateFrame()
    {
        _pressedKeys = _pressedKeyBuffer;
        _pressedKeyBuffer = 0;
        _keypadState = GetKeypadState();
        if (_keypadState == 0)
        {
            s = 0;
            return;
        }
        if (s < 16)
            s++;
        if (_keypadState != 0 || _pressedKeys != 0)
        {
            PhoneSystem.SetAttribute(0, 1);
            _lastPressedKeyTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }

    [FunctionName("c")]
    public void Start()
    {
        long l = 0L;
        IScene x1 = null;
        Display.SetCurrent(this);
        FileManager = new GameFileManager();
        if (b1() == 0)
        {
            RoomData.L1();
            RoomData.G1(3);
            a1(1);
        }
        else
        {
            RoomData.K1();
        }
        PhoneSystem.SetAttribute(0, 1);
        SetCurrentScene(StartupScene.GetInstance(true));
        u = 0;
        v = true;
        ResetPressedKeys();
        SaveData = new SaveData();
        this.RoomData = new RoomData();
        SaveData.j1();
        while (true)
        {
            SaveData.k1();
            long l1 = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            PhoneSystem.GetAttribute(2);
            PhoneSystem.GetAttribute(9);
            do
            {
                UpdateFrame();

                // Disable/Enable sound icon and logic
                if (_soundToggledIconResource != null)
                {
                    if (IsKeyPressed(Display.KEY_FUNCTION))
                    {
                        int i;
                        if ((i = AudioManager.d1()) == 0)
                        {
                            ((ImageResource)_soundToggledIconResource).SetImage(FileManager.GetLoadedImage("syouon0.gif"));
                        }
                        else
                        {
                            ((ImageResource)_soundToggledIconResource).SetImage(FileManager.GetLoadedImage("syouon1.gif"));
                        }

                        ScreenResource.a1(_soundToggledIconResource, 0);
                        _soundToggledIconResource.SetIsVisible(true);
                        _soundToggledIconFrameCount = 0;
                        ScreenResource.AddChild(_soundToggledIconResource, 240, 208);
                    }

                    if (_soundToggledIconResource.IsVisible())
                    {
                        _soundToggledIconFrameCount++;
                        if (_soundToggledIconFrameCount > 20)
                        {
                            _soundToggledIconFrameCount = 0;
                            _soundToggledIconResource.SetIsVisible(false);
                        }

                        int i;
                        if ((i = AudioManager.c1()) == 0)
                        {
                            ((ImageResource)_soundToggledIconResource).SetImage(FileManager.GetLoadedImage("syouon0.gif"));
                        }
                        else
                        {
                            ((ImageResource)_soundToggledIconResource).SetImage(FileManager.GetLoadedImage("syouon1.gif"));
                        }
                    }
                }

                a1(this.RoomData);

                if (_previousScene != null)
                {
                    x1 = a1(x1, _previousScene);
                    _previousScene = null;
                    if (_scene != null)
                    {
                        x1 = a1(x1, _scene);
                        _scene = null;
                    }
                    v = false;
                    break;
                }
            } while (!x1.Update(this));

            PhoneManager.a1();

            ScreenGraphics.Lock();
            if (t != null)
            {
                t = null;
                //System.gc();
            }

            ScreenGraphics.ClearRect(0, 0, GetWidth(), GetHeight());

            ScreenResource.Paint(ScreenGraphics);

            //System.gc();
            ScreenGraphics.Unlock(true);

            // CUSTOM: Propagate finished frame rendering
            RaiseFrameCompleted(true);

            do
            {
                try
                {
                    Task.Delay(1).Wait();
                }
                catch (Exception throwable) { }
            } while ((l = DateTimeOffset.Now.ToUnixTimeMilliseconds() - l1) >= 0L && l < 50L);
            if (v && l >= 0L && l <= 500L)
            {
                u = (int)l;
            }
            else
            {
                u = 50;
                v = true;
            }
            if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - _lastPressedKeyTime >= 29900L)
            {
                _lastPressedKeyTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                PhoneSystem.SetAttribute(0, 0);
            }
        }
    }

    [FunctionName("a")]
    public void SetCurrentScene(IScene scene)
    {
        if (_previousScene != null)
        {
            _scene = scene;
            return;
        }
        _previousScene = scene;
    }

    [FunctionName("a")]
    private IScene a1(IScene paramx1, IScene paramx2)
    {
        if (paramx1 != null)
        {
            try
            {
                paramx1.Reset(this);
            }
            catch (Exception throwable)
            {
                java.util.System.Out.Fatal(throwable, "解放処理で例外発生");
            }
            //System.gc();
        }
        paramx2.Setup(this);
        return paramx2;
    }

    [FunctionName("d")]
    public int d1()
    {
        return u;
    }

    [FunctionName("e")]
    public void ResetPressedKeys()
    {
        _pressedKeyBuffer = 0;
        _keypadState = 0;
        _pressedKeys = 0;
        s = 0;
    }

    [FunctionName("c")]
    public bool IsKeyPadPressed(int key)
    {
        return (_keypadState & key) != 0;
    }

    [FunctionName("d")]
    public bool IsKeyPressed(int keyValue)
    {
        return (_pressedKeys & keyValue) != 0;
    }

    [FunctionName("a")]
    public int MoveCursor(int elementId, int[] elementRanksX, int[] elementRanksY, bool paramBoolean)
    {
        return MoveCursor(elementRanksX[elementId], elementRanksY[elementId], elementRanksX, elementRanksY, paramBoolean);
    }

    [FunctionName("a")]
    public int MoveCursor(int elementRankX, int elementRankY, int[] elementRanksX, int[] elementRanksY, bool paramBoolean)
    {
        sbyte rankXOffset = 0;
        sbyte rankYOffset = 0;
        if ((_pressedKeys & Display.KEY_UP) != 0)
        {
            rankYOffset = -1;
        }
        else if ((_pressedKeys & Display.KEY_DOWN) != 0)
        {
            rankYOffset = 1;
        }
        else if ((_pressedKeys & Display.KEY_LEFT) != 0)
        {
            rankXOffset = -1;
        }
        else if ((_pressedKeys & Display.KEY_RIGHT) != 0)
        {
            rankXOffset = 1;
        }
        else
        {
            return -1;
        }
        java.util.System.Out.Debug("移動先：");
        int i = rankXOffset;
        int j = rankYOffset;
        int k = a1(elementRankX + i, elementRankY + j, elementRanksX, elementRanksY);
        sbyte b3 = 0;
        int n = 0;
        while (k == -1 && n < 4)
        {
            i = rankXOffset + rankXOffset * n;
            j = rankYOffset + rankYOffset * n;
            switch (b3)
            {
                case 0:
                    i += rankXOffset;
                    j += rankYOffset;
                    break;
                case 1:
                    if (rankXOffset != 0)
                    {
                        j = rankXOffset;
                        break;
                    }
                    if (rankYOffset != 0)
                        i = rankYOffset;
                    break;
                case 2:
                    if (rankXOffset != 0)
                    {
                        j = rankXOffset * -1;
                    }
                    else if (rankYOffset != 0)
                    {
                        i = rankYOffset * -1;
                    }
                    n++;
                    b3 = -1;
                    break;
            }
            k = a1(elementRankX + i, elementRankY + j, elementRanksX, elementRanksY);
            b3++;
        }
        if (k == -1 && paramBoolean)
        {
            int i1;
            byte b4;
            switch (rankXOffset)
            {
                case -1:
                    n = elementRankX;
                    for (i1 = 0; i1 < elementRanksX.Length; i1++)
                    {
                        if (elementRanksX[i1] > n)
                            n = elementRanksX[i1];
                    }
                    k = a1(n, elementRankY, elementRanksX, elementRanksY);
                    break;
                case 1:
                    i1 = elementRankX;
                    for (b4 = 0; b4 < elementRanksX.Length; b4++)
                    {
                        if (elementRanksX[b4] < i1)
                            i1 = elementRanksX[b4];
                    }
                    k = a1(i1, elementRankY, elementRanksX, elementRanksY);
                    break;
            }
            switch (rankYOffset)
            {
                case -1:
                    n = elementRankY;
                    for (i1 = 0; i1 < elementRanksY.Length; i1++)
                    {
                        if (elementRanksY[i1] > n)
                            n = elementRanksY[i1];
                    }
                    k = a1(elementRankX, n, elementRanksX, elementRanksY);
                    break;
                case 1:
                    i1 = elementRankY;
                    for (b4 = 0; b4 < elementRanksY.Length; b4++)
                    {
                        if (elementRanksY[b4] < i1)
                            i1 = elementRanksY[b4];
                    }
                    k = a1(elementRankX, i1, elementRanksX, elementRanksY);
                    break;
            }
        }
        if (k != -1 && elementRanksX[k] == elementRankX && elementRanksY[k] == elementRankY)
            k = -1;
        return k;
    }

    [FunctionName("a")]
    public static void a1(ImageResource paramb, int basePosX, int basePosY, int paramInt3)
    {
        int i = paramInt3 % 20;
        int j = 0;
        int k = 0;
        if (i < 13)
        {
            j = 5;
        }
        else if (i < 17)
        {
            j = -(i - 12);
        }
        else if (i < 21)
        {
            j = -4;
        }
        switch (paramb.GetFlipMode())
        {
            case 5:
                j *= -1;
                break;
            case 0:
                k = j;
                j = 0;
                break;
            case 2:
                k = j * -1;
                j = 0;
                break;
        }
        paramb.SetPosition(basePosX + j, basePosY + k);
    }

    [FunctionName("a")]
    private static int a1(int paramInt1, int paramInt2, int[] paramArrayOfint1, int[] paramArrayOfint2)
    {
        for (byte b1 = 0; b1 < paramArrayOfint2.Length; b1++)
        {
            if (paramArrayOfint2[b1] == paramInt2 && paramArrayOfint1[b1] == paramInt1)
                return b1;
        }
        return -1;
    }

    [FunctionName("f")]
    public int f1()
    {
        return _pressedKeys;
    }

    [FunctionName("g")]
    public void Resume()
    {
        AudioManager.b1();
        ResetPressedKeys();
        _pressedKeyBuffer = 32768;
        PhoneSystem.SetAttribute(0, 1);
        _lastPressedKeyTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        //System.gc();
    }

    [FunctionName("h")]
    public void h1()
    {
        if (!FileManager.LoadFiles(StandardFileStorage.FileNames))
            return;

        n1();
        _soundToggledIconResource = ImageResource.Create(FileManager.GetLoadedImage("syouon0.gif"));
        ((ImageResource)_soundToggledIconResource).SetAnchorType(ResourceBase.ANCHOR_RIGHT);
        _soundToggledIconResource.SetIsVisible(false);
        ScreenResource.AddChild(_soundToggledIconResource, 240, 208);
    }

    [FunctionName("i")]
    public void Reset()
    {
        RoomId = -1;
        RoomEventId = -1;
        EventId = -1;

        ScriptFileManager = new GameFileManager();
        ScriptResourceFileManager = new GameFileManager();

        SaveData.Reset();
        RoomData.Reset();
    }

    [FunctionName("n")]
    private void n1()
    {
        b1(2);
    }

    [FunctionName("processIMEEvent")]
    public void processIMEEvent(int paramInt, JavaString paramString)
    {
        if (paramInt == 0)
        {
            n++;
            if (paramString == null || paramString == "")
                return;
            try
            {
                int.Parse(paramString);
                return;
            }
            catch (Exception exception) { }
        }
    }

    [FunctionName("j")]
    public void j1()
    {
        if (F != null)
        {
            ScreenResource.RemoveChild(F);
            F.c1();
            F = null;
        }
    }

    [FunctionName("e")]
    public JavaString ShowSystemMessage(int msgId)
    {
        if (F == null)
        {
            F = TextSelectionResource.Create(ISystemMessageStorage.Messages[msgId - 1][0], ISystemMessageStorage.Messages[msgId - 1][1], ISystemMessageStorage.Messages[msgId - 1][2]);
            ScreenResource.AddChild(F);
        }
        return F.GetActiveText(this);
    }

    [FunctionName("a")]
    private void a1(RoomData parama)
    {
        if (parama.l1() == 0)
            if (PhoneSystem.GetAttribute(2) == 0)
            {
                if (parama.a1() == 1)
                    z = true;
            }
            else if (z)
            {
                parama.a1(2);
                z = false;
            }
        if (parama.l1() == 2 && parama.a1() == 1 && DateTimeOffset.Now.ToUnixTimeMilliseconds() - parama.b1() >= 29900L)
        {
            parama.a1(0L);
            parama.a1(2);
        }
    }

    [FunctionName("k")]
    public int GetGameId()
    {
        return _gameId;
    }

    [FunctionName("f")]
    public void SetGameId(int paramInt)
    {
        _gameId = paramInt;
    }

    [FunctionName("l")]
    public int GetGameVersion()
    {
        return _gameVersion;
    }

    [FunctionName("g")]
    public void SetGameVersion(int paramInt)
    {
        _gameVersion = paramInt;
    }
}
