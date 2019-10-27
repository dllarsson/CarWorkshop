using ClassLibrary;
using ConsoleSimulationEngine2000;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWorkshopConsole
{
    public class MySimulation : Simulation
    {
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 20, 3) { };
        private RollingDisplay menuDisplay = new RollingDisplay(0, 14, 50, 10) { };
        private BorderedDisplay stockDisplay = new BorderedDisplay(65, 14, 50, 3);
        private readonly ConsoleGUI gui;
        private readonly TextInput input;

        private bool IsUnderRepair = false;

        StringBuilder sr = new StringBuilder();
        Workshop ws = new Workshop();
        WorkshopGenerator wsg = new WorkshopGenerator();

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
        log,
        clockDisplay,
        menuDisplay,
        stockDisplay,
        input.CreateDisplay(0, -3, -1) };

        public MySimulation(ConsoleGUI gui, TextInput input)
        {
            gui.TargetUpdateTime = 500;
            wsg.GenerateEmpoyees(ws);
            wsg.GenerateStock(ws);
            this.gui = gui;
            this.input = input;
            menuDisplay.Log("Welcome to the workshop!");
            menuDisplay.Log("Type 1 to hand in a car");
            menuDisplay.Log("Type 2 to hand in a motorcycle");
        }
        public override void PassTime(int deltaTime)
        {
            clockDisplay.Value = DateTime.Now.ToString("HH:mm:ss");
            stockDisplay.Value = "Engines: " + ws.SpareParts["engine"].Stock.ToString() +
                " Transmissions: " + ws.SpareParts["transmission"].Stock.ToString() +
                " Wheels: " + ws.SpareParts["wheel"].Stock.ToString();
            if (IsUnderRepair)
            {
                
               if(ws.ReparingVehicle(ws.customers[0], ws.employees[0], ws.CalculateRepairTime(ws.customers[0])))
                {
                    ws.RepairVehicle(ws.customers[0], ws.employees[0]);
                    log.Log("Repair complete. Total cost of repair: " + ws.customers[0].Invoice.Total + " Name Of customer: " +
                        ws.customers[0].ID);
                    IsUnderRepair = false;
                }
                else
                {
                    log.Log(ws.employees[0].State);
                }
            }

            while (input.HasInput)
            {
                var command = input.Consume();
                log.Log("Input: " + command);
                HandleCommand(command);
                
            }
        }
        public void HandleCommand(string command)
        {
            if (command == "1") //Hand in new car to workShop
            {
                Car c = new Car();
                Customer customer = new Customer(1, c);

                ws.customers.Add(customer);

                ws.HandInCarToShop(customer, "transmission", "wheel", "wheel");

                IsUnderRepair = true;
                

            }
            else if (command == "2")
            {

            }
            else if (command == "3")
            {

            }
        }
    }
}
