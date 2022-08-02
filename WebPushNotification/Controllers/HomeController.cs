using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using WebPushNotification.Hubs;
using WebPushNotification.Models;

namespace WebPushNotification.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<NotifyHub> _hub;
        public HomeController(ILogger<HomeController> logger, IHubContext<NotifyHub> hub)
        {
            _logger = logger;
            _hub = hub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Notify()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendNotify(NotifyModel model)
        {
            await _hub.Clients.All.SendAsync("getNotification", model);
            return new JsonResult(true);
        }
    }
}