using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm2.c.Managers;

namespace LaytonMotdm2.c.Resources;

[ClassName("c","k")]
public class ScriptTextResource : ResourceBase
{
    [MemberName("k")]
    private List<JavaString> _textStrings;
    [MemberName("a")]
    public bool a;
    [MemberName("l")]
    private List<int> l;
    [MemberName("m")]
    private List<int> m;
    [MemberName("n")]
    private int n;
    [MemberName("o")]
    private JavaString[] o = null;

    [MemberName("p")]
    private static int p;
    [MemberName("q")]
    private static int[] q = new int[] { 0, 120, 240 };
    [MemberName("r")]
    private static int _textAnchor = 0;
    [MemberName("s")]
    private static int _lineHeight = 14;
    [MemberName("t")]
    private static int _lineCount;
    [MemberName("u")]
    private static bool _hasShadow = false;
    [MemberName("v")]
    private static int _shadowColor = -1;
    [MemberName("w")]
    private static int _textColor = -1;

    [MemberName("x")]
    private bool x;

    [MemberName("y")]
    private static int y = 0;

    [MemberName("z")]
    private int z = 0;
    [MemberName("A")]
    private int A = 0;
    [MemberName("B")]
    private int B = 0;

    [MemberName("C")]
    private static int C = 0;
    [MemberName("D")]
    private static int D = 10;

    [FunctionName("k")]
    private void k1()
    {
        if (_textStrings == null)
        {
            _textStrings = new List<JavaString>();
        }
        else
        {
            _textStrings.Clear();
        }

        a = false;
        if (l == null)
        {
            l = new List<int>();
        }
        else
        {
            l.Clear();
        }

        l.Add(-1);
        if (m == null)
        {
            m = new List<int>();
        }
        else
        {
            m.Clear();
        }

        m.Add(-1);
        n = -1;
        o = null;
        p = 0;
        _textAnchor = 0;
        _lineHeight = 14;
        _lineCount = 0;
        x = false;
        y = 0;
        z = 0;
        A = 0;
        D = 10;
        _hasShadow = false;
        _shadowColor = -1;
        _textColor = -1;
    }

    [FunctionName("a")]
    public void SetText(JavaString var1)
    {
        bool var2 = false;
        int var3 = 0;
        int var4 = var1.Length;
        k1();

        int var5;
        do
        {
            var5 = var3;
            if ((var3 = var1.IndexOf("[", var3)) - var5 >= 0)
            {
                if (var3 - var5 != 0)
                {
                    _textStrings.Add(var1.Substring(var5, var3));
                }

                var5 = var3;

                var3 = var1.IndexOf("]", var3);
                ++var3;
            }

            if (var3 - var5 >= 1)
            {
                _textStrings.Add(var1.Substring(var5, var3));
                if (_textStrings.Last().IndexOf("[br]") != -1)
                {
                    ++_lineCount;
                }
            }
        } while (var5 < var4 && var5 != -1 && var3 != -1 && var3 - var5 != 0);
    }

    [FunctionName("b")]
    public static ScriptTextResource Create(JavaString text)
    {
        return new ScriptTextResource(text);
    }

    [ConstructorName("k")]
    private ScriptTextResource(JavaString text)
    {
        SetText(text);
    }

