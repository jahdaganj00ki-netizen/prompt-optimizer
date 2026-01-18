using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PromptOptimizer.Utils;

namespace PromptOptimizer.AI
{
    public class GroqConnector
    {
        private const string GROQ_API_URL = "https://api.groq.com/openai/v1/chat/completions";
        private const string MODEL = "llama-3.3-70b-versatile";
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
                logger.Log($"Groq connection test failed: {ex.Message}");
                return false;
            }
        }

        public async Task<string> OptimizePromptAsync(string originalPrompt)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidOperationException("Groq API key not set");

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                    var requestBody = new
                    {
                        model = MODEL,
                        messages = new[]
                        {
                            new { role = "system", content = "You are a prompt optimization expert. Improve the given prompt to be clearer, more specific, and more complete. Return only the optimized prompt." },
                            new { role = "user", content = $"Optimize this prompt:\n\n{originalPrompt}" }
                        },
                        max_tokens = 1000,
                        temperature = 0.7
                    };

                    var json = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(GROQ_API_URL, content);
                    response.EnsureSuccessStatusCode();

                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseContent);
                    string optimizedPrompt = result.choices[0].message.content;

                    logger.Log($"Groq optimization successful");
                    return optimizedPrompt;
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Groq optimization error: {ex.Message}");
                throw;
            }
        }
    }
}
