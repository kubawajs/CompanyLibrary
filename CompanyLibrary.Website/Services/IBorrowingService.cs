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
        Task<Borrowing> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Borrowing borrowing);
    }
}