    [ConstructorName("k")]
    public ScriptTextResource()
    {
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        g.SetFont(GameContext.Font);
        _lineHeight = GameContext.Font.GetHeight() + 1;
        a = false;
        _textAnchor = 0;
        A = 0;
        q[0] = posX;
        int var4 = posY;
        int var5 = 0;
        int var6 = 0;
        bool var7 = false;
        bool var8 = false;

        for (int var9 = 0; var9 < p; ++var9)
        {
            var6 = _textStrings.IndexOf("[hr]", var6);
            ++var6;
        }

        int var21;
        if ((var21 = _textStrings.IndexOf("[hr]", var6)) == -1)
        {
            var21 = _textStrings.Count;
            a = true;
        }

        if (this.x)
        {
            --C;
            if (C <= 0)
            {
                C = D;
                ++z;
            }
        }

        _textColor = Graphics.GetColorOfRGB(0, 0, 0);
        g.SetColor(_textColor);
        _shadowColor = -1;
        _hasShadow = false;
        g.SetOrigin(x, y);

        for (ScriptTextResource.y = z; var6 != var21; ++var6)
        {
            JavaString var22;
            if ((var22 = _textStrings.ElementAt(var6)) == "[br]")
            {
                var4 += _lineHeight;
                var5 = 0;
            }
            else if (var22 == "[l]")
            {
                _textAnchor = 0;
            }
            else
            {
                if (var22 == "[end]")
                {
                    break;
                }

                if (var22 == "[c]")
                {
                    _textAnchor = 1;
                }
                else if (var22 == "[r]")
                {
                    _textAnchor = 2;
                }
                else if (var22 == "[/sdw]")
                {
                    _shadowColor = -1;
                    _hasShadow = false;
                }
                else
                {
                    int var10;
                    int var11;
                    int var12;
                    int var13;
                    int var14;
                    if (var22.IndexOf("[cmd=") != -1)
                    {
                        var8 = true;
                        var11 = var22.IndexOf(",", 5);

                        try
                        {
                            var12 = int.Parse(var22.Substring(5, var11));
                            if (c() != null && n == var12)
                            {
                                break;
                            }

                            for (var13 = 0; var13 < l.Count; ++var13)
                            {
                                var14 = l.ElementAt(var13);
                                if (var12 == var14)
                                {
                                    var12 = -1;
                                    break;
                                }
                            }

                            if (var12 != -1)
                            {
                                B = A;
                                n = var12;
                                var10 = var11 + 1;
                                var11 = var22.IndexOf(",", var10);
                                var13 = int.Parse(var22.Substring(var10, var11));
                                o = new JavaString[var13];

                                for (var14 = 0; var14 < var13 - 1; ++var14)
                                {
                                    var10 = var11 + 1;
                                    var11 = var22.IndexOf(",", var10);
                                    o[var14] = var22.Substring(var10, var11);
                                }

                                var10 = var11 + 1;
                                var11 = var22.IndexOf("]", var10);
                                o[var14] = var22.Substring(var10, var11);
                                l.Add(n);
                                break;
                            }
                        }
                        catch (Exception var20)
                        {
                            g.SetColor(Graphics.GetColorOfRGB(255, 0, 0));
                            DrawText(g, "ER[rgb=r,g,b] p=" + p + " i_s=" + var6 + " " + var22, 10, 20, 0);
                        }
                    }
                    else if (var22.IndexOf("[scd=") != -1)
                    {
                        var8 = true;
                        var11 = var22.IndexOf(",", 5);

                        try
                        {
                            var12 = int.Parse(var22.Substring(5, var11));
                            if (c() != null)
                            {
                                break;
                            }

                            for (var13 = 0; var13 < m.Count(); ++var13)
                            {
                                var14 = m.ElementAt(var13);
                                if (var12 == var14)
                                {
                                    var12 = -1;
                                    break;
                                }
                            }

                            if (var12 != -1)
                            {
                                B = A;
                                var10 = var11 + 1;
                                var11 = var22.IndexOf(",", var10);
                                JavaString[] var15 = new JavaString[var14 = int.Parse(var22.Substring(var10, var11))];

                                int var16;
                                for (var16 = 0; var16 < var14 - 1; ++var16)
                                {
                                    var10 = var11 + 1;
                                    var11 = var22.IndexOf(",", var10);
                                    var15[var16] = var22.Substring(var10, var11);
                                    java.util.System.Out.Debug(" {0}", var15[var16]);
                                }

                                var10 = var11 + 1;
                                var11 = var22.IndexOf("]", var10);
                                var15[var16] = var22.Substring(var10, var11);
                                if (var15[0] == "sound")
                                {
                                    if (var15[1] == "play")
                                    {
                                        AudioManager.PlaySound(int.Parse(var15[2]), GameContext.FileManager.GetLoadedSound(var15[3]), 100);
                                    }
                                    else if (var15[1] == "stop")
                                    {
                                        AudioManager.StopSound(int.Parse(var15[2]));
                                    }
                                }

                                m.Add(var12);
                                break;
                            }
                        }
                        catch (Exception var19)
                        {
                            g.SetColor(Graphics.GetColorOfRGB(255, 0, 0));
                            DrawText(g, "ER[rgb=r,g,b] p=" + p + " i_s=" + var6 + " " + var22, 10, 20, 0);
                        }
                    }
                    else if (var22.IndexOf("[msg=") != -1)
                    {
                        D = int.Parse(var22.Substring(5, var22.IndexOf("]", 5)));
                        if (!this.x)
                        {
                            C = D;
                            this.x = true;
                            z = 0;
                        }
                    }
                    else if (var22.IndexOf("[h=") != -1)
                    {
                        _lineHeight = int.Parse(var22.Substring(3, var22.IndexOf("]", 3)));
                    }
                    else if (var22.IndexOf("[r=") != -1)
                    {
                        q[2] = int.Parse(var22.Substring(3, var22.IndexOf("]", 3)));
                        q[1] = q[2] / 2;
                    }
                    else if (var22.IndexOf("[rgb=") != -1)
                    {
                        var8 = true;
                        var11 = var22.IndexOf(",", 5);
                        var12 = 0;
                        var13 = 0;
                        var14 = 0;

                        try
                        {
                            var12 = int.Parse(var22.Substring(5, var11));
                            var10 = var11 + 1;
                            var11 = var22.IndexOf(",", var10);
                            var13 = int.Parse(var22.Substring(var10, var11));
                            var10 = var11 + 1;
                            var11 = var22.IndexOf("]", var10);
                            var14 = int.Parse(var22.Substring(var10, var11));
                        }
                        catch (Exception var18)
                        {
                            g.SetColor(Graphics.GetColorOfRGB(255, 0, 0));
                            DrawText(g, "ER[rgb=r,g,b] p=" + p + " i_s=" + var6 + " " + var22, 10, 20, 0);
                        }

                        _textColor = Graphics.GetColorOfRGB(var12, var13, var14);
                        g.SetColor(_textColor);
                    }
                    else if (var22.IndexOf("[sdw=") != -1)
                    {
                        var8 = true;
                        var11 = var22.IndexOf(",", 5);
                        var12 = 0;
                        var13 = 0;
                        var14 = 0;

                        try
                        {
                            var12 = int.Parse(var22.Substring(5, var11));
                            var10 = var11 + 1;
                            var11 = var22.IndexOf(",", var10);
                            var13 = int.Parse(var22.Substring(var10, var11));
                            var10 = var11 + 1;
                            var11 = var22.IndexOf("]", var10);
                            var14 = int.Parse(var22.Substring(var10, var11));
                        }
                        catch (Exception var17)
                        {
                            g.SetColor(Graphics.GetColorOfRGB(255, 0, 0));
                            DrawText(g, "ER[rgb=r,g,b] p=" + p + " i_s=" + var6 + " " + var22, 10, 20, 0);
                        }

                        _shadowColor = Graphics.GetColorOfRGB(var12, var13, var14);
                        _hasShadow = true;
                    }
                    else if (this.x)
                    {
                        if (ScriptTextResource.y < var22.Length)
                        {
                            JavaString var23 = var22.Substring(0, ScriptTextResource.y);
                            if (_hasShadow)
                            {
                                g.SetColor(_shadowColor);
                                DrawText(g, var23, q[_textAnchor] + var5 + 1, var4 + 1, _textAnchor);
                                g.SetColor(_textColor);
                            }

                            DrawText(g, var23, q[_textAnchor] + var5, var4, _textAnchor);
                            if (var8)
                            {
                                GameContext.Font.GetBoundingBoxWidth(var22);
                            }
                            else
                            {
                                GameContext.Font.GetBoundingBoxWidth(var22);
                            }

                            ScriptTextResource.y -= var23.Length;
                            A += var23.Length;
                            break;
                        }

                        if (_hasShadow)
                        {
                            g.SetColor(_shadowColor);
                            DrawText(g, var22, q[_textAnchor] + var5 + 1, var4 + 1, _textAnchor);
                            g.SetColor(_textColor);
                        }

                        DrawText(g, var22, q[_textAnchor] + var5, var4, _textAnchor);
                        if (var8)
                        {
                            var5 += GameContext.Font.GetBoundingBoxWidth(var22);
                            var8 = false;
                        }
                        else
                        {
                            var5 = GameContext.Font.GetBoundingBoxWidth(var22);
                        }

                        ScriptTextResource.y -= var22.Length;
                        A += var22.Length;
                    }
                    else
                    {
                        if (_hasShadow)
                        {
                            g.SetColor(_shadowColor);
                            DrawText(g, var22, q[_textAnchor] + var5 + 1, var4 + 1, _textAnchor);
                            g.SetColor(_textColor);
                        }

                        DrawText(g, var22, q[_textAnchor] + var5, var4, _textAnchor);
                        if (var8)
                        {
                            var5 += GameContext.Font.GetBoundingBoxWidth(var22);
                            var8 = false;
                        }
                        else
                        {
                            var5 = GameContext.Font.GetBoundingBoxWidth(var22);
                        }

                        A += var22.Length;
                    }
                }
            }
        }

        if (this.x && ScriptTextResource.y >= 1)
        {
            z = 100000;
        }

        g.ClearClip();
        g.SetOrigin(0, 0);
    }

