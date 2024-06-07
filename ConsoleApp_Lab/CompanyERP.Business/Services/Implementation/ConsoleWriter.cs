using CompanyERP.Business.Services.Interfaces;
using CompanyERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Business.Services.Implementation
{
    public static class ConsoleWriter
    {
        public static void Start()
        {
            bool flag = true;

            while (flag)
            {
                Choices();

                Console.WriteLine("Select opration number by writing it");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {

                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        AddDepartment();
                        break;
                    case 3:
                        DeleteEmployee();
                        break;
                    case 4:
                        DeleteDepartment();
                        break;
                    case 5:
                        AddEmployeeToDepartment();
                        break;
                    case 6:
                        Controller.ShowAllEmployeesInfo();
                        break;
                    case 7:
                        Controller.ShowAllDepartmentsInfo();
                        break;
                    case 8:
                        flag = false;
                        break;
                    default: break;
                }
            }

        }


        public static void Choices()
        {
            Console.WriteLine("""
                1. Add Employee
                2. Add Department
                3. Delete Employee
                4. Delete Department
                5. Add Employee to Department
                6. Show All Employees Info
                7. Show All Departments Info
                8. Quit
                """);
        }

        public static void AddEmployee()
        {
            IServiceEmployee serviceEmployee = new ServiceEmployee();
            Console.WriteLine("Enter name of the employee");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname of the employee");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter salary of the employee");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter experience of the employee in years");
            int experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Does employee has degree. Type Yes or No");
            string degree = Console.ReadLine();
            Console.WriteLine();
            bool hasDegree = true;
            if (degree == "Yes")
                hasDegree = true;
            if (degree == "No")
                hasDegree = false;

            serviceEmployee.Create(new Employee() { Name = name, Surname = surname, Salary = salary, Experience = experience, HasBachelorDegree = hasDegree });
            Console.WriteLine();
        }

        public static void AddDepartment()
        {
            IServiceDepartment serviceDepartment = new ServiceDepartment();
            Console.WriteLine("Enter name of the department");
            string name = Console.ReadLine();
            Console.WriteLine("Enter budget of the company");
            int budget = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee limit of the department");
            int employeeLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter required experience of the department in years");
            int experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Does department require bachelor degree? Type Yes or No");
            string degree = Console.ReadLine();
            Console.WriteLine();
            bool requiresDegree = true;
            if (degree == "Yes")
                requiresDegree = true;
            if (degree == "No")
                requiresDegree = false;

            serviceDepartment.Create(new Department() { Name = name, Budget = budget, EmployeeLimit = employeeLimit, RequiredExperience = experience, IsBachelorDegreeRequired = requiresDegree });
            Console.WriteLine();
        }

        public static void DeleteEmployee()
        {
            Controller.ShowAllEmployeesInfo();
            Console.WriteLine("Which employee would you like to delete? Write ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            IServiceEmployee serviceEmployee = new ServiceEmployee();
            Console.WriteLine($"{serviceEmployee.GetById(id).Name} was deleted successfully");
            serviceEmployee.Remove(id);
            IServiceDepartment serviceDepartment = new ServiceDepartment();
           
        }

        public static void DeleteDepartment()
        {
            Controller.ShowAllDepartmentsInfo();
            Console.WriteLine("Which Department would you like to delete? Write ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            IServiceDepartment serviceDepartment = new ServiceDepartment();
            Console.WriteLine($"{serviceDepartment.GetById(id).Name} was deleted successfully");
            serviceDepartment.Remove(id);
        }

        public static void AddEmployeeToDepartment()
        {
            IServiceEmployee serviceEmployee = new ServiceEmployee();
            IServiceDepartment serviceDepartment = new ServiceDepartment();
            Console.WriteLine("Which employee would you like to add?");
            Controller.ShowAllEmployeesInfo();
            int employeeChoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("To which department would you like to add?");
            Controller.ShowAllDepartmentsInfo();
            int departamentChoice = Convert.ToInt32(Console.ReadLine());
            serviceDepartment.GetById(departamentChoice).AddingEmployee(serviceEmployee.GetById(employeeChoice));
        }

    }


}
