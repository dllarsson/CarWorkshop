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
        private BorderedDisplay ammountOfWorkItems = new BorderedDisplay(0, 11, 100, 3) { };
        private BorderedDisplay workers = new BorderedDisplay(0, 14, 100, 3) { };

        private BorderedDisplay worker1 = new BorderedDisplay(0, 20, 100, 5);
        private BorderedDisplay worker2 = new BorderedDisplay(0, 23, 100, 5);
        private BorderedDisplay worker3 = new BorderedDisplay(0, 26, 100, 5);
        private readonly ConsoleGUI gui;
        private readonly TextInput input;

        private Workshop ws = new Workshop();
        private WorkshopGenerator wsg = new WorkshopGenerator();

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
        log,
        ammountOfWorkItems,
        worker1,
        worker2,
        worker3,
        workers,
        input.CreateDisplay(0, -3, -1) };

        public MySimulation(ConsoleGUI gui, TextInput input)
        {
            log.Log("Welcome to car repair workshop simulator.");
            log.Log("Press 1 as many times as you want to in oder to simulate a new vehicle being repaired.");
            log.Log("Press 2 to exit simulation.");


            gui.TargetUpdateTime = 700;
            wsg.GenerateEmpoyees(ws);
            wsg.GenerateStock(ws);
            this.gui = gui;
            this.input = input;
        }
        public override void PassTime(int deltaTime)
        {
            var count = 0;
            workers.Value = "Workers avaible for work (if skilled enough): " + ws.AvaibleWorkers;
            ammountOfWorkItems.Value = "Current ammount of vehicles in shop: " + ws.WorkItems.Count;
            if (ws.WorkItems.Count > 0)
            {
                if (ws.WorkItems.Count == 2)
                {
                    worker3.Value = "";
                }
                else if (ws.WorkItems.Count == 1)
                {
                    worker2.Value = "";
                }
                else if (ws.WorkItems.Count == 0)
                {
                    worker1.Value = "";
                }
                foreach (var item in ws.WorkItems.ToList())
                {
                    if (count == 0)
                    {
                        if (!item.Vehicle.IsRepaired)
                        {
                            worker1.Value = (item.DoWork());
                            if (item.Vehicle.IsRepaired)
                            {
                                log.Log(item.Customer.Name + "'s " + item.Vehicle.Manufacturer + " " +
                                    item.Vehicle.ModelYear + " " + "(" + item.Vehicle.LicensePlate.ToUpper() + ")" +
                                    " is repaired! Cost of parts: " +
                                    item.Invoice.PriceOfParts + ". Cost of work: " + item.Invoice.PriceOfWork +
                                    ". Total cost: " + item.Invoice.Total);
                            }
                        }
                    }
                    else if (count == 1)
                    {
                        if (!item.Vehicle.IsRepaired)
                        {
                            worker2.Value = (item.DoWork());
                            if (item.Vehicle.IsRepaired)
                            {
                                worker2.Value = (item.Invoice.Total + " price of parts: " + item.Invoice.PriceOfParts +
                                " price of work: " + item.Invoice.PriceOfWork);
                            }
                        }
                    }
                    else if (count == 2)
                    {
                        if (!item.Vehicle.IsRepaired)
                        {
                            worker3.Value = (item.DoWork());
                            if (item.Vehicle.IsRepaired)
                            {
                                worker3.Value = (item.Invoice.Total + " price of parts: " + item.Invoice.PriceOfParts +
                                " price of work: " + item.Invoice.PriceOfWork);
                            }
                        }
                    }
                    if (item.Employee != null)
                    {
                        count++;

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
                List<SparePart> spareParts = wsg.GenerateBrokenParts(ws);
                ws.HandInCarToShop(wsg.GenerateName(), wsg.GenerateManufacturers(), wsg.GenerateYear(), wsg.GenerateRandomLieciensePlate(), spareParts);
            }
            if (command == "2")
            {
                Environment.Exit(0);
            }

        }
    }
}
