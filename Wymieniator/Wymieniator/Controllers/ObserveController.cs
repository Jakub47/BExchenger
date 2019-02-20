using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wymieniator.DAL;
using Wymieniator.Infrastucture;
using Wymieniator.ViewModels;

namespace Wymieniator.Controllers
{
    public class ObserveController : Controller
    {
        private ObserveManager observeManager;
        private ISessionManager sessionManager { get; set; }
        private WymieniatorContext db = new WymieniatorContext();

        public ObserveController()
        {
            sessionManager = new SessionManager();
            observeManager = new ObserveManager(sessionManager, db);
        }

        // GET: Observe
        public ActionResult Index()
        {
            var elementsObserver = observeManager.GetObserver();
            ObserverViewModel vm = new ObserverViewModel()
            {
                ObservePosition = elementsObserver
            };
            return View(vm);
        }

        public ActionResult AddToObserve(int id)
        {
            observeManager.AddToObserver(id);

            return RedirectToAction("Index");
        }

        public int GetAmountOfElementsInObserver()
        {
            return observeManager.GetAmountFromObserver();
        }
    }
}