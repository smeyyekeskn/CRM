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
    public class OrderService: IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
        }
        public void Delete(Order entity)
        {
            orderRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var order = orderRepository.Find(id);
            if (order != null)
            {
                this.Delete(order);
            }
        }
        public Order Find(Guid id)
        {
            return orderRepository.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }


        public void Insert(Order entity)
        {
            orderRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }


        public void Update(Order entity)
        {
            var order = orderRepository.Find(entity.Id);
            order.OrderItems = entity.OrderItems;
            orderRepository.Update(order);
            unitOfWork.SaveChanges();
        }
    }
}
