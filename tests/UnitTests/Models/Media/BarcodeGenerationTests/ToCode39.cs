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

        var actual = sku.ToCode39(barHeightInPixel);
        
        // We cannot really verify the internal structure of the byte array..
        // That is why this is the probably the only way to verify the function is working as expected.
        Assert.NotEmpty(actual.Content);
        Assert.Equal("image/png", actual.MimeType);
    }
}
