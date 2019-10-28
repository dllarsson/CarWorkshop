using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Workshop
    {
        public Dictionary<string, SparePart> SpareParts = new Dictionary<string, SparePart>();
        public List<Employee> Empolyees = new List<Employee>();
        public List<Customer> Customers = new List<Customer>();
        public Dictionary<Customer, Invoice> Invoices = new Dictionary<Customer, Invoice>();
        public List<WorkItem> WorkItems = new List<WorkItem>();
        public int AvaibleWorkers { get; set; } = 3;


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
            AvaibleWorkers++;

            for (int i = 0; i < WorkItems.Count; i++)
            {
                if (workItem == WorkItems[i])
                {
                    WorkItems.RemoveAt(i);
                }
            }
            LookForWork(e);
        }

        public string LookForHelp(Employee e)
        {
            foreach (var employee in Empolyees)
            {
                if (!employee.IsWorking)
                {
                    ((Intern)e).NeedHelp = false;
                    return " asking " + employee.Name + " for help.";
                }
            }
                    return "Nobody is free to help!";
        }

        public void LookForWork(Employee e)
        {
            if(WorkItems.Count > 0)
            {
                foreach (var item in WorkItems.ToList())
                {
                    if (item.Employee == null)
                    {
                        item.Employee = e;
                        item.Employee.IsWorking = true;
                        AvaibleWorkers--;
                        break;
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
            Customer c = new Customer(Customers.Count + 1, customerName);
            Customers.Add(c);
            Vehicle v = new Vehicle(manufacturer, modelYear, liecensePlate, brokenParts);

            WorkItem workItem = new WorkItem(this, GetEmployeeForWork(v), v, CalculateRepairTime(v), c, WorkItems.Count + 1, GetPriceOfAllSpareParts(v));
            WorkItems.Add(workItem);
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
            for (int i = 0; i < Empolyees.Count; i++)
            {
                if (Empolyees[i].SkillLevel >= lowestSkillLevel)
                {
                    if (Empolyees[i].IsWorking != true)
                    {
                        e = Empolyees[i];
                        e.IsWorking = true;
                        AvaibleWorkers--;
                        break;
                    }

                }
            }
            return e;
        }


    }
}
