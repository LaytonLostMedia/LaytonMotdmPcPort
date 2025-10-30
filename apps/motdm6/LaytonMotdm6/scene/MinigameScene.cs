using System.Text;
using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm6.c;
using LaytonMotdm6.c.Managers;
using LaytonMotdm6.c.Resources;

namespace LaytonMotdm6.scene;

[ClassName("scene", "a")]
public class MinigameScene : IScene
{
    private int a;
    private int b;
    private MiniGameInternal[] c;
    private GameFileManager d;
    private ResourceBase[] e = new ResourceBase[64];
    private int f;
    private int g;
    private int h;
    private bool i;
    private int j;
    private int k;
    private int l;
    private int m;
    private int n;
    private int o;
    private int p;
    private int q;
    private int r;
    private int s;
    private int t;
    private int u;
    private int v;
    private bool w = false;
    private JavaString x = "[初期ハンマー]:0\n[初期鞘]      :0\n[初期マシン]  :0\n# ブロックの数と種類,x座標\n# 1:武器の束\n# 2:小麦粉の袋\n# 3:本\n# 4:鞘+武器の束\n# 5:本(赤)\n# 6:本(青)\n[段数]: 10\n[10]  : 1, 100\n[9]   : 1, 100\n[8]   : 1, 100\n[7]   : 1,  90\n[6]   : 3, 100\n[5]   : 2, 110\n[4]   : 6, 100\n[3]   : 3,  90\n[2]   : 5, 100\n[1]   : 1, 100\n#日記のX座標\n[日記]:105\n#日記内容\n[MSG]:日記内容[end]\n[最短]:3\n[SCORE]:1000\n";
    private static MinigameScene y = new MinigameScene();
    private int z;
    private int A;
    private int B;
    private Dictionary<JavaString, JavaString> C = new();
    private bool D;
    private bool E = false;
    private int F = 0;
    private bool G = false;
    private bool H = false;
    private int I = 0;
    private int J;
    private int K = 0;
    private int L = 0;
    private int M = 0;
    private int N = 0;
    private int O = 0;
    private int P = 0;
    private int Q = 0;
    private int R = 0;
    private int S = 0;
    private int T = 0;
    private int U = 0;
    private int V = 0;
    private int W = 0;
    private bool X = false;
    private int Y = 0;
    private int Z = 0;
    private int aa = 1;
    private int ab = 2;
    private int ac = 3;
    private int ad;

    private MinigameScene()
    {
    }

    public static MinigameScene GetInstance()
    {
        return y;
    }

    private void a1(int var1)
    {
        this.z = this.a;
        this.a = var1;
        switch (var1)
        {
            case 1:
                this.j1(0);
                return;
            case 6:
                this.j1(2);
                this.i1(2);
                break;
            default:
                return;
            case 7:
                this.j1(1);
                this.i1(1);
                break;
        }
    }

