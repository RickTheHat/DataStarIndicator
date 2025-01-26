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
    public async Task Greet()
    {
        // for testing write out to console
        Console.WriteLine("Greet called");

        await SseHelper.SetSseHeaders(Response);

        const string indicatorEmptyHtml = "<div id=\"greeting\">No data yet, please wait</div>";
        await SseHelper.SendServerSentEvent(Response, indicatorEmptyHtml);

        const string indicatorGreetingHtml = "<div id=\"greeting\">Hello, the time is XXX</div>";

        await SseHelper.SendServerSentEvent(Response, indicatorGreetingHtml);
    }
}