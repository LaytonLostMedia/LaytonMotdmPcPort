using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm6.c;
using LaytonMotdm6.c.Managers;
using LaytonMotdm6.c.Resources;

namespace LaytonMotdm6.scene;

[ClassName("scene", "n")]
public class SaveGameScene : IScene
{
    [MemberName("a")]
    private static SaveGameScene Instance = new();
    
    [MemberName("b")]
    private int b;
    [MemberName("c")]
    private data.SaveData[] _saveSlots;
    [MemberName("d")]
    private GameFileManager d;
    [MemberName("e")]
    private int e = 1;
    [MemberName("f")]
    private int f = 0;
    [MemberName("g")]
    private bool g = false;
    [MemberName("h")]
    private ResourceBase[] h = new ResourceBase[13];
    [MemberName("i")]
    private static int[][] i = new int[][] { new int[] { 28, 143 }, new int[] { 124, 143 } };
    [MemberName("j")]
    private static int j = 0;

    [ConstructorName("n")]
    private SaveGameScene()
    {
    }

    [FunctionName("a")]
    public static SaveGameScene GetInstance(int var0)
    {
        j = var0;
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        e = 1;
        f = 0;
        g = false;
        d = new GameFileManager();
        _saveSlots = new data.SaveData[1];

        for (int var3 = 0; var3 < 1; ++var3)
        {
            _saveSlots[var3] = new data.SaveData();
            _saveSlots[var3].LoadSlot(var3);
        }

        GameContext.SetBackground(Graphics.GetColorOfRGB(0, 0, 0));
        JavaString[] var5 = new JavaString[] { "bg_hanyou.jpg", "win_savedate.gif", "win_seve.gif" };
        if (d.LoadFiles(var5))
        {
            h[0] = ImageResource.Create(d.GetLoadedImage("bg_hanyou.jpg"));
            var2.AddChild(h[0], (240 - h[0].GetWidth()) / 2, 0);
            h[1] = ImageResource.Create(d.GetLoadedImage("win_savedate.gif"));
            h[0].AddChild(h[1], (h[0].GetWidth() - h[1].GetWidth()) / 2, 14);
            h[2] = ImageResource.Create(d.GetLoadedImage("win_seve.gif"));
            h[0].AddChild(h[2], (h[0].GetWidth() - h[2].GetWidth()) / 2, 64);
            h[3] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
            h[0].AddChild(h[3], i[e][0], i[e][1]);
            ((ImageResource)h[3]).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
            h[4] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0.gif"));
            h[5] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn0f.gif"));
            h[6] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1.gif"));
            h[7] = ImageResource.Create(GameContext.FileManager.GetLoadedImage("yesno_btn1f.gif"));

            for (int var4 = 0; var4 < 2; ++var4)
            {
                h[0].AddChild(h[4 + var4], 38, 136);
                h[0].AddChild(h[6 + var4], 134, 136);
            }

            h[8] = TextResource.Create("セーブファイルなし");
            h[0].AddChild(h[8], h[0].GetWidth() / 2, 26);
            ((TextResource)h[8]).SetAnchorType(1);
            h[9] = TextResource.Create("解いたナゾの数○○");
            h[0].AddChild(h[9], h[0].GetWidth() / 2, 40);
            ((TextResource)h[9]).SetAnchorType(1);
            h[10] = TextResource.Create("これまでの経過を記録しますか？");
            h[11] = TextResource.Create("以前のデータは上書きされます。");
            h[0].AddChild(h[10], h[0].GetWidth() / 2, 100);
            h[0].AddChild(h[11], h[0].GetWidth() / 2, 113);
            ((TextResource)h[10]).SetAnchorType(1);
            ((TextResource)h[11]).SetAnchorType(1);
            h[12] = TextResource.Create("データをセーブしています…");
            h[0].AddChild(h[12], h[0].GetWidth() / 2, 127);
            ((TextResource)h[12]).SetAnchorType(1);
            h[12].SetIsVisible(false);
            SetSaveAvailableText();
            SetQuestionsSolvedText();
            b1(e);
            var2.ExecuteTransition(1);
            b = 0;
            if (j == 2)
            {
                e = 0;
                g = true;
                d1(GameContext);
                _saveSlots[0].LoadSlot(0);
                SetSaveAvailableText();
                SetQuestionsSolvedText();
                h[4].SetIsVisible(false);
                h[5].SetIsVisible(false);
                h[6].SetIsVisible(false);
                h[7].SetIsVisible(false);
                h[10].SetIsVisible(false);
                h[11].SetIsVisible(false);
                h[3].SetIsVisible(false);
                h[12].SetIsVisible(true);
                b = 2;
                return;
            }
        }
        else
        {
            b = 99;
        }
    }

