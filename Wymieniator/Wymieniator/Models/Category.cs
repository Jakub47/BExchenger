using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wymieniator.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Wprowadz nazwe kategorii")]
        [StringLength(50, ErrorMessage = "Nazwa nie moze miec wiecej niz 50 znakow")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Wprowadz opis kategorii")]
        [StringLength(50, ErrorMessage = "opis nie moze miec wiecej niz 50 znakow")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Wprowadz ikonę dla kategorii")]
        public string Picture { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}