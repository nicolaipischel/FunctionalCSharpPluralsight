using Models.Types.Common;
using Models.Types.Components;

namespace Models.Types.Products;

public class AssemblySpecification
{
    public AssemblySpecification(Guid id) => Id = id;
    
    public AssemblySpecification(AssemblySpecification other) =>
        (Id, Name, Description) = (other.Id, other.Name, other.Description);
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }

    public IEnumerable<(Part part, DiscreteMeasure quantity)> Components { get; init; } =
        Enumerable.Empty<(Part, DiscreteMeasure)>();

    public IEnumerable<(InventoryItem item, Measure quantity)> Consumables { get; init; } =
        Enumerable.Empty<(InventoryItem, Measure)>();
}
