using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm3.c;
using LaytonMotdm3.c.Resources;
using LaytonMotdm3.scene;

namespace LaytonMotdm3.nazo;

[ClassName("nazo", "c")]
public class PuzzleManager
{
    [MemberName("k")]
    private static PuzzleManager k;

    [MemberName("a")]
    public int _resourceSectionSize = 0;

    [MemberName("l")]
    private int _resourceObjectCount;
    [MemberName("m")]
    private object[] _resourceObjects;

    [MemberName("b")]
    public JavaString[] _resourceNames;
    [MemberName("c")]
    public int _objectCount;
    [MemberName("d")]
    public object[] _objects = null;
    [MemberName("e")]
    public int[] _intValues = null;
    [MemberName("f")]
    public short[] _shortValues = null;
    [MemberName("g")]
    public byte[] _byteValues = null;
    [MemberName("h")]
    public JavaString[] _stringValues = null;
    [MemberName("i")]
    public JavaString[] i = null;
    [MemberName("j")]
    public int _layoutElementType = -1;

    [MemberName("n")]
    private static int n = 0;

    [FunctionName("a")]
    private void a1(object paramObject)
    {
        _objects[_objectCount] = paramObject;
        _objectCount++;
    }

    [FunctionName("a")]
    public void Reset()
    {
        if (_resourceNames != null)
        {
            for (byte b1 = 0; b1 < _resourceNames.Length; b1++)
            {
                if (_resourceNames[b1].IndexOf(".gif") != -1 || _resourceNames[b1].IndexOf(".jpg") != -1)
                {
                    Image image;
                    if ((image = GetLoadedImage(_resourceNames[b1])) != null)
                        image.Dispose();
                }
                else if (_resourceNames[b1].IndexOf(".mld") != -1)
                {
                    MediaSound mediaSound;
                    if ((mediaSound = GetLoadedSound(_resourceNames[b1])) != null)
                        mediaSound.Dispose();
                }
                else if (_resourceNames[b1].IndexOf(".dat") != -1)
                {
                    GetLoadedData(_resourceNames[b1]);
                }
            }
            _resourceNames = null;
        }
        if (_resourceObjects != null)
            _resourceObjects = null;
        _resourceNames = null;
        _intValues = null;
        _shortValues = null;
        _byteValues = null;
        _stringValues = null;
        i = null;
        for (byte b = 0; b < _objectCount; b++)
        {
            object @object;
            Type clazz;
            if ((clazz = (@object = _objects[b]).GetType()).Name == "Lnazo.oObjectItem")
            {
                PuzzleFactory puzzleFactory;
                (puzzleFactory = (PuzzleFactory)_objects[b]).Reset();
            }
        }
        _objects = null;
    }

    [FunctionName("a")]
    public static IScene GetSolutionInputControl(ScreenResource paramc, byte[] nazoData, byte[] resourceData, int paramInt)
    {
        PuzzleManager c1 = new PuzzleManager();
        PuzzleManager c2;
        (c2 = new PuzzleManager()).ReadIntValues(resourceData);
        n = 1 - c2._intValues[1];
        c1.Load(paramc, nazoData);
        k = c1;
        object var6 = null;
        if (c2.Load(paramc, resourceData))
        {
            switch (c2._layoutElementType)
            {
                case 1:
                    var6 = ButtonControlScene.GetInstance();
                    break;
                case 2:
                    var6 = SwitchControlScene.Create();
                    break;
                case 3:
                    var6 = SelectionControlScene.Create();
                    break;
                case 4:
                    var6 = LineControlScene.Create();
                    break;
                case 5:
                    var6 = KeyboardControlScene.Create();
                    break;
            }
          ((ControlScene)var6)?.a1(c1, c2, paramInt);
        }
        k = null;
        return (IScene)var6;
    }

