using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface IOrderItemService
    {
        void Insert(OrderItem entity);//
        void Update(OrderItem entity);//
        void Delete(OrderItem entity);//
        void Delete(Guid id);//


        OrderItem Find(Guid id);
        OrderItem Find(Expression<Func<OrderItem, bool>> where);


        IEnumerable<OrderItem> GetAll();
        IEnumerable<OrderItem> GetAllByName(string name);
        IEnumerable<OrderItem> GetMany(Expression<Func<OrderItem, bool>> where);
        IEnumerable<OrderItem> Search(string name);//
    }
}
