namespace com.nttdocomostar.fs;

public class StarAccessToken : AccessToken
{
    public static explicit operator byte[](StarAccessToken b) => new byte[0];
}

