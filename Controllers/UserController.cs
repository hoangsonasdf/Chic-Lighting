using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectchicandlighting.Common;
using projectchicandlighting.ModelViews.Userr;
using projectchicandlighting.Repositories.AuthRepositories;
using projectchicandlighting.Request;

namespace projectchicandlighting.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IAuthRepository authRepository, ILogger<UserController> logger)
        {
            _authRepository = authRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _authRepository.GetCurrentUser();
            var model = new ProfileModel
            {
                User = user,
                Request = new ChangePasswordRequest()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Change(ChangePasswordRequest request)
        {
            var user = await _authRepository.GetCurrentUser();
            if (!ModelState.IsValid)
            {
                var model = new ProfileModel
                {
                    User = user,
                    Request = request
                };
                return View("Profile", model);
            }
            var result = await _authRepository.ChangePassword(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeed)
            {
                ViewBag.Response = StaticMessage.ChangePassword;
                var model = new ProfileModel
                {
                    User = user,
                    Request = request
                };
                return View("Profile", model);
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                var model = new ProfileModel
                {
                    User = user,
                    Request = request
                };
                return View("Profile", model);
            }
        }
    }
}
