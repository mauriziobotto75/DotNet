using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeGenerator.Services
{
    public class JokeService
    {
        private readonly HttpClient _httpClient;
        private const string JokeApiUrl = "https://api.api-ninjas.com/v1/jokes";
        private const string JokeApiKey = "YOUR_API_KEY_HERE"; // Get from https://api-ninjas.com/

        public JokeService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Fetches a random joke from the API
        /// </summary>
        public async Task<Joke> GetRandomJokeAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, JokeApiUrl);
                request.Headers.Add("X-Api-Key", JokeApiKey);

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var jokes = JsonConvert.DeserializeObject<Joke[]>(jsonContent);

                return jokes?.Length > 0 ? jokes[0] : null;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching joke from API: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error parsing joke response: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Fetches a random joke by category
        /// </summary>
        public async Task<Joke> GetJokeByCategoryAsync(string category)
        {
            try
            {
                var url = $"{JokeApiUrl}?category={category}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("X-Api-Key", JokeApiKey);

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var jokes = JsonConvert.DeserializeObject<Joke[]>(jsonContent);

                return jokes?.Length > 0 ? jokes[0] : null;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching joke by category: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets available joke categories
        /// </summary>
        public string[] GetAvailableCategories()
        {
            return new[]
            {
                "general",
                "programming",
                "knock-knock"
            };
        }
    }
