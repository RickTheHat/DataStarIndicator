using DataStarIndicator.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DataStarIndicator.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("greet")]
    public async Task Greet()
    {
        // Read the datastar query parameter instead of the request body
        var datastar = Request.Query["datastar"].ToString();

        // for testing write out to console
        Console.WriteLine($"Greet called with datastar: {datastar}");

        await SseHelper.SetSseHeaders(Response);

        const string indicatorEmptyHtml = "<div id=\"greeting\">No data yet, please wait</div>";
        await SseHelper.SendServerSentEvent(Response, indicatorEmptyHtml);

        // Use Task.Delay for asynchronous delay
        await Task.Delay(3000); // 3000 milliseconds = 3 seconds

        const string indicatorGreetingHtml = "<div id=\"greeting\">Hello, the time is XXX</div>";

        await SseHelper.SendServerSentEvent(Response, indicatorGreetingHtml);
    }
}