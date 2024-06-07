using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyERP.Core.Models
{
    public class Employee
    {
        private static int _counter;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; } //in years
        public bool HasBachelorDegree { get; set; }

        public Employee()
        {
            Id = ++_counter;
        }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Surname} - {Salary} - {Experience} and {(HasBachelorDegree is true ? "has bachelor degree" : "does not have bachelor degree")}\n";
        }
    }
}
