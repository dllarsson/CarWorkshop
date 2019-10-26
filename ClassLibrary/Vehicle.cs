
using System;

namespace ClassLibrary
{
    public abstract class Vehicle
    {
        public string Manufacturer { get; private set; }
        public int ModelYear { get; private set; }
        public string LicensePlate { get; private set; }
        public bool IsWorking { get; }
    }
}
