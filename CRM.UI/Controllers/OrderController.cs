using CRM.Model;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;

        public OrderController(IOrderService orderService, ICustomerService customerService, IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.customerService = customerService;

        }
        // GET: Order
        public ActionResult Index()
        {
            var orders = orderService.GetAll();
            return View(orders);
        }
        public ActionResult Create()
        {
            ViewBag.Products = productService.GetAll();
            ViewBag.Customers=customerService.GetAll();

            return View();
        }
        public JsonResult GetCustomer(string tc)
        {
            List<Customer> results = new List<Customer>();
         
                results.Add(customerService.Find(c => c.IdentityNumber == tc));

            var results2 = results.Select(x => new { x.Address, x.FirstName, x.LastName, x.IdentityNumber}).ToList();
            return Json(results2,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProduct(List<string> serialNumber)
        {
            List<Product> results = new List<Product>();

            foreach (var item in serialNumber)
            {
                results.Add(productService.Find(c => c.SerialNumber == item));
            }

            var results2 = results.Select(x => new { x.SerialNumber, x.Name, x.Stock, x.BuyingPrice }).ToList();
            return Json(results2, JsonRequestBehavior.AllowGet);
        }
    }
}