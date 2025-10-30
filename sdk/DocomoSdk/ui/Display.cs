namespace com.nttdocomo.ui;

public class Display
{
    private static Frame _current;

    public static void SetCurrent(Frame frame) => _current = frame;
    public static Frame GetCurrent() => _current;

    public const int EVENT_KEY_PRESSED = 0;
    public const int EVENT_KEY_RELEASED = 1;
    public const int EVENT_RESUME_VM = 4;
    public const int EVENT_UPDATE_VM = 6;
    public const int EVENT_TIMER_EXPIRED = 7;

    public const int EVENT_KEY_ZERO = 0;
    public const int EVENT_KEY_ONE = 1;
    public const int EVENT_KEY_TWO = 2;
    public const int EVENT_KEY_THREE = 3;
    public const int EVENT_KEY_FOUR = 4;
    public const int EVENT_KEY_FIVE = 5;
    public const int EVENT_KEY_SIX = 6;
    public const int EVENT_KEY_SEVEN = 7;
    public const int EVENT_KEY_EIGHT = 8;
    public const int EVENT_KEY_NINE = 9;

    public const int EVENT_KEY_FUNCTION = 11;

    public const int EVENT_KEY_LEFT = 16;
    public const int EVENT_KEY_UP = 17;
    public const int EVENT_KEY_RIGHT = 18;
    public const int EVENT_KEY_DOWN = 19;
    public const int EVENT_KEY_MAIN = 20;

    public const int KEY_ZERO = 0x000001;
    public const int KEY_ONE = 0x000002;
    public const int KEY_TWO = 0x000004;
    public const int KEY_THREE = 0x000008;
    public const int KEY_FOUR = 0x000010;
    public const int KEY_FIVE = 0x000020;
    public const int KEY_SIX = 0x000040;
    public const int KEY_SEVEN = 0x000080;
    public const int KEY_EIGHT = 0x000100;
    public const int KEY_NINE = 0x000200;

    public const int KEY_FUNCTION = 0x000800;

    public const int KEY_LEFT = 0x010000;
    public const int KEY_UP = 0x020000;
    public const int KEY_RIGHT = 0x040000;
    public const int KEY_DOWN = 0x080000;
    public const int KEY_MAIN = 0x100000;
}