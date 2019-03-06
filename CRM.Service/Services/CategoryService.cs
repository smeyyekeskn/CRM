using CRM.Data;
using CRM.Model;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
        }
        public void Delete(Category entity)
        {
            categoryRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var category = categoryRepository.Find(id);
            if (category != null)
            {
                this.Delete(category);
            }
        }
        public Category Find(Guid id)
        {
            return categoryRepository.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAllByName(string name)
        {
            return categoryRepository.GetAll(w => w.Name.Contains(name));
        }

        public void Insert(Category entity)
        {
            categoryRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Category> Search(string name)
        {
            return categoryRepository.GetAll(e => e.Name.Contains(name));
        }

        public void Update(Category entity)
        {
            var category = categoryRepository.Find(entity.Id);
            category.Name = entity.Name;
            category.ProductId = entity.ProductId;
            categoryRepository.Update(category);
            unitOfWork.SaveChanges();
        }
    }
}
