using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Employee
    {
        public string Name { get; }
        public decimal HourlyWage { get; }

        public Employee(string name, decimal hourlyWage)
        {
            Name = name;
            HourlyWage = hourlyWage;
        }
    }
}
