using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wymieniator.DAL;
using Wymieniator.Models;

namespace Wymieniator.Controllers
{
    public class HomeController : Controller
    {
        private WymieniatorContext db = new WymieniatorContext();
        
        // GET: Home
        public ActionResult Index()
        {
            var category = new Category
            {
                Name = "Fantasy",
                Description = "Kategoria dla książek fantastycznych",
                Picture = "Fantasy.png"
            };
            db.Categories.Add(category);
            db.SaveChanges();
            return View();
        }
    }
}