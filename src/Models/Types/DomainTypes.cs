namespace Models.Types;

public record StockKeepingUnit(string Value);
public record Vendor(Guid Id, string Name);
public record ExternalSkuPhoto(byte[] Content, string MimeType, Vendor Vendor);
public record Part(string Name, StockKeepingUnit Sku);
public record ExternalSku(StockKeepingUnit Sku, Vendor Vendor);
public record ExternalPart(Part Part, ExternalSku Sku);
