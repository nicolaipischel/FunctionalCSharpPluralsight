using Models.Common;
using Models.Functions.Media.Types;
using Models.Types;

namespace Models.Media;

// Using domain-related types (SKU)
public delegate FileContent BarcodeGenerator(StockKeepingUnit sku);
// Using infrastructural/configuration types (BarcodeMargins, Code39Style)
public delegate FileContent BarcodeGeneratorExtended(
    BarcodeMargins margins, Code39Style style, StockKeepingUnit sku);

public static class BarcodeGenerationExtensions
{
    // Bridges the gap between the full signature function and the partially applied one.
    public static BarcodeGenerator Apply(this BarcodeGeneratorExtended f,
        BarcodeMargins margins, Code39Style style) =>
        sku => f(margins, style, sku);
}
