using CRM.Model;
using CRM.Service;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IRegionService regionService;
        public CustomerController(ICustomerService customerService, IRegionService regionService)
        {
            this.customerService = customerService;
            this.regionService = regionService;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers=customerService.GetAll();
            return View(customers);
        }
        public ActionResult Create()
        {
            var customer = new Customer();
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", customer.RegionId);
            return View(customer);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {   
                customerService.Insert(customer);
                return RedirectToAction("Index");
            }
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", customer.RegionId);
            return View(customer);
        }
        public ActionResult Edit(Guid id)
        {

            var customer = customerService.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", customer.RegionId);
            return View(customer);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var model = customerService.Find(customer.Id);
                model.IdentityNumber = customer.IdentityNumber;
                model.FirstName = customer.FirstName;
                model.LastName = customer.LastName;
                model.OfferItems = customer.OfferItems;
                model.Phone = customer.Phone;
                model.Products = customer.Products;
                model.RegionId = customer.RegionId;
                model.Status = customer.Status;
                model.Email = customer.Email;
                model.Birthdate = customer.Birthdate;
                model.Address = customer.Address;
                customerService.Update(model);

                return RedirectToAction("Index");
            }
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", customer.RegionId);
            return View();            
        }
        public ActionResult Delete(Guid id)
        {
            customerService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(customerService.Find(id));
        }



    }
}