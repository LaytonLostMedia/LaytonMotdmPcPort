using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm6.c;
using LaytonMotdm6.c.Managers;

namespace LaytonMotdm6.data;

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
    private int[] i = new int[6];
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
    private int[] y = new int[20];
    [MemberName("z")]
    private int[] z = new int[20];
    [MemberName("A")]
    private int[] A = new int[20];
    [MemberName("B")]
    private int[] B = new int[20];
    [MemberName("C")]
    private int C;
    [MemberName("D")]
    private int[,] D = new int[256, 10];
    [MemberName("E")]
    private int[] E = new int[20];
    [MemberName("F")]
    private long F = 0L;
    [MemberName("G")]
    private long G = 0L;
    [MemberName("a")]
    public long a = 0L;
    [MemberName("H")]
    private int H;
    [MemberName("I")]
    private int I;
    [MemberName("J")]
    private int J;
    [MemberName("K")]
    private int K;

    [ConstructorName("b")]
    public SaveData()
    {
        F = 0L;
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
        D[questionId, 1] = var2;
    }

    [FunctionName("b")]
    public void SetQuestionPikarat(int questionId, int var2)
    {
        D[questionId, 0] = var2;
    }

    [FunctionName("c")]
    public void SetQuestionType(int questionId, int var2)
    {
        D[questionId, 2] = var2;
    }

    [FunctionName("d")]
    public void SetQuestionHintCount(int questionId, int var2)
    {
        D[questionId, 3] = var2;
    }

    [FunctionName("e")]
    public void SetQuestionFailCount(int questionId, int var2)
    {
        D[questionId, 4] = var2;
    }

    [FunctionName("f")]
    public void SetQuestionState(int questionId, int value)
    {
        D[questionId, 5] = value;
    }

    [FunctionName("g")]
    public int g1(int questionId)
    {
        return D[questionId, 5];
    }

    [FunctionName("g")]
    public void g1(int questionId, int var2)
    {
        D[questionId, 8] = var2;
    }

    [FunctionName("h")]
    public int h1(int questionId)
    {
        return D[questionId, 8];
    }

    [FunctionName("h")]
    public void h1(int questionId, int var2)
    {
        D[questionId, 9] = var2;
    }

    [FunctionName("i")]
    public int i1(int var1)
    {
        return D[var1, 9];
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

    [FunctionName("k")]
    public void k1(int var1)
    {
        for (int var2 = 0; var2 < 20; ++var2)
        {
            if (v[var2] == 0)
            {
                j1(1);
                v[var2] = var1;
                v1(var1);
                w1(var1);
                return;
            }
        }

    }

    [FunctionName("l")]
    public int l1(int var1)
    {
        return v[var1];
    }

    [FunctionName("v")]
    private void v1(int var1)
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

    [FunctionName("j")]
    public void j1()
    {
        F = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - (long)c;
    }

    [FunctionName("k")]
    public void k1()
    {
        if (F != 0L)
        {
            G = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            a = G - F;
            if (a <= 360000000L)
            {
                c = (int)a;
            }
        }
    }

    [FunctionName("m")]
    public void LoadSlot(int var1)
    {
        byte[] var2 = new byte[4096];
        if ((var2 = ScratchPadManager.Read(11 + var1 * 4096, var2.Length)) == null)
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

        for (var5 = 0; var5 < D.GetLength(0); ++var5)
        {
            D[var5, 0] = var2[var7++] & 255;
            D[var5, 1] = var2[var7++] & 255;
            D[var5, 2] = var2[var7++] & 255;
            D[var5, 3] = var2[var7++] & 255;
            D[var5, 4] = var2[var7++] & 255;
            D[var5, 5] = var2[var7++] & 255;
            D[var5, 6] = var2[var7++] & 255;
            D[var5, 7] = var2[var7++] & 255;
            D[var5, 8] = var2[var7++] & 255;
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
            this.E[var5] = var2[var7++] & 255;
        }

        this.H = var2[var7++] & 255;
        this.I = var2[var7++] & 255;
        this.I |= var2[var7++] << 8 & '\uffff';
        this.I |= var2[var7++] << 16 & 16777215;
        this.I |= var2[var7++] << 24;
        this.K = var2[var7++] & 255;

        for (var5 = 0; var5 < this.y.Length; ++var5)
        {
            this.y[var5] = var2[var7++] & 255;
            this.z[var5] = var2[var7++] & 255;
            this.A[var5] = var2[var7++] & 255;
        }

        for (var5 = 0; var5 < this.B.Length; ++var5)
        {
            this.B[var5] = var2[var7++] & 255;
        }

        this.C = var2[var7] & 255;
        j1();
    }

    [FunctionName("n")]
    public void n1(int var1)
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

        for (var6 = 0; var6 < D.GetLength(0); ++var6)
        {
            var2[var8++] = (byte)D[var6, 0];
            var2[var8++] = (byte)D[var6, 1];
            var2[var8++] = (byte)D[var6, 2];
            var2[var8++] = (byte)D[var6, 3];
            var2[var8++] = (byte)D[var6, 4];
            var2[var8++] = (byte)D[var6, 5];
            var2[var8++] = (byte)D[var6, 6];
            var2[var8++] = (byte)D[var6, 7];
            var2[var8++] = (byte)D[var6, 8];
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
            var2[var8++] = (byte)this.E[var6];
        }

        var2[var8++] = (byte)this.H;
        var2[var8++] = (byte)(this.I & 255);
        var2[var8++] = (byte)(this.I >> 8 & 255);
        var2[var8++] = (byte)(this.I >> 16 & 255);
        var2[var8++] = (byte)(this.I >> 24 & 255);
        var2[var8++] = (byte)this.K;

        for (var6 = 0; var6 < this.y.Length; ++var6)
        {
            var2[var8++] = (byte)(this.y[var6] & 255);
            var2[var8++] = (byte)(this.z[var6] & 255);
            var2[var8++] = (byte)(this.A[var6] & 255);
        }

        for (var6 = 0; var6 < this.B.Length; ++var6)
        {
            var2[var8++] = (byte)(this.B[var6] & 255);
        }

        var2[var8] = (byte)this.C;
        ScratchPadManager.Write(11 + var1 * 4096, var2);
    }

    [FunctionName("l")]
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
        H = 0;

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
            E[var1] = 0;
        }

        for (var1 = 0; var1 < D.GetLength(0); ++var1)
        {
            D[var1, 0] = 0;
            D[var1, 1] = 0;
            D[var1, 2] = 0;
            D[var1, 3] = 0;
            D[var1, 4] = 0;
            D[var1, 5] = 0;
            D[var1, 6] = 0;
            D[var1, 7] = 0;
            D[var1, 8] = 0;
        }

        this.I = 0;
        this.K = 0;

        for (var1 = 0; var1 < this.y.Length; ++var1)
        {
            this.y[var1] = 0;
            this.z[var1] = 0;
            this.A[var1] = 0;
        }

        for (var1 = 0; var1 < this.B.Length; ++var1)
        {
            this.B[var1] = 0;
        }

        this.C = 0;
        this.s = 0;
        this.F = 0L;
        this.G = 0L;
        this.a = 0L;
        j1();
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

    [FunctionName("m")]
    public int GetStoryId()
    {
        return _storyId;
    }

    [FunctionName("n")]
    public int n1()
    {
        return l;
    }

    [FunctionName("o")]
    public int[] o1()
    {
        return m;
    }

    [FunctionName("p")]
    public int[] p1()
    {
        return n;
    }

    [FunctionName("q")]
    public int[] SetEventStates()
    {
        return o;
    }

    [FunctionName("r")]
    public int[] r1()
    {
        return p;
    }

    [FunctionName("s")]
    public int[] GetQuestionBits()
    {
        return _questionBits;
    }

    [FunctionName("t")]
    public int[] t1()
    {
        return r;
    }

    [FunctionName("u")]
    public void u1()
    {
        byte[] var1 = new byte[6];
        byte[] var2 = new byte[6];
        var1 = ScratchPadManager.Read(5, var1.Length);

        for (int var3 = 0; var3 < 6; ++var3)
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

    [FunctionName("v")]
    public void v1()
    {
        byte[] var1 = new byte[6];
        var1 = ScratchPadManager.Read(5, var1.Length);

        for (int var2 = 0; var2 < i.Length; ++var2)
        {
            i[var2] = var1[var2] & 255;
        }
    }

    [FunctionName("w")]
    public bool w1()
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

    [FunctionName("o")]
    public void o1(int var1)
    {
        H = var1;
    }

    [FunctionName("x")]
    public int x1()
    {
        return H;
    }

    [FunctionName("p")]
    public void p1(int var1)
    {
        this.I = var1;
    }

    [FunctionName("y")]
    public int y1()
    {
        return this.I;
    }

    [FunctionName("q")]
    public void q1(int var1)
    {
        this.J = var1;
    }

    [FunctionName("z")]
    public int z1()
    {
        return this.J;
    }

    [FunctionName("A")]
    public void A1()
    {
        this.K = 1;
    }

    [FunctionName("B")]
    public int B1()
    {
        return this.K;
    }

    [FunctionName("a")]
    public void a1(int var1, int var2, int var3, int var4)
    {
        this.j1(var1, var2);
        this.k1(var1, var3);
        this.l1(var1, var4);
    }

    [FunctionName("j")]
    private void j1(int var1, int var2)
    {
        this.y[var1] = var2;
    }

    [FunctionName("r")]
    public int r1(int var1)
    {
        return this.y[var1];
    }

    [FunctionName("k")]
    private void k1(int var1, int var2)
    {
        this.z[var1] = var2;
    }

    [FunctionName("s")]
    public int s1(int var1)
    {
        return this.z[var1];
    }

    [FunctionName("l")]
    private void l1(int var1, int var2)
    {
        this.A[var1] = var2;
    }

    [FunctionName("t")]
    public int t1(int var1)
    {
        return this.A[var1];
    }

    [FunctionName("C")]
    public void C1()
    {
        for (int var1 = 0; var1 < this.B.Length; ++var1)
        {
            this.B[var1] = 0;
        }

    }

    [FunctionName("w")]
    private void w1(int var1)
    {
        for (int var2 = 0; var2 < this.B.Length; ++var2)
        {
            if (this.B[var2] == 0)
            {
                this.B[var2] = var1;
                return;
            }
        }

    }

    [FunctionName("i")]
    public void i1(int var1, int var2)
    {
        this.B[var1] = var2;
    }

    [FunctionName("u")]
    public int u1(int var1)
    {
        return this.B[var1];
    }

    [FunctionName("D")]
    public void D1()
    {
        this.C = 1;
    }

    [FunctionName("E")]
    public int E1()
    {
        return this.C;
    }
}
