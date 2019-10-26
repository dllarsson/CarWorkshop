using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Wheel : ISparePart
    {
        public string Type { get; }
        public decimal Price { get; }
        public int Stock { get; set; }

        public Wheel(string type, decimal price, int stock)
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
