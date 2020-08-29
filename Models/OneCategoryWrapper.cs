using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class OneCategoryWrapper
    {
        public Category ThisCategory { get; set; }
        public List<Product> NonCategoryProducts { get; set; }
        public Product ProductForm { get; set; }
        public Association Association { get; set; }
    }
}