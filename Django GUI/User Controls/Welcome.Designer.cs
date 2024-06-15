namespace Django_GUI.User_Controls
{
    partial class Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.CreateNewProject = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.OpenExisting = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CreateNewProject);
            this.panel1.Location = new System.Drawing.Point(233, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 207);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 71);
            this.label1.TabIndex = 4;
            this.label1.Text = "Create New \r\nDjango Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateNewProject
            // 
            this.CreateNewProject.BackColor = System.Drawing.Color.White;
            this.CreateNewProject.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CreateNewProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateNewProject.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewProject.ForeColor = System.Drawing.Color.Black;
            this.CreateNewProject.Location = new System.Drawing.Point(48, 149);
            this.CreateNewProject.Name = "CreateNewProject";
            this.CreateNewProject.Size = new System.Drawing.Size(141, 30);
            this.CreateNewProject.TabIndex = 3;
            this.CreateNewProject.Text = "Get Started";
            this.CreateNewProject.UseVisualStyleBackColor = false;
            this.CreateNewProject.Click += new System.EventHandler(this.CreateNewProject_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.OpenExisting);
            this.panel2.Location = new System.Drawing.Point(3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 207);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 71);
            this.label2.TabIndex = 6;
            this.label2.Text = "Open Existing\r\nDjango Project";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenExisting
            // 
            this.OpenExisting.BackColor = System.Drawing.Color.White;
            this.OpenExisting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OpenExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenExisting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenExisting.ForeColor = System.Drawing.Color.Black;
            this.OpenExisting.Location = new System.Drawing.Point(41, 149);
            this.OpenExisting.Name = "OpenExisting";
            this.OpenExisting.Size = new System.Drawing.Size(141, 30);
            this.OpenExisting.TabIndex = 5;
            this.OpenExisting.Text = "Get Started";
            this.OpenExisting.UseVisualStyleBackColor = false;
            this.OpenExisting.Click += new System.EventHandler(this.OpenExisting_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Django_GUI.Properties.Resources.OpenExistingIcon;
            this.pictureBox1.Location = new System.Drawing.Point(90, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Django_GUI.Properties.Resources.NewIcon;
            this.pictureBox2.Location = new System.Drawing.Point(92, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Welcome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(46)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Welcome";
            this.Size = new System.Drawing.Size(472, 254);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CreateNewProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OpenExisting;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
