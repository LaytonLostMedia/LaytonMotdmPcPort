using System.Text;
using com.nttdocomo.opt.ui;
using com.nttdocomo.ui;
using com.nttdocomo.util;
using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm3.c.Managers;

[ClassName("c", "ac")]
public class DownloadManager
{
    [MemberName("e")]
    private static int e = 1;
    [MemberName("f")]
    private static int f = 1024;
    [MemberName("g")]
    private static Font g = Font.GetFont(0x71100400);
    [MemberName("h")]
    private static int gameId = 0;
    [MemberName("i")]
    private static int gameVersion = 0;

    [MemberName("a")]
    public static int a = 0;
    [MemberName("b")]
    public static JavaString b = "";
    [MemberName("c")]
    public static JavaString c = null;

    [MemberName("j")]
    private static int j = 0;

    [MemberName("d")]
    public static bool d = false;

    [MemberName("k")]
    private static int k = Graphics.GetColorOfRGB(0, 0, 0);
    [MemberName("l")]
    private static int l = Graphics.GetColorOfRGB(255, 255, 255);
    [MemberName("m")]
    private static int m = Graphics.GetColorOfRGB(128, 128, 128);
    [MemberName("n")]
    private static int n = Graphics.GetColorOfRGB(176, 176, 176);
    [MemberName("o")]
    private static int o = Graphics.GetColorOfRGB(255, 255, 0);
    [MemberName("p")]
    private static Image p;
    [MemberName("q")]
    private static int q;

    [ConstructorName("ac")]
    public DownloadManager()
    {
    }

    [FunctionName("a")]
    public static void Initialize(int gameId, int gameVersion)
    {
        DownloadManager.gameId = gameId;
        DownloadManager.gameVersion = gameVersion;
    }

    [FunctionName("a")]
    public static bool a1()
    {
        return j != 0;
    }

    [FunctionName("b")]
    public static bool b1()
    {
        return j != 0;
    }

    [FunctionName("c")]
    public static int c1()
    {
        return 0;
    }

    [FunctionName("d")]
    public static void d1()
    {
        StringBuilder JavaStringBuffer;
        (JavaStringBuffer = new StringBuilder(b)).Append("/_from_app?game_id=" + gameId);
        JavaString[] arrayOfString = { JavaStringBuffer.ToString() };
        try
        {
            IApplication.GetCurrentApp().Launch(1, arrayOfString);
        }
        catch (Exception exception)
        {
        }
    }

    [FunctionName("a")]
    private static int a1(JavaString paramString, JavaString paramString2, JavaString[] paramArrayOfString)
    {
        j |= 0x1;
        if (paramArrayOfString == null)
            (paramArrayOfString = new JavaString[1])[0] = "O  K";
        Canvas canvas;
        Graphics graphics;
        a1(graphics = (canvas = (Canvas)Display.GetCurrent()).GetGraphics());
        graphics.SetFont(g);
        graphics.Lock();
        graphics.DrawImage(p, 0, 0);
        try
        {
            Graphics2 graphics2 = (Graphics2)graphics.Copy();
            bool boolValue = false;
            graphics2.SetRenderMode(1, 200, 55);
            graphics2.SetColor(k);
            graphics2.FillRect(20, 10, 200, 220);
        }
        catch (Exception exception)
        {
            graphics.SetColor(k);
            graphics.FillRect(20, 10, 200, 220);
        }
        graphics.SetColor(n);
        graphics.DrawRect(20, 10, 199, 219);
        graphics.SetColor(m);
        graphics.FillRect(22, 12, 196, g.GetHeight() + 2);
        graphics.SetColor(l);
        graphics.DrawString(paramString, 120 - g.StringWidth(paramString) / 2, 13 + g.GetAscent());
        a1(graphics, g, paramString2, 28, 38, 184, 240);
        graphics.Unlock(false);
        int i = 0;
        while (true)
        {
            graphics.Lock();
            for (int k = 0; k < paramArrayOfString.Length; k++)
            {
                int m = 220 + (k - paramArrayOfString.Length) * (g.GetHeight() + 5);
                graphics.SetColor((k == i) ? o : m);
                graphics.FillRect(60, m, 120, g.GetHeight() + 4);
                graphics.SetColor((k == i) ? k : l);
                graphics.DrawString(paramArrayOfString[k], 120 - g.StringWidth(paramArrayOfString[k]) / 2, m + g.GetAscent() + 1);
            }
            graphics.Unlock(false);
            int j;
            while ((j = canvas.GetKeypadState()) == 0)
                a1(10);
            if ((j & 1048576) != 0)
            {
                while (canvas.GetKeypadState() != 0)
                {
                    a1(10);
                }

                b1(graphics);
                j ^= 1;
                return i;
            }

            if ((j & 131072) != 0)
            {
                --i;
            }
            else if ((j & 524288) != 0)
            {
                ++i;
            }

            if (i < 0)
            {
                i = 0;
            }

            if (i >= paramArrayOfString.Length)
            {
                i = paramArrayOfString.Length - 1;
            }
        }
    }

