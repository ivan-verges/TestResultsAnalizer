using Microsoft.AspNetCore.Mvc;
using TestResultsAnalyzer.Shared.BusinessLogic;
using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        // POST api/<AnalysisController>
        [HttpPost("TestExecution")]
        public AnalysisResult AnalyzeTestExecution([FromBody] TestExecution value)
        {
            return new ResultsAnalyzer().AnalyzeTestExecution(value);
        }

        // POST api/<AnalysisController>
        [HttpPost("TestExecutions")]
        public AnalysisResult AnalyzeTestExecutions([FromBody] List<TestExecution> value)
        {
            return new ResultsAnalyzer().AnalyzeTestExecutions(value);
        }
    }
}