using com.nttdocomo.ui;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using DocomoLayton.game;
using DocomoLayton.game.Managers;
using DocomoLayton.game.Resources;
using DocomoLayton.nazo;

namespace DocomoLayton.scene;

[ClassName("scene", "r")]
public abstract class ControlScene : IScene
{
    [MemberName("b")]
    public static int width = 320;
    [MemberName("c")]
    public static int height = 240;
    [MemberName("d")]
    public static int centerPosX;
    [MemberName("e")]
    public static int centerPosY;

    [MemberName("f")]
    protected Image f;

    [MemberName("g")]
    public nazo.PuzzleManager g;

    [MemberName("a")]
    private nazo.PuzzleManager a;
    [MemberName("v")]
    private nazo.PuzzleFactory[] v = null;
    [MemberName("w")]
    private int w;
    [MemberName("x")]
    private nazo.PuzzleFactory x = null;
    [MemberName("y")]
    private int y;
    [MemberName("z")]
    private int z;
    [MemberName("A")]
    private int A;
    [MemberName("B")]
    private int[] B = null;
    [MemberName("C")]
    private long[] C;
    [MemberName("D")]
    private int D;
    [MemberName("E")]
    private long E = 0L;

    [MemberName("F")]
    private static int F;

    [MemberName("G")]
    private int G;
    [MemberName("H")]
    private int H;
    [MemberName("I")]
    private int I;
    [MemberName("J")]
    private nazo.PuzzleFactory J = null;
    [MemberName("K")]
    private nazo.PuzzleFactory[] K = null;
    [MemberName("L")]
    private nazo.PuzzleFactory L = null;
    [MemberName("M")]
    private nazo.PuzzleFactory M;
    [MemberName("N")]
    private nazo.PuzzleFactory N;
    [MemberName("O")]
    private nazo.PuzzleFactory O;
    [MemberName("P")]
    private nazo.PuzzleFactory P;
    [MemberName("Q")]
    private nazo.PuzzleFactory Q;
    [MemberName("R")]
    private nazo.PuzzleFactory R;
    [MemberName("S")]
    private int S;

    [MemberName("T")]
    private static int _questionId;

    [MemberName("U")]
    private int U;
    [MemberName("V")]
    private int[] _pikaratAmounts;
    [MemberName("W")]
    private bool W;

    [MemberName("h")]
    public static bool _isEncountered;
    [MemberName("i")]
    public static bool _isSolved;
    [MemberName("j")]
    public static int _hintCount;
    [MemberName("k")]
    public static int _failCount;
    [MemberName("l")]
    public static int l;
    [MemberName("m")]
    public static int m;

    [MemberName("X")]
    private int X;
    [MemberName("Y")]
    private int Y;
    [MemberName("Z")]
    private JavaString Z = "";
    [MemberName("aa")]
    private JavaString aa = "";
    [MemberName("ab")]
    private JavaString[] _hintTexts = new JavaString[] { "", "", "" };
    [MemberName("ac")]
    private JavaString[] ac = new JavaString[] { "", "" };
    [MemberName("ad")]
    private Image[] ad = null;
    [MemberName("ae")]
    private Image ae;
    [MemberName("af")]
    private Image af;
    [MemberName("ag")]
    private Image ag;
    [MemberName("ah")]
    private Image ah;
    [MemberName("ai")]
    private Image ai;
    [MemberName("aj")]
    private Image[] aj = null;
    [MemberName("ak")]
    private Image ak = null;

    [MemberName("n")]
    protected MediaSound[] n;

    [MemberName("al")]
    private PalettedImage[] al = null;

    [MemberName("o")]
    public static int layoutType;
    [MemberName("p")]
    public static int[][] resourcePositions;
    [MemberName("q")]
    public static int[][] keyboardAreas;
    [MemberName("r")]
    public static int[] r2;
    [MemberName("s")]
    public static int[] s;

    [MemberName("am")]
    private bool am;

    [MemberName("t")]
    protected ScriptTextResource[] t = new ScriptTextResource[3];

    [MemberName("an")]
    private int _pikarat;
    [MemberName("ao")]
    private int ao = 0;
    [MemberName("ap")]
    private int ap = 0;

    [MemberName("aq")]
    private static int[][] aq;

    [MemberName("u")]
    protected ImageResource[][] u;

    [MemberName("ar")]
    private int ar = -250;

    [FunctionName("a")]
    public abstract void a1(ScreenResource var1);

    [FunctionName("b")]
    public abstract void b1();

    [FunctionName("c")]
    public abstract void c1();

    [FunctionName("d")]
    public abstract void d1();

    [FunctionName("e")]
    public abstract void e1();

    [FunctionName("f")]
    public abstract void f1();

    [FunctionName("a")]
    public abstract int a1(GameContext var1, object[] var2);

    [FunctionName("d")]
    public abstract void d1(GameContext var1);

    [FunctionName("b")]
    private static int b1(int var0, int var1)
    {
        return var0 + Helper.GetRandomInt(var1);
    }

    [FunctionName("b")]
    private void b1(int var1)
    {
        H = G;
        G = var1;
    }

    [FunctionName("a")]
    protected JavaString a1(GameContext var1, nazo.PuzzleFactory var2)
    {
        JavaString var3 = "";
        if (var1.IsKeyPressed(Display.KEY_MAIN))
        {
            var3 = var2.h1();
        }
        else if (var2.b1(var1))
        {
            AudioManager.b1(1, n[8], 100);
        }

        var2.c1();
        return var3;
    }

    [FunctionName("b")]
    protected JavaString b1(GameContext var1, nazo.PuzzleFactory var2)
    {
        JavaString var3 = "";
        if (var1.IsKeyPressed(Display.KEY_MAIN))
        {
            var3 = var2.h1();
        }
        else if (var2.a1(var1))
        {
            AudioManager.b1(1, n[8], 100);
        }

        var2.c1();
        return var3;
    }

    [FunctionName("e")]
    protected JavaString e1(GameContext var1)
    {
        if (A == 0)
        {
            b1(1);
            ap = -1;
            d1();
            e1();
            L.g1();

            for (int var4 = w; var4 < v.Length; ++var4)
            {
                v[var4].f1();
            }

            O.b1();
            O.f1();
            L.a2 = -1;
            L.b1("return");
            L.c1();
            return "return";
        }
        else if (A > 0)
        {
            --A;
            c1(var1, L);
            return "pre_return";
        }
        else if (A < 0)
        {
            if (z <= 0)
            {
                if (z == 0)
                {
                    L.a2 = -1;
                    L.b1("reset");
                    L.c1();
                }
            }
            else
            {
                --z;
            }

            JavaString var2;
            if ((var2 = c1(var1, L)).Equals("return"))
            {
                AudioManager.b1(1, n[2], 100);
                A = 5;
                var2 = "pre_return";
                d1();
                e1();

                for (int var3 = w; var3 < v.Length; ++var3)
                {
                    v[var3].f1();
                }

                L.f1();
            }
            else if (var2.Equals("reset"))
            {
                AudioManager.b1(1, n[2], 100);
                z = 5;
            }
            else if (var2.Equals("answer"))
            {
                AudioManager.b1(1, n[1], 100);
                z = 5;
            }

            return var2;
        }
        else
        {
            return "";
        }
    }

    [FunctionName("a")]
    protected void a1(GameContext var1, bool var2)
    {
        if (var2)
        {
            y = 0;
        }
        else
        {
            y = 1;
        }

        b1(4);
        a1(0, B[1]);
        a1(1, B[2]);
        a1(2, B[3]);
        a1(3, B[4]);
        a1(4, B[5]);
        a1(5, B[6]);
        a1(6, B[8]);
        var1.ScreenResource.ExecuteTransition(0);
    }

    [ConstructorName("r")]
    protected ControlScene()
    {
    }

