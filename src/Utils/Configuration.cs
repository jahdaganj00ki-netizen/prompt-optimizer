using System;
using System.Configuration;

namespace PromptOptimizer.Utils
{
    public class Configuration
    {
        public static string GetDatabaseFile()
        {
            return ConfigurationManager.AppSettings["DatabaseFile"] ?? "prompt_optimizer.db";
        }

        public static string GetLogLevel()
        {
            return ConfigurationManager.AppSettings["LogLevel"] ?? "Info";
        }

        public static int GetAPITimeout()
        {
            int.TryParse(ConfigurationManager.AppSettings["APITimeout"], out int timeout);
            return timeout > 0 ? timeout : 30;
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["PromptOptimizerDb"]?.ConnectionString 
                ?? "Data Source=prompt_optimizer.db";
        }
    }
}
