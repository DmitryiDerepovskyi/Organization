using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Orgainzation.Web.Models;
using Organization.Contract.BusinessLogic;
using Organization.Core;

namespace Orgainzation.Web.Controllers
{
    public class EquipmentContractController : Controller
    {
        private readonly IManager<EquipmentContract> _manager;
        private readonly IManager<Equipment> _managerEquipment;
        private readonly IManager<Contract> _managerContract;

        public EquipmentContractController(IManager<EquipmentContract> manager, 
            IManager<Contract> managerContract, 
            IManager<Equipment> managerEquipment)
        {
            _manager = manager;
            _managerContract = managerContract;
            _managerEquipment = managerEquipment;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<EquipmentContract>, 
                IEnumerable<EquipmentContractViewModel>>(_manager.GetAll()));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(EquipmentContractViewModel equipmentContractViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid) return View(equipmentContractViewModel);
                _manager.Add(Mapper.Map<EquipmentContractViewModel, EquipmentContract>(equipmentContractViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<EquipmentContract, EquipmentContractViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EquipmentContractViewModel equipmentContractViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid) return View(equipmentContractViewModel);
                _manager.Update(Mapper.Map<EquipmentContractViewModel, EquipmentContract>(equipmentContractViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<EquipmentContract, EquipmentContractViewModel>(_manager.GetByPrimaryKey(id)));
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
