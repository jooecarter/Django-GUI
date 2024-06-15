namespace Django_GUI.User_Controls
{
    partial class ProjectSetup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.RunServer = new System.Windows.Forms.Button();
            this.OpenIDE = new System.Windows.Forms.Button();
            this.OpenFiles = new System.Windows.Forms.Button();
            this.PreviousStep = new System.Windows.Forms.PictureBox();
            this.InstallPython = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Setting up your project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(32)))));
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutput.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.Color.White;
            this.rtbOutput.Location = new System.Drawing.Point(21, 51);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(435, 120);
            this.rtbOutput.TabIndex = 6;
            this.rtbOutput.Text = "";
            // 
            // RunServer
            // 
            this.RunServer.BackColor = System.Drawing.Color.White;
            this.RunServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RunServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunServer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunServer.ForeColor = System.Drawing.Color.Black;
            this.RunServer.Location = new System.Drawing.Point(335, 185);
            this.RunServer.Name = "RunServer";
            this.RunServer.Size = new System.Drawing.Size(121, 30);
            this.RunServer.TabIndex = 7;
            this.RunServer.Text = "Run Server";
            this.RunServer.UseVisualStyleBackColor = false;
            this.RunServer.Visible = false;
            this.RunServer.Click += new System.EventHandler(this.RunServer_Click);
            // 
            // OpenIDE
            // 
            this.OpenIDE.BackColor = System.Drawing.Color.White;
            this.OpenIDE.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OpenIDE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenIDE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenIDE.ForeColor = System.Drawing.Color.Black;
            this.OpenIDE.Location = new System.Drawing.Point(208, 185);
            this.OpenIDE.Name = "OpenIDE";
            this.OpenIDE.Size = new System.Drawing.Size(121, 30);
            this.OpenIDE.TabIndex = 8;
            this.OpenIDE.Text = "Open in IDE";
            this.OpenIDE.UseVisualStyleBackColor = false;
            this.OpenIDE.Visible = false;
            this.OpenIDE.Click += new System.EventHandler(this.OpenIDE_Click);
            // 
            // OpenFiles
            // 
            this.OpenFiles.BackColor = System.Drawing.Color.White;
            this.OpenFiles.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OpenFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFiles.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFiles.ForeColor = System.Drawing.Color.Black;
            this.OpenFiles.Location = new System.Drawing.Point(79, 185);
            this.OpenFiles.Name = "OpenFiles";
            this.OpenFiles.Size = new System.Drawing.Size(121, 30);
            this.OpenFiles.TabIndex = 9;
            this.OpenFiles.Text = "Open Files";
            this.OpenFiles.UseVisualStyleBackColor = false;
            this.OpenFiles.Visible = false;
            this.OpenFiles.Click += new System.EventHandler(this.OpenFiles_Click);
            // 
            // PreviousStep
            // 
            this.PreviousStep.BackColor = System.Drawing.Color.Transparent;
            this.PreviousStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousStep.Image = global::Django_GUI.Properties.Resources.PreviousStep;
            this.PreviousStep.Location = new System.Drawing.Point(45, 190);
            this.PreviousStep.Name = "PreviousStep";
            this.PreviousStep.Size = new System.Drawing.Size(21, 19);
            this.PreviousStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousStep.TabIndex = 15;
            this.PreviousStep.TabStop = false;
            this.PreviousStep.Visible = false;
            this.PreviousStep.Click += new System.EventHandler(this.PreviousStep_Click);
            // 
            // InstallPython
            // 
            this.InstallPython.BackColor = System.Drawing.Color.White;
            this.InstallPython.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.InstallPython.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallPython.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallPython.ForeColor = System.Drawing.Color.Black;
            this.InstallPython.Location = new System.Drawing.Point(335, 185);
            this.InstallPython.Name = "InstallPython";
            this.InstallPython.Size = new System.Drawing.Size(121, 30);
            this.InstallPython.TabIndex = 16;
            this.InstallPython.Text = "Install Python";
            this.InstallPython.UseVisualStyleBackColor = false;
            this.InstallPython.Visible = false;
            this.InstallPython.Click += new System.EventHandler(this.InstallPython_Click);
            // 
            // ProjectSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.InstallPython);
            this.Controls.Add(this.PreviousStep);
            this.Controls.Add(this.OpenFiles);
            this.Controls.Add(this.OpenIDE);
            this.Controls.Add(this.RunServer);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.label1);
            this.Name = "ProjectSetup";
            this.Size = new System.Drawing.Size(472, 254);
            this.Load += new System.EventHandler(this.ProjectSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button RunServer;
        private System.Windows.Forms.Button OpenIDE;
        private System.Windows.Forms.Button OpenFiles;
        private System.Windows.Forms.PictureBox PreviousStep;
        private System.Windows.Forms.Button InstallPython;
    }
}
