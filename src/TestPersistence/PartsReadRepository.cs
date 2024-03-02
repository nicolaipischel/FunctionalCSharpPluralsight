using Application;
using Models.Types;

namespace TestPersistence;

public sealed class PartsReadRepository : IReadOnlyRepository<Part>
{
    // Specification of material for the traffic light DIY project
    // Source: https://www.instructables.com/Traffic-Light-Project/
    public IEnumerable<Part> GetAll() => new Part[]
    {
        new("Transistor BC547", new StockKeepingUnit("ELTRBC547")),
        new("Resistor 1K", new StockKeepingUnit("ELRS1K")),
        new("Resistor 100K", new StockKeepingUnit("ELRS100K")),
        new("Resistor 33K", new StockKeepingUnit("ELRS33K")),
        new("LED Red 3V", new StockKeepingUnit("ELLD3VRED")),
        new("LED Yellow 3V", new StockKeepingUnit("ELLD3VYELLOW")),
        new("LED Green 3V", new StockKeepingUnit("ELLD3VGREEN")),
        new("Capacitor 470uF 25V", new StockKeepingUnit("ELCP470UF25V")),
        new("Capacitor 100uF 25V", new StockKeepingUnit("ELCP100UF25V")),
        new("Battery 9V", new StockKeepingUnit("BT9V")),
        new("Battery clipper Type A", new StockKeepingUnit("BTCLA"))
    };
}
