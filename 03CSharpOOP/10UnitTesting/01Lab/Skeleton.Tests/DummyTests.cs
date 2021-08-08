using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AliveDummyHealth = 10;
        private const int DeadDummyHealth = 0;
        private const int DummyExperience = 10;
        private const int AttackPoints = 5;
        private Dummy AliveDummy;
        private Dummy DeadDummy;

        [SetUp]
        public void TestInit()
        {
             this.AliveDummy = new Dummy(AliveDummyHealth, DummyExperience);
             this.DeadDummy = new Dummy(DeadDummyHealth, DummyExperience);
        }
        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            this.AliveDummy.TakeAttack(AttackPoints);

            Assert.That(AliveDummy.Health == (AliveDummyHealth - AttackPoints), "Dummy health doesn`t change after attack.");
        }

        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Assert.That( () => this.DeadDummy.TakeAttack(AttackPoints), 
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }

        public void DeadDummyCanGiveXP()
        {
            Assert.That(this.DeadDummy.GiveExperience() == DummyExperience, "Dead Dummy doesn`t give XP.");
        }

        public void AliveDummyCanGiveXP()
        {
            Assert.That(this.AliveDummy.GiveExperience() == DummyExperience, "Dead Dummy gives XP.");
        }
    }
}
