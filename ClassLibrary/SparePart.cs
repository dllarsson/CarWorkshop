using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class SparePart
    {
        public string Type { get; private set; }
        public int Stock { get; private set; }
        public int TimeToChangePart { get; private set; }
        public decimal Price { get; private set; }
        public int SkillLevelRequiredToChangePart { get; private set; }


        public SparePart(string type, int stock, int timeToChangePart, decimal price, int skillLevelRequiredToChangePart)
        {
            Price = price;
            Type = type;
            Stock = stock;
            TimeToChangePart = timeToChangePart;
            SkillLevelRequiredToChangePart = skillLevelRequiredToChangePart;
        }

        public void IncreaseStock()
        {
            Stock++;
        }
        public void DecreaseStock()
        {
            Stock--;
        }
    }
}
