using projectchicandlighting.Middleware;

namespace projectchicandlighting
{
    public static class ExtensionMethod
    {
        public static void UseCheckAuthentication(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<JwtCookieMiddleware>();
        }
        public static void UseCheckAuthorization(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<JwtCheckRoleMiddleware>();
        }
    }
}
