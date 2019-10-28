using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class JuniorWorker : Employee
    {
        public override decimal Workspeed { get; set; }
        public override string Title { get; set; }

        public JuniorWorker(string name, decimal hourlyWage, int skillLevel)
        {
            Title = "Junior worker";
            Name = name;
            HourlyWage = hourlyWage;
            SkillLevel = skillLevel;
            IsWorking = false;
            Workspeed = 1;
        }

    }
}
