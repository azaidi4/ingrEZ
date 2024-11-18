public class ComponentMetadata
{
  public required Type Type { get; init; }
  public Dictionary<string, object> Parameters { get; } = [];
}
