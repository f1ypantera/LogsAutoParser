using LogsAutoParser.Workflow;
using System;
using System.Configuration;
using LogsAutoParser.Classes;
using LogsAutoParser.Interfaces;
using Unity;

namespace LogsAutoParser
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ISettingProvider, SettingProvider>();
            container.RegisterType<IDataMiner, DataMiner>();
            container.RegisterType<IResultWriter, ResultWriter>();
            container.RegisterType<IReader, Reader>();
            var startFlow = container.Resolve<ProgramWorkflow>();
            startFlow.Run();
        }
    }
}