    [FunctionName("a")]
    private static byte[] a1(JavaString paramString, JavaString paramString2, JavaString paramString3)
    {
        StringBuilder JavaStringBuffer;
        (JavaStringBuffer = new StringBuilder()).Append("-" + paramString + "/api/" + paramString2 + "?.raw=1" + "&.gid=" + gameId + "&.ver=" + gameVersion);
        JavaString str1;
        if ((str1 = Phone.GetProperty("terminal-id")) != null)
            JavaStringBuffer.Append("&.ser=" + str1);
        JavaString str2;
        if ((str2 = Phone.GetProperty("user-id")) != null)
            JavaStringBuffer.Append("&.icc=" + str2);
        if (a != 0)
            JavaStringBuffer.Append("&.uid=" + a);
        return (paramString3 == null) ? a1(JavaStringBuffer.ToString()) : a1(JavaStringBuffer.ToString(), paramString3);
    }

    [FunctionName("a")]
    private static byte[] a1(JavaString paramString)
    {
        return a1(false, paramString, (JavaString)null);
    }

    [FunctionName("a")]
    private static byte[] a1(JavaString paramString, JavaString paramString2)
    {
        return a1(true, paramString, paramString2);
    }

    [FunctionName("a")]
    private static byte[] a1(bool paramBoolean, JavaString paramString, JavaString paramString2)
    {
        //for (byte b = 0; b <= e; b++) {
        //  HttpConnection httpConnection = null;
        //  Stream inputStream = null;
        //  OutputStream outputStream = null;
        //  try {
        //    if (paramBoolean) {
        //      (httpConnection = (HttpConnection)Connector.open1(e1() + paramString, 3, true)).setRequestMethod1("POST");
        //      (outputStream = httpConnection.openOutputStream1()).write1(paramString2.getBytes1());
        //      outputStream.Close();
        //      outputStream = null;
        //    } else {
        //      (httpConnection = (HttpConnection)Connector.open1(e1() + paramString, 1, true)).setRequestMethod1("GET");
        //    } 
        //    httpConnection.connect1();
        //    if (httpConnection.getResponseCode1() == 200) {
        //      inputStream = httpConnection.openStream1();
        //      int i = int.Parse(httpConnection.getHeaderField1("Content-Length"));
        //      int j = i;
        //      byte[] arrayOfByte = new byte[i];
        //      while (j > 0) {
        //        int k;
        //        if ((k = inputStream.ReadByte(arrayOfByte, i - j, (j < f) ? j : f)) != -1)
        //          j -= k; 
        //      } 
        //      inputStream.Close();
        //      inputStream = null;
        //      httpConnection.Close();
        //      httpConnection = null;
        //      return arrayOfByte;
        //    } 
        //    httpConnection.Close();
        //    httpConnection = null;
        //  } catch (Exception exception) {
        //    Console.WriteLine("httpGetOrPost:" + exception);
        //  } finally {
        //    try {
        //      if (outputStream != null)
        //        outputStream.Close(); 
        //    } catch (Exception exception) {}
        //    try {
        //      if (inputStream != null)
        //        inputStream.Close(); 
        //    } catch (Exception exception) {}
        //    try {
        //      if (httpConnection != null)
        //        httpConnection.Close(); 
        //    } catch (Exception exception) {}
        //  } 
        //} 
        return null;
    }