    [FunctionName("a")]
    private int[] ReadIntValues(Stream inputStream, int count)
    {
        int[] arrayOfInt = new int[count];
        try
        {
            for (byte b = 0; b < count; b++)
                arrayOfInt[b] = ReadInt32(inputStream);
        }
        catch (Exception exception) { }
        return arrayOfInt;
    }

    [FunctionName("a")]
    private object GetLoadedObject(JavaString paramString)
    {
        for (byte b = 0; b < _resourceNames.Length; b++)
        {
            if (_resourceNames[b] == paramString)
                return _resourceObjects[b];
        }
        return null;
    }

    [FunctionName("d")]
    private object GetLoadedObject(int paramInt)
    {
        return (paramInt < 0 || paramInt >= _resourceObjects.Length) ? null : _resourceObjects[paramInt];
    }

    [FunctionName("b")]
    private Image GetLoadedImage(JavaString paramString)
    {
        return (Image)GetLoadedObject(paramString);
    }

    [FunctionName("a")]
    public Image GetLoadedImage(int paramInt)
    {
        return (Image)GetLoadedObject(paramInt);
    }

    [FunctionName("b")]
    public MediaSound GetLoadedSound(int paramInt)
    {
        object @object;
        return ((@object = GetLoadedObject(paramInt)) == null) ? null : (MediaSound)@object;
    }

    [FunctionName("c")]
    private MediaSound GetLoadedSound(JavaString paramString)
    {
        object @object;
        return ((@object = GetLoadedObject(paramString)) == null) ? null : (MediaSound)@object;
    }

    [FunctionName("d")]
    private byte[] GetLoadedData(JavaString paramString)
    {
        return (byte[])GetLoadedObject(paramString);
    }

    [FunctionName("c")]
    public PalettedImage GetLoadedPalettedImage(int paramInt)
    {
        return (PalettedImage)GetLoadedObject(paramInt);
    }

