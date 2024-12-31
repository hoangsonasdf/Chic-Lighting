using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using projectchicandlighting.Common.Result;
using projectchicandlighting.Models;
using projectchicandlighting.Request;

namespace projectchicandlighting.Repositories.AuthRepositories
{
    public interface IAuthRepository
    {
        Task<ComonResult> Login(string username, string password);
        Task<ComonResult> Register(string firstname, string lastname, string username, string email, string address, string password);
        Task<ComonResult> ResetPassword(string userid, string password, string token);
        Task<User> GetCurrentUser();
        Task<string> CreateToken(User user);
        Task<bool> VerifyEmail(string userId, string token);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsername(string username);
        Task<List<string>> GetUserRole(User user);
        Task<User> GetUserById(string id);
        Task<bool> IsExistedEmail(string email);
        Task<bool> IsExistedUsername(string username);
        Task<bool> IsConfirmedEmail(User user);
        Task<string> GeneratePasswordResetToken(User user);
        Task<bool> PasswordValid(User user, string password);
        Task<ComonResult> ChangePassword(User user, string currentPass, string newPass);
        Task Logout();
        AuthenticationProperties GetAuthenticationProperties(string provider, string redirectUrl);
        Task<ExternalLoginInfo> GetExternalLoginInfo();
        Task<SignInResult> ExternalLogin(string provider, string providerKey);
        Task CreateNewUser(ExternalLoginInfo info);
    }
}
