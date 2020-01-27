using System;
using System.Collections.Generic;
using System.Text;

namespace LogsAutoParser.Interfaces
{
    public interface IDataMiner
    {
        IEnumerable<string> Catalog(string catalogName);
    }
}
