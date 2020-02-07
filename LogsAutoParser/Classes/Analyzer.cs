using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<string> SelectNeedStringsForAnalyze()
        {
            var allStringFromFiles = reader.ReadLogsFromFiles(dataMiner.Catalog(settingProvider.GetPathToCatalog()));
            foreach (var regexTemplate in settingProvider.GetTemplateStrings())
            {
                Regex regex = new Regex(regexTemplate);
                foreach (var oneString in allStringFromFiles)
                {
                    MatchCollection matches = regex.Matches(oneString);

                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            analyzeLogs.Add(match.Value);

                        }
                        //Console.WriteLine(matches.Count.ToString());
                    }
                }
            }

            return analyzeLogs;
        }

        public void Test()
        {
            bool flag;
            foreach (var regexTemplate in settingProvider.GetTemplateStrings())
            {
                flag = false;
                Regex regex = new Regex(regexTemplate);
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
                                Console.WriteLine("Совпало с шаблоном - " + match.Value);
                            }

                        }
                    }
                    if (matches.Count == 0 && ss == "vadym" && regex == regex && flag == false)
                    {
                        Console.WriteLine("Не совпало с шаблоном - " + regex);
                    }
                }
            }
        }
    }
}

