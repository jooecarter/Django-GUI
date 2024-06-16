namespace Django_GUI
{
    partial class CreateProject
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
            this.CreateNew = new System.Windows.Forms.Button();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LocationPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateNew
            // 
            this.CreateNew.BackColor = System.Drawing.Color.White;
            this.CreateNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CreateNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNew.ForeColor = System.Drawing.Color.Black;
            this.CreateNew.Location = new System.Drawing.Point(206, 129);
            this.CreateNew.Name = "CreateNew";
            this.CreateNew.Size = new System.Drawing.Size(121, 30);
            this.CreateNew.TabIndex = 26;
            this.CreateNew.Text = "Create +";
            this.CreateNew.UseVisualStyleBackColor = false;
            this.CreateNew.Click += new System.EventHandler(this.CreateNew_Click);
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowseBtn.Location = new System.Drawing.Point(301, 89);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(26, 24);
            this.BrowseBtn.TabIndex = 25;
            this.BrowseBtn.Text = "...";
            this.BrowseBtn.UseVisualStyleBackColor = false;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Location  :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.LocationPath);
            this.panel3.Location = new System.Drawing.Point(106, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 23);
            this.panel3.TabIndex = 23;
            // 
            // LocationPath
            // 
            this.LocationPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationPath.Location = new System.Drawing.Point(3, 4);
            this.LocationPath.Name = "LocationPath";
            this.LocationPath.ReadOnly = true;
            this.LocationPath.Size = new System.Drawing.Size(185, 13);
            this.LocationPath.TabIndex = 5;
            this.LocationPath.Text = "Click to select location...";
            this.LocationPath.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "Project Name  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ProjectName);
            this.panel2.Location = new System.Drawing.Point(106, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 23);
            this.panel2.TabIndex = 21;
            // 
            // ProjectName
            // 
            this.ProjectName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.Location = new System.Drawing.Point(3, 4);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(215, 13);
            this.ProjectName.TabIndex = 5;
            this.ProjectName.Text = "Click to add name...";
            this.ProjectName.Enter += new System.EventHandler(this.ProjectName_Enter);
            this.ProjectName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProjectName_KeyPress);
            this.ProjectName.Leave += new System.EventHandler(this.ProjectName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Create Django Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Django_GUI.Properties.Resources.DjangoBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(353, 183);
            this.Controls.Add(this.CreateNew);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DjangoGUI - Create Project";
            this.Load += new System.EventHandler(this.CreateProject_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateNew;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox LocationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox ProjectName;
        private System.Windows.Forms.Label label1;
    }
}