    [FunctionName("a")]
    private bool Load(ScreenResource paramc, byte[] resourceData)
    {
        bool boolValue = true;
        if (resourceData == null)
            return false;
        BinaryReader dataStream = new BinaryReader(new MemoryStream(resourceData));
        try
        {
            while (dataStream.BaseStream.Position < dataStream.BaseStream.Length)
            {
                JavaString str = "";
                str = str + (char)dataStream.ReadByte();
                str = str + (char)dataStream.ReadByte();
                str = str + (char)dataStream.ReadByte();

                _resourceSectionSize = ReadInt32(dataStream.BaseStream);

                if (str == "res")
                {
                    int i = ReadInt32(dataStream.BaseStream);
                    _resourceObjectCount = 0;
                    _resourceObjects = new object[i];
                    _resourceNames = new JavaString[i];
                    int b = -1;
                label207: while (true)
                    {
                        b++;

                        if (b >= i)
                            break;

                        _resourceNames[b] = ReadString(dataStream);
                        int j;
                        byte[] arrayOfByte = new byte[j = ReadInt32(dataStream.BaseStream)];
                        dataStream.Read(arrayOfByte);
                        JavaString[][] arrayOfString = {
                new JavaString[]{
                      "bg_judge_a00.jpg", "bg_judge_a01.jpg", "bg_judge_a03.jpg", "bg_judge_a04.jpg", "bg_judge_a06.jpg", "bg_judge_a07.jpg", "bg_judge_a09.jpg", "bg_judge_a10.jpg", "bg_judge_a11.jpg", "bg_judge_a13.jpg",
                      "bg_judge_a14.jpg", "bg_judge_a16.jpg", "bg_judge_a17.jpg", "bg_judge_a19.jpg", "bg_judge_a02.jpg", "bg_judge_a05.jpg", "bg_judge_a08.jpg", "bg_judge_a12.jpg", "bg_judge_a15.jpg", "bg_judge_a18.jpg",
                      "SP_V_R_Hantei_050.mld", "SP_V_R_Hantei_051.mld", "SP_V_R_Hantei_052.mld", "SP_V_R_Seikai_060.mld", "SP_V_R_Seikai_061.mld", "SP_V_R_Seikai_062.mld", "SP_V_R_Huseikai_070.mld", "SP_V_R_Huseikai_071.mld", "SP_V_R_Huseikai_072.mld"
                },
                new JavaString[]{
                      "bg_judge_b00.jpg", "bg_judge_b01.jpg", "bg_judge_b03.jpg", "bg_judge_b04.jpg", "bg_judge_b06.jpg", "bg_judge_b07.jpg", "bg_judge_b09.jpg", "bg_judge_b10.jpg", "bg_judge_b11.jpg", "bg_judge_b13.jpg",
                      "bg_judge_b14.jpg", "bg_judge_b16.jpg", "bg_judge_b17.jpg", "bg_judge_b19.jpg", "bg_judge_b02.jpg", "bg_judge_b05.jpg", "bg_judge_b08.jpg", "bg_judge_b12.jpg", "bg_judge_b15.jpg", "bg_judge_b18.jpg",
                      "SP_V_L_Hantei_055.mld", "SP_V_L_Hantei_056.mld", "SP_V_L_Hantei_057.mld", "SP_V_L_Seikai_065.mld", "SP_V_L_Seikai_066.mld", "SP_V_L_Seikai_067.mld", "SP_V_L_Huseikai_075.mld", "SP_V_L_Huseikai_076.mld", "SP_V_L_Huseikai_077.mld"
                }
            };
                        if (_resourceNames[b].IndexOf(".gif") != -1 || _resourceNames[b].IndexOf(".jpg") != -1)
                        {
                            if (this.i != null)
                                for (byte b1 = 0; b1 < this.i.Length; b1++)
                                {
                                    if (this.i[b1] == _resourceNames[b])
                                        try
                                        {
                                            _resourceObjects[_resourceObjectCount] = PalettedImage.CreatePalettedImage(arrayOfByte);
                                            _resourceObjectCount++;
                                            goto label207;
                                        }
                                        catch (Exception exception)
                                        {
                                            goto label207;
                                        }
                                        finally
                                        {
                                            //null;
                                        }
                                }
                            try
                            {
                                byte b1 = 0;
                                while (true)
                                {
                                    if (b1 < (arrayOfString[n]).Length)
                                    {
                                        if (arrayOfString[n][b1] == _resourceNames[b])
                                        {
                                            _resourceObjects[_resourceObjectCount] = null;
                                            _resourceObjectCount++;
                                            break;
                                        }
                                        b1++;
                                        continue;
                                    }
                                    MediaImage mediaImage;
                                    (mediaImage = MediaManager.GetImage(arrayOfByte)).Use();
                                    _resourceObjects[_resourceObjectCount] = mediaImage.GetImage();
                                    _resourceObjectCount++;
                                    break;
                                }
                            }
                            catch (Exception throwable) { }
                        }
                        else if (_resourceNames[b].IndexOf(".mld") != -1)
                        {
                            for (byte b1 = 0; b1 < (arrayOfString[n]).Length; b1++)
                            {
                                if (arrayOfString[n][b1] == _resourceNames[b])
                                {
                                    _resourceObjects[_resourceObjectCount] = null;
                                    _resourceObjectCount++;
                                    goto label207;
                                }
                            }
                            try
                            {
                                MediaSound mediaSound;
                                (mediaSound = MediaManager.GetSound(arrayOfByte)).Use();
                                _resourceObjects[_resourceObjectCount] = mediaSound;
                                _resourceObjectCount++;
                            }
                            catch (Exception throwable) { }
                        }
                        else if (_resourceNames[b].IndexOf(".dat") != -1)
                        {
                            _resourceObjects[_resourceObjectCount] = arrayOfByte;
                            _resourceObjectCount++;
                        }
                    }
                    continue;
                }

                if (str == "obj")
                {
                    if (_objects == null)
                    {
                        _objectCount = 0;
                        _objects = new object[255];
                    }
                    while (0 < _resourceSectionSize)
                    {
                        JavaString str1;
                        if ((str1 = ReadString(dataStream)) == "pimg")
                        {
                            ReadInt32(dataStream.BaseStream);
                            i = new JavaString[ReadInt32(dataStream.BaseStream)];
                            for (byte b = 0; b < i.Length; b++)
                                i[b] = ReadString(dataStream);
                            continue;
                        }
                        if (str1 == "layout")
                        {
                            byte b;
                            ReadInt32(dataStream.BaseStream);
                            ControlScene.layoutType = ReadInt32(dataStream.BaseStream);
                            switch (ControlScene.layoutType)
                            {
                                case 1:
                                    ControlScene.width = ReadInt32(dataStream.BaseStream);
                                    ControlScene.height = ReadInt32(dataStream.BaseStream);
                                    for (b = 0; b < ControlScene.resourcePositions.Length; b++)
                                    {
                                        ControlScene.resourcePositions[b][0] = ReadInt32(dataStream.BaseStream);
                                        ControlScene.resourcePositions[b][1] = ReadInt32(dataStream.BaseStream);
                                    }
                                    for (b = 0; b < ControlScene.keyboardAreas.Length; b++)
                                    {
                                        ControlScene.keyboardAreas[b][0] = ReadInt32(dataStream.BaseStream);
                                        ControlScene.keyboardAreas[b][1] = ReadInt32(dataStream.BaseStream);
                                        ControlScene.keyboardAreas[b][2] = ReadInt32(dataStream.BaseStream);
                                        ControlScene.keyboardAreas[b][3] = ReadInt32(dataStream.BaseStream);
                                    }
                                    for (b = 0; b < ControlScene.s.Length; b++)
                                        ControlScene.s[b] = ReadInt32(dataStream.BaseStream);
                                    for (b = 0; b < ControlScene.r2.Length; b++)
                                        ControlScene.r2[b] = ReadInt32(dataStream.BaseStream);
                                    break;
                            }
                            continue;
                        }
                        if (str1 == "nazoanime")
                        {
                            ReadString(dataStream);
                            int i = ReadInt32(dataStream.BaseStream);
                            int j = ReadInt32(dataStream.BaseStream);
                            int k = ReadInt32(dataStream.BaseStream);
                            int m = ReadInt32(dataStream.BaseStream);
                            int[] arrayOfInt = ReadIntValues(dataStream.BaseStream, m);
                            bool bool1 = false;
                            PuzzleFactory puzzleFactory;
                            (puzzleFactory = new PuzzleFactory()).a1(paramc, "cmd nazoanime", 4, (Image)null);
                            Image[] arrayOfImage = new Image[m];
                            for (byte b = 0; b < m; b++)
                                arrayOfImage[b] = GetLoadedImage(arrayOfInt[b]);
                            puzzleFactory.a1(arrayOfImage, i, j, k);
                            a1(puzzleFactory);
                            continue;
                        }
                        if (str1 == "anime")
                        {
                            PuzzleFactory puzzleFactory = new PuzzleFactory();
                            ReadInt32(dataStream.BaseStream);
                            puzzleFactory.a1(paramc, "cmd anime", 2, (Image)null);
                            int i = ReadInt32(dataStream.BaseStream);
                            int j = ReadInt32(dataStream.BaseStream);
                            int k = ReadInt32(dataStream.BaseStream);
                            int[] arrayOfInt1 = ReadIntValues(dataStream.BaseStream, k);
                            int[] arrayOfInt2 = ReadIntValues(dataStream.BaseStream, k);
                            int[] arrayOfInt3 = ReadIntValues(dataStream.BaseStream, k);
                            for (byte b = 0; b < k; b++)
                            {
                                Image image;
                                switch (arrayOfInt1[b])
                                {
                                    case -1:
                                        image = null;
                                        break;
                                    case -2:
                                        image = PuzzleManager.k.GetLoadedImage(PuzzleManager.k._intValues[22]);
                                        break;
                                    case -3:
                                        image = PuzzleManager.k.GetLoadedImage(PuzzleManager.k._intValues[23]);
                                        break;
                                    case -4:
                                        image = PuzzleManager.k.GetLoadedImage(PuzzleManager.k._intValues[24]);
                                        break;
                                    default:
                                        image = GetLoadedImage(arrayOfInt1[b]);
                                        break;
                                }
                                java.util.System.Out.Debug("anime {0} ", b);
                                puzzleFactory.a1(image, arrayOfInt2[b], arrayOfInt3[b], i, j);
                            }
                            puzzleFactory.g1();
                            a1(puzzleFactory);
                            continue;
                        }
                        if (str1 == "select")
                        {
                            if (_layoutElementType == -1)
                                _layoutElementType = 3;
                            a1(SelectionControlScene.Read(this, dataStream));
                            continue;
                        }
                        if (str1 == "switch")
                        {
                            if (_layoutElementType == -1)
                                _layoutElementType = 2;
                            a1(SwitchControlScene.Read(this, dataStream));
                            continue;
                        }
                        if (str1 == "line")
                        {
                            if (_layoutElementType == -1)
                                _layoutElementType = 4;
                            a1(LineControlScene.Read(this, dataStream));
                            continue;
                        }
                        if (str1 == "keyboard")
                        {
                            if (_layoutElementType == -1)
                                _layoutElementType = 5;
                            a1(KeyboardControlScene.Read(this, dataStream));
                            continue;
                        }
                        if (str1 == "button")
                        {
                            if (_layoutElementType == -1)
                                _layoutElementType = 1;
                            PuzzleFactory puzzleFactory = new PuzzleFactory();
                            int i = ReadInt32(dataStream.BaseStream);
                            int j;
                            if ((j = ReadInt32(dataStream.BaseStream)) == -1)
                            {
                                puzzleFactory.a1(paramc, "SCRIPT_CMD_AddTracePoint", 3, (Image)null);
                            }
                            else
                            {
                                puzzleFactory.a1(paramc, "SCRIPT_CMD_AddTracePoint", 3, GetLoadedImage(j));
                            }
                            puzzleFactory.c = ReadInt32(dataStream.BaseStream);
                            for (byte b = 1; b < i; b++)
                            {
                                int[] arrayOfInt;
                                (arrayOfInt = new int[3])[0] = ReadInt32(dataStream.BaseStream);
                                arrayOfInt[1] = ReadInt32(dataStream.BaseStream);
                                arrayOfInt[2] = ReadInt32(dataStream.BaseStream);
                                int k = ReadInt32(dataStream.BaseStream);
                                int m = ReadInt32(dataStream.BaseStream);
                                int flipMode = ReadInt32(dataStream.BaseStream);
                                int i1 = ReadInt32(dataStream.BaseStream);
                                int i2 = ReadInt32(dataStream.BaseStream);
                                int i3 = ReadInt32(dataStream.BaseStream);
                                int i4 = ReadInt32(dataStream.BaseStream);
                                JavaString str2 = ReadString(dataStream);
                                Image[] arrayOfImage = new Image[3];
                                for (byte b1 = 0; b1 < 3; b1++)
                                {
                                    switch (arrayOfInt[b1])
                                    {
                                        case -1:
                                            arrayOfImage[b1] = null;
                                            break;
                                        case -2:
                                            arrayOfImage[b1] = PuzzleManager.k.GetLoadedImage(PuzzleManager.k._intValues[25]);
                                            break;
                                        case -3:
                                            arrayOfImage[b1] = PuzzleManager.k.GetLoadedImage(PuzzleManager.k._intValues[26]);
                                            break;
                                        case -4:
                                            arrayOfImage[b1] = PuzzleManager.k.GetLoadedImage(PuzzleManager.k._intValues[27]);
                                            break;
                                        default:
                                            arrayOfImage[b1] = GetLoadedImage(arrayOfInt[b1]);
                                            break;
                                    }
                                }
                                puzzleFactory.a1(arrayOfImage[0], arrayOfImage[1], arrayOfImage[2], k, m, flipMode, i1, i2, i4, i3, str2);
                            }
                            puzzleFactory.g1();
                            a1(puzzleFactory);
                            continue;
                        }
                        if (_layoutElementType == -1)
                            _layoutElementType = 0;

                        ReadInt32(dataStream.BaseStream);
                        int imageIndex = ReadInt32(dataStream.BaseStream);
                        GetLoadedImage(imageIndex);
                    }
                    continue;
                }

                if (str == "ary")
                {
                    JavaString str1;
                    if ((str1 = ReadString(dataStream)) == "int")
                    {
                        _intValues = new int[_resourceSectionSize / 4];
                        for (byte b = 0; 0 < _resourceSectionSize; b++)
                            _intValues[b] = ReadInt32(dataStream.BaseStream);
                    }
                    else if (str1 == "short")
                    {
                        _shortValues = new short[_resourceSectionSize / 2];
                        for (byte b = 0; 0 < _resourceSectionSize; b++)
                            _shortValues[b] = ReadInt16(dataStream.BaseStream);
                    }
                    else if (str1 == "byte")
                    {
                        _byteValues = new byte[_resourceSectionSize];
                        dataStream.Read(_byteValues);
                    }
                    else if (str1 == "str")
                    {
                        _stringValues = new JavaString[100];
                        for (byte b = 0; 0 < _resourceSectionSize; b++)
                            _stringValues[b] = ReadString(dataStream);
                    }
                    dataStream.BaseStream.Position += _resourceSectionSize;
                    continue;
                }
                dataStream.BaseStream.Position += _resourceSectionSize;
            }
        }
        catch (Exception exception)
        {
            boolValue = false;
        }
        return boolValue;
    }

