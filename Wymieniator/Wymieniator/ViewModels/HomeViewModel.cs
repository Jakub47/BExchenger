using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wymieniator.Models;

namespace Wymieniator.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<IEnumerable<Book>> NewBooksFromCategories { get; set; }
    }
}