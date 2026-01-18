using System;
using System.Windows.Forms;
using PromptOptimizer.Engine;
using PromptOptimizer.AI;
using PromptOptimizer.Utils;

namespace PromptOptimizer.UI
{
    public partial class MainForm : Form
    {
        private PromptAnalyzer analyzer;
        private PromptOptimizer optimizer;
        private GroqConnector groqConnector;
        private GoogleAIConnector googleConnector;
        private Logger logger;

        public MainForm()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            logger = new Logger();
            analyzer = new PromptAnalyzer();
            groqConnector = new GroqConnector();
            googleConnector = new GoogleAIConnector();
            optimizer = new PromptOptimizer(groqConnector, googleConnector);
        }

        private void btnAPISettings_Click(object sender, EventArgs e)
        {
            using (APISettingsForm settingsForm = new APISettingsForm())
            {
                settingsForm.ShowDialog(this);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string prompt = txtOriginalPrompt.Text;
            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("Please enter a prompt to analyze.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var scores = analyzer.Analyze(prompt);
            DisplayAnalysisResults(scores);
        }

        private void DisplayAnalysisResults(AnalysisScores scores)
        {
            lblClarityScore.Text = $"Clarity: {scores.Clarity:F1}%";
            lblSpecificityScore.Text = $"Specificity: {scores.Specificity:F1}%";
            lblCompletenessScore.Text = $"Completeness: {scores.Completeness:F1}%";
            lblOverallScore.Text = $"Overall: {scores.Overall:F1}%";
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            string prompt = txtOriginalPrompt.Text;
            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("Please enter a prompt to optimize.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGenerate.Enabled = false;
            btnGenerate.Text = "Generating...";

            try
            {
                string optimized = await optimizer.OptimizeAsync(prompt);
                txtOptimizedPrompt.Text = optimized;
                logger.Log($"Optimization completed for prompt: {prompt.Substring(0, Math.Min(50, prompt.Length))}...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during optimization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Log($"Error: {ex.Message}");
            }
            finally
            {
                btnGenerate.Enabled = true;
                btnGenerate.Text = "Generate Optimization";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOptimizedPrompt.Text))
            {
                Clipboard.SetText(txtOptimizedPrompt.Text);
                MessageBox.Show("Optimized prompt copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No optimized prompt to copy.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
