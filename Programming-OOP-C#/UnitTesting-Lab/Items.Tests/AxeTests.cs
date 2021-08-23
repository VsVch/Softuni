using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{

    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;
    
    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(5, 6);
    }

    [Test]
    public void WhenAxeAttackAndDourabilityProvidedShouldBeSetCorectly()
    {       
        Assert.AreEqual(axe.AttackPoints, this.attack);
        Assert.AreEqual(axe.DurabilityPoints, this.durability);
    }

    [Test]
    public void WhenAxeAttacksShouldloseDorabilityPoints()
    {
        axe.Attack(dummy);

        Assert.AreEqual(axe.DurabilityPoints, durability - 1);
    }
    [Test]

    public void WhenAxeAttackWhitDurabilityPointsZeroShouldBeeThrowExeption() 
    {
        dummy = new Dummy(5000, 5000);
        InvalidOperationException ex =            
        Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(dummy);
            }
        });

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }

    [Test]
    public void WhenAxeAttackIsCalledWhitNullDummyShouldThrowNullRef() 
    {
        Assert.Throws<NullReferenceException>(() => 
        { 
            axe.Attack(null); 
        });
    
    }
}