    public void Setup(GameContext var1)
    {
        ScreenResource var2 = var1.ScreenResource;
        this.d = new GameFileManager();
        this.r = 0;
        this.k = 0;
        this.s = this.k;
        this.K = 0;
        this.t = 0;
        this.j = 0;
        this.h = 0;
        this.i = false;
        var1.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        JavaString[] var4 = new JavaString[] { "bg_monooki2.gif", "swords.gif", "ibag.gif", "book.gif", "jeni_diary.gif", "btn_jennifer.gif", "bg_hanyou.jpg", "tuto3.gif", "tuto4.gif", "tuto5.gif", "btn_reset.gif", "swords_saya.gif", "saya.gif", "machine.gif", "minigame.dat", "font7.gif", "mg_icon1.gif", "mg_icon2.gif", "mg_icon3.gif", "mg_failed.gif", "book2.gif", "book3.gif", "lift.gif", "mg_layton1.gif", "mg_layton2.gif", "mg_luke1.gif", "mg_luke2.gif", "mg_luke3.gif", "mg_luke4.gif", "mg_luke5.gif", "mg_luke6.gif", "mg_font2.gif", "mg_font.gif", "mg_menu.gif", "mg_commo0.gif", "font_jennifer.gif", "mg_howplay.gif", "bg_005.mld", "se_mg01.mld", "se_mg02.mld", "se_mg03.mld" };
        if (this.d.LoadFiles(var4))
        {
            this.v = var1.SaveData.x1();
            this.x = new JavaString(this.d.GetLoadedData("minigame.dat"));
            this.a1(this.x);
            this.p = int.Parse(this.C["[最短]"]);
            this.q = 0;
            this.e[0] = ImageResource.Create(this.d.GetLoadedImage("bg_monooki2.gif"));
            var2.AddChild(this.e[0]);
            this.e[46] = ImageResource.Create(this.d.GetLoadedImage("mg_luke1.gif"));
            this.e[0].AddChild(this.e[46]);
            int[] var7 = new int[] { 0, 1, 2, 3, 3 };
            ((ImageResource)this.e[46]).a1(0, 0, this.e[46].GetWidth() / 4, this.e[46].GetHeight(), var7);
            ((ImageResource)this.e[46]).b1(0, 3);
            this.e[50] = ImageResource.Create(this.d.GetLoadedImage("mg_luke5.gif"));
            this.e[0].AddChild(this.e[50]);
            this.e[50].SetIsVisible(false);
            int[] var8 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            ((ImageResource)this.e[50]).a1(0, 0, this.e[50].GetWidth() / 6, this.e[50].GetHeight() / 2, var8);
            ((ImageResource)this.e[50]).b1(0, 1);
            this.e[51] = ImageResource.Create(this.d.GetLoadedImage("mg_luke6.gif"));
            this.e[0].AddChild(this.e[51]);
            this.e[51].SetIsVisible(false);
            ((ImageResource)this.e[51]).a1(0, 0, this.e[51].GetWidth() / 6, this.e[51].GetHeight() / 2, var8);
            ((ImageResource)this.e[51]).b1(0, 1);
            this.e[47] = ImageResource.Create(this.d.GetLoadedImage("mg_luke2.gif"));
            this.e[0].AddChild(this.e[47]);
            ((ImageResource)this.e[47]).a1(0, 0, this.e[47].GetWidth() / 4, this.e[47].GetHeight(), var7);
            ((ImageResource)this.e[47]).b1(0, 3);
            this.e[48] = ImageResource.Create(this.d.GetLoadedImage("mg_luke3.gif"));
            this.e[0].AddChild(this.e[48]);
            ((ImageResource)this.e[48]).a1(0, 0, this.e[48].GetWidth() / 4, this.e[48].GetHeight(), var7);
            ((ImageResource)this.e[48]).b1(0, 3);
            this.e[49] = ImageResource.Create(this.d.GetLoadedImage("mg_luke4.gif"));
            this.e[0].AddChild(this.e[49]);
            ((ImageResource)this.e[49]).a1(0, 0, this.e[49].GetWidth() / 4, this.e[49].GetHeight(), var7);
            ((ImageResource)this.e[49]).b1(0, 3);
            this.e[43] = ImageResource.Create(this.d.GetLoadedImage("mg_layton1.gif"));
            ((ImageResource)this.e[43]).b1(0, 0, 29, 30);
            this.e[0].AddChild((ResourceBase)this.e[43], 0, 152);
            this.e[44] = ImageResource.Create(this.d.GetLoadedImage("mg_layton2.gif"));
            ((ImageResource)this.e[44]).b1(0, 0, 29, 30);
            this.e[0].AddChild((ResourceBase)this.e[44], 0, 152);
            this.e[44].SetIsVisible(false);
            this.e[45] = ImageResource.Create(this.d.GetLoadedImage("lift.gif"));
            ((ImageResource)this.e[45]).b1(0, 0, 64, 25);
            this.e[0].AddChild((ResourceBase)this.e[45], 28, 0);
            this.e[1] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            this.e[0].AddChild(this.e[1]);
            ((ImageResource)this.e[1]).SetFlipMode(5);
            this.e[14] = ImageResource.Create((ImageResource)this.e[1]);
            this.e[15] = ImageResource.Create((ImageResource)this.e[1]);
            this.e[0].AddChild(this.e[14]);
            this.e[0].AddChild(this.e[15]);
            ((ImageResource)this.e[14]).SetFlipMode(5);
            ((ImageResource)this.e[15]).SetFlipMode(5);
            int var3 = int.Parse(this.C["[段数]"]);
            this.c = new MiniGameInternal[var3];

            int var9;
            for (var9 = 0; var9 < var3; ++var9)
            {
                this.c[var9] = (new MiniGameInternal(this));

                var9 = 0;
                for (int var10 = 0; var10 < var3; ++var10)
                {
                    if (var1.SaveData.E1() == 0)
                    {
                        this.c[var9].c1(a1(this.C["[" + (var10 + 1) + "]"], 0));
                        this.c[var9].b1(a1(this.C["[" + (var10 + 1) + "]"], 1));
                    }
                    else
                    {
                        this.c[var10].c1(var1.SaveData.t1(var10));
                        this.c[var10].b1(var1.SaveData.s1(var10));
                        if (var1.SaveData.r1(var10) != 0)
                        {
                            this.c[var10].a1(false);
                        }
                        else
                        {
                            this.c[var10].a1(true);
                        }
                    }

                    if (this.c[var10].e1() == 1)
                    {
                        this.c[var10].a1(this.d.GetLoadedImage("swords.gif"));
                    }
                    else if (this.c[var10].e1() == 2)
                    {
                        this.c[var10].a1(this.d.GetLoadedImage("ibag.gif"));
                    }
                    else if (this.c[var10].e1() == 3)
                    {
                        this.c[var10].a1(this.d.GetLoadedImage("book.gif"));
                    }
                    else if (this.c[var10].e1() == 4)
                    {
                        this.c[var10].a1(this.d.GetLoadedImage("swords_saya.gif"));
                    }
                    else if (this.c[var10].e1() == 5)
                    {
                        this.c[var10].a1(this.d.GetLoadedImage("book2.gif"));
                    }
                    else if (this.c[var10].e1() == 6)
                    {
                        this.c[var10].a1(this.d.GetLoadedImage("book3.gif"));
                    }

                    this.c[var10].a1(182 - (var9 + 1) * MiniGameInternal.a1(this.c[var9]).GetHeight());
                    this.e[0].AddChild(MiniGameInternal.a1(this.c[var10]), this.c[var10].d1(), this.c[var10].c1());
                    if (this.c[var10].f1())
                    {
                        ++var9;
                    }
                    else
                    {
                        MiniGameInternal.a1(this.c[var10]).SetIsVisible(this.c[var10].f1());
                        this.c[var10].i1();
                    }
                }
            }

            this.e[26] = ImageResource.Create(this.d.GetLoadedImage("saya.gif"));
            this.e[0].AddChild(this.e[26]);
            this.e[26].SetIsVisible(false);
            this.e[27] = ImageResource.Create(this.d.GetLoadedImage("machine.gif"));
            this.e[0].AddChild((ResourceBase)this.e[27], 20, 100);
            this.e1(false);
            this.e[30] = ImageResource.Create(this.d.GetLoadedImage("mg_icon1.gif"));
            this.e[37] = ImageResource.Create((ImageResource)this.e[30]);
            this.e[31] = ImageResource.Create(this.d.GetLoadedImage("mg_icon2.gif"));
            this.e[38] = ImageResource.Create((ImageResource)this.e[31]);
            this.e[32] = ImageResource.Create(this.d.GetLoadedImage("mg_icon3.gif"));
            this.e[39] = ImageResource.Create((ImageResource)this.e[32]);
            ((ImageResource)this.e[30]).ClipRect(0, 0, 30, 30);
            ((ImageResource)this.e[37]).ClipRect(30, 0, 30, 30);
            ((ImageResource)this.e[31]).ClipRect(0, 0, 30, 30);
            ((ImageResource)this.e[38]).ClipRect(30, 0, 30, 30);
            ((ImageResource)this.e[32]).ClipRect(0, 0, 30, 30);
            ((ImageResource)this.e[39]).ClipRect(30, 0, 30, 30);
            this.e[0].AddChild((ResourceBase)this.e[37], 10, 195);
            this.e[0].AddChild((ResourceBase)this.e[38], 55, 195);
            this.e[0].AddChild((ResourceBase)this.e[39], 100, 195);
            this.e[0].AddChild((ResourceBase)this.e[30], 10, 195);
            this.e[0].AddChild((ResourceBase)this.e[31], 55, 195);
            this.e[0].AddChild((ResourceBase)this.e[32], 100, 195);
            this.e[33] = KeyboardResource.Create(this.d.GetLoadedImage("font7.gif"), 9, 12, 10, 0);
            this.e[34] = KeyboardResource.Create(this.d.GetLoadedImage("font7.gif"), 9, 12, 10, 0);
            this.e[35] = KeyboardResource.Create(this.d.GetLoadedImage("font7.gif"), 9, 12, 10, 0);
            this.e[30].AddChild(this.e[33], (this.e[30].GetWidth() - this.e[33].GetWidth()) / 2, this.e[30].GetHeight() + 2);
            this.e[31].AddChild(this.e[34], (this.e[31].GetWidth() - this.e[34].GetWidth()) / 2, this.e[31].GetHeight() + 2);
            this.e[32].AddChild(this.e[35], (this.e[32].GetWidth() - this.e[35].GetWidth()) / 2, this.e[32].GetHeight() + 2);
            this.e[62] = ImageResource.Create(this.d.GetLoadedImage("mg_howplay.gif"));
            this.e[63] = ImageResource.Create((ImageResource)this.e[62]);
            ((ImageResource)this.e[62]).ClipRect(0, 0, 56, 14);
            ((ImageResource)this.e[63]).ClipRect(56, 0, 56, 14);
            this.e[0].AddChild(this.e[63]);
            this.e[0].AddChild(this.e[62]);
            this.e[63].SetIsVisible(false);
            this.n1();
            this.e[28] = ImageResource.Create(this.d.GetLoadedImage("btn_jennifer.gif"));
            this.e[29] = ImageResource.Create((ImageResource)this.e[28]);
            ((ImageResource)this.e[28]).ClipRect(0, 0, 71, 15);
            ((ImageResource)this.e[29]).ClipRect(71, 0, 71, 15);
            this.e[0].AddChild(this.e[29]);
            this.e[0].AddChild(this.e[28]);
            this.e[29].SetIsVisible(false);
            if (this.v != 3)
            {
                this.e[28].SetIsVisible(false);
            }

            this.o1();
            this.e[2] = ImageResource.Create(this.d.GetLoadedImage("jeni_diary.gif"));
            this.e[0].AddChild((ResourceBase)this.e[2], int.Parse(this.C["[日記]"]), 0);
            this.e[52] = ImageResource.Create(this.d.GetLoadedImage("mg_font.gif"));
            this.e[0].AddChild((ResourceBase)this.e[52], 150, 200);
            this.e[53] = ImageResource.Create(this.d.GetLoadedImage("mg_menu.gif"));
            this.e[0].AddChild((ResourceBase)this.e[53], 4, 127);
            this.k1(false);
            this.e[54] = ImageResource.Create(this.d.GetLoadedImage("mg_commo0.gif"));
            this.e[53].AddChild((ResourceBase)this.e[54], 1, 1);
            ((ImageResource)this.e[54]).ClipRect(0, 0, 66, 15);
            this.e[42] = RectangleResource.Create(60, 10, 1, 250, 150, 24, 255);
            this.e[52].AddChild(this.e[42], (this.e[52].GetWidth() - this.e[42].GetWidth()) / 2, this.e[52].GetHeight() + 5);
            this.e[40] = RectangleResource.Create(0, 10, 1, 128, 255, 255, 255);
            this.e[42].AddChild((ResourceBase)this.e[40], 0, 0);
            this.e[41] = RectangleResource.Create(62, 12, 0, 255, 255, 255, 255);
            this.e[42].AddChild((ResourceBase)this.e[41], -1, -1);
            this.e[12] = ImageResource.Create(this.d.GetLoadedImage("btn_reset.gif"));
            this.e[13] = ImageResource.Create((ImageResource)this.e[12]);
            ((ImageResource)this.e[12]).ClipRect(0, 0, 50, 15);
            ((ImageResource)this.e[13]).ClipRect(50, 0, 50, 15);
            this.e[0].AddChild((ResourceBase)this.e[13], 5, 5);
            this.e[0].AddChild((ResourceBase)this.e[12], 5, 5);
            this.e[13].SetIsVisible(false);
            this.e[23] = ImageResource.Create((ImageResource)this.e[1]);
            this.e[13].AddChild((ResourceBase)this.e[23], this.e[12].GetWidth() + 3, 0);
            ((ImageResource)this.e[23]).SetFlipMode(4);
            this.e[7] = ImageResource.Create(this.d.GetLoadedImage("bg_hanyou.jpg"));
            this.e[0].AddChild(this.e[7]);
            this.e[7].SetIsVisible(false);
            this.e[8] = ScriptTextResource.Create(this.C["[MSG]"]);
            this.e[7].AddChild((ResourceBase)this.e[8], 12, 30);
            this.e[55] = ImageResource.Create(this.d.GetLoadedImage("font_jennifer.gif"));
            this.e[7].AddChild((ResourceBase)this.e[55], 4, 4);
            int[] var11 = new int[] { 0, 1, 2, 3, 4 };
            this.e[36] = ImageResource.Create(this.d.GetLoadedImage("mg_failed.gif"));
            this.e[0].AddChild(this.e[36]);
            ((ImageResource)this.e[36]).a1(0, 0, this.e[36].GetWidth() / 3, this.e[36].GetHeight() - this.e[36].GetHeight() / 2, var11);
            ((ImageResource)this.e[36]).b1(0, 2);
            this.e[36].SetIsVisible(false);
            this.e[36].d1(192);
            this.e[9] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
            this.e[10] = ImageResource.Create((ImageResource)this.e[9]);
            ((ImageResource)this.e[9]).ClipRect(0, 0, 40, 15);
            ((ImageResource)this.e[10]).ClipRect(40, 0, 40, 15);
            this.e[0].AddChild(this.e[10]);
            this.e[0].AddChild(this.e[9]);
            this.e[10].SetIsVisible(false);
            this.e[11] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            ((ImageResource)this.e[11]).SetFlipMode(5);
            this.e[0].AddChild(this.e[11]);
            this.e[25] = RectangleResource.Create(240, 240, 1, 255, 255, 255, 128);
            this.e[0].AddChild(this.e[25]);
            this.e[16] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small1.gif"));
            this.e[25].AddChild(this.e[16], (this.e[25].GetWidth() - this.e[16].GetWidth()) / 2, (192 - this.e[16].GetHeight()) / 2);
            this.e[17] = TextResource.Create("元に戻しますか？");
            this.e[18] = TextResource.Create("※アイテムはなくなりません。");
            this.e[25].AddChild((ResourceBase)this.e[17], (240 - this.e[17].GetWidth()) / 2, 72);
            this.e[25].AddChild((ResourceBase)this.e[18], (240 - this.e[18].GetWidth()) / 2, 85);
            this.e[19] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
            this.e[20] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
            this.e[21] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
            this.e[22] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));
            this.e[25].AddChild(this.e[19]);
            this.e[25].AddChild(this.e[20]);
            this.e[25].AddChild(this.e[21]);
            this.e[25].AddChild(this.e[22]);
            this.e[24] = ImageResource.Create((ImageResource)this.e[1]);
            this.e[25].AddChild(this.e[24]);
            ((ImageResource)this.e[24]).SetFlipMode(5);
            this.u = 0;
            this.e[3] = ImageResource.Create(this.d.GetLoadedImage("tuto3.gif"));
            this.e[4] = ImageResource.Create(this.d.GetLoadedImage("tuto4.gif"));
            this.e[5] = ImageResource.Create(this.d.GetLoadedImage("tuto5.gif"));
            this.e[6] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
            ((ImageResource)this.e[6]).b1(0, 0, 14, 14);
            this.e[0].AddChild(this.e[3]);
            this.e[0].AddChild(this.e[4]);
            this.e[0].AddChild(this.e[5]);
            this.e[0].AddChild((ResourceBase)this.e[6], 223, 175);
            this.e[3].SetIsVisible(false);
            this.e[4].SetIsVisible(false);
            this.e[5].SetIsVisible(false);
            this.e[6].SetIsVisible(false);
            this.e[56] = RectangleResource.Create(240, 240, 1, 0, 0, 0, 0);
            this.e[0].AddChild(this.e[56]);
            this.e[57] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small1.gif"));
            this.e[0].AddChild(this.e[57], (this.e[0].GetWidth() - this.e[57].GetWidth()) / 2, (192 - this.e[57].GetHeight()) / 2);
            this.e[58] = ImageResource.Create(this.d.GetLoadedImage("mg_font2.gif"));
            this.e[57].AddChild((ResourceBase)this.e[58], (this.e[57].GetWidth() - this.e[58].GetWidth()) / 2, 10);
            this.e[59] = TextResource.Create("小麦粉の袋がやぶけないよう");
            this.e[60] = TextResource.Create("アイテムを上手く使おう！");
            this.e[57].AddChild((ResourceBase)this.e[59], (this.e[57].GetWidth() - this.e[59].GetWidth()) / 2, 30);
            this.e[57].AddChild((ResourceBase)this.e[60], this.e[59].posX, 45);
            this.e[61] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
            ((ImageResource)this.e[61]).b1(0, 0, 14, 14);
            this.e[57].AddChild(this.e[61], this.e[57].GetWidth() - this.e[61].GetWidth() - 7, this.e[57].GetHeight() - this.e[61].GetHeight() - 8);
            this.e[57].SetIsVisible(false);
            this.a1(194, 7);
            this.j1(0);
            this.c1(false);
            if (var1.SaveData.h1() == 1)
            {
                var1.SaveData.g1();
                this.e[3].SetIsVisible(true);
                this.e[6].SetIsVisible(true);
                this.j1(false);
                this.a1(3);
            }
            else if (this.w)
            {
                this.e[7].SetIsVisible(true);
                this.a1(190, 170);
                this.b1(true);
                this.j1(false);
                this.a1(4);
            }
            else
            {
                this.i1(this.k);
                this.a1(0);
                this.c1(true);
            }

