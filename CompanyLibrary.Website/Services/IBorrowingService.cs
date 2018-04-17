using CompanyLibrary.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Services
{
    public interface IBorrowingService
    {
        Task<IEnumerable<Borrowing>> GetAllAsync();
        Task CreateAsync(Borrowing borrowing);
        Task CreateAsync(ApplicationUser user, Book book);
        Task<Borrowing> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Borrowing borrowing);
        Task<bool> BorrowingExists(int id);
    }
}
