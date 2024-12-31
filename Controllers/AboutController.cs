using Microsoft.AspNetCore.Mvc;

namespace projectchicandlighting.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> logger;

        public AboutController(ILogger<AboutController> logger)
        {
            this.logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
