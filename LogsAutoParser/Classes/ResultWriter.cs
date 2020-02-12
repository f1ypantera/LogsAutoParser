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

        public void DisplayFileNames()
        {
            foreach (var s in _mineData.Catalog(_settingProvider.GetPathToCatalog()))
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
                    _analyzer.SelectNeededStringsForAnalyze(_settingProvider.GetPathToTxtById(), _settingProvider.GetCartonID());
                    break;
                case "2":
                    _analyzer.SelectNeededStringsForAnalyze(_settingProvider.GetPathToTxtByLpn(), _settingProvider.GetCartonsLpn());
                    break;
            }
        }
        public void DisplayAnalyzedResult()
        {
            _analyzer.DeepAnalyzingLogs();
        }
    }
}
