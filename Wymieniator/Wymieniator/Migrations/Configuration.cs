namespace Wymieniator.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Wymieniator.DAL;

    public sealed class Configuration : DbMigrationsConfiguration<Wymieniator.DAL.WymieniatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Wymieniator.DAL.WymieniatorContext";
        }

        protected override void Seed(Wymieniator.DAL.WymieniatorContext context)
        {
            //  This method will be called after migrating to the latest version.
            WymieniatorInitializer.SeedData(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