    [FunctionName("a")]
    private bool ReadIntValues(byte[] resourceBytes)
    {
        bool boolValue = true;
        if (resourceBytes == null)
            return false;
        BinaryReader dataStream = new BinaryReader(new MemoryStream(resourceBytes));
        try
        {
            while (dataStream.BaseStream.Position < dataStream.BaseStream.Length)
            {
                JavaString str = "";
                str = str + (char)dataStream.ReadByte();
                str = str + (char)dataStream.ReadByte();
                str = str + (char)dataStream.ReadByte();
                _resourceSectionSize = ReadInt32(dataStream.BaseStream);
                if (str == "ary")
                {
                    JavaString str1;
                    if ((str1 = ReadString(dataStream)) == "int")
                    {
                        _intValues = new int[_resourceSectionSize / 4];
                        for (byte b = 0; 0 < _resourceSectionSize; b++)
                            _intValues[b] = ReadInt32(dataStream.BaseStream);
                    }
                    dataStream.BaseStream.Position += _resourceSectionSize;
                    continue;
                }
                dataStream.BaseStream.Position += _resourceSectionSize;
            }
        }
        catch (Exception exception)
        {
            boolValue = false;
        }
        return boolValue;
    }

    [FunctionName("a")]
    public int ReadInt32(Stream paramStream)
    {
        int i = 0;
        i = paramStream.ReadByte() | paramStream.ReadByte() << 8 | paramStream.ReadByte() << 16 | paramStream.ReadByte() << 24;
        _resourceSectionSize -= 4;
        return i;
    }

    [FunctionName("b")]
    private short ReadInt16(Stream paramStream)
    {
        short s = 0;
        s = (short)(paramStream.ReadByte() | paramStream.ReadByte() << 8);
        _resourceSectionSize -= 2;
        return s;
    }

    [FunctionName("a")]
    public JavaString ReadString(BinaryReader paramBinaryReader)
    {
        short s;
        byte[] arrayOfByte = new byte[s = ReadInt16(paramBinaryReader.BaseStream)];
        paramBinaryReader.Read(arrayOfByte);
        _resourceSectionSize -= s;
        return new JavaString(arrayOfByte);
    }
}
