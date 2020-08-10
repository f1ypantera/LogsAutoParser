using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class SettingProvider:ISettingProvider
    {
        private readonly string _pathToCatalog = ConfigurationManager.AppSettings["pathToCatalog"];
        private readonly string _pathToTxtById = ConfigurationManager.AppSettings["pathToTxtById"];
        private readonly string _pathToTxtByLpn = ConfigurationManager.AppSettings["pathToTxtByLpn"];
        private readonly List<string> _patternListById = ConfigurationManager.GetSection("patternListById") as List<string>;
        private readonly List<string> _patternListByLpn = ConfigurationManager.GetSection("patternListByLpn") as List<string>;
        public string GetPathToCatalog()
        {
            return _pathToCatalog;
        }
        public string GetPathToTxtById()
        {
            
            return _pathToTxtById;
        }
        public string GetPathToTxtByLpn()
        {
            return _pathToTxtByLpn;
        }

        public List<string> GetPatternListById()
        {
            return _patternListById.ToList();
        }
        public List<string> GetPatternListByLpn()
        {
            return _patternListByLpn.ToList();
        }
    }
}

