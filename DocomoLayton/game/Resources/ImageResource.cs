using com.nttdocomo.ui.util3d;
using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace DocomoLayton.game.Resources;

[ClassName("c", "b")]
public class ImageResource : ResourceBase
{
    [MemberName("k")]
    private Image _img = null;

    [MemberName("a")]
    public Palette a = null;

    [MemberName("l")]
    private int _anchorType;
    [MemberName("m")]
    private int _anchorPosX;
    [MemberName("n")]
    private int _clipPosX;
    [MemberName("o")]
    private int _clipPosY;
    [MemberName("p")]
    private int _clipWidth;
    [MemberName("q")]
    private int _clipHeight;
    [MemberName("r")]
    private int _flipMode;
    [MemberName("s")]
    private bool _isClipped;
    [MemberName("t")]
    private int _width;
    [MemberName("u")]
    private int _height;
    [MemberName("v")]
    private float v;
    [MemberName("w")]
    private float w;
    [MemberName("x")]
    private float _sizeScale;
    [MemberName("y")]
    private bool _isResized;
    [MemberName("z")]
    private int[] z = null;
    [MemberName("A")]
    private int A = 0;
    [MemberName("B")]
    private int B = 0;
    [MemberName("C")]
    private int C = 0;
    [MemberName("D")]
    private int D = 0;
    [MemberName("E")]
    private int E = 4;
    [MemberName("F")]
    private int F = 0;
    [MemberName("G")]
    private int[] G = null;
    [MemberName("H")]
    private bool H = false;
    [MemberName("I")]
    private bool I = false;
    [MemberName("J")]
    private bool J = false;

    [ConstructorName("b")]
    private ImageResource()
    {
        _posX = 0;
        _posY = 0;
        _width = 0;
        _height = 0;
        v = 1.0F;
        w = 1.0F;
        _sizeScale = 0.0F;
        _isResized = false;
        _alphaChannel = 255;
    }

    [FunctionName("a")]
    public static ImageResource Create(Image img)
    {
        var resource = new ImageResource
        {
            z = new int[6]
        };

        resource.SetImage(img);
        resource.SetAnchorType(ANCHOR_LEFT);
        resource.SetFlipMode(Graphics.FLIP_NONE);

        resource.a = null;

        return resource;
    }

    [FunctionName("a")]
    public static ImageResource Create(PalettedImage img)
    {
        ImageResource var1;
        (var1 = new ImageResource()).SetImage(img);
        Palette var2 = img.GetPalette();
        var1.a = new Palette(var2.GetEntryCount());

        for (int var3 = 0; var3 < var2.GetEntryCount(); ++var3)
            var1.a.SetEntry(var3, var2.GetEntry(var3));

        var1.SetAnchorType(ANCHOR_LEFT);
        var1.SetFlipMode(Graphics.FLIP_NONE);

        return var1;
    }

    [FunctionName("a")]
    public static ImageResource Create(ImageResource var0)
    {
        ImageResource var1;
        (var1 = new ImageResource()).SetImage(var0._img);
        var1.SetAnchorType(var0._anchorType);
        var1.SetFlipMode(var0._flipMode);
        var1._posX = var0._posX;
        var1._posY = var0._posY;
        if (var0.a != null)
        {
            Palette var2 = var0.a;
            var1.a = new Palette(var2.GetEntryCount());

            for (int var3 = 0; var3 < var2.GetEntryCount(); ++var3)
            {
                var1.a.SetEntry(var3, var2.GetEntry(var3));
            }
        }

        return var1;
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        if (_img != null)
        {
            g.SetFlipMode(_flipMode);
            if (_isResized)
            {
                float var4 = FastMath.Cos(_sizeScale);
                float var5 = FastMath.Sin(_sizeScale);
                z[0] = (int)(4096.0F * var4 * v);
                z[1] = (int)(4096.0F * -var5 * w);
                z[2] = (int)(4096.0F * (_posX + (float)x + _anchorPosX + _width - _width * var4 * v + _height * var5 * w));
                z[3] = (int)(4096.0F * var5 * v);
                z[4] = (int)(4096.0F * var4 * w);
                z[5] = (int)(4096.0F * (_posY + (float)y + _height - _width * var5 * v - _height * var4 * w));
                if (_isClipped)
                {
                    g.DrawImage(_img, z, _clipPosX, _clipPosY, _clipWidth, _clipHeight);
                    i();
                }
                else
                {
                    g.DrawImage(_img, z);
                }
            }
            else
            {
                if (a != null)
                {
                    ((PalettedImage)_img).SetPalette(a);
                }

                if (_isClipped)
                {
                    g.DrawImage(_img, x + _posX + _anchorPosX, y + _posY, _clipPosX, _clipPosY, _clipWidth, _clipHeight);
                    i();
                }
                else
                {
                    g.DrawImage(_img, x + _posX + _anchorPosX, y + _posY);
                }
            }

            g.SetFlipMode(0);
        }
    }

