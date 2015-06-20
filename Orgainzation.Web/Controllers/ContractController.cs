using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AutoMapper;
using Orgainzation.Web.Models;
using Organization.BusinessLogic;
using Organization.Contract.BusinessLogic;
using Organization.Core;

namespace Orgainzation.Web.Controllers
{
    public class ContractController : Controller
    {
        private readonly IManager<Contract> _manager;
        protected virtual IEnumerable<Department> Departments { get; set; }
        protected virtual IEnumerable<Customer> Customers { get; set; }
        private readonly ILogic _logic;
        public ContractController(IManager<Contract> manager,
            IManager<Department> managerDepartment,
            IManager<Customer> managerCustomer, ILogic logic)
        {
            _manager = manager;
            _logic = logic;
            Departments = managerDepartment.GetAll();
            Customers = managerCustomer.GetAll();
        }

        // GET: Contract
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Contract>, IEnumerable<ContractViewModel>>(_manager.GetAll()));
        }

        // GET: Contract/Create
        public ActionResult Create()
        {
            ViewBag.Departments = Departments;
            ViewBag.Customers = Customers;
            return View();
        }

        // POST: Contract/Create
        [HttpPost]
        public ActionResult Create(ContractViewModel contractViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.Departments = Departments;
                    ViewBag.Customers = Customers;
                    return View(contractViewModel);
                }
                _manager.Add(Mapper.Map<ContractViewModel, Contract>(contractViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Departments = Departments;
                ViewBag.Customers = Customers;
                return View();
            }
        }

        // GET: Contract/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = Departments;
            ViewBag.Customers = Customers;
            return View(Mapper.Map<Contract, ContractViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Contract/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContractViewModel contractViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.Departments = Departments;
                    ViewBag.Customers = Customers;
                    return View(contractViewModel);
                }
                _manager.Update(Mapper.Map<ContractViewModel, Contract>(contractViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Departments = Departments;
                ViewBag.Customers = Customers;
                return View();
            }
        }

        // GET: Contract/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<Contract, ContractViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Contract/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerViewModel customerViewModel)
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
        public ActionResult CountTotalPrice()
        {
            return PartialView(_logic.TotalPriceContract());
        }
    }
}
