using CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        void Insert(Employee entity);
        void Update(Employee entity);
        void Delete(Employee entity);
        void Delete(Guid id);
        Employee Find(Guid id);
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetAllByName(string name);
        IEnumerable<Employee> Search(string name);
    }
}
