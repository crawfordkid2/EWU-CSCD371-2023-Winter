using System;

namespace CanHazFunny
{
    public class DisplayOutput : InterfaceJokeDisplay
    {
        public void Display(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
