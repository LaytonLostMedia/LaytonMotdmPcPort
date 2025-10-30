using System.Text;
using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Managers;
using LaytonMotdm3.c.Resources;

namespace LaytonMotdm3.scene;

[ClassName("scene", "o")]
public class MinigameScene : IScene
{
    private int a;
    private int b;
    private static MinigameScene c = new MinigameScene();
    private int d;
    private ResourceBase[] e = new ResourceBase[3];
    private RectangleResource[] f = new RectangleResource[20];
    private RectangleResource[] g = new RectangleResource[80];
    private ResourceBase[] h = new ResourceBase[31];
    private ResourceBase[] i = new ResourceBase[10];
    private ResourceBase[] j;
    private ResourceBase[] k;
    private ResourceBase[] l;
    private ResourceBase[] m;
    private ResourceBase[] n;
    private ResourceBase[] o;
    private ResourceBase[] p;
    private ResourceBase[] q;
    private int[] r = new int[20];
    private int[] s;
    private int t;
    private int[][] u;
    private int v;
    private int w;
    private int x;
    private int y;
    private int z;
    private int A;
    private int B;
    private JavaString C = "#これはテストデータです\n#アイテムにはルールがあり必ず以下の数値にしてください。\n#0:空白\n#1:光の開始地点\n#2:ゴール地点\n#3:鏡1(左上反射)／\n#4:鏡2(右下反射)／\n#5:鏡3(左下反射)＼\n#6:鏡4(右上反射)＼\n#7:穴\n#8:蓋\n#9:ブロック#10,11: 壁判定用の為変更しないでください(光の開始地点変更除く)\n#MAP\n10,11,11,11,11, 1,11,11,11,11,10,\n10, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,\n10, 0, 0, 0, 0, 9, 0, 0, 0, 0,10,\n10, 0, 0, 0, 0, 0, 9, 2, 0, 0,10,\n10, 0, 0, 0, 0, 0, 0, 0, 0, 0,10,\n10, 0, 0, 0, 0, 0, 9, 0, 0, 0,10,\n10, 0, 0, 0, 0, 9, 0, 9, 0, 0,10,\n10, 0, 0, 0, 0, 0, 0, 7, 0, 0,10,\n10,11,11,11,11,11,11,11,11,11,10,\n\n#光の方向は数値で決めます\n#光の位置(1)からどの方向へ進むのか\n#0:上方向へ\n#1:右方向へ\n#2:下方向へ\n#3:左方向へ\n方向 = 2 \n文言 = あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[br]あああああああああああああ[end]#必ず最後は改行\n";
    private GameFileManager D;
    private int E;
    private int F;
    private int G;
    private int H;
    private int I;
    private int J;
    private int K;
    private int L;
    private int M;
    private int N;
    private int O;
    private int P;
    private int Q;
    private int R;
    private int S;
    private int T;
    private JavaString U;
    private int V;
    private int W;
    private int X;
    private int Y;
    private int Z;
    private bool aa;
    private bool ab;
    private bool ac;
    private bool ad = false;
    private bool ae;
    private bool af;
    private int[] ag = new int[] { 0, 48, 96, 144, 192 };
    private int ah;
    private int ai;
    private int aj;
    private int ak;
    private int al = 0;
    private int am = 0;
    private int an;
    private bool ao;
    private bool ap;
    private bool aq;
    private bool ar;
    private int @as;
    private int at;
    private int au;
    private int av;
    private int[][] aw = (int[][])null;
    private bool ax;
    private int ay = 1;
    private int az = 4;
    private int[][] aA = new int[][] { new[] { 25, 25 }, new[] { 25, 18 }, new[] { 25, 25 }, new[] { 25, 18 }, new[] { 18, 18 }, new[] { 25, 18 }, new[] { 25, 18 }, new[] { 25, 19 }, new[] { 18, 18 }, new[] { 25, 18 }, new[] { 15, 18 }, new[] { 25, 4 }, new[] { 25, 18 } };

    [ConstructorName("o")]
    private MinigameScene()
    {
    }

    public static MinigameScene GetInstance()
    {
        return c;
    }

    private void a1(int var1, int var2)
    {
        this.ah = var1;
        this.ai = var2;
    }

    private bool a1(int var1)
    {
        bool var2 = true;
        this.ah += var1;
        if (this.ah < 0)
        {
            this.ah = 0;
            var2 = false;
        }
        else if (this.ah > 4)
        {
            this.ah = 4;
            var2 = false;
        }

        return var2;
    }

    private bool b1(int var1)
    {
        bool var2 = true;
        this.ai += var1;
        if (this.ai < 0)
        {
            this.ai = 0;
            var2 = false;
        }
        else if (this.ai > 3)
        {
            this.ai = 3;
            var2 = false;
        }

        return var2;
    }

    private void c1(int var1)
    {
        this.aj = var1;
        this.ab = false;
    }

