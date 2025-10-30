namespace com.nttdocomo.ui;

public class PalettedImage : Image
{
    private Palette _palette;

    public PalettedImage(byte[] data) : base(data)
    {
        _palette = new(0);
    }

    public static PalettedImage CreatePalettedImage(byte[] data) => new PalettedImage(data);

    public Palette GetPalette() => _palette;
    public void SetPalette(Palette p) => _palette = p;
}