using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm4.c.Managers;

namespace LaytonMotdm4.c.Resources;

[ClassName("c", "ab")]
public abstract class FormattedTextResourceBase : ResourceBase
{
    [MemberName("a")]
    protected static int _totalLength = 8;
    [MemberName("k")]
    protected JavaString _totalText;
    [MemberName("l")]
    protected JavaString l;
    [MemberName("m")]
    protected ResourceBase[] m = new ResourceBase[4];
    [MemberName("n")]
    protected ResourceBase[] n = new ResourceBase[17];
    [MemberName("o")]
    protected ResourceBase[] o = new ResourceBase[8];
    [MemberName("p")]
    protected ResourceBase[] p = new ResourceBase[_totalLength];
    [MemberName("q")]
    protected ResourceBase q;
    [MemberName("r")]
    protected ResourceBase r = null;
    [MemberName("s")]
    protected int s;
    [MemberName("t")]
    protected int[] t = new int[3];
    [MemberName("u")]
    protected int u;
    [MemberName("v")]
    protected static JavaString[] v = { "レイトン", "ルーク" };
    [MemberName("w")]
    protected GameFileManager w = new();
    [MemberName("x")]
    protected JavaString[][][] Keyboards = {
        new[]
        {
            new JavaString[]{
                "あ", "か", "さ", "た", "な", "は", "ま", "や", "ら", "わ", "が", "ざ", "だ", "ば", "ぱ", "ゃ", "ぁ"
            },
            new JavaString[]{
                "い", "き", "し", "ち", "に", "ひ", "み", "ゆ", "り", "を", "ぎ", "じ", "ぢ", "び", "ぴ", "ゅ", "ぃ"
            },
            new JavaString[]{
                "う", "く", "す", "つ", "ぬ", "ふ", "む", "よ", "る", "ん", "ぐ", "ず", "づ", "ぶ", "ぷ", "ょ", "ぅ"
            },
            new JavaString[]{
                "え", "け", "せ", "て", "ね", "へ", "め", "！", "れ", "ー", "げ", "ぜ", "で", "べ", "ぺ", "っ", "ぇ"
            },
            new JavaString[]{
                "お", "こ", "そ", "と", "の", "ほ", "も", "？", "ろ", "ENCODE_1", "ご", "ぞ", "ど", "ぼ", "ぽ", "・", "ぉ"
            }
        },
        new[]
        {
            new JavaString[]{
                "ア", "カ", "サ", "タ", "ナ", "ハ", "マ", "ヤ", "ラ", "ワ", "ガ", "ザ", "ダ", "バ", "パ", "ャ", "ァ"
            },
            new JavaString[]{
                "イ", "キ", "シ", "チ", "ニ", "ヒ", "ミ", "ユ", "リ", "ヲ", "ギ", "ジ", "ヂ", "ビ", "ピ", "ュ", "ィ"
            },
            new JavaString[]{
                "ウ", "ク", "ス", "ツ", "ヌ", "フ", "ム", "ヨ", "ル", "ン", "グ", "ズ", "ヅ", "ブ", "プ", "ョ", "ゥ"
            },
            new JavaString[]{
                "エ", "ケ", "セ", "テ", "ネ", "ヘ", "メ", "！", "レ", "ー", "ゲ", "ゼ", "デ", "ベ", "ペ", "ッ", "ェ"
            },
            new JavaString[]{
                "オ", "コ", "ソ", "ト", "ノ", "ホ", "モ", "？", "ロ", "ENCODE_1", "ゴ", "ゾ", "ド", "ボ", "ポ", "ヴ", "ォ"
            }
        },
        new[]
        {
            new JavaString[]{
                "Ａ", "Ｂ", "Ｃ", "Ｄ", "Ｅ", "Ｆ", "Ｇ", "Ｈ", "Ｉ", "Ｊ", "Ｋ", "Ｌ", "Ｍ", "Ｎ", "Ｏ", "Ｐ", "Ｑ"
            },
            new JavaString[]{
                "Ｒ", "Ｓ", "Ｔ", "Ｕ", "Ｖ", "Ｗ", "Ｘ", "Ｙ", "Ｚ", "．", "…", "「", "」", "（", "）", "‘", "’"
            },
            new JavaString[]{
                "ａ", "ｂ", "ｃ", "ｄ", "ｅ", "ｆ", "ｇ", "ｈ", "ｉ", "ｊ", "ｋ", "ｌ", "ｍ", "ｎ", "ｏ", "ｐ", "ｑ"
            },
            new JavaString[]{
                "ｒ", "ｓ", "ｔ", "ｕ", "ｖ", "ｗ", "ｘ", "ｙ", "ｚ", "＠", "☆", "○", "△", "□", "＃", "♭", "♪"
            },
            new JavaString[]{
                "０", "１", "２", "３", "４", "５", "６", "７", "８", "９", "＋", "ENCODE_2", "×", "÷", "＝", "∞", "＆"
            }
        },
        new[]
        {
            new JavaString[]{
                "あ", "か", "さ", "た", "な", "は", "ま", "や", "ら", "わ", "が", "ざ", "だ", "ば", "ぱ", "ゃ", "ぁ"
            },
            new JavaString[]{
                "い", "き", "し", "ち", "に", "ひ", "み", "ゆ", "り", "を", "ぎ", "じ", "ぢ", "び", "ぴ", "ゅ", "ぃ"
            },
            new JavaString[]{
                "う", "く", "す", "つ", "ぬ", "ふ", "む", "よ", "る", "ん", "ぐ", "ず", "づ", "ぶ", "ぷ", "ょ", "ぅ"
            },
            new JavaString[]{
                "え", "け", "せ", "て", "ね", "へ", "め", "｜", "れ", "｜", "げ", "ぜ", "で", "べ", "ぺ", "っ", "ぇ"
            },
            new JavaString[]{
                "お", "こ", "そ", "と", "の", "ほ", "も", "｜", "ろ", "｜", "ご", "ぞ", "ど", "ぼ", "ぽ", "｜", "ぉ"
            }
        },
        new[]
        {
            new JavaString[] {
                "ア", "カ", "サ", "タ", "ナ", "ハ", "マ", "ヤ", "ラ", "ワ", "ガ", "ザ", "ダ", "バ", "パ", "ャ", "ァ"
            },
            new JavaString[]{
                "イ", "キ", "シ", "チ", "ニ", "ヒ", "ミ", "ユ", "リ", "ヲ", "ギ", "ジ", "ヂ", "ビ", "ピ", "ュ", "ィ"
            },
            new JavaString[]{
                "ウ", "ク", "ス", "ツ", "ヌ", "フ", "ム", "ヨ", "ル", "ン", "グ", "ズ", "ヅ", "ブ", "プ", "ョ", "ゥ"
            },
            new JavaString[]{
                "エ", "ケ", "セ", "テ", "ネ", "ヘ", "メ", "｜", "レ", "｜", "ゲ", "ゼ", "デ", "ベ", "ペ", "ッ", "ェ"
            },
            new JavaString[]{
                "オ", "コ", "ソ", "ト", "ノ", "ホ", "モ", "｜", "ロ", "｜", "ゴ", "ゾ", "ド", "ボ", "ポ", "ヴ", "ォ"
            }
        },
        new[]
        {
            new JavaString[]{
                "Ａ", "Ｂ", "Ｃ", "Ｄ", "Ｅ", "Ｆ", "Ｇ", "Ｈ", "Ｉ"
            },
            new JavaString[]{
                "Ｊ", "Ｋ", "Ｌ", "Ｍ", "Ｎ", "Ｏ", "Ｐ", "Ｑ", "Ｒ"
            },
            new JavaString[]{
                "Ｓ", "Ｔ", "Ｕ", "Ｖ", "Ｗ", "Ｘ", "Ｙ", "Ｚ"
            }
        },
        new[]
        {
            new JavaString[]{
                "０", "１", "２", "３", "４"
            },
            new JavaString[]{
                "５", "６", "７", "８", "９"
            }
        }
    };

