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
    public class EmployeeService: IEmployeeService
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork, IRepository<Employee> employeeRepository)
        {
            this.unitOfWork = unitOfWork;
            this.employeeRepository = employeeRepository;
        }
        public void Delete(Employee entity)
        {
            employeeRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var employee = employeeRepository.Find(id);
            if (employee != null)
            {
                this.Delete(employee);
            }
        }
        public Employee Find(Guid id)
        {
            return employeeRepository.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public IEnumerable<Employee> GetAllByName(string name)
        {
            return employeeRepository.GetAll(w => w.FirstName.Contains(name));
        }

        public void Insert(Employee entity)
        {
            employeeRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Employee> Search(string name)
        {
            return employeeRepository.GetAll(e => e.FirstName.Contains(name));
        }

        public void Update(Employee entity)
        {
            var employee = employeeRepository.Find(entity.Id);
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.IdentityNumber = entity.IdentityNumber;
            employee.OfferItems = entity.OfferItems;
            employee.Phone = entity.Phone;
            employee.RegionId = entity.RegionId;
            employee.Email = entity.Email;
            employee.Birthdate = entity.Birthdate;
            employee.Address = entity.Address;
            employee.UserType = entity.UserType;
            employeeRepository.Update(employee);
            unitOfWork.SaveChanges();
        }
    }
}
