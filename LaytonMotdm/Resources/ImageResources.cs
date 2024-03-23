using System.Drawing;
using System.Reflection;

namespace LaytonMotdm.Resources
{
    static class ImageResources
    {
        private const string IconResource_ = "LaytonMotdm.Resources.Images.layton.ico";

        public static Image Icon => FromResource(IconResource_);

        private static Image FromResource(string name)
        {
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
            return resourceStream == null ? null : Image.FromStream(resourceStream);
        }
    }
}
