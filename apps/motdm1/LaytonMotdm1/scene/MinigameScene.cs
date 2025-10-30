using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm1.c;
using LaytonMotdm1.c.Managers;
using LaytonMotdm1.c.Resources;

namespace LaytonMotdm1.scene;

[ClassName("scene", "o")]
public class MinigameScene : IScene
{
    [MemberName("a")]
    private int a;
    [MemberName("b")]
    private int b;
    [MemberName("c")]
    private static MinigameScene Instance = new();
    [MemberName("d")]
    private int d;
    [MemberName("e")]
    private ResourceBase[] e = new ResourceBase[3];
    [MemberName("f")]
    private RectangleResource[] f = new RectangleResource[36];
    [MemberName("g")]
    private RectangleResource[] g = new RectangleResource[144];
    [MemberName("h")]
    private ResourceBase[] h = new ResourceBase[31];
    [MemberName("i")]
    private ResourceBase[] i = new ResourceBase[10];
    [MemberName("j")]
    private ResourceBase[] j;
    [MemberName("k")]
    private ResourceBase[] k;
    [MemberName("l")]
    private ResourceBase[] l;
    [MemberName("m")]
    private ResourceBase[] m;
    [MemberName("n")]
    private ResourceBase[] n;
    [MemberName("o")]
    private ResourceBase[] o2;
    [MemberName("p")]
    private ResourceBase[] p;
    [MemberName("q")]
    private ResourceBase[] q;
    [MemberName("r")]
    private int[] r = new int[20];
    [MemberName("s")]
    private int[] s;
    [MemberName("t")]
    private int t;
    [MemberName("u")]
    private int[][] u;
    [MemberName("v")]
    private int v;
    [MemberName("w")]
    private int w;
    [MemberName("x")]
    private int x;
    [MemberName("y")]
    private int y;
    [MemberName("z")]
    private int z;
    [MemberName("A")]
    private int A;
    [MemberName("B")]
    private int B;
    [MemberName("C")]
    private JavaString C = "#これはテストデータです\n#アイテムにはルールがあり必ず以下の数値にしてください。\n#0:空白\n#1:光の開始地点\n#2:ゴール地点\n#3:鏡1(左上反射)／\n#4:鏡2(右下反射)／\n#5:鏡3(左下反射)＼\n#6:鏡4(右上反射)＼\n#7:穴\n#8:蓋\n#9:ブロック#10,11: 壁判定用の為変更しないでください(光の開始地点変更除く)\n#MAP\n10,11,11,11,11, 1,11,11,11,11,10,\n10, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,\n10, 0, 0, 0, 0, 9, 0, 0, 0, 0,10,\n10, 0, 0, 0, 0, 0, 9, 2, 0, 0,10,\n10, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,\n10, 0, 0, 0, 0, 0, 9, 0, 0, 0,10,\n10, 0, 0, 0, 0, 9, 0, 9, 0, 0,10,\n10, 0, 0, 0, 0, 0, 0, 7, 0, 0,10,\n10,11,11,11,11,11,11,11,11,11,10,\n\n#光の方向は数値で決めます\n#光の位置(1)からどの方向へ進むのか\n#0:上方向へ\n#1:右方向へ\n#2:下方向へ\n#3:左方向へ\n方向 = 2 \n文言 = あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[end]#必ず最後は改行\n";
    [MemberName("D")]
    private GameFileManager D;
    [MemberName("E")]
    private int[][] E = new int[][] { new int[] { 41, 103 }, new int[] { 131, 103 } };
    [MemberName("F")]
    private int[] F = new int[] { 32, 122 };
    [MemberName("G")]
    private int G;
    [MemberName("H")]
    private int H;
    [MemberName("I")]
    private int I;
    [MemberName("J")]
    private int J;
    [MemberName("K")]
    private int K;
    [MemberName("L")]
    private int L;
    [MemberName("M")]
    private int M;
    [MemberName("N")]
    private int N;
    [MemberName("O")]
    private int O;
    [MemberName("P")]
    private int P;
    [MemberName("Q")]
    private int Q;
    [MemberName("R")]
    private int R;
    [MemberName("S")]
    private int S;
    [MemberName("T")]
    private int T;
    [MemberName("U")]
    private int U;
    [MemberName("V")]
    private int V;
    [MemberName("W")]
    private JavaString W;
    [MemberName("X")]
    private int X;
    [MemberName("Y")]
    private int Y;
    [MemberName("Z")]
    private int Z;
    [MemberName("aa")]
    private int aa;
    [MemberName("ab")]
    private int ab;
    [MemberName("ac")]
    private bool ac;
    [MemberName("ad")]
    private bool ad;
    [MemberName("ae")]
    private bool ae;
    [MemberName("af")]
    private bool af = false;
    [MemberName("ag")]
    private bool ag;
    [MemberName("ah")]
    private bool ah;
    [MemberName("ai")]
    private int[] ai = new int[] { 0, 48, 96, 144, 192 };
    [MemberName("j")]
    private int aj;
    [MemberName("ak")]
    private int ak;
    [MemberName("al")]
    private int al;
    [MemberName("am")]
    private int am;
    [MemberName("an")]
    private int an = 0;
    [MemberName("ao")]
    private int ao = 0;
    [MemberName("ap")]
    private int ap;
    [MemberName("aq")]
    private bool aq;
    [MemberName("ar")]
    private bool ar;
    [MemberName("as")]
    private bool @as;
    [MemberName("at")]
    private bool at;
    [MemberName("au")]
    private int au;
    [MemberName("av")]
    private int av;
    [MemberName("aw")]
    private int aw;
    [MemberName("ax")]
    private int ax;
    [MemberName("ay")]
    private int[][] ay = (int[][])null;
    [MemberName("az")]
    private bool az;
    [MemberName("aA")]
    private int aA = 1;
    [MemberName("aB")]
    private int aB = 4;
    [MemberName("aC")]
    private int[][] aC = new int[][] { new int[] { 25, 25 }, new int[] { 25, 18 }, new int[] { 25, 25 }, new int[] { 25, 18 }, new int[] { 18, 18 }, new int[] { 25, 18 },
        new int[]{ 25, 18 },new int[]{ 25, 19 },new int[] { 18, 18 }, new int[]{ 25, 18 }, new int[]{ 15, 18 }, new int[]{ 25, 4 }, new int[]{ 25, 18 } };

    [ConstructorName("o")]
    private MinigameScene()
    {
    }

    [FunctionName("a")]
    public static MinigameScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    private void a1(int var1, int var2)
    {
        aj = var1;
        ak = var2;
    }

    [FunctionName("a")]
    private bool a1(int var1)
    {
        bool var2 = true;
        aj += var1;
        if (aj < 0)
        {
            aj = 0;
            var2 = false;
        }
        else if (aj > 4)
        {
            aj = 4;
            var2 = false;
        }

        return var2;
    }

    [FunctionName("b")]
    private bool b1(int var1)
    {
        bool var2 = true;
        ak += var1;
        if (ak < 0)
        {
            ak = 0;
            var2 = false;
        }
        else if (ak > 3)
        {
            ak = 3;
            var2 = false;
        }

        return var2;
    }

