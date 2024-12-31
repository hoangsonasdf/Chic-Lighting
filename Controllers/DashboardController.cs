using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projectchicandlighting.ModelViews.Dashboard;
using projectchicandlighting.Repositories.CategoryRepository;
using projectchicandlighting.Repositories.ProductRepositories;
using projectchicandlighting.Repositories.TransactionRepositories;

namespace projectchicandlighting.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(IProductRepository productRepository, ICategoryRepository categoryRepository, ITransactionRepository transactionRepository, ILogger<DashboardController> logger)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int month, int year)
        {
            var currentYear = DateTime.Now.Year;

            var months = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = new DateTime(2000, i, 1).ToString("MMMM")
                });
            }

            var years = new List<SelectListItem>();
            for (int i = 2000; i <= currentYear; i++)
            {
                years.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }

            var data = await _productRepository.GetDashboardProductModels(month, year);
            var labels = data
               .Select(d => d.Name)
               .ToArray();
            var values = data
                .Select(d => d.Count)
                .ToArray();
            var model = new DashboardModel
            {
                Labels = labels,
                Values = values,
                Years = years,
                Months = months,
                SelectedMonth = month,
                SelectedYear = year
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> TopCategories(int month, int year)
        {
            var currentYear = DateTime.Now.Year;


            var months = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = new DateTime(2000, i, 1).ToString("MMMM")
                });
            }

            var years = new List<SelectListItem>();
            for (int i = 2000; i <= currentYear; i++)
            {
                years.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }

            var data = await _categoryRepository.GetDashboardCategoryModels(month, year);
            var labels = data
                .Select(d => d.Name)
                .ToArray();
            var values = data
                .Select(d => d.Count)
                .ToArray();
            var model = new DashboardModel
            {
                Labels = labels,
                Values = values,
                Years = years,
                Months = months,
                SelectedMonth = month,
                SelectedYear = year
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> TopRate()
        {
            var data = await _productRepository.GetDashboardProductRateModels();
            var labels = data
                .Select(d => d.Name)
                .ToArray();
            var values = data
                .Select(d => d.Average)
                .ToArray();
            var model = new DashboardModel
            {
                Labels = labels,
                DoubleValues = values
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Profit(int year)
        {
            var currentYear = DateTime.Now.Year;



            var years = new List<SelectListItem>();
            for (int i = 2000; i <= currentYear; i++)
            {
                years.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }
            var data = await _transactionRepository.GetDashboardProfitModels(year);
            var labels = data
                .Select(d => d.Month)
                .ToArray();
            var values = data
                .Select(d => d.Total)
                .ToArray();
            var model = new DashboardModel
            {
                Labels = labels,
                DoubleValues = values,
                Years = years,
                SelectedYear = year
            };
            return View(model);
        }
    }
}
