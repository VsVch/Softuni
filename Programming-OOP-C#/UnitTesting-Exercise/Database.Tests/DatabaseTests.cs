using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void AddThrowExeptionWhenCapacityIsExceeded()
        {

            int n = 16;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(17));
        }

        [Test]
        public void AddItemInCollection_ShoudReturnEqualNumber()
        {
            int element = 123;

            this.database.Add(element);

            int[] elements = this.database.Fetch();


            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void RemoveItemOnEmptyCollection_ShoudThrowexeption()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void RemoveItemOnCollection_ShoudReturnExactCount()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            this.database.Remove();

            Assert.That(this.database.Count, Is.EqualTo(n - 1));
        }
        [Test]
        public void RemoveIElementFromDatabase()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            this.database.Remove();

            int[] elements = this.database.Fetch();

            Assert.IsFalse(elements.Contains(5));
        }

        [Test]
        public void FetchCollections_ShouldReturnSameElements()
        {
            int n = 3;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            int[] copyCollection = database.Fetch();

            this.database.Remove();

            int[] secondCopy = database.Fetch();

            Assert.That(copyCollection, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void CountElement_ShouldHaveRightAmountOfElement()
        {
            int n = 3;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            Assert.That(this.database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Ctor_ShouldThrowExeptionWhenTryToAddNewItemInFullCollection()
        {
            int n = 16;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Ctor_ShouldReturnrightZeroWhenInitializes()
        {

            Assert.That(this.database.Count, Is.EqualTo(0));
        }
    }
}