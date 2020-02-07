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
        private readonly IAnalyzer analyzer;

        public ResultWriter(IDataMiner mineData, ISettingProvider settingProvider,IReader reader,IAnalyzer analyzer)
        {
            this.mineData = mineData;
            this.settingProvider = settingProvider;
            this.analyzer = analyzer;
        }
        public void DisplayFileNames()
        {
            foreach (var s in mineData.Catalog(settingProvider.GetPathToCatalog()))
            {
                FileInfo fileInf = new FileInfo(s);
                Console.WriteLine(fileInf.Name);
            }
        }
        public void DisplaySelectedStringForAnalyze()
        {
            foreach (var s1 in analyzer.SelectNeedStringsForAnalyze())
            {
                Console.WriteLine(s1);
            }

        }
        public void Test()
        {
            analyzer.Test();
        }
        public void Test2()
        {
            Console.WriteLine("Test2");
            analyzer.TestFindAllStringByConveyorId();
        }
    }
}
