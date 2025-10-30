using com.nttdocomostar.ui.util3d;

namespace com.nttdocomostar.ui.graphics3d
{
    public class Graphics3D
    {
        private Graphics3D(Graphics g) { }

        public void SetPerspectiveView(float var1, float var2, float var3) { }
        public void SetTransform(Transform var1) { }
        public void ResetLights() { }
        public void AddLight(Light var1, Transform var2) { }
        public void RenderObject3D(Primitive var1, Transform var2) { }
        public void RenderObject3D(Figure var1, Transform var2) { }
        public void FlushBuffer() { }

        public static explicit operator Graphics3D(Graphics b) => new Graphics3D(b);
    }
}
