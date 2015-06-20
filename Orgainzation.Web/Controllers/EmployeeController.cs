using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Orgainzation.Web.Models;
using Organization.Contract.BusinessLogic;
using Organization.Core;

namespace Orgainzation.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IManager<Employee> _manager;
        private readonly ILogic _logic;
        protected virtual IEnumerable<Department> Departments { get; set; }
        
        public EmployeeController(IManager<Employee> manager, IManager<Department> managerDepartment, ILogic logic)
        {
            _manager = manager;
            _logic = logic;
            Departments = managerDepartment.GetAll();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(Mapper.Map <IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(_manager.GetAll()));
        }


        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.Departments = Departments;
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.Departments = Departments;
                    return View(employeeViewModel);
                }
                _manager.Add(Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Departments = Departments;
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = Departments;
            return View(Mapper.Map<Employee, EmployeeViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeViewModel employeeViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                     ViewBag.Departments = Departments;
                    return View(employeeViewModel);
                }
                _manager.Update(Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                 ViewBag.Departments = Departments;
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Employee, EmployeeViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeViewModel employeeViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                _manager.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CountAverageSalary()
        {
            return PartialView(_logic.AverageSalary());
        }
    }
}
