using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm1.c.Resources;

[ClassName("c", "v")]
public class TextResource : ResourceBase
{
    [MemberName("a")]
    private JavaString _text;
    [MemberName("k")]
    private int _textWidth;
    [MemberName("l")]
    private int _textColor;
    [MemberName("m")]
    private int _outlineColor;
    [MemberName("n")]
    private int _clipPosX;
    [MemberName("o")]
    private int _clipPosY;
    [MemberName("p")]
    private int _clipWidth;
    [MemberName("q")]
    private int _clipHeight;
    [MemberName("r")]
    private int _anchorType;
    [MemberName("s")]
    private int _anchorPosX;
    [MemberName("t")]
    private int _outlineMode;
    [MemberName("u")]
    private int _fontSizeType = FONT_TINY;

    public const int FONT_TINY = 0;
    public const int FONT_SMALL = 1;
    public const int FONT_MEDIUM = 2;
    public const int FONT_LARGE = 3;

    public const int OUTLINE_NONE = 0;
    public const int OUTLINE_SHADOW = 1;
    public const int OUTLINE_FULL = 2;

    [ConstructorName("v")]
    private TextResource()
    {
        posX = 0;
        posY = 0;
        _textWidth = 0;
        _anchorType = 0;
        _outlineMode = 0;
        _outlineColor = Graphics.GetColorOfName(0);
        _text = "";
        _clipPosX = 0;
        _clipPosY = 0;
        _clipWidth = 240;
        _clipHeight = 240;
    }

    [FunctionName("a")]
    public static TextResource Create(JavaString text)
    {
        var v1 = new TextResource();
        v1.SetText(text);
        v1.SetTextColor(0, 0, 0);
        v1._fontSizeType = FONT_TINY;
        v1.ClipRect(0, 0, 240, 240);
        return v1;
    }

    [FunctionName("a")]
    public static TextResource Create(JavaString text, int r, int g, int b)
    {
        TextResource v1;
        (v1 = new TextResource()).SetText(text);
        v1.SetTextColor(r, g, b);
        v1._fontSizeType = FONT_TINY;
        v1.ClipRect(0, 0, 240, 240);
        return v1;
    }

    [FunctionName("a")]
    public static TextResource Create(JavaString text, int fontSizeType)
    {
        TextResource v1;
        (v1 = new TextResource()).SetText(text);
        v1.SetTextColor(0, 0, 0);
        v1._fontSizeType = fontSizeType;
        return v1;
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        switch (_fontSizeType)
        {
            case FONT_TINY:
                g.SetFont(Font.GetFont(0x70000400));
                break;
            case FONT_SMALL:
                g.SetFont(Font.GetFont(0x70000100));
                break;
            case FONT_MEDIUM:
                g.SetFont(Font.GetFont(0x70000200));
                break;
            case FONT_LARGE:
                g.SetFont(Font.GetFont(0x70000300));
                break;
        }
        int textPosX = x + posX + _anchorPosX;
        int textPosY = y + posY + GameContext.FontAscent;

        if (_outlineMode == OUTLINE_SHADOW)
        {
            g.SetColor(_outlineColor);
            g.DrawString(_text, textPosX + 1, textPosY + 1);
        }
        else if (_outlineMode == OUTLINE_FULL)
        {
            g.SetColor(_outlineColor);
            g.DrawString(_text, textPosX + 1, textPosY);
            g.DrawString(_text, textPosX - 1, textPosY);
            g.DrawString(_text, textPosX, textPosY + 1);
            g.DrawString(_text, textPosX, textPosY - 1);
        }

        g.ClipRect(_clipPosX, _clipPosY, _clipWidth, _clipHeight);
        g.SetColor(_textColor);
        g.DrawString(_text, textPosX, textPosY);
        g.ClearClip();

        g.SetFont(GameContext.Font);
    }

    [FunctionName("a")]
    private void ClipRect(int x, int y, int width, int height)
    {
        _clipPosX = x;
        _clipPosY = y;
        _clipWidth = width;
        _clipHeight = height;
    }

    [FunctionName("b")]
    public void SetText(JavaString text)
    {
        _text = text;
        _textWidth = GameContext.Font.GetBoundingBoxWidth(text);
        
        if (_anchorType != ANCHOR_LEFT)
            SetAnchorType(_anchorType);
    }

    [FunctionName("c")]
    public void SetTextColor(int r, int g, int b)
    {
        _textColor = Graphics.GetColorOfRGB(r, g, b);
    }

    [FunctionName("c")]
    public JavaString GetText()
    {
        return _text;
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return _textWidth;
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return GameContext.Font.GetHeight();
    }

    [FunctionName("a")]
    public void SetAnchorType(int anchorType)
    {
        _anchorType = anchorType;
        _anchorPosX = 0;

        if (_anchorType == ANCHOR_CENTER)
        {
            _anchorPosX -= GetWidth() / 2;
            return;
        }

        if (_anchorType == ANCHOR_RIGHT)
            _anchorPosX -= GetWidth();
    }

    /// <summary>
    /// Sets the text outline mode.
    /// </summary>
    /// <param name="outlineMode">The text outline mode. 0 = None; 1 = Bottom-Right shadow; 2 = Full outline</param>
    [FunctionName("b")]
    public void SetOutlineMode(int outlineMode)
    {
        _outlineMode = outlineMode;
    }

    [FunctionName("a")]
    protected override void Update(Graphics paramGraphics)
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
