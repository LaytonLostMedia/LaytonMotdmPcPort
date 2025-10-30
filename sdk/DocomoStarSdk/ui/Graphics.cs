using System.Drawing;
using System.Drawing.Imaging;

namespace com.nttdocomostar.ui;

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

    public void CopyArea(int var1, int var2, int var3, int var4, int var5, int var6)
    {

    }

    public void SetFont(Font font) => _font = font;
    public void Lock() { }
    public void Unlock(bool b) { }

    public int[] GetRGBPixels(int x, int y, int width, int height, int[] var1, int var2)
    {
        return new int[width * height];
    }

    public void SetPixel(int x, int y)
    {
        // Use "_color" value for pixel
    }

    public int GetPixel(int x, int y)
    {
        return 0;
    }

    public void SetRGBPixels(int x, int y, int width, int height, int[] var1, int var2)
    {
        
    }

    public int GetRGBPixel(int x, int y)
    {
        return 0;
    }

    public void SetPictoColorEnabled(bool toggle)
    {

    }

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

    public void DrawScaledImage(Image image, int x, int y, int width, int height, int srcX, int srcY, int srcWidth, int srcHeight)
    {
        System.Drawing.Image nativeImg = image.GetNativeImage();

        ApplyFlipMode(nativeImg);

        var rect = new RectangleF(_origin.X + x, _origin.Y + y, width, height);
        rect = ApplyFlipMode(rect, nativeImg.Width, nativeImg.Height);

        var srcRect = new RectangleF(srcX, srcY, srcWidth, srcHeight);
        srcRect = ApplyFlipMode(srcRect, nativeImg.Width, nativeImg.Height);

        _g.DrawImage(nativeImg, rect, srcRect, GraphicsUnit.Pixel);

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

    public void DrawPolyline(int[] var1, int[] var2, int var3)
    {

    }

    public static int GetColorOfRGB(int r, int g, int b) => Color.FromArgb(r, g, b).ToArgb();
    public static int GetColorOfRGB(int r, int g, int b, int a) => Color.FromArgb(a, r, g, b).ToArgb();

    public static int GetColorOfName(int index)
    {
        // https://www.multiphasicapps.net/file?name=modules/vendor-api-ntt-docomo-doja/src/main/java/com/nttdocomo/ui/Graphics.java&ci=tip
        switch (index)
        {
            case 0:
                return Color.Black.ToArgb();

            case 1:
                return Color.Blue.ToArgb();

            case 2:
                return Color.Lime.ToArgb();

            case 3:
                return Color.Aqua.ToArgb();

            case 4:
                return Color.Red.ToArgb();

            case 5:
                return Color.Fuchsia.ToArgb();

            case 6:
                return Color.Yellow.ToArgb();

            case 7:
                return Color.White.ToArgb();

            case 8:
                return Color.Gray.ToArgb();

            case 9:
                return Color.Navy.ToArgb();

            case 10:
                return Color.Green.ToArgb();

            case 11:
                return Color.Teal.ToArgb();

            case 12:
                return Color.Maroon.ToArgb();

            case 13:
                return Color.Purple.ToArgb();

            case 14:
                return Color.Olive.ToArgb();

            case 15:
                return Color.Silver.ToArgb();

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

    public void FillArc(int var1, int var2, int var3, int var4, int var5, int var6)
    {

    }

    public void FillPolygon(int[] var1, int[] var2, int var3)
    {

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
