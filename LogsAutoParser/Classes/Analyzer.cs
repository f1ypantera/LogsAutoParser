using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (settingProvider.GetTemplate().Contains(oneString))
                {
                    analyzeLogs.Add(oneString);
                }
            }

            return analyzeLogs;
        }
        public void AnalyzeWithRegex()
        {
            var allStringFromFiles = reader.ReadLogsFromFiles(dataMiner.Catalog(settingProvider.GetPathToCatalog()));
            Regex regex = new Regex(@"\w*vad\w*");
            foreach (var oneString in allStringFromFiles)
            {
                MatchCollection matches = regex.Matches(oneString);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        Console.WriteLine(match.Value);
                }
            }
                
        }
    }
}
