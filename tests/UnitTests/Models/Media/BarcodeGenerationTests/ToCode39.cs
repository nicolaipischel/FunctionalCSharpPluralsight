using System.Text;
using Models.Media;
using Models.Types;

namespace UnitTests.Models.Media.BarcodeGenerationTests;

public sealed class ToCode39
{
    [Fact]
    public void Returns_BarcodePngAsByteArray_Given_SkuAndBarHeight()
    {
        var sku = new StockKeepingUnit("BT9V");
        var barHeightInPixel = 25;

        var margins = new BarcodeGeneration.Margins(0.5f, 0.2f, 25);
        var style = new BarcodeGeneration.Style(1.5f, 2.5f, 2.0f, 2.0f, true);
        var toCode39 = BarcodeGeneration.ToCode39(margins, style);
        var actual = toCode39(sku);
        
        // We cannot really verify the internal structure of the byte array..
        // That is why this is the probably the only way to verify the function is working as expected.
        Assert.NotEmpty(actual.Content);
        Assert.Equal("image/png", actual.MimeType);
    }
}
