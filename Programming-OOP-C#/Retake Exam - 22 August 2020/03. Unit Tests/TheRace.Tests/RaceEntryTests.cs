using NUnit.Framework;
using System;


namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            driver = new UnitDriver("Sand", car);
            car = new UnitCar("meriva", 90, 2000);
        }        
        [Test]
        public void AddNullDriver_ShouldThrowExeption()
        {

            UnitDriver driver1 = null;
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver1));

        }        
        [Test]
        public void AddDriver_ShouldReturnProperObjectCount()
        {

            Assert.That(raceEntry.AddDriver(driver), Is.EqualTo("Driver Sand added in race."));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));

        }
        [Test]
        public void AddExistingDriver_ShouldThrowExeption()
        {

            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));

        }
        [Test]
        public void drivercountisbelowracelimit_shouldthrowexeption()
        {
            UnitCar car1 = new UnitCar("Meriva", 80, 2000);       
            UnitDriver driver1 = new UnitDriver("Mish", car1);           

            raceEntry.AddDriver(driver1);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());

        }
        [Test]
        public void AveregehorsePowerCalcolation_ShouldReturnAverageValue()
        {
            UnitCar car1 = new UnitCar("Meriva", 80, 3000);
            UnitCar car2 = new UnitCar("Corsa", 82, 2500);

            UnitDriver driver1 = new UnitDriver("Mish", car1);
            UnitDriver driver2 = new UnitDriver("Lubo", car2);

            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver1);
            Assert.That(raceEntry.CalculateAverageHorsePower(), Is.EqualTo(81));

        }
    }
}