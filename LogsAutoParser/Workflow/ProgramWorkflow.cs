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
            Console.WriteLine("Start analyzing..");
            Console.WriteLine("\nFile Names: ");
            workFlowReport.DisplayFileNames();
            Console.WriteLine("\nPlease,select 1-byID or 2-byLpn or 3-Overall strings");
            workFlowReport.DisplayCheckCriteria();
            Console.WriteLine("\nDeep analyzing:");
            workFlowReport.DisplayAnalyzedResult();

        }
    }
}
