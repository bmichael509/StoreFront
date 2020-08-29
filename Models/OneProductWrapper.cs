using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class OneProductWrapper
    {
        public Product ThisProduct { get; set; }
        public List<Category> NonProductCategories { get; set; }
        public Category CategoryForm { get; set; }
        public Association Association { get; set; }
    }
}