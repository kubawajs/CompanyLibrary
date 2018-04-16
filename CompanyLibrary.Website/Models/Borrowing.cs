using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Models
{
    public class Borrowing
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RentalDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual ApplicationUser Borrower { get; set; }
    }
}
