using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class ONP
    {
        private List<string> list = new List<string>();
        private int[] operandsPriority = { 1, 1, 2, 3 };
        private string[] operands = { "+", "-", "*", "/" };
        private string[] brackeys = { "(", ")", "=" };

        #region Constructors
        public ONP()
        {

        }

        // Constructor only for tests
        public ONP(string[] expression)
        {
            foreach (var s in expression)
            {
                if (Regex.IsMatch(s, @"\d") || operands.Contains(s) || brackeys.Contains(s))
                {
                    list.Add(s);
                }
                else
                {
                    throw new ArgumentException("Array elements must be digits or math operators!");
                }
            }
        }
        #endregion

        public void Clear() => list.Clear();

        public void Add(string element)
        {
            if (IsCorrect(element))
            {
                list.Add(element);
            }
            else
            {
                throw new ArgumentException("Element is not valid in this place.");
            }
        }

        private bool IsCorrect(string element)
        {
            int len = list.Count;

            if (len > 0 && list.Last() == "=") return false;

            if (operands.Contains(element))
            {
                if (len == 0) return false;
                if (operands.Contains(list[len - 1])) return false;
            }

            //if (element == ")" && NumberOf(")") != NumberOf("(") - 1) return false;

            return true;
        }

        private int NumberOf(string element)
        {
            int num = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] == element)
                    num++;
            }
            return num;
        }

        public string GetFirst()
        {
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public string GetLast()
        {
            if (list.Count > 0)
                return list[list.Count - 1];
            return null;
        }

        public bool LastIsDigit()
        {
            if (list.Count > 0 && Regex.IsMatch(list.Last(), @"\d"))
                return true;
            return false;
        }

        private int PriorityOf(string operand)
        {
            for (int i = 0; i < operands.Length; i++)
            {
                if(operand == operands[i])
                {
                    return operandsPriority[i];
                }
            }
            return 0;
        }

        private List<string> TransformToONP(List<string> expression)
        {
            List<string> exit = new List<string>();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < expression.Count; i++)
            {
                var element = expression[i];
                if(Regex.IsMatch(element, @"\d"))
                {
                    exit.Add(element);
                }
                else if(element == "(")
                {
                    stack.Push(element);
                }
                else if(operands.Contains(element) && stack.Count == 0)
                {
                    stack.Push(element);
                }
                else if (operands.Contains(element) && stack.Count > 0 && PriorityOf(element) < PriorityOf(stack.Peek()))
                {
                    while(stack.Count > 0 && PriorityOf(element) < PriorityOf(stack.Peek()))
                    {
                        exit.Add(stack.Pop());
                    }
                    stack.Push(element);
                }
                else if (operands.Contains(element) && stack.Count > 0 && PriorityOf(element) >= PriorityOf(stack.Peek()))
                {
                    stack.Push(element);
                }
                else if (element == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        exit.Add(stack.Pop());
                    }
                    stack.Pop();
                }
                else if (element == "=")
                {
                    while (stack.Count() > 0)
                    {
                        exit.Add(stack.Pop());
                    }
                }
            }

            foreach(string s in exit)
            {
                Debug.Write(s + " ");
            }

            return exit;
        }

        public double Count()
        {
            List<string> exp = TransformToONP(list);
            Stack<string> stack = new Stack<string>();
    
            for (int i = 0; i < exp.Count; i++)
            {
                var element = exp[i];
                if (Regex.IsMatch(element, @"\d"))
                {
                    stack.Push(element);
                }
                else if(operands.Contains(element))
                {
                    double num1 = Double.Parse(stack.Pop());
                    double num2 = Double.Parse(stack.Pop());
                    stack.Push(Operation(element, num2, num1).ToString());
                }
            }

            return Double.Parse(stack.Pop());
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
    }
}
