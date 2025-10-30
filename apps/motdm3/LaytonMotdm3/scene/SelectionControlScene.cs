using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Managers;
using LaytonMotdm3.c.Resources;

namespace LaytonMotdm3.scene;

[ClassName("scene", "q")]
public class SelectionControlScene : ControlScene
{
    [MemberName("a")]
    private ImageResource _backgroundResource = null;
    [MemberName("v")]
    private ImageResource[] _elementImgResource = null;
    [MemberName("w")]
    private ImageResource _selectorResource = null;
    [MemberName("x")]
    private ScreenResource _screenResource = null;
    [MemberName("y")]
    private bool y;
    [MemberName("z")]
    private int z;
    [MemberName("A")]
    private int A;
    [MemberName("B")]
    private int[] B;
    [MemberName("C")]
    private int C;

    [MemberName("D")]
    private Image _backgroundImg;
    [MemberName("E")]
    private Image[] _elementImages;
    [MemberName("F")]
    private int[] _elementSlots;
    [MemberName("G")]
    private int[] _elementIds;
    [MemberName("H")]
    private int[] _imgPosXUnselected;
    [MemberName("I")]
    private int[] _imgPosYUnselected;
    [MemberName("J")]
    private int[] _selectorFlipMode;
    [MemberName("K")]
    private int[] _selectorPosX;
    [MemberName("L")]
    private int[] _selectorPosY;
    [MemberName("M")]
    private int[] _orderY;
    [MemberName("N")]
    private int[] _orderX;
    [MemberName("O")]
    private int[] _orderIds;
    [MemberName("P")]
    private JavaString[] _solutions;

    [FunctionName("a")]
    public static SelectionControlScene Create()
    {
        return new SelectionControlScene();
    }

    [ConstructorName("q")]
    private SelectionControlScene()
    {
    }

    [FunctionName("a")]
    public override int a1(GameContext var1, object[] var2)
    {
        SelectionControlScene var3 = (SelectionControlScene)var2[0];
        _backgroundImg = var3._backgroundImg;
        _elementImages = var3._elementImages;
        _elementSlots = var3._elementSlots;
        _elementIds = var3._elementIds;
        _imgPosXUnselected = var3._imgPosXUnselected;
        _imgPosYUnselected = var3._imgPosYUnselected;
        _selectorFlipMode = var3._selectorFlipMode;
        _selectorPosX = var3._selectorPosX;
        _selectorPosY = var3._selectorPosY;
        _orderY = var3._orderY;
        _orderX = var3._orderX;
        _orderIds = var3._orderIds;
        _solutions = var3._solutions;
        return 1;
    }

    [FunctionName("b")]
    public override void b1()
    {
        _selectorResource.SetIsVisible(true);
        _backgroundResource.AddChild((ResourceBase)_selectorResource);
    }

