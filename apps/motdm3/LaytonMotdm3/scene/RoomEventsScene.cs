using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Managers;
using LaytonMotdm3.c.Resources;

namespace LaytonMotdm3.scene;

// Scene for investigating and interacting with a room's interior

[ClassName("scene", "a")]
public class RoomEventsScene : IScene
{
    [MemberName("b")]
    private int _state;
    [MemberName("c")]
    private ResourceBase c;
    [MemberName("d")]
    private ResourceBase[] d;
    [MemberName("e")]
    private ResourceBase e;
    [MemberName("f")]
    private ResourceBase f;
    [MemberName("g")]
    private ResourceBase g;
    [MemberName("h")]
    private ResourceBase _resourceBase;
    [MemberName("i")]
    private ResourceBase i;
    [MemberName("j")]
    private ResourceBase j;
    [MemberName("k")]
    private ResourceBase k;
    [MemberName("l")]
    private ResourceBase l;
    [MemberName("m")]
    private ResourceBase m;
    [MemberName("n")]
    private ResourceBase n;
    [MemberName("o")]
    private ResourceBase[] o;
    [MemberName("p")]
    private ResourceBase[] p;
    [MemberName("q")]
    private ResourceBase[] q;
    [MemberName("r")]
    private ResourceBase r;
    [MemberName("s")]
    private ScriptTextResource s;
    [MemberName("t")]
    private bool t;
    [MemberName("u")]
    private int _roomEventId;
    [MemberName("v")]
    private int v;
    [MemberName("w")]
    private int _eventType;
    [MemberName("x")]
    private int x;
    [MemberName("y")]
    private int y;
    [MemberName("z")]
    private int z;
    [MemberName("A")]
    private int[][] _roomEventPositions;
    [MemberName("B")]
    private int _roomEventCount;
    [MemberName("a")]
    protected int[] a2;
    [MemberName("C")]
    private int C;
    [MemberName("D")]
    private bool D;
    [MemberName("E")]
    private bool E;
    [MemberName("F")]
    private int F;

    [MemberName("G")]
    private static RoomEventsScene Instance = new();

    [ConstructorName("a")]
    private RoomEventsScene()
    {
    }

    [FunctionName("a")]
    public static RoomEventsScene GetInstance()
    {
        return Instance;
    }

    [FunctionName("a")]
    public void Setup(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        v = -1;
        E = false;
        F = 0;
        _state = 0;
        _roomEventPositions = gameContext.RoomData.GetEventPositions();
        _roomEventCount = gameContext.RoomData.GetEventCount();
        if (GameContext.RoomEventId == -1)
        {
            _roomEventId = 0;
        }
        else
        {
            _roomEventId = GameContext.RoomEventId;
            if (_roomEventPositions.Length <= _roomEventId)
            {
                _roomEventId = 0;
            }
        }

        c = ImageResource.Create(gameContext.ScriptResourceFileManager.GetLoadedImage(gameContext.RoomData.GetBackground()));
        if (gameContext.RoomData.IsBackgroundFlipped())
        {
            ((ImageResource)c).SetFlipMode(Graphics.FLIP_HORIZONTAL);
        }
        else
        {
            ((ImageResource)c).SetFlipMode(Graphics.FLIP_NONE);
        }

        var2.AddChild(c, (240 - c.GetWidth()) / 2, 0);
        int var3;
        int var5;
        if ((var3 = gameContext.RoomData.GetBackgroundObjectCount()) > 0)
        {
            JavaString var4 = "bgoj_" + Helper.ToStringPad(gameContext.SaveData.GetRoomId() + 1, 3) + ".dat";
            d = gameContext.RoomData.a1(gameContext.ScriptResourceFileManager, var4);

            for (var5 = 0; var5 < var3; ++var5)
            {
                if (gameContext.RoomData.IsBackgroundObjectFlipped(var5))
                {
                    ((AnimatedImageResource)d[var5]).SetFlipMode(Graphics.FLIP_HORIZONTAL);
                }
                else
                {
                    ((AnimatedImageResource)d[var5]).SetFlipMode(Graphics.FLIP_NONE);
                }

                int[] var6 = gameContext.RoomData.GetBackgroundPosition(var5);
                c.AddChild(d[var5], var6[0], var6[1]);
            }
        }

        f = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
        ((ImageResource)f).ClipRect(0, 0, 40, 15);
        g = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_back.gif"));
        ((ImageResource)g).ClipRect(40, 0, 40, 15);
        int var7 = c.GetWidth() - f.GetWidth() - 22;
        var5 = c.GetHeight() - f.GetHeight() - 9;
        c.AddChild(g, var7, var5);
        c.AddChild(f, var7, var5);
        _resourceBase = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_cur.gif"));
        ((ImageResource)_resourceBase).SetFlipMode(Graphics.FLIP_ROTATE_RIGHT);
        _resourceBase.SetIsVisible(false);
        y = var7 - 17;
        z = var5 + 2;
        c.AddChild(_resourceBase, y, z);
        e = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_main30.gif"));
        if (_roomEventCount > 0)
        {
            c.AddChild(e, _roomEventPositions[_roomEventId][0], _roomEventPositions[_roomEventId][1]);
            g.SetIsVisible(false);
        }
        else
        {
            g.SetIsVisible(true);
            _resourceBase.SetIsVisible(true);
        }

        j = ImageResource.Create(GameContext.FileManager.GetLoadedImage("c00_bg_0.gif"));
        s = ScriptTextResource.Create("　");
        k = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event4.gif"));
        ((ImageResource)k).b1(0, 0, 14, 14);
        i = ImageResource.Create(GameContext.FileManager.GetLoadedImage("win_small2.gif"));
        i.AddChild(j, 14, 11);
        i.AddChild(s, 52, 4);
        i.AddChild(k, i.GetWidth() - k.GetWidth() - 3, i.GetHeight() - k.GetHeight() - 3);
        i.SetIsVisible(false);
        i.ExecuteFullTransition(0, 4);
        l = ImageResource.Create(GameContext.FileManager.GetLoadedImage("i_event0.gif"));
        l.SetIsVisible(false);
        c.AddChild(l);
        m = ImageResource.Create(GameContext.FileManager.GetLoadedImage("hakken.gif"));
        m.SetIsVisible(false);
        c.AddChild(m);
        c.AddChild(i, (c.GetWidth() - i.GetWidth()) / 2, c.GetHeight() / 2 - i.GetHeight() / 2);
        gameContext.RoomData.SetPlayerState(0);
        D = false;
        gameContext.b1(0);
        a1(gameContext.RoomData.GetEventType(_roomEventId));
        t = false;

        for (int var8 = 0; var8 < _roomEventCount; ++var8)
        {
            if (gameContext.RoomData.GetEventType(var8) == -1)
            {
                t = true;
                break;
            }
        }

        if (!t)
        {
            g.SetIsVisible(false);
            f.SetIsVisible(false);
            _resourceBase.SetIsVisible(false);
        }
    }

