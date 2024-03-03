using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Media;
using Models.Types;
using Models.Types.Components;
using Models.Types.Media;
using Web.Configuration;

namespace Web.Pages;

public class PartDetailsModel : PageModel
{
    private readonly IReadOnlyRepository<Part> _parts;

    public PartDetailsModel(IReadOnlyRepository<Part> parts, BarcodeGeneratorFactory factory)
    {
        _parts = parts;
        this.GenerateBarcode = factory.Print;
    }

    public Part Part { get; set; } = null!;
    public FileContent BarcodeImage { get; set; } = null!;
    
    public void OnGet(Guid id)
    {
        this.Part = _parts.Find(id);
        this.BarcodeImage = this.GenerateBarcode(this.Part.Sku);

        // Example to show how partial application would work inline.
        // var skus = Enumerable.Empty<StockKeepingUnit>();
        // var f = Code39Generator.ToCode39.Apply(this.Margins, this.Style);
        
        // We need to pass the Invoke of the delegate because
        // a strongly typed delegate do not derive from Action/Func delegates. 
        // var barcodes = skus.Select(f.Invoke);

        // We must rely on lamdas because its safe to assign a lamda to a Func delegate
        // and we cannot assign strongly typed delegates to Func/Action or the other way around directly.
        // Func<StockKeepingUnit, FileContent> func = x => f(x);
        // BarcodeGenerator g = x => func(x);
    }

    private BarcodeGenerator GenerateBarcode { get; }
}
