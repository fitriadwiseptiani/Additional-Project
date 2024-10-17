namespace FibonacciSeries.Test;

public class FibonacciSeriesTest
{
    private FibonacciCalculator _fibonacciCalculator;

    [SetUp]
    public void Setup()
    {
        _fibonacciCalculator = new FibonacciCalculator();
    }

    // Test manually with given number
    [Test]
    public void Generate_ReturnCorrectResult()
    {
        // Arrange
        int n = 3;

        IEnumerable<int> expected = new int[] { 0, 1, 1};

        // Act
        IEnumerable<int> result = _fibonacciCalculator.Generate(n);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Test with several condition
    [TestCase(2, new int[] { 0, 1 })]
    [TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
    [TestCase(-5, new int[] { -5 })]
    [TestCase(50, new int[] {0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,514229,832040,1346269,2178309,3524578,5702887,9227465,14930352,24157817,39088169,63245986,102334155,165580141,267914296,433494437,701408733,1134903170,1836311903
})]
    public void Generate_ReturnCorrectResult(int n, IEnumerable<int> expected)
    {
        // Act
        IEnumerable<int> result = _fibonacciCalculator.Generate(n);
        // Assert
        Assert.AreEqual(expected, result.ToArray());
    }

    [Test]
    // Negative Case
    //When given a zero 
    public void Generate_ReturnThrowException_AddingZero()
    {
        int n = 0;

        Assert.Throws<Exception>(() => _fibonacciCalculator.Generate(n));
    }
}