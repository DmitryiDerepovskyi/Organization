using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Orgainzation.Web.Models;
using Organization.Contract.BusinessLogic;
using Organization.Core;

namespace Orgainzation.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IManager<Department> _manager;

        public DepartmentController(IManager<Department> manager)
        {
            _manager = manager;
        }
        // GET: Department
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(_manager.GetAll()));
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel departmentViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid) return View(departmentViewModel);
                _manager.Add(Mapper.Map<DepartmentViewModel, Department>(departmentViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medcine/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Department, DepartmentViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Medcine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentViewModel departmentViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(departmentViewModel);
                _manager.Update(Mapper.Map<DepartmentViewModel,Department>(departmentViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Department, DepartmentViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DepartmentViewModel departmentViewModel)
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
    }
}
