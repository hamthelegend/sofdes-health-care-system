
namespace HealthCareSystem
{
    partial class SecretaryPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(24, 62);
            this.btnEditAccount.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(359, 79);
            this.btnEditAccount.TabIndex = 0;
            this.btnEditAccount.Text = "Edit Account";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 167);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(359, 79);
            this.button1.TabIndex = 1;
            this.button1.Text = "Manage Patients";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SecretaryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 872);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEditAccount);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SecretaryPanel";
            this.Text = "SecretaryPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button button1;
    }
}