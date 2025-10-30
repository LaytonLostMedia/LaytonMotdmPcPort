using System.Drawing;
using System.Drawing.Imaging;

namespace com.nttdocomo.ui;

public class Image : IDisposable
{
    private readonly System.Drawing.Image _img;
    private readonly HashSet<int> _visiblePaletteColors;

    public Image(byte[] data)
    {
        _img = System.Drawing.Image.FromStream(new MemoryStream(data));
        _visiblePaletteColors = new HashSet<int>();

        if (_img.PixelFormat == PixelFormat.Format8bppIndexed)
        {
            for (var i = 0; i < _img.Palette.Entries.Length; i++)
                if (_img.Palette.Entries[i].A == 255)
                    _visiblePaletteColors.Add(i);
        }
    }

    public Image(System.Drawing.Image nativeImg) => _img = nativeImg;

    private Image(int width, int height)
    {
        _img = new Bitmap(width, height);
    }

    public static Image CreateImage(int width, int height) => new(width, height);

    public System.Drawing.Image GetNativeImage() => _img;

    public int GetWidth() => _img.Width;
    public int GetHeight() => _img.Height;

    public unsafe void SetAlpha(int a)
    {
        var img = (Bitmap)_img;
        switch (img.PixelFormat)
        {
            case PixelFormat.Format8bppIndexed:
                ColorPalette palette = img.Palette;

                foreach (int visibleColorIndex in _visiblePaletteColors)
                {
                    Color color = palette.Entries[visibleColorIndex];
                    palette.Entries[visibleColorIndex] = Color.FromArgb(a, color.R, color.G, color.B);
                }

                img.Palette = palette;
                break;

            default:
                //var bmpData = ((Bitmap)_img).LockBits(new Rectangle(0, 0, _img.Width, _img.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                //var dataPtr = (byte*)bmpData.Scan0;

                //for (var i = 0; i < _img.Width * _img.Height * 4; i += 4)
                //    dataPtr[i + 3] = (byte)a;

                //((Bitmap)_img).UnlockBits(bmpData);
                break;
        }
    }

    public Graphics GetGraphics() => new(this);

    public void Dispose()
    {
        _img.Dispose();
    }
}
