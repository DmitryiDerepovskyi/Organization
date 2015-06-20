using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Orgainzation.Web.Models;
using Organization.Contract.BusinessLogic;
using Organization.Core;

namespace Orgainzation.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IManager<Customer> _manager;

        public CustomerController(IManager<Customer> manager)
        {
            _manager = manager;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(_manager.GetAll()));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid) return View(customerViewModel);
                _manager.Add(Mapper.Map<CustomerViewModel,Customer>(customerViewModel));
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
            return View(Mapper.Map<Customer, CustomerViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerViewModel customerViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid) return View(customerViewModel);
                _manager.Update(Mapper.Map<CustomerViewModel, Customer>(customerViewModel));
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
            return View(Mapper.Map<Customer, CustomerViewModel>(_manager.GetByPrimaryKey(id)));
        }

        // POST: Customer/Delete/5
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
    }
}
