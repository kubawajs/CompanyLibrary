using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyLibrary.Website.Data;
using CompanyLibrary.Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CompanyLibrary.Website.Services;

namespace CompanyLibrary.Website.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IApplicationUserService _applicationUserService;


        public BooksController(IBookService bookService, IApplicationUserService applicationUserService)
        {
            _bookService = bookService;
            _applicationUserService = applicationUserService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
            => View(await _bookService.GetAllAsync());

        // GET: Books/MyBooks
        public async Task<IActionResult> MyBooks()
        {
            var user = await _applicationUserService.GetCurrentUserAsync(HttpContext);
            return View(await _bookService.GetAllByUserAsync(user));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Books/Borrow
        [Authorize]
        public IActionResult Borrow(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("Borrow", "Borrowings",
                new
                {
                    Id = id.Value,
                });
        }

        // GET: Books/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                var user = await _applicationUserService.GetCurrentUserAsync(HttpContext);
                await _bookService.CreateAsync(book, user);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Author,Description")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.UpdateAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await BookExists(book.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // TODO: Only creator of book can delete it
            var book = await _bookService.GetAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExists(int id)
            => await _bookService.BookExists(id);
    }
}
