using Microsoft.AspNetCore.Mvc;
using NLog;

namespace SitNSleep.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly Logger _logger;

        public LoginController()
        {
            _logger = LogManager.GetCurrentClassLogger();

        }

        public IActionResult Index()
        {
            _logger.Info($"In Login controller Index Action.");
            return View();
        }
    }
}
