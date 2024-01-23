using Microsoft.AspNetCore.Mvc;
using TestResultsAnalyzer.Shared.DataGenerator;
using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestExecutionsController : ControllerBase
    {
        // GET: api/<TestExecutionsController>
        [HttpGet]
        public IEnumerable<TestExecution> Get()
        {
            Random random = new();
            List<TestExecution> testExecutions = new DemoGenerator().GenerateTestExecutions(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));

            return testExecutions;
        }
    }
}