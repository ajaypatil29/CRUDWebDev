using CRUDapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDapp.Controllers
{
    public class BookController : Controller
    {
        BookCRUD Crud;
        private readonly IConfiguration configuration;
        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            Crud = new BookCRUD (configuration);
        }

        public ActionResult Index()
        {
            var list = Crud.GetAllBook();
            return View(list);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = Crud.GetbookBYID(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result = Crud.AddBook(book);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = Crud.GetbookBYID(id);
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book )
        {
            try
            {
                int result = Crud.updatebook(book);
                if (result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {

            var book = Crud.GetbookBYID(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = Crud.deleteBook(id);
                     if (result == 1)
                return RedirectToAction(nameof(Index));
                     else
                    return View();
                    
            }
            catch
            {
                return View();
            }
        }
    }
}
