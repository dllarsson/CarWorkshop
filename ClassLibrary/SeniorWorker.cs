using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class SeniorWorker : Employee
    {
        public override decimal Workspeed { get; set; }
        public SeniorWorker(string name, decimal hourlyWage, int skillLevel)
        {
            Name = name;
            HourlyWage = hourlyWage;
            SkillLevel = skillLevel;
            IsWorking = false;
            Workspeed = 2;
            
        }
    }
}
