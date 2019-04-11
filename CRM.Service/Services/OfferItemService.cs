using CRM.Data;
using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public class OfferItemService:IOfferItemService
    {

        private readonly IRepository<OfferItem> offerItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public OfferItemService(IUnitOfWork unitOfWork, IRepository<OfferItem> offerItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.offerItemRepository = offerItemRepository;
        }
        public void Delete(OfferItem entity)
        {
            offerItemRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var offerItem = offerItemRepository.Find(id);
            if (offerItem != null)
            {
                this.Delete(offerItem);
            }
        }
        public OfferItem Find(Guid id)
        {
            return offerItemRepository.Find(id);
        }

        public IEnumerable<OfferItem> GetAll()
        {
            return offerItemRepository.GetAll();
        }

        public OfferItem Find(Expression<Func<OfferItem, bool>> where)
        {
            return offerItemRepository.Find(where);
        }

        public IEnumerable<OfferItem> GetMany(Expression<Func<OfferItem, bool>> where)
        {
            return offerItemRepository.GetMany(where);
        }

        public void Insert(OfferItem entity)
        {
            offerItemRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public void Update(OfferItem entity)
        {
            var offerItem = offerItemRepository.Find(entity.Id);
            offerItem.SerialNumber = entity.SerialNumber;
            offerItem.Quantity = entity.Quantity;
            offerItem.OfferPrice = entity.OfferPrice;
            offerItem.Stock = entity.Stock;
            offerItem.ProductName = entity.ProductName;
            offerItem.ProductId = entity.ProductId;
            offerItem.CustomerId = entity.CustomerId;
            offerItem.OfferId = entity.OfferId;
            
            offerItemRepository.Update(offerItem);
            unitOfWork.SaveChanges();
        }
    }
}

