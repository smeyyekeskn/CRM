using CRM.Model;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = productService.GetAll();
            return View(products);
        }
        public ActionResult Create()
        {
            var product = new Product();
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Insert(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var product = productService.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var model = productService.Find(product.Id);
                model.Name = product.Name;
                model.OfferItems = product.OfferItems;
                model.OrderItems = product.OrderItems;
                model.SerialNumber = product.SerialNumber;
                model.Stock = product.Stock;
                model.CategoryId = product.CategoryId;
                model.BuyingPrice = product.BuyingPrice;
                model.Customers = product.Customers;
                model.Description = product.Description;

                productService.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(categoryService.GetAll(), "Id", "Name", product.CategoryId);
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            return View(productService.Find(id));
        }
































    }
}