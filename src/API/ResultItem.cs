namespace EverythingCli.API;

public record ResultItem
{
    public string Name { get; init; } = "";
    public string Path { get; init; } = "";
    public long Bytes { get; init; }
    public DateTime DateModified { get; init; }
}