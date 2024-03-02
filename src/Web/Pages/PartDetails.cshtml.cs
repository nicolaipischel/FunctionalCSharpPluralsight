using Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Media;
using Models.Types;

namespace Web.Pages;

public class PartDetailsModel : PageModel
{
    private readonly IReadOnlyRepository<Part> _parts;

    public PartDetailsModel(IReadOnlyRepository<Part> parts)
    {
        _parts = parts;
    }

    public Part Part { get; set; } = null!;
    public FileContent BarcodeImage { get; set; } = null!;
    
    public void OnGet(Guid id)
    {
        this.Part = _parts.Find(id);
        this.BarcodeImage = this.GenerateBarcode(this.Part.Sku);
    }

    private Func<StockKeepingUnit, FileContent> GenerateBarcode =>
        BarcodeGeneration.ToCode39(this.Margins, this.Style);

    private BarcodeGeneration.Margins Margins => new(
        Horizontal: 20, Vertical: 10, BarHeightInPixel: 200);

    private BarcodeGeneration.Style Style => new(
        ThinBarWidth: 4, ThickBarWidth: 10, GapWidth: 4, Padding: 4, IsAntialiasingEnabled: false);
}
