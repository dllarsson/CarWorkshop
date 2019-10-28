using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class WorkshopGenerator
    {
        Random rand = new Random();
        public void GenerateStock(Workshop ws)
        {
            ws.AddSparePart("engine", 20, 22, 4000, 18);
            ws.AddSparePart("door", 15, 8, 1000, 8);
            ws.AddSparePart("transmission", 30, 17, 8000, 20);
            ws.AddSparePart("wheel", 20, 9, 400, 10);
            ws.AddSparePart("muffler", 20, 14, 2000, 13);
        }
        public void GenerateEmpoyees(Workshop ws)
        {
            var e = new SeniorWorker("David", 130, 20);
            var e2 = new JuniorWorker("Jesper", 88, 15);
            var e3 = new Intern("Martin", 43, 10);
            ws.employees.Add(e);
            ws.employees.Add(e2);
            ws.employees.Add(e3);
        }

        
    }
}
