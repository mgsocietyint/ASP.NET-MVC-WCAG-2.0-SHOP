using Disabled.DAL;
using Disabled.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disabled.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ShopContext db = new ShopContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Product p in db.Products)
            {
                DynamicNode n = new DynamicNode();
                n.Title = p.ProductName;
                n.Key = "Product_" + p.ProductId;
                n.ParentKey = "Category_" + p.CategoryId;
                n.RouteValues.Add("id", p.ProductId);
                returnValue.Add(n);
            }

            return returnValue;
        }
    }
}