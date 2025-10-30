using DocomoCsJavaBridge;
using System.Drawing;

namespace com.nttdocomostar.ui;

public abstract class Canvas : Frame
{
    private int _keypadState;

    private Graphics? _graphics;

    // CUSTOM: Propagate finished frame rendering
    public static event EventHandler<FrameCompleteEventArgs>? FrameCompleted;

    // CUSTOM: Propagate finished frame rendering
    public static event EventHandler<EventsReceivedEventArgs>? EventsReceived;

    public Canvas()
    {
        EventsReceived += Canvas_EventsReceived;
    }

    // CUSTOM: Propagate finished frame rendering
    public void RaiseFrameCompleted(bool isFinal)
    {
        FrameCompleted?.Invoke(this, new FrameCompleteEventArgs(_graphics, isFinal));
    }

    private void Canvas_EventsReceived(object? sender, EventsReceivedEventArgs e)
    {
        processEvent(e.EventType, e.EventArg);

        switch (e.EventType)
        {
            case Display.EVENT_KEY_PRESSED:
                _keypadState |= 1 << e.EventArg;
                break;

            case Display.EVENT_KEY_RELEASED:
                _keypadState &= ~(1 << e.EventArg);
                break;
        }
    }

    // CUSTOM: To receive key information from external code and hold it in the SDK
    public static void receiveEvent(int eventType, int eventArg)
    {
        EventsReceived?.Invoke(null, new EventsReceivedEventArgs(eventType, eventArg));
    }

    public virtual void processEvent(int eventType, int eventArg) { }

    public Graphics GetGraphics() => _graphics ??= new(new Image(new Bitmap(GetWidth(), GetHeight())));

    public void SetBackground(int color)
    {
        _graphics.SetColor(color);
        _graphics.FillRect(0, 0, GetWidth(), GetHeight());
    }

    public int GetWidth() => AppInfo.GetAppWidth();
    public int GetHeight() => AppInfo.GetAppHeight();

    public int GetKeypadState() => _keypadState;

    public class FrameCompleteEventArgs : EventArgs
    {
        public bool IsFinalFrame { get; }

        public Graphics Graphics { get; }

        public FrameCompleteEventArgs(Graphics graphics, bool isFinalFrame)
        {
            Graphics = graphics;
            IsFinalFrame = isFinalFrame;
        }
    }

    public class EventsReceivedEventArgs : EventArgs
    {
        public int EventType { get; }
        public int EventArg { get; set; }

        public EventsReceivedEventArgs(int eventType, int eventArg)
        {
            EventType = eventType;
            EventArg = eventArg;
        }
    }
}