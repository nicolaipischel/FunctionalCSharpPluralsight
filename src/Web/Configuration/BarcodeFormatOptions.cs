namespace Web.Configuration;

public class BarcodeFormatOptions
{
    public const string SectionKeyName = "BarcodeFormats";
    public const string Inline = "Inline";
    public const string Print = "Print";

    public BarcodeFormat[] Formats { get; set; } = Array.Empty<BarcodeFormat>();
}
