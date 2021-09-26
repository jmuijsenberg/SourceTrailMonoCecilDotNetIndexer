
namespace SourceTrailCecilDotNetIndexer.Data
{
    class DataModel : IDataModel
    {
        public IDataElement AddElement(string name, string type, string annotation)
        {
            return null;
        }

        public IDataRelation AddRelation(string consumerName, string providerName, string type, int weight, string annotation)
        {
            return null;
        }

        public void SkipRelation(string consumerName, string providerName, string type)
        {
        }

        public int CurrentElementCount => 0;

        public int CurrentRelationCount => 0;

        public double ResolvedRelationPercentage => 0.0;
    }
}
