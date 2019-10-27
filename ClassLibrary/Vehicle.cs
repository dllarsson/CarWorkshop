
using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public abstract class Vehicle
    {
        public string Manufacturer { get; private set; }
        public int ModelYear { get; private set; }
        public string LicensePlate { get; private set; }
        public bool IsTransmissionWorking { get; }
        public bool IsEngineWorking { get; }
        public bool IsWheelWorking { get; }
        public bool IsWorking { get; }
        public List<ISparePart> BrokenParts { get; } = new List<ISparePart>();


    }
}
