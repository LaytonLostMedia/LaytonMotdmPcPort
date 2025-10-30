using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm2.c.Managers;

namespace LaytonMotdm2.c.Resources;

[ClassName("c", "s")]
public class FormattedTextResource : FormattedTextResourceBase
{
    [MemberName("P")]
    private int P;
    [MemberName("Q")]
    private int Q = 0;
    [MemberName("R")]
    private bool R = false;

    [ConstructorName("s")]
    public FormattedTextResource()
    {
    }

    [FunctionName("a")]
    public static FormattedTextResource a1(GameContext var0, int var1, bool var2, int var3, bool var4, JavaString var5)
    {
        FormattedTextResource var6;
        (var6 = a1(var0, var1, var2, var3)).A = var4;
        if (var5 != null && !var5.Equals(""))
        {
            var6.n[16].SetIsVisible(true);
            ((ScriptTextResource)var6.r).SetText(var5 + "[end]");
            var6.B = 0;
        }

        return var6;
    }

    [FunctionName("a")]
    private static FormattedTextResource a1(GameContext var0, int var1, bool var2, int var3)
    {
        FormattedTextResource var4;
        (var4 = new FormattedTextResource()).C = true;
        var4.B = 1;
        var4.u = 0;
        var4.s = 0;
        var4.t[var4.s] = 0;
        var4._totalText = "";
        var4.l = "";
        var4.Q = 0;
        var4.R = false;
        var4.z = true;
        var4.A = false;
        JavaString[] var5 = new JavaString[] { "bg_hanyou.jpg", "key0.gif", "key1.gif", "key2.gif", "nazo_key0.gif", "nazo_key1.gif", "nazo_key2.gif", "nazo_key3.gif", "key_waku0.gif", "nazo_textbox.gif", "p_key0.gif", "p_key1.gif", "p_key2.gif", "p_key3.gif", "p_key4.gif", "p_key5.gif" };
        var4.w.LoadFiles(var5);

        for (int var6 = 0; var6 < 17; ++var6)
        {
            if (var6 == 16)
            {
                var4.n[0 + var6] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small2.gif"));
            }
            else
            {
                var4.n[0 + var6] = ImageResource.Create(var4.w.GetLoadedImage(var5[var6]));
            }
        }

        ResourceBase[] var10000 = var4.o;
        int[,] var10002 = K;
        int var12 = var10002[0, 0];
        int[,] var10003 = K;
        var10000[0] = RectangleResource.Create(var12, var10003[0, 1], 0, 255, 0, 0, 128);
        var10000 = var4.o;
        var10002 = K;
        var12 = var10002[1, 0];
        var10003 = K;
        var10000[1] = RectangleResource.Create(var12, var10003[1, 1], 0, 255, 0, 0, 128);
        var10000 = var4.o;
        var10002 = K;
        var12 = var10002[1, 0];
        var10003 = K;
        var10000[2] = RectangleResource.Create(var12, var10003[1, 1], 0, 255, 0, 0, 128);
        var10000 = var4.o;
        var10002 = K;
        var12 = var10002[1, 0];
        var10003 = K;
        var10000[3] = RectangleResource.Create(var12, var10003[1, 1], 0, 255, 0, 0, 128);
        var10000 = var4.o;
        var10002 = K;
        var12 = var10002[2, 0];
        var10003 = K;
        var10000[4] = RectangleResource.Create(var12, var10003[2, 1], 0, 255, 0, 0, 128);
        var10000 = var4.o;
        var10002 = K;
        var12 = var10002[2, 0];
        var10003 = K;
        var10000[5] = RectangleResource.Create(var12, var10003[2, 1], 0, 255, 0, 0, 128);
        var10000 = var4.o;
        var10002 = K;
        var12 = var10002[3, 0];
        var10003 = K;
        var10000[6] = RectangleResource.Create(var12, var10003[3, 1], 0, 255, 0, 0, 128);
        var10000 = var4.o;
        var10002 = K;
        var12 = var10002[4, 0];
        var10003 = K;
        var10000[7] = RectangleResource.Create(var12, var10003[4, 1], 0, 255, 0, 0, 128);
        var4.AddChild(var4.n[0]);
        ResourceBase var10001 = var4.n[1];
        var10002 = H;
        var12 = var10002[0, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[0, 1]);
        var10001 = var4.n[2];
        var10002 = H;
        var12 = var10002[0, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[0, 1]);
        var10001 = var4.n[3];
        var10002 = H;
        var12 = var10002[0, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[0, 1]);
        var10001 = var4.n[4];
        var10002 = H;
        var12 = var10002[1, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[1, 1]);
        var10001 = var4.n[5];
        var10002 = H;
        var12 = var10002[1, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[1, 1]);
        var10001 = var4.n[6];
        var10002 = H;
        var12 = var10002[2, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[2, 1]);
        var10001 = var4.n[7];
        var10002 = H;
        var12 = var10002[3, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[3, 1]);
        var4.AddChild(var4.o[1], 8, 150);
        var4.AddChild(var4.o[2], 57, 150);
        var4.AddChild(var4.o[3], 106, 150);
        var4.AddChild(var4.o[4], 164, 150);
        var4.AddChild(var4.o[5], 238, 150);
        var4.AddChild(var4.o[6], 118, 190);
        var10001 = var4.n[8];
        var10002 = H;
        var12 = var10002[4, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[4, 1]);
        var10001 = var4.n[10];
        var10002 = H;
        var12 = var10002[5, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[5, 1]);
        var10001 = var4.n[11];
        var10002 = H;
        var12 = var10002[6, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[6, 1]);
        var10001 = var4.n[12];
        var10002 = H;
        var12 = var10002[7, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[7, 1]);
        var10001 = var4.n[14];
        var10002 = H;
        var12 = var10002[9, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[9, 1]);
        var4.AddChild(var4.o[0], var4.D[0], var4.E[0]);
        ResourceBase var13;
        if (var1 >= 3)
        {
            var13 = var4.n[14];
            int[,] var14 = H;
            int var15 = var14[11, 0];
            var10002 = H;
            var13.SetPosition(var15, var10002[11, 1]);
        }

        var10001 = var4.n[13];
        var10002 = H;
        var12 = var10002[10, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[10, 1]);
        var10001 = var4.n[15];
        var10002 = H;
        var12 = var10002[8, 0];
        var10003 = H;
        var4.AddChild(var10001, var12, var10003[8, 1]);
        var4.AddChild(var4.n[16], I[0, 0], I[0, 1]);
        var4.r = ScriptTextResource.Create("");
        var13 = var4.n[16];
        var10001 = var4.r;
        var10002 = J;
        var12 = var10002[0, 0];
        var10003 = J;
        var13.AddChild(var10001, var12, var10003[0, 1]);
        var4.n[16].SetIsVisible(false);
        var4.b(var1);
        var4.z = var2;
        if (var1 >= 3)
        {
            var4.o[5].SetPosition(237, 190);
        }

        var4.AddChild(var4.o[7], 44, 70);
        int[,] var11 = L;
        int var7 = M;
        int var8 = N;
        int var9 = O;

        int var10;
        for (var10 = 0; var10 < _totalLength; ++var10)
        {
            a1(var4, var10);
            ((TextResource)var4.p[var10]).SetAnchorType(1);
        }

        if (!var4.z)
        {
            var4.n[10].SetIsVisible(false);
            var4.n[11].SetIsVisible(false);
            var4.n[12].SetIsVisible(false);
            var4.n[15].SetIsVisible(false);
        }

        if (var1 >= 3)
        {
            for (var10 = 0; var10 < 4; ++var10)
            {
                var4.n[8].SetIsVisible(false);
                if (var10 < var3)
                {
                    var4.m[var10] = ImageResource.Create((ImageResource)var4.n[9]);
                    var4.AddChild(var4.m[var10], var11[var3 - 1, var10], var9);
                    var4.AddChild(var4.p[var10], 7 + var11[var3 - 1, var10] + var7, var8);
                    var4.m[var10].SetIsVisible(true);
                }
                else if (var10 < 4)
                {
                    var4.m[var10] = ImageResource.Create((ImageResource)var4.n[9]);
                    var4.AddChild(var4.m[var10], var11[3, var10], var9);
                    var4.m[var10].SetIsVisible(false);
                }
            }

            _totalLength = var3;
        }
        else if (var3 > 0 && var3 < _totalLength)
        {
            _totalLength = var3;
        }

        a1(var4);
        ((TextResource)var4.q).SetAnchorType(1);
        return var4;
    }

