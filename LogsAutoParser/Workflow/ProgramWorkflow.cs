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
            _workFlowReport.Display();
        }
    }
}
