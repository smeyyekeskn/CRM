using CRM.Model;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;

        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }
        public ActionResult Create()
        {
            var category = new Category();
            return View(category);           
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Insert(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public ActionResult Edit(Guid id)
        {
            var category = categoryService.Find(id);
            return View(category);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var model = categoryService.Find(category.Id);
                model.Name = category.Name;
                model.Products = category.Products;
                categoryService.Update(model);

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(categoryService.Find(id));
        }
    }
}