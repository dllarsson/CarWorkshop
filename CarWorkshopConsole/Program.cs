using System;
using ClassLibrary;
using ConsoleSimulationEngine2000;

namespace CarWorkshopConsole
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var input = new TextInput();
            var gui = new ConsoleGUI() { Input = input };
            var sim = new MySimulation(gui, input);
            await gui.Start(sim);
        }
    }
}
