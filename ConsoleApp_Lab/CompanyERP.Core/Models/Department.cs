using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Core.Models
{
    public class Department
    {
        private static int _count;
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeLimit { get; set; }
        public int Budget { get; set; }
        public int RequiredExperience { get; set; } //in years
        public bool IsBachelorDegreeRequired { get; set; }
        public List<Employee> Employees { get; set; }
        public double initial;
        public Department()
        {
            Id = ++_count;
            Employees = [];
            initial = 0;
        }


        public override string ToString()
        {
            return $"{Id} - {Name} - {EmployeeLimit} - Budget: {Budget} - Require expereince in years: {RequiredExperience} and bachelor degree {(IsBachelorDegreeRequired is true ? "is required" : "is not required")} and has {(Employees != null && Employees.Count > 0
        ? "\nEmployees:\n" + string.Join("\n", Employees.Select(e => $"- {e.Name}"))
        : "no worker")}\n";
        }
    }
}
