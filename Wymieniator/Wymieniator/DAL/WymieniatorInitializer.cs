using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Wymieniator.DAL
{
    public class WymieniatorInitializer : DropCreateDatabaseAlways<WymieniatorContext>
    {
        protected override void Seed(WymieniatorContext context)
        {
            SeedData(context);
            base.Seed(context);
        }

        private void SeedData(WymieniatorContext context)
        {
            //Create and add objects to db! 
        }
    }
}