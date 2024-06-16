namespace Django_GUI.User_Controls
{
    partial class ExistingProjects
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
            this.ProjectsPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.AddExistingProject = new System.Windows.Forms.Button();
            this.PreviousStep = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Django Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProjectsPnl
            // 
            this.ProjectsPnl.AutoScroll = true;
            this.ProjectsPnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ProjectsPnl.Location = new System.Drawing.Point(12, 51);
            this.ProjectsPnl.Margin = new System.Windows.Forms.Padding(0);
            this.ProjectsPnl.Name = "ProjectsPnl";
            this.ProjectsPnl.Size = new System.Drawing.Size(460, 105);
            this.ProjectsPnl.TabIndex = 8;
            this.ProjectsPnl.WrapContents = false;
            // 
            // AddExistingProject
            // 
            this.AddExistingProject.BackColor = System.Drawing.Color.White;
            this.AddExistingProject.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AddExistingProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddExistingProject.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddExistingProject.ForeColor = System.Drawing.Color.Black;
            this.AddExistingProject.Location = new System.Drawing.Point(350, 176);
            this.AddExistingProject.Name = "AddExistingProject";
            this.AddExistingProject.Size = new System.Drawing.Size(121, 30);
            this.AddExistingProject.TabIndex = 16;
            this.AddExistingProject.Text = "Add New +";
            this.AddExistingProject.UseVisualStyleBackColor = false;
            this.AddExistingProject.Click += new System.EventHandler(this.AddExistingProject_Click);
            // 
            // PreviousStep
            // 
            this.PreviousStep.BackColor = System.Drawing.Color.Transparent;
            this.PreviousStep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousStep.Image = global::Django_GUI.Properties.Resources.PreviousStep;
            this.PreviousStep.Location = new System.Drawing.Point(12, 180);
            this.PreviousStep.Name = "PreviousStep";
            this.PreviousStep.Size = new System.Drawing.Size(21, 19);
            this.PreviousStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviousStep.TabIndex = 15;
            this.PreviousStep.TabStop = false;
            this.PreviousStep.Click += new System.EventHandler(this.PreviousStep_Click);
            // 
            // ExistingProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.AddExistingProject);
            this.Controls.Add(this.PreviousStep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProjectsPnl);
            this.Name = "ExistingProjects";
            this.Size = new System.Drawing.Size(472, 254);
            this.Load += new System.EventHandler(this.ExistingProjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviousStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.FlowLayoutPanel ProjectsPnl;
        private System.Windows.Forms.PictureBox PreviousStep;
        private System.Windows.Forms.Button AddExistingProject;
    }
}
