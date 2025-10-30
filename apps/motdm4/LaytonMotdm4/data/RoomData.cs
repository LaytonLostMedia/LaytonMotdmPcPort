using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm4.c;
using LaytonMotdm4.c.Files;
using LaytonMotdm4.c.Managers;
using LaytonMotdm4.c.Resources;

namespace LaytonMotdm4.data;

[ClassName("data", "a")]
public class RoomData
{
    [MemberName("a")]
    public JavaString[] ResourceNames;

    [MemberName("b")]
    private CharacterResourceFile _bgOjResource;
    [MemberName("d")]
    private int d;
    [MemberName("e")]
    private long e = 0;
    [MemberName("f")]
    private int _isEntered;
    [MemberName("g")]
    private int _playerState;
    [MemberName("h")]
    private int _gameMode;
    [MemberName("i")]
    private int _memoIndex;

    [MemberName("j")]
    private int _exitCount;
    [MemberName("k")]
    private int[] _exitRoomIds = new int[8];
    [MemberName("l")]
    private int[] l = new int[8];
    [MemberName("m")]
    private int[] m = new int[8];
    [MemberName("n")]
    private int[][] _exitPositions = { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] };
    [MemberName("o")]
    private int[] o = new int[8];

    [MemberName("p")]
    private int _eventCount;
    [MemberName("q")]
    private int[] _eventTypes = new int[32];
    [MemberName("r")]
    private int[] _eventSpeakerIds = new int[32];
    [MemberName("s")]
    private int[,] _eventPositions = new int[32, 2];

    [MemberName("t")]
    public int[] EventTextIds = new int[32];
    [MemberName("u")]
    private int[] _eventRankX = new int[32];
    [MemberName("v")]
    private int[] _eventRankY = new int[32];
    [MemberName("w")]
    private int w;

    [MemberName("x")]
    private int _eventTextCount;
    [MemberName("y")]
    private JavaString[] _eventTexts = new JavaString[32];

    [MemberName("z")]
    private JavaString _backgroundName;
    [MemberName("A")]
    private bool _isBackgroundFlipped;

    [MemberName("B")]
    private int _backgroundObjectCount;
    [MemberName("C")]
    private int[] _backgroundObjectIds = new int[16];
    [MemberName("D")]
    private int[][] _backgroundObjectPositions = new int[][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] };
    [MemberName("E")]
    private int[] E = new int[16];
    [MemberName("F")]
    private bool[] _backgroundObjectFlipped = new bool[16];

    [MemberName("G")]
    private int _storyId;
    [MemberName("H")]
    private int[] _bitFlags = new int[128];
    [MemberName("I")]
    private int[] _eventStates = new int[512];
    [MemberName("J")]
    private int _eventId;
    [MemberName("K")]
    private int[] K = new int[32];
    [MemberName("L")]
    private int[] _questionBits = new int[256];
    [MemberName("M")]
    private int[] M = new int[256];
    [MemberName("N")]
    private int _questionId;
    [MemberName("O")]
    private int[] O = new int[2];

    [MemberName("P")]
    private int _potCount;
    [MemberName("Q")]
    private int[] _potId = new int[10];
    [MemberName("R")]
    private int[] R = new int[10];
    [MemberName("S")]
    private int[] S = new int[10];
    [MemberName("T")]
    private int[][] _potPos = new int[][] { new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2], new int[2] };
    [MemberName("U")]
    private int[] _potAmount = new int[10];
    [MemberName("V")]
    private int[] V = new int[10];
    [MemberName("W")]
    private bool W = true;
    [MemberName("c")]
    public JavaString[][] c;
    [MemberName("X")]
    private int X = 0;
    [MemberName("Y")]
    private int[] Y;
    [MemberName("Z")]
    private int Z;

    [FunctionName("a")]
    public void a1(int var1)
    {
        d = var1;
    }

    [FunctionName("a")]
    public int a1()
    {
        return d;
    }

    [FunctionName("a")]
    public void a1(long var1)
    {
        e = var1;
    }

    [FunctionName("b")]
    public long b1()
    {
        return e;
    }

    [FunctionName("b")]
    public void SetRoomEntered(int var1)
    {
        _isEntered = var1;
    }

    [FunctionName("c")]
    public bool IsRoomEntered()
    {
        return _isEntered == 1;
    }

    // 0: Is in event
    // 1: Is in puzzle
    [FunctionName("c")]
    public void SetPlayerState(int state)
    {
        _playerState = state;
    }

    // 0: Is in event
    // 1: Is in puzzle
    [FunctionName("d")]
    public bool IsPlayerState(int state)
    {
        return _playerState == state;
    }

    [FunctionName("e")]
    public void SetGameMode(int gameMode)
    {
        _gameMode = gameMode;
    }

    [FunctionName("d")]
    public int GetGameMode()
    {
        return _gameMode;
    }

    [FunctionName("e")]
    public void IncrementMemoIndex()
    {
        ++_memoIndex;
    }

    [FunctionName("a")]
    public bool EvaluateMemoIndex(int comparisonValue, int comparisonType)
    {
        bool var3 = false;
        if (comparisonType == 0)
        {
            var3 = _memoIndex == comparisonValue;
        }

        if (comparisonType == 1)
        {
            var3 = _memoIndex < comparisonValue;
        }

        if (comparisonType == 2)
        {
            var3 = _memoIndex > comparisonValue;
        }

        if (comparisonType == 3)
        {
            var3 = _memoIndex <= comparisonValue;
        }

        if (comparisonType == 4)
        {
            var3 = _memoIndex >= comparisonValue;
        }

        return var3;
    }

    [FunctionName("f")]
    public int f1()
    {
        return _memoIndex;
    }

    [ConstructorName("a")]
    public RoomData()
    {
    }

    [FunctionName("g")]
    public void ClearExits()
    {
        for (int i = 0; i < 8; ++i)
        {
            _exitRoomIds[i] = 0;
            l[i] = -1;
            m[i] = -1;
            _exitPositions[i][0] = _exitPositions[i][1] = 0;
            o[i] = 0;
        }

        _exitCount = 0;
    }

    [FunctionName("h")]
    public int GetExitCount()
    {
        return _exitCount;
    }

    [FunctionName("f")]
    public int GetRoomId(int exitIndex)
    {
        return _exitRoomIds[exitIndex];
    }

    [FunctionName("g")]
    public int[] GetExitPosition(int index)
    {
        return _exitPositions[index];
    }

    [FunctionName("i")]
    public int[] i1()
    {
        int[] var1 = new int[_exitCount];
        Array.Copy(l, 0, var1, 0, var1.Length);
        return var1;
    }

    [FunctionName("j")]
    public int[] j1()
    {
        int[] var1 = new int[_exitCount];
        Array.Copy(m, 0, var1, 0, var1.Length);
        return var1;
    }

    [FunctionName("h")]
    public int h1(int var1)
    {
        return o[var1];
    }

    [FunctionName("a")]
    public void AddExit(int var1, int var2, int var3, int x, int y, int var6)
    {
        if (_exitCount < 8)
        {
            _exitRoomIds[_exitCount] = var1;
            l[_exitCount] = var2;
            m[_exitCount] = var3;
            _exitPositions[_exitCount][0] = x;
            _exitPositions[_exitCount][1] = y;
            o[_exitCount] = var6;

            ++_exitCount;
        }
    }

    [FunctionName("k")]
    public void ClearEvents()
    {
        for (var i = 0; i < 32; ++i)
        {
            _eventTypes[i] = 0;
            _eventSpeakerIds[i] = 0;
            _eventPositions[i, 0] = _eventPositions[i, 1] = 0;
            EventTextIds[i] = 0;
            _eventRankX[i] = -1;
            _eventRankY[i] = -1;
            w = 0;
        }

        _eventCount = 0;
    }

    [FunctionName("a")]
    public void AddEvent(int eventType, int speakerId, int rankX, int rankY, int posX, int posY, int eventTextId, int _, int var9)
    {
        w = var9;
        AddEvent(eventType, speakerId, rankX, rankY, posX, posY, eventTextId);
    }

    [FunctionName("a")]
    public void AddEvent(int eventType, int speakerId, int rankX, int rankY, int posX, int posY, int eventTextId)
    {
        if (_eventCount < 32)
        {
            _eventTypes[_eventCount] = eventType;
            _eventSpeakerIds[_eventCount] = speakerId;
            _eventPositions[_eventCount, 0] = posX;
            _eventPositions[_eventCount, 1] = posY;
            EventTextIds[_eventCount] = eventTextId;
            _eventRankX[_eventCount] = rankX;
            _eventRankY[_eventCount] = rankY;
            ++_eventCount;
        }
    }

    [FunctionName("l")]
    public int l1()
    {
        return w;
    }

    [FunctionName("i")]
    public int GetEventType(int roomEventId)
    {
        return _eventTypes[roomEventId];
    }

    [FunctionName("j")]
    public int GetEventSpeakerId(int roomEventId)
    {
        return _eventSpeakerIds[roomEventId];
    }

    [FunctionName("m")]
    public int GetEventCount()
    {
        return _eventCount;
    }

    [FunctionName("k")]
    public int[] GetEventPosition(int roomEventId)
    {
        int[][] eventPositionsCopy = new int[_eventCount][];

        for (int i = 0; i < _eventCount; ++i)
        {
            eventPositionsCopy[i] = new int[2];
            eventPositionsCopy[i][0] = _eventPositions[i, 0] + 11;
            eventPositionsCopy[i][1] = _eventPositions[i, 1];
        }

        return eventPositionsCopy[roomEventId];
    }

    [FunctionName("l")]
    public int GetEventTextId(int var1)
    {
        return EventTextIds[var1];
    }

    [FunctionName("n")]
    public int[] GetEventRanksX()
    {
        int[] var1 = new int[_eventCount];
        Array.Copy(_eventRankX, 0, var1, 0, var1.Length);
        return var1;
    }

    [FunctionName("o")]
    public int[] GetEventRanksY()
    {
        int[] var1 = new int[_eventCount];
        Array.Copy(_eventRankY, 0, var1, 0, var1.Length);
        return var1;
    }

    [FunctionName("p")]
    public int[][] GetEventPositions()
    {
        int[][] eventCopy = new int[_eventCount][];

        for (int i = 0; i < _eventCount; ++i)
        {
            eventCopy[i] = new int[2];
            for (int p = 0; p < 2; ++p)
            {
                eventCopy[i][p] = _eventPositions[i, p];
            }
        }

        return eventCopy;
    }

    [FunctionName("a")]
    public int AddEventText(JavaString text)
    {
        if (_eventTextCount >= 32)
            return 0;

        _eventTexts[_eventTextCount++] = text;

        return _eventTextCount;
    }

    [FunctionName("q")]
    public void ClearEventTexts()
    {
        for (var i = 0; i < 32; ++i)
            _eventTexts[i] = JavaString.Empty;

        _eventTextCount = 0;
    }

    [FunctionName("m")]
    public JavaString m1(int var1)
    {
        return _eventTexts[var1];
    }

    [FunctionName("b")]
    public void SetBackground(JavaString var1)
    {
        _backgroundName = var1;
        _isBackgroundFlipped = false;
    }

    [FunctionName("r")]
    public JavaString GetBackground()
    {
        return _backgroundName;
    }

    [FunctionName("s")]
    public bool IsBackgroundFlipped()
    {
        return _isBackgroundFlipped;
    }

    [FunctionName("t")]
    public void ToggleBackgroundFlipped()
    {
        _isBackgroundFlipped = !_isBackgroundFlipped;
    }

    [FunctionName("u")]
    public void u1()
    {
        for (int var1 = 0; var1 < 16; ++var1)
        {
            _backgroundObjectIds[var1] = 0;
            E[var1] = 0;
            _backgroundObjectPositions[var1][0] = _backgroundObjectPositions[var1][1] = 0;
            _backgroundObjectFlipped[var1] = false;
        }

        _backgroundObjectCount = 0;
    }

    [FunctionName("v")]
    public int GetBackgroundObjectCount()
    {
        return _backgroundObjectCount;
    }

    [FunctionName("n")]
    public int[] GetBackgroundPosition(int id)
    {
        return _backgroundObjectPositions[id];
    }

    [FunctionName("a")]
    public void AddBackgroundObject(int id, int x, int y)
    {
        if (_backgroundObjectCount < 16)
        {
            _backgroundObjectIds[_backgroundObjectCount] = id;
            _backgroundObjectPositions[_backgroundObjectCount][0] = x;
            _backgroundObjectPositions[_backgroundObjectCount][1] = y;
            _backgroundObjectFlipped[_backgroundObjectCount] = false;

            ++_backgroundObjectCount;
        }
    }

    [FunctionName("o")]
    public void ToggleBackgroundObjectFlipped(int var1)
    {
        _backgroundObjectFlipped[var1] = !_backgroundObjectFlipped[var1];
    }

    [FunctionName("p")]
    public bool IsBackgroundObjectFlipped(int var1)
    {
        return _backgroundObjectFlipped[var1];
    }

    [FunctionName("a")]
    public ResourceBase[] a1(GameFileManager var1, JavaString var2)
    {
        if (_bgOjResource == null)
        {
            byte[] var3 = var1.GetLoadedData(var2);
            _bgOjResource = CharacterResourceFile.Read(var3);
        }

        ResourceBase[] var7 = new ResourceBase[_backgroundObjectCount];

        for (int var4 = 0; var4 < _backgroundObjectCount; ++var4)
        {
            try
            {
                var7[var4] = _bgOjResource.GetAnimatedImage(_backgroundObjectIds[var4]);
            }
            catch (Exception var6)
            {
            }
        }

        return var7;
    }

    [FunctionName("w")]
    public void w1()
    {
        if (_bgOjResource != null)
        {
            _bgOjResource.Destroy();
            _bgOjResource = null;
        }
    }

    [FunctionName("q")]
    public void SetStoryId(int id)
    {
        _storyId = id;
    }

    [FunctionName("x")]
    public int GetStoryId()
    {
        return _storyId;
    }

    [FunctionName("r")]
    public bool IsStoryId(int id)
    {
        return _storyId == id;
    }

    [FunctionName("s")]
    public void SetBitFlag(int var1)
    {
        ToggleBitFlag(var1, true);
    }

    [FunctionName("a")]
    public void ToggleBitFlag(int var1, bool shouldSet)
    {
        int var3 = var1 % 8;
        int[] var10000;
        if (shouldSet)
        {
            var10000 = _bitFlags;
            var10000[var1 / 8] |= 1 << var3;
        }
        else
        {
            var10000 = _bitFlags;
            var10000[var1 / 8] &= ~(1 << var3);
        }
    }

    [FunctionName("t")]
    public bool GetBitFlag(int var1)
    {
        int var2 = _bitFlags[var1 / 8];
        int var3 = var1 % 8;
        return (var2 & 1 << var3) != 0;
    }

    [FunctionName("y")]
    public int[] y1()
    {
        return _bitFlags;
    }

    [FunctionName("u")]
    public void SetEventId(int id)
    {
        _eventId = id;
    }

    [FunctionName("z")]
    public int GetEventId()
    {
        return _eventId;
    }

    [FunctionName("b")]
    public void SetEventState(int eventId, int bitIndex)
    {
        int[] var10000 = _eventStates;
        var10000[eventId] |= bitIndex & 255;
    }

    [FunctionName("c")]
    public bool GetEventState(int eventId, int bitIndex)
    {
        return (_eventStates[eventId] & bitIndex) != 0;
    }

    [FunctionName("A")]
    public int[] GetEventStates()
    {
        return _eventStates;
    }

    [FunctionName("v")]
    public bool v1(int var1)
    {
        int var2 = K[var1 / 8];
        int var3 = var1 % 8;
        return (var2 & 1 << var3) != 0;
    }

    [FunctionName("B")]
    public int[] B1()
    {
        return K;
    }

    [FunctionName("w")]
    public void SetQuestionId(int id)
    {
        _questionId = id;
    }

    [FunctionName("C")]
    public int GetQuestionId()
    {
        return _questionId;
    }

    [FunctionName("d")]
    public void SetQuestionBit(int questionId, int bitIndex)
    {
        int[] var10000 = _questionBits;
        var10000[questionId] |= bitIndex & 255;
    }

    [FunctionName("D")]
    public int[] GetQuestionBits()
    {
        return _questionBits;
    }

    // 00000001: Found
    // 00000010: Solved
    // 00000100: ---
    // 00001000: Hint 1
    // 00010000: Hint 2
    // 00100000: Hint 3
    // 01000000: Failed once
    // 10000000: Failed twice
    [FunctionName("e")]
    public bool IsQuestionBitSet(int questionId, int bitIndex)
    {
        return (_questionBits[questionId] & bitIndex) != 0;
    }

    [FunctionName("x")]
    public bool IsCurrentQuestionBitSet(int index)
    {
        return IsQuestionBitSet(_questionId, index);
    }

    [FunctionName("f")]
    public void f1(int var1, int var2)
    {
        int[] var10000 = M;
        var10000[var1] |= var2 & 255;
    }

    [FunctionName("E")]
    public int[] E1()
    {
        return M;
    }

    [FunctionName("g")]
    public void g1(int var1, int var2)
    {
        O[var1] = var2;
    }

    [FunctionName("F")]
    public int[] F1()
    {
        return O;
    }

    [FunctionName("G")]
    public void Reset()
    {
        _eventId = 0;

        int var1;
        for (var1 = 0; var1 < 256; ++var1)
        {
            _questionBits[var1] = 0;
            M[var1] = 0;
        }

        for (var1 = 0; var1 < 512; ++var1)
        {
            _eventStates[var1] = 0;
        }

        int[] var10000 = _eventStates;
        var10000[0] |= 2;
        _memoIndex = 0;
        _storyId = 0;

        for (var1 = 0; var1 < 128; ++var1)
        {
            _bitFlags[var1] = 0;
        }

        g1(0, 0);
        g1(1, 0);

        for (var1 = 0; var1 < 32; ++var1)
        {
            K[var1] = 0;
        }
    }

    [FunctionName("a")]
    public void a1(bool var1)
    {
        W = var1;
    }

    [FunctionName("a")]
    public ResourceBase[] LoadBackgroundResource(GameFileManager fileManager, JavaString resourceName, int var3)
    {
        if (_bgOjResource == null)
        {
            byte[] resourceData = fileManager.GetLoadedData(resourceName);
            _bgOjResource = CharacterResourceFile.Read(resourceData);
        }

        int inactivePots = _potCount;

        for (int var5 = 0; var5 < _potCount; ++var5)
        {
            if (_potAmount[var5] != 0)
            {
                --inactivePots;
            }
        }

        ResourceBase[] inactivePotResources = new ResourceBase[inactivePots];
        int var6 = 0;

        for (int var7 = 0; var6 < _potCount; ++var6)
        {
            if (var3 == 0)
            {
                if (_potAmount[var6] == 0)
                {
                    inactivePotResources[var7] = _bgOjResource.GetAnimatedImage(1);
                    if (V[var6] == -1)
                    {
                        V[var6] = 0;
                    }

                    ((AnimatedImageResource)inactivePotResources[var7]).SetAnimationIndex(V[var6]);
                    ++var7;
                }
            }
            else if (_potAmount[var6] == 0)
            {
                inactivePotResources[var7] = _bgOjResource.GetAnimatedImage(0);
                ++var7;
            }
        }

        return inactivePotResources;
    }

    [FunctionName("b")]
    public void AddPot(int potId, int var2, int var3, int posX, int posY, int var6)
    {
        if (_potCount < 10)
        {
            _potId[_potCount] = potId;
            R[_potCount] = var2;
            S[_potCount] = var3;
            _potPos[_potCount][0] = posX;
            _potPos[_potCount][1] = posY;
            _potAmount[_potCount] = var6;
            if (_potAmount[_potCount] == 0)
            {
                if (W)
                {
                    V[_potCount] = Helper.GetRandomInt(5);
                }
            }
            else
            {
                V[_potCount] = -1;
            }

            ++_potCount;
        }
    }

    [FunctionName("H")]
    public int GetPotCount()
    {
        return _potCount;
    }

    [FunctionName("y")]
    public int[] GetPotPos(int potId)
    {
        return _potPos[potId];
    }

    [FunctionName("z")]
    public int GetPotAmount(int potId)
    {
        return _potAmount[potId];
    }

    [FunctionName("I")]
    public int I1()
    {
        return X;
    }

    [FunctionName("A")]
    public int A1(int var1)
    {
        if (c == null)
        {
            return 0;
        }
        else
        {
            ++var1;
            if (var1 >= c.Length)
            {
                var1 = 0;
            }

            return var1;
        }
    }

    [FunctionName("B")]
    public void B1(int var1)
    {
        Z = 0;
        Y = new int[var1];

        for (int var2 = 0; var2 < var1; ++var2)
        {
            Y[var2] = 0;
        }

    }

    [FunctionName("C")]
    public void C1(int var1)
    {
        Z = var1;
    }

    [FunctionName("J")]
    public int J1()
    {
        return Z;
    }

    [FunctionName("D")]
    public void D1(int var1)
    {
        Y[var1] = 1;
    }

    [FunctionName("E")]
    public int E1(int var1)
    {
        return Y[var1];
    }

    [FunctionName("K")]
    public static void K1()
    {
        byte[] var0 = new byte[2];
        if ((var0 = ScratchPadManager.Read(2, var0.Length)) == null)
        {
            IApplication.GetCurrentApp().Terminate();
        }

        AudioManager.b1(var0[0]);
        PhoneManager.a = var0[1] == 0;
    }

    [FunctionName("L")]
    public static void L1()
    {
        byte[] var0 = new byte[2];

        for (int var1 = 0; var1 < var0.Length; ++var1)
        {
            var0[var1] = (byte)H1(0 + var1);
        }

        ScratchPadManager.Write(2, var0);
    }

    [FunctionName("F")]
    public static void F1(int var0)
    {
        byte var1 = (byte)H1(var0);
        ScratchPadManager.Write(2 + var0, var1);
    }

    [FunctionName("H")]
    private static int H1(int var0)
    {
        int var1 = 0;
        switch (var0)
        {
            case 0:
                var1 = AudioManager.c1();
                break;
            case 1:
                var1 = PhoneManager.a ? 0 : 1;
                break;
        }

        return var1;
    }

    [FunctionName("G")]
    public static void G1(int var0)
    {
        ScratchPadManager.Write(4, (byte)var0);
    }

    [FunctionName("M")]
    public static byte M1()
    {
        return ScratchPadManager.Read(4, 1)[0];
    }

    [FunctionName("a")]
    public void Load(GameContext var1)
    {
        _storyId = var1.SaveData.GetStoryId();
        _memoIndex = var1.SaveData.n1();
        _bitFlags = var1.SaveData.o1();
        O = var1.SaveData.p1();
        _eventStates = var1.SaveData.SetEventStates();
        K = var1.SaveData.r1();
        _questionBits = var1.SaveData.GetQuestionBits();
        M = var1.SaveData.t1();
    }
}
