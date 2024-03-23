using DocomoCsJavaBridge.Aspects;

namespace DocomoLayton.game.Resources;

using com.nttdocomo.ui;

[ClassName("c","c")]
public class ScreenResource : ResourceBase
{
    [MemberName("l")]
    private int _width;
    [MemberName("m")]
    private int _height;
    [MemberName("a")]
    public ResourceBase _textResource = null;
    [MemberName("k")]
    public bool _visible;

    [ConstructorName("c")]
    public ScreenResource(int var1, int var2)
    {
        _width = var1;
        _height = var2;
        Reset();
        _alphaChannel = 255;
    }

    [FunctionName("b")]
    public void Paint(Graphics var1)
    {
        Paint(var1, 0, 0);
        _textResource.Paint(var1, 0, 0);
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
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

    [FunctionName("c")]
    public void MarkVisible()
    {
        _visible = true;
    }

    [FunctionName("d")]
    public void SetVisible()
    {
        MarkVisible();
        _textResource.SetIsVisible(true);
    }

    [FunctionName("i")]
    private void Reset()
    {
        if (_textResource == null)
        {
            _textResource = TextResource.Create("", 255, 255, 255);
            _textResource.SetPosition(0, 0);
            _textResource.SetIsVisible(false);
        }
    }

    [FunctionName("a")]
    protected override void Update(Graphics var1)
    {
        if (_transitionState != 0)
        {
            if (_transitionState == 1)
            {
                if (++_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 2;
                    if (_visible)
                    {
                        _textResource.SetIsVisible(true);
                    }
                }

                _alphaChannel = 255 * _transitionFrame / _transitionFrameCount;
            }
            else if (_transitionState == 3)
            {
                if (_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 0;
                    _alphaChannel = 0;
                }
                else
                {
                    _alphaChannel = 255 - 255 * _transitionFrame / _transitionFrameCount;
                    ++_transitionFrame;
                }

                _visible = false;
                _textResource.SetIsVisible(false);
            }

            var1.SetColor(Graphics.GetColorOfRGB(0, 0, 0, _alphaChannel));
            var1.FillRect(0, 0, GetWidth(), GetHeight());
        }
    }
}