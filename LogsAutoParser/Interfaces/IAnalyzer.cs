using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IAnalyzer
    {
        List<string> AnalyzedLogs();
        IEnumerable<string> SelectNeedStringsForAnalyze();

        IEnumerable<string> SelectNeedStringsForAnalyzeById();

        IEnumerable<string> SelectNeedStringsForAnalyzeByLpn();
      //  void DeepAnalyzingLogs();
    }
}
