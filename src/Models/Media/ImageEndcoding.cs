using Models.Types;
using SkiaSharp;

namespace Models.Media;

internal static class ImageEndcoding
{
    public static FileContent ToPng(this SKBitmap bitmap) =>
        new(Array.Empty<byte>(), string.Empty);
}
