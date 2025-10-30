using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;

namespace LaytonMotdm3.c.Managers;

[ClassName("c","e")]
public class PhoneManager
{
    [MemberName("b")]
    private static int b = 0;
    [MemberName("c")]
    private static int c = 0;
    [MemberName("d")]
    private static int d = 0;
    [MemberName("e")]
    private static int e2 = 1;
    [MemberName("f")]
    private static int f = 0;

    [MemberName("a")]
    public static bool a = true;

    [ConstructorName("e")]
    public PhoneManager()
    {
    }

    [FunctionName("a")]
    public static void a1(int var0)
    {
        c = var0;
        d = 0;
        a1(1, 0);
    }

    [FunctionName("a")]
    private static void a1(int var0, int var1)
    {
        e2 = var0;
        f = var1;
    }

    [FunctionName("b")]
    private static void b1()
    {
        PhoneSystem.SetAttribute(1, 0);
        b = 0;
        c = 0;
        a1(1, 0);
    }

    [FunctionName("a")]
    public static void a1()
    {
        if (d < c && a)
        {
            int var0 = b;
            e2 = 100;
            int var1 = e2 + f;
            if (d % var1 < e2)
            {
                b = 1;
            }
            else
            {
                b = 0;
            }

            if (var0 != b)
            {
                PhoneSystem.SetAttribute(1, b);
            }

            ++d;
        }
        else
        {
            b1();
        }
    }
}