using Disabled.Models;
using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disabled.ViewModels
{
    public sealed class OrderConfirmationEmail : Email
    {
        public string To { get; set; }
        public decimal Cost { get; set; }
        public int OrderNumber { get; set; }
        public string FullAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}