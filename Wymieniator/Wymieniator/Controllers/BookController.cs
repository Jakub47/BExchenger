using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wymieniator.DAL;

namespace Wymieniator.Controllers
{
    public class BookController : Controller
    {
        private WymieniatorContext db = new WymieniatorContext();

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var book = db.Books.Find(id);
            return View(book);
        }

        public ActionResult ListC(string nameOfCategory)
        {
            var books = db.Books.Where(a => a.Category.Name == nameOfCategory).ToList();
            return View(books);
        }
    }
}