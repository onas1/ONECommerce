using ONECommerce.Models;
using System.Collections.Generic;

namespace ONECommerce.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

    }
}
