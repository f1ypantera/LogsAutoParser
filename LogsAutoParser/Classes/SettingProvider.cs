using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class SettingProvider:ISettingProvider
    {
        private readonly string pathToCatalog = ConfigurationManager.AppSettings["pathToCatalog"];
        private readonly string CartonID = ConfigurationManager.AppSettings["cartonId"];
        private readonly string LpnCartons = ConfigurationManager.AppSettings["lpnCartons"];
        private readonly List<string> templateStrings = ConfigurationManager.GetSection("templateString") as List<string>;
        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
      
        public List<string> GetTemplateStrings()
        {
            return templateStrings.ToList();
        }
        public string GetCartonID()
        {
            return CartonID;
        }
        public string GetCartonsLpn()
        {
            return LpnCartons;
        }
    }
}

