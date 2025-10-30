using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.nttdocomostar.ui.util3d
{
    public class Transform
    {
        public Transform() { }
        public Transform(Transform transform) { }

        public float Get(int var1) => 0;
        public void Set(int var1, float var2) { }
        public void SetIdentity() { }
        public void TransVector(Vector3D var1, Vector3D var2) { }
        public void LookAt(Vector3D var1, Vector3D var2, Vector3D var3) { }
        public void Scale(float var1, float var2, float var3) { }
        public void Rotate(float var1, float var2, float var3, float var4) { }
        public void Multiply(Transform var1) { }
    }
}
