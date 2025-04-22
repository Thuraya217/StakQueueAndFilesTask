using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace StakQueueAndFilesTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Reverse a String Using Stack
            Console.Write("Enter world to reverse: ");
            string input = Console.ReadLine();

            // Evaluate Postfix Expression
            string expression = "5 3 + 8 *";
            int result = EvaluatePostfixExpression(expression);
            Console.WriteLine($"Result: {expression} {result}");

            // XML/HTML Tag Validator
            Console.WriteLine("Enter HTML/XML string to validate:");
            string inputTag = Console.ReadLine();

            bool isValid = XMLHTMLTagValidator(input);
            Console.WriteLine($"Tags are {(isValid ? "valid " : "invalid ")}");

            // Prompt user to enter file path
            Console.Write("Enter the file path: ");
            string filePath = Console.ReadLine();
            // Call the method to count lines, words, and characters
            CountLinesWordsAndCharacters(filePath);
        }

        // Reverse a String Using Stack
        static void ReverseAStringUsingStack(string input)
        {
            //Reverse a String Using Stack
            

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

        // Evaluate Postfix Expression
        static int EvaluatePostfixExpression(string expression)
        {
            Stack<int> stack = new Stack<int>();
            string[] tokens = expression.Split(' ');

            foreach (string token in expression.Split(' '))
            {
                if (int.TryParse(token, out int number))
                {
                    // If token is a number, push it onto the stack
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
            // Final result is on top of the stack
            return stack.Pop();
        }

        //static string BrowserHistoryNavigation(string[] args)
        //{

        //}

        // XML/HTML Tag Validator 
        static bool XMLHTMLTagValidator(string inputTag)
        {
            Stack<string> tagStack = new Stack<string>();

            // to match tags like <tag>, </tag>
            Regex tagPattern = new Regex(@"</?([a-zA-Z][a-zA-Z0-9]*)[^>]*>");

            foreach (Match match in tagPattern.Matches(inputTag))
            {
                string tag = match.Value;
                string tagName = match.Groups[1].Value;

                if (tag.StartsWith("</"))
                {
                    // Closing tag
                    if (tagStack.Count == 0 || tagStack.Peek() != tagName)
                    {
                        return false;
                    }
                    tagStack.Pop();
                }
                else if (!tag.EndsWith("/>"))
                {
                    // Opening tag 
                    tagStack.Push(tagName);
                }
            }

            return tagStack.Count == 0;
        }

        //Count Lines, Words, and Characters
        static void CountLinesWordsAndCharacters(string filePath)
        {
            int lineCount = 0;
            int wordCount = 0;
            int charCount = 0;

            // Read the file line by line
            foreach (string line in File.ReadLines(filePath))
            {
                lineCount++;  // Increment line count
                charCount += line.Length;  // Add the length of the current line to the character count

                // Count words by splitting the line into words and checking if they are not empty
                string[] words = line.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                wordCount += words.Length;
            }

            // Display the results
            Console.WriteLine($"Lines: {lineCount}");
            Console.WriteLine($"Words: {wordCount}");
            Console.WriteLine($"Characters: {charCount}");
        }

    }            
}


    
