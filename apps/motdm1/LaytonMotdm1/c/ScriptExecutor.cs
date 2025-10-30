using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm1.data;

namespace LaytonMotdm1.c;

[ClassName("c", "aa")]
public class ScriptExecutor
{
    [MemberName("a")]
    private byte[] branchMarkers = new byte[32];

    [MemberName("b")]
    public JavaString Identifier = "";

    [MemberName("c")]
    private RoomData _roomData;
    [MemberName("d")]
    private SaveData _saveData;

    [MemberName("e")]
    public int CmdMetadata = 0;
    [MemberName("f")]
    public int f = 0;
    [MemberName("g")]
    public int g = 0;
    [MemberName("h")]
    public int _posX = 0;
    [MemberName("i")]
    public int _posY = 0;
    [MemberName("j")]
    public int j = 0;
    [MemberName("k")]
    public int k = 0;
    [MemberName("l")]
    public int l = 0;
    [MemberName("m")]
    public byte[] m;
    [MemberName("n")]
    public int n = 0;
    [MemberName("o")]
    public int o = 0;
    [MemberName("p")]
    public bool p = false;
    [MemberName("q")]
    public byte[] q;
    [MemberName("r")]
    public int r;
    [MemberName("s")]
    public int s;
    [MemberName("t")]
    public int t;
    [MemberName("u")]
    public int u;
    [MemberName("v")]
    public JavaString v;
    [MemberName("w")]
    public int w = 0;
    [MemberName("x")]
    public int x = 0;
    [MemberName("y")]
    public int y = 0;
    [MemberName("z")]
    public JavaString SoundFile = "";
    [MemberName("A")]
    public int A = 0;
    [MemberName("B")]
    public bool B = false;
    [MemberName("C")]
    public int FrameCounter = 0;
    [MemberName("D")]
    public int D = 0;
    [MemberName("E")]
    public JavaString[] ResourceFileNames;
    [MemberName("F")]
    public JavaString[] BackgroundFileNames;
    [MemberName("G")]
    public JavaString[] SpecialFileNames;
    [MemberName("H")]
    public int LoadFileCount = 0;
    [MemberName("I")]
    public JavaString I = "";
    [MemberName("J")]
    public JavaString J;
    [MemberName("K")]
    public JavaString[] K;
    [MemberName("L")]
    public int L;
    [MemberName("P")]
    private int P;
    [MemberName("Q")]
    private bool Q = false;
    [MemberName("M")]
    public bool shouldStopExecution = false;
    [MemberName("N")]
    public int[] N;
    [MemberName("O")]
    public int[] O;

    [ConstructorName("aa")]
    public ScriptExecutor()
    {
    }

    [FunctionName("a")]
    public void ExecuteAll(byte[] scriptData, GameContext var2)
    {
        int eventOffset = 0;

        while (eventOffset < scriptData.Length)
        {
            eventOffset = ExecuteNext(scriptData, eventOffset, var2);
            if (shouldStopExecution)
            {
                break;
            }
        }
    }

