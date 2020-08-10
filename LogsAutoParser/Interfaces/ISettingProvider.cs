using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface ISettingProvider
    {
        string GetPathToCatalog();
        string GetPathToTxtById();
        string GetPathToTxtByLpn();
        List<string> GetPatternListById();
        List<string> GetPatternListByLpn();
    }
}
