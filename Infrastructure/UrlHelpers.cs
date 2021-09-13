using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disabled.Infrastructure
{
    public static class UrlHelpers
    {
        public static string ProductIconPath(this UrlHelper helper, string productIconFilename)
        {
            var productIconFolder = AppConfig.ProductIconsFolderRelative;
            var path = Path.Combine(productIconFolder, productIconFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string CategoryIconPath(this UrlHelper helper, string categoryIconFilename)
        {
            var categoryIconFolder = AppConfig.CategoryIconsFolderRelative;
            var path = Path.Combine(categoryIconFolder, categoryIconFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}