    [FunctionName("a")]
    public void a1(nazo.PuzzleManager var1, nazo.PuzzleManager var2, int var3)
    {
        a = var1;
        g = var2;
        F = var3;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        _questionId = g._intValues[0];
        a1(gameContext, _questionId);
        X = gameContext.SaveData.c1();
        Y = gameContext.SaveData.b1();
        gameContext.RoomData.SetQuestionBit(_questionId, 1);
        centerPosX = (240 - width) / 2;
        centerPosY = (240 - height) / 2;
        LoadTexts();
        j1();
        k1();
        int var3 = a1(gameContext, g._objects);
        v = new nazo.PuzzleFactory[g._objectCount - var3];
        w = 0;

        int var4;
        for (var4 = var3; var4 < g._objectCount; ++var4)
        {
            v[var4 - var3] = (nazo.PuzzleFactory)g._objects[var4];
        }

        if (var3 < g._objectCount && v[0].d == 2)
        {
            w = 1;
            if (_failCount == 0 && m == 0)
            {
                x = v[0];
            }
        }

        a1(var2);
        N.a1(var2, centerPosX, centerPosY);
        M.a1(var2, centerPosX, centerPosY);
        O.a1(var2, centerPosX, centerPosY);
        L.a1(var2, centerPosX, centerPosY);
        P.a1(var2, centerPosX, centerPosY);
        R.a1(var2, centerPosX, centerPosY);
        if (x != null)
        {
            x.a1(var2, centerPosX, centerPosY);
        }

        for (var4 = w; var4 < v.Length; ++var4)
        {
            v[var4].a1(var2, centerPosX, centerPosY);
        }

        c1(var2);
        b1(var2);
        g1(gameContext);
        gameContext.RoomData.SetPlayerState(1);
        _pikarat = _pikaratAmounts[l];
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        _pikaratAmounts = null;
        Z = "";
        aa = "";
        if (_hintTexts != null)
        {
            _hintTexts[0] = "";
            _hintTexts[1] = "";
            _hintTexts[2] = "";
        }
        else
        {
            _hintTexts = new JavaString[3];
            _hintTexts[0] = "";
            _hintTexts[1] = "";
            _hintTexts[2] = "";
        }

        if (ac != null)
        {
            ac[0] = "";
            ac[1] = "";
        }
        else
        {
            ac = new JavaString[2];
            ac[0] = "";
            ac[1] = "";
        }

        if (J != null)
        {
            J.Reset();
            J = null;
        }

        f1();
        if (x != null)
        {
            x = null;
        }

        int var2;
        if (v != null)
        {
            for (var2 = 0; var2 < v.Length; ++var2)
            {
                if (v[var2] != null)
                {
                    v[var2].Reset();
                    v[var2] = null;
                }
            }

            v = null;
        }

        if (L != null)
        {
            L.Reset();
            L = null;
        }

        if (O != null)
        {
            O.Reset();
            O = null;
        }

        if (M != null)
        {
            M.Reset();
            M = null;
        }

        if (N != null)
        {
            N.Reset();
            N = null;
        }

        if (P != null)
        {
            P.Reset();
            P = null;
        }

        if (Q != null)
        {
            Q.Reset();
            Q = null;
        }

        if (R != null)
        {
            R.Reset();
            R = null;
        }

        if (u != null)
        {
            for (var2 = 0; var2 < u[0].Length; ++var2)
            {
                if (u[0][var2] != null)
                {
                    u[0][var2].d();
                    u[0][var2] = null;
                }
            }

            u[0] = null;

            for (var2 = 0; var2 < u[1].Length; ++var2)
            {
                if (u[1][var2] != null)
                {
                    u[1][var2].d();
                    u[1][var2] = null;
                }
            }

            u[1] = null;

            for (var2 = 0; var2 < u[2].Length; ++var2)
            {
                if (u[2][var2] != null)
                {
                    u[2][var2].d();
                    u[2][var2] = null;
                }
            }

            u[2] = null;
            u = (ImageResource[][])null;
        }

        if (K != null)
        {
            K[0].Reset();
            K[1].Reset();
            K[0] = null;
            K[1] = null;
            K = null;
        }

        if (a != null)
        {
            a.Reset();
            a = null;
        }

        if (g != null)
        {
            g.Reset();
            g = null;
        }

        ad = a1(ad);
        ae = a1(ae);
        ae = a1(ae);
        af = a1(af);
        ag = a1(ag);
        f = null;
        ah = a1(ah);
        ai = a1(ai);
        aj = a1(aj);
        ak = a1(ak);

        for (var2 = 0; var2 < al.Length; ++var2)
        {
            if (al[var2] != null)
            {
                al[var2].Dispose();
                al[var2] = null;
            }
        }

        al = null;
        C = null;
        B = null;
        n[1] = null;
        n[2] = null;
        n[8] = null;

        for (var2 = 0; var2 < 30; ++var2)
        {
            if (n[var2] != null)
            {
                n[var2].Dispose();
                n[var2] = null;
            }
        }
    }

    [FunctionName("a")]
    public bool a1(int var1)
    {
        if (C[var1] == 0L)
        {
            return false;
        }
        else
        {
            if (C[var1] <= E)
            {
                C[var1] = 0L;
            }

            return C[var1] == 0L;
        }
    }

    [FunctionName("a")]
    public void a1(int var1, int var2)
    {
        if (C == null)
        {
            C = new long[7];
        }

        C[var1] = E + (long)var2;
    }

