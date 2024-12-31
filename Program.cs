using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Middleware;
using projectchicandlighting.Models;
using projectchicandlighting.Repositories.AuthRepositories;
using projectchicandlighting.Repositories.CartItemRepositories;
using projectchicandlighting.Repositories.CartRepositories;
using projectchicandlighting.Repositories.CategoryRepositories;
using projectchicandlighting.Repositories.CategoryRepository;
using projectchicandlighting.Repositories.FeedbackRepositories;
using projectchicandlighting.Repositories.FeedbackRepository.FeedbackRepository;
using projectchicandlighting.Repositories.ImageRepositories;
using projectchicandlighting.Repositories.OrderDetailRepositories;
using projectchicandlighting.Repositories.OrderRepositories;
using projectchicandlighting.Repositories.OrderStatusRepositories;
using projectchicandlighting.Repositories.PaymentRepositories;
using projectchicandlighting.Repositories.ProductRepositories;
using projectchicandlighting.Repositories.ProductStatusRepositories;
using projectchicandlighting.Repositories.RateRepositories;
using projectchicandlighting.Repositories.TransactionRepositories;
using projectchicandlighting.Services.PayPalServices;
using projectchicandlighting.Services.SendMailServices;
using projectchicandlighting.Services.VnPayServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("conn");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddAuthentication()
    .AddGoogle(option =>
    {
        var googleSection = builder.Configuration.GetSection("Authentication:Google");
        option.ClientId = googleSection["ID"];
        option.ClientSecret = googleSection["Secret"];
    })
    .AddFacebook(option =>
    {
        var facebookSection = builder.Configuration.GetSection("Authentication:Facebook");
        option.AppId = facebookSection["ID"];
        option.AppSecret = facebookSection["Secret"];
    });

builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IProductStatusRepository, ProductStatusRepository>();
builder.Services.AddScoped<IRateRepository, RateRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddScoped<IVnPayService, VnPayService>();
builder.Services.AddScoped<IPayPalService, PayPalService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/User") ||
  context.Request.Path.StartsWithSegments("/Cart") ||
  context.Request.Path.StartsWithSegments("/Product/Admin") ||
  context.Request.Path.StartsWithSegments("/Product/Add") ||
  context.Request.Path.StartsWithSegments("/Dashboard"), builder =>
  {
      builder.UseMiddleware<JwtCookieMiddleware>();
  });

app.UseWhen(context => context.Request.Path.StartsWithSegments("/Dashboard") ||
    context.Request.Path.StartsWithSegments("/Product/Admin") ||
    context.Request.Path.StartsWithSegments("/Product/Add")
    , builder =>
    {
        builder.UseMiddleware<JwtCheckRoleMiddleware>();
    });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
