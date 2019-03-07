using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface IProductService 
    {
        void Insert(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        void Delete(Guid id);
        Product Find(Guid id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllByName(string name);
        IEnumerable<Product> Search(string name);
    }
}
