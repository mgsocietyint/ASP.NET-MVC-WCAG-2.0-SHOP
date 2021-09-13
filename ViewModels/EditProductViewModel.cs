using Disabled.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disabled.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public bool? ConfirmSuccess { get; set; }
    }
}