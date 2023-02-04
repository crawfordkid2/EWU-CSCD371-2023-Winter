using System;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IJokeServices _service;
        private readonly IJokeDisplay _display;

        public Jester(IJokeDisplay? thisdisplay, IJokeServices? thisservice)
        {
            if(thisservice == null)
            {
                throw new ArgumentNullException(nameof(thisdisplay));
            }
            if (thisdisplay == null)
            {
                throw new ArgumentNullException(nameof(thisdisplay));
            }

            this._service = thisservice;
            this._display = thisdisplay;
        }
        
        public string? Joke { get; set; }

        public void TellAJoke()
        {
            string joke = _service.GetJoke();
            while(joke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase))
            {
                joke = _service.GetJoke();
            }
            _display.Display(joke);
            Joke = joke;
        }

    }
}
