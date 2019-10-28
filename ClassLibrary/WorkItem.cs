using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class WorkItem
    {
        public decimal WorkDone { get; private set; }
        public int TimePassed { get; private set; }
        public int Goal { get; private set; }
        public decimal CurrentCost { get; set; }
        public Workshop WS { get; }
        public Employee Employee { get; set; }
        public Vehicle Vehicle { get; private set; }
        public Invoice Invoice { get; set; }
        public Customer Customer { get; set; }
        public int ID { get; set; }
        public decimal BrokenPartCosts { get; private set; }

        public Random Random { get; set; }

        public WorkItem(Workshop ws, Employee employee, Vehicle vehicle, int goal, Customer customer, int id, decimal brokenPartCosts)
        {
            Random = new Random();
            WorkDone = 1;
            ID = id;
            BrokenPartCosts = brokenPartCosts;
            WS = ws;
            Employee = employee;
            Vehicle = vehicle;
            Customer = customer;
            Goal = goal;
        }
        public string DoWork()
        {
            if (Employee is Intern)
            {
                var number = Random.Next(10);
                if (((Intern)Employee).NeedHelp)
                {
                    Employee.StateSet(Employee.Name + " is stuck and need help! " + WS.LookForHelp(Employee));
                    return Employee.State;
                }
                if (number == 0)
                {
                    ((Intern)Employee).NeedHelp = true;
                }
            }
            if (WorkDone < Goal)
            {
                if (this.Employee != null)
                {
                    TimePassed++;
                    WorkDone += Employee.Workspeed;
                    CurrentCost = TimePassed * Employee.HourlyWage;
                    return Employee.Name + "(" + Employee.Title + ")" + " is working." + GetStatus();

                }
                else
                {
                    return "No workers are avaible right now";

                }
            }
            else
            {
                Invoice invoice = new Invoice((CurrentCost + BrokenPartCosts), this.Employee.Name, CurrentCost, BrokenPartCosts);
                Invoice = invoice;
                WS.Invoices.Add(this.Customer, invoice);
                Vehicle.IsRepaired = true;
                WS.RepairCompleted(Vehicle, Customer, Employee, this);
                return Employee.Name + " is done with work.";

            }
        }
        public string GetStatus()
        {
            if (this.Employee != null)
            {
                return " Vehile: " + Vehicle.LicensePlate.ToUpper() +
                             " Progress: " + WorkDone + " / " + Goal +
                             " Work costs: " + CurrentCost;

            }
            return Vehicle.LicensePlate + "... no workers avaible right now.";


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
