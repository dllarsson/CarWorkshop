using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class SeniorWorker : Employee
    {
        public override decimal Workspeed { get; set; }
        public override string Title { get; set; }
        public SeniorWorker(string name, decimal hourlyWage, int skillLevel)
        {
            Title = "Senior worker";
            Name = name;
            HourlyWage = hourlyWage;
            SkillLevel = skillLevel;
            IsWorking = false;
            Workspeed = 2;
            
        }
    }
}
