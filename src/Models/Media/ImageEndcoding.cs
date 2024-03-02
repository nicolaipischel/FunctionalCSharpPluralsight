using Models.Types;
using SkiaSharp;

namespace Models.Media;

internal static class ImageEndcoding
{
    public static FileContent ToPng(this SKBitmap bitmap) =>
        new(bitmap.Encode(SKEncodedImageFormat.Png, 100).ToArray(), "image/png");
}
