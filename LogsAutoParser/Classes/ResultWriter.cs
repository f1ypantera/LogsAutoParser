using System;
using System.IO;
using LogsAutoParser.Interfaces;
using Unity;

namespace LogsAutoParser.Classes
{
    class ResultWriter : IResultWriter
    {
        private readonly IDataMiner _mineData;
        private readonly ISettingProvider _settingProvider;
        private readonly IAnalyzer _analyzer;

        [InjectionConstructor]
        public ResultWriter(IDataMiner mineData, ISettingProvider settingProvider, IAnalyzer analyzer)
        {
            this._mineData = mineData;
            this._settingProvider = settingProvider;
            this._analyzer = analyzer;
        }

        public void Display()
        {
            Console.WriteLine("Start analyzing..");
            Console.WriteLine("\nFile Names: ");
            foreach (var s in _mineData.Catalog(_settingProvider.GetPathToCatalog()))
            {
                FileInfo fileInf = new FileInfo(s);
                Console.WriteLine(fileInf.Name);
            }
            Console.WriteLine("\nPlease,select 1-byID or 2-byLpn");
            string selection = Console.ReadLine();
            while (selection != "2" && selection != "1")
            {
                Console.WriteLine("\nTry Again");
                selection = Console.ReadLine();
            }
            switch (selection)
            {
                case "1":
                    _analyzer.FilterRowsToAnalyze(_settingProvider.GetPathToTxtById(), _settingProvider.GetCartonID());
                    Console.WriteLine("\nDeep analyzing:");
                    _analyzer.DeepAnalyzingLogs(_settingProvider.GetPatternListById());
                    break;
                case "2":
                    _analyzer.FilterRowsToAnalyze(_settingProvider.GetPathToTxtByLpn(), _settingProvider.GetCartonsLpn());
                    Console.WriteLine("\nDeep analyzing:");
                    _analyzer.DeepAnalyzingLogs(_settingProvider.GetPatternListByLpn());
                    break;
            }
        }
    }
}
