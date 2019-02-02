using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Wymieniator.Models;

namespace Wymieniator.DAL
{
    public class WymieniatorContext : DbContext
    {
        public WymieniatorContext() : base("WymieniatorContext")
        {

        }

        static WymieniatorContext()
        {
            Database.SetInitializer<WymieniatorContext>(new WymieniatorInitializer());
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<PositionOfExchange> PositionOfExchanges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}