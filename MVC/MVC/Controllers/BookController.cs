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
        public BookController()
        {

        }

        // GET: Book
        public IActionResult Index()
        {
              return View();
        }
        // GET: Book/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            Book_ViewModel book_ViewModel = new Book_ViewModel();
            return View(book_ViewModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("Book_ID,Title,Author,price")] Book_ViewModel book_ViewModel)
        {

            if (ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(Index));
            }
            return View(book_ViewModel);
        }

        // GET: Book/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {  
            return RedirectToAction(nameof(Index));
        }
    }
}
