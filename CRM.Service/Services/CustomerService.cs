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
    public class CustomerService:ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> customerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.customerRepository = customerRepository;
        }
        public void Delete(Customer entity)
        {
            customerRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var customer = customerRepository.Find(id);
            if (customer != null)
            {
                this.Delete(customer);
            }
        }
        public Customer Find(Guid id)
        {
            return customerRepository.Find(id);
        }

        public Customer Find(Expression<Func<Customer, bool>> where)
        {
            return customerRepository.Find(where);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public IEnumerable<Customer> GetAllByName(string name)
        {
            return customerRepository.GetAll(w => w.FirstName.Contains(name));
        }

        public void Insert(Customer entity)
        {
            customerRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Customer> Search(string name)
        {
            return customerRepository.GetAll(e => e.FirstName.Contains(name));
        }

        public void Update(Customer entity)
        {
            var customer = customerRepository.Find(entity.Id);
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.IdentityNumber = entity.IdentityNumber;
            customer.Offers = entity.Offers;
            customer.Phone = entity.Phone;
            customer.RegionId = entity.RegionId;
            customer.Email = entity.Email;
            customer.Birthdate = entity.Birthdate;
            customer.Address = entity.Address;
            customer.Products = entity.Products;
            customer.Status = entity.Status;
            customerRepository.Update(customer);
            unitOfWork.SaveChanges();
        }
    }
}
