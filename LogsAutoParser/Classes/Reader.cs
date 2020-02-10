using System.Collections.Generic;
using System.IO;
using LogsAutoParser.Interfaces;

namespace LogsAutoParser.Classes
{
    class Reader:IReader
    {
        public IEnumerable<string> ReadLogsFromFiles(IEnumerable<string> pathToFiles)
        {
            foreach (var file in pathToFiles)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }
    }
}
