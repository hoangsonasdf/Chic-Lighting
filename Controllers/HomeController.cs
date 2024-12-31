using Microsoft.AspNetCore.Mvc;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Home;
using projectchicandlighting.Repositories;
using projectchicandlighting.Repositories.CategoryRepository;
using projectchicandlighting.Repositories.FeedbackRepository.FeedbackRepository;
using System.Diagnostics;

namespace projectchicandlighting.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, IFeedbackRepository feedbackRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _feedbackRepository = feedbackRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listFeedback = await _feedbackRepository.GetHomeFeedbackModels();
            var listCategories = await _categoryRepository.GetHomeCategoryModel();
            var listImage = new List<string>();
            for(int i = 1; i <= 12; i++)
            {
                listImage.Add(String.Format("/img/gallery/gallery-{0}.jpg", i));
            }
            var model = new HomeModel
            {
                Feedbacks = listFeedback,
                Categories = listCategories,
                Images = listImage
            };
            return View(model);
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
    }
}