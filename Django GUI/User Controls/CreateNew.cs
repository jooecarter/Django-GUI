using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Django_GUI.User_Controls
{
    public partial class CreateNew : UserControl
    {
        private DjangoGUI parent; // Reference to the parent form

        public CreateNew(DjangoGUI _parent)
        {
            InitializeComponent(); // Initialize the components on the form
            parent = _parent; // Set the parent reference
        }

        // Event handler for when the ProjectName text box gains focus
        private void ProjectName_Enter(object sender, EventArgs e)
        {
            if (ProjectName.Text == "Click to add project name...") // If the placeholder text is present
                ProjectName.Text = ""; // Clear the text box
        }

        // Event handler for when the ProjectName text box loses focus
        private void ProjectName_Leave(object sender, EventArgs e)
        {
            if (ProjectName.Text == "") // If the text box is empty
                ProjectName.Text = "Click to add project name..."; // Restore the placeholder text
        }

        // Event handler for when the PreviousStep button is clicked
        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent); // Create a new Welcome control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(welcome); // Add the Welcome control to the navigation panel
        }

        // Event handler for when the Browse button is clicked
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog(); // Create a new folder browser dialog
            folderDlg.ShowNewFolderButton = true; // Allow the user to create a new folder
            folderDlg.Description = "Select Project Location"; // Set the description of the dialog

            // Show the FolderBrowserDialog and check if the user selected a folder
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                LocationPath.Text = folderDlg.SelectedPath; // Set the LocationPath text box to the selected folder path
            }
        }

        // Event handler for when the CreateNewProject button is clicked
        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            // Validate the input fields and show appropriate messages
            if (ProjectName.Text == "Click to add project name...")
                MessageBox.Show("Please enter the project name.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (LocationPath.Text == "" || LocationPath.Text == "Click to select location...")
                MessageBox.Show("Please select a valid location.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (DjangoVersion.SelectedIndex == -1)
                MessageBox.Show("Please select a version of Django.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                MessageBox.Show("Please wait while we setup your project.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Create a new ProjectSetup control with the necessary information
                ProjectSetup setup = new ProjectSetup(parent, ProjectName.Text, LocationPath.Text, DjangoVersion.Text);

                parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
                parent.NavigationPnl.Controls.Add(setup); // Add the ProjectSetup control to the navigation panel
            }
        }

        // Event handler for when the CreateNew control is loaded
        private void CreateNew_Load(object sender, EventArgs e)
        {
            DjangoVersion.SelectedIndex = 0; // Set the default selected Django version to the first item
            LocationPath.Text = Environment.CurrentDirectory; // Set the LocationPath text box to the current directory
        }

        // Event handler for when the CompareVersions button is clicked
        private void CompareVersions_Click(object sender, EventArgs e)
        {
            // Open the Django releases page in the default web browser
            Process.Start("https://docs.djangoproject.com/en/5.0/releases/");
        }

        private void ProjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get the current text including the new character
            string currentText = ProjectName.Text + e.KeyChar;

            // Validate the character
            if (!IsValidDjangoAppName(currentText))
            {
                // Suppress the key press to prevent the invalid character from being entered
                e.Handled = true;
            }
        }

        private bool IsValidDjangoAppName(string name)
        {
            // Check if the name starts with a letter or underscore
            if (string.IsNullOrEmpty(name) || !(char.IsLetter(name[0]) || name[0] == '_'))
            {
                return false;
            }

            // Use a regular expression to check for valid characters (letters, digits, and underscores)
            return Regex.IsMatch(name, @"^[a-zA-Z_][a-zA-Z0-9_]*$");
        }
    }
}