    [FunctionName("a")]
    private static void a1(Graphics paramGraphics, Font paramFont, JavaString paramString, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
    {
        paramGraphics.ClipRect(paramInt1, paramInt2, paramInt3, paramInt4);
        paramGraphics.SetFont(paramFont);
        int i;
        for (i = 0; i < paramString.Length; i = j)
        {
            int j = paramFont.GetLineBreak(paramString, i, paramString.Length - i, paramInt3);
            paramGraphics.DrawString(paramString.Substring(i, j), paramInt1, paramInt2 + paramFont.GetAscent());
            paramInt2 += paramFont.GetHeight() + 2;
        }
        paramGraphics.ClearClip();
    }

    [FunctionName("e")]
    private static JavaString e1()
    {
        JavaString str;
        int i = (str = IApplication.GetCurrentApp().GetSourceUrl()).IndexOf("/", 7);
        return str.Substring(0, i + 1);
    }

    [FunctionName("a")]
    private static JavaString[] a1(JavaString paramString, int paramInt)
    {
        byte b = 0;
        int j = -1;
        while ((j = paramString.IndexOf((char)paramInt, j + 1)) != -1)
            b++;
        JavaString[] arrayOfString = new JavaString[b];
        for (int i = 0; (j = paramString.IndexOf((char)paramInt, i)) != -1; b++)
        {
            arrayOfString[b] = paramString.Substring(i, j);
            i = j + 1;
        }
        return arrayOfString;
    }

    [FunctionName("a")]
    private static void a1(int paramInt)
    {
        try
        {
            Task.Delay(paramInt).Wait();
            return;
        }
        catch (Exception exception)
        {
            return;
        }
    }

    [FunctionName("a")]
    private static StreamReader a1(byte[] paramArrayOfbyte)
    {
        return new StreamReader(new MemoryStream(paramArrayOfbyte));
    }

    [FunctionName("a")]
    private static void a1(Graphics paramGraphics)
    {
        q++;
        if (p != null)
            return;
        try
        {
            //System.gc();
            int[] arrayOfInt = new int[57600];
            paramGraphics.GetPixels(0, 0, 240, 240, arrayOfInt, 0);
            p = Image.CreateImage(240, 240);
            Graphics graphics;
            (graphics = p.GetGraphics()).Lock();
            graphics.SetPixels(0, 0, 240, 240, arrayOfInt, 0);
            graphics.Unlock(false);
            //System.gc();
            return;
        }
        catch (Exception exception)
        {
            p = Image.CreateImage(1, 1);
            return;
        }
    }

    [FunctionName("b")]
    private static void b1(Graphics paramGraphics)
    {
        q--;
        if (q <= 0)
        {
            q = 0;
            paramGraphics.DrawImage(p, 0, 0);
            p.Dispose();
            p = null;
            //System.gc();
        }
    }

    static DownloadManager()
    {
        Graphics.GetColorOfRGB(255, 0, 0);
        Graphics.GetColorOfRGB(96, 96, 96);
        Graphics.GetColorOfRGB(48, 48, 48);

        Font.GetFont(0x71100100);

        (new JavaString[3])[0] = "今日のランキング";
        (new JavaString[3])[1] = "月間ランキング";
        (new JavaString[3])[2] = "通算ランキング";
        (new JavaString[3])[0] = "今日";
        (new JavaString[3])[1] = "月間";
        (new JavaString[3])[2] = "通算";
        (new JavaString[2])[0] = "上位";
        (new JavaString[2])[1] = "自分";
    }
}