            if (var1.SaveData.E1() == 0)
            {
                this.a1(var1, true);
                var1.SaveData.D1();
            }
            else
            {
                this.a1(var1, false);
            }

            if (this.m <= 0)
            {
                this.c1(false);
            }

            if (!this.c[this.k].f1())
            {
                this.a1(1, true);
            }

            this.s1();
            this.b1(var1, false);
            this.D = true;
            this.g1();
            this.b1(this.k);
            this.d1(false);
            this.b1(0, this.k);
            this.b1(1, this.k);
            this.p1();
            this.h1(false);
            this.e[2].posY = 182 - this.e[2].GetHeight() - this.m1() * MiniGameInternal.a1(this.c[0]).GetHeight();
            this.b1();
            var2.ExecuteTransition(1);
        }

    }

    private void a1(bool var1)
    {
        int var2 = this.A;
        int var3 = this.B;
        if (var1)
        {
            this.e[9].SetPosition(var2 + 2, var3 + 2);
            this.e[10].SetPosition(var2 + 2, var3 + 2);
        }
        else
        {
            this.e[9].SetPosition(var2, var3);
            this.e[10].SetPosition(var2, var3);
        }

        this.b1(var1);
    }

    private bool b1(bool var1)
    {
        this.e[10].SetIsVisible(var1);
        this.e[11].SetIsVisible(var1);
        return var1;
    }

    private void a1(int var1, int var2)
    {
        this.A = var1;
        this.B = var2;
        this.e[9].SetPosition(var1, var2);
        this.e[10].SetPosition(var1, var2);
        this.e[11].SetPosition(var1 - this.e[11].GetWidth() / 2 - 3, var2 + (this.e[9].GetHeight() - this.e[11].GetHeight()) / 2 - 2);
        this.a1(false);
    }

    private void a1(ScreenResource var1)
    {
        this.e[11].SetIsVisible(true);
        this.e[11].SetPosition(158, 176);
        var1.ExecuteTransition(0);
        this.a1(4);
        this.c1(false);
        this.g1(true);
    }

    private void b1(ScreenResource var1)
    {
        this.e[11].SetIsVisible(true);
        this.e[11].SetPosition(170, 26);
        var1.ExecuteTransition(0);
        this.a1(12);
        this.f1(true);
    }

    public bool Update(GameContext var1)
    {
        ScreenResource var2 = var1.ScreenResource;
        this.t1();
        int var4;
        int var5;
        switch (this.a)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    this.j1(true);
                    this.a1(1);
                }
                break;
            case 1:
                if (var2._transitionState == 2)
                {
                    this.n1();
                    this.e[5].SetIsVisible(false);
                    this.e[6].SetIsVisible(false);
                    this.a1(194, 7);
                    this.e[7].SetIsVisible(false);
                    var2.ExecuteTransition(1);
                    if (this.m > 0)
                    {
                        this.c1(true);
                    }
                    else
                    {
                        this.c1(false);
                    }

                    this.j1(true);
                    this.i1(0);
                }
                else if (var2._transitionState == 0)
                {
                    if (((ImageResource)this.e[44]).IsVisible())
                    {
                        ++this.j;
                        if (this.j > 20)
                        {
                            this.j = 0;
                            this.a1(true, 0);
                            this.a1(false, 1);
                        }
                    }

                    this.i1(0);
                    this.h1();
                    if (this.G && this.H)
                    {
                        this.H = false;
                        this.a1(10);
                    }

                    if (this.c1())
                    {
                        if (!((ImageResource)this.e[50]).d1())
                        {
                            this.e[46].SetIsVisible(true);
                            this.e[50].SetIsVisible(false);
                        }

                        if (!((ImageResource)this.e[51]).d1())
                        {
                            this.e[46].SetIsVisible(true);
                            this.e[51].SetIsVisible(false);
                        }

                        this.c1(true);
                        if (this.m == 0)
                        {
                            this.c1(false);
                        }

                        this.i1();
                        this.b1(this.k);
                        this.D = true;
                        if (this.m1() <= 0)
                        {
                            this.c1(false);
                            if (this.v != 3)
                            {
                                this.w = true;
                            }

                            if (this.q <= this.p)
                            {
                                this.b = 2;
                            }
                            else
                            {
                                this.b = 1;
                            }

                            this.a1(2);
                            this.v = 3;
                        }
                    }
                    else
                    {
                        this.D = false;
                    }

                    if (this.D && !this.i)
                    {
                        if (var1.IsKeyPressed(131072) && this.s < 14)
                        {
                            var4 = this.m1();
                            var5 = 14;
                            if (var4 - 1 < 14)
                            {
                                var5 = var4 - 1;
                            }

                            ++this.s;
                            if (this.s > var5)
                            {
                                this.s = var5;
                            }
                            else if (this.a1(1, true))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (var1.IsKeyPressed(524288))
                        {
                            --this.s;
                            if (this.s < 0)
                            {
                                this.s = 0;
                            }
                            else if (this.a1(-1, true))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else if (var1.IsKeyPressed(65536))
                        {
                            this.a1(6);
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }
                        else if (var1.IsKeyPressed(262144))
                        {
                            this.a1(7);
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }
                        else if (var1.IsKeyPressed(1048576) && !this.i)
                        {
                            if (this.m1() > 0 && this.m > 0)
                            {
                                --this.m;
                                if (this.m < 0)
                                {
                                    this.m = 0;
                                }

                                this.i1(0, this.m);
                                ++this.q;
                                this.h = 0;
                                this.i = true;
                            }
                        }
                        else if (var1.IsKeyPressed(2))
                        {
                            this.h1(true);
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }
                        else if (var1.IsKeyPressed(4))
                        {
                            this.a1(true);
                            this.b = 0;
                            this.a1(2);
                            this.c1(false);
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        }
                        else if (var1.IsKeyPressed(32))
                        {
                            if (this.v == 3)
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                                this.a1(var1.ScreenResource);
                            }
                        }
                        else if (var1.IsKeyPressed(8))
                        {
                            this.b1(var1.ScreenResource);
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }
                    }

                    if (this.i)
                    {
                        this.e[46].SetIsVisible(false);
                        this.c1(false);
                        if (this.h == 0)
                        {
                            this.I = 0;
                            this.d1(this.k);
                            if (this.I < 3)
                            {
                                this.e[50].SetIsVisible(true);
                                this.c1(4, true);
                            }
                            else
                            {
                                this.a1(false, 0);
                                this.a1(true, 1);
                                this.e[51].SetIsVisible(true);
                                this.c1(5, true);
                            }
                        }

                        ++this.h;
                        if (this.h > 11)
                        {
                            this.I = 0;
                            this.c1(this.k);
                            if (this.I == 1)
                            {
                                this.k1(100);
                                this.m1(this.Z);
                            }
                            else if (this.I == 2)
                            {
                                this.k1(250);
                                this.m1(this.Z);
                            }
                            else if (this.I == 3)
                            {
                                this.k1(400);
                                this.m1(this.aa);
                            }
                            else if (this.I == 4)
                            {
                                this.k1(600);
                                this.m1(this.ab);
                            }
                            else
                            {
                                this.k1((this.I + (this.I - 2)) * 100);
                                this.m1(this.ac);
                            }

                            this.a1(1, false);
                            this.i = false;
                            AudioManager.b1(1, this.d.GetLoadedSound("se_mg01.mld"), 100, 0);
                        }
                    }
                }

                if (((ImageResource)this.e[50]).e1() == 11)
                {
                    this.c1(4, false);
                    ((ImageResource)this.e[50]).c1(0);
                }

                if (((ImageResource)this.e[51]).e1() == 11)
                {
                    this.c1(5, false);
                    ((ImageResource)this.e[51]).c1(0);
                }
                break;
            case 2:
                var2.ExecuteTransition(0);
                this.a1(99);
                break;
            case 3:
                if (var2._transitionState == 0 && var1.IsKeyPressed(1048576))
                {
                    ++this.u;
                    if (this.u == 1)
                    {
                        this.e[3].SetIsVisible(false);
                        this.e[4].SetIsVisible(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (this.u == 2)
                    {
                        this.e[4].SetIsVisible(false);
                        this.e[5].SetIsVisible(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (this.u == 3)
                    {
                        this.u = 0;
                        var2.ExecuteTransition(0);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                }

                if (var2._transitionState == 2)
                {
                    this.e[5].SetIsVisible(false);
                    this.e[6].SetIsVisible(false);
                    this.a1(1);
                }
                break;
            case 4:
                if (var2._transitionState == 2)
                {
                    this.o1();
                    this.a1(190, 170);
                    this.e[7].SetIsVisible(true);
                    this.b1(true);
                    var2.ExecuteTransition(1);
                    this.j1(false);
                }

                if (var2._transitionState == 0)
                {
                    this.w = false;
                    if (var1.IsKeyPressed(1048576) || var1.IsKeyPressed(4))
                    {
                        var2.ExecuteTransition(0);
                        this.a1(true);
                        this.g1(false);
                        this.a1(1);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        this.c1(false);
                    }
                }
                break;
            case 5:
                if (var1.IsKeyPressed(65536))
                {
                    this.a1(1);
                    this.b1(false);
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.,ld"), 100, 0);
                }
                else if (var1.IsKeyPressed(1048576) || var1.IsKeyPressed(4))
                {
                    this.a1(true);
                    this.b = 0;
                    this.a1(2);
                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                }
                break;
            case 6:
                if (this.K == 2)
                {
                    this.l1();
                }
                else
                {
                    this.b1(this.K, this.k);
                    if (var1.IsKeyPressed(131072) && this.s < 14)
                    {
                        var4 = this.m1();
                        var5 = 14;
                        if (var4 - 1 < 14)
                        {
                            var5 = var4 - 1;
                        }

                        ++this.s;
                        if (this.s > var5)
                        {
                            this.s = var5;
                        }
                        else if (this.K == 1)
                        {
                            ++this.l;
                            if (this.l > 1)
                            {
                                this.l = 1;
                                --this.s;
                            }
                            else if (this.s > var5)
                            {
                                this.l = 0;
                            }
                            else if (this.a1(1, true))
                            {
                                if (this.s > var5)
                                {
                                    this.l = 0;
                                }
                                else
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                }
                            }
                            else
                            {
                                this.l = 0;
                            }
                        }
                        else if (this.a1(1, true))
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(524288))
                    {
                        --this.s;
                        if (this.s >= 0 && this.l >= -1)
                        {
                            if (this.K == 1)
                            {
                                --this.l;
                                if (this.l < -1)
                                {
                                    this.l = -1;
                                    ++this.s;
                                }
                                else if (this.a1(-1, true))
                                {
                                    AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                                }
                                else
                                {
                                    this.l = 0;
                                }
                            }
                            else if (this.a1(-1, true))
                            {
                                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                            }
                        }
                        else
                        {
                            ++this.s;
                        }
                    }
                    else if (var1.IsKeyPressed(65536))
                    {
                        this.a1(7);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(262144))
                    {
                        this.a1(1);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(1048576) && this.m1() > 0)
                    {
                        if (this.o > 0)
                        {
                            this.f1(this.k);
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(2))
                    {
                        this.h1(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(4))
                    {
                        if (this.K == 0)
                        {
                            this.a1(true);
                            this.b = 0;
                            this.a1(2);
                            this.c1(false);
                        }
                        else
                        {
                            this.a1(true);
                        }

                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(32))
                    {
                        if (this.v == 3)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            this.a1(var1.ScreenResource);
                        }
                    }
                    else if (var1.IsKeyPressed(8))
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        this.b1(var1.ScreenResource);
                    }
                }

                if (this.m1() <= 0)
                {
                    this.d1(false);
                }

                if (this.e[10].IsVisible())
                {
                    this.k1();
                }
                break;
            case 7:
                if (this.e1())
                {
                    this.b1(0, this.k);
                    if (this.E)
                    {
                        if (this.f1())
                        {
                            AudioManager.b1(1, this.d.GetLoadedSound("se_mg02.mld"), 100, 0);
                            this.h1(this.k, 4);
                            this.c1(1, true);
                            this.a1(7);
                            --this.n;
                            if (this.n < 0)
                            {
                                this.n = 0;
                            }

                            if (this.n == 0)
                            {
                                this.d1(false);
                            }

                            this.i1(1, this.n);
                        }
                    }
                    else if (var1.IsKeyPressed(131072) && this.s < 14)
                    {
                        var4 = this.m1();
                        var5 = 14;
                        if (var4 - 1 < 14)
                        {
                            var5 = var4 - 1;
                        }

                        ++this.s;
                        if (this.s > var5)
                        {
                            this.s = var5;
                        }
                        else if (this.a1(1, true))
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(524288))
                    {
                        --this.s;
                        if (this.s < 0)
                        {
                            this.s = 0;
                        }
                        else if (this.a1(-1, true))
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(65536))
                    {
                        this.a1(1);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(262144))
                    {
                        this.a1(6);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(1048576) && this.m1() > 0)
                    {
                        if (this.n < 0)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        }
                        else if (this.c[this.k].e1() == 1 && this.n > 0)
                        {
                            this.d1();
                            this.c1(1, false);
                        }
                        else
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(2))
                    {
                        this.h1(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(4))
                    {
                        this.a1(true);
                        this.b = 0;
                        this.a1(2);
                        this.c1(false);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                    }
                    else if (var1.IsKeyPressed(32))
                    {
                        if (this.v == 3)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                            this.a1(var1.ScreenResource);
                        }
                    }
                    else if (var1.IsKeyPressed(8))
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        this.b1(var1.ScreenResource);
                    }
                }

                if (this.m1() <= 0)
                {
                    this.d1(false);
                }
                break;
            case 8:
                if (!this.X)
                {
                    if (var1.IsKeyPressed(65536))
                    {
                        if (!this.h1(0))
                        {
                            this.g1(0);
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(262144))
                    {
                        if (!this.h1(1))
                        {
                            this.g1(1);
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                        }
                    }
                    else if (var1.IsKeyPressed(1048576))
                    {
                        this.q1();
                        this.i1(true);
                    }
                }

                this.e1(var1);
                break;
            case 9:
                this.h1();
                this.c1();
                ++this.t;
                if (this.t > 30)
                {
                    this.t = 0;
                    if (var1.RoomData.GetBitFlag(50))
                    {
                        this.a1(11);
                    }
                    else
                    {
                        var2.ExecuteTransition(0);
                        this.a1(99);
                        this.b = 3;
                    }
                }

                this.c1(4, false);
                this.c1(5, false);
                break;
            case 10:
                this.c1();
                if (this.G)
                {
                    this.h1();
                    this.i1();
                }
                else
                {
                    for (var4 = 0; var4 < this.c.Length; ++var4)
                    {
                        MiniGameInternal.a1(this.c[var4]).j1();
                        this.d1(var4, 1);
                    }

                    ++this.u;
                    if (this.u > 2)
                    {
                        this.u = 0;

                        for (var4 = 0; var4 < this.c.Length; ++var4)
                        {
                            MiniGameInternal.a1(this.c[var4]).j1();
                            this.d1(var4, -1);
                            this.a1(1);
                            this.e[50].SetIsVisible(false);
                            this.e[51].SetIsVisible(false);
                        }
                    }
                }
                break;
            case 11:
                this.r += 10;
                if (this.r > 128)
                {
                    this.e[57].SetIsVisible(true);
                    this.r = 128;
                    if (var1.IsKeyPressed(1048576))
                    {
                        ((RectangleResource)this.e[56]).SetColor(0, 0, 0, 0);
                        this.e[57].SetIsVisible(false);
                        this.b1(var1, true);
                        this.D = true;
                        this.g1();
                        this.b1(this.k);
                        this.d1(false);
                        this.p1();
                        this.h1(false);
                        this.i1(false);
                        this.e[36].SetIsVisible(false);
                        this.G = false;
                        this.j = 0;
                        this.a1(true, 0);
                        this.a1(false, 1);
                        this.e[46].SetIsVisible(true);
                        this.e[50].SetIsVisible(false);
                        this.e[51].SetIsVisible(false);
                        this.i = false;
                        this.d1(var1);
                        this.a1(1);
                        this.c1();
                        this.h1();
                        this.r = 0;
                    }
                }

                ((RectangleResource)this.e[56]).SetColor(0, 0, 0, this.r);
                this.c1();
                this.h1();
                break;
            case 12:
                if (var2._transitionState == 0 && var1.IsKeyPressed(1048576))
                {
                    ++this.u;
                    if (this.u == 1)
                    {
                        this.e[3].SetIsVisible(false);
                        this.e[4].SetIsVisible(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (this.u == 2)
                    {
                        this.e[4].SetIsVisible(false);
                        this.e[5].SetIsVisible(true);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                    else if (this.u == 3)
                    {
                        this.u = 0;
                        var2.ExecuteTransition(0);
                        this.a1(1);
                        this.f1(false);
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                    }
                }

                if (var2._transitionState == 2)
                {
                    var2.ExecuteTransition(1);
                    this.e[3].SetIsVisible(true);
                    this.e[6].SetIsVisible(true);
                    this.j1(false);
                    this.f1(true);
                }
                break;
            case 99:
                if (var2._transitionState == 2)
                {
                    switch (this.b)
                    {
                        case 0:
                            var1.SetCurrentScene(IngameMenuScene.GetInstance());
                            break;
                        case 1:
                            if (this.r1())
                            {
                                var1.SaveData.p1(this.g);
                                var1.RoomData.SetEventId(102);
                            }
                            else
                            {
                                var1.RoomData.SetEventId(100);
                            }

                            this.d1(var1);
                            var1.SetCurrentScene(EventScene.GetInstance());
                            break;
                        case 2:
                            if (this.r1())
                            {
                                var1.SaveData.p1(this.g);
                            }

                            var1.SaveData.A1();
                            this.d1(var1);
                            var1.RoomData.SetEventId(101);
                            var1.SetCurrentScene(EventScene.GetInstance());
                            break;
                        case 3:
                            this.d1(var1);
                            var1.RoomData.SetEventId(103);
                            var1.SetCurrentScene(EventScene.GetInstance());
                            break;
                        default:
                            var1.SetCurrentScene(IngameMenuScene.GetInstance());
                            break;
                    }
                }
                break;
        }

        return true;
    }

    public void Reset(GameContext var1)
    {
        if (this.v != 3)
        {
            var1.SaveData.j1(2);
        }
        else
        {
            var1.SaveData.j1(3);
            var1.SaveData.o1(3);
        }

        var1.SaveData.q1(this.g);
        var1.SaveData.C1();

        int var2;
        for (var2 = 0; var2 < this.m; ++var2)
        {
            var1.SaveData.i1(var2, 1);
        }

        for (var2 = this.m; var2 < this.m + this.n; ++var2)
        {
            var1.SaveData.i1(var2, 5);
        }

        for (var2 = this.m + this.n; var2 < this.m + this.n + this.o; ++var2)
        {
            var1.SaveData.i1(var2, 6);
        }

        for (var2 = 0; var2 < this.c.Length; ++var2)
        {
            if (this.c[var2].f1())
            {
                var1.SaveData.a1(var2, 0, this.c[var2].d1(), this.c[var2].e1());
            }
            else
            {
                var1.SaveData.a1(var2, -1, this.c[var2].d1(), this.c[var2].e1());
            }
        }

        for (var2 = 0; var2 < 64; ++var2)
        {
            if (this.e[var2] != null)
            {
                var1.ScreenResource.RemoveChild(this.e[var2]);
                this.e[var2] = null;
            }
        }

        try
        {
            this.d.Reset();
        }
        catch (Exception var3)
        {
        }

        this.d = null;

        for (var2 = 0; var2 < this.c.Length; ++var2)
        {
            this.c[var2].a1();
            this.c[var2] = null;
        }

    }

    private void a1(JavaString var1)
    {
        bool var2 = false;
        bool var3 = false;
        StringBuilder var4 = new StringBuilder(var1);

        while (!var4.ToString().Trim().Equals(""))
        {
            int var9;
            switch (var4.ToString().Trim()[0])
            {
                case '#':
                    var9 = var4.ToString().IndexOf("\n");
                    var4.Remove(0, var9 + 1);
                    break;
                default:
                    var9 = var4.ToString().IndexOf(":");
                    JavaString var6 = var4.ToString().Substring(0, var9);
                    int var8 = var9 + 1;
                    var9 = var4.ToString().IndexOf("\n", var8);
                    JavaString var7 = var4.ToString().Substring(var8, var9);
                    this.C[var6.Trim()] = var7.Trim();
                    var4.Remove(0, var9 + 1);
                    break;
            }
        }

    }

    private static int a1(JavaString var0, int var1)
    {
        bool var2 = false;
        bool var3 = false;
        int var5 = var0.IndexOf(",");
        if (var1 == 0)
        {
            return int.Parse(var0.Substring(0, var5));
        }
        else
        {
            int var4 = var5 + 1;
            return int.Parse(var0[var4..].Trim());
        }
    }

    private void b1()
    {
        int var1 = 0;

        for (int var2 = 0; var2 < this.m1(); ++var2)
        {
            var1 += MiniGameInternal.a1(this.c[var2]).GetHeight();
        }

        this.e[2].a1(this.e[2].posX, 182 - this.e[2].GetHeight() - var1, 4);
    }

    private bool c1()
    {
        return this.e[2].j1();
    }

    private void b1(int var1)
    {
        this.e[1].SetPosition(MiniGameInternal.a1(this.c[var1]).posX - this.e[1].GetWidth() + 5, MiniGameInternal.a1(this.c[var1]).posY - 2);
        this.e[45].posY = MiniGameInternal.a1(this.c[var1]).posY - 6;
        this.e[46].SetPosition(this.e[45].posX + 40, this.e[45].posY - 21);
        this.e[47].SetPosition(this.e[45].posX + 40, this.e[45].posY - 21);
        this.e[48].SetPosition(this.e[45].posX + 40, this.e[45].posY - 21);
        this.e[49].SetPosition(this.e[45].posX + 40, this.e[45].posY - 21);
        this.e[50].SetPosition(this.e[45].posX + 40, this.e[45].posY - 21);
        this.e[51].SetPosition(this.e[45].posX + 40, this.e[45].posY - 21);
    }

    private bool a1(int var1, bool var2)
    {
        bool var3 = true;
        if (this.m1() > 0)
        {
            this.k += var1;
            if (this.k < 0)
            {
                this.k = 0;
                if (!this.c[this.k].f1())
                {
                    this.a1(-var1, var2);
                }

                var3 = false;
            }
            else if (this.k > this.c.Length - 1)
            {
                this.k = this.c.Length - 1;
                if (!this.c[this.k].f1())
                {
                    this.a1(-var1, var2);
                }

                var3 = false;
            }
            else if (!this.c[this.k].f1())
            {
                this.a1(var1, var2);
            }
            else if (var2)
            {
                this.b1(this.k);
            }
            else if (this.m1() <= this.s)
            {
                --this.s;
            }
        }

        return var3;
    }

    private void c1(bool var1)
    {
        this.e[1].SetIsVisible(var1);
    }

    private void b1(int var1, bool var2)
    {
        if (var2)
        {
            this.b1(var1, this.k);
        }

        this.e[14 + var1].SetIsVisible(var2);
        if (this.m1() <= 0)
        {
            this.e[14 + var1].SetIsVisible(false);
        }

    }

    private void d1(bool var1)
    {
        this.e[14].SetIsVisible(var1);
        this.e[15].SetIsVisible(var1);
    }

    private void b1(int var1, int var2)
    {
        this.e[14 + var1].SetPosition(MiniGameInternal.a1(this.c[var2]).posX - this.e[14 + var1].GetWidth() + 5, MiniGameInternal.a1(this.c[var2]).posY - 2);
    }

    private void e1(bool var1)
    {
        if (var1)
        {
            this.e[27].ExecuteTransition(1);
            this.e[27].SetIsVisible(var1);
        }
        else
        {
            this.e[27].ExecuteTransition(0);
        }
    }

    private void c1(int var1, int var2)
    {
        this.e[27].SetPosition(var1, var2);
    }

    private void d1()
    {
        this.e[26].SetPosition(this.e[14].posX + MiniGameInternal.a1(this.c[this.k]).GetWidth(), this.e[14].posY - this.e[14].GetHeight() + 10);
        this.e[26].SetIsVisible(true);
        this.e[26].a1(this.e[14].posX + MiniGameInternal.a1(this.c[this.k]).GetWidth() - 36, this.e[26].posY, 5);
        this.E = true;
    }

    private bool e1()
    {
        bool var1 = false;
        return this.e[26].j1();
    }

    private bool f1()
    {
        bool var1 = false;
        ++this.F;
        if (this.F > 5)
        {
            var1 = true;
        }

        return var1;
    }

    private int c1(int var1)
    {
        if (this.c[var1].f1())
        {
            ++this.I;
            this.G = true;
            this.c[var1].b1(MiniGameInternal.a1(this.c[var1]).posX + (240 - MiniGameInternal.a1(this.c[var1]).posX));
            MiniGameInternal.a1(this.c[var1]).a1(this.c[var1].d1(), MiniGameInternal.a1(this.c[var1]).posY, 3);
            this.c[var1].h1();
            this.g1();
            this.e1(var1, 1);
            if (this.e1(var1, -1))
            {
                --this.s;
            }

            for (int var2 = var1 + 1; var2 < this.c.Length; ++var2)
            {
                this.c[var2].a1(this.c[var2].c1() + MiniGameInternal.a1(this.c[var2]).GetHeight());
                MiniGameInternal.a1(this.c[var2]).a1(this.c[var2].d1(), this.c[var2].c1(), 3);
                if (this.c[var2].f1())
                {
                    this.H = true;
                }
            }
        }

        PhoneManager.a1(3);
        this.b1();
        return 0;
    }

    private void d1(int var1, int var2)
    {
        MiniGameInternal.a1(this.c[var1]).a1(this.c[var1].d1(), this.c[var1].c1() + var2, 1);
    }

    private bool e1(int var1, int var2)
    {
        bool var3 = false;
        int var4 = var1;

        while ((var1 += var2) >= 0 && var1 <= this.c.Length - 1)
        {
            if (this.c[var1].f1())
            {
                if (this.c[var4].e1() == this.c[var1].e1())
                {
                    this.c1(var1);
                    var3 = true;
                }
                else if (this.c[var4].e1() == 1 && this.c[var1].e1() == 4 || this.c[var4].e1() == 4 && this.c[var1].e1() == 1)
                {
                    this.c1(var1);
                    var3 = true;
                }
                else if ((this.c[var4].e1() != 3 || this.c[var1].e1() != 5) && (this.c[var4].e1() != 5 || this.c[var1].e1() != 3))
                {
                    if (this.c[var4].e1() == 3 && this.c[var1].e1() == 6 || this.c[var4].e1() == 6 && this.c[var1].e1() == 3)
                    {
                        this.c1(var1);
                        var3 = true;
                    }
                    else
                    {
                        if ((this.c[var4].e1() != 5 || this.c[var1].e1() != 6) && (this.c[var4].e1() != 6 || this.c[var1].e1() != 5))
                        {
                            break;
                        }

                        this.c1(var1);
                        var3 = true;
                    }
                }
                else
                {
                    this.c1(var1);
                    var3 = true;
                }
            }

            if (0 >= var1 || var1 >= this.c.Length - 1)
            {
                break;
            }
        }

        return var3;
    }

    private void d1(int var1)
    {
        if (this.c[var1].g1())
        {
            this.c[var1].i1();
            this.g1();
            ++this.I;
            this.f1(var1, 1);
            this.f1(var1, -1);
        }

    }

    private bool f1(int var1, int var2)
    {
        bool var3 = false;
        int var4 = var1;

        while ((var1 += var2) >= 0 && var1 <= this.c.Length - 1)
        {
            if (this.c[var1].g1())
            {
                if (this.c[var4].e1() == this.c[var1].e1())
                {
                    this.d1(var1);
                    var3 = true;
                }
                else if (this.c[var4].e1() == 1 && this.c[var1].e1() == 4 || this.c[var4].e1() == 4 && this.c[var1].e1() == 1)
                {
                    this.d1(var1);
                    var3 = true;
                }
                else if ((this.c[var4].e1() != 3 || this.c[var1].e1() != 5) && (this.c[var4].e1() != 5 || this.c[var1].e1() != 3))
                {
                    if (this.c[var4].e1() == 3 && this.c[var1].e1() == 6 || this.c[var4].e1() == 6 && this.c[var1].e1() == 3)
                    {
                        this.d1(var1);
                        var3 = true;
                    }
                    else
                    {
                        if ((this.c[var4].e1() != 5 || this.c[var1].e1() != 6) && (this.c[var4].e1() != 6 || this.c[var1].e1() != 5))
                        {
                            break;
                        }

                        this.d1(var1);
                        var3 = true;
                    }
                }
                else
                {
                    this.d1(var1);
                    var3 = true;
                }
            }

            if (0 >= var1 || var1 >= this.c.Length - 1)
            {
                break;
            }
        }

        return var3;
    }

    private void g1()
    {
        this.J = 0;

        for (int var1 = 0; var1 < this.c.Length; ++var1)
        {
            if (this.c[var1].f1())
            {
                ++this.J;
            }
        }

    }

    private void h1()
    {
        for (int var1 = 0; var1 < this.c.Length; ++var1)
        {
            if (MiniGameInternal.a1(this.c[var1]).j1())
            {
                MiniGameInternal.a1(this.c[var1]).SetIsVisible(this.c[var1].f1());
            }
        }

        this.e[36].j1();
    }

    private void i1()
    {
        if (this.G)
        {
            this.G = false;

            for (int var1 = 0; var1 < this.c.Length - 1; ++var1)
            {
                if (this.c[var1].f1() && !this.e1(var1))
                {
                    this.j1();
                }
            }
        }

    }

    private bool e1(int var1)
    {
        bool var2 = true;
        int var3 = var1;

        do
        {
            ++var1;
            if (var1 < 0 || var1 > this.c.Length - 1)
            {
                break;
            }

            if (this.c[var1].f1())
            {
                if (this.c[var3].e1() != this.c[var1].e1())
                {
                    var2 = this.c[var3].d1(this.c[var1].e1());
                    break;
                }

                var2 = true;
            }
        } while (0 < var1 && var1 < this.c.Length - 1);

        return var2;
    }

    private void j1()
    {
        int var1 = 0;

        for (int var2 = 0; var2 < this.c.Length; ++var2)
        {
            if (this.c[var2].f1())
            {
                this.e[36].SetIsVisible(true);
                ((ImageResource)this.e[36]).SetPosition(this.e[45].posX + this.e[45].GetWidth() - 10, this.e[45].posY - 17);
                this.e[36].a1(this.e[36].posX, 182 - this.e[36].GetHeight(), 10);
                this.g1(var1, var2);
                ++var1;
            }
        }

    }

    private void g1(int var1, int var2)
    {
        int var3 = Helper.a1(-10, 10);
        int var4 = Helper.a1(-2, 2);
        int var5 = 0;
        if (var1 != 0)
        {
            if (var1 > 3)
            {
                var5 = MiniGameInternal.a1(this.c[var2]).GetHeight() / 2;
            }

            MiniGameInternal.a1(this.c[var2]).a1(this.c[var2].d1() + var3, MiniGameInternal.a1(this.c[var2]).posY + MiniGameInternal.a1(this.c[var2]).GetHeight() * (var1 / 2 + 1) + var4 + var5, 3);
            this.e[2].a1(this.e[2].posX, MiniGameInternal.a1(this.c[var2]).posY + MiniGameInternal.a1(this.c[var2]).GetHeight() * (var1 / 2 + 1) + var4 + var5 - this.e[2].GetHeight() / 2, 4);
        }

        this.c1(false);
        this.d1(false);
        this.a1(9);
    }

    private void h1(int var1, int var2)
    {
        Image[] var3 = new Image[] { null, this.d.GetLoadedImage("swords.gif"), this.d.GetLoadedImage("ibag.gif"), this.d.GetLoadedImage("book.gif"), this.d.GetLoadedImage("swords_saya.gif"), this.d.GetLoadedImage("book2.gif"), this.d.GetLoadedImage("book3.gif") };
        this.c[var1].c1(var2);
        ((ImageResource)MiniGameInternal.a1(this.c[var1])).SetImage(var3[this.c[var1].e1()]);
    }

    private void f1(int var1)
    {
        if (this.K == 0)
        {
            this.M = var1;
            this.L = this.c[var1].e1();
            this.N = MiniGameInternal.a1(this.c[var1]).posX;
            this.O = MiniGameInternal.a1(this.c[var1]).posY;
            this.K = 1;
            this.b1(1, true);
            this.e[48].SetIsVisible(false);
            this.e[49].SetIsVisible(true);
            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
        }
        else
        {
            this.K = 2;
            this.Q = var1;
            this.P = this.c[var1].e1();
            this.R = MiniGameInternal.a1(this.c[var1]).posX;
            this.S = MiniGameInternal.a1(this.c[var1]).posY;
            if (this.M == this.Q)
            {
                AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                this.a1(6);
            }
            else
            {
                AudioManager.b1(1, this.d.GetLoadedSound("se_mg03.mld"), 100, 0);
            }
        }
    }

    private void k1()
    {
        ++this.T;
        if (this.T > 5)
        {
            this.T = 0;
            this.a1(6);
            this.a1(false);
        }

    }

    private void l1()
    {
        switch (this.V)
        {
            case 0:
                int var1 = this.S;
                int var2 = this.S - this.O;
                if (this.O > this.S)
                {
                    var1 = this.O;
                    var2 = this.O - this.S;
                }

                ((ImageResource)this.e[27]).SetSize(this.e[27].GetWidth() / 2, this.e[27].GetHeight() / 2);
                ((ImageResource)this.e[27]).SetScale(1.3F, 1.3F);
                this.c1(this.e[2].posX - 5, var1 - (var2 - MiniGameInternal.a1(this.c[this.M]).GetHeight() + this.e[27].GetHeight()) / 2);
                this.e1(true);
                this.V = 5;
                return;
            case 1:
                if (MiniGameInternal.a1(this.c[this.M]).j1() && MiniGameInternal.a1(this.c[this.Q]).j1())
                {
                    this.V = this.U;
                    return;
                }
                break;
            case 2:
                MiniGameInternal.a1(this.c[this.M]).a1(this.R + 20, this.S, 5);
                MiniGameInternal.a1(this.c[this.Q]).a1(this.N - 20, this.O, 5);
                this.V = 1;
                this.U = 3;
                return;
            case 3:
                MiniGameInternal.a1(this.c[this.M]).a1(this.R, this.S, 5);
                MiniGameInternal.a1(this.c[this.Q]).a1(this.N, this.O, 5);
                this.V = 1;
                this.U = 4;
                return;
            case 4:
                this.h1(this.M, this.P);
                this.h1(this.Q, this.L);
                MiniGameInternal.a1(this.c[this.M]).SetPosition(this.N, this.O);
                MiniGameInternal.a1(this.c[this.Q]).SetPosition(this.R, this.S);
                this.V = 5;
                this.e1(false);
                return;
            case 5:
                this.h1(this.M, this.P);
                this.h1(this.Q, this.L);
                ++this.W;
                if (this.W > 10)
                {
                    this.W = 0;
                    this.e1(false);
                    ((ImageResource)this.e[27]).SetScale(1.0F, 1.0F);
                    this.a1(6);
                    --this.o;
                    if (this.o < 0)
                    {
                        this.o = 0;
                    }

                    if (this.o == 0)
                    {
                        this.d1(false);
                    }

                    this.i1(2, this.o);
                }
                break;
        }

    }

    private void d1(GameContext var1)
    {
        for (int var2 = 0; var2 < this.c.Length; ++var2)
        {
            this.h1(var2, a1(this.C["[" + (var2 + 1) + "]"], 0));
            this.c[var2].b1();
            this.c[var2].b1(a1(this.C["[" + (var2 + 1) + "]"], 1));
            this.c[var2].a1(182 - (var2 + 1) * MiniGameInternal.a1(this.c[var2]).GetHeight());
            MiniGameInternal.a1(this.c[var2]).SetPosition(this.c[var2].d1(), this.c[var2].c1());
            MiniGameInternal.a1(this.c[var2]).SetIsVisible(this.c[var2].f1());
        }

        this.a1(var1, true);
        this.q = 0;
        this.k = 0;
        this.s = this.k;
        this.g1();
        this.b1(this.k);
        this.e[2].posY = 182 - this.e[2].GetHeight() - this.m1() * MiniGameInternal.a1(this.c[0]).GetHeight();
        this.g = 0;
        this.s1();
        if (this.m1() > 0)
        {
            this.c1(true);
        }

    }

    private int m1()
    {
        int var1 = 0;

        for (int var2 = 0; var2 < this.c.Length; ++var2)
        {
            if (this.c[var2].f1())
            {
                ++var1;
            }
        }

        return var1;
    }

    private void n1()
    {
        this.e[62].SetPosition(179, 24);
        this.e[63].SetPosition(179, 24);
    }

    private void f1(bool var1)
    {
        this.e[63].SetIsVisible(var1);
        this.e[62].SetPosition(this.e[62].posX + 2, this.e[62].posY + 2);
        this.e[63].SetPosition(this.e[63].posX + 2, this.e[63].posY + 2);
    }

    private void o1()
    {
        this.e[28].SetPosition(166, 172);
        this.e[29].SetPosition(166, 172);
    }

    private void g1(bool var1)
    {
        this.e[29].SetIsVisible(var1);
        this.e[28].SetPosition(this.e[28].posX + 2, this.e[28].posY + 2);
        this.e[29].SetPosition(this.e[29].posX + 2, this.e[29].posY + 2);
    }

    private void h1(bool var1)
    {
        this.e[13].SetIsVisible(var1);
        this.e[25].SetIsVisible(var1);
        if (var1)
        {
            this.a1(8);
            this.c1(false);
        }

    }

    private void p1()
    {
        this.g1(1);
        this.e[19].SetPosition(41, 103);
        this.e[20].SetPosition(41, 103);
        this.e[21].SetPosition(131, 103);
        this.e[22].SetPosition(131, 103);
    }

    private void g1(int var1)
    {
        if (var1 == 0)
        {
            this.e[20].SetIsVisible(true);
            this.e[22].SetIsVisible(false);
            this.e[24].SetPosition(30, 110);
        }
        else
        {
            this.e[20].SetIsVisible(false);
            this.e[22].SetIsVisible(true);
            this.e[24].SetPosition(120, 110);
        }
    }

    private bool h1(int var1)
    {
        return this.e[20 + var1 * 2].IsVisible();
    }

    private void q1()
    {
        if (this.h1(0))
        {
            this.e[19].SetPosition(this.e[19].posX + 2, this.e[19].posY + 2);
            this.e[20].SetPosition(this.e[20].posX + 2, this.e[20].posY + 2);
            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
        }
        else
        {
            this.e[21].SetPosition(this.e[21].posX + 2, this.e[21].posY + 2);
            this.e[22].SetPosition(this.e[22].posX + 2, this.e[22].posY + 2);
            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
        }
    }

    private void i1(bool var1)
    {
        this.X = var1;
        this.Y = 0;
    }

    private void e1(GameContext var1)
    {
        if (this.X)
        {
            ++this.Y;
            if (this.Y > 5)
            {
                if (this.h1(0))
                {
                    this.d1(var1);
                    this.a1(1);
                }
                else
                {
                    this.a1(this.z);
                }

                this.p1();
                this.h1(false);
                this.i1(false);
            }
        }

    }

    private void j1(bool var1)
    {
        this.e[37].SetIsVisible(var1);
        this.e[38].SetIsVisible(var1);
        this.e[39].SetIsVisible(var1);
        this.e[30].SetIsVisible(var1);
        this.e[31].SetIsVisible(var1);
        this.e[32].SetIsVisible(var1);
        this.e[52].SetIsVisible(var1);
    }

    private void i1(int var1)
    {
        this.e[37].SetIsVisible(false);
        this.e[38].SetIsVisible(false);
        this.e[39].SetIsVisible(false);
        this.e[37 + var1].SetIsVisible(true);
        this.e[52].SetIsVisible(true);
    }

    private void j1(int var1)
    {
        this.e[46].SetIsVisible(false);
        this.e[47].SetIsVisible(false);
        this.e[48].SetIsVisible(false);
        this.e[49].SetIsVisible(false);
        if (this.z != 1 && this.z != 0 && this.z != 3 && this.z != 10 && this.z != 8 && this.z != 11)
        {
            this.e[37].SetIsVisible(false);
        }

        this.e[38].SetIsVisible(false);
        this.e[39].SetIsVisible(false);
        switch (var1)
        {
            case 0:
                this.e[46].SetIsVisible(true);
                this.d1(false);
                this.G = true;
                this.i1();
                break;
            case 1:
                this.e[38].SetIsVisible(true);
                this.e[47].SetIsVisible(true);
                this.d1(false);
                this.c1(false);
                if (this.n > 0)
                {
                    this.b1(0, true);
                }

                this.G = true;
                this.i1();
                break;
            case 2:
                this.e[39].SetIsVisible(true);
                this.e[48].SetIsVisible(true);
                this.d1(false);
                this.l = 0;
                this.c1(false);
                if (this.o > 0)
                {
                    this.b1(0, true);
                }

                this.G = true;
                this.i1();
                break;
        }

        this.e[26].SetIsVisible(false);
        this.E = false;
        this.F = 0;
        this.K = 0;
        this.V = 0;
    }

    [FunctionName("a")]
    private void a1(GameContext var1, bool var2)
    {
        int var3;
        int var4;
        int var5;
        int var6;
        if (var2)
        {
            this.m = int.Parse(this.C["[初期ハンマー]"]);
            this.n = int.Parse(this.C["[初期鞘]"]);
            this.o = int.Parse(this.C["[初期マシン]"]);
            var3 = 0;
            var4 = 0;
            var5 = 0;

            for (var6 = 0; var6 < 20; ++var6)
            {
                if (var1.SaveData.l1(var6) != 1 && var1.SaveData.l1(var6) != 2 && var1.SaveData.l1(var6) != 3 && var1.SaveData.l1(var6) != 4)
                {
                    if (var1.SaveData.l1(var6) == 5)
                    {
                        ++var4;
                    }
                    else if (var1.SaveData.l1(var6) == 6)
                    {
                        ++var5;
                    }
                }
                else
                {
                    ++var3;
                }
            }

            this.m += var3;
            this.n += var4;
            this.o += var5;
        }
        else
        {
            this.m = 0;
            this.n = 0;
            this.o = 0;
            var3 = 0;
            var4 = 0;
            var5 = 0;

            for (var6 = 0; var6 < 20; ++var6)
            {
                if (var1.SaveData.u1(var6) != 1 && var1.SaveData.u1(var6) != 2 && var1.SaveData.u1(var6) != 3 && var1.SaveData.u1(var6) != 4)
                {
                    if (var1.SaveData.u1(var6) == 5)
                    {
                        ++var4;
                    }
                    else if (var1.SaveData.u1(var6) == 6)
                    {
                        ++var5;
                    }
                }
                else
                {
                    ++var3;
                }
            }

            this.m += var3;
            this.n += var4;
            this.o += var5;
        }

        ((KeyboardResource)this.e[33]).a1(this.m.ToString());
        ((KeyboardResource)this.e[34]).a1(this.n.ToString());
        ((KeyboardResource)this.e[35]).a1(this.o.ToString());
    }

    private void i1(int var1, int var2)
    {
        ((KeyboardResource)this.e[33 + var1]).a1(var2.ToString());
    }

    private void b1(GameContext var1, bool var2)
    {
        if (var2)
        {
            this.g = 0;
            this.l1(this.g);
        }
        else
        {
            this.g = var1.SaveData.z1();
            this.l1(this.g);
        }

        this.f = var1.SaveData.y1();
    }

    private void k1(int var1)
    {
        this.g += var1;
        this.l1(this.g);
    }

    private bool r1()
    {
        return this.g > this.f;
    }

    private void s1()
    {
        ((RectangleResource)this.e[40]).SetSize(0, 10);
        ((RectangleResource)this.e[40]).SetColor(128, 255, 255, 255);
    }

    private void l1(int var1)
    {
        int var2 = int.Parse(this.C["[SCORE]"]);
        if (this.g > var2)
        {
            ((RectangleResource)this.e[40]).SetSize(60, 10);
            this.m1(this.ac);
        }
        else
        {
            float var3 = (float)var1 * 1.0F / ((float)var2 * 1.0F) * 60.0F;
            ((RectangleResource)this.e[40]).SetSize((int)var3, 10);
        }

        if (this.r1())
        {
            ((RectangleResource)this.e[40]).SetColor(0, 255, 0, 255);
        }

    }

    private void m1(int var1)
    {
        ((ImageResource)this.e[54]).ClipRect(var1 * 66, 0, 66, 15);
        this.k1(true);
    }

    private void k1(bool var1)
    {
        this.ad = 0;
        this.e[53].SetIsVisible(var1);
    }

    private void t1()
    {
        if (this.e[53].IsVisible())
        {
            ++this.ad;
            if (this.ad > 20)
            {
                this.k1(false);
            }
        }

    }

    private void c1(int var1, bool var2)
    {
        ((ImageResource)this.e[46 + var1]).a1(var2);
    }

    private void a1(bool var1, int var2)
    {
        this.e[43 + var2].SetIsVisible(var1);
    }

    private class MiniGameInternal
    {
        private ResourceBase a;
        private int b = 0;
        private int c = 0;
        private int d = 0;
        private bool e = true;
        private bool f = true;

        public MiniGameInternal(MinigameScene parent)
        {
        }

        public void a1()
        {
            if (this.a != null)
            {
                this.a.h1();
                this.a = null;
            }

        }

        public void b1()
        {
            this.e = true;
            this.f = true;
        }

        public void a1(int var1)
        {
            this.c = var1;
        }

        public int c1()
        {
            return this.c;
        }

        public void b1(int var1)
        {
            this.b = var1;
        }

        public void c1(int var1)
        {
            this.d = var1;
        }

        public void a1(Image var1)
        {
            this.a = ImageResource.Create(var1);
        }

        public void a1(bool var1)
        {
            this.e = var1;
        }

        public int d1()
        {
            return this.b;
        }

        public int e1()
        {
            return this.d;
        }

        public bool f1()
        {
            return this.e;
        }

        public bool g1()
        {
            return this.f;
        }

        public void h1()
        {
            this.e = false;
        }

        public void i1()
        {
            this.f = false;
        }

        public bool d1(int var1)
        {
            bool var2 = true;
            if (this.d != 3)
            {
                if (this.d == 1 && var1 == 2)
                {
                    var2 = false;
                }
                else if (this.d == 2 && var1 == 1)
                {
                    var2 = false;
                }
            }

            return var2;
        }

        public static ResourceBase a1(MiniGameInternal var0)
        {
            return var0.a;
        }
    }
}
