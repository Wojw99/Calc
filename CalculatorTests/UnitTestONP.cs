using Calculator;
using System;
using Xunit;

namespace CalculatorTests
{
    public class UnitTestONP
    {
        [Fact]
        public void Test1()
        {
            Counter onp = new Counter(new string[] { "3","*","4","/","2","="});
            double expected = 6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test2()
        {
            Counter onp = new Counter(new string[] { "(", "(", "8", "/", "4", ")" ,"/", "2", ")", "/", "2", "=" });
            double expected = 0.5;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test3()
        {
            Counter onp = new Counter(new string[] { "8", "/", "4", "*", "2", "=" });
            double expected = 4;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test4()
        {
            Counter onp = new Counter(new string[] { "8", "*", "4", "*", "2", "=" });
            double expected = 64;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test5()
        {
            Counter onp = new Counter(new string[] { "18", "*", "9", "*", "9", "=" });
            double expected = 1458;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test6()
        {
            Counter onp = new Counter(new string[] { "(", "8", "/", "4", ")", "/", "2", "=" });
            double expected = 1;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test7()
        {
            Counter onp = new Counter(new string[] { "8", "*", "9,5", "*", "2,1", "=" });
            double expected = 159.6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test8()
        {
            Counter onp = new Counter(new string[] { "8", "*", "9,5", "*", "-2,1", "=" });
            double expected = -159.6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test9()
        {
            Counter onp = new Counter(new string[] { "-8", "*", "-9,5", "*", "2,1", "=" });
            double expected = 159.6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test10()
        {
            Counter onp = new Counter(new string[] { "567", "*", "999", "/", "321", "=" });
            double expected = 1764.588785046729;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test11()
        {
            Counter onp = new Counter(new string[] { "(", "-2", ")", "/", "2", "=" });
            double expected = -1;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }
    }
}
