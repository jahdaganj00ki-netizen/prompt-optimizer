using System;
using System.IO;

namespace PromptOptimizer.Utils
{
    public class Logger
    {
        private string logPath;

        public Logger()
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "PromptOptimizer"
            );

            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);

            logPath = Path.Combine(appDataPath, "app.log");
        }

        public void Log(string message)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                File.AppendAllText(logPath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logging error: {ex.Message}");
            }
        }

        public void LogError(string message, Exception ex)
        {
            Log($"ERROR: {message} - {ex?.Message}");
        }
    }
}
