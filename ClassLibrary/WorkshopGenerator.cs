using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class WorkshopGenerator
    {
       
        public void GenerateStock(Workshop ws)
        {
            for (int i = 0; i < 300; i++)
            {
                if (i < 100)
                {
                    ws.AddSparePart("engine");
                }
                else if (i < 200)
                {
                    ws.AddSparePart("transmission");
                }
                else if (i < 300)
                {
                    ws.AddSparePart("wheel");
                }
            }
        }
        public void GenerateEmpoyees(Workshop ws)
        {
            Employee e = new Employee("David", 123);
            ws.employees.Add(e);
        }
        
    }
}