    [FunctionName("c")]
    public void c()
    {
        B = 1;
        u = 0;
        if (p != null)
        {
            for (int var1 = 0; var1 < p.Length; ++var1)
            {
                ((TextResource)p[var1]).SetText("");
            }
        }

        _totalText = "";
        l = "";
        Q = 0;
        R = false;
    }

    [FunctionName("m")]
    private void m1()
    {
        n[10].SetPosition(H[5, 0], H[5, 1]);
        n[11].SetPosition(H[6, 0], H[6, 1]);
        n[12].SetPosition(H[7, 0], H[7, 1]);
        n[13].SetPosition(H[10, 0], H[10, 1]);
        n[14].SetPosition(H[9, 0], H[9, 1]);
        if (y >= 3)
        {
            n[14].SetPosition(H[11, 0], H[11, 1]);
        }

        n[15].SetPosition(H[8, 0], H[8, 1]);
    }

    [FunctionName("b")]
    private void b(int var1)
    {
        if (z)
        {
            for (int var2 = 0; var2 < 7; ++var2)
            {
                n[1 + var2].SetIsVisible(false);
            }

            n[1 + var1].SetIsVisible(true);
            y = var1;
        }

    }

    [FunctionName("f")]
    private void f(int var1)
    {
        for (int var2 = 0; var2 < 8; ++var2)
        {
            o[var2].SetIsVisible(false);
        }

        P = var1;
        o[var1].SetIsVisible(true);
        o[1].SetPosition(n[10].posX - 1, n[10].posY - 1);
        o[2].SetPosition(n[11].posX - 1, n[11].posY - 1);
        o[3].SetPosition(n[12].posX - 1, n[12].posY - 1);
        o[4].SetPosition(n[15].posX - 1, n[15].posY - 1);
        o[5].SetPosition(n[14].posX - 1, n[14].posY - 1);
        o[6].SetPosition(n[13].posX - 1, n[13].posY - 1);
    }

