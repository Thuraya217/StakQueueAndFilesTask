using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace StakQueueAndFilesTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = "5 3 + 8 *";
            int result = EvaluatePostfixExpression(expression);
            Console.WriteLine($"Result: {expression} {result}");
        }

        static void ReverseAStringUsingStack(string[] args)
        {
            //Reverse a String Using Stack
            Console.Write("Enter world to reverse: ");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();//Creates a new stack 

            foreach (char c in input) // Push each character to the stack
            {
                stack.Push(c);
            }

            string revers = ""; // Pop characters to reversed the string
            while (stack.Count > 0)
            {
                revers += stack.Pop();
            }
            Console.WriteLine("Reversed string: " + revers);
        }

        static int EvaluatePostfixExpression(string expression)
        {
            Stack<int> stack = new Stack<int>();
            string[] tokens = expression.Split(' ');

            foreach (string token in expression.Split(' '))
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(number);
                }
                else
                {

                    int b = stack.Pop();
                    int a = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "*":
                            stack.Push(a * b);
                            break;
                        case "/":
                            stack.Push(a / b);
                            break;
                        default:
                            throw new InvalidOperationException($"Unknown operator: {token}");
                    }
                }
            }

            return stack.Pop();
        }


        }            
}


    
