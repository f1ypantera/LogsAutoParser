using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IResultWriter
    {
        void DisplayFileNames();
        string DisplayCheckCriteria();
        void DisplaySelectedStringForAnalyze();
        void Test();
        void Test2();
    }
}
