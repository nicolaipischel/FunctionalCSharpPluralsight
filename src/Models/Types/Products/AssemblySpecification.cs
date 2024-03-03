using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Models.Types.Common;
using Models.Types.Components;

namespace Models.Types.Products;

public class AssemblySpecification
{
    public AssemblySpecification(Guid id) =>
        (Id, Instructions) = (id, ImmutableList<AssemblyInstruction>.Empty);

    [SetsRequiredMembers]
    public AssemblySpecification(AssemblySpecification other) =>
        (Id, Name, Description, Instructions) =
        (other.Id, other.Name, other.Description, other.Instructions);
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    
    private ImmutableList<AssemblyInstruction> Instructions { get; init; }

    public AssemblySpecification Add(params AssemblyInstruction[] instructions) =>
        new(this) { Instructions = this.Instructions.AddRange((instructions)) };

    public IEnumerable<(Part part, DiscreteMeasure quantity)> Components { get; init; } =
        Enumerable.Empty<(Part, DiscreteMeasure)>();

    public IEnumerable<(InventoryItem item, Measure quantity)> Consumables { get; init; } =
        Enumerable.Empty<(InventoryItem, Measure)>();
}
