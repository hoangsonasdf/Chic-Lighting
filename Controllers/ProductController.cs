using Microsoft.AspNetCore.Mvc;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Product;
using projectchicandlighting.Repositories.CategoryRepository;
using projectchicandlighting.Repositories.ImageRepositories;
using projectchicandlighting.Repositories.ProductRepositories;
using projectchicandlighting.Repositories.ProductStatusRepositories;
using projectchicandlighting.Repositories.RateRepositories;
using projectchicandlighting.Request;

namespace projectchicandlighting.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IRateRepository _rateRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductStatusRepository _productStatusRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, IRateRepository rateRepository, ICategoryRepository categoryRepository, IProductStatusRepository productStatusRepository, IImageRepository imageRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _rateRepository = rateRepository;
            _categoryRepository = categoryRepository;
            _productStatusRepository = productStatusRepository;
            _imageRepository = imageRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? search, int page = 1)
        {
            List<ProductIndexModel> products;
            int total;
            if (search == null)
            {
                products = await _productRepository.GetProductIndexModels(page);
                total = await _productRepository.GetNumberOfProduct();
            }
            else
            {
                products = await _productRepository.GetProductIndexModelsByName(page, search);
                total = await _productRepository.GetNumberOfProductByName(search);
            }
            var model = new ProductModel
            {
                Products = products,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)total / StaticPageSize.PageSize),
                Search = search,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Admin(int page = 1)
        {
            var products = await _productRepository.GetProductIndexModels(page);
            var total = await _productRepository.GetNumberOfProduct();
            var model = new ProductModel
            {
                Products = products,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)total / StaticPageSize.PageSize),
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var model = await _productRepository.GetProductIndexModelById(id);
            var review = await _rateRepository.GetStarReportByProductId(id);
            var totalReview = await _rateRepository.CountTotalReviewByProductId(id);
            var averageRate = await _rateRepository.GetAvarageRate(id);
            model.Review = review;
            model.TotalReview = totalReview;
            model.AverageRate = averageRate;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var statuses = await _productStatusRepository.GetAddProductStatusModels();
            var categories = await _categoryRepository.GetAddProductCategoryModels();
            var model = new AddEditProductModel
            {
                Categories = categories,
                Statuses = statuses,
                Request = new AddEditProductRequest()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var product = await _productRepository.GetProductIndexModelById(id);
            var statuses = await _productStatusRepository.GetAddProductStatusModels();
            var categories = await _categoryRepository.GetAddProductCategoryModels();
            var model = new AddEditProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Status = product.Status,
                Category = product.Category,
                SalePrice = product.SalePrice,
                Images = product.Image,
                Categories = categories,
                Statuses = statuses,
                Description = product.Description,
                Request = new AddEditProductRequest()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEditProductRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var statuses = await _productStatusRepository.GetAddProductStatusModels();
                    var categories = await _categoryRepository.GetAddProductCategoryModels();
                    var model = new AddEditProductModel
                    {
                        Categories = categories,
                        Statuses = statuses,
                        Request = request
                    };
                    return View(model);
                }
                var product = new Product
                {
                    Name = request.ProductName,
                    Quantity = request.Quantity,
                    Price = request.Price,
                    ProductStatusId = request.ProductStatusId,
                    CategoryId = request.CategoryId,
                    Saleprice = request.SalePrice,
                    Description = request.Description
                };
                await _productRepository.Add(product);
                if (request.Images.Count > 0)
                {
                    var index = 0;
                    foreach (var image in request.Images)
                    {
                        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                        string fileName = $"{timestamp}_{image.FileName}";
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "lightType", fileName);
                        using (var stream = System.IO.File.Create(path))
                        {
                            await image.CopyToAsync(stream);
                        }
                        var newImage = new Image
                        {
                            Path = $"/img/lightType/{fileName}",
                            IsAvatar = (index == 0),
                            ProductId = product.Id
                        };
                        await _imageRepository.Add(newImage);
                        index++;
                    }
                }
                ViewBag.Success = StaticMessage.AddSuccess;
                var statusess = await _productStatusRepository.GetAddProductStatusModels();
                var categoriess = await _categoryRepository.GetAddProductCategoryModels();
                var modell = new AddEditProductModel
                {
                    Categories = categoriess,
                    Statuses = statusess,
                    Request = new AddEditProductRequest()
                };
                return View(modell);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                var statuses = await _productStatusRepository.GetAddProductStatusModels();
                var categories = await _categoryRepository.GetAddProductCategoryModels();
                var model = new AddEditProductModel
                {
                    Categories = categories,
                    Statuses = statuses,
                    Request = request
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEditProductRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var statuses = await _productStatusRepository.GetAddProductStatusModels();
                    var categories = await _categoryRepository.GetAddProductCategoryModels();
                    var model = new AddEditProductModel
                    {
                        Id = request.ProductId,
                        Name = request.ProductName,
                        Quantity = request.Quantity,
                        Price = request.Price,
                        Status = request.ProductStatusId,
                        Category = request.CategoryId,
                        SalePrice = request.SalePrice,
                        Categories = categories,
                        Statuses = statuses,
                        Images = await _imageRepository.GetImagePathByProductId(request.ProductId),
                        Description = request.Description,
                        Request = request
                    };
                    return View(model);
                }

                // Retrieve the existing product
                var product = await _productRepository.GetById(request.ProductId);

                // Update product details
                product.Name = request.ProductName;
                product.Quantity = request.Quantity;
                product.Price = request.Price;
                product.ProductStatusId = request.ProductStatusId;
                product.CategoryId = request.CategoryId;
                product.Saleprice = request.SalePrice;
                product.Description = request.Description;

                await _productRepository.Update(request.ProductId, product);

                // Handle image updates
                if (request.Images != null && request.Images.Count > 0)
                {
                    // Remove existing images for this product
                    var existingImages = await _imageRepository.GetByProductId(product.Id);
                    foreach (var existingImage in existingImages)
                    {
                        // Delete file from filesystem
                        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingImage.Path.TrimStart('/'));
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        // Remove from database
                        await _imageRepository.Delete(existingImage.Id);
                    }

                    // Add new images
                    var index = 0;
                    foreach (var image in request.Images)
                    {
                        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                        string fileName = $"{timestamp}_{image.FileName}";
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "lightType", fileName);

                        // Ensure directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(path));

                        // Save file
                        using (var stream = System.IO.File.Create(path))
                        {
                            await image.CopyToAsync(stream);
                        }

                        // Create new image record
                        var newImage = new Image
                        {
                            Path = $"/img/lightType/{fileName}",
                            IsAvatar = (index == 0),
                            ProductId = product.Id
                        };
                        await _imageRepository.Add(newImage);
                        index++;
                    }
                }

                // Prepare the view model for return
                ViewBag.Success = StaticMessage.EditSuccess;
                var statusess = await _productStatusRepository.GetAddProductStatusModels();
                var categoriess = await _categoryRepository.GetAddProductCategoryModels();
                var modell = new AddEditProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Status = product.ProductStatusId,
                    Category = product.CategoryId,
                    SalePrice = product.Saleprice,
                    Categories = categoriess,
                    Statuses = statusess,
                    Description = product.Description,
                    Images = await _imageRepository.GetImagePathByProductId(product.Id),
                    Request = new AddEditProductRequest()
                };

                return View(modell);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + (ex.InnerException?.Message ?? ""));
                var statuses = await _productStatusRepository.GetAddProductStatusModels();
                var categories = await _categoryRepository.GetAddProductCategoryModels();
                var model = new AddEditProductModel
                {
                    Categories = categories,
                    Statuses = statuses,
                    Request = request
                };
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string productId)
        {
            try
            {
                await _productRepository.Delete(productId);
                return RedirectToAction("Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Admin");
            }
        }
    }
}
