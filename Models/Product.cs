using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int ProductId { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be longer than 2 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "is required")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Price must be positive")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        public List<Association> Associations { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
