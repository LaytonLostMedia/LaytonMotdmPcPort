namespace com.nttdocomostar.ui.graphics3d
{
    public class ActionTable
    {
        private byte[] _data;
        private ActionTable(byte[] data) => _data = data;
        public static ActionTable CreateInstance(byte[] data) => new ActionTable(data);
        public int GetNumActions() => 0;
        public int GetMaxFrame(int var1) => 0;
        public void Dispose() => _data = null;
    }
}
