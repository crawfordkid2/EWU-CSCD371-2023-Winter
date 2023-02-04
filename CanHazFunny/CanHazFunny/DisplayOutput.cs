using System;

namespace CanHazFunny
{
    public class DisplayOutput : IJokeDisplay
    {
        public void Display(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
