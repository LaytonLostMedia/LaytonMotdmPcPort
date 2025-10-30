using System.Drawing;
using System.Drawing.Imaging;
using com.nttdocomo.opt.ui;

namespace com.nttdocomo.ui;

public class Graphics
{
    private readonly Image _img;
    private readonly System.Drawing.Graphics _g;

    private Point _origin;
    private Font _font;
    private Color _color;
    private int _flipMode;

    public const int FLIP_NONE = 0;
    public const int FLIP_HORIZONTAL = 1;
    public const int FLIP_ROTATE_180 = 2;
    public const int FLIP_VERTICAL = 3;
    public const int FLIP_ROTATE_LEFT = 4;
    public const int FLIP_ROTATE_RIGHT = 5;
    public const int FLIP_UNK = 6;

    public Graphics(Image img)
    {
        _img = img;
        _g = System.Drawing.Graphics.FromImage(img.GetNativeImage());
    }

    public void CopyImage(System.Drawing.Image dest, Point p)
    {
        using System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dest);

        System.Drawing.Image nativeImg = _img.GetNativeImage();
        g.DrawImage(nativeImg, new Rectangle(p, dest.Size));
    }

    public void SetFont(Font font) => _font = font;
    public void Lock() { }
    public void Unlock(bool b) { }

    public void DrawImage(Image image, int x, int y)
    {
        System.Drawing.Image nativeImg = image.GetNativeImage();

        ApplyFlipMode(nativeImg);

        _g.DrawImage(nativeImg, _origin.X + x, _origin.Y + y);

        RevertFlipMode(nativeImg);
    }

    public void DrawImage(Image image, int[] destTransform)
    {
        System.Drawing.Image nativeImg = image.GetNativeImage();

        ApplyFlipMode(nativeImg);

        var destPoints = new PointF[]
        {
            new(_origin.X, _origin.Y),
            new(_origin.X + image.GetWidth(), _origin.Y),
            new(_origin.X, _origin.Y + image.GetHeight()),
        };

        var matrix = new System.Drawing.Drawing2D.Matrix(
            destTransform[0] / 4096f, destTransform[3] / 4096f,
            destTransform[1] / 4096f, destTransform[4] / 4096f,
            destTransform[2] / 4096f, destTransform[5] / 4096f);
        matrix.TransformPoints(destPoints);

        _g.DrawImage(nativeImg, destPoints);

        RevertFlipMode(nativeImg);
    }

    public void DrawImage(Image image, int x, int y, int srcX, int srcY, int srcWidth, int srcHeight)
    {
        System.Drawing.Image nativeImg = image.GetNativeImage();

        ApplyFlipMode(nativeImg);

        var srcRect = new RectangleF(srcX, srcY, srcWidth, srcHeight);
        srcRect = ApplyFlipMode(srcRect, nativeImg.Width, nativeImg.Height);

        _g.DrawImage(nativeImg, _origin.X + x, _origin.Y + y, srcRect, GraphicsUnit.Pixel);

        RevertFlipMode(nativeImg);
    }

    public void DrawImage(Image image, int[] destTransform, int srcX, int srcY, int srcWidth, int srcHeight)
    {
        System.Drawing.Image nativeImg = image.GetNativeImage();

        ApplyFlipMode(nativeImg);

        var srcRect = new RectangleF(srcX, srcY, srcWidth, srcHeight);
        srcRect = ApplyFlipMode(srcRect, nativeImg.Width, nativeImg.Height);

        var destPoints = new PointF[]
        {
            new(_origin.X, _origin.Y),
            new(_origin.X + image.GetWidth(), _origin.Y),
            new(_origin.X, _origin.Y + image.GetHeight()),
        };

        var matrix = new System.Drawing.Drawing2D.Matrix(
            destTransform[0] / 4096f, destTransform[3] / 4096f,
            destTransform[1] / 4096f, destTransform[4] / 4096f,
            destTransform[2] / 4096f, destTransform[5] / 4096f);
        matrix.TransformPoints(destPoints);

        _g.DrawImage(nativeImg, destPoints, srcRect, GraphicsUnit.Pixel);

        RevertFlipMode(nativeImg);
    }

    public void DrawRect(int x, int y, int width, int height)
    {
        _g.DrawRectangle(new Pen(_color), _origin.X + x, _origin.Y + y, width, height);
    }

    public void DrawLine(int x, int y, int x2, int y2)
    {
        _g.DrawLine(new Pen(_color), new Point(_origin.X + x, _origin.Y + y), new Point(_origin.X + x2, _origin.Y + y2));
    }

    public void DrawString(string text, int x, int y)
    {
        _g.DrawString(text, _font.GetNativeFont(), new SolidBrush(_color), new Point(_origin.X + x, _origin.Y + y));
    }

    public static int GetColorOfRGB(int r, int g, int b) => Color.FromArgb(r, g, b).ToArgb();
    public static int GetColorOfRGB(int r, int g, int b, int a) => Color.FromArgb(a, r, g, b).ToArgb();

    public static int GetColorOfName(int index)
    {
        switch (index)
        {
            case 0:
                return Color.Black.ToArgb();

            default:
                throw new InvalidOperationException($"invalid color index {index}.");
        }
    }

    public void SetFlipMode(int mode) => _flipMode = mode;
    public void SetColor(int color) => _color = Color.FromArgb(color);

    public void GetPixels(int a, int b, int c, int d, int[] ea, int f) { }
    public void SetPixels(int a, int b, int c, int d, int[] ea, int f) { }

    public void FillRect(int x, int y, int width, int height)
    {
        _g.FillRectangle(new SolidBrush(_color), new Rectangle(_origin.X + x, _origin.Y + y, width, height));
    }

    public void SetOrigin(int a, int b)
    {
        _origin = new Point(a, b);
    }

    public void ClipRect(int x, int y, int width, int height)
    {
        _g.SetClip(new Rectangle(_origin.X + x, _origin.Y + y, width, height));
    }

    public unsafe void ClearRect(int x, int y, int width, int height)
    {
        var nativeImg = (Bitmap)_img.GetNativeImage();

        var bmpData = nativeImg.LockBits(new Rectangle(_origin.X + x, _origin.Y + y, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        var dataPtr = (int*)bmpData.Scan0;

        for (var i = 0; i < width * height; i++)
            dataPtr[i] = 0;

        nativeImg.UnlockBits(bmpData);
    }

    public void ClearClip()
    {
        _g.ResetClip();
    }

    public Graphics2 Copy() => new(_img);

    private void ApplyFlipMode(System.Drawing.Image img)
    {
        switch (_flipMode)
        {
            case FLIP_ROTATE_180:
                img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                break;

            case FLIP_ROTATE_LEFT:
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                break;

            case FLIP_ROTATE_RIGHT:
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                break;

            case FLIP_HORIZONTAL:
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                break;

            case FLIP_VERTICAL:
                img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                break;
        }
    }

    private RectangleF ApplyFlipMode(RectangleF rect, int imgWidth, int imgHeight)
    {
        switch (_flipMode)
        {
            case FLIP_ROTATE_LEFT:
                return new RectangleF(rect.Y, imgWidth - (rect.X + rect.Width), rect.Height, rect.Width);

            case FLIP_ROTATE_RIGHT:
                return new RectangleF(imgHeight - (rect.Y + rect.Height), rect.X, rect.Height, rect.Width);

            case FLIP_ROTATE_180:
                return rect with { X = imgWidth - (rect.X + rect.Width), Y = imgHeight - (rect.Y + rect.Height) };

            case FLIP_VERTICAL:
                return rect with { Y = imgHeight - (rect.Y + rect.Height) };

            case FLIP_HORIZONTAL:
                return rect with { X = imgWidth - (rect.X + rect.Width) };

            default:
                return rect;
        }
    }

    private void RevertFlipMode(System.Drawing.Image img)
    {
        switch (_flipMode)
        {
            case FLIP_ROTATE_180:
                img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                break;

            case FLIP_ROTATE_LEFT:
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                break;

            case FLIP_ROTATE_RIGHT:
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                break;

            case FLIP_HORIZONTAL:
                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                break;

            case FLIP_VERTICAL:
                img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                break;
        }
    }
}
