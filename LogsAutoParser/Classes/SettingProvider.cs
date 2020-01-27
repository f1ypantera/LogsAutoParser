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
        private  readonly string pathToCatalog = ConfigurationManager.AppSettings["pathToCatalog"];
        private  readonly string log1 = ConfigurationManager.AppSettings["Log1"];

        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
        public string GetLog1()
        {
            return log1;
        }
    }
}
