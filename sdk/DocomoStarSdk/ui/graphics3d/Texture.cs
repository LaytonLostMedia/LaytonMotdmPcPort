namespace com.nttdocomostar.ui.graphics3d
{
    public class Texture
    {
        private byte[] _data;

        private Texture(byte[] data) => _data = data;

        public static Texture CreateInstance(byte[] var1) => new Texture(var1);

        public void SetBlendMode(int var1) { }
        public void SetTransparency(float var1) { }

        public void Dispose() => _data = null;
    }
}
