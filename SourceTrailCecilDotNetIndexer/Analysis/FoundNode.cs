namespace SourceTrailCecilDotNetIndexer.Analysis
{
    public class FoundNode
    {
        public FoundNode(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public string Type { get; }
    }
}
