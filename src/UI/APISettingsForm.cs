using System;
using System.Windows.Forms;
using PromptOptimizer.Utils;
using PromptOptimizer.AI;

namespace PromptOptimizer.UI
{
    public partial class APISettingsForm : Form
    {
        private APIKeyManager keyManager;
        private GroqConnector groqConnector;
        private GoogleAIConnector googleConnector;

        public APISettingsForm()
        {
            InitializeComponent();
            keyManager = new APIKeyManager();
            groqConnector = new GroqConnector();
            googleConnector = new GoogleAIConnector();
            LoadSavedKeys();
        }

        private void LoadSavedKeys()
        {
            var keys = keyManager.LoadKeys();
            if (keys != null)
            {
                txtGroqKey.Text = keys.GroqKey ?? "";
                txtGoogleKey.Text = keys.GoogleKey ?? "";
            }
        }

        private async void btnTestGroq_Click(object sender, EventArgs e)
        {
            string key = txtGroqKey.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Please enter a Groq API key.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTestGroq.Enabled = false;
            btnTestGroq.Text = "Testing...";

            try
            {
                bool isValid = await groqConnector.TestConnectionAsync(key);
                if (isValid)
                {
                    MessageBox.Show("Groq API key is valid!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Groq API key is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error testing Groq key: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTestGroq.Enabled = true;
                btnTestGroq.Text = "Test Groq Key";
            }
        }

        private async void btnTestGoogle_Click(object sender, EventArgs e)
        {
            string key = txtGoogleKey.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Please enter a Google AI API key.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTestGoogle.Enabled = false;
            btnTestGoogle.Text = "Testing...";

            try
            {
                bool isValid = await googleConnector.TestConnectionAsync(key);
                if (isValid)
                {
                    MessageBox.Show("Google AI API key is valid!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Google AI API key is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error testing Google key: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTestGoogle.Enabled = true;
                btnTestGoogle.Text = "Test Google Key";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string groqKey = txtGroqKey.Text.Trim();
            string googleKey = txtGoogleKey.Text.Trim();

            if (string.IsNullOrEmpty(groqKey))
            {
                MessageBox.Show("Please enter at least a Groq API key.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            keyManager.SaveKeys(groqKey, googleKey);
            MessageBox.Show("API keys saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
