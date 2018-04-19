using CompanyLibrary.Website.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetAllByUserAsync(ApplicationUser user);
        Task CreateAsync(Book book);
        Task CreateAsync(Book book, ApplicationUser user);
        Task<Book> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Book book);
        Task<bool> BookExists(int id);
        Task EndBorrowing(Borrowing borrowing);
    }
}
