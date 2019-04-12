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
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly IOfferItemService offerItemService;

        public OfferController(IOfferService offerService, ICustomerService customerService, IProductService productService, IOfferItemService offerItemService)
        {
            this.offerService = offerService;
            this.productService = productService;
            this.customerService = customerService;
            this.offerItemService = offerItemService;

        }
        // GET: Order
        public ActionResult Index()
        {
            var offers = offerService.GetAll();
            return View(offers);
        }
        public ActionResult Create()
        {
            ViewBag.Products = productService.GetAll();
            ViewBag.Customers = customerService.GetAll();

            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var offers = offerItemService.GetMany(d => d.OfferId == id);

            foreach (var item in offers)
            {
                offerItemService.Delete(item);
            }

            offerService.Delete(id);

            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(offerItemService.GetMany(g => g.OfferId == id));
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
        public JsonResult AddOffer(IList<OfferItemViewModel> offerItemViewModels, string tc)
        {
            try
            {
                var customerId = customerService.Find(c => c.IdentityNumber == tc).Id;


                var productList = new List<Product>();
                var newOffer = new Offer();
                offerService.Insert(newOffer);

                foreach (var product in offerItemViewModels)
                {
                    var pr = productService.Find(p => p.SerialNumber == product.SerialNumber);

                    var newOfferItem = new OfferItem()
                    {
                        SerialNumber = pr.SerialNumber,
                        ProductName = pr.Name,
                        OfferPrice = product.OfferPrice,
                        Quantity = product.Quantity,
                        Stock = pr.Stock,
                        RegisterRequiredDate = product.RegisterRequiredDate,
                        ProductId = pr.Id,
                        CustomerId = customerId,
                        OfferId = newOffer.Id
                    };

                    offerItemService.Insert(newOfferItem);

                }


                return Json("success");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}