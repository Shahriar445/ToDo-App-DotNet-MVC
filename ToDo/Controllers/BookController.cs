using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers;
public class BookController : Controller
{
   

        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        #region Create
        // Displays the form to create a new book
        public IActionResult Create()
        {
            return View();
        }

        // Handles the HTTP POST request to create a new book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
        #endregion

        #region Details
        // Displays details of a specific book
        public IActionResult Details(int id)
        {
            if (id == null || _context.Books == null)
            {
                return RedirectToAction("Index");
            }
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        #endregion

        #region Edit
        // Displays the form to edit a specific book
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return RedirectToAction("Index");
            }
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Handles the HTTP POST request to edit a specific book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        // Displays a confirmation page for deleting a specific book
        public IActionResult Delete(int id)
        {
            if (id == null || _context.Books == null)
            {
                return RedirectToAction("Index");
            }
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Handles the HTTP POST request to delete a specific book
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
