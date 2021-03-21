using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private Dummy deadDummy;
    private int healt = 5;
    private int expirience = 5;

    [SetUp]
    public void SetUp ()
    {
        dummy = new Dummy(healt, expirience);
        deadDummy = new Dummy(-5, expirience);
    }

    [Test]
    public void WhenHealtIsProvaidetShouldBeSetCorect()
    {
        Assert.That(dummy.Health, Is.EqualTo(healt));
    }

    [Test]
    public void WhenAttackedShouldDecreacehealt()
    {
        int attackPoint = 3;
        dummy.TakeAttack(attackPoint);

        Assert.That(dummy.Health, Is.EqualTo(healt - attackPoint));
    }

    [Test]
    public void WhenAttackedIsDeadShoudThrow()
    {
       // dummy = new Dummy(-5, expirience);     

        Assert.That(() => 
            {
                deadDummy.TakeAttack(3);
        },Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void WhenHealtIsPositiveShouldBeAlive() 
    {
         Assert.That(dummy.IsDead, Is.EqualTo(false));
    }

    [Test]
    public void WhenHealtIsZeroShouldBeDead()
    {
        dummy = new Dummy(0, expirience);
        Assert.That(dummy.IsDead, Is.EqualTo(true));
    }

    [Test]
    public void WhenHealtIsNegativeShouldBeDead()
    {
        
        Assert.That(deadDummy.IsDead, Is.EqualTo(true));
    }

    [Test]
    public void WhenDeadShouldGaveExperiance() 
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(expirience));
    }

    [Test]
    public void WhenAliveGaveExperianceShouldThrow()
    {
        Assert.That(()=> 
        {
           dummy.GiveExperience();

        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
