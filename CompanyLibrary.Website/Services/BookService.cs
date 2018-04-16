using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyLibrary.Website.Data;
using CompanyLibrary.Website.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyLibrary.Website.Services
{
    public class BookService : IBookService
    {
        private readonly CompanyLibraryDbContext _context;

        public BookService(CompanyLibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Book book)
        {
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Book book, ApplicationUser user)
        {
            book.SetAddedBy(user);
            await CreateAsync(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
            => await Task.FromResult(_context.Books);

        public async Task<Book> GetAsync(int id)
            => await _context.Books.SingleOrDefaultAsync(m => m.Id == id);

        public async Task RemoveAsync(int id)
        {
            var book = await GetAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> BookExists(int id)
            => await Task.FromResult(_context.Books.Any(e => e.Id == id));
    }
}
