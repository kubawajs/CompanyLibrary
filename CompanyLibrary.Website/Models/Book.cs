using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string Description { get; set; }

        public DateTime AddedAt { get; private set; }
        public Availability Availability { get; private set; }

        public virtual ApplicationUser AddedBy { get; set; }

        public Book()
        {
            AddedAt = DateTime.Now;
            Availability = Availability.Available;
        }

        public void SetAddedBy(ApplicationUser appUser)
        {
            if(appUser == null)
            {
                throw new Exception("User is null.");
            }
            if (AddedBy == appUser) return;
            AddedBy = appUser;
        }

        public void IsAvailable()
        {
            Availability = Availability.Available;
        }

        public void IsNotAvailable()
        {
            Availability = Availability.NotAvailable;
        }

        public void EndBorrowing(Borrowing borrowing)
        {
            IsAvailable();
        }
    }

    public enum Availability
    {
        Available,
        NotAvailable
    }
}
