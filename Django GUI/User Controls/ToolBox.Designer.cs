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
            this.ProjectName = new System.Windows.Forms.TextBox();
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
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Django ToolBox";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Project Name  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.ForeColor = System.Drawing.Color.White;
            this.NameLbl.Location = new System.Drawing.Point(94, 40);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(38, 14);
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
            this.StartProject.Location = new System.Drawing.Point(2, 0);
            this.StartProject.Name = "StartProject";
            this.StartProject.Size = new System.Drawing.Size(145, 30);
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
            this.StartApp.Location = new System.Drawing.Point(158, 0);
            this.StartApp.Name = "StartApp";
            this.StartApp.Size = new System.Drawing.Size(145, 30);
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
            this.RunServer.Location = new System.Drawing.Point(313, 0);
            this.RunServer.Name = "RunServer";
            this.RunServer.Size = new System.Drawing.Size(145, 30);
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
            this.rtbOutput.Location = new System.Drawing.Point(2, 39);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(457, 73);
            this.rtbOutput.TabIndex = 21;
            this.rtbOutput.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.ProjectName);
            this.panel1.Location = new System.Drawing.Point(2, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 25);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Django_GUI.Properties.Resources.CommandIcon;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 13);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // ProjectName
            // 
            this.ProjectName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.Location = new System.Drawing.Point(30, 5);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(413, 13);
            this.ProjectName.TabIndex = 6;
            this.ProjectName.Text = "Write command to the terminal...";
            this.ProjectName.Enter += new System.EventHandler(this.ProjectName_Enter);
            this.ProjectName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectName_KeyDown);
            this.ProjectName.Leave += new System.EventHandler(this.ProjectName_Leave);
            // 
            // PreviousStep
            // 
            this.PreviousStep.BackColor = System.Drawing.Color.Transparent;
            this.PreviousStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousStep.Image = global::Django_GUI.Properties.Resources.PreviousStep;
            this.PreviousStep.Location = new System.Drawing.Point(451, 8);
            this.PreviousStep.Name = "PreviousStep";
            this.PreviousStep.Size = new System.Drawing.Size(21, 19);
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
            this.ControlsPnl.Location = new System.Drawing.Point(12, 72);
            this.ControlsPnl.Name = "ControlsPnl";
            this.ControlsPnl.Size = new System.Drawing.Size(460, 145);
            this.ControlsPnl.TabIndex = 23;
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PreviousStep);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ControlsPnl);
            this.Name = "ToolBox";
            this.Size = new System.Drawing.Size(472, 254);
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
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel ControlsPnl;
    }
}
