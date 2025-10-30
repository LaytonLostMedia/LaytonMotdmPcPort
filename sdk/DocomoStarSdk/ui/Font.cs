using System.Drawing;

namespace com.nttdocomostar.ui;

public class Font
{
    // Locale:
    // jp: MS Gothic
    // en: Lucida Console

    // Size:
    // LARGE  - 0x70000300 - 24
    // MEDIUM - 0x70000200 - 18
    // SMALL  - 0x70000100 - 12
    // TINY   - 0x70000400 - 9

    private static readonly IDictionary<int, float> FontSizeLookup = new Dictionary<int, float>
    {
        [0x70000400] = 9,
        [0x70000100] = 12,
        [0x70000200] = 18,
        [0x70000300] = 24
    };

    private static readonly string FontName = "MS Gothic";
    private static readonly IDictionary<int, IDictionary<float, System.Drawing.Font>> Fonts = new Dictionary<int, IDictionary<float, System.Drawing.Font>>();

    private readonly System.Drawing.Font _systemFont;
    private readonly System.Drawing.Graphics _stringMeasuring;

    private readonly double _ascentPx;
    private readonly float _height;

    public static Font GetFont(int fontId)
    {
        if (!Fonts.TryGetValue(fontId, out IDictionary<float, System.Drawing.Font>? loadedFonts))
            Fonts[fontId] = loadedFonts = new Dictionary<float, System.Drawing.Font>();

        if (!FontSizeLookup.TryGetValue(fontId, out float fontSize))
            fontSize = FontSizeLookup[0x70000400];

        System.Drawing.Font loadedFont = Fonts[fontId][fontSize] = new System.Drawing.Font(new FontFamily(FontName), fontSize);

        return new Font(loadedFont);
    }

    public static Font GetFont(int fontId, float fontSize)
    {
        if (!Fonts.TryGetValue(fontId, out IDictionary<float, System.Drawing.Font>? loadedFonts))
            Fonts[fontId] = loadedFonts = new Dictionary<float, System.Drawing.Font>();

        if (!loadedFonts.TryGetValue(fontSize, out System.Drawing.Font? loadedFont))
            Fonts[fontId][fontSize] = loadedFont = new System.Drawing.Font(new FontFamily(FontName), fontSize);

        return new Font(loadedFont);
    }

    public System.Drawing.Font GetNativeFont() => _systemFont;

    private Font(System.Drawing.Font systemSystemFont)
    {
        _systemFont = systemSystemFont;
        _stringMeasuring = System.Drawing.Graphics.FromImage(new Bitmap(1, 1));

        _ascentPx = Math.Round((double)_systemFont.FontFamily.GetCellAscent(FontStyle.Regular) /
                               (double)_systemFont.FontFamily.GetEmHeight(FontStyle.Regular));
        _height = _systemFont.GetHeight();
    }

    public int GetAscent() => (int)_ascentPx;
    public int GetHeight() => (int)_height;

    public int GetBoundingBoxWidth(string t) => (int)_stringMeasuring.MeasureString(t, _systemFont).Width;

    public int StringWidth(string s) => (int)_stringMeasuring.MeasureString(s, _systemFont).Width;
    public int GetLineBreak(string s, int start, int length, int a) => 0;
}