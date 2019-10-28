using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Customer
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public decimal Balance { get; private set; }

        public Customer(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                return this.ID == ((Customer)obj).ID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
