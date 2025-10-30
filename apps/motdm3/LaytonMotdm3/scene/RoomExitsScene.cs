using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Managers;
using LaytonMotdm3.c.Resources;

namespace LaytonMotdm3.scene;

// Scene for moving to other rooms from the current room

[ClassName("scene", "i")]
public class RoomExitsScene : IScene
{
    private int a;
    private ResourceBase[] b;
    private ResourceBase[] c;
    private ResourceBase d;
    private ResourceBase e;
    private ResourceBase[] f;
    private ResourceBase[] g;
    private ResourceBase h;
    private int i;
    private int j;
    private int k;
    private int l = 0;
    private int m = 0;
    private int n = 0;
    private int o = 0;
    private static RoomExitsScene p = new RoomExitsScene();

    private RoomExitsScene()
    {
    }

    public static RoomExitsScene GetInstance()
    {
        return p;
    }

    public void Setup(GameContext var1)
    {
        ScreenResource var2 = var1.ScreenResource;
        this.l = 0;
        var1.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        this.a = 0;
        this.m = var1.RoomData.GetExitCount();
        this.b = new ResourceBase[this.m];
        this.c = new ResourceBase[this.m];

        int var13;
        int var14;
        for (var13 = 0; var13 < this.m; ++var13)
        {
            if ((var14 = var1.RoomData.h1(var13)) == 5)
            {
                this.b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_move2.gif"));
                ((ImageResource)this.b[var13]).ClipRect(0, 0, 25, 22);
                this.c[var13] = ImageResource.Create((ImageResource)this.b[var13]);
                ((ImageResource)this.c[var13]).ClipRect(25, 0, 25, 22);
                this.c[var13].SetIsVisible(false);
            }
            else if (var14 == 6)
            {
                this.b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
                ((ImageResource)this.b[var13]).ClipRect(0, 0, 40, 15);
                this.c[var13] = ImageResource.Create((ImageResource)this.b[var13]);
                ((ImageResource)this.c[var13]).ClipRect(40, 0, 40, 15);
                this.c[var13].SetIsVisible(false);
            }
            else if (var14 == 0)
            {
                this.b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_move0.gif"));
                ((ImageResource)this.b[var13]).ClipRect(0, 0, 32, 15);
                this.c[var13] = ImageResource.Create((ImageResource)this.b[var13]);
                ((ImageResource)this.c[var13]).ClipRect(32, 0, 32, 15);
                this.c[var13].SetIsVisible(false);
            }
            else
            {
                this.b[var13] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_move1.gif"));
                ((ImageResource)this.b[var13]).ClipRect(0, 0, 40, 16);
                this.c[var13] = ImageResource.Create((ImageResource)this.b[var13]);
                ((ImageResource)this.c[var13]).ClipRect(40, 0, 40, 16);
                this.c[var13].SetIsVisible(false);
                if (var14 == 3)
                {
                    ((ImageResource)this.b[var13]).SetFlipMode(3);
                    ((ImageResource)this.c[var13]).SetFlipMode(3);
                }

                if (var14 == 4)
                {
                    ((ImageResource)this.b[var13]).SetFlipMode(4);
                    ((ImageResource)this.c[var13]).SetFlipMode(4);
                }

                if (var14 == 2)
                {
                    ((ImageResource)this.b[var13]).SetFlipMode(5);
                    ((ImageResource)this.c[var13]).SetFlipMode(5);
                }
            }
        }

        this.e = ImageResource.Create(var1.ScriptResourceFileManager.GetLoadedImage(var1.RoomData.GetBackground()));
        if (var1.RoomData.IsBackgroundFlipped())
        {
            ((ImageResource)this.e).SetFlipMode(1);
        }
        else
        {
            ((ImageResource)this.e).SetFlipMode(0);
        }

        var2.AddChild((ResourceBase)this.e, (240 - this.e.GetWidth()) / 2, 0);
        int var15;
        int[] var16;
        if ((var13 = var1.RoomData.GetBackgroundObjectCount()) > 0)
        {
            JavaString var20 = "bgoj_" + Helper.ToStringPad(var1.SaveData.GetRoomId() + 1, 3) + ".dat";
            this.f = var1.RoomData.a1(var1.ScriptResourceFileManager, var20);

            for (var15 = 0; var15 < var13; ++var15)
            {
                if (var1.RoomData.IsBackgroundObjectFlipped(var15))
                {
                    ((AnimatedImageResource)this.f[var15]).SetFlipMode(1);
                }
                else
                {
                    ((AnimatedImageResource)this.f[var15]).SetFlipMode(0);
                }

                var16 = var1.RoomData.GetBackgroundPosition(var15);
                this.e.AddChild(this.f[var15], var16[0], var16[1]);
            }
        }

        int var17;
        int var24;
        if ((var14 = var1.RoomData.GetPotCount()) > 0)
        {
            JavaString var21 = "bgoj_" + Helper.ToStringPad(var1.SaveData.GetRoomId(), 3) + ".dat";
            this.f = var1.RoomData.LoadBackgroundResource(var1.ScriptResourceFileManager, var21, 0);
            int var22 = 0;

            for (var17 = 0; var22 < var14; ++var22)
            {
                if (var1.RoomData.GetPotAmount(var22) == 0)
                {
                    int[] var18 = var1.RoomData.GetPotPos(var22);
                    this.e.AddChild(this.f[var17], var18[0], var18[1]);
                    ++var17;
                }
            }

            this.g = new ResourceBase[this.f.Length];
            var22 = var1.RoomData.I1();
            int[][] var23 = new int[this.g.Length][];
            for (var i = 0; i < g.Length; i++) var23[i] = new int[2];
            var24 = 0;

            int var19;
            for (var19 = 0; var24 < var14; ++var24)
            {
                if (var1.RoomData.GetPotAmount(var24) == 0)
                {
                    var23[var19] = var1.RoomData.GetPotPos(var24);
                    ++var19;
                }
            }

            for (var24 = 0; var24 < this.g.Length; ++var24)
            {
                var19 = int.Parse(var1.RoomData.c[var22][0]);
                var22 = var1.RoomData.A1(var22);
                this.g[var24] = KeyboardResource.Create(var1.ScriptResourceFileManager.GetLoadedImage("save_number.gif"), 7, 10, 10, Helper.ToStringPad(var19, 3));
                if (var24 < 4)
                {
                    this.e.AddChild(this.g[var24], var23[var24][0] + 3, 75 - var24 % 2 * 15);
                }
                else
                {
                    this.e.AddChild(this.g[var24], var23[var24][0] + 3, 156 - var24 % 2 * 15);
                }
            }

            var1.RoomData.a1(false);
        }

        this.h = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
        ((ImageResource)this.h).SetFlipMode(5);
        this.h.SetIsVisible(false);
        this.k = -1;

        for (var15 = 0; var15 < this.m; ++var15)
        {
            var17 = (var16 = var1.RoomData.GetExitPosition(var15))[0];
            var24 = var16[1];
            if (var1.RoomData.h1(var15) == 6)
            {
                this.k = var15;
                var17 = this.e.GetWidth() - this.b[var15].GetWidth() - 22;
                var24 = this.e.GetHeight() - this.b[var15].GetHeight() - 9;
                this.b[var15].SetPosition(var17, var24);
                this.d = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
                this.d.SetIsVisible(false);
                ((ImageResource)this.d).ClipRect(40, 0, 40, 15);
                this.e.AddChild(this.d, var17, var24);
                this.i = var17 - 17;
                this.j = var24 + 1;
                this.e.AddChild(this.h, this.i, this.j);
            }

            this.e.AddChild(this.c[var15], var17, var24);
            this.e.AddChild(this.b[var15], var17, var24);
        }

        var1.b1(0);
        this.d1(var1);
        this.b1();
    }

