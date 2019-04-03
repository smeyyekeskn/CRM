using CRM.Data;
using CRM.Model;
using CRM.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderItemService(IUnitOfWork unitOfWork, IRepository<OrderItem> orderItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderItemRepository = orderItemRepository;
        }
        public void Delete(OrderItem entity)
        {
            orderItemRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var orderItem = orderItemRepository.Find(id);
            if (orderItem != null)
            {
                this.Delete(orderItem);
            }
        }
        public OrderItem Find(Guid id)
        {
            return orderItemRepository.Find(id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return orderItemRepository.GetAll();
        }

        public OrderItem Find(Expression<Func<OrderItem, bool>> where)
        {
            return orderItemRepository.Find(where);
        }

        public IEnumerable<OrderItem> GetAllByName(string name)
        {
            return orderItemRepository.GetAll(w => w.ProductName.Contains(name));
        }

        public void Insert(OrderItem entity)
        {
            orderItemRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<OrderItem> Search(string name)
        {
            return orderItemRepository.GetAll(e => e.ProductName.Contains(name));
        }

        public void Update(OrderItem entity)
        {
            var orderItem = orderItemRepository.Find(entity.Id);
            orderItem.SerialNumber = entity.SerialNumber;
            orderItem.Quantity = entity.Quantity;
            orderItem.SellingPrice = entity.SellingPrice;
            orderItem.Stock = entity.Stock;
            orderItem.ProductName = entity.ProductName;
            orderItem.OrderNumber = entity.OrderNumber;
            orderItem.ProductId = entity.ProductId;
            orderItem.CustomerId = entity.CustomerId;
            orderItem.OrderId = entity.OrderId;

            orderItemRepository.Update(orderItem);
            unitOfWork.SaveChanges();
            unitOfWork.SaveChanges();
        }
    }
}
