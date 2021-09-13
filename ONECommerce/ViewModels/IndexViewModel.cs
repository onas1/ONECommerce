using ONECommerce.Models;
using System.Collections.Generic;

namespace ONECommerce.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> ProductList { get; set; } = new List<Product>();

    }
}
