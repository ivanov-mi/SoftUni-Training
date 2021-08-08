using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    using System;

    public class WarriorTests
    {
        [Test]
        [TestCase("Pehso", 100, 150)]
        public void ConstructorShouldInitializeNewWarrior(string name, int damage, int healthPoints)
        {
            var warrior = new Warrior(name, damage, healthPoints);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(healthPoints, warrior.HP);
        }

        [Test]
        [TestCase(null, 100, 150)]
        [TestCase("", 100, 150)]
        [TestCase(" ", 100, 150)]
        public void NameShouldThrowExceptionIfIsNullEmptyOrWhitespace(string name, int damage, int healthPoints)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, damage, healthPoints));
        }

        [Test]
        [TestCase("Pehso", 0, 150)]
        [TestCase("Pehso", -1, 150)]
        public void DamageShouldThrowExceptionIfNonPositive(string name, int damage, int healthPoints)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, damage, healthPoints));
        }

        [Test]
        [TestCase("Pehso", 100, -1)]
        public void HPShouldThrowExceptionIfNegative(string name, int damage, int healthPoints)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, damage, healthPoints));
        }

        [Test]
        [TestCase("Pehso", 100, 29)]
        [TestCase("Pehso", 100, 30)]
        public void Attack_ShouldThrowExceptionIfAttackerHPAreLessOrEqualTo30(string name, int damage, int healthPoints)
        {
            var attacker = new Warrior(name, damage, healthPoints);
            var defender = new Warrior("Gosho", 10, 400);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }

        [Test]
        [TestCase("Pehso", 100, 29)]
        [TestCase("Pehso", 100, 30)]
        public void Attack_ShouldThrowExceptioDefenderHPAreLessOrEqualTo30(
            string name, int damage, int healthPoints)
        {
            var attacker = new Warrior("Gosho", 10, 400);
            var defender = new Warrior(name, damage, healthPoints);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrowExceptionIfAttackerHPIsLessThanDefenderDamage()
        {
            var attacker = new Warrior("Pehso", 100, 100);
            var defender = new Warrior("Gosho", 200, 100);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldReduceAttackerHPWithDefenderDamage()
        {
            var attacker = new Warrior("Pehso", 100, 200);
            var defender = new Warrior("Gosho", 100, 400);

            var expectedAttackerHP = attacker.HP - defender.Damage;

            attacker.Attack(defender);
            var actualAttackerHP = attacker.HP;

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
        }

        [Test]
        public void Attack_ShouldReduceDefenderHPWithAttackerDamage()
        {
            var attacker = new Warrior("Pehso", 100, 200);
            var defender = new Warrior("Gosho", 100, 400);

            var expectedDefenderHP = defender.HP - attacker.Damage;

            attacker.Attack(defender);
            var actualDefenderHP = defender.HP;

            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
        }

        [Test]
        public void Attack_ShoudWorkCorrectly()
        {
            var attacker = new Warrior("Pehso", 100, 200);
            var defender = new Warrior("Gosho", 100, 400);

            var expectedAttackerHP = attacker.HP - defender.Damage;
            var expectedDefenderHP = defender.HP - attacker.Damage;

            attacker.Attack(defender);

            var actualAttackerHP = attacker.HP;
            var actualDefenderHP = defender.HP;

            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
        }

        [Test]
        public void Attack_ShoudReduceEnemysHPWithDamageNoMoreThanZero()
        {
            var attacker = new Warrior("Pehso", 100, 200);
            var defender = new Warrior("Gosho", 100, 50);

            var expectedAttackerHP = attacker.HP - defender.Damage;
            var expectedDefenderHP = 0;

            attacker.Attack(defender);

            var actualAttackerHP = attacker.HP;
            var actualDefenderHP = defender.HP;

            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
        }
    }
}