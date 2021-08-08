using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArenaTests
    {
        private List<Warrior> warriors;
        private Arena arena;

        public ArenaTests()
        {
            this.warriors = new List<Warrior>
            {
                new Warrior("Pehso", 100, 200),
                new Warrior("Gosho", 150, 250),
                new Warrior("Tosho", 50, 200),
                new Warrior("Veso", 250, 100),
            };
        }

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ConstructorShouldCreateArena()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        public void Enroll_ShouldAddNewWarriors(int numberOfWarriors)
        {
            var warriorCollection = this.warriors.Take(numberOfWarriors);

            foreach (var warrior in warriorCollection)
            {
                arena.Enroll(warrior);
            }

            CollectionAssert.AreEqual(warriorCollection, arena.Warriors);
        }

        [Test]
        public void CountShouldReturnWarriorCollectionCount()
        {
            foreach (var warrior in this.warriors)
            {
                arena.Enroll(warrior);
            }

            var expectedCount = this.warriors.Count;
            var actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Enroll_ShouldThrowExceptionIfTryToAddExistingWarrior()
        {
            var warrior = this.warriors.FirstOrDefault();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior));
        }

        [Test]
        public void Fight_ShouldThrowExceptionIfOneOfTheWarriorsIsNotEnrolled()
        {
            var warrior = this.warriors.FirstOrDefault();
            arena.Enroll(warrior);

            var notEnrolledWarrior = new Warrior("Hulk", 999, 999);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(warrior.Name, notEnrolledWarrior.Name));
        }

        [Test]
        public void Fight_ShouldThrowExceptionIfBothOfTheWarriorsAreNotEnrolled()
        {
            var notEnrolledWarrior = new Warrior("Hulk", 999, 999);
            var otherNotEnrolledWarrior = new Warrior("Thor", 500, 999);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(notEnrolledWarrior.Name, otherNotEnrolledWarrior.Name));
        }

        [Test]
        public void Fight_ShouldWorkCorrectly()
        {
            var attacker = new Warrior("Pehso", 100, 200);
            this.arena.Enroll(attacker);
            var defender = new Warrior("Gosho", 100, 400);
            this.arena.Enroll(defender);

            var expectedAttackerHP = attacker.HP - defender.Damage;
            var expectedDefenderHP = defender.HP - attacker.Damage;

            this.arena.Fight(attacker.Name, defender.Name);

            var actualAttackerHP = attacker.HP;
            var actualDefenderHP = defender.HP;

            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
        }
    }
}
