using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase dataPersons;

        [SetUp]
        public void Setup()
        {
            dataPersons = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void AddNewPersonInFullColecction_ShouldTrowExeption()
        {

            int n = 16;

            for (int i = 0; i < n; i++)
            {
                dataPersons.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => dataPersons.Add(new Person(17, "Username17")));

        }

        [Test]
        public void AddSamePerson_ShouldTrowExeption_PersonShouldBeUnique() // error??
        {
            Person person1 = new Person(1, "Misho");
            Person person2 = new Person(2, "Lubcho");

            dataPersons.Add(person1);
            dataPersons.Add(person2);

            Assert.Throws<InvalidOperationException>(() => dataPersons.Add(new Person(3, "Misho")));
            Assert.Throws<InvalidOperationException>(() => dataPersons.Add(new Person(1, "Sasho")));

        }

        [Test]
        public void AddNewUniquePerson_ShouldReturnIncreceByOneCount()
        {
            int expectedCount = 2;
            Person person1 = new Person(1, "Misho");
            Person person2 = new Person(2, "Lubcho");

            dataPersons.Add(person1);
            dataPersons.Add(person2);
            Assert.That(dataPersons.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveFromEmptyCollection_ShouldTrowExeption()
        {

            Assert.Throws<InvalidOperationException>(() => dataPersons.Remove());
        }


        [Test]
        public void RemovePersonFromCollection()
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                Person person = new Person(i, $"UserName{i}");
                dataPersons.Add(person);
            }

            dataPersons.Remove();

            Assert.That(dataPersons.Count, Is.EqualTo(n - 1));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindWhenUsernameIsEmptyOrNull_ShodThrowExeption(string userName)
        {
            dataPersons.Add(new Person(1, "UserName"));
            dataPersons.Add(new Person(2, "UserName2"));

            Assert.Throws<ArgumentNullException>(() => dataPersons.FindByUsername(userName));
        }

        [Test]
        public void FindNotExistinguser_ShodThrowExeption()
        {
            Person person = new Person(2, " userName3");

            dataPersons.Add(new Person(1, "UserName"));
            dataPersons.Add(new Person(2, "UserName2"));

            Assert.Throws<InvalidOperationException>(() => dataPersons.FindByUsername(person.UserName));

        }

        [Test]
        public void FindExistingUser_ShodReturnPerson()
        {
            Person person1 = new Person(1, "UserName");
            Person person2 = new Person(2, " userName2");

            dataPersons.Add(new Person(1, "UserName"));
            dataPersons.Add(new Person(2, "UserName2"));

            Person dbPerson = dataPersons.FindByUsername(person1.UserName);

            Assert.That(person1.UserName, Is.EqualTo(dbPerson.UserName));

        }


        [Test]
        public void WhenIdIsNegativeValue_ShodThrowExeption()
        {
            Person person = new Person(-10, "User");

            Assert.Throws<ArgumentOutOfRangeException>(() => dataPersons.FindById(person.Id));
        }



        [Test]
        public void WhenUserIdIMissingInCollection_ShodThrowExeption()
        {
            Person person = new Person(1, "User");
            dataPersons.Add(person);
            Person person2 = new Person(2, "User");

            Assert.Throws<InvalidOperationException>(() => dataPersons.FindById(person2.Id));
        }

        [Test]
        public void WhenIdIsInCollection_ShodReturnPerson()
        {
            Person person = new Person(1, "User");
            Person person2 = new Person(2, "User2");
            dataPersons.Add(person);
            dataPersons.Add(person2);

            Person dbPerson = dataPersons.FindById(person.Id);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void CtorListInicialization_ShodReturnNull()
        {

            Assert.That(dataPersons.Count, Is.EqualTo(0));
        }
    }
}