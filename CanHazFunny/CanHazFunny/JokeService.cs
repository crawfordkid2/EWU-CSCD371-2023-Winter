using System.Net.Http;
using System.Text.Json;

namespace CanHazFunny
{
    public class JokeService : IJokeServices
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            // Extra credit: Read as json and deserialize to object
            string jsonString = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
            Content? content = JsonSerializer.Deserialize<Content>(jsonString);
            return content?.joke ?? "";
        }

        private class Content
        {
            public string? joke { get; set; }
        }
    }
}
