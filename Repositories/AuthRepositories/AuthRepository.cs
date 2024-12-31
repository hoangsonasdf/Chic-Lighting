using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using projectchicandlighting.Common;
using projectchicandlighting.Common.Result;
using projectchicandlighting.Models;
using projectchicandlighting.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projectchicandlighting.Repositories.AuthRepositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ComonResult> ChangePassword(User user, string currentPass, string newPass)
        {
            var result = await _userManager.ChangePasswordAsync(user, currentPass, newPass);
            if (result.Succeeded)
            {
                return new ComonResult { Succeed = true };
            }
            return new ComonResult { Succeed = false, Errors = result.Errors.Select(error => error.Description).ToList() };
        }

        public async Task<string> CreateToken(User user)
        {
            var userrole = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            userrole.ToList().ForEach(urn =>
            {
                claims.Add(new Claim(ClaimTypes.Role, urn));

            });
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var issuer = _configuration.GetSection("AppSettings:Issuer").Value;
            var audience = _configuration.GetSection("AppSettings:Audience").Value;

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<string> GeneratePasswordResetToken(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<User> GetCurrentUser()
        {
            var userName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            if (userName == null)
            {
                return null;
            }

            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<List<string>> GetUserRole(User user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task<bool> IsConfirmedEmail(User user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<bool> IsExistedEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<bool> IsExistedUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user != null;
        }

        public async Task<ComonResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new ComonResult { Succeed = true, User = user };
            }
            return new ComonResult { Succeed = false };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> PasswordValid(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<ComonResult> Register(string firstname, string lastname, string username, string email, string address, string password)
        {
            var user = new User
            {
                FirstName = firstname,
                LastName = lastname,
                UserName = username,
                Email = email,
                Address = address,
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, StaticRole.User);
                return new ComonResult { Succeed = true, Token = await _userManager.GenerateEmailConfirmationTokenAsync(user) };
            }
            return new ComonResult { Succeed = false, Errors = result.Errors.Select(error => error.Description).ToList() };
        }

        public async Task<ComonResult> ResetPassword(string userid, string password, string token)
        {
            var user = await _userManager.FindByIdAsync(userid);
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            if (result.Succeeded)
            {
                return new ComonResult { Succeed = true };
            }
            return new ComonResult { Succeed = false, Errors = result.Errors.Select(error => error.Description).ToList() };
        }

        public async Task<bool> VerifyEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception($"Unable to load user with ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }
        public AuthenticationProperties GetAuthenticationProperties(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        public Task<ExternalLoginInfo> GetExternalLoginInfo()
        {
            return _signInManager.GetExternalLoginInfoAsync();
        }

        public async Task<SignInResult> ExternalLogin(string provider, string providerKey)
        {
            return await _signInManager.ExternalLoginSignInAsync(provider, providerKey, isPersistent: false, bypassTwoFactor: true);
        }

        public async Task CreateNewUser(ExternalLoginInfo info)
        {
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
            var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
            var user = new User
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Address = "Not Provided"
            };
            var createResult = await _userManager.CreateAsync(user);
            if (createResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, StaticRole.User);
                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }
    }
}
