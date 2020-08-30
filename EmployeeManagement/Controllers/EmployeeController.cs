using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private MockEmployee _employee;
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            _employee = new MockEmployee();
            var model = _employee.GetEmployeeList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee model)
        {
            _employee = new MockEmployee();

            _employee.InsertEmployee(model);
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {
            _employee = new MockEmployee();

            var model = _employee.GetEmployeeById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Employee model) {
            _employee = new MockEmployee();

            _employee.UpdateEmp(model);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            _employee = new MockEmployee();

            _employee.DeleteEmp(id);
            return RedirectToAction("List");
        }
    }
}