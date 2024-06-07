using CompanyERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Services.Interfaces
{
    public interface IServiceDepartment
    {
        void Create(Department department);
        void Remove(int id);
        List<Department> GetAll();
        Department GetById(int id);
        
    }
}
