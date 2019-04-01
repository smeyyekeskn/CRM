using CRM.Model;
using CRM.Service.Services.Interfaces;
using CRM.UI.ViewModel;
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
            var orders = orderService.GetAll().Select(o => new OrderViewModel
            {
                Id = o.Id,
                FullName = o.Customer.FirstName + " " + o.Customer.LastName,
                RequiredDate = o.RequiredDate,
                SellingPrice = o.Total

            }).Distinct().ToList();
            return View(orders);
        }
        public ActionResult Create()
        {
            ViewBag.Products = productService.GetAll();
            ViewBag.Customers = customerService.GetAll();

            return View();
        }
        public JsonResult GetCustomer(string tc)
        {
            List<Customer> results = new List<Customer>();

            results.Add(customerService.Find(c => c.IdentityNumber == tc));

            var results2 = results.Select(x => new { x.Address, x.FirstName, x.LastName, x.IdentityNumber }).ToList();
            return Json(results2, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult AddOrder(IList<Product> products, string tc)
        {
            var customerId = customerService.Find(c => c.IdentityNumber == tc).Id;
            Guid orderNumber = Guid.NewGuid();

            
            var list = new List<Product>();
            foreach (var product in products)
            {
                list.Add(productService.Find(p => p.SerialNumber == product.SerialNumber));
            }

             
            var newOrders = new Order()
            {
                SerialNumber = order.SerialNumber,
                ProductName = order.ProductName,
                Stock = order.Stock,
                Quantity = order.Quantity,
                SellingPrice = order.SellingPrice,
                CustomerId = customerId,
                OrderNumber = orderNumber,
                Products = list
            };

            orderService.Insert(newOrders);


            return Json("success");
        }
    }
}
