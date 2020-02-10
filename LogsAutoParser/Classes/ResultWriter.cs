using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class ResultWriter : IResultWriter
    {
        private readonly IDataMiner mineData;
        private readonly ISettingProvider settingProvider;
        private readonly IAnalyzer analyzer;

        public ResultWriter(IDataMiner mineData, ISettingProvider settingProvider, IReader reader, IAnalyzer analyzer)
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

        public string DisplayCheckCriteria()
        {
            Console.WriteLine("\nPlease,select 1-byID or 2-byLpn or 3-Overall strings");
            string selection = Console.ReadLine();
            while (selection != "3" && selection != "2" && selection != "1")
            {
                Console.WriteLine("\nTry Again");
                selection = Console.ReadLine();
            }
            switch (selection)
            {
                case "1":
                    Console.WriteLine("byID");
                    break;
                case "2":
                    Console.WriteLine("byLpn");
                    break;
                case "3":
                    Console.WriteLine("Just");
                    break;
            }
            return selection;
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
           analyzer.DeepAnalyzingLogs();
        }
        public void Test2()
        {
            Console.WriteLine("Test2");
          //  analyzer.TestFindAllStringByConveyorId();
        }
    }
}
