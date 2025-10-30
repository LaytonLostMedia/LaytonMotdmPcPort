using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm1.c.Files.Models;

[ClassName("c","r")]
public class ImagePartsData
{
    [MemberName("a")]
    private Image[] _images;
    [MemberName("b")]
    private int[,] _parts;

    [ConstructorName("r")]
    private ImagePartsData()
    {
    }

    [FunctionName("a")]
    public static ImagePartsData Create(Image[] images, int[,] partInfos)
    {
        ImagePartsData r1;
        (r1 = new ImagePartsData())._images = images;
        r1._parts = partInfos;

        return r1;
    }

    [FunctionName("a")]
    public void Destroy()
    {
        if (_images != null)
            for (byte b = 0; b < _images.Length; b++)
            {
                if (_images[b] != null)
                {
                    _images[b].Dispose();
                    _images[b] = null;
                }
            }
        _images = null;
        _parts = null;
    }

    [FunctionName("a")]
    public Image GetImage(int partIndex)
    {
        return _images[_parts[partIndex, 0]];
    }

    [FunctionName("a")]
    public int GetPartInfo(int partIndex, int valueIndex)
    {
        return _parts[partIndex, valueIndex];
    }
}
