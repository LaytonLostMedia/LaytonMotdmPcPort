using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using LaytonMotdm3.c.Files.Models;

namespace LaytonMotdm3.c.Resources;

[ClassName("c", "d")]
public class AnimatedImageResource : ResourceBase
{
    [MemberName("a")]
    protected AnimationData _animationData;
    [MemberName("k")]
    protected ImagePartsData _partsData;

    [MemberName("l")]
    private int _animationStepIndex;
    [MemberName("m")]
    private int _currentStepDuration;
    [MemberName("n")]
    private int _animationType;
    [MemberName("o")]
    private int o;
    [MemberName("p")]
    private int p;
    [MemberName("q")]
    private int q;
    [MemberName("r")]
    private int _animationIndex;
    [MemberName("s")]
    private Image[] _image;
    [MemberName("t")]
    private int _anchorType;
    [MemberName("u")]
    private int _anchorPosX;
    [MemberName("v")]
    private int[] _partSrcXPositions;
    [MemberName("w")]
    private int[] _partSrcYPositions;
    [MemberName("x")]
    private int[] _partSrcWidths;
    [MemberName("y")]
    private int[] _partSrcHeights;
    [MemberName("z")]
    private int[] _partDestXPositions;
    [MemberName("A")]
    private int[] _partDestYPositions;
    [MemberName("B")]
    private int _partCount;
    [MemberName("C")]
    private int _flipMode;

    public const int ANIMATION_TYPE_STATIC = 0;
    public const int ANIMATION_TYPE_LOOP = 1;
    public const int ANIMATION_RESET = 256;

    [ConstructorName("d")]
    private AnimatedImageResource()
    {
        posX = 0;
        posY = 0;

        _image = new Image[4];

        _partSrcXPositions = new int[4];
        _partSrcYPositions = new int[4];
        _partSrcWidths = new int[4];
        _partSrcHeights = new int[4];
        _partDestXPositions = new int[4];
        _partDestYPositions = new int[4];

        _alphaChannel = 255;
    }

    [FunctionName("a")]
    public static AnimatedImageResource Create(AnimationData animationData)
    {
        AnimatedImageResource var1;
        (var1 = new AnimatedImageResource())._animationData = animationData;
        var1._partsData = animationData.GetImageParts();
        var1._animationType = 1;
        return var1;
    }

    [FunctionName("a")]
    private void LoadPartData(int stepPartIndex, int partIndex)
    {
        _image[stepPartIndex] = _partsData.GetImage(partIndex);

        _partSrcXPositions[stepPartIndex] = _partsData.GetPartInfo(partIndex, 1);
        _partSrcYPositions[stepPartIndex] = _partsData.GetPartInfo(partIndex, 2);
        _partSrcWidths[stepPartIndex] = _partsData.GetPartInfo(partIndex, 3);
        _partSrcHeights[stepPartIndex] = _partsData.GetPartInfo(partIndex, 4);

        _partDestXPositions[stepPartIndex] = _animationData.GetAnimationPartIndex(_animationIndex, _animationStepIndex, stepPartIndex * 3 + 1);
        _partDestYPositions[stepPartIndex] = _animationData.GetAnimationPartIndex(_animationIndex, _animationStepIndex, stepPartIndex * 3 + 2);

        SetAnchorType(_anchorType);
    }

    [FunctionName("a")]
    public void SetAnimationIndex(int animationIndex)
    {
        if (animationIndex < _animationData.GetAnimationCount())
        {
            _animationIndex = animationIndex;
            _currentStepDuration = 0;
            _animationStepIndex = 0;
        }
    }

    [FunctionName("b")]
    public void SetAnimationBehaviour(int var1)
    {
        if ((var1 & 0xF00) == 0x100)
        {
            _animationStepIndex = 0;
            _currentStepDuration = 0;
        }

        p = 0;
        _animationType = var1 & 0xF;

        g(var1);
    }

    [FunctionName("g")]
    private void g(int var1)
    {
        o = var1 & 0xF0;
    }

