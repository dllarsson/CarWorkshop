using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Invoice
    {
        public decimal Total { get; }
        public bool IsPayed { get;  private set; }

        public Invoice( decimal total)
        {
            Total = total;
        }
    }
}
