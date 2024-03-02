namespace Models.Types;

public record FileContent(byte[] Content, string MimeType);

public record StringEncodedFile(string Content);
