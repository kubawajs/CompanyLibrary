using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyLibrary.Website.Models;

namespace CompanyLibrary.Website.Services
{
    public class BorrowingService : IBorrowingService
    {
        public Task CreateAsync(Borrowing borrowing)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Borrowing>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Borrowing> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Borrowing borrowing)
        {
            throw new NotImplementedException();
        }
    }
}
