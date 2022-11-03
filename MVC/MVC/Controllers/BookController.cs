using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly MVCContext _context;

        public BookController(MVCContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
              return View(await _context.Book_ViewModel.ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book_ViewModel == null)
            {
                return NotFound();
            }

            var book_ViewModel = await _context.Book_ViewModel
                .FirstOrDefaultAsync(m => m.Book_ID == id);
            if (book_ViewModel == null)
            {
                return NotFound();
            }

            return View(book_ViewModel);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Book_ID,Title,Author,price")] Book_ViewModel book_ViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book_ViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book_ViewModel);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book_ViewModel == null)
            {
                return NotFound();
            }

            var book_ViewModel = await _context.Book_ViewModel.FindAsync(id);
            if (book_ViewModel == null)
            {
                return NotFound();
            }
            return View(book_ViewModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Book_ID,Title,Author,price")] Book_ViewModel book_ViewModel)
        {
            if (id != book_ViewModel.Book_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book_ViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Book_ViewModelExists(book_ViewModel.Book_ID))
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
            return View(book_ViewModel);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book_ViewModel == null)
            {
                return NotFound();
            }

            var book_ViewModel = await _context.Book_ViewModel
                .FirstOrDefaultAsync(m => m.Book_ID == id);
            if (book_ViewModel == null)
            {
                return NotFound();
            }

            return View(book_ViewModel);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book_ViewModel == null)
            {
                return Problem("Entity set 'MVCContext.Book_ViewModel'  is null.");
            }
            var book_ViewModel = await _context.Book_ViewModel.FindAsync(id);
            if (book_ViewModel != null)
            {
                _context.Book_ViewModel.Remove(book_ViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Book_ViewModelExists(int id)
        {
          return _context.Book_ViewModel.Any(e => e.Book_ID == id);
        }
    }
}
