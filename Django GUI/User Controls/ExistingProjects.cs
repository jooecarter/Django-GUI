using Newtonsoft.Json; // JSON serialization and deserialization library
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static Django_GUI.User_Controls.ProjectSetup;

namespace Django_GUI.User_Controls
{
    public partial class ExistingProjects : UserControl
    {
        private DjangoGUI parent; // Reference to the main application form

        // Constructor that initializes the user control with a reference to the parent form
        public ExistingProjects(DjangoGUI parent)
        {
            InitializeComponent(); // Initialize the user control components
            this.parent = parent; // Set the parent reference
        }

        // Event handler for the load event of the user control
        private void ExistingProjects_Load(object sender, EventArgs e)
        {
            string startupPath = Application.StartupPath; // Get the application startup path
            string jsonFilePath = Path.Combine(startupPath, "DjangoProjects.json"); // Combine the path with the JSON file name

            // Check if the JSON file exists
            if (!File.Exists(jsonFilePath))
            {
                MessageBox.Show("Projects file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if the file is not found
                return;
            }

            // Read the JSON file
            string json = File.ReadAllText(jsonFilePath);
            List<ProjectDetails> projects = JsonConvert.DeserializeObject<List<ProjectDetails>>(json); // Deserialize JSON to a list of project details

            // Clear existing controls in the panel
            ProjectsPnl.Controls.Clear();

            // Add a user control for each project in the list
            foreach (var project in projects)
            {
                ProjectItem projectControl = new ProjectItem(parent, this, project.ProjectName, project.ProjectPath); // Create a new project item control
                ProjectsPnl.Controls.Add(projectControl); // Add the project control to the panel
            }

            // Adjust the width of the controls if there are more than 3 projects
            if (ProjectsPnl.Controls.Count > 3)
            {
                foreach (Control cntrl in ProjectsPnl.Controls)
                    cntrl.Width = 430; // Set the width of each control
            }
        }

        // Event handler for when the PreviousStep button is clicked
        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent); // Create a new Welcome control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(welcome); // Add the Welcome control to the navigation panel
        }

        // Event handler for adding an existing project
        private void AddExistingProject_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog(); // Create a new folder browser dialog
            folderDlg.ShowNewFolderButton = true; // Allow the user to create a new folder
            folderDlg.Description = "Please select the directory for your project which contains the manage.py file."; // Set the description of the dialog

            // Show the FolderBrowserDialog and check if the user selected a folder
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string startupPath = Application.StartupPath; // Get the application startup path
                string jsonFilePath = Path.Combine(startupPath, "DjangoProjects.json"); // Combine the path with the JSON file name

                List<ProjectDetails> projects;

                // Check if the JSON file exists
                if (File.Exists(jsonFilePath))
                {
                    // Read existing JSON file
                    string json = File.ReadAllText(jsonFilePath);
                    projects = JsonConvert.DeserializeObject<List<ProjectDetails>>(json); // Deserialize JSON to a list of project details
                }
                else
                {
                    // Create a new list if the file does not exist
                    projects = new List<ProjectDetails>();
                }

                // Add the new project details
                projects.Add(new ProjectDetails
                {
                    ProjectName = Path.GetFileName(folderDlg.SelectedPath), // Get the name of the selected folder
                    ProjectPath = folderDlg.SelectedPath // Get the path of the selected folder
                });

                // Write the updated list to the JSON file
                string updatedJson = JsonConvert.SerializeObject(projects, Newtonsoft.Json.Formatting.Indented); // Serialize the list to JSON with indentation
                File.WriteAllText(jsonFilePath, updatedJson); // Write the JSON to the file

                // Create and add a new project item control for the added project
                ProjectItem item = new ProjectItem(parent, this, Path.GetFileName(folderDlg.SelectedPath), folderDlg.SelectedPath);
                ProjectsPnl.Controls.Add(item);

                // Adjust the width of the controls if there are more than 3 projects
                if (ProjectsPnl.Controls.Count > 3)
                {
                    foreach (Control cntrl in ProjectsPnl.Controls)
                        cntrl.Width = 430; // Set the width of each control
                }
            }
        }
    }
}