namespace SourceTrailCecilDotNetIndexer.Analysis
{
    public class FoundEdge
    {
        public FoundEdge(string consumerName, string providerName, string type)
        {
            ConsumerName = consumerName;
            ProviderName = providerName;
            Type = type;
        }

        public string ConsumerName { get; }
        public string ProviderName { get; }
        public string Type { get; }
    }
}
