using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDapp.Models;

namespace CRUDapp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeCRUD CRUD;
        private readonly IConfiguration configuration;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            CRUD = new EmployeeCRUD(configuration);
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var List = CRUD.GetAllEmployee();
            return View(List);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var emp = CRUD.GetEmployeById(id);
            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = CRUD.AddEmployee(emp);
                if(result==1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = CRUD.GetEmployeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = CRUD.UpdateEmployee(emp);
                if(result==1)
                return RedirectToAction(nameof(Index));
                else 
                    return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = CRUD.GetEmployeById(id);
            return View(emp);
            
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = CRUD.DeleteEmployee (id);
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
