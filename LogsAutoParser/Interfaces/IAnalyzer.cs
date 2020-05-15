using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IAnalyzer
    {
        void DeepAnalyzingLogsByID(List<string> patternList);
        void DeepAnalyzingLogsByLPN(List<string> patternList);
        IEnumerable<string> FilterRowsToAnalyze(string path, string criteria);
    }
}
