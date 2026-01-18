namespace PromptOptimizer.UI
{
    partial class APISettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtGroqKey;
        private System.Windows.Forms.TextBox txtGoogleKey;
        private System.Windows.Forms.Button btnTestGroq;
        private System.Windows.Forms.Button btnTestGoogle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblGroqKey;
        private System.Windows.Forms.Label lblGoogleKey;

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
            this.txtGroqKey = new System.Windows.Forms.TextBox();
            this.txtGoogleKey = new System.Windows.Forms.TextBox();
            this.btnTestGroq = new System.Windows.Forms.Button();
            this.btnTestGoogle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblGroqKey = new System.Windows.Forms.Label();
            this.lblGoogleKey = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // lblGroqKey
            this.lblGroqKey.Location = new System.Drawing.Point(12, 15);
            this.lblGroqKey.Name = "lblGroqKey";
            this.lblGroqKey.Size = new System.Drawing.Size(150, 20);
            this.lblGroqKey.TabIndex = 0;
            this.lblGroqKey.Text = "Groq API Key:";

            // txtGroqKey
            this.txtGroqKey.Location = new System.Drawing.Point(12, 35);
            this.txtGroqKey.Name = "txtGroqKey";
            this.txtGroqKey.PasswordChar = '*';
            this.txtGroqKey.Size = new System.Drawing.Size(350, 20);
            this.txtGroqKey.TabIndex = 1;

            // btnTestGroq
            this.btnTestGroq.Location = new System.Drawing.Point(370, 35);
            this.btnTestGroq.Name = "btnTestGroq";
            this.btnTestGroq.Size = new System.Drawing.Size(100, 23);
            this.btnTestGroq.TabIndex = 2;
            this.btnTestGroq.Text = "Test Groq Key";
            this.btnTestGroq.Click += new System.EventHandler(this.btnTestGroq_Click);

            // lblGoogleKey
            this.lblGoogleKey.Location = new System.Drawing.Point(12, 70);
            this.lblGoogleKey.Name = "lblGoogleKey";
            this.lblGoogleKey.Size = new System.Drawing.Size(150, 20);
            this.lblGoogleKey.TabIndex = 3;
            this.lblGoogleKey.Text = "Google AI API Key (Optional):";

            // txtGoogleKey
            this.txtGoogleKey.Location = new System.Drawing.Point(12, 90);
            this.txtGoogleKey.Name = "txtGoogleKey";
            this.txtGoogleKey.PasswordChar = '*';
            this.txtGoogleKey.Size = new System.Drawing.Size(350, 20);
            this.txtGoogleKey.TabIndex = 4;

            // btnTestGoogle
            this.btnTestGoogle.Location = new System.Drawing.Point(370, 90);
            this.btnTestGoogle.Name = "btnTestGoogle";
            this.btnTestGoogle.Size = new System.Drawing.Size(100, 23);
            this.btnTestGoogle.TabIndex = 5;
            this.btnTestGoogle.Text = "Test Google Key";
            this.btnTestGoogle.Click += new System.EventHandler(this.btnTestGoogle_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(310, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(395, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // APISettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 165);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTestGoogle);
            this.Controls.Add(this.txtGoogleKey);
            this.Controls.Add(this.lblGoogleKey);
            this.Controls.Add(this.btnTestGroq);
            this.Controls.Add(this.txtGroqKey);
            this.Controls.Add(this.lblGroqKey);
            this.Name = "APISettingsForm";
            this.Text = "API Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
