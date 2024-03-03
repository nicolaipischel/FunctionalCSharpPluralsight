using Models.Common;
using Models.Media.Types;
using SkiaSharp;

namespace Models.Media;

public static class Code39Generator
{
    // Is obsolete because of the Apply Extension on the delegate type but I still want to keep it as a reference.
    // public static BarcodeGenerator ToCode39(Margins margins, Style style) =>
    //     sku => ToCode39Internal(margins, style, sku);
    
    // https://en:wikipedia.org/wiki/Code_39
    // Take SKU string, convert to Code39 bars, draw to bitmap, encode to png
    public static BarcodeGeneratorExtended ToCode39 => (margins, style, sku) =>
        sku.Value.ToCode39Bars().ToCode39Bitmap(margins, style).ToPng();

    // Take bar widths, convert to graphical lines, draw on the bitmap
    private static SKBitmap ToCode39Bitmap(this IEnumerable<int> bars, BarcodeMargins margins, Code39Style style) =>
        bars.ToGraphicalLines(style).ToBarcodeBitmap(margins, style);

    // Take bar widths, convert them to corresponding graphical lines
    private static SKPaint[] ToGraphicalLines(this IEnumerable<int> bars, Code39Style style) =>
        bars.ToGraphicalLines(Gap(style), ThinBar(style), ThickBar(style));

    // * Bridges the gap between bar widths and actual lines with those widths. *
    // Take bar widths select a corresponding graphical line for each
    private static SKPaint[] ToGraphicalLines(this IEnumerable<int> bars, params SKPaint[] lines) =>
        bars.Select(bar => lines[bar]).ToArray();

    // Specify thick, thin bar and a gap according to requirements.
    private static SKPaint ThickBar(Code39Style style) => Bar(SKColors.Black, style.ThickBarWidth, style.IsAntialiasingEnabled);
    private static SKPaint ThinBar(Code39Style style) => Bar(SKColors.Black, style.ThinBarWidth, style.IsAntialiasingEnabled);
    private static SKPaint Gap(Code39Style style) => Bar(SKColors.Transparent, style.GapWidth, style.IsAntialiasingEnabled);
    
    private static SKPaint Bar(SKColor color, float thickness, bool antialias) => new()
    {
        Color = color,
        Style = SKPaintStyle.Stroke,
        StrokeCap = SKStrokeCap.Butt,
        StrokeWidth = thickness,
        IsAntialias = antialias
    };

    private static SKBitmap ToBarcodeBitmap(this SKPaint[] bars, BarcodeMargins margins, Code39Style style)
    {
        float horizontalMargin = margins.Horizontal;
        float barHeight = margins.BarHeightInPixel;
        float verticalMargin = margins.Vertical;
        float padding = style.Padding;
        float barsWidth = bars.Sum(bar => bar.StrokeWidth);
        float height = barHeight + 2 * verticalMargin;
        float width = barsWidth + (bars.Length - 1) * padding + 2 * horizontalMargin;

        SKBitmap bitmap = InitializeBitmap(width, height);
        SKCanvas canvas = new(bitmap);

        float offset = horizontalMargin;
        foreach (SKPaint bar in bars)
        {
            float x = offset + bar.StrokeWidth / 2;
            canvas.DrawLine(x, verticalMargin, x, barHeight + verticalMargin, bar);
            offset += bar.StrokeWidth + padding;
        }

        return bitmap;
    }

    private static SKBitmap InitializeBitmap(float width, float height)
    {
        SKBitmap bitmap = new((int)Math.Ceiling(width), (int)Math.Ceiling(height));
        SKCanvas canvas = new(bitmap);
        canvas.Clear(SKColors.White);
        
        return bitmap;
    }
        
}
