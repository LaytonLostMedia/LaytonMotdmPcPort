using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.nttdocomostar.ui.util3d
{
    public class Vector3D
    {
        private float x;
        private float y;
        private float z;

        public Vector3D() { }

        public Vector3D(float var1, float var2, float var3)
        {
            x = var1;
            y = var2;
            z = var3;
        }

        public void Set(Vector3D vector)
        {
            Set(vector.x,vector.y,vector.z);
        }

        public void Set(float var1, float var2, float var3)
        {
            x = var1;
            y = var2;
            z = var3;
        }

        public float GetX() => x;
        public float GetY() => y;
        public float GetZ() => z;

        public void SetX(float var1) => x = var1;
        public void SetY(float var1) => y = var1;
        public void SetZ(float var1) => z = var1;
    }
}
