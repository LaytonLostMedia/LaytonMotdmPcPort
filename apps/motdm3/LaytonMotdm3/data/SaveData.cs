using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Managers;

namespace LaytonMotdm3.data;

[ClassName("data", "b")]
public class SaveData
{
    [MemberName("b")]
    private JavaString _name;
    [MemberName("c")]
    private int c;
    [MemberName("d")]
    private int d;
    [MemberName("e")]
    private int e;
    [MemberName("f")]
    private int _solvedCount;
    [MemberName("g")]
    private int g;
    [MemberName("h")]
    private int _roomId;
    [MemberName("i")]
    private int[] i = new int[5];
    [MemberName("j")]
    private bool j = false;
    [MemberName("k")]
    private int _storyId;
    [MemberName("l")]
    private int l;
    [MemberName("m")]
    private int[] m = new int[128];
    [MemberName("n")]
    private int[] n = new int[2];
    [MemberName("o")]
    private int[] o = new int[512];
    [MemberName("p")]
    private int[] p = new int[32];
    [MemberName("q")]
    private int[] _questionBits = new int[256];
    [MemberName("r")]
    private int[] r = new int[256];
    [MemberName("s")]
    private int s;
    [MemberName("t")]
    private int t;
    [MemberName("u")]
    private int u;
    [MemberName("v")]
    private int[] v = new int[20];
    [MemberName("w")]
    private int[] w = new int[20];
    [MemberName("x")]
    private int[,] x = new int[9, 11];
    [MemberName("y")]
    private int[,] _questions = new int[256, 10];
    [MemberName("z")]
    private int[] z = new int[20];
    [MemberName("A")]
    private long A = 0L;
    [MemberName("B")]
    private long B = 0L;
    [MemberName("a")]
    public long a = 0L;
    [MemberName("C")]
    private int C;

    [ConstructorName("b")]
    public SaveData()
    {
        A = 0L;
    }

    [FunctionName("a")]
    public JavaString GetName()
    {
        return _name;
    }

    [FunctionName("a")]
    public void SetName(JavaString name)
    {
        _name = name;
    }

    [FunctionName("b")]
    public int b1()
    {
        return d;
    }

    [FunctionName("a")]
    public void a1(int var1)
    {
        d = var1;
    }

    [FunctionName("c")]
    public int c1()
    {
        return e;
    }

    [FunctionName("b")]
    public void b1(int questionId)
    {
        e = questionId;
    }

    [FunctionName("d")]
    public int GetQuestionsSolvedCount()
    {
        return _solvedCount;
    }

    [FunctionName("c")]
    public void SetQuestionsSolvedCount(int count)
    {
        _solvedCount = count;
    }

    [FunctionName("d")]
    public void d1(int var1)
    {
        g = var1;
    }

    [FunctionName("e")]
    public int GetRoomId()
    {
        return _roomId;
    }

    [FunctionName("e")]
    public void SetRoomId(int id)
    {
        _roomId = id;
    }

    [FunctionName("a")]
    public void a1(int var1, int var2, GameContext var3)
    {
        j = false;
        if (var1 < 0 || i.Length + 1 < var1)
        {
            java.util.System.Out.Error("メモの番号が不正です :{0}", var1);
            var1 = 1;
        }

        if (i[var1 - 1] < var2)
        {
            i[var1 - 1] = var2;
            j = true;
            var3.RoomData.SetBitFlag(100);
        }

    }

    [FunctionName("f")]
    public int f1(int var1)
    {
        if (var1 < 0 || i.Length + 1 < var1)
        {
            java.util.System.Out.Error("メモ取得時の値が不正です :{0}", var1);
            var1 = 1;
        }

        return i[var1 - 1];
    }

    [FunctionName("f")]
    public bool f1()
    {
        return j;
    }

    [FunctionName("a")]
    public void a1(bool var1)
    {
        j = var1;
    }

    [FunctionName("a")]
    public void SetQuestionPikaratTotal(int questionId, int var2)
    {
        _questions[questionId, 1] = var2;
    }

    [FunctionName("b")]
    public void SetQuestionPikarat(int questionId, int var2)
    {
        _questions[questionId, 0] = var2;
    }

    [FunctionName("c")]
    public void SetQuestionType(int questionId, int var2)
    {
        _questions[questionId, 2] = var2;
    }

