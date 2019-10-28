using NUnit.Framework;
using ClassLibrary;

namespace CarWorkshopTests
{
    public class Tests
    {


        [Test]
        public void TestIf()
        {
            Workshop ws = new Workshop();
            WorkshopGenerator wsg = new WorkshopGenerator();
            wsg.GenerateEmpoyees(ws);
            wsg.GenerateStock(ws);

            
            ws.HandInCarToShop(wsg.GenerateName(), wsg.GenerateManufacturers(), wsg.GenerateYear(), wsg.GenerateRandomLieciensePlate(), wsg.GenerateBrokenParts(ws)); ;

            Assert.Pass();
        }
    }
}