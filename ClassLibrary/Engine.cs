using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
     public class Engine : ISparePart
    {
        public string Type { get; }
        public decimal Price { get; }
        public int Stock { get; set; }
        public int TimeToChangePart { get; } = 25;

        public Engine(string type, decimal price, int stock)
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