    [FunctionName("a")]
    protected override void PaintInternal(Graphics g, int x, int y)
    {
        if (_image != null)
        {
            StepAnimation();

            g.SetFlipMode(_flipMode);

            for (var i = 0; i < _partCount; ++i)
            {
                int partPosX = _partDestXPositions[i];
                if (_flipMode == Graphics.FLIP_HORIZONTAL && i != 0)
                {
                    partPosX = _partSrcWidths[0] - partPosX - _partSrcWidths[i];
                }

                g.DrawImage(_image[i], x + posX + _anchorPosX + partPosX, y + posY + _partDestYPositions[i], _partSrcXPositions[i], _partSrcYPositions[i], _partSrcWidths[i], _partSrcHeights[i]);
            }

            g.SetFlipMode(Graphics.FLIP_NONE);
        }
    }

    [FunctionName("j")]
    private void StepAnimation()
    {
        _partCount = _animationData.GetAnimationStepPartCount(_animationIndex, _animationStepIndex);

        for (int var1 = 0; var1 < _partCount; ++var1)
        {
            LoadPartData(var1, _animationData.GetAnimationPartIndex(_animationIndex, _animationStepIndex, var1 * 3));
        }

        // If animation step is finished
        if (_currentStepDuration >= _animationData.GetAnimationStepDuration(_animationIndex, _animationStepIndex))
        {
            ++_animationStepIndex;

            if (_animationType == ANIMATION_TYPE_STATIC)
            {
                --_animationStepIndex;
                --_currentStepDuration;
            }

            // If last animation step is reached
            if (_animationStepIndex >= _animationData.GetAnimationStepCount(_animationIndex))
            {
                if (_animationType == ANIMATION_TYPE_LOOP)
                {
                    _animationStepIndex = 0;
                    _currentStepDuration = 0;
                }
                else if (_animationType == 2)
                {
                    ++p;

                    if (p < q)
                    {
                        _animationStepIndex = 0;
                        _currentStepDuration = 0;
                    }
                    else
                    {
                        _animationType = ANIMATION_TYPE_STATIC;
                        if (o == 0)
                        {
                            _animationStepIndex = 0;
                            _currentStepDuration = 0;
                        }
                        else if (o == 16)
                        {
                            --_animationStepIndex;
                            --_currentStepDuration;
                        }
                    }
                }
            }
        }

        if (_animationType != ANIMATION_TYPE_STATIC)
        {
            ++_currentStepDuration;
        }

    }

    [FunctionName("a")]
    public override int GetWidth()
    {
        return _partsData.GetPartInfo(_animationData.GetAnimationPartIndex(_animationIndex, _animationStepIndex, 0), 3);
    }

    [FunctionName("b")]
    public override int GetHeight()
    {
        return _partsData.GetPartInfo(_animationData.GetAnimationPartIndex(_animationIndex, _animationStepIndex, 0), 4);
    }

    [FunctionName("h")]
    private void SetAnchorType(int anchorType)
    {
        _anchorType = anchorType;
        _anchorPosX = 0;

        if (_anchorType == 1)
        {
            _anchorPosX -= GetWidth() / 2;
        }
        else
        {
            if (_anchorType == 2)
            {
                _anchorPosX -= GetWidth();
            }

        }
    }

    [FunctionName("f")]
    public void SetFlipMode(int flipMode)
    {
        _flipMode = flipMode;
    }

    [FunctionName("c")]
    public int GetFlipMode()
    {
        return _flipMode;
    }

    [FunctionName("c")]
    public void SetAlpha(int alpha)
    {
        _alphaChannel = alpha;

        for (int var2 = 0; var2 < _image.Length; ++var2)
        {
            if (_image[var2] != null)
            {
                _image[var2].SetAlpha(alpha);
            }
        }

    }

    [FunctionName("a")]
    protected override void Update(Graphics var1)
    {
        if (_transitionState != 0)
        {
            if (_transitionState == 3)
            {
                if (++_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 4;
                }

                _alphaChannel = 255 * _transitionFrame / _transitionFrameCount;
            }
            else if (_transitionState == 1)
            {
                if (_transitionFrame == _transitionFrameCount)
                {
                    _transitionState = 2;
                    _alphaChannel = 0;
                }
                else
                {
                    _alphaChannel = 255 - 255 * _transitionFrame / _transitionFrameCount;
                    ++_transitionFrame;
                }
            }
            else
            {
                _transitionState = 0;
            }

            SetAlpha(_alphaChannel);
        }
    }

    [FunctionName("d")]
    public int GetAnimationIndex()
    {
        return _animationIndex;
    }

    [FunctionName("i")]
    public void SetLastAnimationStep()
    {
        _animationStepIndex = _animationData.GetAnimationStepCount(_animationIndex) - 1;
    }
}
