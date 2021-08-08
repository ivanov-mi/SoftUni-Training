using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 10;
        private const int HealthyAxeDurability = 10;
        private const int BrokenAxeDurability = 0;
        private const int DummyHealth = 20;
        private const int DummyExperience = 20;
        private Dummy dummy;
        private Axe axe;

        [Test]
        public void AxeLoosesDurabilityAfterEachAttack()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
            this.axe = new Axe(AxeAttack, HealthyAxeDurability);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints < HealthyAxeDurability, "Weapon durability doesn`t change after attack");
        }

        [Test]
        public void ShouldNotAttackWithBrokenAxe()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
            this.axe = new Axe(AxeAttack, BrokenAxeDurability);

            Assert.That(
                () => axe.Attack(dummy), 
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}