using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class ResultWriter:IResultWriter
    {
        private readonly IDataMiner mineData;
        private readonly ISettingProvider settingProvider;
        private readonly IReader reader;

        public ResultWriter(IDataMiner mineData, ISettingProvider settingProvider,IReader reader)
        {
            this.mineData = mineData;
            this.settingProvider = settingProvider;
            this.reader = reader;

        }
        public void DisplayFileNames()
        {
            Console.WriteLine("\nFile Names: ");
            foreach (var s in mineData.Catalog(settingProvider.GetPathToCatalog()))
            {
                FileInfo fileInf = new FileInfo(s);
                Console.WriteLine(fileInf.Name);
            }
        }
        public void DisplayStrings()
        {
            Console.WriteLine("\nFile contains strings : ");
            foreach (var s in reader.ReadLogsFromFiles(mineData.Catalog(settingProvider.GetPathToCatalog())))
            {
                Console.WriteLine(s);
            }
        }
    }
}
