using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IAnalyzer
    {
        List<string> AnalyzedLogs();
        void DeepAnalyzingLogs();
        IEnumerable<string> SelectNeededStringsForAnalyze(string path, string criteria);
    }
}
