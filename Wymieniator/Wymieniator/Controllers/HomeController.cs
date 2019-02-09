using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wymieniator.DAL;
using Wymieniator.Infrastucture;
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
            //HttpContext.Cache.Add() <<< W przypadku korzystania z domyslnego cache-a
            //For diffrent cache use https://www.infoq.com/news/2007/07/memcached/ OR https://docs.microsoft.com/en-us/azure/azure-cache-for-redis/cache-aspnet-session-state-provider

            ICacheProvider cache = new DefaultCacheProvider();


            var categories = new List<Category>();
            if(cache.IsSet(Consts.CategoriesCacheKey))
            {
                categories = cache.Get(Consts.CategoriesCacheKey) as List<Category>;
            }
            else
            {
                categories = db.Categories.ToList();  cache.Set(Consts.CategoriesCacheKey, categories, 60);
            }
            

            var newBooks = db.Books.Where(a => !a.Hidden).OrderBy(a => a.CategoryId).ToList();
            List<List<Book>> seperatedBooks = new List<List<Book>>();
            if(cache.IsSet(Consts.NewBooksCacheKey))
            {
                seperatedBooks = cache.Get(Consts.NewBooksCacheKey) as List<List<Book>>;
            }
            else
            {
                List<Book> temp = new List<Book>();
                for (int i = 0; i < newBooks.Count; i++)
                {
                    if (i > 0)
                    {
                        if (newBooks.ElementAt(i).CategoryId != newBooks.ElementAt(i - 1).CategoryId)
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
                cache.Set(Consts.NewBooksCacheKey, seperatedBooks, 60);
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