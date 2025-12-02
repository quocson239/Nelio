using NUnit.Framework;


public class SumTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void SumText_1_1_Expected_2() =>Assert.AreEqual(2, MyMath.Sum(1, 1));

    [Test]
    public void SumText_Negative1_2_Expected_1()
    {
        int result = MyMath.Sum(-1, 2);
        int expected = 1;
        Assert.AreEqual(expected, result);
    }
    [Test]
    [TestCase(1,1,2)]
    [TestCase(-1, 1, 0)]
    [TestCase(-1, 5, 4)]
    public void SumTests(int a,int b, int expected)
    {
        Assert.AreEqual(expected,MyMath.Sum(a, b));
    }
    [Test]
    [TestCase(2,1,2)]
    [TestCase(-4, 2, -2)]
    [TestCase(5, -5, -1)]
    [TestCase(1,2,0.5f)]
    public void DivideTest(float a,float b, float expected)
    {
        Assert.AreEqual(expected, MyMath.Divide(a, b));
    }
    [Test]
    public void DivideByZero()
    {
        Assert.Throws<System.DivideByZeroException>(() => MyMath.Divide(1, 0));
    }

    [Test]
    [TestCase(1,1,-1)]
    [TestCase(0,0,1)] 
    public void SolveEquationTest(float a,float b,float expected)
    {
        Assert.AreEqual(expected, new MyMath().SolveEquation(a, b));
    }
    [Test]
    public void SolveEquation_NoSolution()
    {
        Assert.Throws<System.Exception>(() => new MyMath().SolveEquation(0, 1));
    }
}
