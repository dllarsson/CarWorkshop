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
        public decimal BrokenPartCosts{ get; private set; }

        public WorkItem(Workshop ws, Employee employee, Vehicle vehicle, int goal, Customer customer, int id, decimal brokenPartCosts)
        {
            WorkDone = 1;
            ID = id;
            BrokenPartCosts = brokenPartCosts;
            WS = ws;
            Employee = employee;
            Vehicle = vehicle;
            Customer = customer;
            Goal = goal;
        }
        public void DoWork(bool stuck)
        {
            if (WorkDone < Goal)
            {
                if (this.Employee != null)
                {
                    TimePassed++;
                    WorkDone += Employee.Workspeed;
                    CurrentCost = TimePassed * Employee.HourlyWage;
                }
                

            }
            else
            {
                Invoice invoice = new Invoice((CurrentCost + BrokenPartCosts), this.Employee.Name, CurrentCost, BrokenPartCosts);
                Invoice = invoice;
                WS.Invoices.Add(this.Customer, invoice);
                Vehicle.IsRepaired = true;
                WS.RepairCompleted(Vehicle, Customer, Employee, this);

            }
        }
        public string GetStatus()
        {
            if (this.Employee != null)
            {
                return Employee.Name + " is working of car: " + Vehicle.LicensePlate +
       " Progress: " + WorkDone + " / " + Goal +
       " Work costs: " + CurrentCost;

            }
            return Vehicle.LicensePlate +  "... no workers avaible right now.";


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
