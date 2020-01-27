using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IReader
    {
        IEnumerable<string> ReadLogsFromFiles(IEnumerable<string> pathToFiles);
    }
}
