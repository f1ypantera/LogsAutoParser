using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LogsAutoParser.Interfaces;
using Unity;

namespace LogsAutoParser.Classes
{
    class Analyzer : IAnalyzer
    {
        private readonly ISettingProvider _settingProvider;
        private readonly IReader _reader;
        private readonly IDataMiner _dataMiner;
        List<string> analyzeLogs = new List<string>();

        [InjectionConstructor]
        public Analyzer(ISettingProvider settingProvider, IReader reader, IDataMiner dataMiner)
        {
            this._settingProvider = settingProvider;
            this._reader = reader;
            this._dataMiner = dataMiner;
        }

        public IEnumerable<string> FilterRowsToAnalyze(string path, string criteria)
        {
            File.Delete(path);
            var pathToStrings = _reader.ReadLogsFromFiles(_dataMiner.Catalog(_settingProvider.GetPathToCatalog()));
            Regex regex = new Regex(criteria);
            foreach (var oneString in pathToStrings)
            {
                MatchCollection matches = regex.Matches(oneString);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            analyzeLogs.Add(oneString);
                            sw.WriteLine(oneString);
                        }
                    }
                }
            }

            return analyzeLogs;
        }

        public void DeepAnalyzingLogsByID(List<string> patternList)
        {
            bool flag;
            foreach (var regexPattern in patternList)
            {
                flag = false;
                Regex regex = new Regex(regexPattern, RegexOptions.Singleline);
                foreach (var stringLog in analyzeLogs)
                {
                    MatchCollection matches = regex.Matches(stringLog);

                    if (matches.Count > 0)
                    {
                        flag = true;
                        foreach (Match match in matches)
                        {
                            Console.WriteLine("Matched with template pattern - " + match.Value);
                        }
                    }

                    if (matches.Count == 0 && stringLog == analyzeLogs.Last() && flag == false)
                    {
                        Console.WriteLine("Does not matched with template pattern - " + regex);
                    }
                }
            }

        }

        public void DeepAnalyzingLogsByLPN(List<string> patternList)
        {
            bool flag;
            foreach (var regexPattern in patternList)
            {
                int i = 1;
                flag = false;
                Regex regex = new Regex(regexPattern, RegexOptions.Singleline);
                foreach (var stringLog in analyzeLogs)
                {
                 
                    MatchCollection matches = regex.Matches(stringLog);

                    
                    if (matches.Count > 0)
                    {
                        flag = true;

                        foreach (Match match in matches)
                        {
                            
                            if (match.Value == "Received AddPallet ParentLPN:")
                            {
                                Console.WriteLine("Matched with template pattern - " + match.Value);
                                if (i == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Step was completed");
                                    Console.ResetColor();
                                }

                            }

                            if (match.Value == "InboundConveyorClient.NotifyInboundCase:")
                            {
                                Console.WriteLine("Matched with template pattern - " + match.Value);
                                i++;
                                if (i == 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Step was completed");
                                    Console.ResetColor();
                                }
                            }

                            if (match.Value == "InboundCartonFactory.CreateInboundCarton:")
                            {
                                Console.WriteLine("Matched with template pattern - " + match.Value);
                                i++;
                                if (i == 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Step was completed");
                                    Console.ResetColor();
                                }
                            }

                            if (match.Value == "Added inbound carton to queue:")
                            {
                                Console.WriteLine("Matched with template pattern - " + match.Value);
                                i++;
                                if (i == 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Step was completed");
                                    Console.ResetColor();
                                }
                            }

                            if (match.Value == "Removed inbound carton from queue:")
                            {
                                Console.WriteLine("Matched with template pattern - " + match.Value);
                                i++;
                                if (i == 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Step was completed");
                                    Console.ResetColor();
                                }
                            }

                            if (match.Value == "Handling DepalletizationComplete:")
                            {
                                Console.WriteLine("Matched with template pattern - " + match.Value);
                                if (i == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Step was completed");
                                    Console.ResetColor();
                                }
                            }

                        }
                    }

                    if (matches.Count == 0 && stringLog == analyzeLogs.Last() && flag == false)
                    {
                        Console.WriteLine("Does not matched with template pattern - " + regex);
                    }
                }
            }
        }
    }
}

