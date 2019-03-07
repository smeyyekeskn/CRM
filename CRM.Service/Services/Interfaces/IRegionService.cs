using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface IRegionService
    {
        void Insert(Region entity);
        void Update(Region entity);
        void Delete(Region entity);
        void Delete(Guid id);
        Region Find(Guid id);
        IEnumerable<Region> GetAll();
        IEnumerable<Region> GetAllByName(string name);
        IEnumerable<Region> Search(string name);
    }
}