    [FunctionName("c")]
    public JavaString[] c()
    {
        return o;
    }

    [FunctionName("l")]
    private void l1()
    {
        n = -1;
        o = null;
        z = B;
    }

    [FunctionName("d")]
    public bool d()
    {
        if (o != null)
        {
            l1();
        }
        else if (x && z < 100000)
        {
            z = 100000;
        }
        else
        {
            if (a)
            {
                return false;
            }

            ++p;
            Reset();
        }

        return true;
    }

    [FunctionName("i")]
    public bool i()
    {
        bool var1 = true;
        if (!x)
        {
            return false;
        }
        else
        {
            if (o != null)
            {
                var1 = false;
            }
            else if (x && z < 100000)
            {
                var1 = false;
            }

            return var1;
        }
    }

    [FunctionName("j")]
    public void Reset()
    {
        a = false;
        if (l == null)
        {
            l = new List<int>();
        }
        else
        {
            l.Clear();
        }

        l.Add(-1);
        if (m == null)
        {
            m = new List<int>();
        }
        else
        {
            m.Clear();
        }

        m.Add(-1);
        n = -1;
        o = null;
        _textAnchor = ANCHOR_LEFT;
        _lineHeight = 14;
        _lineCount = 0;
        x = false;
        y = 0;
        z = 0;
        A = 0;
        D = 10;
    }

    [FunctionName("a")]
    private static void DrawText(Graphics var0, JavaString text, int x, int y, int anchor)
    {
        y += GameContext.Font.GetAscent();
        if (anchor == ANCHOR_CENTER)
        {
            x -= GameContext.Font.GetBoundingBoxWidth(text) / 2;
        }
        else if (anchor == ANCHOR_RIGHT)
        {
            x -= GameContext.Font.GetBoundingBoxWidth(text);
        }

        var0.DrawString(text, x, y);
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return 0;
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return 0;
    }

    [FunctionName("a")]
    protected override void Update(Graphics var1)
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
}