    public bool Update(GameContext var1)
    {
        ScreenResource var2 = var1.ScreenResource;
        switch (this.a)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    this.a = 1;
                }
                break;
            case 1:
                int var3 = var1.MoveCursor(this.l, var1.RoomData.i1(), var1.RoomData.j1(), false);
                if (var1.IsKeyPressed(1048576))
                {
                    if (this.k != this.l)
                    {
                        this.a = 99;
                        var2.ExecuteTransition(0);
                        var1.SaveData.SetRoomId(var1.RoomData.GetRoomId(this.l));
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                    }
                    else
                    {
                        this.c1();
                        var1.SetCurrentScene(RoomScene.GetInstance());
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                    }
                }
                else if (var1.IsKeyPressed(4))
                {
                    if (this.k >= 0)
                    {
                        this.l = this.k;
                        this.a = 98;
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                        this.c1();
                    }
                }
                else if (var3 != -1)
                {
                    this.l = var3;
                    AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100);
                }

                this.d1(var1);
                this.b1();
                break;
            case 98:
                ++this.n;
                if (this.n > 3)
                {
                    this.n = 0;
                    var1.SetCurrentScene(RoomScene.GetInstance());
                }
                break;
            case 99:
                if (var2._transitionState == 2 && AudioManager.d1(1) != 1)
                {
                    var1.SetCurrentScene(RoomScene.GetInstance());
                }
                break;
        }
        

        return true;
    }

    public void Reset(GameContext var1)
    {
        int var2;
        if (this.f != null)
        {
            for (var2 = 0; var2 < this.f.Length; ++var2)
            {
                this.e.RemoveChild(this.f[var2]);
                this.f[var2] = null;
            }
        }

        if (this.g != null)
        {
            for (var2 = 0; var2 < this.g.Length; ++var2)
            {
                this.e.RemoveChild(this.g[var2]);
                this.g[var2] = null;
            }
        }

        for (var2 = 0; var2 < this.b.Length; ++var2)
        {
            this.e.RemoveChild(this.b[var2]);
            this.b[var2] = null;
        }

        this.e.RemoveChild(this.d);
        this.d = null;
        this.e.RemoveChild(this.h);
        this.h = null;
        var1.ScreenResource.RemoveChild(this.e);
        this.e = null;
    }

    private void b1()
    {
        int var1;
        if (this.l != this.k)
        {
            this.h.SetIsVisible(false);
            if (this.k >= 0)
            {
                ((ImageResource)this.b[this.k]).ClipRect(0, 0, 40, 15);
                this.d.SetIsVisible(false);
            }

            for (var1 = 0; var1 < this.b.Length; ++var1)
            {
                if (this.l != var1)
                {
                    this.b[var1].SetIsVisible(true);
                }
            }

        }
        else
        {
            for (var1 = 0; var1 < this.b.Length; ++var1)
            {
                this.b[var1].SetIsVisible(true);
            }

            this.h.SetIsVisible(true);
            if (this.k >= 0)
            {
                this.d.SetIsVisible(true);
            }

            GameContext.a1((ImageResource)this.h, this.i, this.j, this.o);
            ++this.o;
        }
    }

    private void c1()
    {
        this.b[this.k].SetPosition(this.b[this.k].posX + 2, this.b[this.k].posY + 2);
        this.d.SetPosition(this.d.posX + 2, this.d.posY + 2);
    }

    private void d1(GameContext var1)
    {
        for (int var9 = 0; var9 < this.m; ++var9)
        {
            int var10;
            if ((var10 = var1.RoomData.h1(var9)) == 5)
            {
                if (var9 == this.l)
                {
                    this.c[this.l].SetIsVisible(true);
                }
                else
                {
                    this.c[var9].SetIsVisible(false);
                }
            }
            else if (var10 != 6)
            {
                if (var10 == 0)
                {
                    if (var9 == this.l)
                    {
                        this.c[this.l].SetIsVisible(true);
                    }
                    else
                    {
                        this.c[var9].SetIsVisible(false);
                    }
                }
                else if (var9 == this.l)
                {
                    this.c[this.l].SetIsVisible(true);
                }
                else
                {
                    this.c[var9].SetIsVisible(false);
                }
            }
        }

    }
}
