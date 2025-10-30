using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm4.c.Resources;

[ClassName("c", "m")]
public class TextSelectionResource : ResourceBase
{
    [MemberName("a")]
    private ScriptTextResource a;
    [MemberName("k")]
    private TextResource k;
    [MemberName("l")]
    private TextResource[] l;
    [MemberName("m")]
    private TextResource[] m2;
    [MemberName("n")]
    private int _activeTextIndex;

    [ConstructorName("m")]
    public TextSelectionResource()
    {
    }

    [FunctionName("a")]
    public static TextSelectionResource Create(JavaString scriptText, JavaString var1, JavaString var2)
    {
        TextSelectionResource var3;
        (var3 = new TextSelectionResource()).a = ScriptTextResource.Create(scriptText);
        var3.a.SetPosition(36, 17);
        var3.AddChild(var3.a);
        if (var1 != null)
        {
            var3.l = new TextResource[2];
            var3.m2 = new TextResource[2];
            var3.k = TextResource.Create("／");
            var3.l[0] = TextResource.Create("★");
            var3.m2[0] = TextResource.Create(var1);
            var3.l[1] = TextResource.Create("★");
            var3.m2[1] = TextResource.Create(var2);
            var3.l[0].SetTextColor(255, 0, 0);
            var3.l[1].SetTextColor(255, 0, 0);
            var3.k.SetPosition(120, 185);
            var3.k.SetAnchorType(TextResource.ANCHOR_CENTER);
            var3.l[0].SetAnchorType(TextResource.ANCHOR_RIGHT);
            var3.m2[0].AddChild(var3.l[0], -var3.m2[0].GetWidth(), 0);
            var3.m2[0].SetAnchorType(TextResource.ANCHOR_RIGHT);
            var3.k.AddChild(var3.m2[0], -var3.k.GetWidth(), 0);
            var3.k.AddChild(var3.l[1], var3.k.GetWidth(), 0);
            var3.k.AddChild(var3.m2[1], var3.k.GetWidth() + var3.l[1].GetWidth(), 0);
            var3.AddChild(var3.k);
            var3._activeTextIndex = 1;
            var3.a1(0);
        }

        return var3;
    }

    [FunctionName("a")]
    private void a1(int newActiveIndex)
    {
        if (l != null)
        {
            l[_activeTextIndex].SetIsVisible(false);
            m2[_activeTextIndex].SetTextColor(0, 0, 0);
            _activeTextIndex = newActiveIndex;
            l[_activeTextIndex].SetIsVisible(true);
            m2[_activeTextIndex].SetTextColor(255, 0, 0);
        }
    }

    [FunctionName("a")]
    public JavaString GetActiveText(GameContext var1)
    {
        if (var1.IsKeyPressed(Display.KEY_LEFT))
        {
            a1(0);
        }
        else if (var1.IsKeyPressed(Display.KEY_RIGHT))
        {
            a1(1);
        }
        else if (var1.IsKeyPressed(Display.KEY_MAIN))
        {
            if (l == null)
            {
                return null;
            }

            return m2[_activeTextIndex].GetText();
        }

        return "";
    }

    [FunctionName("c")]
    public void c1()
    {
        l = null;
        m2 = null;
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        g.SetColor(Graphics.GetColorOfRGB(250, 230, 130));
        g.FillRect(0, 0, 426, 240);
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
