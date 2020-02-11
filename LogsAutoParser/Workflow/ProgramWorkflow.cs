using System;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Start analyzing..");
            Console.WriteLine("\nFile Names: ");
            Console.ResetColor();
            workFlowReport.DisplayFileNames();
            Console.ForegroundColor = ConsoleColor.Red;
            workFlowReport.DisplayCheckCriteria();
            //Console.WriteLine("\nSelected strings from log:");
           // workFlowReport.DisplayStringForAnalyze();
            //Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTest  checking:");
            Console.ResetColor();
            workFlowReport.Test();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n-----------------");
            Console.ResetColor();
        }
    }
}