    [FunctionName("d")]
    public override void UpdateInternal(GameContext var1)
    {
        JavaString var2;
        if (!(var2 = GetPressedButtonCaption(var1)).Equals("answer"))
        {
            if (var2.Equals("pre_return"))
            {
                _selectorResource.SetIsVisible(false);
            }
            else if (var2.Equals("return"))
            {
                _selectorResource.SetIsVisible(false);
            }
            else if (var2.Equals("reset"))
            {
                c1();
                e1();
                b1();
            }
            else
            {
                int var7;
                if (var1.IsKeyPressed(Display.KEY_MAIN))
                {
                    if (C == -1)
                    {
                        if (B[z] != -1)
                        {
                            C = B[z];
                            _elementImgResource[C].posY = _imgPosYUnselected[z] + -10;
                            _backgroundResource.a1(_elementImgResource[C], 1);
                            _selectorResource.posY = _selectorPosY[z];
                            B[z] = -1;
                            AudioManager.PlaySound(1, n[1], 100);
                            A = 0;
                        }
                    }
                    else
                    {
                        if (B[z] != -1)
                        {
                            var7 = B[z];
                            B[z] = C;
                            _elementImgResource[B[z]].SetPosition(_imgPosXUnselected[z], _imgPosYUnselected[z]);
                            C = var7;
                            _elementImgResource[C].posY = _imgPosYUnselected[z] + -10;
                            _backgroundResource.a1(_elementImgResource[C], 1);
                        }
                        else
                        {
                            B[z] = C;
                            _elementImgResource[B[z]].SetPosition(_imgPosXUnselected[z], _imgPosYUnselected[z]);
                            C = -1;
                        }

                        AudioManager.PlaySound(1, n[1], 100);
                    }
                }
                else if ((var7 = var1.MoveCursor(z, _orderX, _orderY, false)) != -1)
                {
                    z = var7;
                    _selectorResource.SetPosition(_selectorPosX[z], _selectorPosY[z]);
                    _selectorResource.SetFlipMode(_selectorFlipMode[z]);
                    if (C != -1)
                    {
                        _elementImgResource[C].SetPosition(_imgPosXUnselected[z], _imgPosYUnselected[z] + -10);
                    }

                    AudioManager.PlaySound(1, n[8], 100);
                    A = 0;
                }

                if (C == -1)
                {
                    GameContext.a1(_selectorResource, _selectorPosX[z], _selectorPosY[z], A);
                    ++A;
                }

            }
        }
        else
        {
            if (C != -1)
            {
                if (B[z] != -1)
                {
                    return;
                }

                B[z] = C;
                _elementImgResource[B[z]].SetPosition(_imgPosXUnselected[z], _imgPosYUnselected[z]);
                C = -1;
            }

            JavaString[] var3 = new JavaString[B.Length];

            bool isEmpty;
            int j;
            for (int var4 = 0; var4 < B.Length; ++var4)
            {
                isEmpty = false;

                for (j = 0; j < _solutions.Length; ++j)
                {
                    if (IsSolutionSlotEmpty(_solutions[j], var4))
                    {
                        isEmpty = true;
                        break;
                    }
                }

                JavaString var10 = isEmpty ? "-" : (B[var4] == -1 ? "x" : _elementIds[B[var4]].ToString());
                var3[_orderIds[var4]] = var10;
            }

            JavaString var8 = "";

            for (int var9 = 0; var9 < var3.Length; ++var9)
            {
                if (var9 != 0)
                {
                    var8 = var8 + ",";
                }

                var8 = var8 + var3[var9];
            }

            isEmpty = false;

            for (j = 0; j < _solutions.Length; ++j)
            {
                if (var8.Equals(_solutions[j]))
                {
                    isEmpty = true;
                    break;
                }
            }

            if (isEmpty)
            {
                a1(var1, true);
            }
            else
            {
                a1(var1, false);
            }
        }
    }

    [FunctionName("a")]
    public override void a1(ScreenResource var1)
    {
        _screenResource = var1;
        if (_backgroundResource == null)
        {
            _backgroundResource = ImageResource.Create(_backgroundImg);
        }

        if (_elementImgResource == null)
        {
            _elementImgResource = new ImageResource[_elementImages.Length];

            for (int var2 = 0; var2 < _elementImgResource.Length; ++var2)
            {
                _elementImgResource[var2] = ImageResource.Create(_elementImages[var2]);
            }
        }

        if (_selectorResource == null)
        {
            _selectorResource = ImageResource.Create(f);
            _selectorResource.SetIsVisible(false);
        }

        _screenResource.SetIsVisible(true);
        y = false;
        B = new int[_imgPosXUnselected.Length];
    }

    [FunctionName("d")]
    public override void d1()
    {
        if (!y)
        {
            _screenResource.SetIsVisible(false);
        }
    }

    [FunctionName("c")]
    public override void c1()
    {
        int var1;
        if (_screenResource != null)
        {
            _screenResource.RemoveChild(_backgroundResource);

            for (var1 = 0; var1 < _elementImgResource.Length; ++var1)
            {
                _backgroundResource.RemoveChild(_elementImgResource[var1]);
            }

            _backgroundResource.RemoveChild(_selectorResource);
        }

        if (g1() != 9 && g1() != 4 && g1() != 11)
        {
            for (var1 = 0; var1 < B.Length; ++var1)
            {
                B[var1] = -1;

                for (int var2 = 0; var2 < _elementImgResource.Length; ++var2)
                {
                    if (_elementSlots[var2] == var1)
                    {
                        B[var1] = var2;
                        break;
                    }
                }
            }

            for (var1 = 0; var1 < _elementImgResource.Length; ++var1)
            {
                _elementImgResource[var1].SetPosition(_imgPosXUnselected[_elementSlots[var1]], _imgPosYUnselected[_elementSlots[var1]]);
            }

            C = -1;
            A = 0;

            for (var1 = 0; var1 < _imgPosXUnselected.Length; ++var1)
            {
                if (_orderY[var1] == 0 && _orderX[var1] == 0)
                {
                    z = var1;
                    _selectorResource.SetPosition(_selectorPosX[z], _selectorPosY[z]);
                    _selectorResource.SetFlipMode(_selectorFlipMode[z]);
                    break;
                }
            }
        }

        y = true;
    }

