using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface IOfferService
    {
        void Insert(Offer entity);
        void Update(Offer entity);
        void Delete(Offer entity);
        void Delete(Guid id);
        Offer Find(Guid id);
        IEnumerable<Offer> GetAll();
    }
}
