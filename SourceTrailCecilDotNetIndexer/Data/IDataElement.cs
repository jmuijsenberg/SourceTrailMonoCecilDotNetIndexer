namespace SourceTrailCecilDotNetIndexer.Data
{
    public interface IDataElement
    {
        int Id { get; }
        string Name { get; }
        string Type { get; }
        string Annotation { get; }
    }
}