    [FunctionName("g")]
    private void g(int var1)
    {
        if (var1 == 1)
        {
            if (z)
            {
                if (t[0] < 3)
                {
                    t[1] = 0;
                    return;
                }

                if (t[0] < 6)
                {
                    t[1] = 1;
                    return;
                }

                if (t[0] < 9)
                {
                    t[1] = 2;
                    return;
                }

                if (t[0] < 13)
                {
                    t[1] = 3;
                    return;
                }

                t[1] = 4;
                return;
            }

            t[1] = 4;
            if (t[0] < 13)
            {
                s = 2;
                return;
            }
        }
        else
        {
            if (t[1] == 0)
            {
                t[0] = 1;
                return;
            }

            if (t[1] == 1)
            {
                t[0] = 4;
                return;
            }

            if (t[1] == 2)
            {
                t[0] = 7;
                return;
            }

            if (t[1] == 3)
            {
                t[0] = 10;
                return;
            }

            if (t[1] == 4)
            {
                t[0] = 14;
            }
        }
    }

    [FunctionName("a")]
    public void a1(int var1)
    {
        if (C)
        {
            R = true;
            switch (B)
            {
                case 0:
                    if (var1 == 4)
                    {
                        n[16].SetIsVisible(false);
                        B = 1;
                    }
                    break;

                case 1:
                    int var10002;
                    switch (var1)
                    {
                        case 0:
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            switch (s)
                            {
                                case 0:
                                    if (--u < 0)
                                    {
                                        s = 2;
                                        g(1);
                                    }

                                    return;
                                case 1:
                                    u = Keyboards[y].Length - 1;
                                    s = 0;
                                    if (t[s] >= Keyboards[y][u].Length - 1)
                                    {
                                        t[s] = Keyboards[y][u].Length - 1;
                                    }

                                    return;
                                case 2:
                                    if (z)
                                    {
                                        s = 1;
                                    }
                                    else
                                    {
                                        u = Keyboards[y].Length - 1;
                                        s = 0;
                                        if (t[s] >= Keyboards[y][u].Length - 1)
                                        {
                                            t[s] = Keyboards[y][u].Length - 1;
                                        }

                                        if (Keyboards[y][u][t[s]].Equals("｜"))
                                        {
                                            --u;
                                            if (Keyboards[y][u][t[s]].Equals("｜"))
                                            {
                                                --u;
                                            }

                                            return;
                                        }
                                    }

                                    return;
                                default:
                                    return;
                            }
                        case 1:
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            switch (s)
                            {
                                case 0:
                                    if (++u >= Keyboards[y].Length)
                                    {
                                        s = 1;
                                        g(1);
                                        return;
                                    }
                                    else
                                    {
                                        if (t[s] >= Keyboards[y][u].Length - 1)
                                        {
                                            t[s] = Keyboards[y][u].Length - 1;
                                        }
                                        else if (Keyboards[y][u][t[s]].Equals("｜"))
                                        {
                                            var10002 = t[s]++;
                                            s = 1;
                                            g(1);
                                            return;
                                        }

                                        return;
                                    }
                                case 1:
                                    s = 2;
                                    return;
                                case 2:
                                    u = 0;
                                    s = 0;
                                    if (t[s] >= Keyboards[y][u].Length - 1)
                                    {
                                        t[s] = Keyboards[y][u].Length - 1;
                                    }

                                    return;
                                default:
                                    return;
                            }
                        case 2:
                            if (s != 2)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }

                            switch (s)
                            {
                                case 0:
                                    if (--t[s] < 0)
                                    {
                                        t[s] = Keyboards[y][u].Length - 1;
                                    }

                                    if (Keyboards[y][u][t[s]].Equals("｜"))
                                    {
                                        var10002 = t[s]--;
                                    }

                                    return;
                                case 1:
                                    if (z)
                                    {
                                        if (--t[s] < 0)
                                        {
                                            t[s] = 4;
                                        }

                                        g(0);
                                    }
                                    else
                                    {
                                        s = 2;
                                    }

                                    return;
                                default:
                                    return;
                            }
                        case 3:
                            if (s != 2 && y < 3)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (s != 1 && y >= 3)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }

                            if (s == 0)
                            {
                                if (++t[s] >= Keyboards[y][u].Length)
                                {
                                    t[s] = 0;
                                }

                                if (Keyboards[y][u][t[s]].Equals("｜"))
                                {
                                    var10002 = t[s]++;
                                }
                            }
                            else if (z)
                            {
                                if (s == 1)
                                {
                                    if (++t[s] >= 5)
                                    {
                                        t[s] = 0;
                                    }

                                    g(0);
                                }
                            }
                            else if (s == 2)
                            {
                                s = 1;
                                g(0);
                            }
                            break;
                        case 4:
                            switch (s)
                            {
                                case 0:
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    JavaString var7 = null;
                                    sbyte[] var9;
                                    if (Keyboards[y][u][t[s]].Equals("ENCODE_1"))
                                    {
                                        var9 = new sbyte[] { -127, 96 };

                                        try
                                        {
                                            var7 = new JavaString(var9.Cast<byte>().ToArray());
                                            Append(var7);
                                        }
                                        catch (Exception var6)
                                        {
                                        }

                                        return;
                                    }
                                    else if (Keyboards[y][u][t[s]].Equals("ENCODE_2"))
                                    {
                                        var9 = new sbyte[] { -127, 124 };

                                        try
                                        {
                                            var7 = new JavaString(var9.Cast<byte>().ToArray());
                                            Append(var7);
                                        }
                                        catch (Exception var5)
                                        {
                                        }

                                        return;
                                    }
                                    else
                                    {
                                        Append(Keyboards[y][u][t[s]]);
                                        return;
                                    }
                                case 1:
                                    if (t[s] < 3)
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                        b(t[s]);
                                        n[10 + t[s]].SetPosition(H[5 + t[s], 0] + 1, H[5 + t[s], 1] + 1);
                                        return;
                                    }
                                    else
                                    {
                                        if (t[s] == 3)
                                        {
                                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                            n[15].SetPosition(H[8, 0] + 1, H[8, 1] + 1);
                                            AppendSpace();
                                        }
                                        else if (t[s] == 4)
                                        {
                                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                                            o1();
                                            n[14].SetPosition(H[9, 0] + 1, H[9, 1] + 1);
                                            if (y >= 3)
                                            {
                                                n[14].SetPosition(H[11, 0] + 1, H[11, 1] + 1);
                                            }

                                            return;
                                        }

                                        return;
                                    }
                                case 2:
                                    bool var8 = true;

                                    for (int var4 = 0; var4 < v.Length; ++var4)
                                    {
                                        if (v[var4].Equals(_totalText) && A)
                                        {
                                            var8 = false;
                                            break;
                                        }
                                    }

                                    if (var8)
                                    {
                                        if (!_totalText.Equals(""))
                                        {
                                            if (y < 3)
                                            {
                                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_002.mld"), 100, 0);
                                            }
                                            else
                                            {
                                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                            }

                                            C = false;
                                        }

                                        l = _totalText;
                                        n[13].SetPosition(H[10, 0] + 1, H[10, 1] + 1);
                                    }
                                    else
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_002.mld"), 100, 0);
                                        n[16].SetIsVisible(true);
                                        r.SetPosition(22, J[1, 1]);
                                        ((ScriptTextResource)r).SetText("その名前はつかえません…。[end]");
                                        B = 2;
                                    }

                                    return;
                                default:
                                    return;
                            }
                        case 5:
                            s = 2;
                            bool var2 = true;

