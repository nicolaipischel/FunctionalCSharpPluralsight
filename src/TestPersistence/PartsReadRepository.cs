using Application;
using Models.Types;
using Models.Types.Components;

namespace TestPersistence;

public sealed class PartsReadRepository : IReadOnlyRepository<Part>
{
    // Specification of material for the traffic light DIY project
    // Source: https://www.instructables.com/Traffic-Light-Project/
    public IEnumerable<Part> GetAll() => new Part[]
    {
        new(Ids[0], "Transistor BC547", new StockKeepingUnit("ELTRBC547")),
        new(Ids[1], "Resistor 1K", new StockKeepingUnit("ELRS1K")),
        new(Ids[2], "Resistor 100K", new StockKeepingUnit("ELRS100K")),
        new(Ids[3], "Resistor 33K", new StockKeepingUnit("ELRS33K")),
        new(Ids[4], "LED Red 3V", new StockKeepingUnit("ELLD3VRED")),
        new(Ids[5], "LED Yellow 3V", new StockKeepingUnit("ELLD3VYELLOW")),
        new(Ids[6], "LED Green 3V", new StockKeepingUnit("ELLD3VGREEN")),
        new(Ids[7], "Capacitor 470uF 25V", new StockKeepingUnit("ELCP470UF25V")),
        new(Ids[8], "Capacitor 100uF 25V", new StockKeepingUnit("ELCP100UF25V")),
        new(Ids[9], "Battery 9V", new StockKeepingUnit("BT9V")),
        new(Ids[10], "Battery clipper Type A", new StockKeepingUnit("BTCLA"))
    };

    public Part Find(Guid id) => GetAll().Single(part => part.Id == id);
    
    private static Guid[] Ids { get; } =
        Enumerable.Range(0, 1000).Select(_ => Guid.NewGuid()).ToArray();
}
