namespace SourceTrailCecilDotNetIndexer.Analyzer
{
    public class DotNetType
    {
        public DotNetType(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public string Type { get; }
    }
}
