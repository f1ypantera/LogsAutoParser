using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class Analyzer : IAnalyzer
    {
        private readonly ISettingProvider settingProvider;
        private readonly IReader reader;
        private readonly IDataMiner dataMiner;
        List<string> analyzeLogs = new List<string>();
        public Analyzer(ISettingProvider settingProvider, IReader reader, IDataMiner dataMiner)
        {
            this.settingProvider = settingProvider;
            this.reader = reader;
            this.dataMiner = dataMiner;
        }

        public List<string> AnalyzedLogs()
        {
            return  analyzeLogs;
        }
        public IEnumerable<string> SelectNeedStringsForAnalyzeById()
        {
            
            string writePath = @"D:\\Projects\\LogsAutoParser\\OutPut\\byID.txt";
            File.Delete(writePath);
            var pathToStrings = reader.ReadLogsFromFiles(dataMiner.Catalog(settingProvider.GetPathToCatalog()));
                Regex regex = new Regex(settingProvider.GetCartonID());
                foreach (var oneString in pathToStrings)
                {
                    MatchCollection matches = regex.Matches(oneString);

                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            using (StreamWriter sw = File.AppendText(writePath))
                            {
                                analyzeLogs.Add(oneString);
                                sw.WriteLine(oneString);
                            }
                        }
                    }
                }
                return analyzeLogs;
        }
        public IEnumerable<string> SelectNeedStringsForAnalyzeByLpn()
        {
           
            var pathToStrings = reader.ReadLogsFromFiles(dataMiner.Catalog(settingProvider.GetPathToCatalog()));
            Regex regex = new Regex(settingProvider.GetCartonsLpn());
            foreach (var oneString in pathToStrings)
            {
                MatchCollection matches = regex.Matches(oneString);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        analyzeLogs.Add(match.Value);
                    }
                }
            }
            return analyzeLogs;
        }

        public IEnumerable<string> SelectNeedStringsForAnalyze()
        {
            var allStringFromFiles = reader.ReadLogsFromFiles(dataMiner.Catalog(settingProvider.GetPathToCatalog()));
            foreach (var regexTemplate in settingProvider.GetTemplateStrings())
            {
                Regex regex = new Regex(regexTemplate, RegexOptions.IgnorePatternWhitespace);
                foreach (var oneString in allStringFromFiles)
                {
                    MatchCollection matches = regex.Matches(oneString);

                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            analyzeLogs.Add(match.Value);

                        }
                    }
                }
            }
            return analyzeLogs;
        }
        public void DeepAnalyzingLogs()
        {
            bool flag;
            foreach (var regexTemplate in settingProvider.GetTemplateStrings())
            {
                flag = false;
                Regex regex = new Regex(regexTemplate, RegexOptions.Singleline);
                foreach (var ss in analyzeLogs)
                {
                    MatchCollection matches = regex.Matches(ss);

                    if (matches.Count > 0)
                    {
                        flag = true;
                        foreach (Match match in matches)
                        {
                            if (analyzeLogs.Contains(match.Value))
                            {
                                Console.WriteLine("Matched with template pattern - " + match.Value);
                            }

                        }
                    }
                    if (matches.Count == 0 && ss == analyzeLogs.Last() && regex == regex && flag == false)
                    {
                        Console.WriteLine("Does not matched with template pattern - " + regex);
                    }
                }
            }
        }
    }
}

