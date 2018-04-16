﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Borrowing> BorrowingsHistory { get; set; }
        // TODO: availability
    }
}
