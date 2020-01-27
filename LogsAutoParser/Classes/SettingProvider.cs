using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class SettingProvider:ISettingProvider
    {
        readonly string pathToCatalog = ConfigurationManager.AppSettings["pathToCatalog"];

        public string GetPathToCatalog()
        {
            return pathToCatalog;
        }

    }
}
