using Mono.Cecil;
using System.Collections.Generic;

namespace SourceTrailCecilDotNetIndexer.Analysis
{
    public class DotNetResolver
    {
        private readonly HashSet<string> _paths = new HashSet<string>();

        public void AddSearchPath(AnalyzedAssembly assemblyFile)
        {
            string path = assemblyFile.FileInfo.DirectoryName;
            if (path != null && !_paths.Contains(path))
            {
                _paths.Add(path);
            }
        }

        public ReaderParameters ReaderParameters
        {
            get
            {
                DefaultAssemblyResolver resolver = new DefaultAssemblyResolver();

                foreach (string path in _paths)
                {
                    resolver.AddSearchDirectory(path);
                }

                return new ReaderParameters() { AssemblyResolver = resolver };
            }
        }
    }
}
