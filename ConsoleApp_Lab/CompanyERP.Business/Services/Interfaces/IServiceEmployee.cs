using CompanyERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Services.Interfaces
{
    public interface IServiceEmployee
    {
        void Create(Employee employee);
        void Remove(int id);
        List<Employee> GetAll();
        Employee GetById(int id);
        
    }
}
