using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Employee
    {
        public string Name { get; }
        public decimal HourlyWage { get; }
        public int WorkDone { get; private set; }
        public int WorkTotal { get; }
        public bool IsDoneWithWork { get; private set; }
        public string State { get; private set; }

        public Employee(string name, decimal hourlyWage)
        {
            Name = name;
            HourlyWage = hourlyWage;
        }


        public void StateSet(string state)
        {
            State = state;
        }
    }
}
