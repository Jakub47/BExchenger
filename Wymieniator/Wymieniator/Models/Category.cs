﻿using System.Collections.Generic;

namespace Wymieniator.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}