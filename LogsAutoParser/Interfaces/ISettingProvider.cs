using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface ISettingProvider
    {
        string GetPathToCatalog();
        string GetLog1();
        string GetLog2();
        string GetLog3();
        string GetLog4();
    }
}
