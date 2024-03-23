namespace com.nttdocomo.ui;

public class Dialog : Frame
{
    private readonly int _type;
    private readonly string _title;

    public Dialog(int type, string title)
    {
        _type = type;
        _title = title;
    }

    public void SetText(string text) { }
    public void Show() { }
}
