using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using LaytonMotdm4.data;

namespace LaytonMotdm4.c.Managers;

[ClassName("c", "w")]
public class AudioManager : MediaListener
{
    [MemberName("e")]
    private static AudioManager Instance = new();
    [MemberName("f")]
    private static AudioPresenter[] f;
    [MemberName("g")]
    private static int g = 0;
    [MemberName("h")]
    private static int[] h = new int[] { 0, 40, 70, 100 };
    [MemberName("i")]
    private static int i = 3;
    [MemberName("j")]
    private static int[] j;
    [MemberName("k")]
    private static bool[] k;
    [MemberName("l")]
    private static int[] l;
    [MemberName("m")]
    private static MediaSound[] m;

    [MemberName("a")]
    public static int a;
    [MemberName("b")]
    public static int b;
    [MemberName("c")]
    public static int c;
    [MemberName("d")]
    public static bool d;

    [ConstructorName("w")]
    public AudioManager()
    {
    }

    [FunctionName("a")]
    public static bool a1(int paramInt1, MediaSound paramMediaSound, int paramInt2)
    {
        return a1(paramInt1, paramMediaSound, paramInt2, 0, true);
    }

    [FunctionName("a")]
    public static bool a1(int paramInt1, MediaSound paramMediaSound, int paramInt2, int paramInt3)
    {
        return a1(paramInt1, paramMediaSound, paramInt2, paramInt3, true);
    }

    [FunctionName("b")]
    public static bool PlaySound(int paramInt1, MediaSound paramMediaSound, int paramInt2)
    {
        return a1(paramInt1, paramMediaSound, paramInt2, 0, false);
    }

    [FunctionName("b")]
    public static bool b1(int paramInt1, MediaSound paramMediaSound, int paramInt2, int paramInt3)
    {
        return a1(paramInt1, paramMediaSound, paramInt2, paramInt3, false);
    }

    [FunctionName("a")]
    private static bool a1(int paramInt1, MediaSound paramMediaSound, int paramInt2, int paramInt3, bool paramBoolean)
    {
        bool boolValue = a1(paramInt1, paramMediaSound);
        try
        {
            if (!boolValue)
                return boolValue;
            a1(paramInt1, paramInt2);
            if (m[paramInt1] == paramMediaSound)
            {
                k[paramInt1] = paramBoolean;
                return true;
            }
            if (!(boolValue = b1(paramInt1, paramInt3)))
                return boolValue;
            k[paramInt1] = paramBoolean;
            if (k[paramInt1])
                m[paramInt1] = paramMediaSound;
        }
        catch (Exception exception)
        {
            java.util.System.Out.Fatal(exception, "An error occurred playing the audio.");
        }
        return boolValue;
    }

    [FunctionName("a")]
    public static bool StopSound(int paramInt)
    {
        try
        {
            f[paramInt].Pause();
            f[paramInt].Stop();
            l[paramInt] = -2;
            k[paramInt] = false;
            m[paramInt] = null;
        }
        catch (Exception exception)
        {
            return false;
        }
        return true;
    }

    [FunctionName("a")]
    public static bool a1()
    {
        for (byte b = 0; b < g; b++)
        {
            if (!StopSound(b))
                return false;
        }
        return true;
    }

    [FunctionName("b")]
    public static void b1(int paramInt)
    {
        if (paramInt >= h.Length)
            paramInt = h.Length - 1;
        i = paramInt;
        for (byte b = 0; b < g; b++)
            e1(b);
    }

    [FunctionName("a")]
    public static void a1(int paramInt1, int paramInt2)
    {
        j[paramInt1] = paramInt2;
        e1(paramInt1);
    }

    [FunctionName("a")]
    public static void a1(int paramInt1, int paramInt2, int paramInt3)
    {
        b = j[paramInt1];
        a = paramInt2;
        d = true;
        c = paramInt3;
    }

    [FunctionName("c")]
    public static int c1(int paramInt)
    {
        if (!d)
            return 0;
        if (b > a)
        {
            b -= c;
            if (b <= a)
                b = a;
        }
        if (b < a)
        {
            b += c;
            if (b >= a)
                b = a;
        }
        else if (b == a)
        {
            d = false;
            a1(paramInt, b);
            j[paramInt] = 100;
            return 2;
        }
        a1(paramInt, b);
        return 1;
    }

    [FunctionName("a")]
    private static bool a1(int paramInt, MediaSound paramMediaSound)
    {
        if (paramMediaSound == null)
            return false;
        if (f[paramInt].GetMediaResource() == null)
        {
            f[paramInt].SetSound(paramMediaSound);
        }
        else if (f[paramInt].GetMediaResource() != paramMediaSound)
        {
            try
            {
                StopSound(paramInt);
                f[paramInt].SetSound(paramMediaSound);
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        return true;
    }

    [FunctionName("b")]
    private static bool b1(int paramInt1, int paramInt2)
    {
        bool boolValue = true;
        try
        {
            f[paramInt1].Play(paramInt2);
            l[paramInt1] = -1;
        }
        catch (Exception exception)
        {
            boolValue = false;
            java.util.System.Out.Fatal(exception, "An error occurred playing the audio.");
        }
        return boolValue;
    }

    [FunctionName("e")]
    private static void e1(int paramInt)
    {
        int i = j[paramInt];
        try
        {
            if ((i = h[i] * i / 100) < 0)
            {
                i = 0;
            }
            else if (i > 100)
            {
                i = 100;
            }
            f[paramInt].SetAttribute(4, i);
            return;
        }
        catch (Exception exception)
        {
            java.util.System.Out.Fatal(exception, "An error occurred playing the audio.");
            return;
        }
    }

    [FunctionName("b")]
    public static void b1()
    {
        try
        {
            for (byte b = 0; b < g; b++)
            {
                if (k[b])
                {
                    b1(b, 0);
                }
                else
                {
                    StopSound(b);
                    l[b] = 2;
                }
            }
            return;
        }
        catch (Exception exception)
        {
            java.util.System.Out.Fatal(exception, "An error occurred playing the audio.");
            return;
        }
    }

    [FunctionName("mediaAction")]
    public void mediaAction(MediaPresenter paramMediaPresenter, int paramInt1, int paramInt2)
    {
        try
        {
            for (byte b = 0; b < f.Length; b++)
            {
                if (paramMediaPresenter == f[b])
                    l[b] = paramInt1;
            }
            return;
        }
        catch (Exception exception)
        {
            java.util.System.Out.Fatal(exception, "An error occurred playing the audio.");
            return;
        }
    }

    [FunctionName("c")]
    public static int c1()
    {
        return i;
    }

    [FunctionName("d")]
    public static int d1(int paramInt)
    {
        return l[paramInt];
    }

    [FunctionName("d")]
    public static int d1()
    {
        try
        {
            if (i == 0)
            {
                i = RoomData.M1();
            }
            else
            {
                i = 0;
            }
            for (byte b = 0; b < g; b++)
                e1(b);

            RoomData.F1(0);
        }
        catch (Exception exception)
        {
            java.util.System.Out.Fatal(exception, "An error occurred playing the audio.");
        }
        return i;
    }

    static AudioManager()
    {
        g = 4;
        f = new AudioPresenter[g];
        for (byte b = 0; b < g; b++)
        {
            f[b] = AudioPresenter.GetAudioPresenter();
            f[b].SetMediaListener(Instance);
        }
        j = new int[g];
        k = new bool[g];
        m = new MediaSound[g];
        l = new int[g];
        d = false;
    }
}
