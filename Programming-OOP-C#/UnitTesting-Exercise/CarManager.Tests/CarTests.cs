
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("make", "model", 10, 100);
        }

        [Test]
        [TestCase("", "model", 10, 100)]
        [TestCase(null, "model", 10, 100)]
        [TestCase("make","", 10, 100)]
        [TestCase("make", null, 10, 100)]
        [TestCase("make", "model", 0, 100)]
        [TestCase("make", "model", -10, 100)]
        [TestCase("make", "model", 10, 0)]
        [TestCase("make", "model", 10, -100)]
        public void DiferentTypeOfNonValidArguments_ShouldThrowExeption
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ChekFuelAmountAfterRefuel_ShouldReturnProperAmount()
        {
            int reFuel = 20;

            car.Refuel(reFuel);

            Assert.That(car.FuelAmount, Is.EqualTo(reFuel));

        }

        [Test]
        public void ChekFuelAmountAfterAddFuelToFullTank_ShouldReturnFullTankCapacity()
        {

            int reFuel = 120;
            car.Refuel(reFuel);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));

        }

        [Test]
        public void ChekWhenNeededFuelIsMoreThanFuelInTank_ShouldThrowexeption()
        {
            car.Refuel(20);
            double distance = 1000;

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        public void ChekWhenNeededFuelIsExsactSameThanFuelInTank_ShouldBeEnough()
        {
            car.Refuel(100);
            double distance = 1000;
            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }


        [Test]
        public void ChekWasteWhenDrive_ShouldRedusFuelAmount()
        {
            car.Refuel(100);
            double distance = 100;
            double neededFuel = distance / 100 * car.FuelConsumption;
            double fuelLeft = car.FuelAmount - neededFuel;

            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(fuelLeft));
        }

        [Test] 
        public void CtorSetsParametars_ShouldReturnEqualParameters()
        {

            string make = "opel";
            string model = "meriva";
            double fuelConsumption = 7;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption,fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }
    }
}