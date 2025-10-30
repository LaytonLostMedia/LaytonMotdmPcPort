using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm1.c.Resources;

[ClassName("c", "z")]
public class KeyboardResource : ResourceBase
{
    [MemberName("a")]
    private int _anchor;
    [MemberName("k")]
    private int k;
    [MemberName("l")]
    private Image _cellImage;
    [MemberName("m")]
    private int _cellWidth;
    [MemberName("n")]
    private int _cellHeight;
    [MemberName("o")]
    private int o;
    [MemberName("p")]
    private JavaString _keyboardInputs;
    [MemberName("q")]
    private int q;
    [MemberName("r")]
    private int _solutionWidth;
    [MemberName("s")]
    private int s;
    [MemberName("t")]
    private int t;
    [MemberName("u")]
    private int[] _input;

    [ConstructorName("z")]
    private KeyboardResource()
    {
    }

    [FunctionName("a")]
    public static KeyboardResource Create(Image cellImage, int width, int height, int paramInt3, JavaString presetInput)
    {
        KeyboardResource z1;
        (z1 = new KeyboardResource()).Setup(cellImage, width, height, paramInt3, "0123456789", -1, 0);
        z1.SetInput(presetInput);
        z1.SetAnchorType(0);
        return z1;
    }

    [FunctionName("a")]
    public static KeyboardResource Create(Image cellImage, int width, int height, int paramInt3, JavaString presetInput, int paramInt4)
    {
        KeyboardResource z1;
        (z1 = new KeyboardResource()).Setup(cellImage, width, height, paramInt3, "0123456789", -1, paramInt4);
        z1.SetInput(presetInput);
        z1.SetAnchorType(0);
        return z1;
    }

    [FunctionName("a")]
    public static KeyboardResource Create(Image cellImage, int width, int height, int paramInt3, int presetInput)
    {
        KeyboardResource z1;
        (z1 = new KeyboardResource()).Setup(cellImage, width, height, paramInt3, "0123456789", -1, 0);
        z1.SetInput($"{presetInput}");
        z1.SetAnchorType(0);
        return z1;
    }

    [FunctionName("a")]
    private void Setup(Image cellImage, int cellWidth, int cellHeight, int paramInt3, JavaString possibleInputs, int paramInt4, int paramInt5)
    {
        _cellImage = cellImage;
        _cellWidth = cellWidth;
        _cellHeight = cellHeight;
        o = paramInt3;
        s = cellHeight;
        _keyboardInputs = possibleInputs;
        q = paramInt4;
        t = paramInt5;
    }

    [FunctionName("a")]
    public void SetInput(JavaString paramString)
    {
        byte[] arrayOfByte = JavaString.GetBytes(paramString);
        int i = paramString.Length;
        _input = new int[i];
        for (byte b = 0; b < i; b++)
            _input[b] = _keyboardInputs.IndexOf((char)arrayOfByte[b]);
        _solutionWidth = _cellWidth * i;
        SetAnchorType(_anchor);
    }

    [FunctionName("a")]
    public void a1(int paramInt)
    {
        bool boolValue = false;
        int i = _input.Length - 1;
        if (paramInt < 0)
        {
            paramInt = -paramInt;
            boolValue = true;
        }
        do
        {
            _input[i] = paramInt % 10;
            paramInt /= 10;
        } while (--i >= 0 && paramInt != 0);
        if (boolValue && i >= 0)
            _input[i--] = q;
        while (i >= 0)
        {
            _input[i] = -1;
            i--;
        }
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        int i = x + posX + k;
        int j = y + posY;
        byte b = 0;
        while (b < _input.Length)
        {
            int k;
            if ((k = _input[b]) >= 0)
                g.DrawImage(_cellImage, i + b * t + b, j, k % o * _cellWidth, k / o * _cellHeight, _cellWidth, _cellHeight);
            b++;
            i += _cellWidth;
        }
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return _solutionWidth;
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return s;
    }

    [FunctionName("b")]
    public void SetAnchorType(int paramInt)
    {
        _anchor = paramInt;
        k = 0;
        if (_anchor == ANCHOR_CENTER)
        {
            k -= GetWidth() / 2;
            return;
        }
        if (_anchor == ANCHOR_RIGHT)
            k -= GetWidth();
    }

    [FunctionName("a")]
    protected override void Update(Graphics paramGraphics)
    {
        if (_transitionState != 0)
        {
            if (_transitionState == 3)
            {
                if (++_transitionFrame == _transitionFrameCount)
                    _transitionState = 4;
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
                    _transitionFrame++;
                }
            }
            else
            {
                _transitionState = 0;
            }
            _cellImage.SetAlpha(_alphaChannel);
        }
    }

    static KeyboardResource()
    {
        (new int[4])[0] = 0;
        (new int[4])[1] = 30;
        (new int[4])[2] = 60;
        (new int[4])[3] = 10;
        (new int[1][])[0] = new int[4];
        (new JavaString[1])[0] = "0123456789";
    }
}
