using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;
using LaytonMotdm2.c.Files.Models;
using LaytonMotdm2.c.Resources;

namespace LaytonMotdm2.c.Files;

[ClassName("c", "a")]
public class CharacterResourceFile
{
    [MemberName("c")]
    private ImagePartsData _partsData;
    [MemberName("d")]
    private AnimationData[] _animations;

    [MemberName("a")]
    public int _sectionSize;
    [MemberName("b")]
    public static bool _isBigEndian = false;

    [ConstructorName("a")]
    private CharacterResourceFile()
    {
    }

    [FunctionName("a")]
    public static CharacterResourceFile Read(byte[] var0)
    {
        CharacterResourceFile var1;
        if (!(var1 = new CharacterResourceFile()).TryRead(var0))
        {
            var1.Destroy();
            var1 = null;
        }

        return var1;
    }

    [FunctionName("b")]
    private bool TryRead(byte[] fileData)
    {
        var isSuccessful = true;

        _sectionSize = 0;
        _animations = new AnimationData[32];

        if (fileData == null)
        {
            return false;
        }
        else
        {
            using var reader = new BinaryReader(new MemoryStream(fileData));

            try
            {
                bool var4 = false;
                int animationIndex = 0;
                Image[] images = null;
                JavaString sectionIdentifier = null;

                while (true)
                {
                label221:
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        sectionIdentifier = JavaString.Concat((char)reader.ReadByte(), (char)reader.ReadByte(), (char)reader.ReadByte());
                        _sectionSize = ReadInt32(reader.BaseStream);

                        int var11;
                        if (sectionIdentifier == "res")
                        {
                            int var31;
                            byte[][] imageDatas = new byte[var31 = ReadInt32(reader.BaseStream)][];
                            JavaString[] imageNames = new JavaString[var31];
                            images = new Image[var31];

                            for (var i = 0; i < var31; ++i)
                            {
                                imageNames[i] = ReadString(reader);

                                var11 = ReadInt32(reader.BaseStream);
                                imageDatas[i] = new byte[var11];
                                reader.Read(imageDatas[i]);

                                MediaImage var33;
                                (var33 = MediaManager.GetImage(imageDatas[i])).Use();
                                images[i] = var33.GetImage();
                            }
                        }
                        else if (sectionIdentifier != "obj")
                        {
                            reader.BaseStream.Position += _sectionSize;
                        }
                        else
                        {
                            while (true)
                            {
                                while (true)
                                {
                                    if (0 >= _sectionSize)
                                    {
                                        goto label221;
                                    }

                                    JavaString var10;
                                    if ((var10 = ReadString(reader)) == "parts")
                                    {
                                        int[,] partInfo = new int[var11 = ReadInt32(reader.BaseStream), 5];

                                        for (var i = 0; i < var11; ++i)
                                        {
                                            partInfo[i, 0] = ReadInt32(reader.BaseStream);
                                            partInfo[i, 1] = ReadInt32(reader.BaseStream);
                                            partInfo[i, 2] = ReadInt32(reader.BaseStream);
                                            partInfo[i, 3] = ReadInt32(reader.BaseStream);
                                            partInfo[i, 4] = ReadInt32(reader.BaseStream);
                                        }

                                        _partsData = ImagePartsData.Create(images, partInfo);
                                    }
                                    else if (var10 == "animation")
                                    {
                                        int[][][] animationData = new int[ReadInt32(reader.BaseStream)][][];

                                        for (var i = 0; i < animationData.Length; ++i)
                                        {
                                            int stepCount = ReadInt32(reader.BaseStream);
                                            animationData[i] = new int[stepCount][];

                                            for (int stepIndex = 0; stepIndex < stepCount; ++stepIndex)
                                            {
                                                int stepPartCount = ReadInt32(reader.BaseStream);
                                                animationData[i][stepIndex] = new int[stepPartCount * 3 + 1];

                                                for (int stepPartIndex = 0; stepPartIndex < stepPartCount; ++stepPartIndex)
                                                {
                                                    for (int stepPartInfoIndex = 0; stepPartInfoIndex < 3; ++stepPartInfoIndex)
                                                    {
                                                        int var18 = stepPartIndex * 3 + stepPartInfoIndex;
                                                        animationData[i][stepIndex][var18] = ReadInt32(reader.BaseStream);
                                                    }
                                                }

                                                animationData[i][stepIndex][stepPartCount * 3] = ReadInt32(reader.BaseStream);
                                            }
                                        }

                                        _animations[animationIndex++] = AnimationData.Create(animationData, _partsData);
                                    }
                                }
                            }
                        }
                    }

                    return isSuccessful;
                }
            }
            catch (Exception var28)
            {
                isSuccessful = false;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception var27)
                {
                }

            }

            return isSuccessful;
        }
    }

    [FunctionName("a")]
    public AnimatedImageResource GetAnimatedImage(int var1)
    {
        return AnimatedImageResource.Create(_animations[var1]);
    }

    [FunctionName("a")]
    public void Destroy()
    {
        if (_partsData != null)
        {
            _partsData.Destroy();
        }

        if (_animations != null)
        {
            for (int var1 = 0; var1 < _animations.Length; ++var1)
            {
                if (_animations[var1] != null)
                {
                    _animations[var1].Destroy();
                    _animations[var1] = null;
                }
            }
        }

        _partsData = null;
        _animations = null;
    }

    [FunctionName("a")]
    private int ReadInt32(Stream var1)
    {
        int value;

        if (_isBigEndian)
        {
            value = var1.ReadByte() << 24 | var1.ReadByte() << 16 | var1.ReadByte() << 8 | var1.ReadByte();
        }
        else
        {
            value = var1.ReadByte() | var1.ReadByte() << 8 | var1.ReadByte() << 16 | var1.ReadByte() << 24;
        }

        _sectionSize -= 4;

        return value;
    }

    [FunctionName("b")]
    private short ReadInt16(Stream var1)
    {
        short value;

        if (_isBigEndian)
        {
            value = (short)(var1.ReadByte() << 8 | var1.ReadByte());
        }
        else
        {
            value = (short)(var1.ReadByte() | var1.ReadByte() << 8);
        }

        _sectionSize -= 2;

        return value;
    }

    [FunctionName("a")]
    private JavaString ReadString(BinaryReader var1)
    {
        byte[] var3 = new byte[ReadInt16(var1.BaseStream)];
        var1.Read(var3);

        _sectionSize -= var3.Length;

        return new JavaString(var3);
    }
}
