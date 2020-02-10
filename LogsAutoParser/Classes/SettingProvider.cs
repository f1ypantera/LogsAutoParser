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
        List<string> templateStrings = ConfigurationManager.GetSection("backupDirectories") as List<string>;
        //private readonly string templateString1 = ConfigurationManager.AppSettings["templateString1"];
        //private readonly string templateString2 = ConfigurationManager.AppSettings["templateString2"];
        //private readonly string templateString3 = ConfigurationManager.AppSettings["templateString3"];
        //private readonly string templateString4 = ConfigurationManager.AppSettings["templateString4"];
        //private readonly string templateString5 = ConfigurationManager.AppSettings["templateString5"];
        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
      
        public List<string> GetTemplateStrings()
        {
            //List<string> templateStrings = new List<string>();
            //templateStrings.Add(templateString1);
            //templateStrings.Add(templateString2);
            //templateStrings.Add(templateString3);
            //templateStrings.Add(templateString4);
            //templateStrings.Add(templateString5);
            return templateStrings.ToList();
        }
    }
}