    [FunctionName("b")]
    public bool Update(GameContext gameContext)
    {
        ScreenResource var2 = gameContext.ScreenResource;
        switch (_state)
        {
            case 0:
                if (var2._transitionState == 0)
                {
                    _state = 1;
                }
                break;

            case 1:
                GameContext.a1((ImageResource)_resourceBase, y, z, x);
                ++x;
                int var3 = gameContext.MoveCursor(_roomEventId, gameContext.RoomData.GetEventRanksX(), gameContext.RoomData.GetEventRanksY(), false);
                if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    if (gameContext.RoomData.GetEventType(_roomEventId) == -1)
                    {
                        _state = 99;
                        b1();
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                        gameContext.RoomData.a1(false);
                    }
                    else
                    {
                        _eventType = gameContext.RoomData.GetEventType(_roomEventId);
                        GameContext.RoomEventId = _roomEventId;
                        a2 = gameContext.RoomData.GetEventPosition(_roomEventId);
                        if (_eventType == 1)
                        {
                            bool var4 = false;
                            s.SetText(gameContext.RoomData.m1(gameContext.RoomData.GetEventTextId(_roomEventId)) + "[end]");
                            if (gameContext.RoomData.GetEventSpeakerId(_roomEventId) == 0)
                            {
                                ((ImageResource)j).SetImage(GameContext.FileManager.GetLoadedImage("c00_bg_0.gif"));
                            }
                            else
                            {
                                ((ImageResource)j).SetImage(GameContext.FileManager.GetLoadedImage("c01_bg_0.gif"));
                            }

                            a1(false);
                            i.ExecuteFullTransition(1, 4);
                            i.SetIsVisible(true);
                            _state = 2;
                            AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                        }
                        else if (_eventType != 0 && _eventType != 3 && _eventType != 100)
                        {
                            if (_eventType == 5)
                            {
                                gameContext.RoomData.SetEventId(gameContext.RoomData.GetEventSpeakerId(_roomEventId));
                                if (gameContext.RoomData.GetEventState(gameContext.RoomData.GetEventId(), 2))
                                {
                                    AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                                    a1(false);
                                    _state = 97;
                                    return true;
                                }

                                a1(false);
                                a2[0] -= ((ImageResource)m).GetWidth() / 2;
                                a2[1] -= ((ImageResource)m).GetHeight();
                                m.SetPosition(a2[0], a2[1]);
                                C = 3;
                                a1(m, a2, -7, C);
                                D = true;
                                _state = 3;
                                AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                                gameContext.ScreenResource.MarkVisible();
                            }
                            else if (_eventType != 100 && _eventType == 101)
                            {
                                _state = 4;
                                o[0].SetIsVisible(false);
                                o[1].SetIsVisible(true);

                                int var5;
                                for (var5 = 0; var5 < q.Length; ++var5)
                                {
                                    q[var5].SetIsVisible(true);
                                    ((AnimatedImageResource)q[var5]).SetAnimationBehaviour(258);
                                }

                                for (var5 = 0; var5 < d.Length; ++var5)
                                {
                                    d[var5].ExecuteTransition(0, 5);
                                    p[var5].ExecuteTransition(0, 5);
                                }

                                AudioManager.PlaySound(1, gameContext.ScriptResourceFileManager.GetLoadedSound("se_046.mld"), 100);
                                AudioManager.PlaySound(2, gameContext.ScriptResourceFileManager.GetLoadedSound("se_047.mld"), 100);
                            }
                        }
                        else
                        {
                            gameContext.RoomData.SetEventId(gameContext.RoomData.GetEventSpeakerId(_roomEventId));
                            if (gameContext.RoomData.GetEventState(gameContext.RoomData.GetEventId(), 2))
                            {
                                AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                                a1(false);
                                _state = 97;
                                return true;
                            }

                            a1(false);
                            a2[0] -= ((ImageResource)l).GetWidth() / 2;
                            l.SetPosition(a2[0], a2[1]);
                            C = 5;
                            a1(l, a2, -50, C);
                            D = true;
                            _state = 3;
                            AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_011.mld"), 100);
                            if (_eventType == 0 || _eventType == 3)
                            {
                                gameContext.ScreenResource.MarkVisible();
                            }
                        }
                    }
                }
                else if (gameContext.IsKeyPressed(Display.KEY_TWO))
                {
                    if (gameContext.SaveData.GetRoomId() != 100)
                    {
                        _roomEventId = _roomEventCount;
                        _state = 99;
                        a1(-1);
                        b1();
                        AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_004.mld"), 100);
                        gameContext.RoomData.a1(false);
                    }
                }
                else if (var3 != -1)
                {
                    _roomEventId = var3;
                    a1(gameContext.RoomData.GetEventType(_roomEventId));
                    AudioManager.PlaySound(1, GameContext.FileManager.GetLoadedSound("se_018.mld"), 100);
                }
                break;
            
            case 2:
                if (gameContext.IsKeyPressed(Display.KEY_MAIN))
                {
                    i.ExecuteFullTransition(0, 4);
                    if (E)
                    {
                        gameContext.RoomData.SetEventId(62);
                        v = 0;
                        _state = 98;
                        var2.ExecuteTransition(0);
                    }
                    else
                    {
                        a1(true);
                        _state = 1;
                    }
                }
                break;
            
            case 3:
                if (n.h1())
                {
                    if (D)
                    {
                        D = false;
                        a1(n, a2, 0, C);
                    }
                    else
                    {
                        if (_eventType != 5)
                        {
                            n.SetIsVisible(false);
                        }

                        if (_eventType == 0 || _eventType == 3 || _eventType == 5)
                        {
                            var2.ExecuteTransition(0);
                            v = 0;
                            _state = 98;
                        }
                    }
                }
                break;
            
            case 97:
                ++F;
                if (F > 2)
                {
                    F = 0;
                    a1(true);
                    _state = 1;
                    if (r != null)
                    {
                        r.SetIsVisible(false);
                    }
                }
                break;
            
            case 98:
                if (var2._transitionState == 2)
                {
                    _state = 99;
                }
                break;
            
            case 99:
                if (v == 0)
                {
                    gameContext.SetCurrentScene(EventScene.GetInstance());
                }
                else
                {
                    gameContext.SetCurrentScene(RoomScene.GetInstance());
                }
                break;
        }

