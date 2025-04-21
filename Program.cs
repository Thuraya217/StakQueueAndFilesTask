namespace StakQueueAndFilesTask
{
    internal class Program
    {
        static void Main(string[] args)
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



    }

}
    
