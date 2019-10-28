using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class JuniorWorker : Employee
    {
        public override decimal Workspeed { get; set; }

        public JuniorWorker(string name, decimal hourlyWage, int skillLevel)
        {
            Name = name;
            HourlyWage = hourlyWage;
            SkillLevel = skillLevel;
            IsWorking = false;
            Workspeed = 1;
        }
    }
}
