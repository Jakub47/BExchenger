using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wymieniator.DAL;
using Wymieniator.Models;

namespace Wymieniator.Infrastucture
{
    public class ObserveManager
    {
        private WymieniatorContext db;
        private ISessionManager session;

        public ObserveManager(ISessionManager session,WymieniatorContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<ObservePosition> GetObserver()
        {
            List<ObservePosition> observe;

            if(session.Get<List<ObservePosition>>(Consts.ObserverSessionKey) == null)
            {
                observe = new List<ObservePosition>();
            }
            else
            {
                observe = session.Get<List<ObservePosition>>(Consts.ObserverSessionKey) as List<ObservePosition>;
            }

            return observe;
        }
        public void AddToObserver(int bookId)
        {
            var observer = GetObserver();
            var observerPosition = observer.Find(b => b.Book.BookId == bookId);

            if (observerPosition != null)
                observerPosition.Amount++;
            else
            {
                var bookToAdd = db.Books.Where(b => b.BookId == bookId).SingleOrDefault();

                if(bookToAdd != null)
                {
                    var newObserverPosition = new ObservePosition()
                    {
                        Book = bookToAdd,
                        Amount = 1,
                    };
                    observer.Add(newObserverPosition);
                }
            }

            session.Set(Consts.ObserverSessionKey, observer);

        }
        public int DeleteFromObserver(int bookId)
        {
            var observer = GetObserver();
            var observerPosition = observer.Find(k => k.Book.BookId == bookId);


            if(observerPosition != null)
            {
                if(observerPosition.Amount > 1)
                {
                    observerPosition.Amount--;
                    return observerPosition.Amount;
                }
                else
                {
                    observer.Remove(observerPosition);
                }
            }
            return 0;
        }
        public decimal GetAmountFromObserver()
        {
            var observer = GetObserver();
            return observer.Sum(o => o.Amount);
        }
        public Exchange CreateExchange(Exchange newExchange,string userId)
        {
            var observer = GetObserver();
            newExchange.DateOfInsert = DateTime.Now;
            //newExchange.userId = userId;
            db.Exchanges.Add(newExchange);
            if(newExchange.PositionOfExchange == null)
            {
                newExchange.PositionOfExchange = new List<PositionOfExchange>();
            }

            foreach (var Element in observer)
            {
                var newPosition = new PositionOfExchange()
                {

                    BookId = Element.Book.BookId,
                };

                newExchange.PositionOfExchange.Add(newPosition);
            }
            db.SaveChanges();
            return newExchange;
        }

        public void Empty()
        {
            session.Set<List<PositionOfExchange>>(Consts.ObserverSessionKey, null);
        }
    }
}