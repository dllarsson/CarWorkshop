using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Workshop
    {
        public Dictionary<string, SparePart> SpareParts = new Dictionary<string, SparePart>();
        public List<Employee> employees = new List<Employee>();
        public List<Customer> customers = new List<Customer>();
        public Dictionary<Customer, Invoice> Invoices = new Dictionary<Customer, Invoice>();
        public Dictionary<string, (Vehicle, Customer)> Vehicles = new Dictionary<string, (Vehicle, Customer)>();
        public List<WorkItem> workItems = new List<WorkItem>();


        public void AddSparePart(string key, int stock, int timeToChangePart, decimal price, int skillLevelRequiredToChangePart)
        {
            SparePart sparePart = new SparePart(key, stock, timeToChangePart, price, skillLevelRequiredToChangePart);
            SpareParts.Add(key, sparePart);
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

        public void RepairCompleted(Vehicle v, Customer c, Employee e, WorkItem workItem)
        {
            while (v.BrokenParts.Count > 0)
            {
                SpareParts[v.BrokenParts[0].Type].DecreaseStock();
                v.BrokenParts.RemoveAt(0);
            }

            
            e.IsWorking = false;

            for (int i = 0; i < workItems.Count; i++)
            {
                if (workItem == workItems[i])
                {
                    workItems.RemoveAt(i);
                }
            }
            LookForWork(e);
        }

        public void LookForWork(Employee e)
        {
            if(workItems.Count > 0)
            {
                foreach (var item in workItems.ToList())
                {
                    if (item.Employee == null)
                    {
                        item.Employee = e;
                    }
                }
            }
        }

        public int CalculateRepairTime(Vehicle v)
        {
            int repairTime = 0;
            foreach (var item in v.BrokenParts)
            {
                repairTime += item.TimeToChangePart;
            }
            return repairTime;
        }



        public void HandInCarToShop(string customerName, string manufacturer, int modelYear, string liecensePlate, List<SparePart> brokenParts)
        {
            Customer c = new Customer(customers.Count + 1, customerName);
            customers.Add(c);
            Vehicle v = new Vehicle(manufacturer, modelYear, liecensePlate, brokenParts);

            WorkItem workItem = new WorkItem(this, GetEmployeeForWork(v), v, CalculateRepairTime(v), c, workItems.Count + 1, GetPriceOfAllSpareParts(v));
            workItems.Add(workItem);
            Vehicles.Add(liecensePlate.ToUpper(), (v, c));
        }

        public decimal GetPriceOfAllSpareParts(Vehicle v)
        {
            decimal price = 0;
            foreach (var item in v.BrokenParts)
            {
                price += item.Price;
            }
            return price;
        }

        public Employee GetEmployeeForWork(Vehicle v)
        {
            Employee e = null;
            var lowestSkillLevel = 0;
            for (int i = 0; i < v.BrokenParts.Count; i++)
            {
                if (v.BrokenParts[i].SkillLevelRequiredToChangePart > lowestSkillLevel)
                {
                    lowestSkillLevel = v.BrokenParts[i].SkillLevelRequiredToChangePart;
                }
            }
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].SkillLevel >= lowestSkillLevel)
                {
                    if (employees[i].IsWorking != true)
                    {
                        e = employees[i];
                        e.IsWorking = true;
                        break;
                    }

                }
            }
            return e;
        }


    }
}
