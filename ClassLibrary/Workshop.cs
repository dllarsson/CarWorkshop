using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Workshop
    {
        public Dictionary<string, ISparePart> SpareParts = new Dictionary<string, ISparePart>();
        public List<Employee> employees = new List<Employee>();
        public List<Customer> customers = new List<Customer>();

        private int count = 0;

        public void AddSparePart(string key)
        {
            ISparePart sparePart;
            if (key == "engine")
            {
                var stock = 1;
                if (SpareParts.ContainsKey("engine"))
                {
                    SpareParts["engine"].IncreaseStock();
                }
                else
                {
                    sparePart = new Engine("engine", 3000, stock);
                    SpareParts.Add(key, sparePart);
                }


            }
            else if (key == "transmission")
            {
                var stock = 1;
                if (SpareParts.ContainsKey("transmission"))
                {
                    SpareParts["transmission"].IncreaseStock();
                }
                else
                {
                    sparePart = new Transmission("transmission", 2300, stock);
                    SpareParts.Add(key, sparePart);
                }


            }
            else if (key == "wheel")
            {
                var stock = 1;
                if (SpareParts.ContainsKey("wheel"))
                {
                    SpareParts["wheel"].IncreaseStock();
                }
                else
                {
                    sparePart = new Wheel("wheel", 2300, stock);
                    SpareParts.Add(key, sparePart);
                }

            }
        }

        public int GetStockOfSparePart(string key)
        {
            if (SpareParts.ContainsKey(key))
            {
                return SpareParts[key].Stock;
            }
            else
            {
                return -1;
            }
        }

        public void RemoveSparePart(string key)
        {
            if (SpareParts.ContainsKey(key))
            {
                if (SpareParts[key].Stock == 0)
                {
                    SpareParts.Remove(key);
                }
                SpareParts[key].DecreaseStock();
            }

        }

        public decimal GetPriceOfSparePart(string key)
        {
            if (SpareParts.ContainsKey(key))
            {
                return SpareParts[key].Price;
            }
            else
            {
                return -1;
            }
        }

        public void RepairVehicle(Customer c, Employee e)
        {
            decimal priceOfRepair = 0;
            while (c.Vehicle.BrokenParts.Count > 0)
            {
                priceOfRepair += GetPriceOfSparePart(c.Vehicle.BrokenParts[0].Type);
                SpareParts[c.Vehicle.BrokenParts[0].Type].DecreaseStock();
                c.Vehicle.BrokenParts.RemoveAt(0);
            }
            priceOfRepair += CalculateRepairTime(c) * e.HourlyWage;

            c.Invoice = new Invoice(priceOfRepair);
            
        }

        public int CalculateRepairTime(Customer c)
        {
            int repairTime = 0;
            foreach (var item in c.Vehicle.BrokenParts)
            {
                repairTime += item.TimeToChangePart;
            }
            return repairTime;
        }

        public bool ReparingVehicle(Customer c, Employee e, int repairTime)
        {
            if (count != repairTime)
            {
                count++;
                e.StateSet(e.Name + " is working. " + "Total cost of repair: " + e.HourlyWage * count);
                return false;
            }
            else
            {
                count = 0;
                return true;
            }

        }

        public void HandInCarToShop(Customer c,string key)
        {
            
            c.Vehicle.BrokenParts.Add(SpareParts[key]);
            customers.Add(c);
        }
        public void HandInCarToShop(Customer c, string key, string key2)
        {
            c.Vehicle.BrokenParts.Add(SpareParts[key]);
            c.Vehicle.BrokenParts.Add(SpareParts[key2]);
            customers.Add(c);
        }
        public void HandInCarToShop(Customer c, string key, string key2, string key3)
        {
            c.Vehicle.BrokenParts.Add(SpareParts[key]);
            c.Vehicle.BrokenParts.Add(SpareParts[key2]);
            c.Vehicle.BrokenParts.Add(SpareParts[key3]);

            customers.Add(c);
        }


    }
}
