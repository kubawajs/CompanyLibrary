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
        public DateTime RentalDate { get; private set; }

        public virtual Book Book { get; set; }
        public virtual ApplicationUser Borrower { get; set; }

        public Borrowing()
        {
            RentalDate = DateTime.Now;
        }


        public void SetBorrower(ApplicationUser user)
        {
            if(user == null)
            {
                throw new Exception("User is empty.");
            }
            if (Borrower == user) return;
            Borrower = user;
        }

        public void SetBook(Book book)
        {
            if (book == null)
            {
                throw new Exception("Book is empty.");
            }
            if (Book == book) return;
            Book = book;
        }
    }
}