    [FunctionName("a")]
    public void SetScale(float var1)
    {
        _sizeScale = var1;
        _isResized = true;
    }

    [FunctionName("a")]
    public void SetSize(int var1, int var2)
    {
        _width = var1;
        _height = var2;
        _isResized = true;
    }

    [FunctionName("a")]
    public void ClipRect(int x, int y, int width, int height)
    {
        _clipPosX = x;
        _clipPosY = y;
        _clipWidth = width;
        _clipHeight = height;
        _isClipped = true;
        SetAnchorType(_anchorType);
    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return _clipWidth;
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return _clipHeight;
    }

    [FunctionName("b")]
    public void SetImage(Image img)
    {
        _img = img;
        if (img != null)
        {
            _clipWidth = img.GetWidth();
            _clipHeight = img.GetHeight();
        }
        else
        {
            _clipWidth = 0;
            _clipHeight = 0;
        }

        SetAnchorType(_anchorType);
        SetAlpha(_alphaChannel);
    }

    /// <summary>
    /// Sets the anchor position of the image.
    /// </summary>
    /// <param name="anchorType">The anchor type. 0 = Left; 1 = Center; 2 = Right</param>
    [FunctionName("a")]
    public void SetAnchorType(int anchorType)
    {
        _anchorType = anchorType;
        _anchorPosX = 0;

        if (_anchorType == ANCHOR_CENTER)
        {
            _anchorPosX -= GetWidth() / 2;
        }
        else
        {
            if (_anchorType == ANCHOR_RIGHT)
            {
                _anchorPosX -= GetWidth();
            }

        }
    }

    /// <summary>
    /// Sets the flip mode to rotate or flip the image resource.
    /// </summary>
    /// <param name="flipMode">The flip and rotation mode.</param>
    [FunctionName("b")]
    public void SetFlipMode(int flipMode)
    {
        _flipMode = flipMode;
    }

    [FunctionName("c")]
    public int GetFlipMode()
    {
        return _flipMode;
    }

    [FunctionName("b")]
    public void b1(int var1, int var2, int var3, int var4)
    {
        _clipPosX = var1;
        _clipPosY = var2;
        _clipWidth = var3;
        _clipHeight = var4;
        _isClipped = true;
        I = true;
        J = false;
        SetAnchorType(_anchorType);
        A = _img.GetWidth() / _clipWidth;
    }

    [FunctionName("b")]
    public void b1(int var1, int var2)
    {
        C = var1;
        E = var2;
    }

    [FunctionName("i")]
    private void i()
    {
        if (I)
        {
            if (H)
            {
                ++D;
                if (D > C)
                {
                    D = 0;
                    H = false;
                }
            }
            else
            {
                ++F;
                if (F >= E)
                {
                    F = 0;
                    ++B;
                    if (B >= A)
                    {
                        B = 0;
                        if (J)
                        {
                            _clipPosX = _clipWidth * G[B];
                        }
                        else
                        {
                            _clipPosX = 0;
                        }

                        if (C != 0)
                        {
                            H = true;
                        }
                    }
                    else if (J)
                    {
                        _clipPosX = _clipWidth * G[B];
                    }
                    else
                    {
                        _clipPosX = B * _clipWidth;
                    }

                    _clipPosY = 0;
                    if (_clipPosX >= _img.GetWidth())
                    {
                        _clipPosY += _clipHeight;
                        _clipPosX -= _img.GetWidth();
                    }
                }
            }
        }
    }

    [FunctionName("c")]
    public void SetAlpha(int var1)
    {
        if (_img != null)
        {
            _alphaChannel = var1;
            _img.SetAlpha(var1);
        }
        else
        {
            _alphaChannel = 255;
        }
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
                if (++_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 2;
                    _alphaChannel = 0;
                }
                else
                {
                    _alphaChannel = 255 - 255 * _transitionFrame / _transitionFrameCount;
                }
            }
            else
            {
                _transitionState = 0;
            }

            _img.SetAlpha(_alphaChannel);
        }
    }

    [FunctionName("a")]
    public void a1(int[] var1)
    {
        if (a != null)
        {
            for (int var2 = 0; var2 < var1.Length; ++var2)
            {
                a.SetEntry(var2, var1[var2]);
            }
        }
    }

    [FunctionName("d")]
    public void d()
    {
        _img = null;
        a = null;
        z = null;
        G = null;
    }
}
