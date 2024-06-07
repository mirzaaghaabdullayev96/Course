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
    public static class Controller
    {
        public static void AddingEmployee(this Department department, Employee employee)
        {
            if (department.Employees.Contains(employee))
            {
                Console.WriteLine($"This employee is already working in {department.Name}");
                return;
            }
            if (department.Budget < department.initial + employee.Salary)
            {
                Console.WriteLine($"Budget is exceeded so {employee.Name} was not added to {department.Name}");
                department.initial += employee.Salary;
                return;
            }
            if (department.EmployeeLimit < department.Employees.Count() + 1)
            {
                Console.WriteLine("Employee limit is exceeded so {employee.Name} was not added to {department.Name}");
                return;
            }
            if (department.IsBachelorDegreeRequired is true && employee.HasBachelorDegree is not true)
            {
                Console.WriteLine($"{employee.Name} does not have bachelor degree so {employee.Name} was not added to {department.Name}");
                return;
            }
            if (department.RequiredExperience > employee.Experience)
            {
                Console.WriteLine($"{employee.Name} does not have enough experience so {employee.Name} was not added to {department.Name}");
                return;
            }

            department.Employees.Add(employee);
            Console.WriteLine($"{employee.Name} was added to {department.Name} successfully");
        }

        public static void ShowAllEmployeesInfo()
        {
            IServiceEmployee serviceEmployee = new ServiceEmployee();
            foreach(Employee employee in serviceEmployee.GetAll())
            {
                Console.WriteLine(employee);
            }
        }

        public static void ShowAllDepartmentsInfo()
        {
            IServiceDepartment serviceDepartment = new ServiceDepartment();
            foreach (Department department in serviceDepartment.GetAll())
            {
                Console.WriteLine(department);
            }
        }
    }
}
