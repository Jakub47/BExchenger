using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Wymieniator.Migrations;
using Wymieniator.Models;

namespace Wymieniator.DAL
{
    public class WymieniatorInitializer : MigrateDatabaseToLatestVersion<WymieniatorContext, Configuration>
    {

        public static void SeedData(WymieniatorContext context)
        {
            var categories = new List<Category>
            {
                new Category() {CategoryId = 1, Name = "Fantasy", Description = "Książki zawierające elementy fantasy",
                                Picture = "fantasy.png"},
                new Category() {CategoryId = 2, Name = "Horror", Description = "Książki zawierające elementy horroru",
                                Picture = "horror.png"},
                new Category() {CategoryId = 3, Name = "Historyczne", Description = "Książki zawierające elementy historii",
                                Picture = "naukowe.png"},
                new Category() {CategoryId = 4, Name = "Slowniki", Description = "Książki slużące do tłumaczeń",
                                Picture = "slownik.png"},
                new Category() {CategoryId = 5, Name = "Sensacyjne", Description = "Książki zawierające elementy sensacji",
                                Picture = "sensacja.png"},
            };
            categories.ForEach(a => context.Categories.AddOrUpdate(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book() {BookId = 1, CategoryId = 1 , Title = "Władca Pierścieni: Druzyńa Pierścienia", Publisher = "Wydawnictwo MUZA S.A.",
                            FirstNameOfAuthor = "John" , LastNameOfAuthor = "Tolkien" , PublicationDate = new DateTime(2012,10,10), Pages = 1280,
                            Language = "PL", Description = "Władca Pierścieni to jedna z najbardziej niezwykłych książek w całej współczesnej literaturze. Ogromna, z epickim rozmachem napisana powieść wprowadza nas w wykreowany przez wyobraźnię autora świat - fantastyczny, lecz ukazany wszechstronnie i szczegółowo, równie pełny i bogaty jak świat realny.",
                            ShortDescription = "Władca Pierścieni to jedna z tych książek",
                            BooksForExchange = "Wiedzmin|Metro2033", DateOfInsert = DateTime.Now, HardCover = true,
                            MainPicture = "WladcaPierscieniaDP.png"},

                 new Book() {BookId = 2, CategoryId = 2 , Title = "Metro 2033", Publisher = "Insignis Media",
                            FirstNameOfAuthor = "Dmitrij" , LastNameOfAuthor = "Głuchowski" , PublicationDate = new DateTime(2009,11,24), Pages = 513,
                            Language = "PL", Description = "rosyjska powieść postapokaliptyczna napisana przez Dmitrija Głuchowskiego, pierwsza część trylogii. Akcja powieści rozgrywa się w moskiewskim metrze w 2033 roku, 20 lat po wojnie nuklearnej. Została opublikowana w 2005 roku w Rosji, a w Polsce ukazała się w 2010 roku nakładem wydawnictwa Insignis Media. W 2007 roku nagrodzona za najlepszy debiut na europejskim konkursie literackim Eurocon w Kopenhadze.",
                            ShortDescription = "rosyjska powieść postapokaliptyczna",
                            BooksForExchange = "Star wars | Czerwona ręka", DateOfInsert = DateTime.Now, HardCover = false,
                            MainPicture = "Metro2033.png"},

                  new Book() {BookId = 3, CategoryId = 3 , Title = "Pamiętnik Paska", Publisher = "Wydawnictwo Iskry",
                            FirstNameOfAuthor = "Jan" , LastNameOfAuthor = "Pasek" , PublicationDate = new DateTime(2012,10,10), Pages = 624,
                            Language = "PL", Description = "Pamiętniki, które Pasek spisywał najprawdopodobniej pod koniec życia (w latach 1690–1695), zostały wydane drukiem w 1836  roku przez Raczyńskiego. Dzielą się na dwie części: lata 1655–1666 – obejmują służbę w wojskach Rzeczypospolitej, lata 1667–1688 – żywot ziemiański (sprawy domowe i publiczne).",
                            ShortDescription = "Pamiętniki, które Pasek spisywał pod koniec życia",
                            BooksForExchange = "Napoleon", DateOfInsert = DateTime.Now, HardCover = false,
                            MainPicture = "Pasek.png"},

                   new Book() {BookId = 4, CategoryId = 4 , Title = "Słownik angielsko-polski, polsko-angielski", Publisher = "	Oxford University Press",
                            FirstNameOfAuthor = "Opracowanie" , LastNameOfAuthor = "Zbiorowe" , PublicationDate = new DateTime(2008,04,14), Pages = 1092,
                            Language = "PL", Description = "Oxford Wordpower to praktyczny słownik polsko-angielski i angielsko-polski z CD-ROM-em, zawierający słownictwo od poziomu średnio zaawansowanego do zaawansowanego. ",
                            ShortDescription = "Oxford Wordpower to słownik polskoangielski",
                            BooksForExchange = "Słownik niemiecko-polski|Metro2033", DateOfInsert = DateTime.Now, HardCover = false,
                            MainPicture = "SlownikANPL.png"},

                   new Book() {BookId = 5, CategoryId = 5 , Title = "Dziewczyna, która igrała z ogniem", Publisher = "Czarna Owca",
                            FirstNameOfAuthor = "Stieg" , LastNameOfAuthor = "Larsson" , PublicationDate = new DateTime(2011,08,25), Pages = 700,
                            Language = "ENG", Description = "W kolejnej, po Mężczyznach, którzy nienawidzą kobiet, części trylogii Millennium główną bohaterką jest Lisbeth Salander. Seria dramatycznych wypadków wywołuje u Lisbeth wspomnienia mrocznej przeszłości, z którą raz na zawsze postanawia się rozprawić. Dwoje dziennikarzy, Dag i Mia, docierają do niezwykłych informacji na temat rozległej siatki przemycającej z Europy Wschodniej do Szwecj",
                            ShortDescription = "Części trylogii Millennium główną bohaterką ",
                            BooksForExchange = "Wiedzmin", DateOfInsert = DateTime.Now, HardCover = true,
                            MainPicture = "DziewczynaKtoraIgralaZOgniem.png" },
                    new Book() {BookId = 6, CategoryId = 1 , Title = "temp", Publisher = "temp2",
                            FirstNameOfAuthor = "xsd" , LastNameOfAuthor = "qww" , PublicationDate = new DateTime(2008,04,14), Pages = 1092,
                            Language = "cx", Description = "ss",
                            ShortDescription = "dd",
                            BooksForExchange = "qwz", DateOfInsert = DateTime.Now, HardCover = false,
                            MainPicture = "x3.png",
                    }
            };
            books.ForEach(a => context.Books.AddOrUpdate(a));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}