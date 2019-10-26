using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Customer
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public Vehicle Vehicle { get; set; }

        public Customer(int id, string name, Vehicle vehicle)
        {
            ID = id;
            Name = name;
            Vehicle = vehicle;
        }
    }
}