    [FunctionName("a")]
    public int ExecuteNext(byte[] scriptData, int offset, GameContext var3)
    {
        _roomData = var3.RoomData;
        _saveData = var3.SaveData;
        offset = ReadIdentifier(scriptData, offset);

        try
        {
            int resourceIndex;
            if (Identifier.Equals("addExit"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                f = scriptData[offset++];
                g = scriptData[offset++];
                _posX = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                _posY = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                j = scriptData[offset++];
                var3.RoomData.AddExit(CmdMetadata, f, g, _posX, _posY, j);
            }
            else
            {
                bool var7;
                if (Identifier.Equals("addPot"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    f = scriptData[offset++];
                    g = scriptData[offset++];
                    _posX = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    _posY = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    w = scriptData[offset++];
                    var3.RoomData.AddPot(CmdMetadata, f, g, _posX, _posY, w);
                    var7 = false;
                    if (w == 0)
                    {
                        _roomData.AddEvent(100, CmdMetadata, f, g, _posX, _posY, 0);
                    }
                    else if (w == 1)
                    {
                        _roomData.AddEvent(101, CmdMetadata, f, g, _posX, _posY, 0);
                    }
                    else
                    {
                        _roomData.AddEvent(-1, -1, f, g, _posX, _posY, -1);
                    }
                }
                else if (Identifier.Equals("addEvent"))
                {
                    ++offset;
                    ++offset;
                    n = scriptData[offset++];
                    CmdMetadata = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    f = scriptData[offset++];
                    g = scriptData[offset++];
                    _posX = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    _posY = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    l = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    m = new byte[l];
                    Array.Copy(scriptData, offset, m, 0, l);
                    offset += l;
                    resourceIndex = _roomData.AddEventText(new JavaString(m)) - 1;
                    if (n == 4)
                    {
                        D = scriptData[offset++];
                        w = scriptData[offset++];
                        _roomData.AddEvent(n, CmdMetadata, f, g, _posX, _posY, resourceIndex, D, w);
                    }
                    else
                    {
                        _roomData.AddEvent(n, CmdMetadata, f, g, _posX, _posY, resourceIndex);
                    }
                }
                else if (Identifier.Equals("Return"))
                {
                    ++offset;
                    ++offset;
                    f = scriptData[offset++];
                    g = scriptData[offset++];
                    _roomData.AddEvent(-1, -1, f, g, 254, 217, -1);
                }
                else if (Identifier.Equals("addBG"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    _roomData.SetBackground(ResourceFileNames[CmdMetadata]);
                }
                else if (Identifier.Equals("setBGFlip"))
                {
                    ++offset;
                    ++offset;
                    _roomData.ToggleBackgroundFlipped();
                }
                else if (Identifier.Equals("addBGObj"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    _posX = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    _posY = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    _roomData.AddBackgroundObject(CmdMetadata, _posX, _posY);
                }
                else if (Identifier.Equals("setObjFlip"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    _roomData.ToggleBackgroundObjectFlipped(CmdMetadata);
                }
                else if (Identifier.Equals("if"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    byte var9 = scriptData[offset++];
                    p = var9 == 1;
                    n = scriptData[offset++];
                    o = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    bool var5 = EvaluateComparison(n, o);
                    if (p)
                    {
                        var5 = !var5;
                    }

                    if (var5)
                    {
                        SetBranchFlag(CmdMetadata, true);
                    }
                    else
                    {
                        offset = GetNextBranchOffset(scriptData, offset, CmdMetadata);
                    }
                }
                else if (Identifier.Equals("elseif"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    p = scriptData[offset++] == 1;
                    n = scriptData[offset++];
                    o = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    if (IsBranchFlagSet(CmdMetadata))
                    {
                        offset = GetNextBranchOffset(scriptData, offset, CmdMetadata);
                    }
                    else
                    {
                        var7 = EvaluateComparison(n, o);
                        if (p)
                        {
                            var7 = !var7;
                        }

                        if (var7)
                        {
                            SetBranchFlag(CmdMetadata, true);
                        }
                        else
                        {
                            offset = GetNextBranchOffset(scriptData, offset, CmdMetadata);
                        }
                    }
                }
                else if (Identifier.Equals("else"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    if (IsBranchFlagSet(CmdMetadata))
                    {
                        offset = GetNextBranchOffset(scriptData, offset, CmdMetadata);
                    }
                }
                else if (Identifier.Equals("endif"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    SetBranchFlag(CmdMetadata, false);
                }
                else if (Identifier.Equals("Choice"))
                {
                    P = offset - 10;
                    ++offset;
                    ++offset;
                    LoadFileCount = scriptData[offset++];
                    l = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                    q = new byte[l];
                    Array.Copy(scriptData, offset, q, 0, l);
                    offset += l;
                    J = new JavaString(q);
                    K = new JavaString[LoadFileCount];

                    for (resourceIndex = 0; resourceIndex < LoadFileCount; ++resourceIndex)
                    {
                        l = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                        q = new byte[l];
                        Array.Copy(scriptData, offset, q, 0, l);
                        offset += l;
                        K[resourceIndex] = new JavaString(q);
                    }

                    L = scriptData[offset++];
                }
                else if (Identifier.Equals("Case"))
                {
                    ++offset;
                    ++offset;
                    CmdMetadata = scriptData[offset++];
                    if (Q)
                    {
                        offset = GetNextChoiceOffset(scriptData, offset);
                    }
                    else if (var3.RoomData.J1() + 1 != CmdMetadata)
                    {
                        offset = GetNextChoiceOffset(scriptData, offset);
                        Q = false;
                    }
                    else
                    {
                        Q = true;
                    }
                }
                else if (Identifier.Equals("endChoice"))
                {
                    ++offset;
                    ++offset;
                    if (Q)
                    {
                        offset = P;
                    }
                    else
                    {
                        J = null;

                        for (resourceIndex = 0; resourceIndex < K.Length; ++resourceIndex)
                        {
                            K[resourceIndex] = null;
                        }

                        L = 0;
                    }

                    Q = false;
                }
            }

            if (Identifier.Equals("sendNazoba"))
            {
                ++offset;
                ++offset;
            }

            if (Identifier.Equals("FadeIn"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("FadeOut"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("SpFadeOut"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                FrameCounter = scriptData[offset++];
            }

            int var8;
            if (Identifier.Equals("PluralIn"))
            {
                ++offset;
                ++offset;
                resourceIndex = scriptData[offset++];
                O = new int[resourceIndex];

                for (var8 = 0; var8 < resourceIndex; ++var8)
                {
                    O[var8] = scriptData[offset++];
                }

                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("PluralOut"))
            {
                ++offset;
                ++offset;
                resourceIndex = scriptData[offset++];
                O = new int[resourceIndex];

                for (var8 = 0; var8 < resourceIndex; ++var8)
                {
                    O[var8] = scriptData[offset++];
                }

                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("SpFadeIn"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("ObjFadeOut"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                w = scriptData[offset++];
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("ObjFadeIn"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                w = scriptData[offset++];
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("Vibe"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("Shake"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
                CmdMetadata = scriptData[offset++];
            }

            if (Identifier.Equals("ShakeBG"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("ShakeSP"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
                CmdMetadata = scriptData[offset++];
            }

            if (Identifier.Equals("ShakeALL"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("Wait"))
            {
                ++offset;
                ++offset;
                FrameCounter = scriptData[offset++];
            }

            if (Identifier.Equals("KeyWait"))
            {
                ++offset;
                ++offset;
            }

            if (Identifier.Equals("CQuestion"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                var3.RoomData.SetQuestionId(CmdMetadata);
            }

            if (Identifier.Equals("CEvent"))
            {
                ++offset;
                ++offset;
                CmdMetadata = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                var3.RoomData.SetEventId(CmdMetadata);
            }

            if (Identifier.Equals("setEVState"))
            {
                ++offset;
                ++offset;
                D = scriptData[offset++];
                var3.RoomData.SetEventState(var3.RoomData.GetEventId(), D);
            }

            if (Identifier.Equals("GameMode"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                var3.RoomData.SetGameMode(CmdMetadata);
            }

            if (Identifier.Equals("AddObject"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                w = scriptData[offset++];
                n = scriptData[offset++];
                _posX = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                _posY = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                x = scriptData[offset++];
            }

            if (Identifier.Equals("AddSprite"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                _posX = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                _posY = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                n = scriptData[offset++];
            }

            if (Identifier.Equals("ChangeAni"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                n = scriptData[offset++];
            }

            if (Identifier.Equals("ChangeLAni"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                n = scriptData[offset++];
            }

            if (Identifier.Equals("reverseSP"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
            }

            if (Identifier.Equals("InfoWindow"))
            {
                ++offset;
                ++offset;
                n = scriptData[offset++];
                CmdMetadata = scriptData[offset++];
            }

            if (Identifier.Equals("TextWindow"))
            {
                ++offset;
                ++offset;
                n = scriptData[offset++];
                CmdMetadata = scriptData[offset++];
                l = (short)(scriptData[offset++] | scriptData[offset++] << 8);
                q = new byte[l];
                Array.Copy(scriptData, offset, q, 0, l);
                offset += l;
                v = new JavaString(q);
            }

            if (Identifier.Equals("addMemo"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                var3.SaveData.a1(CmdMetadata, 1, var3);
            }

            if (Identifier.Equals("BGMask"))
            {
                ++offset;
                ++offset;
                r = scriptData[offset++];
                s = scriptData[offset++];
                t = scriptData[offset++];
                u = scriptData[offset++];
            }

            if (Identifier.Equals("PlaySound"))
            {
                ++offset;
                ++offset;
                y = scriptData[offset++];
                A = scriptData[offset++];
                q = new byte[A];
                Array.Copy(scriptData, offset, q, 0, A);
                offset += A;
                SoundFile = new JavaString(q);
                B = (scriptData[offset++]) == 1;
            }

            if (Identifier.Equals("StopSound"))
            {
                ++offset;
                ++offset;
                y = scriptData[offset++];
            }

            if (Identifier.Equals("PlayRSound"))
            {
                ++offset;
                ++offset;
                y = scriptData[offset++];
                A = scriptData[offset++];
                q = new byte[A];
                Array.Copy(scriptData, offset, q, 0, A);
                offset += A;
                SoundFile = new JavaString(q);
                B = (scriptData[offset++]) == 1;
            }

            if (Identifier.Equals("PlayMovie"))
            {
                ++offset;
                ++offset;
                A = scriptData[offset++];
                q = new byte[A];
                Array.Copy(scriptData, offset, q, 0, A);
                offset += A;
                I = new JavaString(q);
            }

            if (Identifier.Equals("SetBG"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
            }

            if (Identifier.Equals("reverseBG"))
            {
                ++offset;
                ++offset;
            }

            if (Identifier.Equals("inTitle"))
            {
                ++offset;
                ++offset;
            }

            if (Identifier.Equals("LukeLetter"))
            {
                ++offset;
                ++offset;
            }

            if (Identifier.Equals("AdhereMsg"))
            {
                ++offset;
                ++offset;
            }

            if (Identifier.Equals("SolMystery"))
            {
                ++offset;
                ++offset;
                LoadFileCount = scriptData[offset++];
                if (LoadFileCount > 0)
                {
                    N = new int[LoadFileCount];

                    for (resourceIndex = 0; resourceIndex < LoadFileCount; ++resourceIndex)
                    {
                        N[resourceIndex] = (scriptData[offset++]) - 1;
                    }
                }
            }

            if (Identifier.Equals("Occur"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
            }

            if (Identifier.Equals("Achieve"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
            }

            if (Identifier.Equals("comMove"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                var3.SaveData.SetRoomId(CmdMetadata);
            }

            if (Identifier.Equals("updateMemo"))
            {
                ++offset;
                ++offset;
                var3.RoomData.IncrementMemoIndex();
            }

            if (Identifier.Equals("setStory"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                var3.RoomData.SetStoryId(CmdMetadata);
            }

            if (Identifier.Equals("setBitFlg"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                var3.RoomData.SetBitFlag(CmdMetadata);
            }

            if (Identifier.Equals("offBitFlg"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                var3.RoomData.ToggleBitFlag(CmdMetadata, false);
            }

            if (Identifier.Equals("setItemFlg"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                n = scriptData[offset++];
                var3.RoomData.g1(CmdMetadata, n);
            }

            if (Identifier.Equals("setRiddle"))
            {
                ++offset;
                ++offset;
                CmdMetadata = scriptData[offset++];
                n = scriptData[offset++];
            }

            if (Identifier.Equals("LoadData"))
            {
                ++offset;
                ++offset;
                LoadFileCount = scriptData[offset++];
                ResourceFileNames = new JavaString[LoadFileCount];

                for (resourceIndex = 0; resourceIndex < LoadFileCount; ++resourceIndex)
                {
                    A = scriptData[offset++];
                    q = new byte[A];
                    Array.Copy(scriptData, offset, q, 0, A);
                    offset += A;
                    ResourceFileNames[resourceIndex] = new JavaString(q);
                }
            }

            if (Identifier.Equals("LoadBG"))
            {
                ++offset;
                ++offset;
                LoadFileCount = scriptData[offset++];
                BackgroundFileNames = new JavaString[LoadFileCount];

                for (resourceIndex = 0; resourceIndex < LoadFileCount; ++resourceIndex)
                {
                    A = scriptData[offset++];
                    q = new byte[A];
                    Array.Copy(scriptData, offset, q, 0, A);
                    offset += A;
                    BackgroundFileNames[resourceIndex] = new JavaString(q);
                }
            }

            if (Identifier.Equals("LoadSP"))
            {
                ++offset;
                ++offset;
                LoadFileCount = scriptData[offset++];
                SpecialFileNames = new JavaString[LoadFileCount];

                for (resourceIndex = 0; resourceIndex < LoadFileCount; ++resourceIndex)
                {
                    CmdMetadata = scriptData[offset++];
                    if (CmdMetadata == 0)
                    {
                        SpecialFileNames[resourceIndex] = "layton.dat";
                    }
                    else if (CmdMetadata == 1)
                    {
                        SpecialFileNames[resourceIndex] = "luke.dat";
                    }
                    else if (CmdMetadata == 2)
                    {
                        SpecialFileNames[resourceIndex] = "bridge.dat";
                    }
                }
            }

            if (Identifier.Equals("EndScript"))
            {
                ++offset;
                ++offset;
                shouldStopExecution = true;
            }
        }
        catch (Exception var6)
        {
            java.util.System.Out.Fatal(var6, "スクリプト展開失敗:{0}\n cmd={1}",var6.Message,Identifier);
        }

        return offset;
    }

    [FunctionName("a")]
    private int ReadIdentifier(byte[] scriptData, int offset)
    {
        byte[] identifierBuffer = new byte[10];

        for (int var4 = 0; var4 < 10; ++var4)
        {
            identifierBuffer[var4] = scriptData[offset + var4];
        }

        Identifier = new JavaString(identifierBuffer).Trim();
        offset += 10;
        return offset;
    }

    [FunctionName("a")]
    private void SetBranchFlag(int index, bool toggle)
    {
        int subIndex = index % 8;
        if (toggle)
            branchMarkers[index / 8] |= (byte)(1 << subIndex);
        else
            branchMarkers[index / 8] &= (byte)~(1 << subIndex);
    }

    [FunctionName("a")]
    private bool IsBranchFlagSet(int index)
    {
        int subIndex = index % 8;
        return (branchMarkers[index / 8] & 1 << subIndex) != 0;
    }

    [FunctionName("a")]
    private bool EvaluateComparison(int comparisonType, int comparisonValue)
    {
        bool result = false;
        switch (comparisonType)
        {
            // Memo index comparison
            // 0: equals
            // 1: smaller than
            // 2: greater than
            // 3: smaller equals
            // 4: greater equals
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                result = _roomData.EvaluateMemoIndex(comparisonValue, comparisonType);
                break;

            // If puzzle is encountered
            case 5:
                if (comparisonValue == 0)
                {
                    result = _roomData.IsCurrentQuestionBitSet(1);
                }
                else
                {
                    result = _roomData.IsQuestionBitSet(comparisonValue, 1);
                }
                break;

            // If puzzle is solved
            case 6:
                if (comparisonValue == 0)
                {
                    result = _roomData.IsCurrentQuestionBitSet(2);
                }
                else
                {
                    result = _roomData.IsQuestionBitSet(comparisonValue, 2);
                }
                break;

            // If player comes from an event
            case 7:
                result = _roomData.IsPlayerState(0);
                break;

            // If player comes from a puzzle
            case 8:
                result = _roomData.IsPlayerState(1);
                break;

            // If certain number of puzzles is solved
            case 9:
                if (_saveData.GetQuestionsSolvedCount() >= comparisonValue)
                {
                    result = true;
                }
                break;

            case 10:
                result = _roomData.v1(comparisonValue);
                break;

            case 11:
                result = _roomData.GetEventState(comparisonValue, 2);
                break;

            // If a certain game bit is set
            case 12:
                result = _roomData.GetBitFlag(comparisonValue);
                break;

            // If player just entered the room
            case 13:
                if (result = _roomData.IsRoomEntered())
                {
                    _roomData.SetRoomEntered(0);
                }
                break;

            // Checks if a certain story section is active
            case 14:
                result = _roomData.IsStoryId(comparisonValue);
                break;

            case 15:
                result = false;
                if (_roomData.c == null)
                {
                    if (comparisonValue >= 0)
                    {
                        result = true;
                    }
                }
                else if (_roomData.c.Length <= comparisonValue)
                {
                    result = true;
                }
                break;

            // If player is in a certain room
            case 16:
                if (_saveData.GetRoomId() == comparisonValue)
                {
                    result = true;
                }
                break;
        }

        return result;
    }

    [FunctionName("a")]
    private int GetNextBranchOffset(byte[] scriptData, int offset, int branchId)
    {
        while (true)
        {
            int lastOffset = offset;
            offset = ReadIdentifier(scriptData, offset);
            if (Identifier.Equals("elseif"))
            {
                offset += 2;
                if (scriptData[offset++] == branchId)
                {
                    offset = lastOffset;
                    break;
                }

                offset += 4;
            }
            else if (!Identifier.Equals("else") && !Identifier.Equals("endif"))
            {
                int eventSize = scriptData[offset++] | scriptData[offset++] << 8;
                offset += eventSize;
            }
            else
            {
                offset += 2;
                if (scriptData[offset++] == branchId)
                {
                    offset = lastOffset;
                    break;
                }
            }
        }

        return offset;
    }

    [FunctionName("b")]
    private int GetNextChoiceOffset(byte[] scriptData, int offset)
    {
        while (true)
        {
            int lastOffset = offset;
            offset = ReadIdentifier(scriptData, offset);
            if (Identifier.Equals("Case"))
            {
                offset = lastOffset;
                break;
            }

            if (Identifier.Equals("endChoice"))
            {
                offset = lastOffset;
                break;
            }

            int eventSize = scriptData[offset++] | scriptData[offset++] << 8;
            offset += eventSize;
        }

        return offset;
    }
}
