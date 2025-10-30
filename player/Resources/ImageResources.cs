using System.Reflection;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace DoCoMoPlayer.Resources
{
    static class ImageResources
    {
        private const string IconResource_ = "icon.jpg";

        public static Image<Rgba32> Icon => FromResource(IconResource_);

        private static Image<Rgba32> FromResource(string name)
        {
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
            return resourceStream == null ? null : Image.Load<Rgba32>(resourceStream);
        }
    }
}