    [FunctionName("a")]
    public void Setup(GameContext var1)
    {
        ScreenResource var2 = var1.ScreenResource;
        this.D = new GameFileManager();
        var1.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        this.d1(0);
        JavaString[] var3 = new JavaString[] { "bg_monooki.jpg", "btn_partselect.gif", "btn_reset.gif", "p_kabe.gif", "p_kagami.gif", "p_ana.gif", "p_yuka.gif", "p_hammer.gif", "p_lamp0.gif", "p_lamp1.gif", "p_ana_small.gif", "font_jennifer.gif", "btn_jennifer.gif", "bg_hanyou.jpg", "monooki.dat", "tuto1.gif", "tuto2.gif" };
        this.d = 0;
        this.Y = 0;
        this.F = 0;
        this.G = 0;
        this.E = 1;
        this.aa = false;
        this.ac = false;
        this.ar = false;
        this.ae = false;
        this.aq = false;
        this.ap = false;
        this.af = true;
        this.ax = true;
        this.ao = true;
        this.O = 1;
        this.P = 1;
        this.Q = 0;
        this.H = 1;
        this.S = 64;
        this.T = 0;
        this.at = 0;
        this.au = 0;
        this.av = 0;
        this.V = 0;
        this.W = 2;
        this.X = 0;
        this.am = 0;
        this.al = 0;
        this.an = 0;
        this.Z = 0;
        this.@as = 0;
        this.c1(0);
        this.a1(0, 0);
        this.a1(0, 0, 0, 0);
        this.b = 0;
        this.ay = 1;
        this.az = 4;
        this.u = new int[9][];
        for (var i = 0; i < u.Length; i++) this.u[i] = new int[11];
        if (!this.D.LoadFiles(var3))
        {
            this.d1(99);
        }
        else
        {
            this.C = new JavaString(this.D.GetLoadedData("monooki.dat"));
            this.t = var1.SaveData.z1();
            if (this.t == 3)
            {
                this.a1(var1, this.C, 1);
                this.S = 0;
            }

            this.a1(var1, this.C, 0);
            this.h[0] = ImageResource.Create(this.D.GetLoadedImage("bg_monooki.jpg"));
            var2.AddChild(this.h[0]);

            int var4;
            for (var4 = 3; var4 < 9; ++var4)
            {
                this.h[var4] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            }

            ((ImageResource)this.h[3]).SetFlipMode(3);
            ((ImageResource)this.h[4]).SetFlipMode(5);
            ((ImageResource)this.h[5]).SetFlipMode(4);
            ((ImageResource)this.h[6]).SetFlipMode(5);
            ((ImageResource)this.h[7]).SetFlipMode(5);
            ((ImageResource)this.h[8]).SetFlipMode(4);
            this.h[25] = ImageResource.Create((ImageResource)this.h[3]);
            ((ImageResource)this.h[25]).SetFlipMode(3);
            this.h[22] = RectangleResource.Create(240, 192, 1, this.T, this.T, this.T, this.S);
            this.h[0].AddChild(this.h[22]);
            this.e1(var1);
            this.m1();
            this.h[1] = ImageResource.Create(this.D.GetLoadedImage("p_lamp0.gif"));
            this.h[2] = ImageResource.Create(this.D.GetLoadedImage("p_lamp1.gif"));
            this.h[2].SetIsVisible(false);
            this.h[0].AddChild(this.h[1]);
            this.h[1].AddChild(this.h[2]);

            for (var4 = 0; var4 < this.n.Length; ++var4)
            {
                this.n[var4] = ImageResource.Create(this.D.GetLoadedImage("p_ana.gif"));
                this.n[var4].SetIsVisible(false);
                this.h[0].AddChild(this.n[var4]);
            }

            for (var4 = 0; var4 < this.o.Length; ++var4)
            {
                this.o[var4] = ImageResource.Create(this.D.GetLoadedImage("p_yuka.gif"));
                this.o[var4].SetIsVisible(false);
                this.h[0].AddChild(this.o[var4]);
                int var5;
                if ((var5 = var1.SaveData.n1(var4)) != 0)
                {
                    this.o[var4].SetPosition(var5 % 11 * 19 + 9, var5 / 11 * 19 + 1);
                    this.o[var4].SetIsVisible(true);
                }
            }

            byte var9 = 25;
            byte var8 = 18;
            switch (this.J)
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

            int[][] var6 = new int[][] { new[]{ 3, 86 }, new[] { 7, 3 }, new[] { 3, 18 }, new[] { 25, 3 } };
            this.h[29] = ImageResource.Create(this.D.GetLoadedImage("p_ana_small.gif"));
            this.h[0].AddChild(this.h[29], this.K * 19 + var9 - this.h[29].GetWidth() / 2 + 1, this.L * 19 + var8 - this.h[29].GetHeight() / 2);
            if (this.J == 3)
            {
                ((ImageResource)this.h[29]).SetFlipMode(4);
                this.h[29].posY += 2;
            }
            else if (this.J == 1)
            {
                ((ImageResource)this.h[29]).SetFlipMode(5);
                this.h[29].posY += 2;
                --this.h[29].posX;
            }
            else if (this.J == 0)
            {
                ((ImageResource)this.h[29]).SetFlipMode(3);
                this.h[29].posY += 2;
            }

            this.f[0] = RectangleResource.Create(1, 1, 1, 255, 255, 0, 128);
            this.f[0].SetRect(this.K * 19 + var9, this.L * 19 + var8, var6[this.J][0], var6[this.J][1]);

            int var7;
            for (var7 = 0; var7 < 4; ++var7)
            {
                this.g[var7 * 20] = RectangleResource.Create(1, 1, 1, 255, 255, 0, 128);
                this.g[var7 * 20].SetRect(this.K * 19 + var9, this.L * 19 + var8, var6[this.J][0], var6[this.J][1]);
            }

            for (var7 = 1; var7 < 20; ++var7)
            {
                this.f[var7] = RectangleResource.Create(0, 0, 1, 255, 255, 0, 128);
                this.h[0].AddChild((ResourceBase)this.f[var7]);
                this.g[var7] = RectangleResource.Create(0, 0, 1, 255, 255, 0, 128);
                this.g[var7 + 20] = RectangleResource.Create(0, 0, 1, 255, 255, 0, 128);
                this.g[var7 + 40] = RectangleResource.Create(0, 0, 1, 150, 150, 0, 128);
                this.g[var7 + 60] = RectangleResource.Create(0, 0, 1, 150, 150, 0, 128);
                this.h[0].AddChild((ResourceBase)this.g[var7]);
                this.h[0].AddChild((ResourceBase)this.g[var7 + 20]);
                this.h[0].AddChild((ResourceBase)this.g[var7 + 40]);
                this.h[0].AddChild((ResourceBase)this.g[var7 + 60]);
            }

            for (var4 = 0; var4 < this.j.Length; ++var4)
            {
                this.j[var4] = ImageResource.Create(this.D.GetLoadedImage("p_kagami.gif"));
                ((ImageResource)this.j[var4]).SetFlipMode(1);
                this.j[var4].SetIsVisible(false);
                this.h[0].AddChild(this.j[var4]);
            }

            for (var4 = 0; var4 < this.k.Length; ++var4)
            {
                this.k[var4] = ImageResource.Create(this.D.GetLoadedImage("p_kagami.gif"));
                ((ImageResource)this.k[var4]).SetFlipMode(5);
                this.k[var4].SetIsVisible(false);
                this.h[0].AddChild(this.k[var4]);
            }

            for (var4 = 0; var4 < this.l.Length; ++var4)
            {
                this.l[var4] = ImageResource.Create(this.D.GetLoadedImage("p_kagami.gif"));
                ((ImageResource)this.l[var4]).SetFlipMode(6);
                this.l[var4].SetIsVisible(false);
                this.h[0].AddChild(this.l[var4]);
            }

            for (var4 = 0; var4 < this.m.Length; ++var4)
            {
                this.m[var4] = ImageResource.Create(this.D.GetLoadedImage("p_kagami.gif"));
                this.m[var4].SetIsVisible(false);
                this.h[0].AddChild(this.m[var4]);
            }

            this.h[30] = RectangleResource.Create(34, 8, 1, 255, 255, 255, 128);
            this.h[0].AddChild(this.h[30]);
            this.h[30].SetIsVisible(false);

            for (var4 = 0; var4 < this.p.Length; ++var4)
            {
                this.p[var4] = ImageResource.Create(this.D.GetLoadedImage("p_kabe.gif"));
                this.h[0].AddChild((ResourceBase)this.p[var4], -10, 0);
            }

            this.h[12] = ImageResource.Create(this.D.GetLoadedImage("p_kagami.gif"));
            this.h[12].SetIsVisible(false);
            this.h[0].AddChild(this.h[12]);
            this.h[9] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
            ((ImageResource)this.h[9]).ClipRect(0, 0, 40, 15);
            this.h[10] = ImageResource.Create((ImageResource)this.h[9]);
            ((ImageResource)this.h[10]).ClipRect(40, 0, 40, 15);
            this.h[0].AddChild(this.h[10]);
            this.h[0].AddChild(this.h[9]);
            this.b1(false);
            this.h[18] = ImageResource.Create((ImageResource)this.h[3]);
            this.h[0].AddChild((ResourceBase)this.h[18], 150, 172);
            ((ImageResource)this.h[18]).SetAnchorType(5);
            this.h[18].SetIsVisible(false);
            this.h[13] = ImageResource.Create(this.D.GetLoadedImage("btn_jennifer.gif"));
            ((ImageResource)this.h[13]).ClipRect(0, 0, 71, 15);
            this.h[14] = ImageResource.Create((ImageResource)this.h[13]);
            ((ImageResource)this.h[14]).ClipRect(71, 0, 71, 15);
            this.h[0].AddChild(this.h[14]);
            this.h[0].AddChild(this.h[13]);
            this.h[14].SetIsVisible(false);
            if (this.t != 3)
            {
                this.h[13].SetIsVisible(false);
            }

            this.d1(false);
            this.h[0].AddChild((ResourceBase)this.h[8], 60, 6);
            this.h[8].SetIsVisible(false);
            this.i[0] = ImageResource.Create(this.D.GetLoadedImage("btn_reset.gif"));
            ((ImageResource)this.i[0]).ClipRect(0, 0, 50, 15);
            this.i[1] = ImageResource.Create((ImageResource)this.i[0]);
            ((ImageResource)this.i[1]).ClipRect(50, 0, 50, 15);
            this.h[0].AddChild((ResourceBase)this.i[1], 5, 5);
            this.h[0].AddChild((ResourceBase)this.i[0], 5, 5);
            this.i[1].SetIsVisible(false);
            this.i[2] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small1.gif"));
            this.i[3] = TextResource.Create("へやを最初の状態に戻しますか？");
            this.i[4] = TextResource.Create("※パーツはなくなりません。");
            this.i[5] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
            this.i[6] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
            this.i[7] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
            this.i[8] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));
            this.i[6].SetIsVisible(false);
            this.i[9] = RectangleResource.Create(240, 192, 1, 255, 255, 255, 128);
            this.h[0].AddChild(this.i[9]);
            this.i[9].AddChild(this.i[2], (240 - this.i[2].GetWidth()) / 2, (this.h[0].GetHeight() - this.i[2].GetHeight()) / 2);
            this.i[9].AddChild(this.i[5]);
            this.i[9].AddChild(this.i[6]);
            this.i[9].AddChild(this.i[7]);
            this.i[9].AddChild(this.i[8]);
            this.a1(0, false);
            this.a1(1, false);
            this.i[9].AddChild((ResourceBase)this.h[7], 122, 110);
            this.i[9].AddChild((ResourceBase)this.i[3], (240 - this.i[3].GetWidth()) / 2, 72);
            this.i[9].AddChild((ResourceBase)this.i[4], (240 - this.i[4].GetWidth()) / 2, 85);
            this.h1(1);
            this.i[9].SetIsVisible(false);
            this.a1(var1, true);
            this.h[23] = RectangleResource.Create(240, 192, 1, 255, 255, 255, 0);
            this.h[0].AddChild(this.h[23]);
            this.q = new ResourceBase[this.r.Length];

            for (var4 = 0; var4 < this.q.Length; ++var4)
            {
                this.q[var4] = ImageResource.Create(this.D.GetLoadedImage("p_kagami.gif"));
                this.q[var4].SetIsVisible(false);
                this.h[23].AddChild((ResourceBase)this.q[var4], 48 * var4 + 5, 200);
            }

            this.h[24] = RectangleResource.Create(48, 1, 0, 0, 0, 0, 0);
            this.h[23].AddChild((ResourceBase)this.h[24], (240 - this.h[24].GetWidth()) / 2, 195);
            this.h[0].AddChild((ResourceBase)this.h[4], 185, 7);
            ((ImageResource)this.h[4]).SetFlipMode(5);
            this.h[4].SetIsVisible(false);
            this.h[0].AddChild(this.h[3], this.ah * 38 + 37, this.ai * 38 + 20);
            this.h[24].AddChild((ResourceBase)this.h[25], 15, -2);
            this.h[25].SetIsVisible(false);
            this.h[23].AddChild((ResourceBase)this.h[5], 0, 210);
            this.h[23].AddChild((ResourceBase)this.h[6], 230, 210);
            this.h[5].SetIsVisible(false);
            this.h[6].SetIsVisible(false);
            this.h[11] = ImageResource.Create(this.D.GetLoadedImage("p_hammer.gif"));
            this.h[0].AddChild(this.h[11]);
            this.h[11].SetIsVisible(false);
            this.h[15] = ImageResource.Create(this.D.GetLoadedImage("bg_hanyou.jpg"));
            this.h[0].AddChild(this.h[15]);
            this.h[15].SetIsVisible(false);
            this.h[19] = ImageResource.Create((ImageResource)this.h[9]);
            ((ImageResource)this.h[19]).ClipRect(0, 0, 40, 15);
            this.h[20] = ImageResource.Create((ImageResource)this.h[9]);
            ((ImageResource)this.h[20]).ClipRect(40, 0, 40, 15);
            this.h[15].AddChild((ResourceBase)this.h[20], 195, 172);
            this.h[15].AddChild((ResourceBase)this.h[19], 195, 172);
            this.h[17] = ImageResource.Create((ImageResource)this.h[3]);
            this.h[15].AddChild((ResourceBase)this.h[17], 186, 173);
            ((ImageResource)this.h[17]).SetFlipMode(5);
            this.h[16] = ImageResource.Create(this.D.GetLoadedImage("font_jennifer.gif"));
            this.h[15].AddChild((ResourceBase)this.h[16], 4, 4);
            this.h[21] = ScriptTextResource.Create(this.U);
            this.h[15].AddChild((ResourceBase)this.h[21], 12, 31);
            this.h[26] = ImageResource.Create((ImageResource)this.i[2]);
            this.h[27] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
            this.h[28] = ScriptTextResource.Create("使えるパーツがありません。[end]");
            this.h[23].AddChild(this.h[26]);
            this.h[26].AddChild((ResourceBase)this.h[27], 190, 65);
            ((ImageResource)this.h[27]).ClipRect(0, 0, this.h[27].GetWidth() / 2, this.h[27].GetHeight());
            this.h[26].AddChild((ResourceBase)this.h[28], 30, 30);
            this.h[26].SetIsVisible(false);
            this.e[0] = ImageResource.Create(this.D.GetLoadedImage("tuto1.gif"));
            this.e[1] = ImageResource.Create(this.D.GetLoadedImage("tuto2.gif"));
            this.e[2] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
            ((ImageResource)this.e[0]).SetAnchorType(1);
            var2.AddChild((ResourceBase)this.e[0], 120, 0);
            ((ImageResource)this.e[1]).SetAnchorType(1);
            var2.AddChild((ResourceBase)this.e[1], 120, 0);
            var2.AddChild((ResourceBase)this.e[2], 223, 175);
            ((ImageResource)this.e[2]).ClipRect(0, 0, this.e[2].GetWidth() / 2, this.e[2].GetHeight());
            ((ImageResource)this.e[2]).b1(1, 3);
            this.e[0].SetIsVisible(false);
            this.e[1].SetIsVisible(false);
            this.e[2].SetIsVisible(false);
            if (var1.SaveData.h1() == 1)
            {
                this.e[0].SetIsVisible(true);
                this.e[2].SetIsVisible(true);
                this.d1(10);
                var1.SaveData.g1();
            }
            else if (this.ad)
            {
                this.d1(5);
                this.a1(true);
            }
            else
            {
                this.i1();
                this.j1();
                this.k1();
            }

