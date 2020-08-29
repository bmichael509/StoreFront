using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class ProductsWrapper
    {
        public Product ProductForm { get; set; }
        public List<Product> AllProducts { get; set; }
    }
}