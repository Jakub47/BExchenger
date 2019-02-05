using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wymieniator.DAL;
using Wymieniator.Models;
using Wymieniator.ViewModels;

namespace Wymieniator.Controllers
{
    public class HomeController : Controller
    {
        private WymieniatorContext db = new WymieniatorContext();
        // GET: Home
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            var newBooks = db.Books.Where(a => !a.Hidden).OrderBy(a => a.CategoryId).ToList();
            List<List<Book>> seperatedBooks = new List<List<Book>>();
            List<Book> temp = new List<Book>();

            for (int i = 0;i<newBooks.Count;i++)
            {
                if(i > 0)
                {
                    if(newBooks.ElementAt(i).CategoryId != newBooks.ElementAt(i - 1).CategoryId)
                    {
                        seperatedBooks.Add(temp);
                        temp = new List<Book>(); temp.Add(newBooks.ElementAt(i));
                    }
                    else
                    {
                        temp.Add(newBooks.ElementAt(i));
                    }
                }
                else
                    temp.Add(newBooks.ElementAt(i));
            }

            var vm = new HomeViewModel()
            {
                Categories = categories,
                NewBooksFromCategories = seperatedBooks
            };
            
            return View(vm);
        }
    }
}