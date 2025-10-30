using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm4.c.Files.Models;

[ClassName("c", "p")]
public class AnimationData
{
    [MemberName("a")]
    private ImagePartsData _imgPartsData;
    [MemberName("b")]
    private int _animationCount;
    [MemberName("c")]
    private int[][][] _animationData;
    [MemberName("d")]
    private int[][] g;
    [MemberName("e")]
    private int[][] _partCounts;

    [ConstructorName("p")]
    private AnimationData()
    {
    }

    [FunctionName("a")]
    public static AnimationData Create(int[][][] animationData, ImagePartsData partsData)
    {
        AnimationData p1;
        (p1 = new AnimationData())._animationData = animationData;
        p1._animationCount = animationData.Length;

        p1._imgPartsData = partsData;
        p1.Initialize();

        return p1;
    }

    [FunctionName("d")]
    private void Initialize()
    {
        _partCounts = new int[_animationData.Length][];
        g = new int[_animationData.Length][];
        for (byte b = 0; b < _animationData.Length; b++)
        {
            _partCounts[b] = new int[_animationData[b].Length];
            g[b] = new int[_animationData[b].Length];
            for (byte b1 = 0; b1 < _animationData[b].Length; b1++)
            {
                _partCounts[b][b1] = (_animationData[b][b1].Length - 1) / 3;
                g[b][b1] = _animationData[b][b1][_animationData[b][b1].Length - 1];
            }
        }
    }

    [FunctionName("a")]
    public ImagePartsData GetImageParts()
    {
        return _imgPartsData;
    }

    [FunctionName("b")]
    public int GetAnimationCount()
    {
        return _animationCount;
    }

    [FunctionName("a")]
    public int GetAnimationPartIndex(int animationIndex, int animationStepIndex, int paramInt3)
    {
        return _animationData[animationIndex][animationStepIndex][paramInt3];
    }

    [FunctionName("a")]
    public int GetAnimationStepPartCount(int animationIndex, int animationStepIndex)
    {
        return _partCounts[animationIndex][animationStepIndex];
    }

    [FunctionName("b")]
    public int GetAnimationStepDuration(int paramInt1, int paramInt2)
    {
        return g[paramInt1][paramInt2];
    }

    [FunctionName("a")]
    public int GetAnimationStepCount(int paramInt)
    {
        return g[paramInt].Length;
    }

    [FunctionName("c")]
    public void Destroy()
    {
        _imgPartsData = null;
        _animationData = null;
        g = null;
        _partCounts = null;
    }
}
