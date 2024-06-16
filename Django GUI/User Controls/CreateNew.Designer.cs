namespace Django_GUI.User_Controls
{
    partial class CreateNew
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LocationPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateNewProject = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DjangoVersion = new System.Windows.Forms.ComboBox();
            this.CompareVersions = new System.Windows.Forms.Label();
            this.PreviousStep = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.BrowseBtn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 128);
            this.panel1.TabIndex = 1;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowseBtn.Location = new System.Drawing.Point(396, 83);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(26, 24);
            this.BrowseBtn.TabIndex = 13;
            this.BrowseBtn.Text = "...";
            this.BrowseBtn.UseVisualStyleBackColor = false;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Django_GUI.Properties.Resources.NewIcon;
            this.pictureBox2.Location = new System.Drawing.Point(13, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Location  :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.LocationPath);
            this.panel3.Location = new System.Drawing.Point(96, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 23);
            this.panel3.TabIndex = 11;
            // 
            // LocationPath
            // 
            this.LocationPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationPath.Location = new System.Drawing.Point(3, 4);
            this.LocationPath.Name = "LocationPath";
            this.LocationPath.ReadOnly = true;
            this.LocationPath.Size = new System.Drawing.Size(288, 13);
            this.LocationPath.TabIndex = 5;
            this.LocationPath.Text = "Click to select location...";
            this.LocationPath.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Project Name  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ProjectName);
            this.panel2.Location = new System.Drawing.Point(96, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 23);
            this.panel2.TabIndex = 9;
            // 
            // ProjectName
            // 
            this.ProjectName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.Location = new System.Drawing.Point(3, 4);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(326, 13);
            this.ProjectName.TabIndex = 5;
            this.ProjectName.Text = "Click to add project name...";
            this.ProjectName.Enter += new System.EventHandler(this.ProjectName_Enter);
            this.ProjectName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProjectName_KeyPress);
            this.ProjectName.Leave += new System.EventHandler(this.ProjectName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Django Project Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateNewProject
            // 
            this.CreateNewProject.BackColor = System.Drawing.Color.White;
            this.CreateNewProject.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CreateNewProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateNewProject.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewProject.ForeColor = System.Drawing.Color.Black;
            this.CreateNewProject.Location = new System.Drawing.Point(340, 185);
            this.CreateNewProject.Name = "CreateNewProject";
            this.CreateNewProject.Size = new System.Drawing.Size(121, 30);
            this.CreateNewProject.TabIndex = 3;
            this.CreateNewProject.Text = "Setup Project";
            this.CreateNewProject.UseVisualStyleBackColor = false;
            this.CreateNewProject.Click += new System.EventHandler(this.CreateNewProject_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Django Version  :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DjangoVersion
            // 
            this.DjangoVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DjangoVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DjangoVersion.FormattingEnabled = true;
            this.DjangoVersion.Items.AddRange(new object[] {
            "5.0.6",
            "4.2.13",
            "4.2"});
            this.DjangoVersion.Location = new System.Drawing.Point(123, 147);
            this.DjangoVersion.Name = "DjangoVersion";
            this.DjangoVersion.Size = new System.Drawing.Size(131, 21);
            this.DjangoVersion.TabIndex = 15;
            // 
            // CompareVersions
            // 
            this.CompareVersions.AutoSize = true;
            this.CompareVersions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CompareVersions.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompareVersions.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CompareVersions.Location = new System.Drawing.Point(285, 149);
            this.CompareVersions.Name = "CompareVersions";
            this.CompareVersions.Size = new System.Drawing.Size(96, 14);
            this.CompareVersions.TabIndex = 16;
            this.CompareVersions.Text = "Compare Versions";
            this.CompareVersions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CompareVersions.Click += new System.EventHandler(this.CompareVersions_Click);
            // 
            // PreviousStep
            // 
            this.PreviousStep.BackColor = System.Drawing.Color.Transparent;
            this.PreviousStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousStep.Image = global::Django_GUI.Properties.Resources.PreviousStep;
            this.PreviousStep.Location = new System.Drawing.Point(303, 190);
            this.PreviousStep.Name = "PreviousStep";
            this.PreviousStep.Size = new System.Drawing.Size(21, 19);
            this.PreviousStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousStep.TabIndex = 14;
            this.PreviousStep.TabStop = false;
            this.PreviousStep.Click += new System.EventHandler(this.PreviousStep_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Django_GUI.Properties.Resources.Link;
            this.pictureBox1.Location = new System.Drawing.Point(268, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 13);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.CompareVersions_Click);
            // 
            // CreateNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PreviousStep);
            this.Controls.Add(this.CompareVersions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DjangoVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CreateNewProject);
            this.Name = "CreateNew";
            this.Size = new System.Drawing.Size(472, 254);
            this.Load += new System.EventHandler(this.CreateNew_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateNewProject;
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox LocationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DjangoVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label CompareVersions;
        private System.Windows.Forms.PictureBox PreviousStep;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
    }
}
