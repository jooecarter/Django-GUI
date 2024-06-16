using Django_GUI.User_Controls; // Namespace for user controls
using Newtonsoft.Json; // JSON serialization and deserialization library
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Django_GUI.User_Controls.ProjectSetup; // Static import for ProjectSetup class

namespace Django_GUI
{
    public partial class UpdatePath : Form
    {
        private string name, currentPath, newPath; // Variables to store project name, current path, and new path
        private DjangoGUI parent; // Reference to the parent form

        // Constructor to initialize the form with the specified parent, project name, and current path
        public UpdatePath(DjangoGUI parent, string name, string currentPath)
        {
            InitializeComponent();
            this.name = name; // Set the project name
            this.currentPath = currentPath; // Set the current path
            this.parent = parent; // Set the parent reference
        }

        // Event handler for when the Browse button is clicked
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            string selectedPath = ShowFolderBrowserDialogInSTA(); // Show the folder browser dialog in STA thread
            if (!string.IsNullOrEmpty(selectedPath))
            {
                LocationPath.Text = selectedPath; // Update the LocationPath text box with the selected path
                newPath = selectedPath; // Update the new path variable
            }
        }

        // Event handler for when the Update button is clicked
        private void Update_Click(object sender, EventArgs e)
        {
            ProjectDetails updatedProject = new ProjectDetails
            {
                ProjectName = name, // Set the project name
                ProjectPath = newPath // Set the new path
            };

            string startupPath = Application.StartupPath; // Get the application startup path
            string jsonFilePath = Path.Combine(startupPath, "DjangoProjects.json"); // Combine the path with the JSON file name

            // Check if the JSON file exists
            if (!File.Exists(jsonFilePath))
            {
                MessageBox.Show("Projects file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read the JSON file
            string json = File.ReadAllText(jsonFilePath);
            List<ProjectDetails> projects = JsonConvert.DeserializeObject<List<ProjectDetails>>(json); // Deserialize JSON to a list of project details

            // Find and remove the matching record
            projects.RemoveAll(p => p.ProjectName == name && p.ProjectPath == currentPath);

            // Add the new record
            projects.Add(updatedProject);

            // Write the updated JSON back to the file
            string updatedJson = JsonConvert.SerializeObject(projects, Formatting.Indented); // Serialize the list to JSON with indentation
            File.WriteAllText(jsonFilePath, updatedJson); // Write the JSON to the file

            MessageBox.Show("Path has been updated.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Update the UI on the UI thread
            if (parent.NavigationPnl.InvokeRequired)
            {
                parent.NavigationPnl.Invoke(new Action(() =>
                {
                    parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
                    ExistingProjects existing = new ExistingProjects(parent); // Create a new ExistingProjects control with the parent reference
                    parent.NavigationPnl.Controls.Add(existing); // Add the ExistingProjects control to the navigation panel
                }));
            }
            else
            {
                parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
                ExistingProjects existing = new ExistingProjects(parent); // Create a new ExistingProjects control with the parent reference
                parent.NavigationPnl.Controls.Add(existing); // Add the ExistingProjects control to the navigation panel
            }

            ActiveForm.Close(); // Close the form
        }

        // Event handler for loading the UpdatePath form
        private void UpdatePath_Load(object sender, EventArgs e)
        {
            ProjectName.Text = name; // Set the ProjectName text box to the project name
            LocationPath.Text = currentPath; // Set the LocationPath text box to the current path
        }

        // Method to show the folder browser dialog in a single-threaded apartment (STA) thread
        private string ShowFolderBrowserDialogInSTA()
        {
            string selectedPath = null; // Variable to store the selected path

            // Create a new thread to show the folder browser dialog
            Thread t = new Thread(() =>
            {
                using (FolderBrowserDialog folderDlg = new FolderBrowserDialog())
                {
                    folderDlg.ShowNewFolderButton = true; // Allow the user to create a new folder
                    folderDlg.Description = "Select Project Location"; // Set the description of the dialog

                    if (folderDlg.ShowDialog() == DialogResult.OK)
                    {
                        selectedPath = folderDlg.SelectedPath; // Set the selected path
                    }
                }
            });

            t.SetApartmentState(ApartmentState.STA); // Set the apartment state to STA
            t.Start(); // Start the thread
            t.Join(); // Wait for the thread to complete

            return selectedPath; // Return the selected path
        }
    }
}