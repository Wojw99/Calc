using Calculator;
using System;
using Xunit;

namespace CalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calc = new Counter();
            calc.Add("3");
            calc.Add("*");
            calc.Add("4");
            calc.Add("/");
            calc.Add("2");
            string expected = "6";

            string result = calc.Count();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test2()
        {
            var calc = new Counter();
            calc.Add("8");
            calc.Add("/");
            calc.Add("4");
            calc.Add("/");
            calc.Add("2");
            calc.Add("/");
            calc.Add("2");
            calc.Add("/");
            calc.Add("2");
            string expected = "0,25";

            string result = calc.Count();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test3()
        {
            var calc = new Counter();
            calc.Add("8");
            calc.Add("/");
            calc.Add("4");
            calc.Add("*");
            calc.Add("2");
            string expected = "4";

            string result = calc.Count();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test4()
        {
            var calc = new Counter();
            calc.Add("8");
            calc.Add("*");
            calc.Add("4");
            calc.Add("*");
            calc.Add("2");
            string expected = "64";

            string result = calc.Count();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test5()
        {
            var calc = new Counter();
            calc.Add("8");
            calc.Add("*");
            calc.Add("9");
            calc.Add("*");
            calc.Add("9");
            string expected = "648";

            string result = calc.Count();

            Assert.Equal(expected, result);
        }
    }
}
