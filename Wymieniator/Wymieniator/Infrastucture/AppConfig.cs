using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Wymieniator.Infrastucture
{
    /// <summary>
    /// Class responsible for getting values from Web.config
    /// </summary>
    public class AppConfig
    {
        private static string _iconsForCategoryFolder = ConfigurationManager.AppSettings["IconsForCategoryFolder"];

        public static string IconsForCategoryFolder
        {
            get
            {
                return _iconsForCategoryFolder;
            }
        }

        private static string _imagesFolder = ConfigurationManager.AppSettings["ImagesFolder"];

        public static string ImagesFolder
        {
            get
            {
                return _imagesFolder;
            }
        }
    }
}