using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class CategoriesWrapper
    {
        public Category CategoryForm { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}