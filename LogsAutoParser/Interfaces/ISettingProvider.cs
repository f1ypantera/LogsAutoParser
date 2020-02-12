using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface ISettingProvider
    {
        string GetPathToCatalog();
        List<string> GetPatternListById();
        List<string> GetPatternListByLpn();
        string GetCartonID();
        string GetCartonsLpn();
    }
}
