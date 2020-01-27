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
        private readonly string log1 = ConfigurationManager.AppSettings["Log1"];
        private readonly string log2 = ConfigurationManager.AppSettings["Log2"];
        private readonly string log3 = ConfigurationManager.AppSettings["Log3"];
        private readonly string log4 = ConfigurationManager.AppSettings["Log4"];
        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }
        public string GetLog1()
        {
            return log1;
        }
        public string GetLog2()
        {
            return log2;
        }
        public string GetLog3()
        {
            return log3;
        }
        public string GetLog4()
        {
            return log4;
        }
    }
}

