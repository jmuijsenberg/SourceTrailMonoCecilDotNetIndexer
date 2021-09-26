namespace SourceTrailCecilDotNetIndexer.Data
{
    /// <summary>
    /// Interface to the data model. An interface has been introduced to improve testability.
    /// </summary>
    public interface IDataModel
    {
        IDataElement AddElement(string name, string type, string annotation);

        IDataRelation AddRelation(string consumerName, string providerName, string type, int weight, string annotation);

        void SkipRelation(string consumerName, string providerName, string type);

        int CurrentElementCount { get; }

        int CurrentRelationCount { get; }

        double ResolvedRelationPercentage { get; }
    }
}
