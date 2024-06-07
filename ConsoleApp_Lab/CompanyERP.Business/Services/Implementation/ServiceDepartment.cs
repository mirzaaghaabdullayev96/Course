using CompanyERP.Business.Services.Interfaces;
using CompanyERP.Core.Models;
using CompanyERP.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Services.Implementation
{
    public class ServiceDepartment : IServiceDepartment
    {

        public void Create(Department department)
        {
            Database<Department>.listOFT.Add(department);
            Console.WriteLine(department.Name + " was created successufully");
        }

        public List<Department> GetAll()
        {
            return Database<Department>.listOFT;
        }

        public Department GetById(int id)
        {
            Department? wantedDepartment = Database<Department>.listOFT.Find(x => x.Id == id);
            if (wantedDepartment is null)
            {
                throw new NullReferenceException("Department by this ID was not found");
            }
            return wantedDepartment;
        }

        public void Remove(int id)
        {
            Department? wantedDepartment = Database<Department>.listOFT.Find(x => x.Id == id);
            if (wantedDepartment is null)
            {
                throw new NullReferenceException("Department by this ID was not found");
            }
            Database<Department>.listOFT.Remove(wantedDepartment);
        }
        
    }
}
