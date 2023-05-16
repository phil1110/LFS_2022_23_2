
namespace Calculator.Service.GUI
{
    partial class MainForm
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
			this.gbxLogs = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.lbxLogs = new System.Windows.Forms.ListBox();
			this.gbxQuarantine = new System.Windows.Forms.GroupBox();
			this.btnAllow = new System.Windows.Forms.Button();
			this.btnRefuse = new System.Windows.Forms.Button();
			this.lbxQuarantine = new System.Windows.Forms.ListBox();
			this.gbxLogs.SuspendLayout();
			this.gbxQuarantine.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxLogs
			// 
			this.gbxLogs.Controls.Add(this.btnClear);
			this.gbxLogs.Controls.Add(this.lbxLogs);
			this.gbxLogs.Location = new System.Drawing.Point(21, 28);
			this.gbxLogs.Name = "gbxLogs";
			this.gbxLogs.Size = new System.Drawing.Size(370, 412);
			this.gbxLogs.TabIndex = 7;
			this.gbxLogs.TabStop = false;
			this.gbxLogs.Text = "Logs";
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(143, 368);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 6;
			this.btnClear.Text = "Löschen";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// lbxLogs
			// 
			this.lbxLogs.FormattingEnabled = true;
			this.lbxLogs.Location = new System.Drawing.Point(30, 21);
			this.lbxLogs.Name = "lbxLogs";
			this.lbxLogs.Size = new System.Drawing.Size(310, 329);
			this.lbxLogs.TabIndex = 5;
			this.lbxLogs.SelectedIndexChanged += new System.EventHandler(this.lbxLogs_SelectedIndexChanged);
			// 
			// gbxQuarantine
			// 
			this.gbxQuarantine.Controls.Add(this.btnAllow);
			this.gbxQuarantine.Controls.Add(this.btnRefuse);
			this.gbxQuarantine.Controls.Add(this.lbxQuarantine);
			this.gbxQuarantine.Location = new System.Drawing.Point(439, 32);
			this.gbxQuarantine.Name = "gbxQuarantine";
			this.gbxQuarantine.Size = new System.Drawing.Size(317, 272);
			this.gbxQuarantine.TabIndex = 8;
			this.gbxQuarantine.TabStop = false;
			this.gbxQuarantine.Text = "Quarantäne";
			// 
			// btnAllow
			// 
			this.btnAllow.Location = new System.Drawing.Point(194, 229);
			this.btnAllow.Name = "btnAllow";
			this.btnAllow.Size = new System.Drawing.Size(75, 23);
			this.btnAllow.TabIndex = 9;
			this.btnAllow.Text = "Zulassen";
			this.btnAllow.UseVisualStyleBackColor = true;
			this.btnAllow.Click += new System.EventHandler(this.btnAllow_Click);
			// 
			// btnRefuse
			// 
			this.btnRefuse.Location = new System.Drawing.Point(52, 229);
			this.btnRefuse.Name = "btnRefuse";
			this.btnRefuse.Size = new System.Drawing.Size(75, 23);
			this.btnRefuse.TabIndex = 8;
			this.btnRefuse.Text = "Blockieren";
			this.btnRefuse.UseVisualStyleBackColor = true;
			this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
			// 
			// lbxQuarantine
			// 
			this.lbxQuarantine.FormattingEnabled = true;
			this.lbxQuarantine.Location = new System.Drawing.Point(33, 20);
			this.lbxQuarantine.Name = "lbxQuarantine";
			this.lbxQuarantine.Size = new System.Drawing.Size(251, 186);
			this.lbxQuarantine.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.gbxQuarantine);
			this.Controls.Add(this.gbxLogs);
			this.Name = "MainForm";
			this.Text = "LFS 4HITN";
			this.gbxLogs.ResumeLayout(false);
			this.gbxQuarantine.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLogs;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lbxLogs;
        private System.Windows.Forms.GroupBox gbxQuarantine;
        private System.Windows.Forms.Button btnAllow;
        private System.Windows.Forms.Button btnRefuse;
        private System.Windows.Forms.ListBox lbxQuarantine;
    }
}

