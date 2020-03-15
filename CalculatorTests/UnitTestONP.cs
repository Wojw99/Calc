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
            ONP onp = new ONP(new string[] { "8", "*", "9", "*", "9", "=" });
            double expected = 648;
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
    }
}
