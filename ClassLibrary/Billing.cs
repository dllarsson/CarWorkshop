using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Billing
    {
        public decimal Bill { get; }
        public Billing(decimal workCosts, int timeInShop, Vehicle vehicle)
        {
            decimal priceOfSpareParts = 0;
            foreach (var item in vehicle.changedParts)
            {
                priceOfSpareParts += item.Price;
            }
            decimal totalCost = priceOfSpareParts + timeInShop + workCosts;
        }
    }
}