                            for (int var3 = 0; var3 < v.Length; ++var3)
                            {
                                if (v[var3].Equals(_totalText) && A)
                                {
                                    var2 = false;
                                    break;
                                }
                            }

                            if (var2)
                            {
                                if (!_totalText.Equals(""))
                                {
                                    if (y < 3)
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_002.mld"), 100, 0);
                                    }
                                    else
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    }

                                    C = false;
                                }

                                l = _totalText;
                                n[13].SetPosition(H[10, 0] + 1, H[10, 1] + 1);
                            }
                            else
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_002.mld"), 100, 0);
                                n[16].SetIsVisible(true);
                                r.SetPosition(32, J[1, 1]);
                                ((ScriptTextResource)r).SetText("その名前は使えません…。[end]");
                                B = 2;
                            }
                            break;
                        case 6:
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            o1();
                            n[14].SetPosition(H[9, 0] + 1, H[9, 1] + 1);
                            if (y >= 3)
                            {
                                n[14].SetPosition(H[11, 0] + 1, H[11, 1] + 1);
                            }
                            break;
                    }

                    return;

                case 2:
                    if (var1 == 4)
                    {
                        n[16].SetIsVisible(false);
                        c();
                        return;
                    }
                    break;
            }
        }
    }

    [FunctionName("d")]
    public JavaString d()
    {
        return l;
    }

    [FunctionName("a")]
    private void Append(JavaString text)
    {
        if (_totalText.Length < _totalLength)
        {
            _totalText = _totalText + text;
        }
        else
        {
            _totalText = _totalText.Substring(0, _totalText.Length - 1) + text;
        }

        ((TextResource)p[_totalText.Length - 1]).SetText(_totalText.Substring(_totalText.Length - 1, _totalText.Length));
    }

    [FunctionName("n")]
    private void AppendSpace()
    {
        Append("　");
    }

    [FunctionName("o")]
    private void o1()
    {
        if (_totalText.Length != 0)
        {
            if (_totalText.Length == 1)
            {
                _totalText = "";
            }
            else
            {
                _totalText = _totalText.Substring(0, _totalText.Length - 1);
            }

            for (int var1 = 0; var1 < _totalLength; ++var1)
            {
                if (var1 < _totalText.Length)
                {
                    ((TextResource)p[var1]).SetText(_totalText.Substring(var1, var1 + 1));
                }
                else
                {
                    ((TextResource)p[var1]).SetText("");
                }
            }
        }
    }

    [FunctionName("i")]
    protected override void Paint()
    {
        l1();
        if (R)
        {
            ++Q;
            if (Q > 3)
            {
                m1();
                R = !R;
                Q = 0;
            }
        }

        if (_transitionState != 0)
        {
            C = true;
        }

        switch (s)
        {
            case 0:
                if (y >= 5)
                {
                    f(7);
                }
                else
                {
                    f(0);
                }

                o[P].SetPosition(D[y] + t[s] * F[y], E[y] + u * G[y]);
                return;

            case 1:
                if (y >= 3)
                {
                    t[s] = 4;
                }

                f(t[s] + 1);
                return;

            case 2:
                f(6);
                break;

            default:
                return;
        }
    }

    [FunctionName("b")]
    public void b(bool var1)
    {
        C = var1;
        s = 0;
        t[s] = 0;
        m1();
    }

    [FunctionName("j")]
    protected override void Update()
    {
        if (_transitionState != 0)
        {
            if (_transitionState == 1)
            {
                _isVisible = false;
                _transitionState = 2;
                return;
            }

            if (_transitionState == 2)
            {
                _transitionState = 0;
                return;
            }

            if (_transitionState == 3)
            {
                if (++_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 4;
                    return;
                }
            }
            else if (_transitionState == 4)
            {
                _isVisible = true;
                _transitionState = 0;
            }
        }
    }

    [FunctionName("k")]
    public void Reset()
    {
        int var1;
        for (var1 = 16; var1 >= 0; --var1)
        {
            if (n[var1] != null)
            {
                n[var1].f1();
                n[var1] = null;
            }
        }

        for (var1 = 7; var1 >= 0; --var1)
        {
            if (o[var1] != null)
            {
                o[var1].f1();
                o[var1] = null;
            }
        }

        for (var1 = _totalLength - 1; var1 >= 0; --var1)
        {
            if (p[var1] != null)
            {
                p[var1].f1();
                p[var1] = null;
            }
        }

        for (var1 = 3; var1 >= 0; --var1)
        {
            m[var1] = null;
        }

        if (r != null)
        {
            r.f1();
            r = null;
        }

        if (q != null)
        {
            q.f1();
            q = null;
        }

        _totalText = "";
        l = "";
        Q = 0;
        R = false;

        try
        {
            w.Reset();
        }
        catch { }
    }
}
