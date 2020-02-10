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
        private readonly string pathToCatalog = ConfigurationManager.AppSettings["pathToCatalog"];
        private readonly List<string> templateStrings = ConfigurationManager.GetSection("templateString") as List<string>;
        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
      
        public List<string> GetTemplateStrings()
        {
            return templateStrings.ToList();
        }
    }
}

