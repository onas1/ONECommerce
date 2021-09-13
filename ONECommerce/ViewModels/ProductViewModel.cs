using ONECommerce.Models;
using System.Collections.Generic;

namespace ONECommerce.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; } = new List<Category>();
        public IEnumerable<Product> ProductList { get; set; } = new List<Product>();
        public string SelectedCategory { get; set; }
    }
}
