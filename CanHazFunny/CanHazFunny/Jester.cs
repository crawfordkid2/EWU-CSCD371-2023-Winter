using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly InterfaceJokeServices service;
        private readonly InterfaceJokeDisplay display;

        public Jester(InterfaceJokeDisplay? thisdisplay, InterfaceJokeServices? thisservice)
        {
            if(thisservice == null)
            {
                throw new System.ArgumentNullException(nameof(thisservice));
            }
            if (thisdisplay == null)
            {
                throw new System.ArgumentNullException(nameof(thisdisplay));
            }

            this.service = thisservice;
            this.display = thisdisplay;
        }
        
        public string? Joke { get; set; }

        public void TellAJoke()
        {
            string joke = service.GetJoke();
            while(joke.ToLower().Contains("chuck norris"))
            {
                joke = service.GetJoke();
            }
            display.Display(joke);

        }

    }
}
