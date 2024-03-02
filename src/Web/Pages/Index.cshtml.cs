using Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Functions.Media.Types;
using Models.Media;
using Models.Types;

namespace Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IReadOnlyRepository<Part> _parts;

    public IndexModel(ILogger<IndexModel> logger, IReadOnlyRepository<Part> parts)
    {
        _logger = logger;
        _parts = parts;
    }

    public IEnumerable<Part> AllParts { get; set; } = Enumerable.Empty<Part>();

    public BarcodeMargins Margins { get; } = new(
        Horizontal: 5, Vertical: 3, BarHeightInPixel: 25);

    public Code39Style Style { get; } = new(
        ThinBarWidth: 1.5f, ThickBarWidth: 4, GapWidth: 2, Padding: 2, IsAntialiasingEnabled: true);

    public void OnGet()
    {
        this.AllParts = _parts.GetAll().ToList();
        
    }
}
