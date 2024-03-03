using Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Media;
using Models.Types;
using Models.Types.Components;
using Web.Configuration;

namespace Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IReadOnlyRepository<Part> _parts;

    public IndexModel(
        ILogger<IndexModel> logger,
        IReadOnlyRepository<Part> parts,
        BarcodeGeneratorFactory factory)
    {
        _logger = logger;
        _parts = parts;
        this.BarcodeGenerator = factory.Inline;
    }

    public IEnumerable<Part> AllParts { get; set; } = Enumerable.Empty<Part>();
    public BarcodeGenerator BarcodeGenerator { get; }

    public void OnGet()
    {
        this.AllParts = _parts.GetAll().ToList();
    }
}
