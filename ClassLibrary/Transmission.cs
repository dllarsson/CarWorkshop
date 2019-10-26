using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Transmission : ISparePart
    {
        public string Type { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; set; }

        public Transmission(string type, decimal price, int stock)
        {
            Type = type;
            Price = price;
            Stock = stock;
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
