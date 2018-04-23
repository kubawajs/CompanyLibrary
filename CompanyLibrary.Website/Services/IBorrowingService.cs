using CompanyLibrary.Website.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Services
{
    public interface IBorrowingService
    {
        Task<IEnumerable<Borrowing>> GetAllAsync();
        Task<IEnumerable<Borrowing>> GetAllByBookAsync(Book book);
        Task<IEnumerable<Borrowing>> GetAllForUserByStateAsync(ApplicationUser user, BorrowingState state);
        Task CreateAsync(Borrowing borrowing);
        Task CreateAsync(ApplicationUser user, Book book);
        Task<Borrowing> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Borrowing borrowing);
        Task<bool> BorrowingExists(int id);
        Task EndBorrowing(Borrowing borrowing);
    }
}
