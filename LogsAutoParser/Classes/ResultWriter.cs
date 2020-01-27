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
        private readonly IAnalyzer analyzer;

        public ResultWriter(IDataMiner mineData, ISettingProvider settingProvider,IReader reader,IAnalyzer analyzer)
        {
            this.mineData = mineData;
            this.settingProvider = settingProvider;
            this.reader = reader;
            this.analyzer = analyzer;

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
        public void DisplayAllStrings()
        {
            Console.WriteLine("\nFile contains all strings: ");
            foreach (var s in reader.ReadLogsFromFiles(mineData.Catalog(settingProvider.GetPathToCatalog())))
            {
                Console.WriteLine(s);
            }
        }

        public void DisplayRequiredStringForAnalyze()
        {
            Console.WriteLine("\nFile contains strings for analyze: ");
            foreach (var s1 in analyzer.AnalyzeSteps())
            {
                Console.WriteLine(s1);
            }

        }
        public void DisplayDeepAnalyze()
        {
            Console.WriteLine("\nFile contains deep analyze: ");
            
        }
    }
}
