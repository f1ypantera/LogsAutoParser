using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LogsAutoParser.Interfaces;
using Unity;

namespace LogsAutoParser.Workflow
{
    public class ProgramWorkflow:IRun
    {
        private readonly IResultWriter workFlowReport;
        private readonly IAnalyzer analyzer;

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
           // workFlowReport.DisplayAllStrings();
            workFlowReport.DisplayRequiredStringForAnalyze();
            workFlowReport.DisplayDeepAnalyze();
        }
    }
}
