
using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Vehicle
    {
        public string Manufacturer { get; private set; }
        public int ModelYear { get; private set; }
        public string LicensePlate { get; private set; }
        public bool IsRepaired { get; set; }
        public List<SparePart> BrokenParts { get; private set; } = new List<SparePart>();

        public Vehicle(string manufacturer, int modelYear, string licensePlate, List<SparePart> brokenParts)
        {
            IsRepaired = false;
            Manufacturer = manufacturer;
            ModelYear = modelYear;
            LicensePlate = licensePlate;
            BrokenParts = brokenParts;
        }

    }
}
