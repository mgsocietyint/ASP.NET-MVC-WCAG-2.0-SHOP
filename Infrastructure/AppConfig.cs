using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Disabled.Infrastructure
{
    public class AppConfig
    {
        private static string _productIconsFolderRelative = ConfigurationManager.AppSettings["ProductIconsFolder"];
        private static string _categoryIconsFolderRelative = ConfigurationManager.AppSettings["CategoryIconsFolder"];

        public static string CategoryIconsFolderRelative
        {
            get
            {
                return _categoryIconsFolderRelative;
            }
        }

        public static string ProductIconsFolderRelative
        {
            get
            {
                return _productIconsFolderRelative;
            }
        }
    }
}