    [FunctionName("b")]
    public bool Update(GameContext var1)
    {
        ++this.E;
        if (this.E >= long.MaxValue)
        {
            this.E = 0L;
        }

        ScreenResource var2 = var1.ScreenResource;
        switch (this.ao)
        {
            case 1:
                if (var2._transitionState != 2)
                {
                    return true;
                }

                this.ao = 0;
                break;
            case 2:
                if (var2._transitionState != 2)
                {
                    return true;
                }

                this.ao = 0;
                var2.ExecuteTransition(1);
                break;
        }

        PuzzleResource var3;
        int var4;
        String var6;
        int var7;
        switch (this.G)
        {
            case 0:
                if (var2._transitionState == 3)
                {
                    this.O.g1();
                    ((KeyboardResource)this.J.a1(this.J.e - 1).k[3]).a1(this.GetPikarat().ToString());
                    ((KeyboardResource)this.J.a1(this.J.e - 1).k[4]).a1(this.X);
                }
                else if (this.J.c1())
                {
                    if (this.J.a2 == 1)
                    {
                        var3 = this.J.a1(1);
                        if (0 < _failCount && _failCount < this._pikaratAmounts.Length)
                        {
                            if (this.GetPikarat() < this._pikarat)
                            {
                                if (this._pikaratAmounts[_failCount - 1] == this._pikarat)
                                {
                                    AudioManager.b1(1, this.n[3], 100);
                                    this.D = 2;
                                }

                                --this._pikarat;
                                --this.D;
                            }
                            else
                            {
                                this._pikarat = this.GetPikarat();
                                if (this.D <= 0)
                                {
                                    AudioManager.a1(1);
                                }

                                --this.D;
                            }

                           ((KeyboardResource)var3.k[1]).a1(this._pikarat.ToString());
                        }
                        else
                        {
                            ((KeyboardResource)var3.k[1]).a1(this.GetPikarat().ToString());
                        }

                        if (var1.IsKeyPressed(1048576) && (this._pikarat == this.GetPikarat() || this._pikarat == 0))
                        {
                            var3.y = 1;
                            l = _failCount;
                            AudioManager.a1(1);
                            AudioManager.a1(0, this.n[0], 100);
                        }
                    }

                    if (var2._transitionState == 0)
                    {
                        if (var1.IsKeyPressed(1048576) && !this.t[0].d())
                        {
                            if (this.am)
                            {
                                AudioManager.b1(1, this.n[1], 100);
                                this.am = false;
                            }

                            var2.ExecuteTransition(0);
                        }
                    }
                    else if (var2._transitionState == 2)
                    {
                        this.J.g1();
                        this.d1();
                        this.e1();
                        var2.ExecuteTransition(1);

                        for (var7 = this.w; var7 < this.v.Length; ++var7)
                        {
                            this.v[var7].b1();
                            this.v[var7].f1();
                        }

                        this.O.b1();
                        this.d1(_hintCount);
                        this.O.f1();
                        this.b1(1);
                        this.ap = -1;
                    }
                }
                else if (_isSolved && this.J.a2 == this.J.e - 1 && this.W)
                {
                    var3 = null;
                    AudioManager.a1(0, this.n[0], 100);
                    this.W = false;
                }
                break;
            case 1:
                if (this.ap > 0)
                {
                    --this.ap;
                }
                else if (this.ap == 0)
                {
                    if (this.x != null && _failCount == 0 && m == 0)
                    {
                        this.b1(13);
                        this.O.g1();
                        this.x.f1();
                        this.x.c1();
                        m = 1;
                    }
                    else
                    {
                        this.b1(2);
                        this.b1();
                        this.O.g1();
                        this.L.f1();
                        this.z = -1;
                        this.A = -1;
                    }
                }
                else
                {
                    if ((var6 = this.a1(var1, this.O)).Equals(""))
                    {
                        var6 = c1(var1, this.O);
                    }

                    if (!var6.Equals(""))
                    {
                        if (var6.Equals("hint"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            this.b1(var1, true);
                        }
                        else if (var6.Equals("answer"))
                        {
                            this.ap = 5;
                            AudioManager.b1(1, this.n[1], 100);
                        }
                        else if (var6.Equals("giveup"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            var2.ExecuteTransition(0);
                            this.b1(3);
                        }
                        else if (var6.Equals("question"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            this.b1(0);
                            this.J.b1();
                            this.J.a2 = this.J.e - 1;
                            this.am = true;
                            ((KeyboardResource)this.J.a1(this.J.a2).k[4]).a1(this.X);
                            this.J.f1();
                            var2.ExecuteTransition(0);
                            this.ao = 1;
                        }
                    }

                    for (var4 = this.w; var4 < this.v.Length; ++var4)
                    {
                        this.v[var4].c1();
                    }

                    this.l1();
                }
                break;
            case 2:
                if (var2._transitionState != 1)
                {
                    if (var2._transitionState == 2)
                    {
                        var2.ExecuteTransition(1);
                        this.x.g1();
                        this.x.b1();
                        this.e1();
                        this.b1();
                        this.L.f1();
                    }
                    else if (var2._transitionState != 3)
                    {
                        this.d1(var1);

                        for (var7 = this.w; var7 < this.v.Length; ++var7)
                        {
                            if (this.v[var7].b1(var1))
                            {
                                AudioManager.b1(1, this.n[8], 100);
                            }

                            this.v[var7].c1();
                        }
                    }
                }
                break;
            case 3:
                if (var2._transitionState != 1)
                {
                    if (var2._transitionState == 2)
                    {
                        var2.ExecuteTransition(1);
                        this.P.b1();
                        this.O.b1();

                        for (var7 = this.w; var7 < this.v.Length; ++var7)
                        {
                            this.v[var7].b1();
                            this.v[var7].g1();
                        }

                        this.P.f1();
                    }
                    else if (var2._transitionState != 3 && !(var6 = this.a1(var1, this.P)).Equals(""))
                    {
                        if (var6.Equals("yes"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            this.c1(var1, false);
                            this.c1();
                        }
                        else if (var6.Equals("no"))
                        {
                            AudioManager.b1(1, this.n[2], 100);
                            this.b1(1);
                            this.ap = -1;
                            this.P.b1();
                            this.e1();

                            for (var4 = this.w; var4 < this.v.Length; ++var4)
                            {
                                this.v[var4].f1();
                            }

                            this.O.f1();
                            var2.ExecuteTransition(1);
                        }
                    }
                }
                break;
            case 4:
                if (var2._transitionState != 1)
                {
                    if (var2._transitionState == 2)
                    {
                        this.L.a2 = -1;
                        this.L.b1("answer");
                        this.L.c1();
                        var1.b1(3);
                        if (this.a1(0))
                        {
                            if (this.U == 0)
                            {
                                AudioManager.b1(1, this.n[b1(11, 3)], 100);
                            }
                            else
                            {
                                AudioManager.b1(1, this.n[b1(20, 3)], 100);
                            }
                        }

                        if (this.a1(3))
                        {
                            AudioManager.a1(0, 0, 2);
                        }
                        else
                        {
                            switch (AudioManager.c1(0))
                            {
                                case 0:
                                default:
                                    break;
                                case 2:
                                    AudioManager.a1(0, 100);
                                    AudioManager.a1(0);
                                    break;
                            }
                        }

                        if (this.a1(1))
                        {
                            AudioManager.b1(3, this.n[4], 100);
                        }

                        if (this.a1(5))
                        {
                            if (this.y == 0)
                            {
                                AudioManager.b1(1, this.n[5], 100);
                            }
                            else if (this.y == 1)
                            {
                                AudioManager.b1(1, this.n[6], 100);
                            }
                        }

                        if (this.a1(4))
                        {
                            if (this.y == 0)
                            {
                                if (this.U == 0)
                                {
                                    AudioManager.b1(2, this.n[b1(14, 3)], 100);
                                }
                                else
                                {
                                    AudioManager.b1(2, this.n[b1(23, 3)], 100);
                                }
                            }
                            else if (this.y == 1)
                            {
                                if (this.U == 0)
                                {
                                    AudioManager.b1(2, this.n[b1(17, 3)], 100);
                                }
                                else
                                {
                                    AudioManager.b1(2, this.n[b1(26, 3)], 100);
                                }
                            }
                        }

                        if (this.a1(6) && (_isSolved || this.y != 0))
                        {
                            AudioManager.a1(0, this.n[0], 100);
                        }

                        if (this.a1(2))
                        {
                            var2.ExecuteTransition(1);
                            var1.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
                            this.L.b1();
                            this.c1();
                            this.d1();
                            this.O.b1();

                            for (var7 = this.w; var7 < this.v.Length; ++var7)
                            {
                                this.v[var7].b1();
                            }

                            if (this.y == 0)
                            {
                                ((KeyboardResource)this.K[this.y].a1(this.K[this.y].e - 2).k[3]).a1(this.X.ToString());
                            }

                            this.K[this.y].f1();
                        }
                    }
                    else if (var2._transitionState != 3)
                    {
                        this.b1(5);
                        if (this.y == 0)
                        {
                            ((KeyboardResource)(var3 = this.K[this.y].a1(this.K[this.y].e - 4)).k[1]).a1(this.GetPikarat().ToString());
                            ((KeyboardResource)var3.k[2]).a1(this.Y.ToString());
                            this._pikarat = 0;
                        }
                    }
                }
                break;
            case 5:
                if (this.a1(0))
                {
                    if (this.U == 0)
                    {
                        AudioManager.b1(1, this.n[b1(11, 3)], 100);
                    }
                    else
                    {
                        AudioManager.b1(1, this.n[b1(20, 3)], 100);
                    }
                }

                if (this.a1(3))
                {
                    AudioManager.a1(0, 0, 2);
                }
                else
                {
                    switch (AudioManager.c1(0))
                    {
                        case 0:
                        default:
                            break;
                        case 2:
                            AudioManager.a1(0, 100);
                            AudioManager.a1(0);
                            break;
                    }
                }

                if (this.a1(1))
                {
                    AudioManager.b1(3, this.n[4], 100);
                }

                if (this.a1(5))
                {
                    if (this.y == 0)
                    {
                        AudioManager.b1(1, this.n[5], 100);
                    }
                    else if (this.y == 1)
                    {
                        AudioManager.b1(1, this.n[6], 100);
                    }
                }

                if (this.a1(4))
                {
                    if (this.y == 0)
                    {
                        if (this.U == 0)
                        {
                            AudioManager.b1(2, this.n[b1(14, 3)], 100);
                        }
                        else
                        {
                            AudioManager.b1(2, this.n[b1(23, 3)], 100);
                        }
                    }
                    else if (this.y == 1)
                    {
                        if (this.U == 0)
                        {
                            AudioManager.b1(2, this.n[b1(17, 3)], 100);
                        }
                        else
                        {
                            AudioManager.b1(2, this.n[b1(26, 3)], 100);
                        }
                    }
                }

                if (this.a1(6) && (_isSolved || this.y != 0))
                {
                    AudioManager.a1(0, this.n[0], 100);
                }

                if (this.K[this.y].c1())
                {
                    if (this.y == 0)
                    {
                        if (this.K[this.y].a2 == this.K[this.y].e - 4)
                        {
                            if (this._pikarat <= this.GetPikarat())
                            {
                                ((KeyboardResource)(var3 = this.K[this.y].a1(this.K[this.y].e - 4)).k[1]).a1((this.GetPikarat() - this._pikarat).ToString());
                                ((KeyboardResource)var3.k[2]).a1((this.Y + this._pikarat).ToString());
                                if (this._pikarat == 0)
                                {
                                    AudioManager.b1(2, this.n[3], 100);
                                }

                                var4 = this.GetPikarat();
                                if (15 > var4)
                                {
                                    ++this._pikarat;
                                }
                                else if (30 > var4)
                                {
                                    this._pikarat += 2;
                                }
                                else if (45 > var4)
                                {
                                    this._pikarat += 3;
                                }
                                else if (60 > var4)
                                {
                                    this._pikarat += 4;
                                }
                                else if (75 > var4)
                                {
                                    this._pikarat += 5;
                                }
                                else
                                {
                                    this._pikarat += 6;
                                }

                                if (this.GetPikarat() - this._pikarat <= 0)
                                {
                                    this._pikarat = this.GetPikarat();
                                    AudioManager.a1(2);
                                }
                            }
                            else
                            {
                                AudioManager.a1(2);
                            }

                            if (var1.IsKeyPressed(1048576) && this.GetPikarat() - this._pikarat == 0)
                            {
                                AudioManager.a1(2);
                                if (!_isSolved && this.y == 0)
                                {
                                    AudioManager.a1(0, this.n[0], 100);
                                }

                                this.K[this.y].a2 = this.K[this.y].e - 3;
                                var2.ExecuteTransition(0);
                            }
                        }
                        else if (this.K[this.y].a2 == this.K[this.y].e - 1)
                        {
                            if (var1.IsKeyPressed(1048576))
                            {
                                if (!this.t[1 + this.y].d())
                                {
                                    this.K[this.y].a2 = this.K[this.y].e - 2;
                                    var2.ExecuteTransition(0);
                                }

                                if (this.am)
                                {
                                    AudioManager.b1(1, this.n[1], 100);
                                    this.am = false;
                                }
                            }
                        }
                        else if (this.t[1 + this.y].i())
                        {
                            this.M.b1();
                            this.M.f1();
                            this.b1(6);
                        }
                        else if (var1.IsKeyPressed(1048576) && !this.t[1 + this.y].d())
                        {
                            this.M.b1();
                            this.M.f1();
                            this.b1(6);
                        }
                    }
                    else if (var1.IsKeyPressed(1048576) && !this.t[1 + this.y].d())
                    {
                        this.b1(8);
                        var2.ExecuteTransition(0);
                        this._pikarat = this.GetPikarat();
                        if (!_isSolved)
                        {
                            ((KeyboardResource)this.J.a1(1).k[1]).a1(this.GetPikarat().ToString());
                            ++_failCount;
                            if (_failCount >= this._pikaratAmounts.Length)
                            {
                                _failCount = this._pikaratAmounts.Length - 1;
                            }
                        }
                    }
                }
                else if (this.y == 0)
                {
                    if (this.K[this.y].a2 == this.K[this.y].e - 5)
                    {
                        var1.b1(3);
                    }
                }
                else if (this.K[this.y].a2 == this.K[this.y].e - 2)
                {
                    var1.b1(3);
                }
                break;
            case 6:
                if (var2._transitionState == 2)
                {
                    this.M.b1();
                    this.b1(5);
                }
                else if (var2._transitionState == 0)
                {
                    if ((var6 = this.a1(var1, this.M)).Equals(""))
                    {
                        var6 = c1(var1, this.M);
                    }

                    if (!var6.Equals(""))
                    {
                        if (var6.Equals("image"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            var2.ExecuteTransition(0);
                            this.am = true;
                            this.K[this.y].a2 = this.K[this.y].e - 1;
                        }
                        else if (var6.Equals("exit"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            this.c1(var1, true);
                        }

                        this._pikarat = this.GetPikarat();
                    }
                }
                break;
            case 7:
            default:
                if (var1.IsKeyPressed(1048576))
                {
                    if (this.y != 0)
                    {
                        this._pikarat = this.GetPikarat();
                    }

                    this.g1(var1);
                }
                break;
            case 8:
                if (var2._transitionState != 1)
                {
                    if (var2._transitionState == 2)
                    {
                        var2.ExecuteTransition(1);
                        this.K[this.y].g1();
                        this.N.b1();
                        this.N.f1();
                    }
                    else if (var2._transitionState != 3 && !(var6 = this.a1(var1, this.N)).Equals(""))
                    {
                        if (var6.Equals("retry"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            this.h1(var1);
                        }
                        else if (var6.Equals("hint"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            this.b1(var1, true);
                        }
                        else if (var6.Equals("giveup"))
                        {
                            AudioManager.b1(1, this.n[1], 100);
                            this.c1(var1, false);
                        }
                    }
                }
                break;
            case 9:
                this.N.g1();
                this.g1(var1);
                break;
            case 10:
                if (AudioManager.c1(0) == 2)
                {
                    try
                    {
                        AudioManager.a1();
                        switch (F)
                        {
                            case 0:
                                var1.SetCurrentScene(EventScene.GetInstance());
                                break;
                            case 1:
                            case 2:
                                break;
                            default:
                                var1.SetCurrentScene(EventScene.GetInstance());
                                break;
                        }
                    }
                    catch (Exception var5)
                    {
                    }
                }
                break;
            case 11:
                if (var2._transitionState == 2)
                {
                    if (this.Q.h1().Equals("ret"))
                    {
                        if (1 != this.I)
                        {
                            this.g1(var1);
                        }
                        else
                        {
                            this.b1(1);
                            this.ap = -1;
                            this.P.b1();
                            this.O.b1();
                            this.P.g1();
                            this.d1();
                            this.e1();

                            for (var7 = this.w; var7 < this.v.Length; ++var7)
                            {
                                this.v[var7].b1();
                                this.v[var7].f1();
                            }

                            this.d1(_hintCount);
                            this.O.f1();
                            var2.ExecuteTransition(1);
                        }

                        this.Q.b1();
                        this.Q.g1();
                        this.Q.Reset();
                        this.Q = null;
                    }
                    else
                    {
                        this.Q.f1();
                        this.O.g1();
                        var2.ExecuteTransition(1);
                    }
                }
                else if (var2._transitionState != 1)
                {
                    if ((var6 = this.b1(var1, this.Q)).Equals(""))
                    {
                        if (var1.IsKeyPressed(1048576))
                        {
                        }
                    }
                    else if (var6.Equals("lock"))
                    {
                        AudioManager.b1(1, this.n[8], 100);
                        this.R.a2 = 0;
                        this.R.e1();
                        this.R.f1();
                        this.R.c1();
                        this.Q.a1((Image)null);
                        this.b1(12);
                    }
                    else if (var6.Equals("medal"))
                    {
                        this.Q.b1(var6);
                    }
                    else
                    {
                        if (var6.Equals("ret"))
                        {
                            AudioManager.b1(1, this.n[2], 100);
                            if (1 == this.H)
                            {
                                var2.ExecuteTransition(0);
                            }
                            else
                            {
                                var2.ExecuteTransition(0);
                            }

                            return true;
                        }

                        this.Q.b1(var6);
                    }
                }
                break;
            case 12:
                if ((var6 = this.a1(var1, this.R)).Equals(""))
                {
                    if (var1.IsKeyPressed(1048576))
                    {
                    }
                }
                else
                {
                    if (var6.Equals("yes"))
                    {
                        AudioManager.b1(1, this.n[29], 100);
                        ++_hintCount;
                        --this.X;
                        this.b1(var1, false);
                    }
                    else if (var6.Equals("no"))
                    {
                        AudioManager.b1(1, this.n[2], 100);
                    }

                    this.Q.a1(this.f);
                    this.Q.b1("lock");
                    this.R.b1(var6);
                    this.R.g1();
                    this.b1(11);
                }
                break;
            case 13:
                if (this.x.c1())
                {
                    var3 = this.x.a1(this.x.a2);
                    if (var2._transitionState == 0 && var1.IsKeyPressed(1048576))
                    {
                        if (this.x.a2 + 1 >= this.x.e)
                        {
                            var2.ExecuteTransition(0);
                            this.b1(2);
                            this.z = -1;
                            this.A = -1;
                        }
                        else
                        {
                            var3.y = 1;
                        }
                    }
                }
                break;
        }

        return true;
    }

    [FunctionName("a")]
    public static void a1(GameContext var0, int questionId)
    {
        data.RoomData var2 = var0.RoomData;
        _isEncountered = true;
        _isSolved = var2.IsQuestionBitSet(questionId, 2);
        _hintCount = 0;
        if (var2.IsQuestionBitSet(questionId, 8))
        {
            ++_hintCount;
        }

        if (var2.IsQuestionBitSet(questionId, 16))
        {
            ++_hintCount;
        }

        if (var2.IsQuestionBitSet(questionId, 32))
        {
            ++_hintCount;
        }

        _failCount = 0;
        if (var2.IsQuestionBitSet(questionId, 64))
        {
            ++_failCount;
        }

        if (var2.IsQuestionBitSet(questionId, 128))
        {
            ++_failCount;
        }

        l = var0.SaveData.h1(questionId);
        m = var0.SaveData.i1(questionId);
        if (var0.SaveData.g1(questionId) == 2)
        {
            _isSolved = true;
            var2.SetQuestionBit(questionId, 2);
        }
    }

    [FunctionName("f")]
    private void f1(GameContext var1)
    {
        data.RoomData var2 = var1.RoomData;
        if (_isSolved)
        {
            var2.SetQuestionBit(_questionId, 2);
        }

        if (_hintCount >= 1)
        {
            var2.SetQuestionBit(_questionId, 8);
        }

        if (_hintCount >= 2)
        {
            var2.SetQuestionBit(_questionId, 16);
        }

        if (_hintCount >= 3)
        {
            var2.SetQuestionBit(_questionId, 32);
        }

        if (_failCount >= 1)
        {
            var2.SetQuestionBit(_questionId, 64);
        }

        if (_failCount >= 2)
        {
            var2.SetQuestionBit(_questionId, 128);
        }

        if (l >= 1)
        {
            var2.f1(_questionId, 64);
        }

        if (l >= 2)
        {
            var2.f1(_questionId, 128);
        }

        if (var1.SaveData.g1(_questionId) != 2)
        {
            var1.SaveData.SetQuestionPikaratTotal(_questionId, _pikaratAmounts[0]);
            var1.SaveData.SetQuestionPikarat(_questionId, GetPikarat());
            var1.SaveData.SetQuestionType(_questionId, g._layoutElementType - 1);
            var1.SaveData.SetQuestionHintCount(_questionId, _hintCount);
            var1.SaveData.SetQuestionFailCount(_questionId, _failCount);
            var1.SaveData.g1(_questionId, l);
            var1.SaveData.h1(_questionId, m);
            if (_isEncountered)
            {
                var1.SaveData.SetQuestionState(_questionId, 1);
            }

            if (_isSolved)
            {
                var1.SaveData.SetQuestionState(_questionId, 2);
            }
        }

        int var3;
        if ((var3 = var1.SaveData.g1(_questionId)) == 1 || var3 == 2)
        {
            var1.SaveData.a1(_questionId, var3, var1);
            var1.SaveData.w1();
        }

        int var4 = 0;
        int var5 = 0;

        for (int var6 = 0; var6 < 135; ++var6)
        {
            if (var1.SaveData.g1(var6 + 1) != 0)
            {
                ++var4;
                if (var1.SaveData.g1(var6 + 1) == 2)
                {
                    ++var5;
                }
            }
        }

        var1.SaveData.d1(var4);
        var1.SaveData.SetQuestionsSolvedCount(var5);
    }

    [FunctionName("g")]
    public int g1()
    {
        return G;
    }

    [FunctionName("a")]
    private void a1()
    {
        I = G;
    }

    [FunctionName("h")]
    public int GetPikarat()
    {
        return _pikaratAmounts[_failCount];
    }

    [FunctionName("i")]
    private void LoadTexts()
    {
        Z = g._stringValues[0];
        aa = g._stringValues[1];
        _hintTexts[0] = g._stringValues[2];
        _hintTexts[1] = g._stringValues[3];
        _hintTexts[2] = g._stringValues[4];
        ac[0] = g._stringValues[5];
        ac[1] = g._stringValues[6];
    }

    [FunctionName("j")]
    private void j1()
    {
        U = g._intValues[1];
        _pikaratAmounts = new int[g._intValues[2]];

        int var1;
        for (var1 = 0; var1 < g._intValues[2]; ++var1)
        {
            _pikaratAmounts[var1] = g._intValues[3 + var1];
        }

        ai = g.GetLoadedImage(g._intValues[3 + var1]);
        S = g._intValues[3 + var1 + 1];
        n = new MediaSound[30];

        for (var1 = 0; var1 < 30; ++var1)
        {
            n[var1] = a.GetLoadedSound(a._intValues[var1 + a._intValues[0]]);
        }

        n[1] = GameContext.FileManager.GetLoadedSound("se_011.mld");
        n[2] = GameContext.FileManager.GetLoadedSound("se_004.mld");
        n[8] = GameContext.FileManager.GetLoadedSound("se_018.mld");
        B = new int[9];

        for (var1 = 0; var1 < 8; ++var1)
        {
            B[var1 + 1] = a._intValues[a._intValues[0] + 30 + var1];
        }
    }

    [FunctionName("k")]
    private void k1()
    {
        ad = new Image[7];
        ad[0] = a.GetLoadedImage(a._intValues[1]);
        ad[3] = a.GetLoadedImage(a._intValues[2]);
        ad[4] = a.GetLoadedImage(a._intValues[3]);
        ad[5] = a.GetLoadedImage(a._intValues[4]);
        ad[1] = a.GetLoadedImage(a._intValues[5]);
        ad[2] = a.GetLoadedImage(a._intValues[6]);
        ad[6] = a.GetLoadedImage(a._intValues[7]);
        af = a.GetLoadedImage(a._intValues[8]);
        ag = a.GetLoadedImage(a._intValues[9]);
        ae = a.GetLoadedImage(a._intValues[10]);
        f = GameContext.FileManager.GetLoadedImage("i_cur.gif");
        ah = a.GetLoadedImage(a._intValues[12]);
        aj = new Image[3];
        aj[0] = a.GetLoadedImage(a._intValues[13]);
        aj[1] = a.GetLoadedImage(a._intValues[14]);
        aj[2] = a.GetLoadedImage(a._intValues[28]);
        al = new PalettedImage[8];
        al[0] = a.GetLoadedPalettedImage(a._intValues[15]);
        al[1] = a.GetLoadedPalettedImage(a._intValues[16]);
        al[2] = a.GetLoadedPalettedImage(a._intValues[17]);
        al[3] = a.GetLoadedPalettedImage(a._intValues[18]);
        al[4] = a.GetLoadedPalettedImage(a._intValues[19]);
        al[5] = a.GetLoadedPalettedImage(a._intValues[20]);
        al[6] = a.GetLoadedPalettedImage(a._intValues[21]);
        al[7] = a.GetLoadedPalettedImage(a._intValues[29]);
        N = (nazo.PuzzleFactory)a._objects[0];
        N.a1(f);
        O = (nazo.PuzzleFactory)a._objects[1];
        O.a1(f);
        P = (nazo.PuzzleFactory)a._objects[2];
        P.a1(f);
        ImageResource var1 = P.ImageResource;
        ResourceBase[] var2 = new ResourceBase[2];

        JavaString var3;
        for (var3 = _questionId.ToString(); var3.Length < 3; var3 = "0" + var3)
        {
        }

        var2[0] = TextResource.Create(Z);
        var2[0].SetPosition(resourcePositions[0][0], resourcePositions[0][1]);
        ((TextResource)var2[0]).SetAnchorType(1);
        var2[0].SetIsVisible(true);
        var2[1] = TextResource.Create("ナゾ " + Helper.ConvertStringDigitsWide(var3));
        var2[1].SetPosition(resourcePositions[1][0], resourcePositions[1][1]);
        var2[1].SetIsVisible(true);
        var1.AddChild(var2[0]);
        var1.AddChild(var2[1]);
        M = (nazo.PuzzleFactory)a._objects[3];
        M.a1(f);
        L = (nazo.PuzzleFactory)a._objects[S];
        R = (nazo.PuzzleFactory)a._objects[8];
        R.a1(f);
    }

    [FunctionName("b")]
    private void b1(ScreenResource var1)
    {
        JavaString var2;
        for (var2 = _questionId.ToString(); var2.Length < 3; var2 = "0" + var2)
        {
        }

        J = new nazo.PuzzleFactory();
        J.a1(var1, "ナゾ起動時アニメ", 2, (Image)null);
        ResourceBase[] var3;
        (var3 = new ResourceBase[3])[0] = ImageResource.Create(ae);
        var3[1] = KeyboardResource.Create(ad[0], keyboardAreas[0][0], keyboardAreas[0][1], keyboardAreas[0][2], var2, keyboardAreas[0][3]);
        var3[1].SetPosition(resourcePositions[2][0], resourcePositions[2][1]);
        var3[2] = TextResource.Create("ナゾ " + Helper.ConvertStringDigitsWide(var2) + "  " + Z);
        var3[2].SetPosition(resourcePositions[3][0], resourcePositions[3][1]);
        ((TextResource)var3[2]).SetAnchorType(1);
        J.a1(var3, 30, 2, 0, 0);
        (var3 = new ResourceBase[4])[0] = ImageResource.Create(af);
        var3[1] = KeyboardResource.Create(ad[6], keyboardAreas[1][0], keyboardAreas[1][1], keyboardAreas[1][2], "" + _pikaratAmounts[l], keyboardAreas[1][3]);
        ((KeyboardResource)var3[1]).b1(2);
        var3[1].SetPosition(resourcePositions[4][0], resourcePositions[4][1]);
        var3[2] = KeyboardResource.Create(ad[1], keyboardAreas[2][0], keyboardAreas[2][1], keyboardAreas[2][2], _pikaratAmounts[0]);
        ((KeyboardResource)var3[2]).b1(2);
        var3[2].SetPosition(resourcePositions[5][0], resourcePositions[5][1]);
        var3[3] = KeyboardResource.Create(ad[3], keyboardAreas[3][0], keyboardAreas[3][1], keyboardAreas[3][2], Y);
        ((KeyboardResource)var3[3]).b1(2);
        var3[3].SetPosition(resourcePositions[6][0], resourcePositions[6][1]);
        J.a1(var3, -1, 2, 0, 0);
        (var3 = new ResourceBase[5])[0] = ImageResource.Create(ag);
        t[0] = ScriptTextResource.Create(aa);
        var3[1] = t[0];
        var3[1].SetPosition(resourcePositions[7][0], resourcePositions[7][1]);
        var3[2] = KeyboardResource.Create(ad[3], keyboardAreas[3][0], keyboardAreas[3][1], keyboardAreas[3][2], var2);
        ((KeyboardResource)var3[2]).b1(2);
        var3[2].SetPosition(resourcePositions[8][0], resourcePositions[8][1]);
        var3[3] = KeyboardResource.Create(ad[4], keyboardAreas[4][0], keyboardAreas[4][1], keyboardAreas[4][2], GetPikarat());
        ((KeyboardResource)var3[3]).b1(2);
        var3[3].SetPosition(resourcePositions[9][0], resourcePositions[9][1]);
        var3[4] = c1(0);
        ((KeyboardResource)var3[4]).b1(2);
        var3[4].SetPosition(resourcePositions[10][0], resourcePositions[10][1]);
        J.a1(var3, -1, 2, 0, 0);
        J.a1(var1, centerPosX, centerPosY);
        if (_isSolved)
        {
            J.a1(new int[] { 1 });
        }
    }

    [FunctionName("c")]
    private void c1(ScreenResource var1)
    {
        K = new nazo.PuzzleFactory[2];
        K[0] = (nazo.PuzzleFactory)a._objects[4 + 2 * U];
        K[1] = (nazo.PuzzleFactory)a._objects[5 + 2 * U];

        for (int var2 = 0; var2 < 2; ++var2)
        {
            int var3;
            for (var3 = 0; var3 < K[var2].e; ++var3)
            {
                nazo.PuzzleResource var4 = K[var2].a1(var3);
                int var5 = (width - var4.k[0].GetWidth()) / 2;
                var4.k[0].SetPosition(var5, 0);
            }

            var3 = K[var2].e;
            ResourceBase[] var6;
            JavaString var7;
            if (var2 == 0)
            {
                (var6 = new ResourceBase[3])[0] = ImageResource.Create(aj[2]);

                for (var7 = _questionId.ToString(); var7.Length < 3; var7 = "0" + var7)
                {
                }

                var6[1] = KeyboardResource.Create(ad[1], keyboardAreas[2][0], keyboardAreas[2][1], keyboardAreas[2][2], GetPikarat());
                ((KeyboardResource)var6[1]).b1(2);
                var6[1].SetPosition(resourcePositions[11][0], resourcePositions[11][1]);
                var6[2] = KeyboardResource.Create(ad[2], keyboardAreas[5][0], keyboardAreas[5][1], keyboardAreas[5][2], Y);
                ((KeyboardResource)var6[2]).b1(2);
                var6[2].SetPosition(resourcePositions[12][0], resourcePositions[12][1]);
                K[var2].a1(var6, -1, 2, 0, 0);
                K[var2].a1(ai, 30, 2, 0, 0);
            }

            if (var2 != 0)
            {
                var6 = new ResourceBase[2];
                t[2] = ScriptTextResource.Create(ac[1]);
                var6[1] = t[2];
                var6[1].SetPosition(resourcePositions[16][0], resourcePositions[16][1]);
                var6[0] = ImageResource.Create(aj[var2]);
            }
            else
            {
                var6 = new ResourceBase[4];
                t[1] = ScriptTextResource.Create(ac[0]);
                var6[1] = t[1];
                var6[1].SetPosition(resourcePositions[13][0], resourcePositions[13][1]);
                var6[0] = ImageResource.Create(aj[var2]);

                for (var7 = _questionId.ToString(); var7.Length < 3; var7 = "0" + var7)
                {
                }

                var6[2] = KeyboardResource.Create(ad[3], keyboardAreas[3][0], keyboardAreas[3][1], keyboardAreas[3][2], var7);
                ((KeyboardResource)var6[2]).b1(2);
                var6[2].SetPosition(resourcePositions[14][0], resourcePositions[14][1]);
                var6[3] = c1(2);
                ((KeyboardResource)var6[3]).b1(2);
                var6[3].SetPosition(resourcePositions[15][0], resourcePositions[15][1]);
            }

            K[var2].a1(var6, -1, 1, 0, 0);
            if (var2 == 0)
            {
                K[var2].a1(ai, -1, 1, 0, 0);
                if (_isSolved)
                {
                    K[var2].a1(new int[] { var3 });
                }
            }

            K[var2].a1(var1, centerPosX, centerPosY);
        }
    }

    [FunctionName("c")]
    private KeyboardResource c1(int var1)
    {
        KeyboardResource var2 = null;
        int var3 = X;
        switch (var1)
        {
            case 0:
                var2 = KeyboardResource.Create(ad[4], keyboardAreas[4][0], keyboardAreas[4][1], keyboardAreas[4][2], var3);
                break;
            case 1:
                var2 = KeyboardResource.Create(ad[3], keyboardAreas[3][0], keyboardAreas[3][1], keyboardAreas[3][2], var3);
                break;
            case 2:
                var2 = KeyboardResource.Create(ad[4], keyboardAreas[4][0], keyboardAreas[4][1], keyboardAreas[4][2], var3);
                break;
        }

        return var2;
    }

    [FunctionName("g")]
    private void g1(GameContext var1)
    {
        J.b1();
        O.b1();
        P.b1();
        L.b1();
        c1();
        d1();
        K[0].b1();
        M.b1();
        K[1].b1();
        N.b1();

        for (int var2 = w; var2 < v.Length; ++var2)
        {
            v[var2].b1();
        }

        t[0].j();
        t[1].j();
        t[2].j();
        if (Q != null)
        {
            Q.b1();
        }

        if (x != null)
        {
            x.b1();
        }

        J.f1();
        b1(0);
        AudioManager.a1(0);
        AudioManager.b1(1, n[9], 100);
        am = false;
        W = _isSolved;
        var1.b1(3);
    }

    [FunctionName("c")]
    private static JavaString c1(GameContext var0, nazo.PuzzleFactory var1)
    {
        JavaString var2 = null;
        if ((var2 = var1.b1(var0.f1())) != "")
        {
            var1.c1();
        }

        return var2;
    }

    [FunctionName("b")]
    private void b1(GameContext var1, bool var2)
    {
        if (Q != null)
        {
            Q.b1();
            Q.g1();
            Q.Reset();
            Q = null;
        }

        ImageResource[] var3;
        (var3 = new ImageResource[3])[0] = ImageResource.Create(al[0]);
        var3[1] = ImageResource.Create(var3[0]);
        var3[2] = ImageResource.Create(var3[0]);
        var3[0].ClipRect(s[0], s[1], s[2], s[3]);
        var3[1].ClipRect(s[4], s[5], s[6], s[7]);
        var3[2].ClipRect(s[8], s[9], s[10], s[11]);
        var3[0].SetIsVisible(true);
        var3[1].SetIsVisible(true);
        var3[2].SetIsVisible(true);
        int var4 = s[12];
        int var5 = s[13];
        int var6 = s[14];
        ImageResource[] var7;
        (var7 = new ImageResource[3])[0] = ImageResource.Create(al[1]);
        var7[0].a1(aq[0]);
        var7[1] = ImageResource.Create(var7[0]);
        var7[1].a1(aq[1]);
        var7[2] = ImageResource.Create(var7[0]);
        var7[2].a1(aq[2]);
        var7[0].AddChild(var3[0], s[15], s[16]);
        var7[1].AddChild(var3[1], s[15], s[16]);
        var7[2].AddChild(var3[2], s[15], s[16]);
        var7[0].SetPosition(var4, var5);
        var7[1].SetPosition(var4 + var6, var5);
        var7[2].SetPosition(var4 + var6 * 2, var5);
        ImageResource[] var8;
        (var8 = new ImageResource[9])[0] = ImageResource.Create(al[2]);
        var8[0].a1(aq[0]);
        var8[1] = ImageResource.Create(var8[0]);
        var8[1].a1(aq[1]);
        var8[2] = ImageResource.Create(var8[0]);
        var8[2].a1(aq[2]);
        var8[3] = ImageResource.Create(var8[0]);
        var8[3].a1(aq[0]);
        var8[4] = ImageResource.Create(var8[0]);
        var8[4].a1(aq[1]);
        var8[5] = ImageResource.Create(var8[0]);
        var8[5].a1(aq[2]);
        var8[6] = ImageResource.Create(var8[0]);
        var8[6].a1(aq[0]);
        var8[7] = ImageResource.Create(var8[0]);
        var8[7].a1(aq[1]);
        var8[8] = ImageResource.Create(var8[0]);
        var8[8].a1(aq[2]);
        var8[0].SetPosition(var4, var5);
        var8[1].SetPosition(var4 + var6, var5);
        var8[2].SetPosition(var4 + var6 * 2, var5);
        var8[3].SetPosition(var4, var5);
        var8[4].SetPosition(var4 + var6, var5);
        var8[5].SetPosition(var4 + var6 * 2, var5);
        var8[6].SetPosition(var4, var5);
        var8[7].SetPosition(var4 + var6, var5);
        var8[8].SetPosition(var4 + var6 * 2, var5);
        int var9 = s[17];
        int var10 = s[18];
        KeyboardResource[] var11;
        (var11 = new KeyboardResource[2])[0] = c1(1);
        var11[0].b1(2);
        var11[0].SetPosition(s[19], s[20]);
        var11[1] = c1(1);
        var11[1].b1(2);
        var11[1].SetPosition(s[29], s[30]);
        ImageResource[] var12 = new ImageResource[3];
        ImageResource[] var13 = new ImageResource[3];
        var12[0] = ImageResource.Create(al[7]);
        var12[0].AddChild((ResourceBase)var8[0]);
        var12[0].SetPosition(var9, var10);
        var12[0].a1(aq[0]);
        var13[0] = ImageResource.Create(al[4]);
        var13[0].AddChild((ResourceBase)var8[6]);
        var13[0].SetPosition(var9, var10);
        var13[0].a1(aq[0]);
        var12[1] = ImageResource.Create(var12[0]);
        var12[1].AddChild((ResourceBase)var8[1]);
        var12[1].SetPosition(var9, var10);
        var12[1].a1(aq[1]);
        var13[1] = ImageResource.Create(var13[0]);
        var13[1].AddChild((ResourceBase)var8[7]);
        var13[1].SetPosition(var9, var10);
        var13[1].a1(aq[1]);
        var12[2] = ImageResource.Create(var12[0]);
        var12[2].AddChild((ResourceBase)var8[2]);
        var12[2].SetPosition(var9, var10);
        var12[2].a1(aq[2]);
        var13[2] = ImageResource.Create(var13[0]);
        var13[2].AddChild((ResourceBase)var8[8]);
        var13[2].SetPosition(var9, var10);
        var13[2].a1(aq[2]);
        ImageResource[] var14;
        (var14 = new ImageResource[3])[0] = ImageResource.Create(al[5]);
        var14[0].AddChild((ResourceBase)var8[3]);
        var14[0].SetPosition(var9, var10);
        var14[0].a1(aq[0]);
        var14[1] = ImageResource.Create(var14[0]);
        var14[1].AddChild((ResourceBase)var8[4]);
        var14[1].SetPosition(var9, var10);
        var14[1].a1(aq[1]);
        var14[2] = ImageResource.Create(var14[0]);
        var14[2].AddChild((ResourceBase)var8[5]);
        var14[2].SetPosition(var9, var10);
        var14[2].a1(aq[2]);
        ScriptTextResource[] var15;
        (var15 = new ScriptTextResource[3])[0] = ScriptTextResource.Create(_hintTexts[0]);
        var15[1] = ScriptTextResource.Create(_hintTexts[1]);
        var15[2] = ScriptTextResource.Create(_hintTexts[2]);
        var15[0].SetPosition(s[21], s[22]);
        var15[1].SetPosition(s[21], s[22]);
        var15[2].SetPosition(s[21], s[22]);
        ImageResource[] var16;
        (var16 = new ImageResource[3])[0] = ImageResource.Create(al[3]);
        var16[0].AddChild((ResourceBase)var7[0]);
        var16[0].AddChild(var15[0]);
        var16[0].SetPosition(var9, var10);
        var16[0].a1(aq[0]);
        var16[1] = ImageResource.Create(var16[0]);
        var16[1].AddChild((ResourceBase)var7[1]);
        var16[1].AddChild(var15[1]);
        var16[1].SetPosition(var9, var10);
        var16[1].a1(aq[1]);
        var16[2] = ImageResource.Create(var16[0]);
        var16[2].AddChild((ResourceBase)var7[2]);
        var16[2].AddChild(var15[2]);
        var16[2].SetPosition(var9, var10);
        var16[2].a1(aq[2]);
        ImageResource var17;
        (var17 = ImageResource.Create(al[6])).SetPosition(s[23], var10 + s[24]);
        Q = new nazo.PuzzleFactory();
        if (ak == null)
        {
            ak = Image.CreateImage(width, height);
            Graphics var18;
            (var18 = ak.GetGraphics()).SetColor(Graphics.GetColorOfRGB(249, 249, 223));
            var18.FillRect(0, 0, width, height);
        }

        Q.a1(var1.ScreenResource, "SCRIPT_CMD_AddTracePoint", 3, ak);
        bool var20 = false;
        int var19 = _hintCount;
        if (_isSolved)
        {
            var19 = 3;
        }

        switch (var19)
        {
            case 0:
                if (X <= 0)
                {
                    Q.a1(var14[0], var14[0], var14[0], 0, 0, 2, s[25], s[26], 0, 0, "medal");
                }
                else
                {
                    var12[0].AddChild(var11[0]);
                    var13[0].AddChild(var11[1]);
                    Q.a1(var12[0], var12[0], var13[0], 0, 0, 2, s[25], s[26], 0, 0, "lock");
                }

                Q.a1(var17, var17, var17, 0, 0, 2, s[27], s[28], 1, 0, "ret");
                break;
            case 1:
                if (X <= 0)
                {
                    Q.a1(var14[1], var14[1], var14[1], 0, 0, 2, s[25] + var6, s[26], 1, 0, "medal");
                }
                else
                {
                    var12[1].AddChild(var11[0]);
                    var13[1].AddChild(var11[1]);
                    Q.a1(var12[1], var12[1], var13[1], 0, 0, 2, s[25] + var6, s[26], 1, 0, "lock");
                }

                Q.a1(var16[0], var16[0], var16[0], 0, 0, 2, s[25], s[26], 0, 0, "hint");
                Q.a1(var17, var17, var17, 0, 0, 2, s[27], s[28], 2, 0, "ret");
                break;
            case 2:
                if (X <= 0)
                {
                    Q.a1(var14[2], var14[2], var14[2], 0, 0, 2, s[25] + var6 * 2, s[26], 2, 0, "medal");
                }
                else
                {
                    var12[2].AddChild(var11[0]);
                    var13[2].AddChild(var11[1]);
                    Q.a1(var12[2], var12[2], var13[2], 0, 0, 2, s[25] + var6 * 2, s[26], 2, 0, "lock");
                }

                Q.a1(var16[1], var16[1], var16[1], 0, 0, 2, s[25] + var6, s[26], 1, 0, "hint");
                Q.a1(var16[0], var16[0], var16[0], 0, 0, 2, s[25], s[26], 0, 0, "hint");
                Q.a1(var17, var17, var17, 0, 0, 2, s[27], s[28], 3, 0, "ret");
                break;
            case 3:
                Q.a1(var16[2], var16[2], var16[2], 0, 0, 2, s[25] + var6 * 2, s[26], 2, 0, "hint");
                Q.a1(var16[1], var16[1], var16[1], 0, 0, 2, s[25] + var6, s[26], 1, 0, "hint");
                Q.a1(var16[0], var16[0], var16[0], 0, 0, 2, s[25], s[26], 0, 0, "hint");
                Q.a1(var17, var17, var17, 0, 0, 2, s[27], s[28], 3, 0, "ret");
                break;
        }

        Q.a1(f);
        Q.a1(var1.ScreenResource, centerPosX, centerPosY);
        Q.g1();
        if (var2)
        {
            var1.ScreenResource.ExecuteTransition(0);
            ao = 1;
            Q.b1();
            if (var19 == 3 && _isEncountered)
            {
                Q.a2 = 2;
            }

            a1();
        }
        else
        {
            if (var19 == 3)
            {
                Q.a2 = 0;
            }
            else
            {
                Q.a2 = 1;
            }

            Q.f1();
        }

        b1(11);
        Q.e1();
    }

    [FunctionName("h")]
    private void h1(GameContext var1)
    {
        b1(9);
        var1.ScreenResource.ExecuteTransition(0);
        ao = 1;
    }

    [FunctionName("c")]
    private void c1(GameContext var1, bool var2)
    {
        data.RoomData var3 = var1.RoomData;
        _isSolved = var2;
        if (var1.SaveData.g1(_questionId) == 2)
        {
            _isSolved = true;
            var3.SetQuestionBit(_questionId, 2);
        }

        AudioManager.a1(0, 30, 2);
        if (_isSolved && !var3.IsQuestionBitSet(_questionId, 2))
        {
            var1.SaveData.a1(Y + GetPikarat());
        }

        f1(var1);
        var1.SaveData.b1(X);
        var1.ScreenResource.ExecuteTransition(0);
        var1.ScreenResource.MarkVisible();
        ao = 1;
        b1(10);
    }

    [FunctionName("d")]
    private void d1(int var1)
    {
        nazo.PuzzleResource var2 = null;
        var2 = O.a1("hint");
        if (u == null)
        {
            u = new ImageResource[3][];
            u[0] = new ImageResource[3];
            u[1] = new ImageResource[3];
            u[2] = new ImageResource[3];
            u[0][0] = ImageResource.Create(ah);
            u[0][0].SetPosition(33, 4);
            u[0][1] = ImageResource.Create(u[0][0]);
            u[0][2] = ImageResource.Create(u[0][0]);
            u[1][0] = ImageResource.Create(u[0][0]);
            u[1][0].SetPosition(43, 4);
            u[1][1] = ImageResource.Create(u[1][0]);
            u[1][2] = ImageResource.Create(u[1][0]);
            u[2][0] = ImageResource.Create(u[0][0]);
            u[2][0].SetPosition(53, 4);
            u[2][1] = ImageResource.Create(u[2][0]);
            u[2][2] = ImageResource.Create(u[2][0]);
            var2.k[0].AddChild(u[0][0]);
            var2.k[0].AddChild(u[1][0]);
            var2.k[0].AddChild(u[2][0]);
            var2.k[1].AddChild(u[0][1]);
            var2.k[1].AddChild(u[1][1]);
            var2.k[1].AddChild(u[2][1]);
            var2.k[2].AddChild(u[0][2]);
            var2.k[2].AddChild(u[1][2]);
            var2.k[2].AddChild(u[2][2]);
        }

        int var3;
        for (var3 = 0; var3 < var1; ++var3)
        {
            u[var3][0].SetIsVisible(true);
            u[var3][1].SetIsVisible(true);
            u[var3][2].SetIsVisible(true);
        }

        while (var3 < 3)
        {
            u[var3][0].SetIsVisible(false);
            u[var3][1].SetIsVisible(false);
            u[var3][2].SetIsVisible(false);
            ++var3;
        }

    }

    [FunctionName("l")]
    private void l1()
    {
        ++ar;
        if (ar >= 50)
        {
            if (ar < 60)
            {
                d1(3);
            }
            else if (ar < 70)
            {
                d1(_hintCount);
            }
            else if (ar < 80)
            {
                d1(3);
            }
            else if (ar < 90)
            {
                d1(_hintCount);
            }
            else if (ar < 100)
            {
                d1(3);
            }
            else if (ar < 110)
            {
                d1(_hintCount);
            }
            else
            {
                ar = -250;
            }
        }
    }

    [FunctionName("a")]
    private static Image[] a1(Image[] var0)
    {
        if (var0 != null)
        {
            for (int var1 = 0; var1 < var0.Length; ++var1)
            {
                a1(var0[var1]);
            }

            var0 = null;
        }

        return var0;
    }

    [FunctionName("a")]
    private static Image a1(Image var0)
    {
        if (var0 != null)
        {
            var0.Dispose();
            var0 = null;
        }

        return var0;
    }

    static ControlScene()
    {
        centerPosX = 120 - width / 2;
        centerPosY = 120 - height / 2;
        layoutType = 0;
        resourcePositions = new int[][]
        {
            new int[] { 214, 67 },
            new int[]{ 45, 67 },
            new int[]{ 148, 65 },
            new int[]{ 160, 140 },
            new int[]{ 153, 68 },
            new int[]{ 248, 95 },
            new int[]{ 245, 212 },
            new int[]{ 10, 38 },
            new int[]{ 66, 7 },
            new int[]{ 120, 6 },
            new int[]{ 314, 6 },
            new int[]{ 193, 47 },
            new int[]{ 244, 155 },
            new int[]{ 10, 38 },
            new int[]{ 66, 7 },
            new int[]{ 314, 6 },
            new int[]{ 10, 38 }
        };
        keyboardAreas = new int[][]
        {
            new int[]{ 32, 62, 10, 8 },
            new int[]{ 44, 75, 10, 4 },
            new int[]{ 29, 48, 10, 0 },
            new int[]{ 9, 18, 10, 0 },
            new int[]{ 11, 20, 10, 0 },
            new int[]{ 34, 58, 10, 0 }
        };
        r2 = new int[] { 0, 0 };
        s = new int[]
        {
            0, 0, 8, 14,
            8, 0, 8, 14,
            16, 0, 8, 14,
            0, -20, 70, 48,
            5, 10, 40, 210,
            111, 20, 20, 247,
            -20, 35, 7, 275,
            7, 210, 101
        };
        aq = new int[][]
        {
            new int[]
            {
                Graphics.GetColorOfRGB(0, 255, 0), Graphics.GetColorOfRGB(218, 54, 65), Graphics.GetColorOfRGB(225, 164, 153), Graphics.GetColorOfRGB(48, 15, 5), Graphics.GetColorOfRGB(91, 71, 49), Graphics.GetColorOfRGB(254, 251, 227), Graphics.GetColorOfRGB(227, 220, 178), Graphics.GetColorOfRGB(149, 140, 107), Graphics.GetColorOfRGB(240, 240, 192), Graphics.GetColorOfRGB(187, 180, 128)
            },
            new int[]
            {
                Graphics.GetColorOfRGB(0, 255, 0), Graphics.GetColorOfRGB(218, 54, 65), Graphics.GetColorOfRGB(225, 164, 153), Graphics.GetColorOfRGB(48, 15, 5), Graphics.GetColorOfRGB(91, 71, 49), Graphics.GetColorOfRGB(254, 251, 227), Graphics.GetColorOfRGB(227, 220, 178), Graphics.GetColorOfRGB(149, 140, 107), Graphics.GetColorOfRGB(216, 246, 205), Graphics.GetColorOfRGB(145, 187, 128)
            },
            new int[]
            {
                Graphics.GetColorOfRGB(0, 255, 0), Graphics.GetColorOfRGB(218, 54, 65), Graphics.GetColorOfRGB(225, 164, 153), Graphics.GetColorOfRGB(48, 15, 5), Graphics.GetColorOfRGB(91, 71, 49), Graphics.GetColorOfRGB(254, 251, 227), Graphics.GetColorOfRGB(227, 220, 178), Graphics.GetColorOfRGB(149, 140, 107), Graphics.GetColorOfRGB(205, 245, 227), Graphics.GetColorOfRGB(128, 187, 160)
            }
        };
    }
}
