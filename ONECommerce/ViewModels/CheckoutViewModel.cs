using ONECommerce.Models;

namespace ONECommerce.ViewModels
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; }

        public Cart Cart { get; set; } = new Cart();
        //public string userName { get; set; }
    }
}