    [FunctionName("d")]
    public void SetQuestionHintCount(int questionId, int var2)
    {
        _questions[questionId, 3] = var2;
    }

    [FunctionName("e")]
    public void SetQuestionFailCount(int questionId, int var2)
    {
        _questions[questionId, 4] = var2;
    }

    [FunctionName("f")]
    public void SetQuestionState(int questionId, int value)
    {
        _questions[questionId, 5] = value;
    }

    [FunctionName("g")]
    public int g1(int questionId)
    {
        return _questions[questionId, 5];
    }

    [FunctionName("g")]
    public void g1(int questionId, int var2)
    {
        _questions[questionId, 8] = var2;
    }

    [FunctionName("h")]
    public int h1(int questionId)
    {
        return _questions[questionId, 8];
    }

    [FunctionName("h")]
    public void h1(int questionId, int var2)
    {
        _questions[questionId, 9] = var2;
    }

    [FunctionName("i")]
    public int i1(int var1)
    {
        return _questions[var1, 9];
    }

    [FunctionName("g")]
    public void g1()
    {
        t = 0;
    }

    [FunctionName("h")]
    public int h1()
    {
        return t;
    }

    [FunctionName("j")]
    public void j1(int var1)
    {
        u = var1;
    }

    [FunctionName("i")]
    public int i1()
    {
        return u;
    }

    [FunctionName("a")]
    public void a1(int var1, int var2, int var3)
    {
        x[var1, var2] = var3;
    }

    [FunctionName("i")]
    public int i1(int var1, int var2)
    {
        return x[var1, var2];
    }

    [FunctionName("k")]
    public void k1(int var1)
    {
        for (int var2 = 0; var2 < 20; ++var2)
        {
            if (v[var2] == 0)
            {
                j1(1);
                v[var2] = var1;
                r1(var1);
                return;
            }
        }

    }

    [FunctionName("j")]
    public void j1(int var1, int var2)
    {
        v[var1] = var2;
    }

    [FunctionName("l")]
    public int l1(int var1)
    {
        return v[var1];
    }

    [FunctionName("j")]
    public void j1()
    {
        v = new int[20];

        for (int var1 = 0; var1 < 20; ++var1)
        {
            v[var1] = 0;
        }

        Array.Copy(w, 0, v, 0, w.Length);
    }

    [FunctionName("r")]
    private void r1(int var1)
    {
        for (int var2 = 0; var2 < 20; ++var2)
        {
            if (w[var2] == 0)
            {
                w[var2] = var1;
                return;
            }
        }
    }

    [FunctionName("m")]
    public void m1(int var1)
    {
        for (int var2 = 0; var2 < 20; ++var2)
        {
            if (z[var2] == 0)
            {
                z[var2] = var1;
                return;
            }
        }
    }

    [FunctionName("n")]
    public int n1(int var1)
    {
        return z[var1];
    }

    [FunctionName("k")]
    public void k1()
    {
        for (int var1 = 0; var1 < 20; ++var1)
        {
            z[var1] = 0;
        }
    }

    [FunctionName("l")]
    public void l1()
    {
        A = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - (long)c;
    }

    [FunctionName("m")]
    public void m1()
    {
        if (A != 0L)
        {
            B = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            a = B - A;
            if (a <= 360000000L)
            {
                c = (int)a;
            }
        }
    }

