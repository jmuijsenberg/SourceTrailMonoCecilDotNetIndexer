
namespace SourceTrailCecilDotNetIndexer.Data
{
    public interface IDataRelation
    {
        int ConsumerId{ get; }
        int ProviderId { get; }
        string Type { get; }
        int Weight { get; }
        string Annotation { get; }
    }
}
