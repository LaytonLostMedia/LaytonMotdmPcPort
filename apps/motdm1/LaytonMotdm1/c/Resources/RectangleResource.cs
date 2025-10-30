using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm1.c.Resources;

[ClassName("c", "f")]
public class RectangleResource : ResourceBase
{
    [MemberName("a")]
    private int _rectangleType;
    [MemberName("k")]
    private int _width;
    [MemberName("l")]
    private int _height;
    [MemberName("m")]
    private int _redChannel;
    [MemberName("n")]
    private int _greenChannel;
    [MemberName("o")]
    private int _blueChannel;
    [MemberName("p")]
    private int _gradientTargetRed;
    [MemberName("q")]
    private int _gradientTargetGreen;
    [MemberName("r")]
    private int _gradientTargetBlue;
    [MemberName("s")]
    private int _color;

    public const int RECT_HOLLOW = 0;
    public const int RECT_FILL = 1;
    public const int RECT_GRADIENT = 2;

    [ConstructorName("f")]
    private RectangleResource()
    {
    }

    [FunctionName("a")]
    public static RectangleResource Create(int x, int y, int rectType, int r, int g, int b, int a)
    {
        var res = new RectangleResource();

        res.SetSize(x, y);
        res._rectangleType = rectType;
        res.SetColor(r, g, b, a);

        return res;
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        g.SetColor(_color);

        if (_rectangleType == RECT_HOLLOW)
        {
            // Rectangle outline
            g.DrawRect(x + posX, y + posY, _width - 1, _height - 1);
        }
        else if (_rectangleType == RECT_FILL)
        {
            // Rectangle filled
            g.FillRect(x + posX, y + posY, _width, _height);
        }
        else
        {
            // Rectangle gradient
            x += posX;
            y += posY;
            int var4 = x + _width;

            for (var h = 0; h < _height; ++h)
            {
                int gradientIndex = _height - h;

                int gradientRed = (_redChannel * gradientIndex + _gradientTargetRed * h) / _height;
                int gradientGreen = (_greenChannel * gradientIndex + _gradientTargetGreen * h) / _height;
                int gradientBlue = (_blueChannel * gradientIndex + _gradientTargetBlue * h) / _height;

                g.SetColor(Graphics.GetColorOfRGB(gradientRed, gradientGreen, gradientBlue));
                g.DrawLine(x, y + h, var4, y + h);
            }
        }
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return _width;
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return _height;
    }

    [FunctionName("a")]
    public void SetSize(int width, int height)
    {
        _width = width;
        _height = height;
    }

    [FunctionName("a")]
    public void SetRect(int x, int y, int width, int height)
    {
        SetPosition(x, y);
        SetSize(width, height);
    }

    [FunctionName("b")]
    public void SetColor(int r, int g, int b, int a)
    {
        _redChannel = r;
        _greenChannel = g;
        _blueChannel = b;

        _color = Graphics.GetColorOfRGB(r, g, b, a);
    }

    [FunctionName("a")]
    protected override void Update(Graphics var1)
    {
        if (_transitionState != 0)
        {
            if (_transitionState == 3)
            {
                if (++_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 4;
                }

                _alphaChannel = 255 * _transitionFrame / _transitionFrameCount;
            }
            else if (_transitionState == 1)
            {
                if (_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 2;
                    _alphaChannel = 0;
                }
                else
                {
                    _alphaChannel = 255 - 255 * _transitionFrame / _transitionFrameCount;
                    ++_transitionFrame;
                }
            }
            else
            {
                _transitionState = 0;
            }

            SetColor(_redChannel, _greenChannel, _blueChannel, _alphaChannel);
        }
    }
}
