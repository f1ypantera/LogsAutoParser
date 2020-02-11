using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IResultWriter
    {
        void DisplayFileNames();
        void DisplayStringForAnalyze();
        void DisplayCheckCriteria();
        void Test();
    }
}
