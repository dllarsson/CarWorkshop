using ClassLibrary;
using ConsoleSimulationEngine2000;
using System;
using System.Collections.Generic;
using System.Linq;
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
            gui.TargetUpdateTime = 700;
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
            stockDisplay.Value = "";
            if (ws.workItems.Count > 0)
            {
                foreach (var item in ws.workItems.ToList())
                {
                    if (!item.Vehicle.IsRepaired)
                    {
                        item.DoWork();
                        if (item.Vehicle.IsRepaired)
                        {
                            log.Log(item.Invoice.Total + " price of parts: " + item.Invoice.PriceOfParts +
                            " price of work: " + item.Invoice.PriceOfWork);
                        }
                        log.Log(item.GetStatus());
                    }
                    else
                    {
                       
                    }
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
                List<SparePart> spareParts = new List<SparePart>();
                spareParts.Add(ws.SpareParts["transmission"]);
                spareParts.Add(ws.SpareParts["wheel"]);
                spareParts.Add(ws.SpareParts["engine"]);
                ws.HandInCarToShop("Johan", "Saab", 2007, "abc123", spareParts);
            }
            else if (command == "2")
            {
                List<SparePart> spareParts = new List<SparePart>();
                spareParts.Add(ws.SpareParts["door"]);
                spareParts.Add(ws.SpareParts["wheel"]);
                spareParts.Add(ws.SpareParts["muffler"]);
                ws.HandInCarToShop("Erik", "Volvo", 2007, "hej321", spareParts);
            }
            else if (command == "3")
            {
                List<SparePart> spareParts = new List<SparePart>();
                spareParts.Add(ws.SpareParts["wheel"]);
                ws.HandInCarToShop("Hello", "Volvo", 2007, "aaa333", spareParts);
            }
        }
    }
}
