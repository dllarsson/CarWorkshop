using System;
using ClassLibrary;

namespace CarWorkshopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouseGenerator whg = new WareHouseGenerator();
            whg.Generate();
        }
    }
}
