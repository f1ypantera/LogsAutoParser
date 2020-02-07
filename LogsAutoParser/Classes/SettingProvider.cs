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
        private readonly string pathToCatalog = ConfigurationManager.AppSettings["getPathToCatalog"];
        private readonly string templateStrings1 = ConfigurationManager.AppSettings["templateString1"];
        private readonly string templateStrings2 = ConfigurationManager.AppSettings["templateString2"];
        private readonly string templateStrings3 = ConfigurationManager.AppSettings["templateString3"];
        private readonly string templateStrings4 = ConfigurationManager.AppSettings["templateString4"];
        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
      
        public List<string> GetTemplateStrings()
        {
            List<string> templateStrings = new List<string>();
            templateStrings.Add(templateStrings1);
            templateStrings.Add(templateStrings2);
            templateStrings.Add(templateStrings3);
            templateStrings.Add(templateStrings4);
            return templateStrings.ToList();
        }
    }
}

