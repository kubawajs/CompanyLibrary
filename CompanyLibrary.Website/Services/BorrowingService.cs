using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyLibrary.Website.Data;
using CompanyLibrary.Website.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyLibrary.Website.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly CompanyLibraryDbContext _context;

        public BorrowingService(CompanyLibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Borrowing borrowing)
        {
            await _context.AddAsync(borrowing);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(ApplicationUser user, Book book)
        {
            var borrowing = new Borrowing();
            borrowing.SetBorrower(user);
            borrowing.SetBook(book);
            await CreateAsync(borrowing);
        }

        public async Task<IEnumerable<Borrowing>> GetAllAsync()
            => await Task.FromResult(_context.Borrowings);

        public async Task<Borrowing> GetAsync(int id)
            => await _context.Borrowings.SingleOrDefaultAsync(m => m.Id == id);

        public async Task RemoveAsync(int id)
        {
            var borrowing = await GetAsync(id);
            _context.Borrowings.Remove(borrowing);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrowing borrowing)
        {
            _context.Update(borrowing);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> BorrowingExists(int id)
            => await Task.FromResult(_context.Borrowings.Any(e => e.Id == id));
    }
}
