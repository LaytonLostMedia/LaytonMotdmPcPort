using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm6.c.Resources;

[ClassName("c", "z")]
public class KeyboardResource : ResourceBase
{
    [MemberName("a")]
    private int a;
    [MemberName("k")]
    private int k;
    [MemberName("l")]
    private Image l;
    [MemberName("m")]
    private int _width;
    [MemberName("n")]
    private int _height;
    [MemberName("o")]
    private int o;
    [MemberName("p")]
    private JavaString p;
    [MemberName("q")]
    private int q;
    [MemberName("r")]
    private int r;
    [MemberName("s")]
    private int s;
    [MemberName("t")]
    private int t;
    [MemberName("u")]
    private int[] u;

    [ConstructorName("z")]
    private KeyboardResource()
    {
    }

    [FunctionName("a")]
    public static KeyboardResource Create(Image paramImage, int width, int height, int paramInt3, JavaString paramString)
    {
        KeyboardResource z1;
        (z1 = new KeyboardResource()).Setup(paramImage, width, height, paramInt3, "0123456789", -1, 0);
        z1.a1(paramString);
        z1.b1(0);
        return z1;
    }

    [FunctionName("a")]
    public static KeyboardResource Create(Image paramImage, int width, int height, int paramInt3, JavaString paramString, int paramInt4)
    {
        KeyboardResource z1;
        (z1 = new KeyboardResource()).Setup(paramImage, width, height, paramInt3, "0123456789", -1, paramInt4);
        z1.a1(paramString);
        z1.b1(0);
        return z1;
    }

    [FunctionName("a")]
    public static KeyboardResource Create(Image paramImage, int width, int height, int paramInt3, int paramInt4)
    {
        KeyboardResource z1;
        (z1 = new KeyboardResource()).Setup(paramImage, width, height, paramInt3, "0123456789", -1, 0);
        z1.a1($"{paramInt4}");
        z1.b1(0);
        return z1;
    }

    [FunctionName("a")]
    private void Setup(Image paramImage, int width, int height, int paramInt3, JavaString paramString, int paramInt4, int paramInt5)
    {
        l = paramImage;
        _width = width;
        _height = height;
        o = paramInt3;
        s = height;
        p = paramString;
        q = paramInt4;
        t = paramInt5;
    }

    [FunctionName("a")]
    public void a1(JavaString paramString)
    {
        byte[] arrayOfByte = JavaString.GetBytes(paramString);
        int i = paramString.Length;
        u = new int[i];
        for (byte b = 0; b < i; b++)
            u[b] = p.IndexOf((char)arrayOfByte[b]);
        r = _width * i;
        b1(a);
    }

    [FunctionName("a")]
    public void a1(int paramInt)
    {
        bool boolValue = false;
        int i = u.Length - 1;
        if (paramInt < 0)
        {
            paramInt = -paramInt;
            boolValue = true;
        }
        do
        {
            u[i] = paramInt % 10;
            paramInt /= 10;
        } while (--i >= 0 && paramInt != 0);
        if (boolValue && i >= 0)
            u[i--] = q;
        while (i >= 0)
        {
            u[i] = -1;
            i--;
        }
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        int i = x + posX + k;
        int j = y + posY;
        byte b = 0;
        while (b < u.Length)
        {
            int k;
            if ((k = u[b]) >= 0)
                g.DrawImage(l, i + b * t + b, j, k % o * _width, k / o * _height, _width, _height);
            b++;
            i += _width;
        }
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return r;
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return s;
    }

    [FunctionName("b")]
    public void b1(int paramInt)
    {
        a = paramInt;
        k = 0;
        if (a == 1)
        {
            k -= GetWidth() / 2;
            return;
        }
        if (a == 2)
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
            l.SetAlpha(_alphaChannel);
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
