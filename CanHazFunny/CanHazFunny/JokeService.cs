using System.Net.Http;

namespace CanHazFunny
{
    public class JokeService :InterfaceJokeServices
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
            return JokeFormat(joke);
        }
        
        private static string JokeFormat(string unfJoke)
        {
            string bareString = unfJoke.Remove(0, 10);
            int index = bareString.Length;
            bareString = bareString.Remove(index - 3, 3);
            return bareString;

        }


    }
}
