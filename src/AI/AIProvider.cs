using System.Threading.Tasks;

namespace PromptOptimizer.AI
{
    public interface IAIProvider
    {
        Task<string> OptimizePromptAsync(string originalPrompt);
        Task<bool> TestConnectionAsync(string apiKey);
    }

    public class AIProvider
    {
        private GroqConnector groq;
        private GoogleAIConnector google;

        public AIProvider()
        {
            groq = new GroqConnector();
            google = new GoogleAIConnector();
        }

        public GroqConnector GetGroqConnector()
        {
            return groq;
        }

        public GoogleAIConnector GetGoogleConnector()
        {
            return google;
        }
    }
}
