namespace BankSafe.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    public class BankVaultTests
    {
        private Item defaultItem;
        private BankVault bankVault;

        public BankVaultTests()
        {
            this.defaultItem = new Item("Ivan Ivanov", "Nishto");
        }

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
        }

        [Test]
        public void CheckItemConstructorWorksCorrlectl()
        {
            var item = new Item("Tosho", "gold");

            Assert.IsNotNull(item);
            Assert.AreEqual("Tosho", item.Owner);
            Assert.AreEqual("gold", item.ItemId);
        }

        [Test]
        public void CheckBanckVaultConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.bankVault);
            Assert.AreEqual(12, this.bankVault.VaultCells.Count);
            Assert.IsTrue(this.bankVault.VaultCells.All(x => x.Key != null));
            Assert.IsTrue(this.bankVault.VaultCells.All(x => x.Value == null));
        }

        [Test]
        public void AddItem_ShouldWorkCorrectly()
        {
            var returnString = this.bankVault.AddItem("A2", this.defaultItem);
            var expectedString = $"Item:{this.defaultItem.ItemId} saved successfully!";

            Assert.AreEqual(this.defaultItem, this.bankVault.VaultCells["A2"]);
            Assert.AreEqual(expectedString, returnString);
        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfDictKeyValueIsInvalid()
        {
            Assert.Throws<ArgumentException>(
                () => this.bankVault.AddItem("Invalid cell", this.defaultItem));
        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfTryToAddToExistingKeyValue()
        {
            this.bankVault.AddItem("A2", this.defaultItem);

            Assert.Throws<ArgumentException>(
                () => this.bankVault.AddItem("A2", this.defaultItem));
        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfTryToAddItemIdAlreadyExisting()
        {
            this.bankVault.AddItem("A2", this.defaultItem);

            Assert.Throws<InvalidOperationException>(
                () => this.bankVault.AddItem("C1", this.defaultItem));
        }

        [Test]
        public void RemoveItem_ShouldWorkCorrectly()
        {
            this.bankVault.AddItem("A2", this.defaultItem);

            var expectedString = $"Remove item:{this.defaultItem.ItemId} successfully!";
            var returnString = this.bankVault.RemoveItem("A2", this.defaultItem);

            Assert.AreEqual(null, this.bankVault.VaultCells["A2"]);
            Assert.AreEqual(expectedString, returnString);
        }

        [Test]
        public void RemoveItem_ShouldThrowExceptionIfKeyDoesntExists()
        {
            this.bankVault.AddItem("A2", this.defaultItem);

            Assert.Throws<ArgumentException>(
                () => this.bankVault.AddItem("Invalid cell", this.defaultItem));
        }

        [Test]
        public void RemoveItem_ShouldThrowExceptionIfItemDoesntExists()
        {
            this.bankVault.AddItem("A2", this.defaultItem);
            var nonExistingItem = new Item("Vasko", "silver");

            Assert.Throws<ArgumentException>(
                () => this.bankVault.AddItem("A2", nonExistingItem));
        }
    }
}