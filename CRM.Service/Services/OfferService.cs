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
    public class OfferService: IOfferService
    {
        private readonly IRepository<Offer> offerRepository;
        private readonly IUnitOfWork unitOfWork;
        public OfferService(IUnitOfWork unitOfWork, IRepository<Offer> offerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.offerRepository = offerRepository;
        }
        public void Delete(Offer entity)
        {
            offerRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var offer = offerRepository.Find(id);
            if (offer != null)
            {
                this.Delete(offer);
            }
        }
        public Offer Find(Guid id)
        {
            return offerRepository.Find(id);
        }

        public IEnumerable<Offer> GetAll()
        {
            return offerRepository.GetAll();
        }


        public void Insert(Offer entity)
        {
            offerRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }


        public void Update(Offer entity)
        {
            var offer = offerRepository.Find(entity.Id);
            offer.Amount = entity.Amount;
            offer.CustomerId = entity.CustomerId;
            offer.Description = entity.Description;
            offer.EmployeeId = entity.EmployeeId;
            offer.Products = entity.Products;
            offerRepository.Update(offer);
            unitOfWork.SaveChanges();
        }
    }
}
