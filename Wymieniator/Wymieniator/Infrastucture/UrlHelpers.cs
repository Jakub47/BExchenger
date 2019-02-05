using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wymieniator.Infrastucture
{
    public static class UrlHelpers
    {
        public static string CategoriesIconsPath(this UrlHelper helper, string nameIconOfCategory)
        {
            var CategoriesIconsFolder = AppConfig.IconsForCategoryFolder;
            var path = Path.Combine(CategoriesIconsFolder, nameIconOfCategory);
            var pathAb = helper.Content(path);
            return pathAb;
        }

        public static string ImagesPath(this UrlHelper helper, string nameOfImage)
        {
            var ImagesFolder = AppConfig.ImagesFolder;
            var path = Path.Combine(ImagesFolder, nameOfImage);
            var pathAb = helper.Content(path);
            return pathAb;
        }
    }
}