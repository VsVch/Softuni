using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {

        private ComputerManager computerMenager;
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            computerMenager = new ComputerManager();
            computer = new Computer("Asus", "VivoBook", 700);
        }

        [Test]
        public void AddComputerWhitValueNull_ShouldThrowExeption()
        {
            computer = null;
            Assert.Throws<ArgumentNullException>(() => computerMenager.AddComputer(computer));
        }
        [Test]
        public void AddExsistingComputer_ShouldThrowExeption()
        {
            computerMenager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerMenager.AddComputer(computer));            
        }
        [Test]
        public void AddComputer_ShouldReturnProperValue()
        {

            computerMenager.AddComputer(computer);
            int computersCount = 1;
            Assert.That(computerMenager.Count, Is.EqualTo(computersCount));
            Assert.That(computerMenager.Computers.Contains(computer), Is.True);
        }
        [Test]
        public void GetNullComputer_ShouldThrowExeption()
        {
            Computer computer1 = new Computer("Masus", "Vivo", 1700);
            computerMenager.AddComputer(computer1);
            
            Assert.Throws<ArgumentNullException>(() => computerMenager.GetComputer(null, "Vivo"));
            Assert.Throws<ArgumentNullException>(() => computerMenager.GetComputer("Masus", null));
            
        }
        [Test]
        public void GetComputer_ShouldReturnProperValue()
        {

            computerMenager.AddComputer(computer);           
            
            Assert.That(computerMenager.GetComputer(computer.Manufacturer, computer.Model), Is.EqualTo(computer));
            
        }
        [Test]
        public void RemoveComputer_ShouldRemoveComputer()
        {

            computerMenager.AddComputer(computer);
            Computer computer1 = new Computer("Masus", "Vivo", 1700);
            computerMenager.AddComputer(computer1);
            int computersCount = 1;

            Assert.That(computerMenager.RemoveComputer(computer.Manufacturer, computer.Model), Is.EqualTo(computer));
            Assert.That(computerMenager.Count, Is.EqualTo(computersCount));
        }
        [Test]
        public void GetComputerByManefacture_ShouldReturnProperValue()
        {
            Computer computer1 = new Computer("Asus", "RivoBook", 700);
            Computer computer2 = new Computer("Asus", "MivoBook", 700);
            Computer computer3 = new Computer("Acer", "GivoBook", 700);
            computerMenager.AddComputer(computer);
            computerMenager.AddComputer(computer1);
            computerMenager.AddComputer(computer2);
            computerMenager.AddComputer(computer3);

            ICollection<Computer> getComputers = computerMenager.GetComputersByManufacturer("Asus");

            Assert.That(getComputers.Count, Is.EqualTo(3));
        }
        [Test]
        public void CollectionInitialization_ShouldReturnNullr()
        {             
           
            Assert.That(computerMenager.Count, Is.EqualTo(0));
        }
        [Test]
        public void GetComputerByManefactureIsEmptyCollection_ShouldReturnNull()
        {
            
            ICollection<Computer> getComputers = computerMenager.GetComputersByManufacturer("Asus");

            Assert.That(getComputers.Count, Is.EqualTo(0));
        }
        [Test]
        public void RemoveComputerFromEmptyCollection_ShouldThrowExeption()
        {
            Assert.Throws<ArgumentException>(() => computerMenager.RemoveComputer(computer.Manufacturer, computer.Model));   
        }      

        [Test]
        public void CheckConstructorAndPropertiest() // ("Asus", "VivoBook", 700)
        {
            Assert.That(computer.Manufacturer, Is.EqualTo("Asus"));
            Assert.That(computer.Model, Is.EqualTo("VivoBook"));
            Assert.That(computer.Price, Is.EqualTo(700));
            Assert.That(computerMenager.Computers.Count, Is.EqualTo(0));
            Assert.That(computerMenager.Count, Is.EqualTo(0));
            Assert.That(computerMenager, Is.Not.Null);
            Assert.That(computerMenager.Computers, Is.Not.Null);
        }
        [Test]
        public void GetComputerWhitNullValue_ShouldThrowExeption()
        {
            computerMenager.AddComputer(computer);

            Computer computer1 = new Computer("Acer", "GivoBook", 700);
            Assert.Throws<ArgumentException>(() => computerMenager.GetComputer(computer1.Manufacturer, computer1.Model));
        }
    }
}