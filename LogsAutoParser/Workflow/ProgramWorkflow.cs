using System;
using System.Collections.Generic;
using System.Text;
using LogsAutoParser.Interfaces;
using Unity;

namespace LogsAutoParser.Workflow
{
    public class ProgramWorkflow:IRun
    {
        private readonly IResultWriter workFlowReport;

        [InjectionConstructor]
        public ProgramWorkflow(IResultWriter workFlowReport)
        {
            this.workFlowReport = workFlowReport;
        }
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Start analyzing..");
            workFlowReport.DisplayFileNames();
            workFlowReport.DisplayStrings();
        }
    }
}
