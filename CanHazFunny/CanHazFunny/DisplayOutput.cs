using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
