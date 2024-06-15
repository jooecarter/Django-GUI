using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Django_GUI.User_Controls
{
    public partial class CreateNew : UserControl
    {
        private DjangoGUI parent;

        public CreateNew(DjangoGUI _parent)
        {
            InitializeComponent();
            parent = _parent;
        }

        private void ProjectName_Enter(object sender, EventArgs e)
        {
            if (ProjectName.Text == "Click to add project name...")
                ProjectName.Text = "";
        }

        private void ProjectName_Leave(object sender, EventArgs e)
        {
            if (ProjectName.Text == "")
                ProjectName.Text = "Click to add project name...";
        }

        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent);

            parent.NavigationPnl.Controls.Clear();
            parent.NavigationPnl.Controls.Add(welcome);
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            folderDlg.Description = "Select Project Location";

            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                LocationPath.Text = folderDlg.SelectedPath;
            }
        }

        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            if (ProjectName.Text == "Click to add project name...")
                MessageBox.Show("Please enter the project name.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (LocationPath.Text == "" || LocationPath.Text == "Click to select location...")
                MessageBox.Show("Please select a valid location.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (DjangoVersion.SelectedIndex == -1)
                MessageBox.Show("Please select a version of Django.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                MessageBox.Show("Please wait while we setup your project.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                ProjectSetup setup = new ProjectSetup(parent, ProjectName.Text, LocationPath.Text, DjangoVersion.Text);

                parent.NavigationPnl.Controls.Clear();
                parent.NavigationPnl.Controls.Add(setup);
            }
        }

        private void CreateNew_Load(object sender, EventArgs e)
        {
            DjangoVersion.SelectedIndex = 0;
            LocationPath.Text = Environment.CurrentDirectory;
        }

        private void CompareVersions_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.djangoproject.com/en/5.0/releases/");
        }
    }
}
