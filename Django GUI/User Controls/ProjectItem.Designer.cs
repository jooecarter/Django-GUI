namespace Django_GUI.User_Controls
{
    partial class ProjectItem
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
            this.Name = new System.Windows.Forms.Label();
            this.DeleteProject = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.ForeColor = System.Drawing.Color.White;
            this.Name.Location = new System.Drawing.Point(29, 5);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(82, 15);
            this.Name.TabIndex = 9;
            this.Name.Text = "Project Name";
            this.Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Name.Click += new System.EventHandler(this.Name_Click);
            this.Name.MouseEnter += new System.EventHandler(this.Name_MouseEnter);
            this.Name.MouseLeave += new System.EventHandler(this.Name_MouseLeave);
            // 
            // DeleteProject
            // 
            this.DeleteProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteProject.Image = global::Django_GUI.Properties.Resources.DeleteMsgCirclular;
            this.DeleteProject.Location = new System.Drawing.Point(429, 4);
            this.DeleteProject.Name = "DeleteProject";
            this.DeleteProject.Size = new System.Drawing.Size(18, 18);
            this.DeleteProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DeleteProject.TabIndex = 10;
            this.DeleteProject.TabStop = false;
            this.DeleteProject.Click += new System.EventHandler(this.DeleteProject_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Django_GUI.Properties.Resources.OpenExistingIcon;
            this.pictureBox1.Location = new System.Drawing.Point(2, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ProjectItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DeleteProject);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.pictureBox1);
            this.Size = new System.Drawing.Size(450, 27);
            this.Load += new System.EventHandler(this.ProjectItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.PictureBox DeleteProject;
    }
}
