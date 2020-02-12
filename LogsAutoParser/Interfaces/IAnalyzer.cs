using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IAnalyzer
    {
        void DeepAnalyzingLogs();
        IEnumerable<string> SelectNeededStringsForAnalyze(string path, string criteria);
    }
}
