using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IAnalyzer
    {
        void DeepAnalyzingLogsById(List<string> patternList);
        void FilterRowsToAnalyze(string path, string criteria);
    }
}
