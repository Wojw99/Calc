using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Counter
    {
        List<string> list = new List<string>();

        public void Add(string x) => list.Add(x);
        public void Clear() => list.Clear();

        public string GetLastIfDigit()
        {
            if (list.Count > 0)
            {
                var ch = list[list.Count - 1];
                if (Regex.IsMatch(ch, @"\d"))
                    return ch;
                else
                    return "";
            }
            else
            {
                return "";
            }
        }

        public void Back()
        {
            if(list.Count > 0)
            {
                list.RemoveAt(list.Count - 1);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private double Operation(string operand, double num1, double num2)
        {
            if (operand == "/")
                return num1 / num2;
            else if (operand == "*")
                return num1 * num2;
            else if (operand == "+")
                return num1 + num2;
            else 
                return num1 - num2;
        }

        public string GetSeries()
        {
            string series = "";

            foreach(var x in list)
            {
                series += x;
            }

            return series;
        }

        public string Count()
        {
            List<string> series = list;
            string[] order = { "/", "*" };
            string[] noOrder = { "+", "-" };

            foreach(var operand in order)
            {
                for (int i = 0; i < series.Count; i++)
                {
                    if (series[i] == operand)
                    {
                        series[i] = Operation(operand, Double.Parse(series[i - 1]), Double.Parse(series[i + 1])).ToString();
                        series.RemoveAt(i + 1);
                        series.RemoveAt(i - 1);
                        i = 0;
                    }
                }
            }

            for (int i = 0; i < series.Count; i++)
            {
                if (series[i] == noOrder[0])
                {
                    series[i] = Operation(noOrder[0], Double.Parse(series[i - 1]), Double.Parse(series[i + 1])).ToString();
                    series.RemoveAt(i + 1);
                    series.RemoveAt(i - 1);
                    i = 0;
                }
                else if (series[i] == noOrder[1])
                {
                    series[i] = Operation(noOrder[1], Double.Parse(series[i - 1]), Double.Parse(series[i + 1])).ToString();
                    series.RemoveAt(i + 1);
                    series.RemoveAt(i - 1);
                    i = 0;
                }
            }

            return series[0];
        }
    }
}
