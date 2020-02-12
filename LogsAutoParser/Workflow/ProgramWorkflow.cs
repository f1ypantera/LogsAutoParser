using System;
using LogsAutoParser.Interfaces;
using Unity;

namespace LogsAutoParser.Workflow
{
    class ProgramWorkflow:IRun
    {
        private readonly IResultWriter _workFlowReport;
        
        [InjectionConstructor]
        public ProgramWorkflow(IResultWriter workFlowReport)
        {
            this._workFlowReport = workFlowReport;
        }
        public void Run()
        {
            Console.WriteLine("Start analyzing..");
            Console.WriteLine("\nFile Names: ");
            _workFlowReport.DisplayFileNames();
            Console.WriteLine("\nPlease,select 1-byID or 2-byLpn");
            _workFlowReport.DisplayCheckCriteria();
            Console.WriteLine("\nDeep analyzing:");
            _workFlowReport.DisplayAnalyzedResult();

        }
    }
}
