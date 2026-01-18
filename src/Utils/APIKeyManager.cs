using System;
using System.IO;
using Newtonsoft.Json;

namespace PromptOptimizer.Utils
{
    public class APIKeys
    {
        [JsonProperty("groq_key")]
        public string GroqKey { get; set; }

        [JsonProperty("google_key")]
        public string GoogleKey { get; set; }
    }

    public class APIKeyManager
    {
        private string keyFilePath;
        private Logger logger = new Logger();

        public APIKeyManager()
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "PromptOptimizer"
            );

            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);

            keyFilePath = Path.Combine(appDataPath, "api_keys.json");
        }

        public void SaveKeys(string groqKey, string googleKey)
        {
            try
            {
                var keys = new APIKeys
                {
                    GroqKey = groqKey,
                    GoogleKey = googleKey
                };

                string json = JsonConvert.SerializeObject(keys, Formatting.Indented);
                File.WriteAllText(keyFilePath, json);
                logger.Log("API keys saved successfully");
            }
            catch (Exception ex)
            {
                logger.LogError("Error saving API keys", ex);
                throw;
            }
        }

        public APIKeys LoadKeys()
        {
            try
            {
                if (!File.Exists(keyFilePath))
                    return null;

                string json = File.ReadAllText(keyFilePath);
                var keys = JsonConvert.DeserializeObject<APIKeys>(json);
                logger.Log("API keys loaded successfully");
                return keys;
            }
            catch (Exception ex)
            {
                logger.LogError("Error loading API keys", ex);
                return null;
            }
        }

        public void DeleteKeys()
        {
            try
            {
                if (File.Exists(keyFilePath))
                {
                    File.Delete(keyFilePath);
                    logger.Log("API keys deleted");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error deleting API keys", ex);
            }
        }
    }
}
