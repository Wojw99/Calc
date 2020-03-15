using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string[] brackeys = { "(", ")" , "="};

        #region Constructors
        public ONP()
        {

        }

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

        public void Add(string element) => list.Add(element);

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
