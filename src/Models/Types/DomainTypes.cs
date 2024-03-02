namespace Models.Types;

public record StockKeepingUnit(string Value);
public record Vendor(Guid Id, string Name);
public record ExternalSkuPhoto(FileContent Content, Vendor Vendor);

public abstract record InventoryItem(Guid Id, string Name, StockKeepingUnit Sku);
public record Part(Guid Id, string Name, StockKeepingUnit Sku) 
    : InventoryItem(Id, Name, Sku);

public record Material(Guid Id, string Name, StockKeepingUnit Sku, ContinousMeasure Quanity)
    : InventoryItem(Id, Name, Sku);
public record ExternalSku(StockKeepingUnit Sku, Vendor Vendor);
public record ExternalPart(Part Part, ExternalSku Sku);
