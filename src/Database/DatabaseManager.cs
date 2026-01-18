using System;
using System.Data.SQLite;
using System.Configuration;

namespace PromptOptimizer.Database
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PromptOptimizerDb"].ConnectionString;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string createTableSQL = @"
                        CREATE TABLE IF NOT EXISTS Prompts (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            OriginalPrompt TEXT NOT NULL,
                            OptimizedPrompt TEXT,
                            ClarityScore REAL,
                            SpecificityScore REAL,
                            CompletenessScore REAL,
                            OverallScore REAL,
                            CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                        )";

                    using (var command = new SQLiteCommand(createTableSQL, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Database initialization error: {ex.Message}");
            }
        }

        public void SavePromptAnalysis(string original, string optimized, double clarity, double specificity, double completeness, double overall)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string insertSQL = @"
                        INSERT INTO Prompts (OriginalPrompt, OptimizedPrompt, ClarityScore, SpecificityScore, CompletenessScore, OverallScore)
                        VALUES (@original, @optimized, @clarity, @specificity, @completeness, @overall)";

                    using (var command = new SQLiteCommand(insertSQL, connection))
                    {
                        command.Parameters.AddWithValue("@original", original);
                        command.Parameters.AddWithValue("@optimized", optimized ?? "");
                        command.Parameters.AddWithValue("@clarity", clarity);
                        command.Parameters.AddWithValue("@specificity", specificity);
                        command.Parameters.AddWithValue("@completeness", completeness);
                        command.Parameters.AddWithValue("@overall", overall);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving prompt analysis: {ex.Message}");
            }
        }
    }
}
