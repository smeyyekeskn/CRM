using CRM.Model;
using CRM.Service.Services.Interfaces;
using CRM.UI.Models;
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
        private readonly IOrderItemService orderItemService;

        public OrderController(IOrderService orderService, ICustomerService customerService, IProductService productService, IOrderItemService orderItemService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.customerService = customerService;
            this.orderItemService = orderItemService;

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
        public JsonResult AddOrder(IList<OrderItemViewModel> orderItemViewModels, string tc)
        {
            var customerId = customerService.Find(c => c.IdentityNumber == tc).Id;
            Guid orderNumber = Guid.NewGuid();


            var productList = new List<Product>();
            var newOrder = new Order();
            orderService.Insert(newOrder);

            foreach (var product in orderItemViewModels)
            {
                var pr = productService.Find(p => p.SerialNumber == product.SerialNumber);

                var newOrderItem = new OrderItem()
                {
                    SerialNumber = pr.SerialNumber,
                    ProductName = pr.Name,
                    SellingPrice = product.SellingPrice,
                    Quantity = product.Quantity,
                    Stock = pr.Stock,
                    ProductId = pr.Id,
                    CustomerId = customerId,
                    OrderId = newOrder.Id
                };

                orderItemService.Insert(newOrderItem);
                var proUp = productService.Find(p => p.SerialNumber == product.SerialNumber);
                proUp.Stock -= product.Quantity;
                productService.Update(proUp);

            }




            //var newOrders = new Order()
            //{
            //    SerialNumber = order.SerialNumber,
            //    ProductName = order.ProductName,
            //    Stock = order.Stock,
            //    Quantity = order.Quantity,
            //    SellingPrice = order.SellingPrice,
            //    CustomerId = customerId,
            //    OrderNumber = orderNumber,
            //    Products = list
            //};

            //orderService.Insert(newOrders);


            return Json("success");
        }
    }
}
