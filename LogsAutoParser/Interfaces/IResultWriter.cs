using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IResultWriter
    {
        void DisplayFileNames();
        void DisplaySelectedStringForAnalyze();
        void Test();
    }
}
