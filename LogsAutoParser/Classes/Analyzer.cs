using System;
using System.Collections.Generic;
using System.Text;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class Analyzer : IAnalyzer
    {
        private readonly ISettingProvider settingProvider;
        private readonly IReader reader;
        private readonly IDataMiner dataMiner;
        List<string> analyzeLogs = new List<string>();
        public Analyzer(ISettingProvider settingProvider,IReader reader, IDataMiner  dataMiner)
        {
            this.settingProvider = settingProvider;
            this.reader = reader;
            this.dataMiner = dataMiner;
        }

        public IEnumerable<string> AnalyzeSteps()
        {
            var allStringFromFiles = reader.ReadLogsFromFiles(dataMiner.Catalog(settingProvider.GetPathToCatalog()));
            foreach (var oneString in allStringFromFiles)
            {
                if (settingProvider.GetLog().Contains(oneString))
                {
                   analyzeLogs.Add(oneString);
                }
            }

            return analyzeLogs;
        }
    }
}
