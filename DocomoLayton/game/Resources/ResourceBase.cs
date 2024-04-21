using System.Diagnostics;
using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace DocomoLayton.game.Resources;

[ClassName("c", "h")]
public abstract class ResourceBase
{
    [MemberName("b")]
    protected ResourceBase? RootResource;
    [MemberName("c")]
    protected ResourceBase? ChildResource;

    [MemberName("a")]
    private ResourceBase? _parentResource;

    [MemberName("d")]
    protected bool _isVisible = true;

    [MemberName("e")]
    public int posX = 0;
    [MemberName("f")]
    public int posY = 0;

    [MemberName("k")]
    private int k;
    [MemberName("l")]
    private int l;
    [MemberName("m")]
    private int m;
    [MemberName("n")]
    private int n;
    [MemberName("o")]
    private int o;
    [MemberName("p")]
    private int p;

    [MemberName("g")]
    public int _alphaChannel;
    [MemberName("h")]
    public int _transitionState;
    [MemberName("i")]
    public int _transitionFrame;
    [MemberName("j")]
    public int _transitionFrameCount;

    public const int ANCHOR_LEFT = 0;
    public const int ANCHOR_CENTER = 1;
    public const int ANCHOR_RIGHT = 2;

    [ConstructorName("h")]
    public ResourceBase()
    {
    }

    [FunctionName("e")]
    public bool IsVisible()
    {
        return _isVisible;
    }

    [FunctionName("a")]
    public void SetIsVisible(bool var1)
    {
        _isVisible = var1;
    }

    [FunctionName("a")]
    public abstract int GetWidth();

    [FunctionName("b")]
    public abstract int GetHeight();

    [FunctionName("c")]
    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

    [FunctionName("a")]
    public bool AddChild(ResourceBase var1)
    {
        if (var1.RootResource != null)
            var1.f1();

        if (ChildResource == null)
        {
            ChildResource = var1;
        }
        else
        {
            ResourceBase var2 = ChildResource;
            while (var2._parentResource != null)
                var2 = var2._parentResource;

            var2._parentResource = var1;
        }

        var1.RootResource = this;
        var1._parentResource = null;

        return true;
    }

    [FunctionName("a")]
    public bool AddChild(ResourceBase resource, int x, int y)
    {
        bool wasSet = AddChild(resource);

        if (wasSet)
            resource.SetPosition(x, y);

        return wasSet;
    }

    [FunctionName("b")]
    public bool RemoveChild(ResourceBase resourceToUnlink)
    {
        var resourceFound = false;
        ResourceBase lastResource = null;

        for (ResourceBase resource = ChildResource; resource != null; resource = resource._parentResource)
        {
            if (resource == resourceToUnlink)
            {
                resourceFound = true;
                break;
            }

            lastResource = resource;
        }

        if (resourceFound)
        {
            if (ChildResource == resourceToUnlink)
            {
                ChildResource = resourceToUnlink._parentResource;
            }
            else
            {
                lastResource._parentResource = resourceToUnlink._parentResource;
            }

            resourceToUnlink.RootResource = null;
            resourceToUnlink._parentResource = null;
        }

        return resourceFound;
    }

    [FunctionName("f")]
    public bool f1()
    {
        return RootResource == null ? false : RootResource.RemoveChild(this);
    }

    [FunctionName("a")]
    public bool a1(ResourceBase var1, int var2)
    {
        int var3 = -1;
        int var4 = 0;
        ResourceBase var5 = null;
        ResourceBase var6 = null;

        ResourceBase var7;
        for (var7 = ChildResource; var7 != null; var7 = var7._parentResource)
        {
            if (var7 == var1)
            {
                var3 = var4;
                var5 = var6;
            }
            else
            {
                ++var4;
            }

            var6 = var7;
        }

        if (var3 >= 0 && var4 != 0)
        {
            if (var5 == null)
            {
                ChildResource = var1._parentResource;
            }
            else
            {
                var5._parentResource = var1._parentResource;
            }

            var1._parentResource = null;
            if (var2 < 0)
            {
                if ((var2 = -1 - var2) > var4)
                {
                    var2 = var4;
                }
            }
            else if ((var2 = var4 - var2) < 0)
            {
                var2 = 0;
            }

            if (var2 == 0)
            {
                var1._parentResource = ChildResource;
                ChildResource = var1;
            }
            else
            {
                var7 = ChildResource;

                for (int var8 = 1; var8 < var2; ++var8)
                {
                    var7 = var7._parentResource;
                }

                var1._parentResource = var7._parentResource;
                var7._parentResource = var1;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    [FunctionName("g")]
    public void Destroy()
    {
        ResourceBase var2;
        for (ResourceBase var1 = ChildResource; var1 != null; var1 = var2)
        {
            var2 = var1._parentResource;
            var1.Destroy();
            var1.RootResource = null;
            var1._parentResource = null;
        }

        ChildResource = null;
    }

    [FunctionName("b")]
    public void Paint(Graphics graphics, int x, int y)
    {
        ResourceBase var4;
        if (_isVisible)
        {
            PaintInternal(graphics, x, y);

            for (var4 = ChildResource; var4 != null; var4 = var4._parentResource)
            {
                var4.Paint(graphics, x + posX, y + posY);
            }
        }

        Update(graphics);

        for (var4 = ChildResource; var4 != null; var4 = var4._parentResource)
        {
            var4.Update(graphics);
        }
    }

    [FunctionName("a")]
    protected abstract void PaintInternal(Graphics g, int x, int y);

    [FunctionName("a")]
    protected abstract void Update(Graphics var1);

    [FunctionName("a")]
    public void a1(int var1, int var2, int var3)
    {
        k = posX;
        l = posY;
        m = var1;
        n = var2;
        p = 0;
        o = var3;
    }

    [FunctionName("h")]
    public bool h1()
    {
        if (p >= o)
        {
            return true;
        }
        else
        {
            ++p;
            posX = (k * (o - p) + m * p) / o;
            posY = (l * (o - p) + n * p) / o;
            return false;
        }
    }

    [FunctionName("c")]
    public void c1(int var1)
    {
        _alphaChannel = var1;
    }

    [FunctionName("d")]
    public void ExecuteTransition(int var1)
    {
        ExecuteTransition(var1, 10);
    }

    [FunctionName("d")]
    public void ExecuteTransition(int var1, int frameCount)
    {
        if (frameCount < 1)
        {
            frameCount = 10;
        }

        if (var1 == 0)
        {
            _transitionState = 1;
        }
        else
        {
            _transitionState = 3;
        }

        _transitionFrame = 0;
        _transitionFrameCount = frameCount;
    }

    [FunctionName("e")]
    public void ExecuteFullTransition(int var1)
    {
        ExecuteFullTransition(var1, 10);
    }

    [FunctionName("e")]
    public void ExecuteFullTransition(int var1, int frameCount)
    {
        if (frameCount < 1)
        {
            frameCount = 1;
        }

        if (var1 == 0)
        {
            _transitionState = 1;
        }
        else
        {
            _transitionState = 3;
        }

        _transitionFrame = 0;
        _transitionFrameCount = frameCount;

        PropagateTransition(_transitionState, _transitionFrame, _transitionFrameCount);
    }

    [FunctionName("b")]
    public void PropagateTransition(int var1, int var2, int var3)
    {
        for (ResourceBase var4 = ChildResource; var4 != null; var4 = var4._parentResource)
        {
            var4._transitionState = var1;
            var4._transitionFrame = var2;
            var4._transitionFrameCount = var3;
        }
    }
}