        return true;
    }

    [FunctionName("c")]
    public void Reset(GameContext var1)
    {
        i.RemoveChild(k);
        k = null;
        i.RemoveChild(j);
        j = null;
        i.RemoveChild(s);
        s = null;
        c.RemoveChild(i);
        i = null;
        c.RemoveChild(e);
        e = null;
        c.RemoveChild(f);
        f = null;
        c.RemoveChild(g);
        g = null;
        c.RemoveChild(_resourceBase);
        _resourceBase = null;
        c.RemoveChild(l);
        l = null;
        c.RemoveChild(m);
        m = null;
        if (d != null)
        {
            for (int var2 = 0; var2 < d.Length; ++var2)
            {
                c.RemoveChild(d[var2]);
                d[var2] = null;
            }
        }

        var1.ScreenResource.RemoveChild(c);
        c = null;
        n = null;
    }

    [FunctionName("a")]
    private void a1(bool var1)
    {
        e.SetIsVisible(var1);
        if (t)
        {
            f.SetIsVisible(var1);
        }
    }

    [FunctionName("a")]
    private void a1(int var1)
    {
        if (var1 == -1)
        {
            e.SetIsVisible(false);
            _resourceBase.SetIsVisible(true);
            ((ImageResource)g).SetIsVisible(true);
        }
        else
        {
            e.SetPosition(_roomEventPositions[_roomEventId][0], _roomEventPositions[_roomEventId][1]);
            e.SetIsVisible(true);
            _resourceBase.SetIsVisible(false);
            ((ImageResource)g).SetIsVisible(false);
        }
    }

    [FunctionName("b")]
    private void b1()
    {
        f.SetPosition(f.posX + 2, f.posY + 2);
        g.SetPosition(g.posX + 2, g.posY + 2);
    }

    [FunctionName("a")]
    private void a1(ResourceBase var1, int[] var2, int var3, int var4)
    {
        n = var1;
        n.a1(var2[0], var2[1] + var3, var4);
        n.SetIsVisible(true);
    }
}
