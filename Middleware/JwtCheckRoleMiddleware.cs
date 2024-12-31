using projectchicandlighting.Common;
using projectchicandlighting.Repositories.AuthRepositories;

namespace projectchicandlighting.Middleware
{
    public class JwtCheckRoleMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCheckRoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated && context.User.IsInRole(StaticRole.Admin))
            {
                await _next(context);
            }
            else
            {
                context.Response.Redirect("/Auth/Login");
            }
        }
    }
}
