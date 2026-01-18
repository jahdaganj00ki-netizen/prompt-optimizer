using System;
using System.Threading.Tasks;
using PromptOptimizer.AI;

namespace PromptOptimizer.Engine
{
    public class PromptOptimizer
    {
        private readonly GroqConnector groqConnector;
        private readonly GoogleAIConnector googleConnector;

        public PromptOptimizer(GroqConnector groq, GoogleAIConnector google)
        {
            groqConnector = groq;
            googleConnector = google;
        }

        public async Task<string> OptimizeAsync(string originalPrompt)
        {
            if (string.IsNullOrWhiteSpace(originalPrompt))
                throw new ArgumentException("Prompt cannot be empty");

            try
            {
                // Try Groq first (primary)
                string optimized = await groqConnector.OptimizePromptAsync(originalPrompt);
                if (!string.IsNullOrEmpty(optimized))
                    return optimized;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Groq optimization failed: {ex.Message}");
            }

            try
            {
                // Fallback to Google AI
                string optimized = await googleConnector.OptimizePromptAsync(originalPrompt);
                if (!string.IsNullOrEmpty(optimized))
                    return optimized;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Google optimization failed: {ex.Message}");
            }

            throw new Exception("Both AI providers failed. Please check your API keys and internet connection.");
        }
    }
}
