using Microsoft.AspNetCore.Mvc;
using NLog;

namespace SitNSleep.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Logger _logger;

        public HomeController()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public IActionResult Index()
        {
            _logger.Info($"In Home controller Index Action.");
            return View();
        }
    }
}
