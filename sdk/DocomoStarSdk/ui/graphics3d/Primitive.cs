using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.nttdocomostar.ui.graphics3d
{
    public class Primitive
    {
        public Primitive(byte var1, int var2, int var3)
        {

        }

        public int[] GetVertexArray() => new int[0];
        public short[] GetTextureCoordArray() => new short[0];
        public int[] GetNormalArray() => new int[0];
        public int[] GetColorArray() => new int[0];

        public void SetPerspectiveCorrectionEnabled(bool toggle) { }

        public void SetTexture(Texture var1) { }
        public void SetTransparency(float var1) { }
        public void SetBlendMode(int var1) { }

        public void Dispose() { }
    }
}