            this.b1();
            var2.ExecuteTransition(1);
        }
    }

    private void a1(bool var1)
    {
        if (var1)
        {
            this.h[15].SetIsVisible(true);
            this.h[13].SetIsVisible(false);
            this.h[14].SetIsVisible(false);
            this.h[18].SetIsVisible(false);
            ((ScriptTextResource)this.h[21]).SetText(this.U);
        }
        else
        {
            this.h[15].SetIsVisible(false);
            this.h[19].SetPosition(195, 172);
            this.h[20].SetPosition(195, 172);
        }
    }

    private void b1(int var1, int var2)
    {
        int var3;
        for (var3 = 1; var3 < 20; ++var3)
        {
            this.f[var3].SetIsVisible(false);
            this.g[var3].SetIsVisible(false);
            this.g[var3 + 20].SetIsVisible(false);
            this.g[var3 + 40].SetIsVisible(false);
            this.g[var3 + 60].SetIsVisible(false);
        }

        for (var3 = 1; var3 < this.H + 1; ++var3)
        {
            if (var3 == 1)
            {
                if (this.J == 3)
                {
                    this.f[var3].SetPosition(220, var2 * 19 + 18);
                    this.g[var3].SetPosition(220, var2 * 19 + 18 - 1);
                    this.g[var3 + 20].SetPosition(220, var2 * 19 + 18 + 3);
                    this.g[var3 + 40].SetPosition(220, var2 * 19 + 18 - 2);
                    this.g[var3 + 60].SetPosition(220, var2 * 19 + 18 + 4);
                }
                else if (this.J == 1)
                {
                    this.f[var3].SetPosition(18, var2 * 19 + 18);
                    this.g[var3].SetPosition(18, var2 * 19 + 18 - 1);
                    this.g[var3 + 20].SetPosition(18, var2 * 19 + 18 + 3);
                    this.g[var3 + 40].SetPosition(18, var2 * 19 + 18 - 2);
                    this.g[var3 + 60].SetPosition(18, var2 * 19 + 18 + 4);
                }
                else if (this.J == 2)
                {
                    this.f[var3].SetPosition(var1 * 19 + 25, 13);
                    this.g[var3].SetPosition(var1 * 19 + 25 - 1, 13);
                    this.g[var3 + 20].SetPosition(var1 * 19 + 25 + 3, 13);
                    this.g[var3 + 40].SetPosition(var1 * 19 + 25 - 2, 13);
                    this.g[var3 + 60].SetPosition(var1 * 19 + 25 + 4, 13);
                }
                else
                {
                    this.f[var3].SetPosition(var1 * 19 + 25, var2 * 19 + 18);
                    this.g[var3].SetPosition(var1 * 19 + 25 - 1, var2 * 19 + 18 - 1);
                    this.g[var3 + 20].SetPosition(var1 * 19 + 25 + 3, var2 * 19 + 18 + 3);
                    this.g[var3 + 40].SetPosition(var1 * 19 + 25 - 2, var2 * 19 + 18 - 2);
                    this.g[var3 + 60].SetPosition(var1 * 19 + 25 + 4, var2 * 19 + 18 + 4);
                }
            }
        }

    }

    private void b1()
    {
        this.ac = false;
        this.K = this.M;
        this.L = this.N;
        this.H = 1;
        this.I = this.J;
        this.b1(this.K, this.L);
    }

    private void d1(int var1)
    {
        this.ak = this.a;
        this.a = var1;
    }

    [FunctionName("b")]
    public bool Update(GameContext var1)
    {
        ScreenResource var2 = var1.ScreenResource;
        bool var3 = false;
        int var4;
        int var5;
        int var6;
        int var7;
        switch (this.a)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    this.d1(1);
                }
                break;
            case 1:
                if (var2._transitionState == 2)
                {
                    this.a1(false);
                    this.i1();
                    this.j1();
                    this.k1();
                    if (this.t != 3)
                    {
                        this.h[13].SetIsVisible(false);
                        this.h[14].SetIsVisible(false);
                    }
                    else
                    {
                        this.h[13].SetIsVisible(true);
                    }

                    var2.ExecuteTransition(1);
                }

                if (var2._transitionState == 0)
                {
                    if (this.t != 3)
                    {
                        this.h[13].SetIsVisible(false);
                        this.h[14].SetIsVisible(false);
                    }
                    else
                    {
                        this.h[13].SetIsVisible(true);
                    }

                    if (this.V == 0 && this.Y == 0)
                    {
                        this.f1(true);
                    }
                    else
                    {
                        this.f1(false);
                    }

                    if (!this.ae)
                    {
                        if (var1.IsKeyPressed(131072))
                        {
                            if (this.ab)
                            {
                                this.ab = false;
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (this.b1(-1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (this.V == 0 && this.Y == 0)
                            {
                                if (!this.aa)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                    if (this.ah < 2)
                                    {
                                        this.c1(0);
                                    }
                                    else
                                    {
                                        this.c1(1);
                                    }
                                }

                                this.aa = true;
                            }
                        }
                        else if (var1.IsKeyPressed(524288))
                        {
                            if (this.aa)
                            {
                                this.aa = false;
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (this.b1(1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                            else if (this.V == 0 && this.Y == 0 && this.t == 3)
                            {
                                if (this.s.Length != 0)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                    this.ab = false;
                                    this.d1(2);
                                    this.k1(this.ah);
                                }
                            }
                            else if (this.V == 0 && this.Y == 0 && this.s.Length != 0)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                this.ab = false;
                                this.d1(2);
                                this.k1(this.ah);
                            }
                        }
                        else if (var1.IsKeyPressed(262144) && !this.ab)
                        {
                            if (this.aa)
                            {
                                if (this.aj != 1)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                }

                                this.c1(1);
                            }
                            else if (this.a1(1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (var1.IsKeyPressed(65536) && !this.ab)
                        {
                            if (this.aa)
                            {
                                if (this.aj != 0)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                }

                                this.c1(0);
                            }
                            else if (this.a1(-1))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (var1.IsKeyPressed(2) && this.V == 0 && this.Y == 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            this.p1();
                        }
                        else if (var1.IsKeyPressed(4) && this.V == 0 && this.Y == 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            this.a1(0, 0);
                            this.aa = true;
                            this.c1(1);
                            this.b1(true);
                            var3 = true;
                        }
                        else if (var1.IsKeyPressed(4) && this.Y == 1)
                        {
                            this.V = 0;
                            this.Y = 0;
                            if ((var4 = this.at - 2) == 6)
                            {
                                var4 = 5;
                            }

                            this.j1(var4);
                            this.aq = true;
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            this.i1();
                            this.j1();
                            this.k1();
                        }
                        else if (var1.IsKeyPressed(4) && this.V == 1)
                        {
                            var4 = this.u[this.v][this.w];
                            this.u[this.v][this.w] = this.at;
                            this.at = var4;
                            if (this.at == 0)
                            {
                                this.V = 0;
                            }
                            else
                            {
                                this.f1(this.at - 2);
                            }

                            this.a1(this.x, this.y);
                            this.b1();
                            this.a1(var1, true);
                            this.ap = true;
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        }
                        else if (var1.IsKeyPressed(1048576))
                        {
                            if (this.aa)
                            {
                                if (this.aj == 0)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    this.p1();
                                }
                                else
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                                    this.b1(true);
                                    var3 = true;
                                }
                            }
                            else if (this.Y == 1)
                            {
                                var4 = this.ai * 2 + 1;
                                var5 = this.ah * 2 + 1;
                                if (this.at == 8)
                                {
                                    if (this.a1(7, var4, var5))
                                    {
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                        this.u[var4][var5] = this.at;
                                        this.Y = 0;
                                        this.at = 0;
                                        var1.SaveData.m1(var4 * 11 + var5);
                                        this.a1(var1, true);
                                        this.b1();
                                    }
                                }
                                else
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    if (!this.a1(0, var4, var5) && !this.a1(8, var4, var5))
                                    {
                                        if (this.a1(3, var4, var5) || this.a1(4, var4, var5) || this.a1(5, var4, var5) || this.a1(6, var4, var5))
                                        {
                                            var6 = this.u[this.ai * 2 + 1][this.ah * 2 + 1];
                                            this.u[this.ai * 2 + 1][this.ah * 2 + 1] = this.at;
                                            this.at = var6;
                                            this.f1(this.at - 2);
                                            this.a1(var1, true);
                                            this.b1();
                                            this.Y = 0;
                                            this.V = 1;
                                        }
                                    }
                                    else
                                    {
                                        this.u[var4][var5] = this.at;
                                        this.at = 0;
                                        this.Y = 0;
                                        this.a1(var1, true);
                                        this.b1();
                                    }

                                    this.a1(this.ah, this.ai, var4, var5);
                                }
                            }
                            else
                            {
                                ++this.V;
                                if (this.V == 1)
                                {
                                    this.au = this.ai * 2 + 1;
                                    this.av = this.ah * 2 + 1;
                                    if (this.av < 1)
                                    {
                                        this.av = 1;
                                    }
                                    else if (this.av > 9)
                                    {
                                        this.av = 9;
                                    }

                                    if (this.au < 1)
                                    {
                                        this.au = 1;
                                    }
                                    else if (this.au > 7)
                                    {
                                        this.au = 7;
                                    }

                                    this.at = this.u[this.au][this.av];
                                    if (this.at != 0 && this.at != 7 && this.at != 8 && this.at != 2)
                                    {
                                        this.u[this.au][this.av] = 0;
                                        this.a1(this.ah, this.ai, this.au, this.av);
                                    }
                                    else
                                    {
                                        this.V = 0;
                                    }

                                    if (this.V == 1)
                                    {
                                        this.b1();
                                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                        this.f1(this.at - 2);
                                    }
                                }
                                else if (this.V == 2)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    if (this.at == 8)
                                    {
                                        if (this.a1(7, this.ai * 2 + 1, this.ah * 2 + 1))
                                        {
                                            this.u[this.ai * 2 + 1][this.ah * 2 + 1] = this.at;
                                            this.u[this.au][this.av] = 0;
                                            this.V = 0;
                                            var1.SaveData.m1(this.av * 11 + this.au);
                                            this.b1();
                                        }
                                        else
                                        {
                                            this.u[this.au][this.av] = this.at;
                                            this.V = 1;
                                            this.b1();
                                        }
                                    }
                                    else if (this.at == 3 || this.at == 4 || this.at == 5 || this.at == 6)
                                    {
                                        if (this.a1(8, this.ai * 2 + 1, this.ah * 2 + 1))
                                        {
                                            this.u[this.ai * 2 + 1][this.ah * 2 + 1] = this.at;
                                            this.u[this.au][this.av] = 0;
                                            this.V = 0;
                                            this.at = 0;
                                            this.b1();
                                            this.a1(this.ah, this.ai, this.ai * 2 + 1, this.ah * 2 + 1);
                                        }
                                        else if (!this.a1(2, this.ai * 2 + 1, this.ah * 2 + 1) && !this.a1(7, this.ai * 2 + 1, this.ah * 2 + 1))
                                        {
                                            if (this.a1(0, this.ai * 2 + 1, this.ah * 2 + 1))
                                            {
                                                var4 = this.u[this.ai * 2 + 1][this.ah * 2 + 1];
                                                this.u[this.ai * 2 + 1][this.ah * 2 + 1] = this.at;
                                                this.at = var4;
                                                this.V = 0;
                                                this.b1();
                                                this.a1(this.ah, this.ai, this.ai * 2 + 1, this.ah * 2 + 1);
                                            }
                                            else
                                            {
                                                var4 = this.u[this.ai * 2 + 1][this.ah * 2 + 1];
                                                this.u[this.ai * 2 + 1][this.ah * 2 + 1] = this.at;
                                                this.at = var4;
                                                this.V = 1;
                                                this.b1();
                                                this.f1(this.at - 2);
                                                this.a1(this.ah, this.ai, this.ai * 2 + 1, this.ah * 2 + 1);
                                            }
                                        }
                                        else
                                        {
                                            this.V = 1;
                                        }
                                    }

                                    this.a1(var1, true);
                                }
                            }
                        }
                        else if (var1.IsKeyPressed(32) && this.V == 0 && this.Y == 0 && this.t == 3)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            this.a1(var2);
                        }
                    }

                    if (this.V == 1)
                    {
                        this.a1(var1, true);
                        this.e1(this.at - 2);
                    }
                    else if (this.Y == 1)
                    {
                        this.e1(this.at - 2);
                    }
                    else
                    {
                        this.h[12].SetIsVisible(false);
                    }

                    if (this.ac)
                    {
                        if (this.t != 3 && !this.ae)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            this.ae = true;
                        }

                        this.S -= 2;
                        this.T += 25;
                        if (this.T > 255)
                        {
                            this.T = 255;
                        }

                        if (this.S <= 0)
                        {
                            this.S = 0;
                            if (this.t != 3)
                            {
                                this.b = 1;
                                this.ad = true;
                                var3 = true;
                                this.t = 3;
                                if ((var4 = this.at - 2) == 6)
                                {
                                    var4 = 5;
                                }

                                if (this.V != 0 || this.at != 0)
                                {
                                    this.V = 0;
                                    this.i1(var4);
                                }
                            }
                        }

                       ((RectangleResource)this.h[22]).SetColor(this.T, this.T, this.T, this.S);
                    }

                    this.o1();
                    if (this.aq)
                    {
                        this.h1();
                    }
                    else if (this.ap)
                    {
                        this.g1();
                    }

                    if (var3)
                    {
                        var2.ExecuteTransition(0);
                        this.d1(99);
                    }

                    this.e1();
                }
                break;
            case 2:
                if (var2._transitionState == 2)
                {
                    this.a1(false);

                    for (var4 = 0; var4 < this.q.Length; ++var4)
                    {
                        this.q[var4].SetIsVisible(true);
                    }

                    if (this.t != 3)
                    {
                        this.h[13].SetIsVisible(false);
                        this.h[14].SetIsVisible(false);
                    }
                    else
                    {
                        this.h[13].SetIsVisible(true);
                    }

                    var2.ExecuteTransition(1);
                }
                else if (var2._transitionState == 0)
                {
                    this.h[25].SetIsVisible(true);
                    this.h[18].SetIsVisible(false);
                    this.e1();
                    bool var10 = false;
                    this.l1();
                    this.o1();
                    if (this.h[24].h1())
                    {
                        if (var1.IsKeyPressed(131072))
                        {
                            this.d1(1);
                            this.ah = this.W;
                            this.h[25].SetIsVisible(false);
                        }
                        else if (!var1.IsKeyPressed(1048576))
                        {
                            if (var1.IsKeyPressed(2))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                this.p1();
                                this.h[8].SetIsVisible(true);
                                this.h[25].SetIsVisible(false);
                            }
                            else if (var1.IsKeyPressed(4))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                                this.a1(0, 0);
                                this.aa = false;
                                this.c1(1);
                                this.b1(true);
                                var3 = true;
                                this.h[4].SetIsVisible(true);
                                this.h[25].SetIsVisible(false);
                            }
                            else if (var1.IsKeyPressed(32))
                            {
                                if (this.t == 3)
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                    this.a1(var2);
                                }
                            }
                            else if (this.s.Length > 0)
                            {
                                if (var1.IsKeyPressed(65536) && 0 < this.W + this.X - this.Z / 48)
                                {
                                    --this.W;
                                    if (this.W < 0)
                                    {
                                        this.W = 0;
                                        if (this.X > 0)
                                        {
                                            this.g1(0);
                                            --this.X;
                                            if (this.X < 0)
                                            {
                                                this.X = 0;
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

                                    this.j1();
                                    this.h[24].a1(this.ag[this.W], this.h[24].posY, 5);
                                }

                                if (var1.IsKeyPressed(262144) && this.s.Length - 1 > this.W + this.X - this.Z / 48)
                                {
                                    ++this.W;
                                    if (this.W > 4)
                                    {
                                        this.W = 4;
                                        if (this.s.Length - 1 > this.W + this.X)
                                        {
                                            this.g1(1);
                                            ++this.X;
                                            if (this.s.Length < this.W + this.X)
                                            {
                                                this.X = this.s.Length - this.W;
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

                                    this.j1();
                                    this.h[24].a1(this.ag[this.W], this.h[24].posY, 5);
                                }
                            }
                        }
                        else
                        {
                            if (this.s.Length > this.W + this.X - this.Z / 48 && -1 < this.W + this.X - this.Z / 48)
                            {
                                this.f1();
                                this.d1(1);
                                int[] var9 = new int[] { 0, 3, 4, 5, 6, 8, 12 };
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                if ((var4 = var9[this.s[this.W + this.X - this.Z / 48]]) == 12)
                                {
                                    this.d1(6);
                                    this.O = 5;
                                    this.P = 4;
                                }
                                else
                                {
                                    this.at = var4;
                                    this.f1(this.s[this.W + this.X - this.Z / 48]);
                                    this.d1(1);
                                }

                                this.Y = 1;
                                this.s[this.W + this.X - this.Z / 48] = 0;
                                this.r = this.s;
                                this.a1(2, 2);
                                var6 = 0;

                                for (var7 = 0; var7 < this.r.Length; ++var7)
                                {
                                    if (this.s[var7] != 0)
                                    {
                                        ++var6;
                                    }
                                }

                                this.s = new int[var6];
                                var7 = 0;

                                for (int var8 = 0; var8 < this.r.Length; ++var8)
                                {
                                    if (this.r[var8] != 0)
                                    {
                                        this.s[var7] = this.r[var8];
                                        ++var7;
                                    }
                                }

                                this.q1();
                                this.i1();
                                this.j1();
                                this.k1();
                            }
                            else if (this.s.Length == 0)
                            {
                                this.f1();
                                this.d1(1);
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            }

                            for (var5 = 0; var5 < this.q.Length; ++var5)
                            {
                                this.q[var5].posX = var5 * 48 + 5 + this.Z;
                            }

                            //System.gc();
                            this.h[25].SetIsVisible(false);
                        }
                    }

                    for (var5 = 0; var5 < this.q.Length; ++var5)
                    {
                        this.q[var5].h1();
                    }

                    if (var3)
                    {
                        var2.ExecuteTransition(0);
                        this.d1(99);
                    }
                }
                break;
            case 3:
                if (this.G == 0)
                {
                    if (var1.IsKeyPressed(65536))
                    {
                        if (this.E != 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }

                        this.E = 0;
                        this.h1(this.E);
                    }
                    else if (var1.IsKeyPressed(262144))
                    {
                        if (this.E != 1)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }

                        this.E = 1;
                        this.h1(this.E);
                    }
                    else if (var1.IsKeyPressed(1048576))
                    {
                        this.G = 1;
                        if (this.E == 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            this.a1(0, true);
                            this.h[2].SetIsVisible(false);
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                            this.a1(1, true);
                        }
                    }
                }

                if (this.G == 1)
                {
                    ++this.F;
                    if (this.F > 10)
                    {
                        this.i[9].SetIsVisible(false);
                        this.d1(1);
                        this.c1(false);
                        this.G = 0;
                        this.F = 0;
                        if (this.E == 0)
                        {
                            var1.SaveData.j1();
                            var1.SaveData.k1();

                            for (var4 = 0; var4 < this.o.Length; ++var4)
                            {
                                this.o[var4].SetIsVisible(false);
                            }

                            this.e1(var1);
                            this.a1(var1, this.C, 0);
                            this.u = this.aw;
                            var4 = 0;

                            while (true)
                            {
                                if (var4 >= 4)
                                {
                                    this.a1(var1, true);
                                    this.b1();
                                    this.W = 2;
                                    this.X = 0;
                                    this.i1();
                                    this.j1();
                                    this.k1();
                                    break;
                                }

                                for (var5 = 0; var5 < 5; ++var5)
                                {
                                    if (this.u[var4 * 2 + 1][var5 * 2 + 1] == 8)
                                    {
                                        var6 = var4 * 2 + 1;
                                        var7 = var5 * 2 + 1;
                                        var1.SaveData.m1(var6 * 11 + var7);
                                    }
                                }

                                ++var4;
                            }
                        }

                        this.E = 1;
                        this.a1(0, false);
                        this.a1(1, false);
                        this.h1(this.E);
                    }
                }
                break;
            case 5:
                if (var2._transitionState == 2)
                {
                    this.i1();
                    this.a1(true);
                    var2.ExecuteTransition(1);
                    this.h[5].SetIsVisible(false);
                    this.h[6].SetIsVisible(false);
                }

                if (var2._transitionState == 0 && (var1.IsKeyPressed(1048576) || var1.IsKeyPressed(4)))
                {
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                    this.ad = false;
                    var2.ExecuteTransition(0);
                    this.h[19].SetPosition(this.h[19].posX + 2, this.h[19].posY + 2);
                    this.h[20].SetPosition(this.h[20].posX + 2, this.h[20].posY + 2);
                    this.d1(false);
                    if (this.ak == 2)
                    {
                        this.d1(2);
                    }
                    else
                    {
                        this.d1(1);
                    }
                }
                break;
            case 6:
                this.f1(false);
                this.h[11].SetPosition(this.O * 19 + 19, this.P * 19 + 3);
                this.h[11].SetIsVisible(true);
                this.h[30].SetIsVisible(true);
                this.a1(this.O / 2, this.P / 2);
                if (this.@as == 0 && !this.ae)
                {
                    if (var1.IsKeyPressed(131072))
                    {
                        this.P += -1;
                        if (this.P < 1)
                        {
                            this.P = 1;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            if (this.P % 2 == 0)
                            {
                                --this.O;
                                if (this.O < 1)
                                {
                                    this.O = 1;
                                    this.R = 1;
                                }
                            }
                            else if (this.O == 1 && this.R == 1)
                            {
                                --this.O;
                                this.R = 0;
                            }
                            else
                            {
                                ++this.O;
                                if (this.O > 10)
                                {
                                    this.O = 10;
                                }

                                if (this.Q == 1)
                                {
                                    this.O -= 2;
                                }
                            }
                        }
                    }
                    else if (var1.IsKeyPressed(524288))
                    {
                        ++this.P;
                        if (this.P > 7)
                        {
                            this.P = 7;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            if (this.P % 2 == 0)
                            {
                                --this.O;
                                if (this.O < 0)
                                {
                                    this.O = 1;
                                    this.R = 1;
                                }
                            }
                            else if (this.O == 1 && this.R == 1)
                            {
                                --this.O;
                                this.R = 0;
                            }
                            else
                            {
                                ++this.O;
                                if (this.O > 10)
                                {
                                    this.O = 10;
                                }

                                if (this.Q == 1)
                                {
                                    this.O -= 2;
                                }
                            }
                        }
                    }
                    else if (var1.IsKeyPressed(65536))
                    {
                        this.O += -2;
                        if (this.P % 2 == 0)
                        {
                            if (this.O < 1)
                            {
                                this.O = 1;
                            }
                            else
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (this.O < 0)
                        {
                            this.O = 0;
                            this.Q = 1;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(262144))
                    {
                        this.R = 0;
                        this.Q = 0;
                        this.O += 2;
                        if (this.P % 2 == 0)
                        {
                            if (this.O > 9)
                            {
                                this.O = 9;
                            }
                            else
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (this.O > 10)
                        {
                            this.O = 10;
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(1048576))
                    {
                        if (this.a1(9, this.P, this.O))
                        {
                            for (var4 = 0; var4 < this.p.Length; ++var4)
                            {
                                this.p[var4].SetIsVisible(false);
                            }

                            this.ar = true;
                            PhoneManager.a1(3);
                            this.u[this.P][this.O] = 0;
                            this.A = -1;
                            this.B = 0;
                            this.a1(var1, true);
                            this.Y = 0;
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(4) && !this.ar)
                    {
                        this.j1(6);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        this.aq = true;
                    }

                    if (this.O % 2 == 0)
                    {
                        this.h[30].SetPosition(this.O * 19 + 22, this.P * 19);
                        ((RectangleResource)this.h[30]).SetPosition(8, 34);
                    }
                    else
                    {
                        this.h[30].SetPosition(this.O * 19 + 8, this.P * 19 + 14);
                        ((RectangleResource)this.h[30]).SetPosition(34, 8);
                    }

                    this.a1(this.O, this.P, true);
                }

                if (this.ac)
                {
                    if (this.t != 3 && !this.ae)
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        this.ae = true;
                    }

                    this.S -= 2;
                    this.T += 25;
                    if (this.T > 255)
                    {
                        this.T = 255;
                    }

                    if (this.S <= 0)
                    {
                        this.S = 0;
                        if (this.t != 3)
                        {
                            this.b = 1;
                            this.ad = true;
                            var3 = true;
                            this.t = 3;
                            this.V = 0;
                            this.i1(6);
                        }
                    }

                   ((RectangleResource)this.h[22]).SetColor(this.T, this.T, this.T, this.S);
                }
                
                if (this.ar)
                {
                    ((ImageResource)this.h[11]).SetSize(this.h[11].GetWidth() / 2, this.h[11].GetHeight() / 2);
                    ((ImageResource)this.h[11]).SetScale(315.0F);
                    this.ar = this.d1(var1);
                    this.aa = false;
                }

                this.o1();
                if (this.aq)
                {
                    this.h1();
                    this.a1(this.O, this.P, false);
                }
                else
                {
                    this.h[3].SetIsVisible(true);
                    this.h[3].SetPosition(this.h[11].posX, this.h[11].posY - 10);
                }

                if (var3)
                {
                    var2.ExecuteTransition(0);
                    this.d1(99);
                }

                this.e1();
                this.i1();
                this.j1();
                this.k1();
                break;
            case 10:
                if (var2._transitionState == 0 && var1.IsKeyPressed(1048576))
                {
                    ++this.d;
                    if (this.d == 1)
                    {
                        this.e[0].SetIsVisible(false);
                        this.e[1].SetIsVisible(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (this.d == 2)
                    {
                        var2.ExecuteTransition(0);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                }

                if (var2._transitionState == 2)
                {
                    this.e[1].SetIsVisible(false);
                    this.e[2].SetIsVisible(false);
                    this.d1(1);
                    this.i1();
                    this.j1();
                    this.k1();
                }
                break;
            case 99:
                if (var2._transitionState == 2)
                {
                    switch (this.b)
                    {
                        case 0:
                            var1.SetCurrentScene((IScene)IngameMenuScene.GetInstance());
                            break;
                        case 1:
                            var1.RoomData.SetEventId(256);
                            var1.SetCurrentScene((IScene)EventScene.GetInstance());
                            break;
                        default:
                            var1.SetCurrentScene((IScene)IngameMenuScene.GetInstance());
                            break;
                    }
                }
                break;
        }

        return true;
    }

    private void c1()
    {
        ++this.H;
        if (this.H > 19)
        {
            this.H = 19;
        }

        int var1 = this.K * 19 + 25;
        int var2 = this.L * 19 + 18;
        this.f[this.H].SetPosition(var1, var2);
        this.g[this.H].SetPosition(var1 - 1, var2 - 1);
        this.g[this.H + 20].SetPosition(var1 + 3, var2 + 3);
        this.g[this.H + 40].SetPosition(var1 - 2, var2 - 2);
        this.g[this.H + 60].SetPosition(var1 + 4, var2 + 4);
    }

    private bool a1(int var1, int var2, int var3)
    {
        bool var4 = false;
        if (this.u[var2][var3] == var1)
        {
            var4 = true;
        }

        return var4;
    }

    private void d1()
    {
        this.h[3].SetPosition(this.ah * 38 + 37, this.ai * 38 + 20 + this.al);
        if (this.V != 1 && this.Y != 1)
        {
            if (this.am > 0)
            {
                this.am = -20;
            }
            else
            {
                this.al = this.am;
                if (this.am < -8)
                {
                    this.al = -8;
                }
            }

            ++this.am;
        }
        else
        {
            this.al = -8;
        }
    }

    private void e1()
    {
        this.h[5].posX = 2 - this.an;
        this.h[6].posX = 230 + this.an;
        if (this.ao)
        {
            ++this.an;
            if (this.an > 3)
            {
                this.ao = !this.ao;
                return;
            }
        }
        else
        {
            --this.an;
            if (this.an < 0)
            {
                this.ao = !this.ao;
            }
        }

    }

    private void b1(bool var1)
    {
        if (var1)
        {
            this.h[10].SetIsVisible(true);
            this.h[10].SetPosition(196, 9);
            this.h[9].SetPosition(196, 9);
        }
        else
        {
            this.h[10].SetIsVisible(false);
            this.h[10].SetPosition(194, 7);
            this.h[9].SetPosition(194, 7);
        }
    }

    private void c1(bool var1)
    {
        if (var1)
        {
            ((ImageResource)this.i[1]).SetIsVisible(true);
            this.i[0].SetPosition(7, 7);
            this.i[1].SetPosition(7, 7);
        }
        else
        {
            ((ImageResource)this.i[1]).SetIsVisible(false);
            this.i[0].SetPosition(5, 5);
            this.i[1].SetPosition(5, 5);
        }
    }

    private void a1(int var1, bool var2)
    {
        int[][] var3 = new int[][] { new[]{ 41, 103 }, new[] { 131, 103 } };
        byte var4 = 0;
        if (var1 == 1)
        {
            var4 = 2;
        }

        if (var2)
        {
            this.i[5 + var4].SetPosition(var3[var1][0] + 2, var3[var1][1] + 2);
            this.i[6 + var4].SetPosition(var3[var1][0] + 2, var3[var1][1] + 2);
        }
        else
        {
            this.i[5 + var4].SetPosition(var3[var1][0], var3[var1][1]);
            this.i[6 + var4].SetPosition(var3[var1][0], var3[var1][1]);
        }
    }

    private void d1(bool var1)
    {
        if (var1)
        {
            this.ab = true;
            this.h[13].SetPosition(168, 174);
            this.h[14].SetPosition(168, 174);
        }
        else
        {
            this.ab = false;
            this.h[13].SetPosition(166, 172);
            this.h[14].SetPosition(166, 172);
        }
    }

    private bool d1(GameContext var1)
    {
        bool var2 = true;
        ++this.@as;
        if (this.@as < 8)
        {
            this.h[3].SetIsVisible(false);
            var1.ScreenResource.SetPosition(0 + this.@as % 2, 0 + this.@as % 2);
        }
        else
        {
            var1.ScreenResource.SetPosition(0, 0);
            this.@as = 0;
            var2 = false;
            this.d1(1);
            this.d1();
            this.h[11].SetIsVisible(false);
            this.h[30].SetIsVisible(false);
            ((ImageResource)this.h[11]).SetScale(0.0F);
            this.h[3].SetIsVisible(true);
            this.f1(true);
        }

        return var2;
    }

    private void f1()
    {
        this.aa = false;
    }

    private bool g1()
    {
        ++this.@as;
        if (this.@as < 8)
        {
            this.c1(1);
            this.h[3].SetIsVisible(false);
            this.h[4].SetIsVisible(true);
            this.b1(true);
            this.ae = true;
            return false;
        }
        else
        {
            this.c1(0);
            this.@as = 0;
            this.h[3].SetIsVisible(true);
            this.h[4].SetIsVisible(false);
            this.b1(false);
            this.ap = false;
            this.ae = false;
            return true;
        }
    }

    private void h1()
    {
        if (this.g1())
        {
            this.a1(2, 2);
            this.d1();
            this.b1(false);
            this.Y = 0;
            this.h[11].SetIsVisible(false);
            this.h[30].SetIsVisible(false);
            ((ImageResource)this.h[11]).SetScale(0.0F);
            this.f1(true);
            this.aq = false;
            this.d1(1);
        }
        else
        {
            this.h[11].SetIsVisible(false);
            this.h[30].SetIsVisible(false);
        }
    }

    private void e1(int var1)
    {
        int var2 = (this.ah * 2 + 1) * 19 + 9;
        int var3 = (this.ai * 2 + 1) * 19 - 3;
        int[][] var4 = new int[][] { new[]{ 0, 0 }, new[] { 3, 0 }, new[] { 3, -3 }, new[] { 3, -3 }, new[] { 3, 0 } };
        if (var1 < 5)
        {
            this.h[12].SetPosition(var2 + var4[var1][0], var3 + var4[var1][1]);
        }
        else
        {
            this.h[12].SetPosition(var2, var3);
        }

        this.h[12].SetIsVisible(true);
    }

    private void a1(GameContext var1, bool var2)
    {
        int var3;
        for (var3 = 0; var3 < this.j.Length; ++var3)
        {
            this.j[var3].SetIsVisible(false);
        }

        for (var3 = 0; var3 < this.k.Length; ++var3)
        {
            this.k[var3].SetIsVisible(false);
        }

        for (var3 = 0; var3 < this.l.Length; ++var3)
        {
            this.l[var3].SetIsVisible(false);
        }

        for (var3 = 0; var3 < this.m.Length; ++var3)
        {
            this.m[var3].SetIsVisible(false);
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
            for (var11 = 0; var11 < this.o.Length; ++var11)
            {
                if ((var12 = var1.SaveData.n1(var11)) != 0)
                {
                    this.o[var11].SetPosition(var12 % 11 * 19 + 9, var12 / 11 * 19 + 1);
                    this.o[var11].SetIsVisible(true);
                }
            }

            for (var11 = 0; var11 < 9; ++var11)
            {
                for (var12 = 0; var12 < 11; ++var12)
                {
                    int var9 = var12 * 19 + 9;
                    int var10 = var11 * 19 + 1;
                    if (this.a1(3, var11, var12))
                    {
                        this.j[var3].SetPosition(var9 + 5, var10 + 5);
                        this.j[var3].SetIsVisible(true);
                        ++var3;
                    }
                    else if (this.a1(4, var11, var12))
                    {
                        this.k[var4].SetPosition(var9, var10);
                        this.k[var4].SetIsVisible(true);
                        ++var4;
                    }
                    else if (this.a1(5, var11, var12))
                    {
                        this.l[var5].SetPosition(var9 + 4, var10);
                        this.l[var5].SetIsVisible(true);
                        ++var5;
                    }
                    else if (this.a1(6, var11, var12))
                    {
                        this.m[var6].SetPosition(var9 - 1, var10 + 5);
                        this.m[var6].SetIsVisible(true);
                        ++var6;
                    }
                    else if (this.a1(7, var11, var12))
                    {
                        this.n[var7].SetPosition(var9, var10);
                        this.n[var7].SetIsVisible(true);
                        ++var7;
                    }
                    else if (this.a1(2, var11, var12))
                    {
                        this.h[1].SetPosition(var9, var10 + 6);
                    }
                    else if (this.a1(9, var11, var12))
                    {
                        if (var12 % 2 == 1)
                        {
                            ((ImageResource)this.p[var8]).SetFlipMode(5);
                            this.p[var8].SetPosition(var9, var10 + 14);
                        }
                        else
                        {
                            ((ImageResource)this.p[var8]).SetFlipMode(0);
                            this.p[var8].SetPosition(var9 + 14, var10);
                        }

                        this.p[var8].SetIsVisible(true);
                        ++var8;
                    }
                }
            }
        }

    }

    private void a1(int var1, int var2, int var3, int var4)
    {
        this.x = var1;
        this.y = var2;
        this.v = var3;
        this.w = var4;
    }

    private void f1(int var1)
    {
        Image[] var2 = new Image[] { null, this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_yuka.gif") };
        int[] var3 = new int[] { 0, 1, 5, 6, 0, 0 };
        ((ImageResource)this.h[12]).SetImage(var2[var1]);
        ((ImageResource)this.h[12]).SetFlipMode(var3[var1]);
    }

    private void i1()
    {
        for (int var1 = 0; var1 < this.q.Length; ++var1)
        {
            this.q[var1].SetIsVisible(false);
        }

    }

    private void g1(int var1)
    {
        for (int var2 = 0; var2 < this.q.Length; ++var2)
        {
            if (var1 == 0)
            {
                this.q[var2].a1(this.q[var2].posX + 48, this.q[var2].posY, 5);
            }
            else if (var1 == 1)
            {
                this.q[var2].a1(this.q[var2].posX - 48, this.q[var2].posY, 5);
            }
        }

    }

    private void j1()
    {
        Image[] var1 = new Image[] { null, this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_kagami.gif"), this.D.GetLoadedImage("p_yuka.gif"), this.D.GetLoadedImage("p_hammer.gif") };
        int[] var2 = new int[] { 0, 1, 5, 6, 0, 0, 0 };
        int var3 = 0;

        for (int var4 = 0; var4 < this.s.Length; ++var4)
        {
            if (this.s[var4] != 0)
            {
                ((ImageResource)this.q[var4]).SetImage(var1[this.s[var4]]);
                ((ImageResource)this.q[var4]).SetFlipMode(var2[this.s[var4]]);
                this.q[var4].SetIsVisible(true);
                ++var3;
            }
        }

        if (var3 != 3 && var3 != 2)
        {
            if (var3 != 1 && var3 != 0)
            {
                this.Z = 0;
            }
            else
            {
                this.Z = 96;
            }
        }
        else
        {
            this.Z = 48;
        }
    }

    private void k1()
    {
        for (int var1 = 0; var1 < this.q.Length; ++var1)
        {
            this.q[var1].posX = var1 * 48 + 5 + this.Z;
        }

        this.l1();
    }

    private void l1()
    {
        if (this.s.Length < 5)
        {
            this.h[5].SetIsVisible(false);
            this.h[6].SetIsVisible(false);
        }

        if (this.X > 0)
        {
            this.h[5].SetIsVisible(true);
        }
        else
        {
            this.h[5].SetIsVisible(false);
        }

        if (this.s.Length - (this.X + 4) > 1)
        {
            this.h[6].SetIsVisible(true);
        }
        else
        {
            this.h[6].SetIsVisible(false);
        }
    }

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
                if (this.a1(3, var8, var9))
                {
                    ++var1;
                }
                else if (this.a1(4, var8, var9))
                {
                    ++var2;
                }
                else if (this.a1(5, var8, var9))
                {
                    ++var3;
                }
                else if (this.a1(6, var8, var9))
                {
                    ++var4;
                }
            }
        }

        for (var8 = 0; var8 < this.r.Length; ++var8)
        {
            if (this.r[var8] == 1)
            {
                ++var1;
            }

            if (this.r[var8] == 2)
            {
                ++var2;
            }

            if (this.r[var8] == 3)
            {
                ++var3;
            }

            if (this.r[var8] == 4)
            {
                ++var4;
            }
        }

        this.j = new ResourceBase[var1];
        this.k = new ResourceBase[var2];
        this.l = new ResourceBase[var3];
        this.m = new ResourceBase[var4];
        this.n = new ResourceBase[20];
        this.o = new ResourceBase[20];
        this.p = new ResourceBase[20];
    }

    private void e1(GameContext var1)
    {
        this.r = new int[20];

        int var2;
        for (var2 = 0; var2 < this.r.Length; ++var2)
        {
            this.r[var2] = 0;
        }

        var2 = 0;

        int var3;
        for (var3 = 0; var3 < 20; ++var3)
        {
            this.r[var3] = var1.SaveData.l1(var3);
            if (this.r[var3] != 0)
            {
                ++var2;
            }
        }

        this.s = new int[var2];
        var2 = 0;

        for (var3 = 0; var3 < this.r.Length; ++var3)
        {
            if (this.r[var3] != 0)
            {
                this.s[var2] = this.r[var3];
                ++var2;
            }
        }

    }

    public void Reset(GameContext var1)
    {
        int var2;
        for (var2 = 0; var2 < 20; ++var2)
        {
            var1.SaveData.j1(var2, 0);
        }

        for (var2 = 0; var2 < this.r.Length; ++var2)
        {
            var1.SaveData.j1(var2, this.r[var2]);
        }

        for (var2 = 0; var2 < 9; ++var2)
        {
            for (int var3 = 0; var3 < 11; ++var3)
            {
                var1.SaveData.a1(var2, var3, this.u[var2][var3]);
            }
        }

        if (this.t != 3)
        {
            var1.SaveData.j1(2);
        }
        else
        {
            var1.SaveData.j1(3);
            var1.SaveData.q1(3);
        }

        for (var2 = 0; var2 < this.q.Length; ++var2)
        {
            if (this.q[var2] != null)
            {
                this.q[var2].f1();
                this.q[var2] = null;
            }
        }

        for (var2 = 0; var2 < 20; ++var2)
        {
            if (this.p[var2] != null)
            {
                this.p[var2].f1();
                this.p[var2] = null;
            }

            if (this.o[var2] != null)
            {
                this.o[var2].f1();
                this.o[var2] = null;
            }

            if (this.n[var2] != null)
            {
                this.n[var2].f1();
                this.n[var2] = null;
            }
        }

        for (var2 = 0; var2 < this.m.Length; ++var2)
        {
            if (this.m[var2] != null)
            {
                this.m[var2].f1();
                this.m[var2] = null;
            }
        }

        for (var2 = 0; var2 < this.l.Length; ++var2)
        {
            if (this.l[var2] != null)
            {
                this.l[var2].f1();
                this.l[var2] = null;
            }
        }

        for (var2 = 0; var2 < this.k.Length; ++var2)
        {
            if (this.k[var2] != null)
            {
                this.k[var2].f1();
                this.k[var2] = null;
            }
        }

        for (var2 = 0; var2 < this.j.Length; ++var2)
        {
            if (this.j[var2] != null)
            {
                this.j[var2].f1();
                this.j[var2] = null;
            }
        }

        for (var2 = 0; var2 < this.i.Length; ++var2)
        {
            if (this.i[var2] != null)
            {
                this.i[var2].f1();
                this.i[var2] = null;
            }
        }

        for (var2 = 0; var2 < 20; ++var2)
        {
            if (this.f[var2] != null)
            {
                this.f[var2].f1();
                this.f[var2] = null;
            }
        }

        for (var2 = 0; var2 < 80; ++var2)
        {
            if (this.g[var2] != null)
            {
                this.g[var2].f1();
                this.g[var2] = null;
            }
        }

        for (var2 = 0; var2 < 31; ++var2)
        {
            if (this.h[var2] != null)
            {
                this.h[var2].f1();
                this.h[var2] = null;
            }
        }

        for (var2 = 0; var2 < 3; ++var2)
        {
            if (this.e[var2] != null)
            {
                this.e[var2].f1();
                this.e[var2] = null;
            }
        }

        try
        {
            this.D.Reset();
        }
        catch (Exception var4)
        {
        }

        this.s = null;
        this.C = "";
    }

    private void a1(GameContext var1, JavaString var2, int var3)
    {
        this.aw = new int[9][];
        for (var i = 0; i < aw.Length; i++) aw[i] = new int[11];
        bool var4 = false;
        bool var5 = false;
        int var6 = 0;
        StringBuilder var7 = new StringBuilder(var2);

        while (!var7.ToString().Trim().Equals(""))
        {
            int var12;
            int var13;
            switch (var7.ToString().Trim()[0])
            {
                case '#':
                    var13 = var7.ToString().IndexOf("\n");
                    var7.Remove(0, var13 + 1);
                    break;
                case '文':
                    var12 = var7.ToString().IndexOf("=") + 1;
                    var13 = var7.ToString().IndexOf("\n", var12);
                    this.U = var7.ToString().Substring(var12, var13).Trim();
                    var7.Remove(0, var13 + 1);
                    break;
                case '方':
                    var12 = var7.ToString().IndexOf("=") + 1;
                    var13 = var7.ToString().IndexOf("\n", var12);
                    if (var3 == 0)
                    {
                        this.J = int.Parse(var7.ToString().Substring(var12, var13).Trim());
                        this.I = this.J;
                    }

                    var7.Remove(0, var13 + 1);
                    break;
                default:
                    var13 = var7.ToString().IndexOf(",");
                    JavaString var9 = var7.ToString().Substring(0, var13);
                    if (var3 == 0)
                    {
                        this.aw[var6 / 11][var6 % 11] = int.Parse(var9.Trim());
                        if (this.aw[var6 / 11][var6 % 11] == 1)
                        {
                            this.M = var6 % 11;
                            this.N = var6 / 11;
                            this.K = this.M;
                            this.L = this.N;
                        }

                        ++var6;
                    }

                    var7.Remove(0, var13 + 1);
                    break;
            }
        }

        int var8;
        int var14;
        if (var1.SaveData.h1() == 1)
        {
            this.u = this.aw;

            for (var8 = 0; var8 < 4; ++var8)
            {
                for (var14 = 0; var14 < 5; ++var14)
                {
                    if (this.u[var8 * 2 + 1][var14 * 2 + 1] == 8)
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
                    this.u[var8][var14] = var1.SaveData.i1(var8, var14);
                }
            }
        }

    }

    private void h1(int var1)
    {
        int[] var2 = new int[] { 32, 122 };
        this.h[7].posX = var2[var1];
        if (var1 == 0)
        {
            this.i[6].SetIsVisible(true);
            this.i[8].SetIsVisible(false);
        }
        else
        {
            this.i[6].SetIsVisible(false);
            this.i[8].SetIsVisible(true);
        }
    }

    private void n1()
    {
        for (int var1 = 0; var1 < this.H + 1; ++var1)
        {
            this.g[var1 + 40].SetIsVisible(this.ax);
            this.g[var1 + 60].SetIsVisible(this.ax);
            this.g[var1].SetIsVisible(this.af);
            this.g[var1 + 20].SetIsVisible(this.af);
        }

        ++this.az;
        if (this.az > 4)
        {
            this.az = 0;
            this.ax = true;
        }
        else
        {
            this.ax = false;
        }

        ++this.ay;
        if (this.ay > 3)
        {
            this.ay = -1;
            this.af = false;
        }
        else
        {
            this.af = true;
        }
    }

    private void i1(int var1)
    {
        for (int var2 = 0; var2 < this.r.Length; ++var2)
        {
            if (this.r[var2] == 0)
            {
                this.r[var2] = var1;
                return;
            }
        }

    }

    private void j1(int var1)
    {
        this.r = this.s;
        int var2 = 0;

        int var3;
        for (var3 = 0; var3 < this.r.Length; ++var3)
        {
            if (this.s[var3] != 0)
            {
                ++var2;
            }
        }

        this.s = new int[var2 + 1];
        var3 = 0;

        for (int var4 = 0; var4 < this.r.Length; ++var4)
        {
            if (this.r[var4] != 0)
            {
                this.s[var3] = this.r[var4];
                ++var3;
            }
        }

        this.s[var2] = var1;
        this.r = this.s;
    }

    private int c1(int var1, int var2)
    {
        int var3 = 0;

        for (int var4 = 0; var4 < 9; ++var4)
        {
            for (int var5 = 0; var5 < 11; ++var5)
            {
                if (this.u[var4][var5] == 9)
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

    private void a1(int var1, int var2, bool var3)
    {
        this.z = this.c1(var1, var2);
        if (this.z >= 0)
        {
            ++this.B;
            if (this.B < 10)
            {
                this.p[this.z].SetIsVisible(true);
            }
            else if (this.B < 20)
            {
                this.p[this.z].SetIsVisible(false);
            }
            else
            {
                this.B = 0;
            }

            if (!var3)
            {
                this.p[this.z].SetIsVisible(true);
            }

            if (this.A != this.z)
            {
                if (this.A >= 0)
                {
                    this.p[this.A].SetIsVisible(true);
                }

                this.A = this.z;
                this.B = 0;
                if (!var3)
                {
                    this.p[this.A].SetIsVisible(true);
                    return;
                }
            }
        }
        else
        {
            if (this.A >= 0)
            {
                this.p[this.A].SetIsVisible(true);
            }

            this.A = -1;
            this.B = 0;
        }

    }

    private void e1(bool var1)
    {
        if (var1)
        {
            this.aa = false;
            this.h[3].SetIsVisible(false);
            this.h[14].SetIsVisible(true);
            this.h[18].SetIsVisible(true);
            this.h[4].SetIsVisible(false);
            this.h[10].SetIsVisible(false);
            this.h[8].SetIsVisible(false);
            this.i[1].SetIsVisible(false);
            this.h[25].SetIsVisible(false);
        }
        else
        {
            this.h[14].SetIsVisible(false);
            this.h[18].SetIsVisible(false);
        }
    }

    private void f1(bool var1)
    {
        this.i[0].SetIsVisible(var1);
        if (this.t == 3)
        {
            this.h[13].SetIsVisible(var1);
        }

        this.h[4].SetIsVisible(var1);
    }

    private void o1()
    {
        bool var1 = false;
        sbyte var2 = -1;
        sbyte var3 = -1;
        if (!this.ac)
        {
            if (this.I == 0)
            {
                this.L += -1;
                if (this.a1(9, this.L, this.K))
                {
                    ++this.L;
                    var3 = 7;
                }
                else if (!this.a1(10, this.L, this.K) && !this.a1(11, this.L, this.K))
                {
                    if (!this.a1(3, this.L, this.K) && !this.a1(6, this.L, this.K))
                    {
                        if (this.a1(4, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 1;
                        }
                        else if (this.a1(5, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 3;
                        }
                        else if (this.L < 1)
                        {
                            this.L = 1;
                        }
                    }
                    else
                    {
                        ++this.L;
                        var3 = 11;
                    }
                }
                else
                {
                    ++this.L;
                    var3 = 0;
                }
            }
            else if (this.I == 2)
            {
                ++this.L;
                if (this.a1(9, this.L, this.K))
                {
                    this.L += -1;
                    var3 = 5;
                }
                else if (!this.a1(10, this.L, this.K) && !this.a1(11, this.L, this.K))
                {
                    if (!this.a1(4, this.L, this.K) && !this.a1(5, this.L, this.K))
                    {
                        if (this.a1(3, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 3;
                        }
                        else if (this.a1(6, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 1;
                        }
                        else if (this.L > 8)
                        {
                            this.L = 8;
                        }
                    }
                    else
                    {
                        this.L += -1;
                        var3 = 9;
                    }
                }
                else
                {
                    this.L += -1;
                    var3 = 2;
                }
            }
            else if (this.I == 3)
            {
                this.K += -1;
                if (this.a1(9, this.L, this.K))
                {
                    var3 = 6;
                }

                if (!this.a1(10, this.L, this.K) && !this.a1(11, this.L, this.K))
                {
                    if (!this.a1(3, this.L, this.K) && !this.a1(5, this.L, this.K))
                    {
                        if (this.a1(4, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 2;
                        }
                        else if (this.a1(6, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 0;
                        }
                        else if (this.K < 1)
                        {
                            this.K = 1;
                        }
                    }
                    else
                    {
                        var3 = 10;
                    }
                }
                else
                {
                    ++this.K;
                    var3 = 3;
                }
            }
            else if (this.I == 1)
            {
                ++this.K;
                if (this.a1(9, this.L, this.K))
                {
                    var3 = 4;
                }

                if (!this.a1(10, this.L, this.K) && !this.a1(11, this.L, this.K))
                {
                    if (!this.a1(4, this.L, this.K) && !this.a1(6, this.L, this.K))
                    {
                        if (this.a1(3, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 0;
                        }
                        else if (this.a1(5, this.L, this.K))
                        {
                            var1 = true;
                            var2 = 2;
                        }
                        else if (this.K > 10)
                        {
                            this.K = 10;
                        }
                    }
                    else
                    {
                        var3 = 8;
                    }
                }
                else
                {
                    this.K += -1;
                    var3 = 1;
                }
            }
        }

        if (this.a1(2, this.L, this.K))
        {
            this.ac = true;
            this.h[2].SetIsVisible(true);
        }
        else
        {
            this.h[2].SetIsVisible(false);
        }

        int var14 = this.f[this.H - 1].posX;
        int var15 = this.f[this.H - 1].posY;
        int var16 = this.g[this.H - 1].posX;
        int var17 = this.g[this.H - 1].posY;
        int var18 = this.g[this.H - 1 + 20].posX;
        int var19 = this.g[this.H - 1 + 20].posY;
        int var20 = this.g[this.H - 1 + 40].posX;
        int var21 = this.g[this.H - 1 + 40].posY;
        int var22 = this.g[this.H - 1 + 60].posX;
        int var23 = this.g[this.H - 1 + 60].posY;
        int var12;
        int var13;
        if (var3 != -1)
        {
            if (var3 == 4 || var3 == 8)
            {
                --this.K;
            }

            if (var3 == 6 || var3 == 10)
            {
                ++this.K;
            }

            var12 = this.K * 19 + 25;
            var13 = this.L * 19 + 18;
            if (this.I == 0)
            {
                this.f[this.H].posY = var15 - (var15 - var13 + this.aA[var3][1]) + 2;
                this.f[this.H].SetSize(3, var15 - var13 + this.aA[var3][1]);
                this.g[this.H].posY = var17 - (var17 - var13 + this.aA[var3][1]) + 2;
                this.g[this.H + 20].posY = var19 - (var19 - var13 + this.aA[var3][1]) + 2;
                this.g[this.H + 40].posY = var21 - (var21 - var13 + this.aA[var3][1]) + 2;
                this.g[this.H + 60].posY = var23 - (var23 - var13 + this.aA[var3][1]) + 2;
                this.g[this.H].SetSize(1, var17 - var13 + this.aA[var3][1]);
                this.g[this.H + 20].SetSize(1, var19 - var13 + this.aA[var3][1]);
                this.g[this.H + 40].SetSize(1, var21 - var13 + this.aA[var3][1]);
                this.g[this.H + 60].SetSize(1, var23 - var13 + this.aA[var3][1]);
            }
            else if (this.I == 2)
            {
                this.f[this.H].SetSize(3, var13 - var15 + this.aA[var3][1]);
                this.g[this.H].SetSize(1, var13 - var17 + this.aA[var3][1]);
                this.g[this.H + 20].SetSize(1, var13 - var19 + this.aA[var3][1]);
                this.g[this.H + 40].SetSize(1, var13 - var21 + this.aA[var3][1]);
                this.g[this.H + 60].SetSize(1, var13 - var23 + this.aA[var3][1]);
            }
            else if (this.I == 3)
            {
                this.f[this.H].posX = var14 - (var14 - var12 + this.aA[var3][0]) + 5;
                this.f[this.H].SetSize(var14 - var12 + this.aA[var3][0], 3);
                this.g[this.H].posX = var16 - (var16 - var12 + this.aA[var3][0]) + 5;
                this.g[this.H + 20].posX = var18 - (var18 - var12 + this.aA[var3][0]) + 5;
                this.g[this.H + 40].posX = var20 - (var20 - var12 + this.aA[var3][0]) + 5;
                this.g[this.H + 60].posX = var22 - (var22 - var12 + this.aA[var3][0]) + 5;
                this.g[this.H].SetSize(var16 - var12 + this.aA[var3][0], 1);
                this.g[this.H + 20].SetSize(var18 - var12 + this.aA[var3][0], 1);
                this.g[this.H + 40].SetSize(var20 - var12 + this.aA[var3][0], 1);
                this.g[this.H + 60].SetSize(var22 - var12 + this.aA[var3][0], 1);
            }
            else if (this.I == 1)
            {
                this.f[this.H].SetSize(var12 - var14 + this.aA[var3][0], 3);
                this.g[this.H].SetSize(var12 - var16 + this.aA[var3][0], 1);
                this.g[this.H + 20].SetSize(var12 - var18 + this.aA[var3][0], 1);
                this.g[this.H + 40].SetSize(var12 - var20 + this.aA[var3][0], 1);
                this.g[this.H + 60].SetSize(var12 - var22 + this.aA[var3][0], 1);
            }
        }
        else
        {
            var12 = this.K * 19 + 25;
            var13 = this.L * 19 + 18;
            if (this.I == 0)
            {
                this.f[this.H].posY = var15 - (var15 - var13) + 3;
                this.f[this.H].SetSize(3, var15 - var13 - 1);
                this.g[this.H].posY = var17 - (var17 - var13) + 3;
                this.g[this.H + 20].posY = var19 - (var19 - var13) + 3;
                this.g[this.H + 40].posY = var21 - (var21 - var13) + 3;
                this.g[this.H + 60].posY = var23 - (var23 - var13) + 3;
                this.g[this.H].SetSize(1, var17 - var13 - 1);
                this.g[this.H + 20].SetSize(1, var19 - var13 - 1);
                this.g[this.H + 40].SetSize(1, var21 - var13 - 1);
                this.g[this.H + 60].SetSize(1, var23 - var13 - 1);
            }
            else if (this.I == 2)
            {
                this.f[this.H].SetSize(3, var13 - var15);
                this.g[this.H].SetSize(1, var13 - var17);
                this.g[this.H + 20].SetSize(1, var13 - var19);
                this.g[this.H + 40].SetSize(1, var13 - var21);
                this.g[this.H + 60].SetSize(1, var13 - var23);
            }
            else if (this.I == 3)
            {
                this.f[this.H].posX = var14 - (var14 - var12) + 3;
                this.f[this.H].SetSize(var14 - var12 + 2, 3);
                this.g[this.H].posX = var16 - (var16 - var12) + 3;
                this.g[this.H + 20].posX = var18 - (var18 - var12) + 3;
                this.g[this.H + 40].posX = var20 - (var20 - var12) + 3;
                this.g[this.H + 60].posX = var22 - (var22 - var12) + 3;
                this.g[this.H].SetSize(var16 - var12 + 2, 1);
                this.g[this.H + 20].SetSize(var18 - var12 + 2, 1);
                this.g[this.H + 40].SetSize(var20 - var12 + 2, 1);
                this.g[this.H + 60].SetSize(var22 - var12 + 2, 1);
            }
            else if (this.I == 1)
            {
                this.f[this.H].SetSize(var12 - var14, 3);
                this.g[this.H].SetSize(var12 - var16, 1);
                this.g[this.H + 20].SetSize(var12 - var18, 1);
                this.g[this.H + 40].SetSize(var12 - var20, 1);
                this.g[this.H + 60].SetSize(var12 - var22, 1);
            }
        }

        this.f[this.H].SetIsVisible(true);
        this.g[this.H].SetIsVisible(true);
        this.g[this.H + 20].SetIsVisible(true);
        this.g[this.H + 40].SetIsVisible(true);
        this.g[this.H + 60].SetIsVisible(true);
        this.d1();
        this.n1();
        if (this.aa)
        {
            this.h[3].SetIsVisible(false);
            if (this.aj == 0)
            {
                this.h[8].SetIsVisible(true);
                this.h[4].SetIsVisible(false);
                this.i[1].SetIsVisible(true);
                this.h[10].SetIsVisible(false);
            }
            else
            {
                this.h[8].SetIsVisible(false);
                this.h[4].SetIsVisible(true);
                this.i[1].SetIsVisible(false);
                this.h[10].SetIsVisible(true);
            }
        }
        else
        {
            this.h[3].SetIsVisible(true);
            this.h[8].SetIsVisible(false);
            this.i[1].SetIsVisible(false);
            this.h[4].SetIsVisible(false);
            this.h[10].SetIsVisible(false);
        }

        if (this.a == 2)
        {
            this.c1(0);
            this.h[3].SetIsVisible(false);
        }

        this.e1(this.ab);
        if (var1)
        {
            this.c1();
            if (var2 > -1)
            {
                this.I = var2;
            }
        }

        //System.gc();
    }

    private void p1()
    {
        this.aa = true;
        this.c1(0);
        this.a1(0, 0);
        this.c1(true);
        this.i[9].SetIsVisible(true);
        this.d1(3);
    }

    private void a1(ScreenResource var1)
    {
        this.h[25].SetIsVisible(false);
        this.d1(5);
        var1.ExecuteTransition(0);
        this.d1(true);
    }

    private void q1()
    {
        this.W = 2;
        this.X = 0;
        this.h[24].SetPosition(this.ag[this.W], this.h[24].posY);
        this.h[25].SetIsVisible(false);
    }

    private void k1(int var1)
    {
        switch (this.s.Length)
        {
            case 0:
            case 1:
                this.W = 2;
                break;
            case 2:
                if (0 < var1 && var1 < 3)
                {
                    this.W = var1;
                }
                else
                {
                    this.W = 2;
                }
                break;
            case 3:
                if (0 < var1 && var1 < 4)
                {
                    this.W = var1;
                }
                else
                {
                    this.W = 2;
                }
                break;
            case 4:
                if (var1 < 4)
                {
                    this.W = var1;
                }
                else
                {
                    this.W = 2;
                }
                break;
            case 5:
                this.W = var1;
                break;
            default:
                this.W = var1;
                break;
        }

        this.h[24].a1(this.ag[this.W], this.h[24].posY, 1);
    }
}
