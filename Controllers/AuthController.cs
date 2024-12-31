using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectchicandlighting.Common;
using projectchicandlighting.Common.Result;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Auth;
using projectchicandlighting.Repositories.AuthRepositories;
using projectchicandlighting.Request;
using projectchicandlighting.Services.SendMailServices;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace projectchicandlighting.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISendMailService _sendMailService;
        private readonly ILogger<AuthController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(IAuthRepository authRepository, ISendMailService sendMailService, ILogger<AuthController> logger, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _authRepository = authRepository;
            _sendMailService = sendMailService;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Auth", new { ReturnUrl = returnUrl });
            var properties = _authRepository.GetAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login");
            }

            var info = await _authRepository.GetExternalLoginInfo();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }


            var result = await _authRepository.ExternalLogin(info.LoginProvider, info.ProviderKey);
            if (result.Succeeded)
            {
                returnUrl ??= Url.Content("~/");
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (email != null)
                {
                    await _authRepository.CreateNewUser(info);
                    returnUrl ??= Url.Content("~/");
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction(nameof(Login));
            }
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                var loginResult = await _authRepository.Login(request.Username, request.Password);
                if (loginResult.Succeed == true)
                {
                    var user = loginResult.User;
                    var role = await _authRepository.GetUserRole(user);
                    if (role.Contains(StaticRole.Admin))
                    {
                        return RedirectToAction("Index", "Dashboard", new { month = DateTime.Now.Month, year = DateTime.Now.Year });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", StaticMessage.InvalidCred);
                    return View(request);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                var registerResult = await _authRepository.Register(request.Firstname, request.Lastname, request.Username, request.Email, request.Address, request.Password);
                if (registerResult.Succeed == true)
                {
                    var user = await _authRepository.GetUserByUsername(request.Username);
                    var link = Url.Action("Verify", "Auth",
                        new { userId = user.Id, token = registerResult.Token }, Request.Scheme);
                    var emailBody = await _sendMailService.EmailBodyVerify(link);


                    await _sendMailService.SendMail("Confirm your email", emailBody, request.Email);

                    return RedirectToAction("VerfifyNotify");
                }
                else
                {
                    foreach (var error in registerResult.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return View(request);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> VerfifyNotify()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Verify(string userId, string token)
        {
            var user = await _authRepository.GetUserById(userId);
            var model = new VerifyModel
            {
                User = user,
                Token = token,
                Request = new VerifyRequest { UserId = userId, Token = token },
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Verify(VerifyRequest request)
        {
            try
            {
                var result = await _authRepository.VerifyEmail(request.UserId, request.Token);
                if (result == true)
                {
                    TempData["AlertMessage"] = "Verify email successfully";
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    throw new ApplicationException($"Error confirming email for user with ID '{request.UserId}':");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var user = await _authRepository.GetUserByEmail(request.Email);
            if (user == null || !(await _authRepository.IsConfirmedEmail(user)))
            {
                ModelState.AddModelError("", StaticMessage.ErrorOccur);
                return View(request);
            }

            var token = await _authRepository.GeneratePasswordResetToken(user);
            var link = Url.Action("ResetPassword", "Auth",
                       new { userId = user.Id, token }, Request.Scheme);
            var emailBody = await _sendMailService.EmailBodyReset(link);
            await _sendMailService.SendMail("Reset your password", emailBody, request.Email);

            return RedirectToAction("ResetNotify");
        }

        [HttpGet]
        public async Task<IActionResult> ResetNotify()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            var model = new ResetPasswordRequest { UserId = userId, Token = token };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                var user = await _authRepository.GetUserById(request.UserId);
                if (user == null || !(await _authRepository.IsConfirmedEmail(user)))
                {
                    ModelState.AddModelError("", StaticMessage.ErrorOccur);
                    return View(request);
                }
                var result = await _authRepository.ResetPassword(request.UserId, request.Password, request.Token);
                if (result.Succeed)
                {
                    TempData["AlertMessage"] = StaticMessage.ChangePassword;
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return View(request);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                return View(request);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authRepository.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
