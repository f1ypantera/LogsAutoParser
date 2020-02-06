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

        public IEnumerable<string> AnalyzeSteps()
        {
            var allStringFromFiles = reader.ReadLogsFromFiles(dataMiner.Catalog(settingProvider.GetPathToCatalog()));
            foreach (var regexTemplate in settingProvider.GetTemplateStringsList())
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

                    //if (matches.Count == 0)
                    //{
                    //    Console.WriteLine("не ок");
                    //}
                }
            }

            return analyzeLogs;
        }

        public void DeepAnalyzer()
        {
            bool flag;
            foreach (var regexTemplate in settingProvider.GetTemplateStringsList())
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
                                Console.WriteLine("есть " + match.Value);
                            }

                        }
                    }
                    if (matches.Count == 0 && ss == "vadym" && regex == regex && flag == false)
                    {
                        Console.WriteLine(regex);
                    }

                    //Console.WriteLine(matches.Count.ToString());

                    //foreach (Match match in matches)
                    //{
                    //    if (analyzeLogs.Contains(match.Value))
                    //    {
                    //        Console.WriteLine("есть " + match.Value);
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("нет " + match.Value);
                    //    }
                    //}
                }
            }



            //foreach (var a in analyzeLogs)
                //{
                //    Console.WriteLine(a);
                //}

            //    List<string> aa = new List<string>() { "vadym" ,"ira" ,"vitalik" };
            //foreach (var s in aa)
            //{
            //    if (analyzeLogs.Contains(s))
            //    {
            //        Console.WriteLine("есть "+ s);
            //    }
            //    else
            //    {
            //        Console.WriteLine("нет " + s);
            //    }
            //}
            
            
            //foreach (var regexTemplate in settingProvider.GetTemplateStringsList())
            //{
            //    Regex regex = new Regex(regexTemplate);
            //    foreach (var step in analyzeLogs)
            //    {

            //        if (regex.IsMatch(step))
            //        {
            //            Console.WriteLine("Ok");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Ne ok");
            //        }
            //    }



        }
    }
}

