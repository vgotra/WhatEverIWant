# TODO List

- Check according to logic should property similar to **AudioCollection** be required or not. Especially for db implementation. Because if this item exist then it should have properties not null.

- Also, do I need those classes, or they can be automatically created by EF Core for many-to-many relations? It can simplify a lot, but also such entities can help a lot in JOIN queries.

```csharp
public class AudioBookCollectionItem
{
    public Guid AudioCollectionId { get; set; }
    public AudioBookCollection AudioCollection { get; set; }

    public Guid AudioBookId { get; set; }
    public AudioBook AudioBook { get; set; }
}
```