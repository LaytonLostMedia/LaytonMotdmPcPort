//
// Source code recreated from a .class file by IntelliJ IDEA
// (powered by FernFlower decompiler)
//

using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm5.c.Resources;

[ClassName("c", "j")]
public class LineResource : ResourceBase
{
    [MemberName("a")]
    private int _targetX;
    [MemberName("k")]
    private int _targetY;
    [MemberName("l")]
    private int _r;
    [MemberName("m")]
    private int _g;
    [MemberName("n")]
    private int _b;
    [MemberName("o")]
    private int _color;

    [ConstructorName("j")]
    private LineResource()
    {
        posX = 0;
        posY = 0;
        _targetX = 0;
        _targetY = 0;
        _r = 0;
        _g = 0;
        _b = 0;
        _color = 0;
    }

    [FunctionName("a")]
    public static LineResource Create(int startX, int startY, int targetX, int targetY, int r, int g, int b)
    {
        LineResource var7;
        (var7 = new LineResource()).SetColor(r, g, b);
        var7.SetPosition(startX, startY);
        var7._targetX = targetX;
        var7._targetY = targetY;
        return var7;
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        g.SetColor(_color);
        g.DrawLine(x + posX, y + posY, x + _targetX, y + _targetY);
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return Math.Abs(posY - _targetY);
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return Math.Abs(posX - _targetX);
    }

    [FunctionName("c")]
    private void SetColor(int r, int g, int b)
    {
        _r = r;
        _g = g;
        _b = b;
        _color = Graphics.GetColorOfRGB(r, g, b);
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

            SetColor(_r, _g, _b);
        }
    }
}
