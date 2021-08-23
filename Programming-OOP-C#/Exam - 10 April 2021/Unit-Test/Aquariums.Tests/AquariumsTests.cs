namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("Sand", 5);
        }

        [Test]
        [TestCase("", 5)]
        [TestCase(null, 5)]        
        public void NameCantBeNullOrWhiteSpace(string value, int capacity) 
        {
            Fish fish = new Fish(value);
            Assert.Throws<ArgumentNullException>(() => new Aquarium(value, capacity));
        }

        [Test]
        [TestCase("Sand", -1)]
        [TestCase("Sand", -5)]
        public void CapacityCantBeNullOrWhiteSpace(string value, int capacity)
        {
            
            Assert.Throws<ArgumentException>(() => new Aquarium(value, capacity));
        }

        [Test]        
        public void AddFishInFullAquariumShouldThrowExeption()
        {
            Aquarium aquarium = new Aquarium("Sand", 1);
            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Lubi");

            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2));
        }
        
        [Test]
        public void AddFishShouldReturnExactCount()
        {

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Lubi");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.That(aquarium.Count, Is.EqualTo(2));
        }
        [Test]
        public void RemoveNullFishShouldThrowExeption()
        {

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Lubi");
            Fish fish3 = new Fish(null);            

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(fish3.Name));
        }
        [Test]
        public void RemoveFishShouldReturnExpectedResult()
        {

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("fish");           

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.RemoveFish(fish2.Name);

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }
        [Test]
        public void SellNullFishShouldThrowExeption()
        {

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Lubi");
            Fish fish3 = new Fish(null);

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(fish3.Name));
        }
        [Test]
        public void SellFishShouldReturnExpectedResult()
        {

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("fish");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            //aquarium.SellFish(fish2.Name);

            Assert.That(fish2.Available, Is.True);
            Assert.That(aquarium.SellFish(fish2.Name), Is.EqualTo(fish2));
        }

        [Test]
        public void ReportFishShouldReturnExpectedResult()
        {

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("fish");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            string expextedMessege = $"Fish available at {aquarium.Name}: {fish1.Name}, {fish2.Name}";

            Assert.That(aquarium.Report(), Is.EqualTo(expextedMessege));
        }
        [Test]
        public void RemoveEmptyColectionShouldThrowExeption()
        {
            Fish fish = new Fish("fish");

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(fish.Name));
        }
    }
}
