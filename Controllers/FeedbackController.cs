using Microsoft.AspNetCore.Mvc;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.Repositories.FeedbackRepository.FeedbackRepository;
using projectchicandlighting.Request;

namespace projectchicandlighting.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(IFeedbackRepository feedbackRepository, ILogger<FeedbackController> logger)
        {
            _feedbackRepository= feedbackRepository;
            _logger= logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(FeedbackRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", request);
                }
                var feedback = new Feedback
                {
                    Rate = short.Parse(request.Rate),
                    Name= request.Name,
                    Email= request.Email,
                    Comment= request.Comment,
                };
                await _feedbackRepository.Add(feedback);
                ViewBag.Response = StaticMessage.AddData;
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                return View("Index", request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _feedbackRepository.GetAdminFeedbackModels();
            return View(model);
        }
    }
}
