using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bank;

        [SetUp]
        public void Setup()
        {
            item = new Item("Sasho", "1");
            bank = new BankVault();            
        }
        [Test]
        public void AddCellWhitInvalidKey_ShouldThrowExeption()
        {

            Assert.Throws<ArgumentException>(() => bank.AddItem("D1", item));
        }        
        [Test]
        public void AddItemOnOccupiedCell_ShouldThrowExeption()
        {
            Item item1 = new Item("Misho", "2");
            bank.AddItem("A1", item1);
            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", item));
        }       
        [Test]
        public void AddItemOnExistCell_ShouldThrowExeption()
        {
            Item item1 = new Item("Misho", "2");
            bank.AddItem("A1", item);
            
            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", item));

        }
        [Test]
        public void AddItemOnNotExistCell_ShouldSueccside()
        {
            Item item1 = new Item("Misho", "2");
            bank.AddItem("A1", item);
            Assert.That(bank.AddItem("A2", item1), Is.EqualTo($"Item:{item1.ItemId} saved successfully!"));
        }
        [Test]
        public void RemoveItemOnNotExistCell_ShouldThrowExeption()
        {
            
            bank.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bank.RemoveItem("H1", item));
        }
        [Test]
        public void RemovedItemDontExistOnTheCell_ShouldThrowExeption()
        {
            Item item1 = new Item("Misho", "2");
            bank.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A1", item1));
        }
        [Test]
        public void RemovedItemTheCell_ShouldReturnProperMessege()
        {
            
            bank.AddItem("A1", item);
            Assert.That(bank.RemoveItem("A1", item),Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }      

    }
}