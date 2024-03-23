using System.Drawing;

namespace com.nttdocomo.ui;

public abstract class Canvas : Frame
{
    private int _keypadState;

    private readonly Graphics _graphics = new(new Image(new Bitmap(240, 240)));

    // CUSTOM: To receive key information from external code and hold it in the SDK
    public void receiveEvent(int eventType, int eventArg)
    {
        processEvent(eventType, eventArg);

        switch (eventType)
        {
            case Display.EVENT_KEY_PRESSED:
                _keypadState |= 1 << eventArg;
                break;

            case Display.EVENT_KEY_RELEASED:
                _keypadState &= ~(1 << eventArg);
                break;
        }
    }

    protected abstract void processEvent(int eventType, int eventArg);

    public Graphics GetGraphics() => _graphics;

    public void SetBackground(int color)
    {
        _graphics.SetColor(color);
        _graphics.FillRect(0, 0, GetWidth(), GetHeight());
    }

    public int GetWidth() => 240;
    public int GetHeight() => 240;

    public int GetKeypadState() => _keypadState;
}