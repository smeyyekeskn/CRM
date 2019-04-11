using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface IOfferItemService
    {
        void Insert(OfferItem entity);
        void Update(OfferItem entity);
        void Delete(OfferItem entity);
        void Delete(Guid id);
        OfferItem Find(Guid id);
        OfferItem Find(Expression<Func<OfferItem, bool>> where);
        IEnumerable<OfferItem> GetMany(Expression<Func<OfferItem, bool>> where);
        IEnumerable<OfferItem> GetAll();
    }
}
