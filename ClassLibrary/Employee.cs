using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class Employee
    {
        public string Name { get;  set; }
        public decimal HourlyWage { get;  set; }
        public int WorkDone { get;  set; }
        public int WorkTotal { get;  set; }
        public bool IsWorking { get; set; }
        public string State { get;  set; }
        public int SkillLevel { get;  set; }
        public abstract decimal Workspeed { get; set; }

        public void StateSet(string state)
        {
            State = state;
        }
    }
}
