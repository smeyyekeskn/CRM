using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface ICustomerService
    {
        void Insert(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
        void Delete(Guid id);
        Customer Find(Guid id);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> GetAllByName(string name);
        IEnumerable<Customer> Search(string name);
    }
}
