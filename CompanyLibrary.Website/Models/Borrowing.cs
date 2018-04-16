using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Models
{
    public class Borrowing
    {
        public DateTime RentalDate { get; set; }
        public virtual Book Book { get; set; }
        public virtual ApplicationUser Borrower { get; set; }
    }
}
