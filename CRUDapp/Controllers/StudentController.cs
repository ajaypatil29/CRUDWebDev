using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDapp.Models;

namespace CRUDapp.Controllers
{
    public class StudentController : Controller
    {
        StudentCRUD CRUD;
        private readonly IConfiguration configuration;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            CRUD = new StudentCRUD(configuration);
        }
        public ActionResult Index()
        {
            var List=CRUD.GetAllStudent();
            return View(List);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var std = CRUD.GetStudentById(id);
            return View(std);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            try
            {
                int result = CRUD.AddStudent(std);
                if(result == 1) 
                return RedirectToAction(nameof(Index));
                else
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var std=CRUD.GetStudentById(id);
            return View(std);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student std)
        {
            try
            {
                int result = CRUD.UpdateStudent(std);
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var std= CRUD.GetStudentById(id);
            return View(std);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result=CRUD.DeleteStudent(id);
                if(result == 1)
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
