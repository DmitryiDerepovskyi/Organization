using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Orgainzation.Web.Models;
using Organization.Contract.BusinessLogic;
using Organization.Core;

namespace Orgainzation.Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IManager<Equipment> _manager;
        protected virtual IEnumerable<Department> Departments { get; set; }
     
        public EquipmentController(IManager<Equipment> manager, 
            IManager<Department> managerDepartment)
        {
            _manager = manager;
            Departments = managerDepartment.GetAll();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Equipment>, IEnumerable<EquipmentViewModel>>(_manager.GetAll()));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.Departments = Departments;
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(EquipmentViewModel equipmentViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.Departments = Departments;
                    return View(equipmentViewModel);
                }
                _manager.Add(Mapper.Map<EquipmentViewModel, Equipment>(equipmentViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Departments = Departments;
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = Departments;
            return View(Mapper.Map<Equipment, EquipmentViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EquipmentViewModel equipmentViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.Departments = Departments;
                    return View(equipmentViewModel);
                }
                _manager.Update(Mapper.Map<EquipmentViewModel, Equipment>(equipmentViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Departments = Departments;
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Equipment, EquipmentViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EquipmentViewModel equipmentViewModel)
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
