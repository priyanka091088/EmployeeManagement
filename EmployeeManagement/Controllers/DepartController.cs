using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartController : Controller
    {
        private MockDepartment _department;
        // GET: Depart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            _department = new MockDepartment();
            var model = _department.GetAllDepartment();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Depart model)
        {
            _department = new MockDepartment();

            _department.InsertDepartment(model);
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {
            _department = new MockDepartment();

            var model = _department.GetDepartById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Depart model)
        {
            _department = new MockDepartment();

            _department.UpdateDepartment(model);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            _department = new MockDepartment();

            _department.DeleteDepartment(id);
            return RedirectToAction("List");
        }
    }
}