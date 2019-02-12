using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wymieniator.Models
{
    public class Exchange
    {
        //Keys
        public int ExchangeId { get; set; }


        //Validate
        [Required(ErrorMessage = "Proszę dodać imie")]
        [StringLength(75, ErrorMessage = "Imię nie może być dłuższe niz 75 znaków")]
        [DisplayName("Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Proszę dodać nazwisko")]
        [StringLength(100, ErrorMessage = "Nazwisko nie może być dłuższe niz 100 znaków")]
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Proszę podać ulice")]
        [StringLength(100, ErrorMessage = "Nazwa ulica nie może być dłuższe niz 100 znaków")]
        [DisplayName("Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Proszę podać miasto")]
        [StringLength(100, ErrorMessage = "Nazwa miasta nie może być dłuższe niz 100 znaków")]
        [DisplayName("Miasto")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Proszę podać kod pocztowy")]
        [RegularExpression(@"\d{2}-\d{3}",ErrorMessage = "Nie poprawna forma kodu")]
        [DisplayName("Kod pocztowy")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        [RegularExpression(@"^(?:\d{8}|00\d{10}|\+\d{2}\d{8})$", ErrorMessage = "Nie poprawna forma numeru")]
        [DisplayName("Numer telefonu")]
        public string TelephoneNumber { get; set; }

        [Required(ErrorMessage = "Proszę podać adres email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        [DisplayName("Email")]
        public string Email { get; set; }


        //Not validate
        [StringLength(50, ErrorMessage = " Długość Informacji nie może być dłuższe niz 50 znaków")]
        [DisplayName("Dodatkowe informacje")]
        public string Info { get; set; }

        public DateTime DateOfInsert { get; set; }

        public Accepted Accepted { get; set; }

        //Lists
        public List<PositionOfExchange> PositionOfExchange { get; set; }
        public virtual ICollection<Book> BooksToExchange { get; set; }
    }

    public enum Accepted
    {
        Yes,
        No,
        Thinking
    }
}