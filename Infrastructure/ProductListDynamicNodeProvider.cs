using Disabled.DAL;
using Disabled.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disabled.Infrastructure
{
    public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ShopContext db = new ShopContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Category c in db.Categories)
            {
                DynamicNode n = new DynamicNode();
                n.Title = c.CategoryName;
                n.Key = "Category_" + c.CategoryId;
                n.RouteValues.Add("categoryname", c.CategoryName);
                returnValue.Add(n);
            }

            return returnValue;
        }
    }
}