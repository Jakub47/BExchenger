using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wymieniator.ViewModels
{
    public class ObserveDeleteViewModel
    {
        public int IdOfPosition { get; set; }
        public int ObserverAmount { get; set; }
        public int AmountOfDeletingItems { get; set; }
    }
}