    [FunctionName("e")]
    public override void e1()
    {
        _screenResource.SetIsVisible(true);
        if (_screenResource != null)
        {
            _screenResource.AddChild(_backgroundResource, centerPosX, centerPosY);
            _screenResource.a1(_backgroundResource, -2);

            for (int var1 = 0; var1 < _elementImgResource.Length; ++var1)
            {
                _backgroundResource.AddChild((ResourceBase)_elementImgResource[var1]);
            }

            if (C != -1)
            {
                _backgroundResource.AddChild((ResourceBase)_elementImgResource[C]);
            }
        }

        y = false;
    }

    [FunctionName("f")]
    public override void ResetInternal()
    {
        if (_backgroundResource != null)
        {
            _backgroundResource.Dispose();
            _backgroundResource = null;
        }

        int var1;
        if (_elementImgResource != null)
        {
            for (var1 = 0; var1 < _elementImgResource.Length; ++var1)
            {
                _elementImgResource[var1].Dispose();
            }

            _elementImgResource = null;
        }

        if (_selectorResource != null)
        {
            _selectorResource.Dispose();
            _selectorResource = null;
        }

        _screenResource = null;
        B = null;
        if (_backgroundImg != null)
        {
            _backgroundImg.Dispose();
            _backgroundImg = null;
        }

        if (_elementImages != null)
        {
            for (var1 = 0; var1 < _elementImages.Length; ++var1)
            {
                _elementImages[var1].Dispose();
            }

            _elementImages = null;
        }

        _elementSlots = null;
        _elementIds = null;
        _imgPosXUnselected = null;
        _imgPosYUnselected = null;
        _selectorFlipMode = null;
        _selectorPosX = null;
        _selectorPosY = null;
        _orderY = null;
        _orderX = null;
        _orderIds = null;
        _solutions = null;
    }

    [FunctionName("a")]
    private static bool IsSolutionSlotEmpty(JavaString solution, int slot)
    {
        int currentSlot = 0;

        for (int i = 0; i < solution.Length; ++i)
        {
            if (solution[i] == ',')
            {
                if (currentSlot == slot)
                {
                    if (solution[i - 1] == '-')
                    {
                        return true;
                    }

                    return false;
                }

                ++currentSlot;
            }
            else if (i == solution.Length - 1 && slot == currentSlot + 1)
            {
                if (solution[i] == '-')
                {
                    return true;
                }

                return false;
            }
        }

        return false;
    }

    [FunctionName("a")]
    public static object Read(nazo.PuzzleManager var0, BinaryReader var1)
    {
        SelectionControlScene var2 = Create();

        try
        {
            var0.ReadInt32(var1.BaseStream);
            int var4 = var0.ReadInt32(var1.BaseStream);
            var2._backgroundImg = var0.GetLoadedImage(var4);
            int var6 = var0.ReadInt32(var1.BaseStream);
            int var7 = var0.ReadInt32(var1.BaseStream);
            int var8 = var0.ReadInt32(var1.BaseStream);
            var2._elementImages = new Image[var6];
            var2._elementSlots = new int[var6];
            var2._elementIds = new int[var6];

            int var9;
            for (var9 = 0; var9 < var6; ++var9)
            {
                var2._elementImages[var9] = var0.GetLoadedImage(var0.ReadInt32(var1.BaseStream));
                var2._elementSlots[var9] = var0.ReadInt32(var1.BaseStream);
                var2._elementIds[var9] = var0.ReadInt32(var1.BaseStream);
            }

            var2._imgPosXUnselected = new int[var7];
            var2._imgPosYUnselected = new int[var7];
            var2._selectorFlipMode = new int[var7];
            var2._selectorPosX = new int[var7];
            var2._selectorPosY = new int[var7];
            var2._orderY = new int[var7];
            var2._orderX = new int[var7];
            var2._orderIds = new int[var7];

            for (var9 = 0; var9 < var7; ++var9)
            {
                var2._imgPosXUnselected[var9] = var0.ReadInt32(var1.BaseStream);
                var2._imgPosYUnselected[var9] = var0.ReadInt32(var1.BaseStream);
                var2._selectorFlipMode[var9] = var0.ReadInt32(var1.BaseStream);
                var2._selectorPosX[var9] = var0.ReadInt32(var1.BaseStream);
                var2._selectorPosY[var9] = var0.ReadInt32(var1.BaseStream);
                var2._orderY[var9] = var0.ReadInt32(var1.BaseStream);
                var2._orderX[var9] = var0.ReadInt32(var1.BaseStream);
                var2._orderIds[var9] = var0.ReadInt32(var1.BaseStream);
            }

            var2._solutions = new JavaString[var8];

            for (var9 = 0; var9 < var8; ++var9)
            {
                var2._solutions[var9] = var0.ReadString(var1);
            }
        }
        catch (Exception var10)
        {
            var2 = null;
        }

        return var2;
    }
}
