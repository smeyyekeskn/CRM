using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IEmployeeService employeeService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        public HomeController(IOrderService orderService, IEmployeeService employeeService, ICustomerService customerService, IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.customerService = customerService;
            this.employeeService = employeeService;
        }
        public ActionResult Index()
        {
            ViewBag.OrderCount = orderService.GetAll().Count();
            ViewBag.ProductCount = productService.GetAll().Sum(p=>p.Stock);
            ViewBag.CustomerCount = customerService.GetAll().Count();
            ViewBag.EmployeeCount = employeeService.GetAll().Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}