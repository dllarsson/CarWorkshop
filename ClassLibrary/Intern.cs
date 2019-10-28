using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Intern : Employee
    {
        public override decimal Workspeed { get; set; }
        public bool NeedHelp { get; set; }
        public override string Title { get; set; }

        public Intern(string name, decimal hourlyWage, int skillLevel)
        {
            Title = "Intern";
            Name = name;
            HourlyWage = hourlyWage;
            SkillLevel = skillLevel;
            IsWorking = false;
            Workspeed = 0.3m;
        }
    }
}
