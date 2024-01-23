using Microsoft.AspNetCore.Mvc;
using System.Text;
using TestResultsAnalyzer.Shared.BusinessLogic;
using TestResultsAnalyzer.Shared.DataModel;

namespace TestResultsAnalyzer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadCsvController : ControllerBase
    {
        // POST api/<DownloadCsvController>
        [HttpPost]
        public IActionResult Post([FromBody] List<TestExecution> value)
        {
            DataConverter dataConverter = new();

            string csvContent = dataConverter.TestExecutionsToCsv(value);
            byte[] dataBytes = Encoding.UTF8.GetBytes(csvContent);
            return File(dataBytes, "text/csv");
        }
    }
}