using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Customer
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public Customer(int id, Vehicle vehicle)
        {
            ID = id;
            Vehicle = vehicle;
        }

        public Customer(int id, Vehicle vehicle, ISparePart brokenPart, ISparePart brokenPartTwo)
        {
            ID = id;
            Vehicle = vehicle;
            Vehicle.BrokenParts.Add(brokenPart);
            Vehicle.BrokenParts.Add(brokenPartTwo);
        }
        public Customer(int id, Vehicle vehicle, ISparePart brokenPart, ISparePart brokenPartTwo, ISparePart brokenPartThree)
        {
            ID = id;
            Vehicle = vehicle;
            Vehicle.BrokenParts.Add(brokenPart);
            Vehicle.BrokenParts.Add(brokenPartTwo);
            Vehicle.BrokenParts.Add(brokenPartThree);
        }
    }
}
