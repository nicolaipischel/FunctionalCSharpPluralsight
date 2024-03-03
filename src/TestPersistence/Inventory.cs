using System.ComponentModel.Design;
using Application;
using Models.Types.Common;
using Models.Types.Components;

namespace TestPersistence;

public class Inventory : IReadOnlyRepository<(Part part, DiscreteMeasure quantity)>
{
    private readonly IReadOnlyRepository<Part> _parts;

    public Inventory(IReadOnlyRepository<Part> parts)
    {
        _parts = parts;
    }

    public Option<(Part part, DiscreteMeasure quantity)> TryFind(Guid id) =>
        _parts.TryFind(id).Filter(Exists).Map(part => (part, QuantityFor(part)));

    private static DiscreteMeasure QuantityFor(Part part) =>
        new("Piece", Exists(part) ? 1U : 0);
    
    public IEnumerable<(Part part, DiscreteMeasure quantity)> GetAll() =>
        _parts.GetAll().Where(Exists).Select(part => (part, QuantityFor(part)));

    private static bool Exists(Part part) => part.Sku.Value[part.Sku.Value.Length / 2] % 5 == 2;
}
