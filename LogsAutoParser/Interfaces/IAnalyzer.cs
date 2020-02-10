using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IAnalyzer
    {
        IEnumerable<string> SelectNeedStringsForAnalyze();
        //void TestFindAllStringByConveyorId();
      //  void Test();
    }
}