    [FunctionName("c")]
    private void c1(int var1)
    {
        al = var1;
        ad = false;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        D = new GameFileManager();
        gameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        d1(0);
        JavaString[] var3 = new JavaString[]
        {
            "bg_monooki.jpg", "btn_partselect.gif", "btn_reset.gif", "p_kabe.gif", "p_kagami.gif", "p_ana.gif",
            "p_yuka.gif", "p_hammer.gif", "p_lamp0.gif", "p_lamp1.gif", "p_ana_small.gif", "font_jennifer.gif",
            "btn_jennifer.gif", "bg_hanyou.jpg", "monooki.dat", "tuto1.gif", "tuto2.gif"
        };
        d = 0;
        aa = 0;
        H = 0;
        I = 0;
        G = 1;
        ac = false;
        ae = false;
        at = false;
        ag = false;
        @as = false;
        ar = false;
        ah = true;
        az = true;
        aq = true;
        Q = 1;
        R = 1;
        S = 0;
        J = 1;
        U = 64;
        V = 0;
        av = 0;
        aw = 0;
        ax = 0;
        X = 0;
        Y = 2;
        Z = 0;
        ao = 0;
        an = 0;
        ap = 0;
        ab = 0;
        au = 0;
        c1(0);
        a1(0, 0);
        a1(0, 0, 0, 0);
        b = 0;
        aA = 1;
        aB = 4;
        u = new int[9][];
        for (var i = 0; i < 9; i++)
            u[i] = new int[11];

        if (!D.LoadFiles(var3))
        {
            d1(99);
        }
        else
        {
            C = new JavaString(D.GetLoadedData("monooki.dat"));
            t = gameContext.SaveData.z1();
            if (t == 3)
            {
                a1(gameContext, C, 1);
                U = 0;
            }

            a1(gameContext, C, 0);
            h[0] = ImageResource.Create(D.GetLoadedImage("bg_monooki.jpg"));
            var2.AddChild(h[0]);

            int var4;
            for (var4 = 3; var4 < 9; ++var4)
            {
                h[var4] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            }

            ((ImageResource)h[3]).SetFlipMode(Graphics.FLIP_VERTICAL);
            ((ImageResource)h[4]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            ((ImageResource)h[5]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            ((ImageResource)h[6]).SetFlipMode(Graphics.FLIP_ROTATE_LEFT);
            ((ImageResource)h[7]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            ((ImageResource)h[8]).SetFlipMode(Graphics.FLIP_ROTATE_LEFT);
            h[25] = ImageResource.Create((ImageResource)h[3]);
            ((ImageResource)h[25]).SetFlipMode(Graphics.FLIP_VERTICAL);
            h[22] = RectangleResource.Create(240, 192, 1, V, V, V, U);
            h[0].AddChild(h[22]);
            e1(gameContext);
            m1();
            h[1] = ImageResource.Create(D.GetLoadedImage("p_lamp0.gif"));
            h[2] = ImageResource.Create(D.GetLoadedImage("p_lamp1.gif"));
            h[2].SetIsVisible(false);
            h[0].AddChild(h[1]);
            h[1].AddChild(h[2]);

            for (var4 = 0; var4 < n.Length; ++var4)
            {
                n[var4] = ImageResource.Create(D.GetLoadedImage("p_ana.gif"));
                n[var4].SetIsVisible(false);
                h[0].AddChild(n[var4]);
            }

            for (var4 = 0; var4 < o2.Length; ++var4)
            {
                o2[var4] = ImageResource.Create(D.GetLoadedImage("p_yuka.gif"));
                o2[var4].SetIsVisible(false);
                h[0].AddChild(o2[var4]);
                int var5;
                if ((var5 = gameContext.SaveData.n1(var4)) != 0)
                {
                    o2[var4].SetPosition(var5 % 11 * 19 + 9, var5 / 11 * 19 + 1);
                    o2[var4].SetIsVisible(true);
                }
            }

            byte var9 = 25;
            byte var8 = 18;
            switch (L)
            {
                case 0:
                    var8 = 28;
                    break;
                case 1:
                    var9 = 18;
                    break;
                case 2:
                    var8 = 13;
                    break;
                case 3:
                    var9 = 35;
                    break;
            }

            int[][] var6 = new int[][] { new int[] { 3, 86 }, new int[] { 7, 3 }, new int[] { 3, 18 }, new int[] { 25, 3 } };
            h[29] = ImageResource.Create(D.GetLoadedImage("p_ana_small.gif"));
            h[0].AddChild(h[29], M * 19 + var9 - h[29].GetWidth() / 2,
                N * 19 + var8 - h[29].GetHeight() / 2 + 2);
            f[0] = RectangleResource.Create(1, 1, 1, 255, 255, 0, 128);
            f[0].SetRect(M * 19 + var9, N * 19 + var8, var6[L][0], var6[L][1]);

            int var7;
            for (var7 = 0; var7 < 4; ++var7)
            {
                g[var7 * 36] = RectangleResource.Create(1, 1, 1, 255, 255, 0, 128);
                g[var7 * 36].SetRect(M * 19 + var9, N * 19 + var8, var6[L][0], var6[L][1]);
            }

            for (var7 = 1; var7 < 36; ++var7)
            {
                f[var7] = RectangleResource.Create(0, 0, 1, 255, 255, 0, 128);
                h[0].AddChild(f[var7]);
                g[var7] = RectangleResource.Create(0, 0, 1, 255, 255, 0, 128);
                g[var7 + 36] = RectangleResource.Create(0, 0, 1, 255, 255, 0, 128);
                g[var7 + 72] = RectangleResource.Create(0, 0, 1, 150, 150, 0, 128);
                g[var7 + 108] = RectangleResource.Create(0, 0, 1, 150, 150, 0, 128);
                h[0].AddChild(g[var7]);
                h[0].AddChild(g[var7 + 36]);
                h[0].AddChild(g[var7 + 72]);
                h[0].AddChild(g[var7 + 108]);
            }

            for (var4 = 0; var4 < j.Length; ++var4)
            {
                j[var4] = ImageResource.Create(D.GetLoadedImage("p_kagami.gif"));
                ((ImageResource)j[var4]).SetFlipMode(Graphics.FLIP_HORIZONTAL);
                j[var4].SetIsVisible(false);
                h[0].AddChild(j[var4]);
            }

            for (var4 = 0; var4 < k.Length; ++var4)
            {
                k[var4] = ImageResource.Create(D.GetLoadedImage("p_kagami.gif"));
                ((ImageResource)k[var4]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
                k[var4].SetIsVisible(false);
                h[0].AddChild(k[var4]);
            }

            for (var4 = 0; var4 < l.Length; ++var4)
            {
                l[var4] = ImageResource.Create(D.GetLoadedImage("p_kagami.gif"));
                ((ImageResource)l[var4]).SetFlipMode(Graphics.FLIP_UNK);
                l[var4].SetIsVisible(false);
                h[0].AddChild(l[var4]);
            }

            for (var4 = 0; var4 < m.Length; ++var4)
            {
                m[var4] = ImageResource.Create(D.GetLoadedImage("p_kagami.gif"));
                m[var4].SetIsVisible(false);
                h[0].AddChild(m[var4]);
            }

            h[30] = RectangleResource.Create(34, 8, 1, 255, 255, 255, 128);
            h[0].AddChild(h[30]);
            h[30].SetIsVisible(false);

            for (var4 = 0; var4 < p.Length; ++var4)
            {
                p[var4] = ImageResource.Create(D.GetLoadedImage("p_kabe.gif"));
                h[0].AddChild(p[var4], -10, 0);
            }

            h[12] = ImageResource.Create(D.GetLoadedImage("p_kagami.gif"));
            h[12].SetIsVisible(false);
            h[0].AddChild(h[12]);
            h[9] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
            ((ImageResource)h[9]).ClipRect(0, 0, 40, 15);
            h[10] = ImageResource.Create((ImageResource)h[9]);
            ((ImageResource)h[10]).ClipRect(40, 0, 40, 15);
            h[0].AddChild(h[10], 194, 7);
            h[0].AddChild(h[9], 194, 7);
            ((ImageResource)h[10]).SetIsVisible(false);
            h[18] = ImageResource.Create((ImageResource)h[3]);
            h[0].AddChild(h[18], 150, 172);
            ((ImageResource)h[18]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            h[18].SetIsVisible(false);
            h[13] = ImageResource.Create(D.GetLoadedImage("btn_jennifer.gif"));
            ((ImageResource)h[13]).ClipRect(0, 0, 71, 15);
            h[14] = ImageResource.Create((ImageResource)h[13]);
            ((ImageResource)h[14]).ClipRect(71, 0, 71, 15);
            h[0].AddChild(h[14], 166, 172);
            h[0].AddChild(h[13], 166, 172);
            h[14].SetIsVisible(false);
            if (t != 3)
            {
                h[13].SetIsVisible(false);
            }

            h[0].AddChild(h[8], 60, 6);
            h[8].SetIsVisible(false);
            i[0] = ImageResource.Create(D.GetLoadedImage("btn_reset.gif"));
            ((ImageResource)i[0]).ClipRect(0, 0, 50, 15);
            i[1] = ImageResource.Create((ImageResource)i[0]);
            ((ImageResource)i[1]).ClipRect(50, 0, 50, 15);
            h[0].AddChild(i[1], 5, 5);
            h[0].AddChild(i[0], 5, 5);
            i[1].SetIsVisible(false);
            i[2] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small1.gif"));
            i[3] = TextResource.Create("へやを最初の状態に戻しますか？");
            i[4] = TextResource.Create("※パーツはなくなりません。");
            i[5] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
            i[6] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
            i[7] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
            i[8] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));
            i[6].SetIsVisible(false);
            i[9] = RectangleResource.Create(240, 192, 1, 255, 255, 255, 128);
            h[0].AddChild(i[9]);
            i[9].AddChild(i[2], (240 - i[2].GetWidth()) / 2, (h[0].GetHeight() - i[2].GetHeight()) / 2);
            i[9].AddChild(i[5], E[0][0], E[0][1]);
            i[9].AddChild(i[6], E[0][0], E[0][1]);
            i[9].AddChild(i[7], E[1][0], E[1][1]);
            i[9].AddChild(i[8], E[1][0], E[1][1]);
            i[9].AddChild(h[7], 122, 110);
            i[9].AddChild(i[3], (240 - i[3].GetWidth()) / 2, 72);
            i[9].AddChild(i[4], (240 - i[4].GetWidth()) / 2, 85);
            h[7].posX = F[1];
            i[9].SetIsVisible(false);
            a1(gameContext, true);
            h[23] = RectangleResource.Create(240, 192, 1, 255, 255, 255, 0);
            h[0].AddChild(h[23]);
            q = new ResourceBase[r.Length];

            for (var4 = 0; var4 < q.Length; ++var4)
            {
                q[var4] = ImageResource.Create(D.GetLoadedImage("p_kagami.gif"));
                q[var4].SetIsVisible(false);
                h[23].AddChild(q[var4], 48 * var4 + 5, 200);
            }

            h[24] = RectangleResource.Create(48, 1, 0, 0, 0, 0, 0);
            h[23].AddChild(h[24], (240 - h[24].GetWidth()) / 2, 195);
            h[0].AddChild(h[4], 185, 7);
            ((ImageResource)h[4]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            h[4].SetIsVisible(false);
            h[0].AddChild(h[3], aj * 38 + 37, ak * 38 + 20);
            h[24].AddChild(h[25], 15, -2);
            h[25].SetIsVisible(false);
            h[23].AddChild(h[5], 0, 210);
            h[23].AddChild(h[6], 230, 210);
            h[5].SetIsVisible(false);
            h[6].SetIsVisible(false);
            h[11] = ImageResource.Create(D.GetLoadedImage("p_hammer.gif"));
            h[0].AddChild(h[11]);
            h[11].SetIsVisible(false);
            h[15] = ImageResource.Create(D.GetLoadedImage("bg_hanyou.jpg"));
            h[0].AddChild(h[15]);
            h[15].SetIsVisible(false);
            h[19] = ImageResource.Create((ImageResource)h[9]);
            ((ImageResource)h[19]).ClipRect(0, 0, 40, 15);
            h[20] = ImageResource.Create((ImageResource)h[9]);
            ((ImageResource)h[20]).ClipRect(40, 0, 40, 15);
            h[15].AddChild(h[20], 195, 172);
            h[15].AddChild(h[19], 195, 172);
            h[17] = ImageResource.Create((ImageResource)h[3]);
            h[15].AddChild(h[17], 186, 173);
            ((ImageResource)h[17]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            h[16] = ImageResource.Create(D.GetLoadedImage("font_jennifer.gif"));
            h[15].AddChild(h[16], 4, 4);
            h[21] = ScriptTextResource.Create(W);
            h[15].AddChild(h[21], 12, 31);
            h[26] = ImageResource.Create((ImageResource)i[2]);
            h[27] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
            h[28] = ScriptTextResource.Create("使えるパーツがありません。[end]");
            h[23].AddChild(h[26]);
            h[26].AddChild(h[27], 190, 65);
            ((ImageResource)h[27]).b1(0, 0, h[27].GetWidth() / 2, h[27].GetHeight());
            h[26].AddChild(h[28], 30, 30);
            h[26].SetIsVisible(false);
            e[0] = ImageResource.Create(D.GetLoadedImage("tuto1.gif"));
            e[1] = ImageResource.Create(D.GetLoadedImage("tuto2.gif"));
            e[2] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
            ((ImageResource)e[0]).SetAnchorType(ResourceBase.ANCHOR_CENTER);
            var2.AddChild(e[0], 120, 0);
            ((ImageResource)e[1]).SetAnchorType(ResourceBase.ANCHOR_CENTER);
            var2.AddChild(e[1], 120, 0);
            var2.AddChild(e[2], 223, 175);
            ((ImageResource)e[2]).b1(0, 0, e[2].GetWidth() / 2, e[2].GetHeight());
            ((ImageResource)e[2]).b1(1, 3);
            e[0].SetIsVisible(false);
            e[1].SetIsVisible(false);
            e[2].SetIsVisible(false);
            if (gameContext.SaveData.h1() == 1)
            {
                e[0].SetIsVisible(true);
                e[2].SetIsVisible(true);
                d1(10);
                gameContext.SaveData.g1();
            }
            else if (af)
            {
                d1(5);
                a1(true);
            }
            else
            {
                i1();
                j1();
                k1();
            }

            b1();
            var2.ExecuteTransition(1);
        }
    }

    [FunctionName("a")]
    private void a1(bool var1)
    {
        if (var1)
        {
            h[15].SetIsVisible(true);
            h[13].SetIsVisible(false);
            h[14].SetIsVisible(false);
            h[18].SetIsVisible(false);
            ((ScriptTextResource)h[21]).SetText(W);
        }
        else
        {
            h[15].SetIsVisible(false);
            h[19].SetPosition(195, 172);
            h[20].SetPosition(195, 172);
        }
    }

    [FunctionName("b")]
    private void b1(int var1, int var2)
    {
        for (int var3 = 1; var3 < 36; ++var3)
        {
            if (var3 == 1)
            {
                f[var3].SetPosition(var1 * 19 + 25, var2 * 19 + 18);
                g[var3].SetPosition(var1 * 19 + 25 - 1, var2 * 19 + 18 - 1);
                g[var3 + 36].SetPosition(var1 * 19 + 25 + 3, var2 * 19 + 18 + 3);
                g[var3 + 72].SetPosition(var1 * 19 + 25 - 2, var2 * 19 + 18 - 2);
                g[var3 + 108].SetPosition(var1 * 19 + 25 + 4, var2 * 19 + 18 + 4);
                if (L == 3)
                {
                    f[var3].posX = 220;
                    g[var3].posX = 220;
                    g[var3 + 36].posX = 220;
                    g[var3 + 72].posX = 220;
                    g[var3 + 108].posX = 220;
                }
                else if (L == 1)
                {
                    f[var3].posX = 18;
                    g[var3].posX = 18;
                    g[var3 + 36].posX = 18;
                    g[var3 + 72].posX = 18;
                    g[var3 + 108].posX = 18;
                }
                else if (L == 2)
                {
                    f[var3].posY = 13;
                    g[var3].posY = 13;
                    g[var3 + 36].posY = 13;
                    g[var3 + 72].posY = 13;
                    g[var3 + 108].posY = 13;
                }
            }

            f[var3].SetIsVisible(false);
            g[var3].SetIsVisible(false);
            g[var3 + 36].SetIsVisible(false);
            g[var3 + 72].SetIsVisible(false);
            g[var3 + 108].SetIsVisible(false);
        }
    }

    [FunctionName("b")]
    private void b1()
    {
        ae = false;
        M = O;
        N = P;
        J = 1;
        K = L;
        b1(M, N);
    }

    [FunctionName("d")]
    private void d1(int var1)
    {
        am = a;
        a = var1;
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        bool var3 = false;
        int var4;
        int var5;
        int var6;
        int var7;
        switch (a)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    d1(1);
                }
                break;
            case 1:
                if (var2._transitionState == 2)
                {
                    a1(false);
                    i1();
                    j1();
                    k1();
                    if (t != 3)
                    {
                        h[13].SetIsVisible(false);
                        h[14].SetIsVisible(false);
                    }
                    else
                    {
                        h[13].SetIsVisible(true);
                    }

                    var2.ExecuteTransition(1);
                }

                if (var2._transitionState == 0)
                {
                    if (t != 3)
                    {
                        h[13].SetIsVisible(false);
                        h[14].SetIsVisible(false);
                    }
                    else
                    {
                        h[13].SetIsVisible(true);
                    }

                    if (X == 0 && aa == 0)
                    {
                        f1(true);
                    }
                    else
                    {
                        f1(false);
                    }

                    if (!ag)
                    {
                        if (gameContext.IsKeyPressed(Display.KEY_UP))
                        {
                            if (ad)
                            {
                                ad = false;
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (b1(-1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (X == 0 && aa == 0)
                            {
                                if (!ac)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                    if (aj < 2)
                                    {
                                        c1(0);
                                    }
                                    else
                                    {
                                        c1(1);
                                    }
                                }

                                ac = true;
                            }
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_DOWN))
                        {
                            if (ac)
                            {
                                ac = false;
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (b1(1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (X == 0 && aa == 0 && t == 3)
                            {
                                if (s.Length != 0)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                    ad = false;
                                    d1(2);
                                    k1(aj);
                                }
                            }
                            else if (X == 0 && aa == 0 && s.Length != 0)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                ad = false;
                                d1(2);
                                k1(aj);
                            }
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_RIGHT) && !ad)
                        {
                            if (ac)
                            {
                                if (al != 1)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                }

                                c1(1);
                            }
                            else if (a1(1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_LEFT) && !ad)
                        {
                            if (ac)
                            {
                                if (al != 0)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                }

                                c1(0);
                            }
                            else if (a1(-1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_ONE) && X == 0 && aa == 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            p1();
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_TWO) && X == 0 && aa == 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            a1(0, 0);
                            ac = true;
                            c1(1);
                            b1(true);
                            var3 = true;
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_TWO) && aa == 1)
                        {
                            X = 0;
                            aa = 0;
                            if ((var4 = av - 2) == 6)
                            {
                                var4 = 5;
                            }

                            j1(var4);
                            @as = true;
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            i1();
                            j1();
                            k1();
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_TWO) && X == 1)
                        {
                            var4 = u[v][w];
                            u[v][w] = av;
                            av = var4;
                            if (av == 0)
                            {
                                X = 0;
                            }
                            else
                            {
                                f1(av - 2);
                            }

                            a1(x, y);
                            b1();
                            a1(gameContext, true);
                            ar = true;
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                        {
                            if (ac)
                            {
                                if (al == 0)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    p1();
                                }
                                else
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                                    b1(true);
                                    var3 = true;
                                }
                            }
                            else if (aa == 1)
                            {
                                var4 = ak * 2 + 1;
                                var5 = aj * 2 + 1;
                                if (av == 8)
                                {
                                    if (a1(7, var4, var5))
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                        u[var4][var5] = av;
                                        aa = 0;
                                        av = 0;
                                        gameContext.SaveData.m1(var4 * 11 + var5);
                                        a1(gameContext, true);
                                        b1();
                                    }
                                }
                                else
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    if (!a1(0, var4, var5) && !a1(8, var4, var5))
                                    {
                                        if (a1(3, var4, var5) || a1(4, var4, var5) || a1(5, var4, var5) || a1(6, var4, var5))
                                        {
                                            var6 = u[ak * 2 + 1][aj * 2 + 1];
                                            u[ak * 2 + 1][aj * 2 + 1] = av;
                                            av = var6;
                                            f1(av - 2);
                                            a1(gameContext, true);
                                            b1();
                                            aa = 0;
                                            X = 1;
                                        }
                                    }
                                    else
                                    {
                                        u[var4][var5] = av;
                                        av = 0;
                                        aa = 0;
                                        a1(gameContext, true);
                                        b1();
                                    }

                                    a1(aj, ak, var4, var5);
                                }
                            }
                            else
                            {
                                ++X;
                                if (X == 1)
                                {
                                    aw = ak * 2 + 1;
                                    ax = aj * 2 + 1;
                                    if (ax < 1)
                                    {
                                        ax = 1;
                                    }
                                    else if (ax > 9)
                                    {
                                        ax = 9;
                                    }

                                    if (aw < 1)
                                    {
                                        aw = 1;
                                    }
                                    else if (aw > 7)
                                    {
                                        aw = 7;
                                    }

                                    av = u[aw][ax];
                                    if (av != 0 && av != 7 && av != 8 && av != 2)
                                    {
                                        u[aw][ax] = 0;
                                        a1(aj, ak, aw, ax);
                                    }
                                    else
                                    {
                                        X = 0;
                                    }

                                    if (X == 1)
                                    {
                                        b1();
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                        f1(av - 2);
                                    }
                                }
                                else if (X == 2)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    if (av == 8)
                                    {
                                        if (a1(7, ak * 2 + 1, aj * 2 + 1))
                                        {
                                            u[ak * 2 + 1][aj * 2 + 1] = av;
                                            u[aw][ax] = 0;
                                            X = 0;
                                            gameContext.SaveData.m1(ax * 11 + aw);
                                            b1();
                                        }
                                        else
                                        {
                                            u[aw][ax] = av;
                                            X = 1;
                                            b1();
                                        }
                                    }
                                    else if (av == 3 || av == 4 || av == 5 || av == 6)
                                    {
                                        if (a1(8, ak * 2 + 1, aj * 2 + 1))
                                        {
                                            u[ak * 2 + 1][aj * 2 + 1] = av;
                                            u[aw][ax] = 0;
                                            X = 0;
                                            av = 0;
                                            b1();
                                            a1(aj, ak, ak * 2 + 1, aj * 2 + 1);
                                        }
                                        else if (!a1(2, ak * 2 + 1, aj * 2 + 1) && !a1(7, ak * 2 + 1, aj * 2 + 1))
                                        {
                                            if (a1(0, ak * 2 + 1, aj * 2 + 1))
                                            {
                                                var4 = u[ak * 2 + 1][aj * 2 + 1];
                                                u[ak * 2 + 1][aj * 2 + 1] = av;
                                                av = var4;
                                                X = 0;
                                                b1();
                                                a1(aj, ak, ak * 2 + 1, aj * 2 + 1);
                                            }
                                            else
                                            {
                                                var4 = u[ak * 2 + 1][aj * 2 + 1];
                                                u[ak * 2 + 1][aj * 2 + 1] = av;
                                                av = var4;
                                                X = 1;
                                                b1();
                                                f1(av - 2);
                                                a1(aj, ak, ak * 2 + 1, aj * 2 + 1);
                                            }
                                        }
                                        else
                                        {
                                            X = 1;
                                        }
                                    }

                                    a1(gameContext, true);
                                }
                            }
                        }
                        else if (gameContext.IsKeyPressed(Display.KEY_FIVE) && X == 0 && aa == 0 && t == 3)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            a1(var2);
                        }
                    }

                    if (X == 1)
                    {
                        a1(gameContext, true);
                        e1(av - 2);
                    }
                    else if (aa == 1)
                    {
                        e1(av - 2);
                    }
                    else
                    {
                        h[12].SetIsVisible(false);
                    }

                    if (ae)
                    {
                        if (t != 3 && !ag)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            ag = true;
                        }

                        U -= 2;
                        V += 25;
                        if (V > 255)
                        {
                            V = 255;
                        }

                        if (U <= 0)
                        {
                            U = 0;
                            if (t != 3)
                            {
                                b = 1;
                                af = true;
                                var3 = true;
                                t = 3;
                                if ((var4 = av - 2) == 6)
                                {
                                    var4 = 5;
                                }

                                if (X != 0 || av != 0)
                                {
                                    X = 0;
                                    i1(var4);
                                }
                            }
                        }

                        ((RectangleResource)h[22]).SetColor(V, V, V, U);
                    }

                    o1();
                    if (@as)
                    {
                        h1();
                    }
                    else if (ar)
                    {
                        g1();
                    }

                    if (var3)
                    {
                        var2.ExecuteTransition(0);
                        d1(99);
                    }

                    e1();
                }
                break;
            case 2:
                if (var2._transitionState == 2)
                {
                    a1(false);

                    for (var4 = 0; var4 < q.Length; ++var4)
                    {
                        q[var4].SetIsVisible(true);
                    }

                    if (t != 3)
                    {
                        h[13].SetIsVisible(false);
                        h[14].SetIsVisible(false);
                    }
                    else
                    {
                        h[13].SetIsVisible(true);
                    }

                    var2.ExecuteTransition(1);
                }
                else if (var2._transitionState == 0)
                {
                    h[25].SetIsVisible(true);
                    h[18].SetIsVisible(false);
                    e1();
                    bool var10 = false;
                    if (h[24].h1())
                    {
                        if (gameContext.IsKeyPressed(Display.KEY_UP))
                        {
                            d1(1);
                            aj = Y;
                            h[25].SetIsVisible(false);
                        }
                        else if (!gameContext.IsKeyPressed(Display.KEY_MAIN))
                        {
                            if (gameContext.IsKeyPressed(Display.KEY_ONE))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                p1();
                                h[8].SetIsVisible(true);
                                h[25].SetIsVisible(false);
                            }
                            else if (gameContext.IsKeyPressed(Display.KEY_TWO))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                                a1(0, 0);
                                ac = false;
                                c1(1);
                                b1(true);
                                var3 = true;
                                h[4].SetIsVisible(true);
                                h[25].SetIsVisible(false);
                            }
                            else if (gameContext.IsKeyPressed(Display.KEY_FIVE))
                            {
                                if (t == 3)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    a1(var2);
                                }
                            }
                            else if (s.Length > 0)
                            {
                                if (gameContext.IsKeyPressed(Display.KEY_LEFT) && 0 < Y + Z - ab / 48)
                                {
                                    --Y;
                                    if (Y < 0)
                                    {
                                        Y = 0;
                                        if (Z > 0)
                                        {
                                            g1(0);
                                            --Z;
                                            if (Z < 0)
                                            {
                                                Z = 0;
                                            }
                                            else
                                            {
                                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                    }

                                    j1();
                                    h[24].a1(ai[Y], h[24].posY, 5);
                                }

                                if (gameContext.IsKeyPressed(Display.KEY_RIGHT) && s.Length - 1 > Y + Z - ab / 48)
                                {
                                    ++Y;
                                    if (Y > 4)
                                    {
                                        Y = 4;
                                        if (s.Length - 1 > Y + Z)
                                        {
                                            g1(1);
                                            ++Z;
                                            if (s.Length < Y + Z)
                                            {
                                                Z = s.Length - Y;
                                            }
                                            else
                                            {
                                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                    }

                                    j1();
                                    h[24].a1(ai[Y], h[24].posY, 5);
                                }
                            }
                        }
                        else
                        {
                            if (s.Length > Y + Z - ab / 48 && -1 < Y + Z - ab / 48)
                            {
                                f1();
                                d1(1);
                                int[] var9 = new int[] { 0, 3, 4, 5, 6, 8, 12 };
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                if ((var4 = var9[s[Y + Z - ab / 48]]) == 12)
                                {
                                    d1(6);
                                    Q = 5;
                                    R = 4;
                                }
                                else
                                {
                                    av = var4;
                                    f1(s[Y + Z - ab / 48]);
                                    d1(1);
                                }

                                aa = 1;
                                s[Y + Z - ab / 48] = 0;
                                r = s;
                                a1(2, 2);
                                var6 = 0;

                                for (var7 = 0; var7 < r.Length; ++var7)
                                {
                                    if (s[var7] != 0)
                                    {
                                        ++var6;
                                    }
                                }

                                s = new int[var6];
                                var7 = 0;

                                for (int var8 = 0; var8 < r.Length; ++var8)
                                {
                                    if (r[var8] != 0)
                                    {
                                        s[var7] = r[var8];
                                        ++var7;
                                    }
                                }

                                q1();
                                i1();
                                j1();
                                k1();
                            }
                            else if (s.Length == 0)
                            {
                                f1();
                                d1(1);
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            }

                            for (var5 = 0; var5 < q.Length; ++var5)
                            {
                                q[var5].posX = var5 * 48 + 5 + ab;
                            }
                            
                            h[25].SetIsVisible(false);
                        }
                    }

                    for (var5 = 0; var5 < q.Length; ++var5)
                    {
                        q[var5].h1();
                    }

                    l1();
                    o1();
                    if (var3)
                    {
                        var2.ExecuteTransition(0);
                        d1(99);
                    }
                }
                break;
            case 3:
                if (I == 0)
                {
                    if (gameContext.IsKeyPressed(Display.KEY_LEFT))
                    {
                        if (G != 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }

                        G = 0;
                        h1(G);
                    }
                    else if (gameContext.IsKeyPressed(Display.KEY_RIGHT))
                    {
                        if (G != 1)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }

                        G = 1;
                        h1(G);
                    }
                    else if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                    {
                        I = 1;
                        if (G == 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            a1(0, true);
                            h[2].SetIsVisible(false);
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            a1(1, true);
                        }
                    }
                }

                if (I == 1)
                {
                    ++H;
                    if (H > 10)
                    {
                        i[9].SetIsVisible(false);
                        d1(1);
                        c1(false);
                        I = 0;
                        H = 0;
                        if (G == 0)
                        {
                            gameContext.SaveData.j1();
                            gameContext.SaveData.k1();

                            for (var4 = 0; var4 < o2.Length; ++var4)
                            {
                                o2[var4].SetIsVisible(false);
                            }

                            e1(gameContext);
                            a1(gameContext, C, 0);
                            u = ay;
                            var4 = 0;

                            while (true)
                            {
                                if (var4 >= 4)
                                {
                                    a1(gameContext, true);
                                    b1();
                                    Y = 2;
                                    Z = 0;
                                    i1();
                                    j1();
                                    k1();
                                    break;
                                }

                                for (var5 = 0; var5 < 5; ++var5)
                                {
                                    if (u[var4 * 2 + 1][var5 * 2 + 1] == 8)
                                    {
                                        var6 = var4 * 2 + 1;
                                        var7 = var5 * 2 + 1;
                                        gameContext.SaveData.m1(var6 * 11 + var7);
                                    }
                                }

                                ++var4;
                            }
                        }

                        G = 1;
                        a1(0, false);
                        a1(1, false);
                        h1(G);
                    }
                }
                break;
            case 5:
                if (var2._transitionState == 2)
                {
                    i1();
                    a1(true);
                    var2.ExecuteTransition(1);
                    h[5].SetIsVisible(false);
                    h[6].SetIsVisible(false);
                }

                if (var2._transitionState == 0 && (gameContext.IsKeyPressed(Display.KEY_MAIN) || gameContext.IsKeyPressed(Display.KEY_TWO)))
                {
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                    af = false;
                    var2.ExecuteTransition(0);
                    h[19].SetPosition(h[19].posX + 2, h[19].posY + 2);
                    h[20].SetPosition(h[20].posX + 2, h[20].posY + 2);
                    d1(false);
                    if (am == 2)
                    {
                        d1(2);
                    }
                    else
                    {
                        d1(1);
                    }
                }
                break;
            case 6:
                f1(false);
                h[11].SetPosition(Q * 19 + 19, R * 19 + 3);
                h[11].SetIsVisible(true);
                h[30].SetIsVisible(true);
                a1(Q / 2, R / 2);
                if (au == 0 && !ag)
                {
                    if (gameContext.IsKeyPressed(Display.KEY_UP))
                    {
                        R += -1;
                        if (R < 1)
                        {
                            R = 1;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            if (R % 2 == 0)
                            {
                                --Q;
                                if (Q < 1)
                                {
                                    Q = 1;
                                    T = 1;
                                }
                            }
                            else if (Q == 1 && T == 1)
                            {
                                --Q;
                                T = 0;
                            }
                            else
                            {
                                ++Q;
                                if (Q > 10)
                                {
                                    Q = 10;
                                }

                                if (S == 1)
                                {
                                    Q -= 2;
                                }
                            }
                        }
                    }
                    else if (gameContext.IsKeyPressed(Display.KEY_DOWN))
                    {
                        ++R;
                        if (R > 7)
                        {
                            R = 7;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            if (R % 2 == 0)
                            {
                                --Q;
                                if (Q < 0)
                                {
                                    Q = 1;
                                    T = 1;
                                }
                            }
                            else if (Q == 1 && T == 1)
                            {
                                --Q;
                                T = 0;
                            }
                            else
                            {
                                ++Q;
                                if (Q > 10)
                                {
                                    Q = 10;
                                }

                                if (S == 1)
                                {
                                    Q -= 2;
                                }
                            }
                        }
                    }
                    else if (gameContext.IsKeyPressed(Display.KEY_LEFT))
                    {
                        Q += -2;
                        if (R % 2 == 0)
                        {
                            if (Q < 1)
                            {
                                Q = 1;
                            }
                            else
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (Q < 0)
                        {
                            Q = 0;
                            S = 1;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (gameContext.IsKeyPressed(Display.KEY_RIGHT))
                    {
                        T = 0;
                        S = 0;
                        Q += 2;
                        if (R % 2 == 0)
                        {
                            if (Q > 9)
                            {
                                Q = 9;
                            }
                            else
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (Q > 10)
                        {
                            Q = 10;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                    {
                        if (a1(9, R, Q))
                        {
                            for (var4 = 0; var4 < p.Length; ++var4)
                            {
                                p[var4].SetIsVisible(false);
                            }

                            at = true;
                            PhoneManager.a1(3);
                            u[R][Q] = 0;
                            A = -1;
                            B = 0;
                            a1(gameContext, true);
                            aa = 0;
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }
                    }
                    else if (gameContext.IsKeyPressed(Display.KEY_TWO) && !at)
                    {
                        j1(6);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        @as = true;
                    }

                    if (Q % 2 == 0)
                    {
                        h[30].SetPosition(Q * 19 + 22, R * 19);
                        ((RectangleResource)h[30]).SetSize(8, 34);
                    }
                    else
                    {
                        h[30].SetPosition(Q * 19 + 8, R * 19 + 14);
                        ((RectangleResource)h[30]).SetSize(34, 8);
                    }

                    a1(Q, R, true);
                }

                if (ae)
                {
                    if (t != 3 && !ag)
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        ag = true;
                    }

                    U -= 2;
                    V += 25;
                    if (V > 255)
                    {
                        V = 255;
                    }

                    if (U <= 0)
                    {
                        U = 0;
                        if (t != 3)
                        {
                            b = 1;
                            af = true;
                            var3 = true;
                            t = 3;
                            X = 0;
                            i1(6);
                        }
                    }

                    ((RectangleResource)h[22]).SetColor(V, V, V, U);
                }

                if (at)
                {
                    ((ImageResource)h[11]).SetSize(h[11].GetWidth() / 2, h[11].GetHeight() / 2);
                    ((ImageResource)h[11]).SetScale(315.0F);
                    at = d1(gameContext);
                    ac = false;
                }

                o1();
                if (@as)
                {
                    h1();
                    a1(Q, R, false);
                }
                else
                {
                    h[3].SetIsVisible(true);
                    h[3].SetPosition(h[11].posX, h[11].posY - 10);
                }

                if (var3)
                {
                    var2.ExecuteTransition(0);
                    d1(99);
                }

                e1();
                i1();
                j1();
                k1();
                break;
            case 10:
                if (var2._transitionState == 0 && gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    ++d;
                    if (d == 1)
                    {
                        e[0].SetIsVisible(false);
                        e[1].SetIsVisible(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (d == 2)
                    {
                        var2.ExecuteTransition(0);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                }

                if (var2._transitionState == 2)
                {
                    e[1].SetIsVisible(false);
                    e[2].SetIsVisible(false);
                    d1(1);
                    i1();
                    j1();
                    k1();
                }
                break;
            case 99:
                if (var2._transitionState == 2)
                {
                    switch (b)
                    {
                        case 0:
                            gameContext.SetCurrentScene(IngameMenuScene.GetInstance());
                            break;
                        case 1:
                            gameContext.RoomData.SetEventId(256);
                            gameContext.SetCurrentScene(EventScene.GetInstance());
                            break;
                        default:
                            gameContext.SetCurrentScene(IngameMenuScene.GetInstance());
                            break;
                    }
                }

                break;
        }

        return true;
    }

    [FunctionName("c")]
    private void c1()
    {
        ++J;
        if (J > 35)
        {
            J = 35;
        }

        int var1 = M * 19 + 25;
        int var2 = N * 19 + 18;
        f[J].SetPosition(var1, var2);
        g[J].SetPosition(var1 - 1, var2 - 1);
        g[J + 36].SetPosition(var1 + 3, var2 + 3);
        g[J + 72].SetPosition(var1 - 2, var2 - 2);
        g[J + 108].SetPosition(var1 + 4, var2 + 4);
    }

    [FunctionName("a")]
    private bool a1(int var1, int var2, int var3)
    {
        bool var4 = false;
        if (u[var2][var3] == var1)
        {
            var4 = true;
        }

        return var4;
    }

    [FunctionName("d")]
    private void d1()
    {
        h[3].SetPosition(aj * 38 + 37, ak * 38 + 20 + an);
        if (X != 1 && aa != 1)
        {
            if (ao > 0)
            {
                ao = -20;
            }
            else
            {
                an = ao;
                if (ao < -8)
                {
                    an = -8;
                }
            }

            ++ao;
        }
        else
        {
            an = -8;
        }
    }

    [FunctionName("e")]
    private void e1()
    {
        h[5].posX = 2 - ap;
        h[6].posX = 230 + ap;
        if (aq)
        {
            ++ap;
            if (ap > 3)
            {
                aq = !aq;
                return;
            }
        }
        else
        {
            --ap;
            if (ap < 0)
            {
                aq = !aq;
            }
        }
    }

    [FunctionName("b")]
    private void b1(bool var1)
    {
        if (var1)
        {
            h[10].SetIsVisible(true);
            h[10].SetPosition(196, 9);
            h[9].SetPosition(196, 9);
        }
        else
        {
            h[10].SetIsVisible(false);
            h[10].SetPosition(194, 7);
            h[9].SetPosition(194, 7);
        }
    }

    [FunctionName("c")]
    private void c1(bool var1)
    {
        if (var1)
        {
            ((ImageResource)i[1]).SetIsVisible(true);
            i[0].SetPosition(7, 7);
            i[1].SetPosition(7, 7);
        }
        else
        {
            ((ImageResource)i[1]).SetIsVisible(false);
            i[0].SetPosition(5, 5);
            i[1].SetPosition(5, 5);
        }
    }

    [FunctionName("a")]
    private void a1(int var1, bool var2)
    {
        byte var3 = 0;
        if (var1 == 1)
        {
            var3 = 2;
        }

        if (var2)
        {
            i[5 + var3].SetPosition(E[var1][0] + 2, E[var1][1] + 2);
            i[6 + var3].SetPosition(E[var1][0] + 2, E[var1][1] + 2);
        }
        else
        {
            i[5 + var3].SetPosition(E[var1][0], E[var1][1]);
            i[6 + var3].SetPosition(E[var1][0], E[var1][1]);
        }
    }

    [FunctionName("d")]
    private void d1(bool var1)
    {
        if (var1)
        {
            ad = true;
            h[13].SetPosition(168, 174);
            h[14].SetPosition(168, 174);
        }
        else
        {
            ad = false;
            h[13].SetPosition(166, 172);
            h[14].SetPosition(166, 172);
        }
    }

    [FunctionName("d")]
    private bool d1(GameContext var1)
    {
        bool var2 = true;
        ++au;
        if (au < 8)
        {
            h[3].SetIsVisible(false);
            var1.ScreenResource.SetPosition(0 + au % 2, 0 + au % 2);
        }
        else
        {
            var1.ScreenResource.SetPosition(0, 0);
            au = 0;
            var2 = false;
            d1(1);
            d1();
            h[11].SetIsVisible(false);
            h[30].SetIsVisible(false);
            ((ImageResource)h[11]).SetScale(0.0F);
            h[3].SetIsVisible(true);
            f1(true);
        }

        return var2;
    }

    [FunctionName("f")]
    private void f1()
    {
        ac = false;
    }

    [FunctionName("g")]
    private bool g1()
    {
        ++au;
        if (au < 8)
        {
            c1(1);
            h[3].SetIsVisible(false);
            h[4].SetIsVisible(true);
            b1(true);
            ag = true;
            return false;
        }
        else
        {
            c1(0);
            au = 0;
            h[3].SetIsVisible(true);
            h[4].SetIsVisible(false);
            b1(false);
            ar = false;
            ag = false;
            return true;
        }
    }

    [FunctionName("h")]
    private void h1()
    {
        if (g1())
        {
            a1(2, 2);
            d1();
            b1(false);
            aa = 0;
            h[11].SetIsVisible(false);
            h[30].SetIsVisible(false);
            ((ImageResource)h[11]).SetScale(0.0F);
            f1(true);
            @as = false;
            d1(1);
        }
        else
        {
            h[11].SetIsVisible(false);
            h[30].SetIsVisible(false);
        }
    }

    [FunctionName("e")]
    private void e1(int var1)
    {
        int var2 = (aj * 2 + 1) * 19 + 9;
        int var3 = (ak * 2 + 1) * 19 - 3;
        int[][] var4 = new int[][] { new int[] { 0, 0 }, new int[] { 3, 0 }, new int[] { 3, -3 }, new int[] { 3, -3 }, new int[] { 3, 0 } };
        if (var1 < 5)
        {
            h[12].SetPosition(var2 + var4[var1][0], var3 + var4[var1][1]);
        }
        else
        {
            h[12].SetPosition(var2, var3);
        }

        h[12].SetIsVisible(true);
    }

    [FunctionName("a")]
    private void a1(GameContext var1, bool var2)
    {
        int var3;
        for (var3 = 0; var3 < j.Length; ++var3)
        {
            j[var3].SetIsVisible(false);
        }

        for (var3 = 0; var3 < k.Length; ++var3)
        {
            k[var3].SetIsVisible(false);
        }

        for (var3 = 0; var3 < l.Length; ++var3)
        {
            l[var3].SetIsVisible(false);
        }

        for (var3 = 0; var3 < m.Length; ++var3)
        {
            m[var3].SetIsVisible(false);
        }

        var3 = 0;
        int var4 = 0;
        int var5 = 0;
        int var6 = 0;
        int var7 = 0;
        int var8 = 0;
        if (var2)
        {
            int var11;
            int var12;
            for (var11 = 0; var11 < o2.Length; ++var11)
            {
                if ((var12 = var1.SaveData.n1(var11)) != 0)
                {
                    o2[var11].SetPosition(var12 % 11 * 19 + 9, var12 / 11 * 19 + 1);
                    o2[var11].SetIsVisible(true);
                }
            }

            for (var11 = 0; var11 < 9; ++var11)
            {
                for (var12 = 0; var12 < 11; ++var12)
                {
                    int var9 = var12 * 19 + 9;
                    int var10 = var11 * 19 + 1;
                    if (a1(3, var11, var12))
                    {
                        j[var3].SetPosition(var9 + 5, var10 + 5);
                        j[var3].SetIsVisible(true);
                        ++var3;
                    }
                    else if (a1(4, var11, var12))
                    {
                        k[var4].SetPosition(var9, var10);
                        k[var4].SetIsVisible(true);
                        ++var4;
                    }
                    else if (a1(5, var11, var12))
                    {
                        l[var5].SetPosition(var9 + 4, var10);
                        l[var5].SetIsVisible(true);
                        ++var5;
                    }
                    else if (a1(6, var11, var12))
                    {
                        m[var6].SetPosition(var9 - 1, var10 + 5);
                        m[var6].SetIsVisible(true);
                        ++var6;
                    }
                    else if (a1(7, var11, var12))
                    {
                        n[var7].SetPosition(var9, var10);
                        n[var7].SetIsVisible(true);
                        ++var7;
                    }
                    else if (a1(2, var11, var12))
                    {
                        h[1].SetPosition(var9, var10 + 6);
                    }
                    else if (a1(9, var11, var12))
                    {
                        if (var12 % 2 == 1)
                        {
                            ((ImageResource)p[var8]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
                            p[var8].SetPosition(var9, var10 + 14);
                        }
                        else
                        {
                            ((ImageResource)p[var8]).SetFlipMode(Graphics.FLIP_NONE);
                            p[var8].SetPosition(var9 + 14, var10);
                        }

                        p[var8].SetIsVisible(true);
                        ++var8;
                    }
                }
            }
        }
    }

    [FunctionName("a")]
    private void a1(int var1, int var2, int var3, int var4)
    {
        x = var1;
        y = var2;
        v = var3;
        w = var4;
    }

    [FunctionName("f")]
    private void f1(int var1)
    {
        Image[] var2 = new Image[] { null, D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_yuka.gif") };
        int[] var3 = new int[] { 0, 1, 5, 6, 0, 0 };
        ((ImageResource)h[12]).SetImage(var2[var1]);
        ((ImageResource)h[12]).SetFlipMode(var3[var1]);
    }

    [FunctionName("i")]
    private void i1()
    {
        for (int var1 = 0; var1 < q.Length; ++var1)
        {
            q[var1].SetIsVisible(false);
        }
    }

    [FunctionName("g")]
    private void g1(int var1)
    {
        for (int var2 = 0; var2 < q.Length; ++var2)
        {
            if (var1 == 0)
            {
                q[var2].a1(q[var2].posX + 48, q[var2].posY, 5);
            }
            else if (var1 == 1)
            {
                q[var2].a1(q[var2].posX - 48, q[var2].posY, 5);
            }
        }
    }

    [FunctionName("j")]
    private void j1()
    {
        Image[] var1 = new Image[] { null, D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_kagami.gif"), D.GetLoadedImage("p_yuka.gif"), D.GetLoadedImage("p_hammer.gif") };
        int[] var2 = new int[] { 0, 1, 5, 6, 0, 0, 0 };
        int var3 = 0;

        for (int var4 = 0; var4 < s.Length; ++var4)
        {
            if (s[var4] != 0)
            {
                ((ImageResource)q[var4]).SetImage(var1[s[var4]]);
                ((ImageResource)q[var4]).SetFlipMode(var2[s[var4]]);
                q[var4].SetIsVisible(true);
                ++var3;
            }
        }

        if (var3 != 3 && var3 != 2)
        {
            if (var3 != 1 && var3 != 0)
            {
                ab = 0;
            }
            else
            {
                ab = 96;
            }
        }
        else
        {
            ab = 48;
        }
    }

    [FunctionName("k")]
    private void k1()
    {
        for (int var1 = 0; var1 < q.Length; ++var1)
        {
            q[var1].posX = var1 * 48 + 5 + ab;
        }

        l1();
    }

    [FunctionName("l")]
    private void l1()
    {
        if (s.Length < 5)
        {
            h[5].SetIsVisible(false);
            h[6].SetIsVisible(false);
        }

        if (Z > 0)
        {
            h[5].SetIsVisible(true);
        }
        else
        {
            h[5].SetIsVisible(false);
        }

        if (s.Length - (Z + 4) > 1)
        {
            h[6].SetIsVisible(true);
        }
        else
        {
            h[6].SetIsVisible(false);
        }
    }

    [FunctionName("m")]
    private void m1()
    {
        int var1 = 0;
        int var2 = 0;
        int var3 = 0;
        int var4 = 0;

        int var8;
        for (var8 = 0; var8 < 9; ++var8)
        {
            for (int var9 = 0; var9 < 11; ++var9)
            {
                if (a1(3, var8, var9))
                {
                    ++var1;
                }
                else if (a1(4, var8, var9))
                {
                    ++var2;
                }
                else if (a1(5, var8, var9))
                {
                    ++var3;
                }
                else if (a1(6, var8, var9))
                {
                    ++var4;
                }
            }
        }

        for (var8 = 0; var8 < r.Length; ++var8)
        {
            if (r[var8] == 1)
            {
                ++var1;
            }

            if (r[var8] == 2)
            {
                ++var2;
            }

            if (r[var8] == 3)
            {
                ++var3;
            }

            if (r[var8] == 4)
            {
                ++var4;
            }
        }

        j = new ResourceBase[var1];
        k = new ResourceBase[var2];
        l = new ResourceBase[var3];
        m = new ResourceBase[var4];
        n = new ResourceBase[20];
        o2 = new ResourceBase[20];
        p = new ResourceBase[20];
    }

    [FunctionName("e")]
    private void e1(GameContext var1)
    {
        r = new int[20];

        int var2;
        for (var2 = 0; var2 < r.Length; ++var2)
        {
            r[var2] = 0;
        }

        var2 = 0;

        int var3;
        for (var3 = 0; var3 < 20; ++var3)
        {
            r[var3] = var1.SaveData.l1(var3);
            if (r[var3] != 0)
            {
                ++var2;
            }
        }

        s = new int[var2];
        var2 = 0;

        for (var3 = 0; var3 < r.Length; ++var3)
        {
            if (r[var3] != 0)
            {
                s[var2] = r[var3];
                ++var2;
            }
        }

    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        int var2;
        for (var2 = 0; var2 < 20; ++var2)
        {
            var1.SaveData.j1(var2, 0);
        }

        for (var2 = 0; var2 < r.Length; ++var2)
        {
            var1.SaveData.j1(var2, r[var2]);
        }

        for (var2 = 0; var2 < 9; ++var2)
        {
            for (int var3 = 0; var3 < 11; ++var3)
            {
                var1.SaveData.a1(var2, var3, u[var2][var3]);
            }
        }

        if (t != 3)
        {
            var1.SaveData.j1(2);
        }
        else
        {
            var1.SaveData.j1(3);
            var1.SaveData.q1(3);
        }

        for (var2 = 0; var2 < q.Length; ++var2)
        {
            if (q[var2] != null)
            {
                q[var2].f1();
                q[var2] = null;
            }
        }

        for (var2 = 0; var2 < 20; ++var2)
        {
            if (p[var2] != null)
            {
                p[var2].f1();
                p[var2] = null;
            }

            if (o2[var2] != null)
            {
                o2[var2].f1();
                o2[var2] = null;
            }

            if (n[var2] != null)
            {
                n[var2].f1();
                n[var2] = null;
            }
        }

        for (var2 = 0; var2 < m.Length; ++var2)
        {
            if (m[var2] != null)
            {
                m[var2].f1();
                m[var2] = null;
            }
        }

        for (var2 = 0; var2 < l.Length; ++var2)
        {
            if (l[var2] != null)
            {
                l[var2].f1();
                l[var2] = null;
            }
        }

        for (var2 = 0; var2 < k.Length; ++var2)
        {
            if (k[var2] != null)
            {
                k[var2].f1();
                k[var2] = null;
            }
        }

        for (var2 = 0; var2 < j.Length; ++var2)
        {
            if (j[var2] != null)
            {
                j[var2].f1();
                j[var2] = null;
            }
        }

        for (var2 = 0; var2 < i.Length; ++var2)
        {
            if (i[var2] != null)
            {
                i[var2].f1();
                i[var2] = null;
            }
        }

        for (var2 = 0; var2 < 36; ++var2)
        {
            if (f[var2] != null)
            {
                f[var2].f1();
                f[var2] = null;
            }
        }

        for (var2 = 0; var2 < 144; ++var2)
        {
            if (g[var2] != null)
            {
                g[var2].f1();
                g[var2] = null;
            }
        }

        for (var2 = 0; var2 < 31; ++var2)
        {
            if (h[var2] != null)
            {
                h[var2].f1();
                h[var2] = null;
            }
        }

        for (var2 = 0; var2 < 3; ++var2)
        {
            if (e[var2] != null)
            {
                e[var2].f1();
                e[var2] = null;
            }
        }

        try
        {
            D.Reset();
        }
        catch (Exception var4)
        {
        }

        s = null;
        C = "";
    }

    [FunctionName("a")]
    private void a1(GameContext var1, JavaString var2, int var3)
    {
        ay = new int[9][];
        for (var i = 0; i < 9; i++)
            ay[i] = new int[11];

        bool var4 = false;
        bool var5 = false;
        int var6 = 0;

        while (!string.IsNullOrEmpty(var2.Trim()))
        {
            int var12;
            int var13;
            switch (var2.Trim()[0])
            {
                // Skip commented line
                case '#':
                    var13 = var2.IndexOf("\n");
                    var2 = var2[(var13 + 1)..];
                    break;
                case '文':
                    var12 = var2.IndexOf("=") + 1;
                    var13 = var2.IndexOf("\n", var12);
                    W = var2.Substring(var12, var13).Trim();
                    var2 = var2[(var13 + 1)..];
                    break;
                case '方':
                    var12 = var2.IndexOf("=") + 1;
                    var13 = var2.IndexOf("\n", var12);
                    if (var3 == 0)
                    {
                        L = int.Parse(var2.Substring(var12, var13).Trim());
                        K = L;
                    }

                    var2 = var2[(var13 + 1)..];
                    break;
                default:
                    var13 = var2.IndexOf(",");
                    JavaString var9 = var2.Substring(0, var13);
                    if (var3 == 0)
                    {
                        ay[var6 / 11][var6 % 11] = int.Parse(var9.Trim());
                        if (ay[var6 / 11][var6 % 11] == 1)
                        {
                            O = var6 % 11;
                            P = var6 / 11;
                            M = O;
                            N = P;
                        }

                        ++var6;
                    }

                    var2 = var2[(var13 + 1)..];
                    break;
            }
        }

        int var8;
        int var14;
        if (var1.SaveData.h1() == 1)
        {
            u = ay;

            for (var8 = 0; var8 < 4; ++var8)
            {
                for (var14 = 0; var14 < 5; ++var14)
                {
                    if (u[var8 * 2 + 1][var14 * 2 + 1] == 8)
                    {
                        int var10 = var8 * 2 + 1;
                        int var11 = var14 * 2 + 1;
                        var1.SaveData.m1(var10 * 11 + var11);
                    }
                }
            }
        }
        else
        {
            for (var8 = 0; var8 < 9; ++var8)
            {
                for (var14 = 0; var14 < 11; ++var14)
                {
                    u[var8][var14] = var1.SaveData.i1(var8, var14);
                }
            }
        }
    }

    [FunctionName("h")]
    private void h1(int var1)
    {
        h[7].posX = F[var1];
        if (var1 == 0)
        {
            i[6].SetIsVisible(true);
            i[8].SetIsVisible(false);
        }
        else
        {
            i[6].SetIsVisible(false);
            i[8].SetIsVisible(true);
        }
    }

    [FunctionName("n")]
    private void n1()
    {
        for (int var1 = 1; var1 < 36; ++var1)
        {
            if (var1 < J + 1)
            {
                g[var1 + 72].SetIsVisible(az);
                g[var1 + 108].SetIsVisible(az);
                g[var1].SetIsVisible(ah);
                g[var1 + 36].SetIsVisible(ah);
            }
        }

        ++aB;
        if (aB > 4)
        {
            aB = 0;
            az = true;
        }
        else
        {
            az = false;
        }

        ++aA;
        if (aA > 3)
        {
            aA = -1;
            ah = false;
        }
        else
        {
            ah = true;
        }
    }

    [FunctionName("i")]
    private void i1(int var1)
    {
        for (int var2 = 0; var2 < r.Length; ++var2)
        {
            if (r[var2] == 0)
            {
                r[var2] = var1;
                return;
            }
        }
    }

    [FunctionName("j")]
    private void j1(int var1)
    {
        r = s;
        int var2 = 0;

        int var3;
        for (var3 = 0; var3 < r.Length; ++var3)
        {
            if (s[var3] != 0)
            {
                ++var2;
            }
        }

        s = new int[var2 + 1];
        var3 = 0;

        for (int var4 = 0; var4 < r.Length; ++var4)
        {
            if (r[var4] != 0)
            {
                s[var3] = r[var4];
                ++var3;
            }
        }

        s[var2] = var1;
        r = s;
    }

    [FunctionName("c")]
    private int c1(int var1, int var2)
    {
        int var3 = 0;

        for (int var4 = 0; var4 < 9; ++var4)
        {
            for (int var5 = 0; var5 < 11; ++var5)
            {
                if (u[var4][var5] == 9)
                {
                    if (var4 == var2 && var5 == var1)
                    {
                        return var3;
                    }

                    ++var3;
                }
            }
        }

        return -1;
    }

    [FunctionName("a")]
    private void a1(int var1, int var2, bool var3)
    {
        z = c1(var1, var2);
        if (z >= 0)
        {
            ++B;
            if (B < 10)
            {
                p[z].SetIsVisible(true);
            }
            else if (B < 20)
            {
                p[z].SetIsVisible(false);
            }
            else
            {
                B = 0;
            }

            if (!var3)
            {
                p[z].SetIsVisible(true);
            }

            if (A != z)
            {
                if (A >= 0)
                {
                    p[A].SetIsVisible(true);
                }

                A = z;
                B = 0;
                if (!var3)
                {
                    p[A].SetIsVisible(true);
                    return;
                }
            }
        }
        else
        {
            if (A >= 0)
            {
                p[A].SetIsVisible(true);
            }

            A = -1;
            B = 0;
        }
    }

    [FunctionName("e")]
    private void e1(bool var1)
    {
        if (var1)
        {
            ac = false;
            h[3].SetIsVisible(false);
            h[14].SetIsVisible(true);
            h[18].SetIsVisible(true);
            h[4].SetIsVisible(false);
            h[10].SetIsVisible(false);
            h[8].SetIsVisible(false);
            i[1].SetIsVisible(false);
            h[25].SetIsVisible(false);
        }
        else
        {
            h[14].SetIsVisible(false);
            h[18].SetIsVisible(false);
        }
    }

    [FunctionName("f")]
    private void f1(bool var1)
    {
        i[0].SetIsVisible(var1);
        if (t == 3)
        {
            h[13].SetIsVisible(var1);
        }

        h[4].SetIsVisible(var1);
    }

    [FunctionName("o")]
    private void o1()
    {
        bool var1 = false;
        sbyte var2 = -1;
        sbyte var3 = -1;
        if (!ae)
        {
            switch (K)
            {
                case 0:
                    N += -1;
                    if (a1(9, N, M))
                    {
                        ++N;
                        var3 = 7;
                    }
                    else if (!a1(10, N, M) && !a1(11, N, M))
                    {
                        if (!a1(3, N, M) && !a1(6, N, M))
                        {
                            if (a1(4, N, M))
                            {
                                var1 = true;
                                var2 = 1;
                            }
                            else if (a1(5, N, M))
                            {
                                var1 = true;
                                var2 = 3;
                            }
                            else if (N < 1)
                            {
                                N = 1;
                            }
                        }
                        else
                        {
                            ++N;
                            var3 = 11;
                        }
                    }
                    else
                    {
                        ++N;
                        var3 = 0;
                    }
                    break;
                case 1:
                    ++M;
                    if (a1(9, N, M))
                    {
                        var3 = 4;
                    }

                    if (!a1(10, N, M) && !a1(11, N, M))
                    {
                        if (!a1(4, N, M) && !a1(6, N, M))
                        {
                            if (a1(3, N, M))
                            {
                                var1 = true;
                                var2 = 0;
                            }
                            else if (a1(5, N, M))
                            {
                                var1 = true;
                                var2 = 2;
                            }
                            else if (M > 10)
                            {
                                M = 10;
                            }
                        }
                        else
                        {
                            var3 = 8;
                        }
                    }
                    else
                    {
                        M += -1;
                        var3 = 1;
                    }
                    break;
                case 2:
                    ++N;
                    if (a1(9, N, M))
                    {
                        N += -1;
                        var3 = 5;
                    }
                    else if (!a1(10, N, M) && !a1(11, N, M))
                    {
                        if (!a1(4, N, M) && !a1(5, N, M))
                        {
                            if (a1(3, N, M))
                            {
                                var1 = true;
                                var2 = 3;
                            }
                            else if (a1(6, N, M))
                            {
                                var1 = true;
                                var2 = 1;
                            }
                            else if (N > 8)
                            {
                                N = 8;
                            }
                        }
                        else
                        {
                            N += -1;
                            var3 = 9;
                        }
                    }
                    else
                    {
                        N += -1;
                        var3 = 2;
                    }
                    break;
                case 3:
                    M += -1;
                    if (a1(9, N, M))
                    {
                        var3 = 6;
                    }

                    if (!a1(10, N, M) && !a1(11, N, M))
                    {
                        if (!a1(3, N, M) && !a1(5, N, M))
                        {
                            if (a1(4, N, M))
                            {
                                var1 = true;
                                var2 = 2;
                            }
                            else if (a1(6, N, M))
                            {
                                var1 = true;
                                var2 = 0;
                            }
                            else if (M < 1)
                            {
                                M = 1;
                            }
                        }
                        else
                        {
                            var3 = 10;
                        }
                    }
                    else
                    {
                        ++M;
                        var3 = 3;
                    }
                    break;
            }
        }

        if (a1(2, N, M))
        {
            ae = true;
            h[2].SetIsVisible(true);
        }
        else
        {
            h[2].SetIsVisible(false);
        }

        int var14 = f[J - 1].posX;
        int var15 = f[J - 1].posY;
        int var16 = g[J - 1].posX;
        int var17 = g[J - 1].posY;
        int var18 = g[J - 1 + 36].posX;
        int var19 = g[J - 1 + 36].posY;
        int var20 = g[J - 1 + 72].posX;
        int var21 = g[J - 1 + 72].posY;
        int var22 = g[J - 1 + 108].posX;
        int var23 = g[J - 1 + 108].posY;
        int var12;
        int var13;
        if (var3 != -1)
        {
            if (var3 == 4 || var3 == 8)
            {
                --M;
            }

            if (var3 == 6 || var3 == 10)
            {
                ++M;
            }

            var12 = M * 19 + 25;
            var13 = N * 19 + 18;
            switch (K)
            {
                case 0:
                    f[J].posY = var15 - (var15 - var13 + aC[var3][1]) + 2;
                    f[J].SetSize(3, var15 - var13 + aC[var3][1]);
                    g[J].posY = var17 - (var17 - var13 + aC[var3][1]) + 2;
                    g[J + 36].posY = var19 - (var19 - var13 + aC[var3][1]) + 2;
                    g[J + 72].posY = var21 - (var21 - var13 + aC[var3][1]) + 2;
                    g[J + 108].posY = var23 - (var23 - var13 + aC[var3][1]) + 2;
                    g[J].SetSize(1, var17 - var13 + aC[var3][1]);
                    g[J + 36].SetSize(1, var19 - var13 + aC[var3][1]);
                    g[J + 72].SetSize(1, var21 - var13 + aC[var3][1]);
                    g[J + 108].SetSize(1, var23 - var13 + aC[var3][1]);
                    break;
                case 1:
                    f[J].SetSize(var12 - var14 + aC[var3][0], 3);
                    g[J].SetSize(var12 - var16 + aC[var3][0], 1);
                    g[J + 36].SetSize(var12 - var18 + aC[var3][0], 1);
                    g[J + 72].SetSize(var12 - var20 + aC[var3][0], 1);
                    g[J + 108].SetSize(var12 - var22 + aC[var3][0], 1);
                    break;
                case 2:
                    f[J].SetSize(3, var13 - var15 + aC[var3][1]);
                    g[J].SetSize(1, var13 - var17 + aC[var3][1]);
                    g[J + 36].SetSize(1, var13 - var19 + aC[var3][1]);
                    g[J + 72].SetSize(1, var13 - var21 + aC[var3][1]);
                    g[J + 108].SetSize(1, var13 - var23 + aC[var3][1]);
                    break;
                case 3:
                    f[J].posX = var14 - (var14 - var12 + aC[var3][0]) + 5;
                    f[J].SetSize(var14 - var12 + aC[var3][0], 3);
                    g[J].posX = var16 - (var16 - var12 + aC[var3][0]) + 5;
                    g[J + 36].posX = var18 - (var18 - var12 + aC[var3][0]) + 5;
                    g[J + 72].posX = var20 - (var20 - var12 + aC[var3][0]) + 5;
                    g[J + 108].posX = var22 - (var22 - var12 + aC[var3][0]) + 5;
                    g[J].SetSize(var16 - var12 + aC[var3][0], 1);
                    g[J + 36].SetSize(var18 - var12 + aC[var3][0], 1);
                    g[J + 72].SetSize(var20 - var12 + aC[var3][0], 1);
                    g[J + 108].SetSize(var22 - var12 + aC[var3][0], 1);
                    break;
            }
        }
        else
        {
            var12 = M * 19 + 25;
            var13 = N * 19 + 18;
            switch (K)
            {
                case 0:
                    f[J].posY = var15 - (var15 - var13) + 3;
                    f[J].SetSize(3, var15 - var13 + 2);
                    g[J].posY = var17 - (var17 - var13) + 3;
                    g[J + 36].posY = var19 - (var19 - var13) + 3;
                    g[J + 72].posY = var21 - (var21 - var13) + 3;
                    g[J + 108].posY = var23 - (var23 - var13) + 3;
                    g[J].SetSize(1, var17 - var13 + 2);
                    g[J + 36].SetSize(1, var19 - var13 + 2);
                    g[J + 72].SetSize(1, var21 - var13 + 2);
                    g[J + 108].SetSize(1, var23 - var13 + 2);
                    break;
                case 1:
                    f[J].SetSize(var12 - var14, 3);
                    g[J].SetSize(var12 - var16, 1);
                    g[J + 36].SetSize(var12 - var18, 1);
                    g[J + 72].SetSize(var12 - var20, 1);
                    g[J + 108].SetSize(var12 - var22, 1);
                    break;
                case 2:
                    f[J].SetSize(3, var13 - var15);
                    g[J].SetSize(1, var13 - var17);
                    g[J + 36].SetSize(1, var13 - var19);
                    g[J + 72].SetSize(1, var13 - var21);
                    g[J + 108].SetSize(1, var13 - var23);
                    break;
                case 3:
                    f[J].posX = var14 - (var14 - var12) + 3;
                    f[J].SetSize(var14 - var12 + 2, 3);
                    g[J].posX = var16 - (var16 - var12) + 3;
                    g[J + 36].posX = var18 - (var18 - var12) + 3;
                    g[J + 72].posX = var20 - (var20 - var12) + 3;
                    g[J + 108].posX = var22 - (var22 - var12) + 3;
                    g[J].SetSize(var16 - var12 + 2, 1);
                    g[J + 36].SetSize(var18 - var12 + 2, 1);
                    g[J + 72].SetSize(var20 - var12 + 2, 1);
                    g[J + 108].SetSize(var22 - var12 + 2, 1);
                    break;
            }
        }

        f[J].SetIsVisible(true);
        g[J].SetIsVisible(true);
        g[J + 36].SetIsVisible(true);
        g[J + 72].SetIsVisible(true);
        g[J + 108].SetIsVisible(true);
        d1();
        n1();
        if (ac)
        {
            h[3].SetIsVisible(false);
            if (al == 0)
            {
                h[8].SetIsVisible(true);
                h[4].SetIsVisible(false);
                i[1].SetIsVisible(true);
                h[10].SetIsVisible(false);
            }
            else
            {
                h[8].SetIsVisible(false);
                h[4].SetIsVisible(true);
                i[1].SetIsVisible(false);
                h[10].SetIsVisible(true);
            }
        }
        else
        {
            h[3].SetIsVisible(true);
            h[8].SetIsVisible(false);
            i[1].SetIsVisible(false);
            h[4].SetIsVisible(false);
            h[10].SetIsVisible(false);
        }

        if (a == 2)
        {
            c1(0);
            h[3].SetIsVisible(false);
        }

        e1(ad);
        if (var1)
        {
            c1();
            if (var2 > -1)
            {
                K = var2;
            }
        }
    }

    [FunctionName("p")]
    private void p1()
    {
        ac = true;
        c1(0);
        a1(0, 0);
        c1(true);
        i[9].SetIsVisible(true);
        d1(3);
    }

    [FunctionName("a")]
    private void a1(ScreenResource var1)
    {
        d1(5);
        var1.ExecuteTransition(0);
        d1(true);
    }

    [FunctionName("q")]
    private void q1()
    {
        Y = 2;
        Z = 0;
        h[24].SetPosition(ai[Y], h[24].posY);
        h[25].SetIsVisible(false);
    }

    [FunctionName("k")]
    private void k1(int var1)
    {
        switch (s.Length)
        {
            case 0:
            case 1:
                Y = 2;
                break;
            case 2:
                if (0 < var1 && var1 < 3)
                {
                    Y = var1;
                }
                else
                {
                    Y = 2;
                }
                break;
            case 3:
                if (0 < var1 && var1 < 4)
                {
                    Y = var1;
                }
                else
                {
                    Y = 2;
                }
                break;
            case 4:
                if (var1 < 4)
                {
                    Y = var1;
                }
                else
                {
                    Y = 2;
                }
                break;
            case 5:
                Y = var1;
                break;
            default:
                Y = var1;
                break;
        }

        h[24].a1(ai[Y], h[24].posY, 1);
    }
}
