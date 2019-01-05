using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wymieniator.Models
{
    public class Book
    {
        //Keys
        public int BookId { get; set; }
        public int CategoryId { get; set; }


        //To Validate
        [Required(ErrorMessage = "Proszę dodać tytuł kursu")]
        [StringLength(75,ErrorMessage = "Tytul nie moze miec wiecej niz 75 znakow")]
        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Proszę dodać Wydawce")]
        [StringLength(75, ErrorMessage = "Nazwa w polu Wydawca nie moze miec wiecej niz 75 znakow")]
        [DisplayName("Wydawca")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Proszę dodać Imie autora")]
        [StringLength(75, ErrorMessage = "Imię nie może być dłuższe niz 75 znaków")]
        [DisplayName("Imię Autora")]
        public string FirstNameOfAuthor { get; set; }

        [Required(ErrorMessage = "Proszę dodać nazwisko autora")]
        [StringLength(100, ErrorMessage = "Nazwisko nie może być dłuższe niz 100 znaków")]
        [DisplayName("Nazwisko Autora")]
        public string LastNameOfAuthor { get; set; }

        [Required(ErrorMessage = "Proszę dodać date wydania")]
        [DataType(DataType.Date)]
        [DisplayName("Data publikacji")]
        public DateTime PublicationDate { get; set; }

        
        [Required(ErrorMessage = "Proszę dodać ilosc stron")]
        [Range(0,10000,ErrorMessage = "Ilosc stron nie moze byc wiecej niz 100000")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "Proszę wybrać język książki")]
        [DisplayName("Językj")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić opis książki")]
        [StringLength(500, ErrorMessage = "Opis nie może być dłuższy niż 500 znaków")]
        [DisplayName("Opis książki")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić opis skrócony książki")]
        [StringLength(50, ErrorMessage = "Opis skrócony nie może być dłuższy niż 50 znaków")]
        [DisplayName("Opis skrócony książki")]
        public string ShortDescription { get; set; }


        //No to validate
        public bool Hidden { get; set; }

        [DisplayName("Książki do wymiany")]
        public string BooksForExchange { get; set; }

        public DateTime DateOfInsert { get; set; }

        [DisplayName("Edycja")]
        public int Edition { get; set; }

        [DisplayName("Twarda okładka")]
        public bool HardCover { get; set; }

        [DisplayName("Główny obrazek")]
        public string MainPicture { get; set; }

        //Lists
        public virtual Category Category { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}