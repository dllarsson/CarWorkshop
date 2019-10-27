using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public interface ISparePart
    {
        public string Type { get; }
        public decimal Price { get; }
        public int Stock { get; }
        public int TimeToChangePart { get; }

        public void IncreaseStock();
        public void DecreaseStock();
    }
}
