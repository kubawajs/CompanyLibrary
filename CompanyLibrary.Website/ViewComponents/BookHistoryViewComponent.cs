using CompanyLibrary.Website.Models;
using CompanyLibrary.Website.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyLibrary.Website.ViewComponents
{
    public class BookHistoryViewComponent : ViewComponent
    {
        private readonly IBorrowingService _borrowingService;

        public BookHistoryViewComponent(IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Book book)
        {
            var bookHistory = await _borrowingService.GetAllByBookAsync(book);
            return View(bookHistory);
        }
    }
}
