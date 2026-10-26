using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Data;
using Library.Core.ServiceInterface;
using Library.Core.Dto;

namespace Library.Controllers
{
        public class BookController : Controller
        {

            private readonly IBookServices _bookServices;
            private readonly LibraryContext _context;
            public BookController
                (
                IBookServices bookServices,
                LibraryContext context
                )
            {
                _bookServices = bookServices;
                _context = context;
            }

            public IActionResult Index()
            {
            var books = _context.Books.ToList();
            var result = books.Select(x => new BookIndexViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    PublishedYear = x.PublishedYear,
                    IsAvailable = x.IsAvailable
                }).ToList();



                return View(result);
            }

            [HttpGet]
            public IActionResult Create()
            {
                BookCreateViewModel vm = new();

                return View(vm);
            }
           
            [HttpPost]
            public async Task<IActionResult> Create(BookCreateViewModel vm)
            {
                if (ModelState.IsValid)
                {
                    var dto = new BookDto
                    {
                        Id = vm.Id,
                        Title = vm.Title,
                        Author = vm.Author,
                        PublishedYear = vm.PublishedYear,
                        IsAvailable = vm.IsAvailable
                    };



                    var result = await _bookServices.Create(dto);

                    return RedirectToAction(nameof(Index));
                }
                return View(vm);
            }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var vm = new BookDeleteViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishedYear = book.PublishedYear,
                IsAvailable = book.IsAvailable
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var result = await _bookServices.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var vm = new BookUpdateViewModel();
            {
                vm.Id = book.Id;
                vm.Title = book.Title;

                return View(vm);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateViewModel vm)
        {
            var dto = new BookDto()
            {
                Id = vm.Id,
                Title = vm.Title
            };

            var result = await _bookServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
