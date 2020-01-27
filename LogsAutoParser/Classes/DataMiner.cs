using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class DataMiner:IDataMiner
    {
        public IEnumerable<string> Catalog(string pathToCatalog)
        {
            string[] pathToFiles = null;
            try
            {
                pathToFiles = Directory.GetFiles(pathToCatalog);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Catalog not found");
                throw;
            }
            return pathToFiles;
        }
    }
}
