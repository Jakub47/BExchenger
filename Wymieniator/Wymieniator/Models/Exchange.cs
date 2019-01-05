using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wymieniator.Models
{
    public class Exchange
    {
        public int ExchangeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public DateTime DateOfInsert { get; set; }

        public Accepted Accepted { get; set; }

        List<PositionOfExchange> PositionOfExchange { get; set; }
        public virtual ICollection<Book> BooksToExchange { get; set; }
    }

    public enum Accepted
    {
        Yes,
        No,
        Thinking
    }
}