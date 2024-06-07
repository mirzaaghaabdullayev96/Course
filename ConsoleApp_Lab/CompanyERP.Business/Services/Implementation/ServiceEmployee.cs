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
    public class ServiceEmployee : IServiceEmployee
    {
        public void Create(Employee Employee)
        {
            Database<Employee>.listOFT.Add(Employee);
            Console.WriteLine(Employee.Name + " was created successufully");
        }

        public List<Employee> GetAll()
        {
            return Database<Employee>.listOFT;
        }

        public Employee GetById(int id)
        {
            Employee? wantedEmployee = Database<Employee>.listOFT.Find(x => x.Id == id);
            if (wantedEmployee is null)
            {
                throw new NullReferenceException("Employee by this ID was not found");
            }
            return wantedEmployee;
        }

        public void Remove(int id)
        {
            IServiceDepartment serviceDepartment = new ServiceDepartment();
            Employee? wantedEmployee = Database<Employee>.listOFT.Find(x => x.Id == id);
           
            if (wantedEmployee is null)
            {
                throw new NullReferenceException("Employee by this ID was not found");
            }

            foreach (Department department in serviceDepartment.GetAll())
            {
                if (department.Employees.Contains(wantedEmployee))
                {
                    department.initial -= wantedEmployee.Salary;
                    department.Employees.Remove(wantedEmployee);
                }
            }

            Database<Employee>.listOFT.Remove(wantedEmployee);
        }
    }
}