    [MemberName("y")]
    public int y;

    [MemberName("z")]
    protected bool z;
    [MemberName("A")]
    protected bool A;
    [MemberName("B")]
    protected int B;
    [MemberName("C")]
    protected bool C;

    [MemberName("D")]
    public int[] D = { 9, 9, 9, 9, 9, 39, 74 };
    [MemberName("E")]
    public int[] E = { 46, 46, 46, 61, 61, 65, 64 };
    [MemberName("F")]
    public int[] F = { 13, 13, 13, 13, 13, 18, 18 };
    [MemberName("G")]
    public int[] G = { 14, 14, 14, 14, 14, 18, 18 };

    [MemberName("H")]
    public static int[,] H = {
      { 8, 45 }, { 8, 60 }, { 37, 64 }, { 73, 64 }, { 55, 14 }, { 9, 121 }, { 46, 121 }, { 83, 121 }, { 121, 121 }, { 177, 121 },
      { 90, 153 }, { 177, 160 } };
    [MemberName("I")]
    public static int[,] I = { { 24, 58 } };
    [MemberName("J")]
    public static int[,] J = { { 41, 12 }, { 22, 20 } };
    [MemberName("K")]
    public static int[,] K = { { 14, 15 }, { 37, 19 }, { 56, 19 }, { 62, 25 }, { 19, 19 } };
    [MemberName("L")]
    public static int[,] L = { { 107, 0, 0, 0 }, { 94, 121, 0, 0 }, { 80, 107, 134, 0 }, { 67, 94, 121, 148 } };
    [MemberName("M")]
    public static int M = 6;
    [MemberName("N")]
    public static int N = 28;
    [MemberName("O")]
    public static int O = 15;

    [MemberName("P")]
    private int P = 0;

    [ConstructorName("ab")]
    public FormattedTextResourceBase()
    {
    }

    [FunctionName("a")]
    protected override void Update(Graphics paramGraphics)
    {
        Update();
    }

    [FunctionName("f")]
    protected abstract void Update();

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        Paint();
    }

    [FunctionName("e")]
    protected abstract void Paint();

    [FunctionName("a")]
    public override int GetWidth()
    {
        return 0;
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return 0;
    }

    [FunctionName("a")]
    public static void a1(FormattedTextResource @params, int paramInt)
    {
        @params.p[paramInt] = TextResource.Create("", TextResource.FONT_TINY);
        @params.AddChild(@params.p[paramInt], 65 + paramInt * 16, 18);
    }

    [FunctionName("a")]
    public static void a1(FormattedTextResource @params)
    {
        @params.q = TextResource.Create("＿", TextResource.FONT_TINY);
        if (@params.y >= 3)
        {
            @params.AddChild(@params.q, 64, 30);
            return;
        }
        @params.AddChild(@params.q, 64, 18);
    }

    [FunctionName("l")]
    public void l1()
    {
        int[,] arrayOfInt = { { 106, 0, 0, 0 }, { 93, 120, 0, 0 }, { 79, 106, 133, 0 }, { 66, 93, 120, 147 } };
        int i;
        if ((i = _totalText.Length) >= _totalLength)
            i = _totalLength - 1;
        q.posX = 64 + i * 16;
        if (y >= 3)
            q.posX = arrayOfInt[_totalLength - 1, i] + 14;
        P++;
        if (P < 10)
        {
            ((TextResource)q).SetText("＿");
            return;
        }
        if (P > 20)
            P = 0;
        ((TextResource)q).SetText("");
    }
}
