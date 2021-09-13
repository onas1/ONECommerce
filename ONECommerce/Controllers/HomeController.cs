using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ONECommerce.Models;
using ONECommerce.Repositories.Interface;
using ONECommerce.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ONECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductRepository productRepository, ICartRepository cartRepository, ILogger<HomeController> logger)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _logger = logger;
        }






        public async Task<IActionResult> Index()
        {
            var products = new IndexViewModel
            {
                ProductList = await _productRepository.GetProducts()
            };

            return View(products);
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _cartRepository.AddItem("test", productId);
            return RedirectToPage("Cart");
        }













        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
