using CRM.Data;
using CRM.Model;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service 
{
    public class ProductService: IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }
        public void Delete(Product entity)
        {
            productRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var product = productRepository.Find(id);
            if (product != null)
            {
                this.Delete(product);
            }
        }
        public Product Find(Guid id)
        {
            return productRepository.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product Find(Expression<Func<Product, bool>> where)
        {
            return productRepository.Find(where);
        }

        public IEnumerable<Product> GetAllByName(string name)
        {
            return productRepository.GetAll(w => w.Name.Contains(name));
        }

        public void Insert(Product entity)
        {
            productRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Product> Search(string name)
        {
            return productRepository.GetAll(e => e.Name.Contains(name));
        }

        public void Update(Product entity)
        {
            var product = productRepository.Find(entity.Id);
            product.Name = entity.Name;
            product.CategoryId = entity.CategoryId;
            product.Customers = entity.Customers;
            product.Offers = entity.Offers;
            product.Description = entity.Description;
            product.SerialNumber = entity.SerialNumber;
            product.Stock = entity.Stock;
            product.BuyingPrice = entity.BuyingPrice;

            productRepository.Update(product);
            unitOfWork.SaveChanges();
        }
    }
}
