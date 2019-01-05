using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wymieniator.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string FirstNameOfAuthor { get; set; }
        public string LastNameOfAuthor { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        public DateTime DateOfInsert { get; set; }

        public int Edition { get; set; }
        public int Pages { get; set; }
        public bool HardCover { get; set; }
        public string Language { get; set; }
        public string MainPicture { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool Hidden { get; set; }
        public string BooksForExchange { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}