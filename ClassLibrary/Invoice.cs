using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Invoice
    {
        public decimal Total { get; }
        public string WorkerOfVehicle { get; }
        public string WorkerOnVehice { get; private set; }
        public decimal PriceOfWork { get; private set; }
        public decimal PriceOfParts { get; set; }
        public bool IsPayed { get;  private set; }

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
