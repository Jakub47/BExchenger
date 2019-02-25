using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wymieniator.ViewModels;

namespace Wymieniator.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);
            else
                return RedirectToAction("Index", "Home");

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else
                return RedirectToAction("Index", "Home");

        }
    }
}