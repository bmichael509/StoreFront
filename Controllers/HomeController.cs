using System;
using System.Linq;
using System.Collections.Generic;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;


namespace BankAccount.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }
        [HttpGet("products")]
        public IActionResult Products()
        {
            ProductsWrapper desProducts = new ProductsWrapper();
            desProducts.AllProducts = _context.Products.ToList();
            return View("NewProduct", desProducts);
        }
        [HttpPost("products")]
        public IActionResult CreateProduct(ProductsWrapper Form)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(Form.ProductForm);
                _context.SaveChanges();
            }
            return RedirectToAction("Products");
        }
        [HttpGet("products/{id}")]
        public IActionResult OneProduct(int id)
        {
            OneProductWrapper FocusProduct = new OneProductWrapper();
            FocusProduct.ThisProduct = _context.Products
                .Include(a => a.Associations)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(p => p.ProductId == id);
            FocusProduct.NonProductCategories = _context.Categories
                .Include(a => a.Associations)
                .Where(c => !c.Associations.Any(p => p.ProductId == FocusProduct.ThisProduct.ProductId))
                .ToList();
            return View("OneProduct", FocusProduct);
        }
        [HttpPost("products/{id}")]
        public IActionResult AddProductToCategory(int id, OneProductWrapper form)
        {
            form.Association.ProductId = id;
            _context.Associations.Add(form.Association);
            _context.SaveChanges();
            return RedirectToAction("OneProduct", id);
        }


        [HttpGet("categories")]
        public IActionResult Categories()
        {
            CategoriesWrapper desCategories = new CategoriesWrapper();
            desCategories.AllCategories = _context.Categories.ToList();
            return View("NewCategory", desCategories);
        }
        [HttpPost("categories")]
        public IActionResult CreateCategory(CategoriesWrapper Form)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(Form.CategoryForm);
                _context.SaveChanges();
            }
            return RedirectToAction("Categories");
        }
        [HttpGet("categories/{id}")]
        public IActionResult OneCategory(int id)
        {
            OneCategoryWrapper FocusCategory = new OneCategoryWrapper();
            FocusCategory.ThisCategory = _context.Categories
                .Include(a => a.Associations)
                .ThenInclude(c => c.Product)
                .FirstOrDefault(p => p.CategoryId == id);
            FocusCategory.NonCategoryProducts = _context.Products
                .Include(a => a.Associations)
                .Where(c => !c.Associations.Any(p => p.CategoryId == FocusCategory.ThisCategory.CategoryId))
                .ToList();
            return View("OneCategory", FocusCategory);
        }
        [HttpPost("categories/{id}")]
        public IActionResult AddCategoryToProduct(int id, OneCategoryWrapper form)
        {
            form.Association.CategoryId = id;
            _context.Associations.Add(form.Association);
            _context.SaveChanges();
            return RedirectToAction("OneCategory", id);
        }
    }
}