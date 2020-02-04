using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class SettingProvider:ISettingProvider
    {
        private readonly string pathToCatalog = "D:\\Projects\\LogsAutoParser\\Catalog";
        private readonly string[] templateStrings = ConfigurationManager.AppSettings["Log"].Split(",");
        
        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
        public List<string> GetTemplate()
        {
            return templateStrings.ToList();
        }
    }
}

