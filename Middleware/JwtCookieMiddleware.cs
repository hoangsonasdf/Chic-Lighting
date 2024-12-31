namespace projectchicandlighting.Middleware
{
    public class JwtCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
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
