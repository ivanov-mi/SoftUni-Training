using NUnit.Framework;

namespace Tests
{
    using Database;
    using System;

    public class DatabaseTests
    {
        private const int MaxArrayCapacity = 16;
        private readonly int[] simpleTestArray = { 1, 2, 3, 4, 5 };

        [TestCase()]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            Database database = new Database(new int[MaxArrayCapacity]);
            var expectedCount = MaxArrayCapacity;
            var actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ThrowExceptionWhenTryToInitializeWithMoreThan17Elements()
        {
            Assert.Throws<InvalidOperationException>(
                () => new Database(new int[MaxArrayCapacity + 1]));
        }

        [Test]
        public void AddMethodShouldAddElementAndIncreaseCount()
        {
            Database database = new Database();
            var expectedCount = database.Count + 1;

            database.Add(new int());
            var actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldAddToTheEndOfTheArray()
        {
            int numberToAdd = int.MinValue;
            Database database = new Database(this.simpleTestArray);

            database.Add(numberToAdd);

            var expectedResult = numberToAdd;
            var dataBaseArray = database.Fetch();
            var actualResult = dataBaseArray[dataBaseArray.Length - 1];

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void IfArrayIsFullAndTryToAddElementThrowException()
        {
            Database database = new Database(new int[MaxArrayCapacity]);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new int()));
        }

        [Test]
        public void RemoveMethodShouldRemoveElementAndDecrementCount()
        {
            Database database = new Database(new int[MaxArrayCapacity]);
            var expectedCount = database.Count - 1;

            database.Remove();
            var actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void IfArrayIsEmptyAndTryToRemoveElementThrowException()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(
                 () => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveToTheEndOfTheArray()
        {
            var testArray = this.simpleTestArray;
            Database database = new Database(this.simpleTestArray);

            database.Remove();

            var expectedResult = testArray[testArray.Length - 2];
            var dataBaseArray = database.Fetch();
            var actualResult = dataBaseArray[dataBaseArray.Length - 1];

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FetchMethodShouldReturningAllElementsAsArray()
        {
            Database database = new Database(this.simpleTestArray);
            var expectedResult = this.simpleTestArray;

            var actualResult = database.Fetch();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}