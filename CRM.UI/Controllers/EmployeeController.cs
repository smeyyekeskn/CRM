using CRM.Model;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IRegionService regionService;
        public EmployeeController(IEmployeeService employeeService, IRegionService regionService)
        {
            this.employeeService = employeeService;
            this.regionService = regionService;

        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = employeeService.GetAll();
            return View(employees);
        }
        public ActionResult Create()
        {
            var employee = new Employee();
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", employee.RegionId);
            return View(employee);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeService.Insert(employee);
                return RedirectToAction("Index");
            }
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", employee.RegionId);
            return View(employee);
        }
        public ActionResult Edit(Guid id)
        {
            var employee = employeeService.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", employee.RegionId);
            return View(employee);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var model = employeeService.Find(employee.Id);
                model.FirstName = employee.FirstName;
                model.LastName = employee.LastName;
                model.Offers = employee.Offers;
                model.Phone = employee.Phone;
                model.RegionId = employee.RegionId;
                model.IdentityNumber = employee.IdentityNumber;
                model.Email = employee.Email;
                model.Birthdate = employee.Birthdate;
                model.Address = employee.Address;
                model.Status = employee.Status;

                employeeService.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.Regions = new SelectList(regionService.GetAll(), "Id", "Name", employee.RegionId);
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            employeeService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details (Guid id)
        {
            return View(employeeService.Find(id));
        }
    }
}