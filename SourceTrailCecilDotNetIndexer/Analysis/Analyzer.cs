using System;
using System.Collections.Generic;
using System.IO;
using SourceTrailCecilDotNetIndexer.Settings;
using SourceTrailCecilDotNetIndexer.Data;
using SourceTrailCecilDotNetIndexer.Util;

namespace SourceTrailCecilDotNetIndexer.Analysis
{
    public class Analyzer
    {
        private readonly IDataModel _model;
        private readonly AnalyzerSettings _analyzerSettings;
        private readonly IProgress<ProgressInfo> _progress;
        private readonly List<AnalyzedAssembly> _assemblyFiles = new List<AnalyzedAssembly>();
        private readonly DotNetResolver _resolver = new DotNetResolver();

        public Analyzer(IDataModel model, AnalyzerSettings analyzerSettings, IProgress<ProgressInfo> progress)
        {
            _model = model;
            _analyzerSettings = analyzerSettings;
            _progress = progress;
        }

        public void Analyze()
        {
            FindAssemblies();
            FindTypes();
            FindRelations();
        }

        private void FindAssemblies()
        {
            foreach (string assemblyFilename in Directory.EnumerateFiles(_analyzerSettings.Input.AssemblyDirectory))
            {
                AnalyzedAssembly assemblyFile = new AnalyzedAssembly(assemblyFilename, _progress);

                if (assemblyFile.Exists && assemblyFile.IsAssembly)
                {
                    _assemblyFiles.Add(assemblyFile);
                    _resolver.AddSearchPath(assemblyFile);
                    UpdateAssemblyProgress(false);
                }
            }
            UpdateAssemblyProgress(true);
        }

        private void FindTypes()
        {
            foreach (AnalyzedAssembly assemblyFile in _assemblyFiles)
            {
                assemblyFile.FindTypes(_resolver);
                foreach (FoundNode type in assemblyFile.Types)
                {
                    _model.AddElement(type.Name, type.Type, null);
                }
            }
        }

        private void FindRelations()
        {
            foreach (AnalyzedAssembly assemblyFile in _assemblyFiles)
            {
                assemblyFile.FindRelations();
                foreach (FoundEdge relation in assemblyFile.Relations)
                {
                    _model.AddRelation(relation.ConsumerName, relation.ProviderName, relation.Type, 1, null);
                }
            }
        }

        private void UpdateAssemblyProgress(bool done)
        {
            ProgressInfo progressInfo = new ProgressInfo
            {
                ActionText = "Finding assemblies",
                CurrentItemCount = _assemblyFiles.Count,
                TotalItemCount = 0,
                ItemType = "assemblies",
                Percentage = null,
                Done = done
            };
            _progress?.Report(progressInfo);
        }
    }
}
