using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class WorkshopGenerator
    {
        private Random rand = new Random();
        private List<string> parts = new List<string> { "engine", "transmission", "wheel", "muffler", "door" };
        private List<string> names = new List<string> { "Erik", "Johan", "Bill", "Anna", "Clara", "John", "Marie", "Beatrice", "Victoria", "Anton" };
        private List<string> manufacturers = new List<string> { "Peugot", "Merceders", "Toyota", "Kia", "Ford", "BMW", "Audi", "Volvo", "Saab" };

        public string GenerateName()
        {
            var index = rand.Next(0, names.Count);
            return names[index];
        }
        public string GenerateManufacturers()
        {
            var index = rand.Next(0, manufacturers.Count);
            return manufacturers[index];
        }
        public int GenerateYear()
        {
            var year = 1970;
            year += rand.Next(0, 49);
            return year;
        }

        public List<SparePart> GenerateBrokenParts(Workshop ws)
        {
            List<SparePart> spareParts = new List<SparePart>();
            var tempList = new List<string>(parts);
            var numberOfBrokenParts = rand.Next(1, 4);

            for (int j = 0; j < numberOfBrokenParts; j++)
            {
                var index = rand.Next(0, tempList.Count);
                SparePart sp = new SparePart(parts[index], 20, rand.Next(15, 25), rand.Next(500, 10000), rand.Next(5, 20));
                spareParts.Add(sp);
                tempList.RemoveAt(index);
            }
            return spareParts;
        }


        public string GenerateRandomLieciensePlate()
        {
            StringBuilder sr = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                int num = rand.Next(0, 26);
                char letter = (char)('a' + num);
                sr.Append(letter);

            }
            for (int j = 0; j < 3; j++)
            {
                int num = rand.Next(0, 9);
                sr.Append(num);
            }

            return sr.ToString();
        }
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
            var e3 = new Intern("Martin", 43, 12);
            ws.Empolyees.Add(e);
            ws.Empolyees.Add(e2);
            ws.Empolyees.Add(e3);
        }


    }
}
