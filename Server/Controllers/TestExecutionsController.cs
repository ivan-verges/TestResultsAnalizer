using Microsoft.AspNetCore.Mvc;
using TestResultsAnalyzer.Shared;

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
            List<TestExecution> testExecutions = new();
            for (int testExecutionId = 1; testExecutionId < 10; testExecutionId++)
            {
                TestExecution testExecution = new() { Id = testExecutionId, TestSuites = new List<TestSuite>() };

                for (int testSuiteId = 1; testSuiteId < 10; testSuiteId++)
                {
                    TestSuite testSuite = new() { Id = testSuiteId, Name = $"Test Suite {testSuiteId}", TestCases = new List<TestCase>() };

                    for (int testCaseId = 1; testCaseId < 10; testCaseId++)
                    {
                        TestCase testCase = new() { Id = testCaseId, Name = $"Test Case {testCaseId}", EndTime = DateTime.Now, StartTime = DateTime.Now };
                        switch (testCaseId % 4)
                        {
                            case 0:
                                {
                                    testCase.Result = TestResult.Fail;
                                    break;
                                }
                            case 1:
                                {
                                    testCase.Result = TestResult.Pending;
                                    break;
                                }
                            case 2:
                                {
                                    testCase.Result = TestResult.Skipped;
                                    break;
                                }
                            case 3:
                                {
                                    testCase.Result = TestResult.Success;
                                    break;
                                }
                        }

                        testSuite.TestCases.Add(testCase);
                    }

                    testExecution.TestSuites.Add(testSuite);
                }

                testExecutions.Add(testExecution);
            }
            
            return testExecutions;
        }

        // GET api/<TestExecutionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestExecutionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestExecutionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestExecutionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}