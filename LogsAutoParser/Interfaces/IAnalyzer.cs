using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IAnalyzer
    {
        void DeepAnalyzingLogs(List<string> patternList);
        IEnumerable<string> FilterRowsToAnalyze(string path, string criteria);
    }
}
