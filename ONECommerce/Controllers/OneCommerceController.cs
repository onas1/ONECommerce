using Microsoft.AspNetCore.Mvc;
using ONECommerce.Models;
using ONECommerce.Repositories.Interface;
using ONECommerce.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ONECommerce.Controllers
{
    public class OneCommerceController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;


        public OneCommerceController(ICartRepository cartRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        //get cart by username

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var Cart = await _cartRepository.GetCartByUserName("test");

            return View(Cart);
        }

        //remove item from cart
        public async Task<IActionResult> Cart(int cartId, int cartItemId)
        {
            await _cartRepository.RemoveItem(cartId, cartItemId);
            return RedirectToAction("Cart");
        }



        //checkout page
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var cart = new CheckoutViewModel
            {
                Cart = await _cartRepository.GetCartByUserName("test"),
            };

            return View(cart);
        }




        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkout)
        {
            checkout.Cart = await _cartRepository.GetCartByUserName("test");

            if (!ModelState.IsValid)
            {
                return View();
            }

            checkout.Order = new Order
            {
                UserName = "test",
                TotalPrice = checkout.Cart.TotalPrice
            };

            await _orderRepository.CheckOut(checkout.Order);
            await _cartRepository.ClearCart("test");

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }




        // confirmation page

        public void OnGetContact()
        {

            var Message = "Your email was sent.";
        }

        public void OnGetOrderSubmitted()
        {
            var Message = "Your order submitted successfully.";
        }




        //contact page
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }



        //get orders
        [HttpGet]
        public async Task<IActionResult> Order()
        {
            var orders = new OrderViewModel
            {
                Orders = await _orderRepository.GetOrdersByUserName("test")
            };

            return View(orders);
        }



        //products
        [HttpGet]
        public async Task<IActionResult> Product(int? categoryId)
        {

            var ProductsToReturn = new ProductViewModel();

            ProductsToReturn.CategoryList = await _productRepository.GetCategories();

            if (categoryId.HasValue)
            {
                ProductsToReturn.ProductList = await _productRepository.GetProductByCategory(categoryId.Value);
                ProductsToReturn.SelectedCategory = ProductsToReturn.CategoryList.FirstOrDefault(c => c.Id == categoryId.Value)?.Name;
            }
            else
            {
                ProductsToReturn.ProductList = await _productRepository.GetProducts();
            }

            return View(ProductsToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _cartRepository.AddItem("test", productId);
            return RedirectToAction("Cart");
        }



        //product details
        [HttpGet]
        public async Task<IActionResult> ProductDetail(int? productId)
        {
            var productDetailsToReturn = new ProductDetailViewModel();
            if (productId == null)
            {
                return NotFound();
            }

            productDetailsToReturn.Product = await _productRepository.GetProductById(productId.Value);
            if (productDetailsToReturn.Product == null)
            {
                return NotFound();
            }
            return View(productDetailsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAddToCartAsync(ProductDetailViewModel model)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _cartRepository.AddItem("test", model.Product.Id, model.Quantity, model.Color);
            return RedirectToAction("Cart");
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
