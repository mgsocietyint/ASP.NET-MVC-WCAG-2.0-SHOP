using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Disabled.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Wprowadź nazwę produktu.")]
        public string ProductName { get; set; }
        public string ProducerId { get; set; }
        public string ProductImageFileName { get; set; }
        [Required(ErrorMessage = "Wprowadź opis produktu.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Wprowadź cenę produktu.")]
        public decimal Price { get; set; }
        public bool IsHidden { get; set; }
        public virtual Category Category { get; set; }
    }
}