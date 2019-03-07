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
    public class RegionService: IRegionService
    {
        private readonly IRepository<Region> regionRepository;
        private readonly IUnitOfWork unitOfWork;
        public RegionService(IUnitOfWork unitOfWork, IRepository<Region> regionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.regionRepository = regionRepository;
        }
        public void Delete(Region entity)
        {
            regionRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var region = regionRepository.Find(id);
            if (region != null)
            {
                this.Delete(region);
            }
        }
        public Region Find(Guid id)
        {
            return regionRepository.Find(id);
        }

        public IEnumerable<Region> GetAll()
        {
            return regionRepository.GetAll();
        }

        public IEnumerable<Region> GetAllByName(string name)
        {
            return regionRepository.GetAll(w => w.Name.Contains(name));
        }

        public void Insert(Region entity)
        {
            regionRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Region> Search(string name)
        {
            return regionRepository.GetAll(e => e.Name.Contains(name));
        }

        public void Update(Region entity)
        {
            var region = regionRepository.Find(entity.Id);
            region.Name = entity.Name;
            region.Employees = entity.Employees;
            region.Customers = entity.Customers;
            regionRepository.Update(region);
            unitOfWork.SaveChanges();
        }
    }
}
