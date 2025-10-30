namespace com.nttdocomostar.ui;

public class Palette
{
    private readonly byte[] _data;
    private readonly int _entryCount;

    public Palette(byte[] data)
    {
        _data = data;
        _entryCount = 0;
    }

    public Palette(int count)
    {
        _entryCount = count;
    }

    public int GetEntryCount() => _entryCount;

    public int GetEntry(int index) => -1;

    public void SetEntry(int index, int value) { }
}
