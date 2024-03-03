using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Types.Common;
using Models.Types.Products;

namespace Web.Pages;

public class SpecDetailsModel : PageModel
{
    private IReadOnlyRepository<AssemblySpecification> Specifications;

    public SpecDetailsModel(IReadOnlyRepository<AssemblySpecification> Specifications) =>
        this.Specifications = Specifications;

    public AssemblySpecification Specification { get; set; } = null!;

    public IActionResult OnGet(Guid id) =>
        Specifications.TryFind(id)
            .Map(spec =>
            {
                this.Specification = spec;
                return (IActionResult)Page();
            }).Reduce(NotFound);
}
