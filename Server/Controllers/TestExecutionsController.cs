using Microsoft.AspNetCore.Mvc;
using TestResultsAnalyzer.Shared.DataGenerator;
using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestExecutionsController : ControllerBase
    {
        //Simulate Database Context Object
        private readonly List<TestExecution> testExecutions = new DemoGenerator().GenerateTestExecutions(4, 4, 4);

        // GET: api/<TestExecutionsController>
        [HttpGet]
        public IEnumerable<TestExecution> Get()
        {
            return testExecutions;
        }

        // GET api/<TestExecutionsController>/5
        [HttpGet("{id}")]
        public TestExecution Get(int id)
        {
            return testExecutions.First(x => x.Id == id);
        }

        // POST api/<TestExecutionsController>
        [HttpPost]
        public void Post([FromBody] TestExecution value)
        {
            testExecutions.Add(value);
        }

        // PUT api/<TestExecutionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TestExecution value)
        {
            TestExecution testExecution = testExecutions.First(x => x.Id == id);
            testExecution.TestSuites = value.TestSuites;
        }

        // DELETE api/<TestExecutionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TestExecution testExecution = testExecutions.First(x => x.Id == id);
            testExecutions.Remove(testExecution);
        }
    }
}