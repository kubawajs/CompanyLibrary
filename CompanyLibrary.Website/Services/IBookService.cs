using CompanyLibrary.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task CreateAsync(Book book);
        Task CreateAsync(Book book, ApplicationUser user);
        Task<Book> GetAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Book book);
        Task<bool> BookExists(int id);
    }
}
