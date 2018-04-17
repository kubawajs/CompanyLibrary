using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyLibrary.Website.Data;
using CompanyLibrary.Website.Models;
using Microsoft.AspNetCore.Authorization;
using CompanyLibrary.Website.Services;

namespace CompanyLibrary.Website.Controllers
{
    public class BorrowingsController : Controller
    {
        private readonly IBorrowingService _borrowingService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IBookService _bookService;

        public BorrowingsController(IBorrowingService borrowingService,
            IApplicationUserService applicationUserService,
            IBookService bookService)
        {
            _borrowingService = borrowingService;
            _applicationUserService = applicationUserService;
            _bookService = bookService;
        }

        // GET: Borrowings
        public async Task<IActionResult> Index()
            => View(await _borrowingService.GetAllAsync());

        // GET: Borrowings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _borrowingService.GetAsync(id.Value);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        // GET: Borrowings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Borrowings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Borrower, Book")] Borrowing borrowing)
        {
            if (ModelState.IsValid)
            {
                await _borrowingService.CreateAsync(borrowing);
                return RedirectToAction(nameof(Index));
            }
            return View(borrowing);
        }

        // GET: Borrowings/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _borrowingService.GetAsync(id.Value);
            if (borrowing == null)
            {
                return NotFound();
            }
            return View(borrowing);
        }

        // POST: Borrowings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentalDate")] Borrowing borrowing)
        {
            if (id != borrowing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _borrowingService.UpdateAsync(borrowing);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await BorrowingExists(borrowing.Id)))
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
            return View(borrowing);
        }

        // GET: Borrowings/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _borrowingService.GetAsync(id.Value);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        // POST: Borrowings/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _borrowingService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


        // GET: Borrowings/Borrow
        [Authorize]
        public async Task<IActionResult> Borrow(int id)
        {
            var user = await _applicationUserService.GetCurrentUserAsync(HttpContext);
            var book = await _bookService.GetAsync(id);

            if(book.Availability == Availability.NotAvailable)
            {
                //TODO: Add view
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _borrowingService.CreateAsync(user, book);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }


        private async Task<bool> BorrowingExists(int id)
            => await _borrowingService.BorrowingExists(id);
    }
}
