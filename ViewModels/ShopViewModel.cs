using Disabled.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disabled.ViewModels
{
    public class ShopViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}