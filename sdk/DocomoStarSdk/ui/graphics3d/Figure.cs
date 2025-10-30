namespace com.nttdocomostar.ui.graphics3d
{
    public class Figure
    {
        private byte[] _data;
        private Figure(byte[] data) => _data = data;
        public static Figure CreateInstance(byte[] data) => new Figure(data);
        public void SetPerspectiveCorrectionEnabled(bool var1) { }
        public void SetTime(int time) { }
        public void SetAction(ActionTable var1, int var2) { }
        public void SetBlendMode(int var1) { }
        public void SetTransparency(float var1) { }
        public void SetTexture(Texture var1) { }
        public void Dispose() => _data = null;
    }
}
