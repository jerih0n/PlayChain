namespace NodeWindowsLauncher
{
    partial class Form1
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
            this.changeDirektoryBtn = new System.Windows.Forms.Button();
            this.launchNodeBtn = new System.Windows.Forms.Button();
            this.nodeFullPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeDirektoryBtn
            // 
            this.changeDirektoryBtn.Location = new System.Drawing.Point(12, 65);
            this.changeDirektoryBtn.Name = "changeDirektoryBtn";
            this.changeDirektoryBtn.Size = new System.Drawing.Size(302, 23);
            this.changeDirektoryBtn.TabIndex = 0;
            this.changeDirektoryBtn.Text = "Change node path";
            this.changeDirektoryBtn.UseVisualStyleBackColor = true;
            this.changeDirektoryBtn.Click += new System.EventHandler(this.changeDirektoryBtn_Click);
            // 
            // launchNodeBtn
            // 
            this.launchNodeBtn.Enabled = false;
            this.launchNodeBtn.Location = new System.Drawing.Point(12, 36);
            this.launchNodeBtn.Name = "launchNodeBtn";
            this.launchNodeBtn.Size = new System.Drawing.Size(302, 23);
            this.launchNodeBtn.TabIndex = 1;
            this.launchNodeBtn.Text = "Launch node";
            this.launchNodeBtn.UseVisualStyleBackColor = true;
            this.launchNodeBtn.Click += new System.EventHandler(this.launchNodeBtn_Click);
            // 
            // nodeFullPath
            // 
            this.nodeFullPath.Location = new System.Drawing.Point(12, 12);
            this.nodeFullPath.Name = "nodeFullPath";
            this.nodeFullPath.ReadOnly = true;
            this.nodeFullPath.Size = new System.Drawing.Size(317, 20);
            this.nodeFullPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(50, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 204);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nodeFullPath);
            this.Controls.Add(this.launchNodeBtn);
            this.Controls.Add(this.changeDirektoryBtn);
            this.Name = "Form1";
            this.Text = "PlayChain Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeDirektoryBtn;
        private System.Windows.Forms.Button launchNodeBtn;
        private System.Windows.Forms.TextBox nodeFullPath;
        private System.Windows.Forms.Label label1;
    }
}

