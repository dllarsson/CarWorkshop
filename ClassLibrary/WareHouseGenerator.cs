using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class WareHouseGenerator
    {
        WareHouse wh = new WareHouse();
        public void Generate()
        {
            for (int i = 0; i < 300; i++)
            {
                if (i < 100)
                {
                    wh.AddSparePart("engine");
                }
                else if (i < 200)
                {
                    wh.AddSparePart("transmission");
                }
                else if (i == 300)
                {
                    wh.AddSparePart("wheel");
                }
            }
        }
    }
}
