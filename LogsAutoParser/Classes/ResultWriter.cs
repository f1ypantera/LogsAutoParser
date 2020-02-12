using System;
using System.IO;
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

        public void DisplayCheckCriteria()
        {
           
            string selection = Console.ReadLine();
            while (selection != "2" && selection != "1")
            {
                Console.WriteLine("\nTry Again");
                selection = Console.ReadLine();
            }
            switch (selection)
            {
                case "1":
                    Console.WriteLine("byID");
                    analyzer.SelectNeededStringsForAnalyze(settingProvider.GetPathToTxtById(), settingProvider.GetCartonID());
                    break;
                case "2":
                    Console.WriteLine("byLpn");
                    analyzer.SelectNeededStringsForAnalyze(settingProvider.GetPathToTxtByLpn(), settingProvider.GetCartonsLpn());
                    break;
            }
        }
        public void DisplayAnalyzedResult()
        {
           analyzer.DeepAnalyzingLogs();
        }
    }
}