    [FunctionName("a")]
    private void SetSaveAvailableText()
    {
        if (_saveSlots[0].GetName() == "")
        {
            ((TextResource)h[8]).SetText("セーブファイルなし");
        }
        else
        {
            ((TextResource)h[8]).SetText("セーブファイルあり");
        }
    }

    [FunctionName("b")]
    private void SetQuestionsSolvedText()
    {
        int var1 = _saveSlots[0].GetQuestionsSolvedCount();
        JavaString[] var2 = new JavaString[] { "０", "１", "２", "３", "４", "５", "６", "７", "８", "９", "１０", "１１", "１２" };
        ((TextResource)h[9]).SetText("解いたナゾの数" + var2[var1]);
    }

    [FunctionName("b")]
    public bool Update(GameContext GameContext)
    {
        ScreenResource var2 = GameContext.ScreenResource;
        bool var3 = false;
        switch (b)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    b = 1;
                }
                break;
            case 1:
                if (GameContext.IsKeyPressed(Display.KEY_LEFT))
                {
                    --e;
                    if (e < 0)
                    {
                        e = 0;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                }

                if (GameContext.IsKeyPressed(Display.KEY_RIGHT))
                {
                    ++e;
                    if (e > 1)
                    {
                        e = 1;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100, 0);
                    }
                }

                if (GameContext.IsKeyPressed(Display.KEY_MAIN) && !g)
                {
                    if (e == 0)
                    {
                        if (!g)
                        {
                            AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100, 0);
                        }

                        g = true;
                        d1(GameContext);
                        _saveSlots[0].LoadSlot(0);
                        SetSaveAvailableText();
                        SetQuestionsSolvedText();
                        b = 2;
                    }
                    else
                    {
                        AudioManager.b1(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100, 0);
                        h[6].SetPosition(h[6].posX + 2, h[6].posY + 2);
                        h[7].SetPosition(h[7].posX + 2, h[7].posY + 2);
                        var3 = true;
                    }
                }

                b1(e);
                if (var3)
                {
                    b = 99;
                    var2.ExecuteTransition(0);
                }
                break;
            case 2:
                f += GameContext.d1();
                if (f < 300)
                {
                    h[4].SetPosition(40, 138);
                    h[5].SetPosition(40, 138);
                }
                else
                {
                    h[4].SetIsVisible(false);
                    h[5].SetIsVisible(false);
                    h[6].SetIsVisible(false);
                    h[7].SetIsVisible(false);
                    h[10].SetIsVisible(false);
                    h[11].SetIsVisible(false);
                    h[3].SetIsVisible(false);
                    h[12].SetIsVisible(true);
                }

                if (f > 1000)
                {
                    b = 99;
                    var2.ExecuteTransition(0);
                }
                break;
            case 99:
                if (var2._transitionState == 2)
                {
                    if (j == 2)
                    {
                        if (GameContext.RoomData.GetGameMode() == 1)
                        {
                            GameContext.SetCurrentScene(EventScene.GetInstance());
                        }
                        else if (GameContext.RoomData.GetGameMode() == 11)
                        {
                            GameContext.SetCurrentScene(StartupScene.GetInstance(false));
                        }
                        else
                        {
                            GameContext.SetCurrentScene(RoomScene.GetInstance());
                        }
                    }
                    else
                    {
                        GameContext.SetCurrentScene(IngameMenuScene.GetInstance());
                    }
                }
                break;
        }

        return true;
    }

    [FunctionName("d")]
    private void d1(GameContext var1)
    {
        var1.SaveData.a1(var1);
        var1.SaveData.n1(e);
        var1.SaveData.LoadSlot(e);
        var1.RoomData.Load(var1);
    }

    [FunctionName("b")]
    private void b1(int var1)
    {
        h[3].posX = i[var1][0];
        h[5].SetIsVisible(false);
        h[7].SetIsVisible(false);
        h[5 + var1 * 2].SetIsVisible(true);
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        for (int var2 = 12; var2 >= 0; --var2)
        {
            if (h[var2] != null)
            {
                h[var2].h1();
                h[var2] = null;
            }
        }

        try
        {
            d.Reset();
        }
        catch (Exception var3)
        {
        }

        d = null;
        _saveSlots = null;
    }
}
