using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PromptOptimizer.Utils;

namespace PromptOptimizer.AI
{
    public class GoogleAIConnector
    {
        private const string GOOGLE_API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";
        private string apiKey;
        private Logger logger = new Logger();

        public async Task<bool> TestConnectionAsync(string key)
        {
            try
            {
                apiKey = key;
                string testPrompt = "Say 'OK' only.";
                string response = await OptimizePromptAsync(testPrompt);
                return !string.IsNullOrEmpty(response);
            }
            catch (Exception ex)
            {
                logger.Log($"Google AI connection test failed: {ex.Message}");
                return false;
            }
        }

        public async Task<string> OptimizePromptAsync(string originalPrompt)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("Google AI API key not set");

            try
            {
                using (var client = new HttpClient())
                {
                    var requestBody = new
                    {
                        contents = new[]
                        {
                            new
                            {
                                parts = new[]
                                {
                                    new
                                    {
                                        text = $"You are a prompt optimization expert. Improve the given prompt to be clearer, more specific, and more complete. Return only the optimized prompt.\n\nOptimize this prompt:\n\n{originalPrompt}"
                                    }
                                }
                            }
                        }
                    };

                    var json = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    string url = $"{GOOGLE_API_URL}?key={apiKey}";
                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseContent);
                    string optimizedPrompt = result.candidates[0].content.parts[0].text;

                    logger.Log($"Google AI optimization successful");
                    return optimizedPrompt;
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Google AI optimization error: {ex.Message}");
                throw;
            }
        }
    }
}
