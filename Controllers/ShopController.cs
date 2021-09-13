using Disabled.DAL;
using Disabled.Infrastructure;
using Disabled.Models;
using Disabled.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Disabled.Controllers
{
    public class ShopController : Controller
    {
        //private ShopContext db = new ShopContext();

        ShopContext db = new ShopContext();

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> categories1;

            if (cache.IsSet(Consts.NewItemCacheKey))
            {
                categories1 = cache.Get(Consts.NewItemCacheKey) as List<Category>;
            }
            else
            {
                categories1 = db.Categories.ToList();
                cache.Set(Consts.NewItemCacheKey, categories, 30);
            }

            var vm = new ShopViewModel()
            {
                Categories = categories
            };

            return View(vm);
        }

        public ActionResult ProductDetails(int id)
        {
            var product = db.Products.Find(id);

            return View(product);
        }

        public ActionResult ProductList(string categoryname)
        {
            var category = db.Categories.Include("Products").Where(c => c.CategoryName.ToUpper() == categoryname.ToUpper()).Single();
            var products = category.Products.Where(p => !p.IsHidden);
            ViewBag.Category = category.CategoryName;
            return View(products);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 80000)]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();

            return PartialView("_CategoriesMenu", categories);
        }

        public ActionResult Search(string searchQuery)
        {
            var products = db.Products.Where(p => (p.ProductName.ToLower().Contains(searchQuery.ToLower()) && !p.IsHidden));

            return View("ProductList", products);
        }
    }
}