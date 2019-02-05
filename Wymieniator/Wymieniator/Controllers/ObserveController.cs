using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wymieniator.Controllers
{
    public class ObserveController : Controller
    {
        // GET: Observe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToObserve(int id)
        {
            return View();
        }
    }
}