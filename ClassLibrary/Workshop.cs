using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class WareHouse
    {
        public Dictionary<string, ISparePart> SpareParts = new Dictionary<string, ISparePart>();

        public void AddSparePart(string key)
        {
            ISparePart sparePart;
            if (key == "engine")
            {
                var stock = 1;
                if (SpareParts.ContainsKey("engine"))
                {
                    SpareParts["engine"].IncreaseStock();
                }
                else
                {
                    sparePart = new Engine("engine", 3000, stock);
                    SpareParts.Add(key, sparePart);
                }


            }
            else if (key == "transmission")
            {
                var stock = 1;
                if (SpareParts.ContainsKey("transmission"))
                {
                    SpareParts["transmission"].IncreaseStock();
                }
                else
                {
                    sparePart = new Transmission("transmission", 2300, stock);
                    SpareParts.Add(key, sparePart);
                }


            }
            else if (key == "wheel")
            {
                var stock = 1;
                if (SpareParts.ContainsKey("wheel"))
                {
                    SpareParts["wheel"].IncreaseStock();
                }
                else
                {
                    sparePart = new Wheel("wheel", 2300, stock);
                    SpareParts.Add(key, sparePart);
                }

            }
        }

        public int GetStockOfSparePart(string key)
        {
            if (SpareParts.ContainsKey(key))
            {
                return SpareParts[key].Stock;
            }
            else
            {
                return -1;
            }
        }

        public void RemovePart(string key)
        {
            if (SpareParts.ContainsKey(key))
            {
                if (SpareParts[key].Stock == 0)
                {
                    SpareParts.Remove(key);
                }
                SpareParts[key].DecreaseStock();
            }

        }

        public decimal GetPriceOfSparePart(string key)
        {
            if (SpareParts.ContainsKey(key))
            {
                return SpareParts[key].Price;
            }
            else
            {
                return -1;
            }
        }
    }
}
