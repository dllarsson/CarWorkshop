using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Invoice
    {
        public decimal Total { get; }
        public string WorkerOfVehicle { get; }
        public string WorkerOnVehice { get; }
        public decimal PriceOfWork { get; }
        public decimal PriceOfParts { get; }
        public bool IsPayed { get; }

        public Invoice(decimal total, string workerOfVehicle, decimal priceOfWork, decimal priceOfParts)
        {
            Total = total;
            WorkerOfVehicle = workerOfVehicle;
            PriceOfWork = priceOfWork;
            PriceOfParts = priceOfParts;
            IsPayed = false;
        }
    }
}
