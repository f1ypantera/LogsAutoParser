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
        private readonly string log = ConfigurationManager.AppSettings["Log"];
  
        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
        public string GetLog()
        {
            return log;
        }
       
    }
}

