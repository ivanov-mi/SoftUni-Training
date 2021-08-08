namespace Chainblock.Tests
{
    using System;
    using System.Linq;
    using Contracts;
    using NUnit.Framework;

    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Initialize()
        {
            this.chainblock = new Chainblock();
        }

        [Test]
        public void Add_TransactionWithNonExistingTransactionIdShouldIncreaseCount()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            Assert.That(chainblock.Count, Is.EqualTo(1), "Count should be increasd and equal to 1.");
        }

        [Test]
        public void Add_TransactionWithExistingID_ShouldThrowException()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            Assert.Throws<InvalidOperationException>(
                () => chainblock.Add(dummyTx),
                "Transaction ID already exists.");

            Assert.That(chainblock.Count, Is.EqualTo(1), "The count shouldn`t increase.");
        }

        [Test]
        public void ContainsById_ShouldReturnTrueForExistingTransaction()
        {
            var txId = 1;
            ITransaction dummyTx = new Transaction(txId, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            Assert.That(this.chainblock.Contains(txId), Is.EqualTo(true), "Contains should return true with existing transaction.");
        }

        [Test]
        public void ContainsByIdShould_ReturnFalseForNonExistingTransaction()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            Assert.That(this.chainblock.Contains(2), Is.EqualTo(false), "Contains should return false with non-existing transaction.");
        }

        [Test]
        public void ContainsByTx_ShouldReturnTrueForExistingTx()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            Assert.That(this.chainblock.Contains(dummyTx), Is.EqualTo(true), "Contains should return true with existing transaction.");
        }

        [Test]
        public void ContainsByx_ShouldReturnFalseForNonExistingTx()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            ITransaction nonExistingTransaction = new Transaction(2, TransactionStatus.Unauthorized, "my friend", "me", 1234.0);

            Assert.That(this.chainblock.Contains(nonExistingTransaction), Is.EqualTo(false), "Contains should return false with non-existing transaction.");
        }

        [Test]
        public void GetById_ShouldReturnTxIfIdExists()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);
            ITransaction anotherDummyTx = new Transaction(2, TransactionStatus.Unauthorized, "my friend", "me", 1234.0);

            this.chainblock.Add(dummyTx);
            this.chainblock.Add(anotherDummyTx);

            var anotherDummyTxId = 2;

            ITransaction tx = this.chainblock.GetById(anotherDummyTxId);

            Assert.That(tx, Is.EqualTo(anotherDummyTx), "Transactions are unique.");
        }

        [Test]
        public void GetId_ShouldThrowExceptionIfIdExists()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);
            ITransaction anotherDummyTx = new Transaction(2, TransactionStatus.Unauthorized, "my friend", "me", 1234.0);

            this.chainblock.Add(dummyTx);
            this.chainblock.Add(anotherDummyTx);

            var nonExistingId = 5;

            Assert.Throws<InvalidOperationException>( 
                () => this.chainblock.GetById(nonExistingId), 
                "Get by Id with non existing transaction should throw an exception.");
        }

        [Test]
        public void ChangeTxStatus_ShouldChangeTxStatusIfExists()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            var expectedStatus = TransactionStatus.Successfull;
            this.chainblock.ChangeTransactionStatus(dummyTx.Id, expectedStatus);

            var receivedTx = this.chainblock.GetById(dummyTx.Id);
            var actualStatus = receivedTx.Status;

            Assert.That(actualStatus, Is.EqualTo(expectedStatus),
                "Change transaction status should update.");
        }

        [Test]
        public void ChangeTxStatus_ShouldThrowExceptionIfTxNonExist()
        {
            ITransaction dummyTx = new Transaction(1, TransactionStatus.Aborted, "me", "my friend", 1234.0);

            this.chainblock.Add(dummyTx);

            Assert.Throws<ArgumentException>(
                () => this.chainblock.ChangeTransactionStatus(23, TransactionStatus.Aborted),
                "Change status with non-existing Id should throws ArgumentException.");
        }

        [Test]
        public void RemoveTxById_ShouldRemoveTxAndReduceCount()
        {
            for (int i = 0; i < 100; i++)
            {
                var tx = new Transaction(i, TransactionStatus.Successfull, i.ToString(), i.ToString(), i + 0.1);

                this.chainblock.Add(tx);
            }

            var expectedResult = this.chainblock.Count - 1;
            var queryId = 0;

            this.chainblock.RemoveTransactionById(queryId);

            var actualResult = this.chainblock.Count;

            Assert.That(
                actualResult, Is.EqualTo(expectedResult));

            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.GetById(queryId));
        }

        [Test]
        public void RemoveMultipleTxById_ShouldRemoveTxAndReduceCount()
        {
            for (int i = 0; i < 100; i++)
            {
                var tx = new Transaction(i, TransactionStatus.Successfull, i.ToString(), i.ToString(), i + 0.1);

                this.chainblock.Add(tx);
            }

            for (int i = 0; i <= 4; i++)
            {
                this.chainblock.RemoveTransactionById(i);
            }

            Assert.That(
                this.chainblock.Count, 
                Is.EqualTo(95));

            for (int i = 0; i <= 4; i++)
            {
                Assert.Throws<InvalidOperationException>(
                    () => this.chainblock.GetById(i));
            }
        }

        [Test]
        public void RemoveTxById_ShouldThrowExceptionIfCollectionEmptyAndCountRemainNonNegative()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.RemoveTransactionById(0));

            Assert.That(
                this.chainblock.Count,
                Is.EqualTo(0));
        }

        [Test]
        public void RemoveTxById_ShouldThrowExceptionIfNonExistingId()
        {
            for (int i = 0; i < 5; i++)
            {
                var tx = new Transaction(i, TransactionStatus.Successfull, i.ToString(), i.ToString(), i + 0.1);

                this.chainblock.Add(tx);
            }

            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.RemoveTransactionById(5));

            Assert.That(
                this.chainblock.Count,
                Is.EqualTo(5));
        }

        [Test]
        public void GetByTxStatus_ShouldReturnTxWithTheGivenStatusOrderedByAmountInDescending()
        {
            for (int i = 0; i < 100; i++)
            {
                var status = (TransactionStatus)(i % 4 + 1);

                var tx = new Transaction(i, status, i.ToString(), i.ToString(), i + 50);

                this.chainblock.Add(tx);
            }

            var filterTransactionStatus = TransactionStatus.Successfull;

            var filteredTransaction = this.chainblock.GetByTransactionStatus(filterTransactionStatus)
                .ToArray();

            Assert.That(filteredTransaction[0].Status, Is.EqualTo(filterTransactionStatus));
            var previousAmount = filteredTransaction[0].Amount;

            foreach (var tx in filteredTransaction)
            {
                var currentAmount = tx.Amount;

                Assert.That(currentAmount, Is.LessThanOrEqualTo(previousAmount));

                Assert.That(tx.Status, Is.EqualTo(filterTransactionStatus));

                previousAmount = currentAmount;
            }
        }

        [Test]
        public void GetByTxStatus_ShouldThrowExceptionIfThereAreNoTxWtihThisStatus()
        {
            for (int i = 0; i < 100; i++)
            {
                var status = (TransactionStatus)(i % 3 + 1);

                var tx = new Transaction(i, status, i.ToString(), i.ToString(), i + 50);

                this.chainblock.Add(tx);
            }

            var nonExistingTransactionStatus = TransactionStatus.Unauthorized;
                                   
            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.GetByTransactionStatus(nonExistingTransactionStatus));
        }
    }
}