    [FunctionName("o")]
    public void LoadSlot(int var1)
    {
        byte[] var2 = new byte[4096];
        if ((var2 = ScratchPadManager.Read(10 + var1 * 4096, var2.Length)) == null)
        {
            IApplication.GetCurrentApp().Terminate();
        }

        bool var3 = false;
        byte[] var4 = new byte[16];
        Array.Copy(var2, 0, var4, 0, var4.Length);
        _name = new JavaString(var4).Trim();
        int var7 = var4.Length;
        c = var2[var7++] & 255;
        c |= var2[var7++] << 8 & '\uffff';
        c |= var2[var7++] << 16 & 16777215;
        c |= var2[var7++] << 24;
        d = var2[var7++] & 255;
        d |= var2[var7++] << 8 & '\uffff';
        d |= var2[var7++] << 16 & 16777215;
        d |= var2[var7++] << 24;
        e = var2[var7++] & 255;
        _solvedCount = var2[var7++] & 255;
        g = var2[var7++] & 255;
        _roomId = var2[var7++] & 255;

        int var5;
        for (var5 = 0; var5 < i.Length; ++var5)
        {
            i[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < _questions.GetLength(0); ++var5)
        {
            _questions[var5, 0] = var2[var7++] & 255;
            _questions[var5, 1] = var2[var7++] & 255;
            _questions[var5, 2] = var2[var7++] & 255;
            _questions[var5, 3] = var2[var7++] & 255;
            _questions[var5, 4] = var2[var7++] & 255;
            _questions[var5, 5] = var2[var7++] & 255;
            _questions[var5, 6] = var2[var7++] & 255;
            _questions[var5, 7] = var2[var7++] & 255;
            _questions[var5, 8] = var2[var7++] & 255;
        }

        s = var2[var7++] & 255;
        _storyId = var2[var7++] & 255;
        l = var2[var7++] & 255;

        for (var5 = 0; var5 < 128; ++var5)
        {
            m[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < 2; ++var5)
        {
            n[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < 512; ++var5)
        {
            o[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < 32; ++var5)
        {
            p[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < 256; ++var5)
        {
            _questionBits[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < 256; ++var5)
        {
            r[var5] = var2[var7++] & 255;
        }

        t = var2[var7++] & 255;
        u = var2[var7++] & 255;

        for (var5 = 0; var5 < 9; ++var5)
        {
            for (int var6 = 0; var6 < 11; ++var6)
            {
                x[var5, var6] = var2[var7++] & 255;
            }
        }

        for (var5 = 0; var5 < 20; ++var5)
        {
            v[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < 20; ++var5)
        {
            w[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < 20; ++var5)
        {
            z[var5] = var2[var7++] & 255;
        }

        C = var2[var7] & 255;
        l1();
    }

    [FunctionName("p")]
    public void p1(int var1)
    {
        byte[] var2 = new byte[4096];
        bool var3 = false;
        byte[] var4 = JavaString.GetBytes("                ");
        byte[] var5;
        Array.Copy(var5 = _name.GetBytes(), 0, var4, 0, var5.Length);
        int var8 = var4.Length;
        Array.Copy(var4, 0, var2, 0, var8);
        var2[var8++] = (byte)(c & 255);
        var2[var8++] = (byte)(c >> 8 & 255);
        var2[var8++] = (byte)(c >> 16 & 255);
        var2[var8++] = (byte)(c >> 24 & 255);
        var2[var8++] = (byte)(d & 255);
        var2[var8++] = (byte)(d >> 8 & 255);
        var2[var8++] = (byte)(d >> 16 & 255);
        var2[var8++] = (byte)(d >> 24 & 255);
        var2[var8++] = (byte)e;
        var2[var8++] = (byte)_solvedCount;
        var2[var8++] = (byte)g;
        var2[var8++] = (byte)_roomId;

        int var6;
        for (var6 = 0; var6 < i.Length; ++var6)
        {
            var2[var8++] = (byte)i[var6];
        }

        for (var6 = 0; var6 < _questions.GetLength(0); ++var6)
        {
            var2[var8++] = (byte)_questions[var6, 0];
            var2[var8++] = (byte)_questions[var6, 1];
            var2[var8++] = (byte)_questions[var6, 2];
            var2[var8++] = (byte)_questions[var6, 3];
            var2[var8++] = (byte)_questions[var6, 4];
            var2[var8++] = (byte)_questions[var6, 5];
            var2[var8++] = (byte)_questions[var6, 6];
            var2[var8++] = (byte)_questions[var6, 7];
            var2[var8++] = (byte)_questions[var6, 8];
        }

        var2[var8++] = (byte)s;
        var2[var8++] = (byte)_storyId;
        var2[var8++] = (byte)l;

        for (var6 = 0; var6 < m.Length; ++var6)
        {
            var2[var8++] = (byte)m[var6];
        }

        for (var6 = 0; var6 < n.Length; ++var6)
        {
            var2[var8++] = (byte)n[var6];
        }

        for (var6 = 0; var6 < o.Length; ++var6)
        {
            var2[var8++] = (byte)o[var6];
        }

        for (var6 = 0; var6 < p.Length; ++var6)
        {
            var2[var8++] = (byte)p[var6];
        }

        for (var6 = 0; var6 < _questionBits.Length; ++var6)
        {
            var2[var8++] = (byte)_questionBits[var6];
        }

        for (var6 = 0; var6 < r.Length; ++var6)
        {
            var2[var8++] = (byte)r[var6];
        }

        var2[var8++] = (byte)t;
        var2[var8++] = (byte)u;

        for (var6 = 0; var6 < 9; ++var6)
        {
            for (int var7 = 0; var7 < 11; ++var7)
            {
                var2[var8++] = (byte)x[var6, var7];
            }
        }

        for (var6 = 0; var6 < 20; ++var6)
        {
            var2[var8++] = (byte)v[var6];
        }

        for (var6 = 0; var6 < 20; ++var6)
        {
            var2[var8++] = (byte)w[var6];
        }

        for (var6 = 0; var6 < 20; ++var6)
        {
            var2[var8++] = (byte)z[var6];
        }

        var2[var8] = (byte)C;
        ScratchPadManager.Write(10 + var1 * 4096, var2);
    }

    [FunctionName("n")]
    public void Reset()
    {
        _name = "きみ";
        d = 0;
        e = 10;
        _solvedCount = 0;
        g = 0;
        _roomId = 1;

        int var1;
        for (var1 = 0; var1 < i.Length; ++var1)
        {
            i[var1] = 0;
        }

        t = 1;
        u = 0;
        C = 0;

        for (var1 = 0; var1 < 9; ++var1)
        {
            for (int var2 = 0; var2 < 11; ++var2)
            {
                x[var1, var2] = 0;
            }
        }

        for (var1 = 0; var1 < 20; ++var1)
        {
            v[var1] = 0;
            w[var1] = 0;
            z[var1] = 0;
        }

        for (var1 = 0; var1 < _questions.GetLength(0); ++var1)
        {
            _questions[var1, 0] = 0;
            _questions[var1, 1] = 0;
            _questions[var1, 2] = 0;
            _questions[var1, 3] = 0;
            _questions[var1, 4] = 0;
            _questions[var1, 5] = 0;
            _questions[var1, 6] = 0;
            _questions[var1, 7] = 0;
            _questions[var1, 8] = 0;
        }

        s = 0;
        A = 0L;
        B = 0L;
        a = 0L;
        l1();
    }

    [FunctionName("a")]
    public void a1(GameContext var1)
    {
        _storyId = var1.RoomData.GetStoryId();
        l = var1.RoomData.f1();
        m = var1.RoomData.y1();
        n = var1.RoomData.F1();
        o = var1.RoomData.GetEventStates();
        p = var1.RoomData.B1();
        _questionBits = var1.RoomData.GetQuestionBits();
        r = var1.RoomData.E1();
    }

    [FunctionName("o")]
    public int GetStoryId()
    {
        return _storyId;
    }

    [FunctionName("p")]
    public int p1()
    {
        return l;
    }

    [FunctionName("q")]
    public int[] q1()
    {
        return m;
    }

    [FunctionName("r")]
    public int[] r1()
    {
        return n;
    }

    [FunctionName("s")]
    public int[] SetEventStates()
    {
        return o;
    }

    [FunctionName("t")]
    public int[] t1()
    {
        return p;
    }

    [FunctionName("u")]
    public int[] GetQuestionBits()
    {
        return _questionBits;
    }

    [FunctionName("v")]
    public int[] v1()
    {
        return r;
    }

    [FunctionName("w")]
    public void w1()
    {
        byte[] var1 = new byte[5];
        byte[] var2 = new byte[5];
        var1 = ScratchPadManager.Read(5, var1.Length);

        for (int var3 = 0; var3 < 5; ++var3)
        {
            if (var1[var3] < i[var3])
            {
                var2[var3] = (byte)i[var3];
            }
            else
            {
                var2[var3] = var1[var3];
            }
        }

        ScratchPadManager.Write(5, var2);
    }

    [FunctionName("x")]
    public void x1()
    {
        byte[] var1 = new byte[5];
        var1 = ScratchPadManager.Read(5, var1.Length);

        for (int var2 = 0; var2 < i.Length; ++var2)
        {
            i[var2] = var1[var2] & 255;
        }
    }

    [FunctionName("y")]
    public bool y1()
    {
        bool var1 = true;

        for (int var2 = 0; var2 < i.Length; ++var2)
        {
            if (i[var2] != 2)
            {
                var1 = false;
                break;
            }
        }

        return var1;
    }

    [FunctionName("q")]
    public void q1(int var1)
    {
        C = var1;
    }

    [FunctionName("z")]
    public int z1()
    {
        return C;
    }
}
