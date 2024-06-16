namespace Django_GUI.User_Controls
{
    partial class ToolBox
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
            this.label2 = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.StartProject = new System.Windows.Forms.Button();
            this.StartApp = new System.Windows.Forms.Button();
            this.RunServer = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CmdPrompt = new System.Windows.Forms.TextBox();
            this.PreviousStep = new System.Windows.Forms.PictureBox();
            this.ControlsPnl = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).BeginInit();
            this.ControlsPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Django ToolBox";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Project Name  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.ForeColor = System.Drawing.Color.White;
            this.NameLbl.Location = new System.Drawing.Point(141, 62);
            this.NameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(53, 19);
            this.NameLbl.TabIndex = 12;
            this.NameLbl.Text = "Name";
            this.NameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartProject
            // 
            this.StartProject.BackColor = System.Drawing.Color.White;
            this.StartProject.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.StartProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartProject.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartProject.ForeColor = System.Drawing.Color.Black;
            this.StartProject.Location = new System.Drawing.Point(3, 0);
            this.StartProject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartProject.Name = "StartProject";
            this.StartProject.Size = new System.Drawing.Size(218, 46);
            this.StartProject.TabIndex = 17;
            this.StartProject.Text = "Start Project";
            this.StartProject.UseVisualStyleBackColor = false;
            this.StartProject.Click += new System.EventHandler(this.StartProject_Click);
            // 
            // StartApp
            // 
            this.StartApp.BackColor = System.Drawing.Color.White;
            this.StartApp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.StartApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartApp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartApp.ForeColor = System.Drawing.Color.Black;
            this.StartApp.Location = new System.Drawing.Point(237, 0);
            this.StartApp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartApp.Name = "StartApp";
            this.StartApp.Size = new System.Drawing.Size(218, 46);
            this.StartApp.TabIndex = 18;
            this.StartApp.Text = "Start App";
            this.StartApp.UseVisualStyleBackColor = false;
            this.StartApp.Click += new System.EventHandler(this.StartApp_Click);
            // 
            // RunServer
            // 
            this.RunServer.BackColor = System.Drawing.Color.White;
            this.RunServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RunServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunServer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunServer.ForeColor = System.Drawing.Color.Black;
            this.RunServer.Location = new System.Drawing.Point(470, 0);
            this.RunServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RunServer.Name = "RunServer";
            this.RunServer.Size = new System.Drawing.Size(218, 46);
            this.RunServer.TabIndex = 19;
            this.RunServer.Text = "Run Sever";
            this.RunServer.UseVisualStyleBackColor = false;
            this.RunServer.Click += new System.EventHandler(this.RunServer_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.Color.White;
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutput.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.Color.Black;
            this.rtbOutput.Location = new System.Drawing.Point(3, 60);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(686, 112);
            this.rtbOutput.TabIndex = 21;
            this.rtbOutput.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.CmdPrompt);
            this.panel1.Location = new System.Drawing.Point(3, 185);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 38);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Django_GUI.Properties.Resources.CommandIcon;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // CmdPrompt
            // 
            this.CmdPrompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CmdPrompt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdPrompt.Location = new System.Drawing.Point(45, 8);
            this.CmdPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CmdPrompt.Name = "CmdPrompt";
            this.CmdPrompt.Size = new System.Drawing.Size(620, 19);
            this.CmdPrompt.TabIndex = 6;
            this.CmdPrompt.Text = "Write command to the terminal...";
            this.CmdPrompt.Enter += new System.EventHandler(this.CmdPrompt_Enter);
            this.CmdPrompt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmdPrompt_KeyDown);
            this.CmdPrompt.Leave += new System.EventHandler(this.CmdPrompt_Leave);
            // 
            // PreviousStep
            // 
            this.PreviousStep.BackColor = System.Drawing.Color.Transparent;
            this.PreviousStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousStep.Image = global::Django_GUI.Properties.Resources.PreviousStep;
            this.PreviousStep.Location = new System.Drawing.Point(676, 12);
            this.PreviousStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PreviousStep.Name = "PreviousStep";
            this.PreviousStep.Size = new System.Drawing.Size(32, 29);
            this.PreviousStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousStep.TabIndex = 20;
            this.PreviousStep.TabStop = false;
            this.PreviousStep.Click += new System.EventHandler(this.PreviousStep_Click);
            // 
            // ControlsPnl
            // 
            this.ControlsPnl.Controls.Add(this.panel1);
            this.ControlsPnl.Controls.Add(this.StartProject);
            this.ControlsPnl.Controls.Add(this.rtbOutput);
            this.ControlsPnl.Controls.Add(this.StartApp);
            this.ControlsPnl.Controls.Add(this.RunServer);
            this.ControlsPnl.Location = new System.Drawing.Point(18, 111);
            this.ControlsPnl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ControlsPnl.Name = "ControlsPnl";
            this.ControlsPnl.Size = new System.Drawing.Size(690, 223);
            this.ControlsPnl.TabIndex = 23;
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PreviousStep);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ControlsPnl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ToolBox";
            this.Size = new System.Drawing.Size(708, 391);
            this.Load += new System.EventHandler(this.ToolBox_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).EndInit();
            this.ControlsPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Button StartProject;
        private System.Windows.Forms.Button StartApp;
        private System.Windows.Forms.Button RunServer;
        private System.Windows.Forms.PictureBox PreviousStep;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox CmdPrompt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel ControlsPnl;
    }
}
