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

        [StringLength(2000)]
        public string Description { get; set; }

        public virtual IEnumerable<Borrowing> BorrowingsHistory { get; set; }
        public virtual ApplicationUser AddedBy { get; set; }
        // TODO: availability

        public void SetAddedBy(ApplicationUser appUser)
        {
            if(appUser == null)
            {
                throw new Exception("User is null.");
            }
            if (AddedBy == appUser) return;
            AddedBy = appUser;
        }
    }
}
