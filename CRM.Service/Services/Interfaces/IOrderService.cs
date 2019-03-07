using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface IOrderService
    {
        void Insert(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        void Delete(Guid id);
        Order Find(Guid id);
        IEnumerable<Order> GetAll();
    }
}
