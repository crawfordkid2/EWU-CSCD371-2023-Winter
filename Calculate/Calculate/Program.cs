using Calculate;
namespace Calculate;
using System;
    public class Program
    {

        public static void Main()
        {
            var calc = new Calculator();

            while(true)
            {
                Console.WriteLine("Type a Mathmatical Equation " +
                    "\n (Ex: x+y, x-y, x*y, x/y)" +
                    "\n make sure to put a space between characters and symbols");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                if(calc.TryCalculate(input,out var result))
                {
                    Console.WriteLine(result); break;

                }
                else
                {
                    Console.WriteLine("Invalid equation ");
                }
                



            }


        }

        public Action<string> WriteLine { get; init; } = x => Console.WriteLine(x);

        public Func<string?> ReadLine { get; init; } = () => Console.ReadLine();


    }
