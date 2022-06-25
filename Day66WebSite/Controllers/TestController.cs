using Day66WebSite.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day66WebSite.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<IActionResult> TestFlights()
        {
            var flights = await _testService.Test1Async();

            return View(flights);
        }
    }
}
