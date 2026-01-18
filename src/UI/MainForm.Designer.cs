namespace PromptOptimizer.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtOriginalPrompt;
        private System.Windows.Forms.TextBox txtOptimizedPrompt;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnAPISettings;
        private System.Windows.Forms.Label lblClarityScore;
        private System.Windows.Forms.Label lblSpecificityScore;
        private System.Windows.Forms.Label lblCompletenessScore;
        private System.Windows.Forms.Label lblOverallScore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtOriginalPrompt = new System.Windows.Forms.TextBox();
            this.txtOptimizedPrompt = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnAPISettings = new System.Windows.Forms.Button();
            this.lblClarityScore = new System.Windows.Forms.Label();
            this.lblSpecificityScore = new System.Windows.Forms.Label();
            this.lblCompletenessScore = new System.Windows.Forms.Label();
            this.lblOverallScore = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // txtOriginalPrompt
            this.txtOriginalPrompt.Location = new System.Drawing.Point(12, 40);
            this.txtOriginalPrompt.Multiline = true;
            this.txtOriginalPrompt.Name = "txtOriginalPrompt";
            this.txtOriginalPrompt.Size = new System.Drawing.Size(460, 100);
            this.txtOriginalPrompt.TabIndex = 0;

            // btnAnalyze
            this.btnAnalyze.Location = new System.Drawing.Point(12, 150);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(100, 30);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze Prompt";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);

            // Score Labels
            this.lblClarityScore.Location = new System.Drawing.Point(12, 190);
            this.lblClarityScore.Name = "lblClarityScore";
            this.lblClarityScore.Size = new System.Drawing.Size(150, 20);
            this.lblClarityScore.TabIndex = 2;
            this.lblClarityScore.Text = "Clarity: --";

            this.lblSpecificityScore.Location = new System.Drawing.Point(12, 215);
            this.lblSpecificityScore.Name = "lblSpecificityScore";
            this.lblSpecificityScore.Size = new System.Drawing.Size(150, 20);
            this.lblSpecificityScore.TabIndex = 3;
            this.lblSpecificityScore.Text = "Specificity: --";

            this.lblCompletenessScore.Location = new System.Drawing.Point(12, 240);
            this.lblCompletenessScore.Name = "lblCompletenessScore";
            this.lblCompletenessScore.Size = new System.Drawing.Size(150, 20);
            this.lblCompletenessScore.TabIndex = 4;
            this.lblCompletenessScore.Text = "Completeness: --";

            this.lblOverallScore.Location = new System.Drawing.Point(12, 265);
            this.lblOverallScore.Name = "lblOverallScore";
            this.lblOverallScore.Size = new System.Drawing.Size(150, 20);
            this.lblOverallScore.TabIndex = 5;
            this.lblOverallScore.Text = "Overall: --";

            // btnGenerate
            this.btnGenerate.Location = new System.Drawing.Point(120, 150);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(120, 30);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate Optimization";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // txtOptimizedPrompt
            this.txtOptimizedPrompt.Location = new System.Drawing.Point(12, 310);
            this.txtOptimizedPrompt.Multiline = true;
            this.txtOptimizedPrompt.Name = "txtOptimizedPrompt";
            this.txtOptimizedPrompt.Size = new System.Drawing.Size(460, 100);
            this.txtOptimizedPrompt.TabIndex = 7;

            // btnCopy
            this.btnCopy.Location = new System.Drawing.Point(12, 420);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 30);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);

            // btnAPISettings
            this.btnAPISettings.Location = new System.Drawing.Point(430, 10);
            this.btnAPISettings.Name = "btnAPISettings";
            this.btnAPISettings.Size = new System.Drawing.Size(42, 23);
            this.btnAPISettings.TabIndex = 9;
            this.btnAPISettings.Text = "⚙️";
            this.btnAPISettings.Click += new System.EventHandler(this.btnAPISettings_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.btnAPISettings);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtOptimizedPrompt);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblOverallScore);
            this.Controls.Add(this.lblCompletenessScore);
            this.Controls.Add(this.lblSpecificityScore);
            this.Controls.Add(this.lblClarityScore);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtOriginalPrompt);
            this.Name = "MainForm";
            this.Text = "Prompt Optimizer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
