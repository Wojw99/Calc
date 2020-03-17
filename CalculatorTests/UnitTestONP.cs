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
            ONP onp = new ONP(new string[] { "3","*","4","/","2","="});
            double expected = 6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test2()
        {
            ONP onp = new ONP(new string[] { "(", "(", "8", "/", "4", ")" ,"/", "2", ")", "/", "2", "=" });
            double expected = 0.5;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test3()
        {
            ONP onp = new ONP(new string[] { "8", "/", "4", "*", "2", "=" });
            double expected = 4;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test4()
        {
            ONP onp = new ONP(new string[] { "8", "*", "4", "*", "2", "=" });
            double expected = 64;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test5()
        {
            ONP onp = new ONP(new string[] { "18", "*", "9", "*", "9", "=" });
            double expected = 1458;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test6()
        {
            ONP onp = new ONP(new string[] { "(", "8", "/", "4", ")", "/", "2", "=" });
            double expected = 1;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test7()
        {
            ONP onp = new ONP(new string[] { "8", "*", "9,5", "*", "2,1", "=" });
            double expected = 159.6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test8()
        {
            ONP onp = new ONP(new string[] { "8", "*", "9,5", "*", "-2,1", "=" });
            double expected = -159.6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test9()
        {
            ONP onp = new ONP(new string[] { "-8", "*", "-9,5", "*", "2,1", "=" });
            double expected = 159.6;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test10()
        {
            ONP onp = new ONP(new string[] { "567", "*", "999", "/", "321", "=" });
            double expected = 1764.588785046729;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test11()
        {
            ONP onp = new ONP(new string[] { "(", "-2", ")", "/", "2", "=" });
            double expected = -1;
            double result = onp.Count();
            Assert.Equal(expected, result);
        }
    }
}
