using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise.Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new ExpressionProcessor();
            Console.WriteLine(processor.Calculate("1 + 2 + 3"));
            Console.WriteLine(processor.Calculate("1 + 2 + xy"));
            processor.Variables.Add('x', 3);
            Console.WriteLine(processor.Calculate("10 - 2 - x"));
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        private enum Operator
        {
            Plus, Minus
        }

        public int Calculate(string expression)
        {
            expression = expression.Replace(" ", string.Empty);

            int result = 0;
            Operator lastOperator = Operator.Plus;

            for (int i = 0; i < expression.Length; ++i)
            {
                if (expression[i].Equals('+'))
                {
                    lastOperator = Operator.Plus;
                }

                else if (expression[i].Equals('-'))
                {
                    lastOperator = Operator.Minus;
                }

                else if (char.IsLetter(expression[i]))
                {
                    if (i + 1 != expression.Length && char.IsLetter(expression[i+1]))
                    {
                        return 0;
                    }

                    result = ApplyOperator(lastOperator, Variables[expression[i]], result);
                }

                else if (char.IsDigit(expression[i]))
                {
                    var sb = new StringBuilder();
                    sb.Append(expression[i]);
                    int j = i;

                    while (j + 1 < expression.Length)
                    {
                        if (!char.IsDigit(expression[j + 1]))
                        {
                            i = j;
                            break;
                        }

                        ++j;
                        sb.Append(expression[j]);
                    }

                    var amount = int.Parse(sb.ToString());
                    result = ApplyOperator(lastOperator, amount, result);
                }
            }

            return result;
        }

        private int ApplyOperator(Operator @operator, int amount, int initial)
        {
            switch (@operator)
            {
                case Operator.Plus:
                    return initial + amount;
                case Operator.Minus:
                    return initial - amount;
                default:
                    return initial;
            }
        }
    }
}
