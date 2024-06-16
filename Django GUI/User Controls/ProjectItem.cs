using Newtonsoft.Json; // JSON serialization and deserialization library
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Django_GUI.User_Controls.ProjectSetup;

namespace Django_GUI.User_Controls
{
    public partial class ProjectItem : UserControl
    {
        private ExistingProjects existing; // Reference to the ExistingProjects control
        private DjangoGUI parent; // Reference to the main application form
        private string name, path; // Project name and path

        // Constructor that initializes the user control with references to the parent form, existing projects control, project name, and project path
        public ProjectItem(DjangoGUI parent, ExistingProjects existing, string name, string path)
        {
            InitializeComponent(); // Initialize the user control components

            this.existing = existing; // Set the reference to the ExistingProjects control
            this.parent = parent; // Set the reference to the parent form
            this.name = name; // Set the project name
            this.path = path; // Set the project path
        }

        // Event handler for when the mouse enters the Name label
        private void Name_MouseEnter(object sender, EventArgs e)
        {
            Name.ForeColor = Color.Gray; // Change the text color to gray
        }

        // Event handler for when the mouse leaves the Name label
        private void Name_MouseLeave(object sender, EventArgs e)
        {
            Name.ForeColor = Color.White; // Change the text color back to white
        }

        // Event handler for when the DeleteProject button is clicked
        private void DeleteProject_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this project?" +
                "\nThis action can not be undone.", "DjangoGUI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dlg == DialogResult.Yes)
            {
                Directory.Delete(path, true); // Delete the project directory

                // Remove project from JSON file
                string jsonFilePath = Path.Combine(Application.StartupPath, "DjangoProjects.json");

                if (File.Exists(jsonFilePath))
                {
                    string json = File.ReadAllText(jsonFilePath); // Read the JSON file
                    List<ProjectDetails> projects = JsonConvert.DeserializeObject<List<ProjectDetails>>(json); // Deserialize JSON to a list of project details

                    // Find and remove the project
                    ProjectDetails projectToRemove = projects.FirstOrDefault(p => p.ProjectName == name && p.ProjectPath == path);

                    if (projectToRemove != null)
                    {
                        projects.Remove(projectToRemove); // Remove the project from the list

                        // Save the updated list back to the JSON file
                        string updatedJson = JsonConvert.SerializeObject(projects, Formatting.Indented);
                        File.WriteAllText(jsonFilePath, updatedJson); // Write the JSON to the file

                        MessageBox.Show("Project has been deleted.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        existing.ProjectsPnl.Controls.Remove(this); // Remove the project control from the panel
                    }
                    else
                    {
                        MessageBox.Show("Project not found in JSON file.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("JSON file not found.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Event handler for when the Name label is clicked
        private void Name_Click(object sender, EventArgs e)
        {
            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel

            ToolBox toolBox = new ToolBox(parent, name, path); // Create a new ToolBox control with the parent reference, project name, and project path
            parent.NavigationPnl.Controls.Add(toolBox); // Add the ToolBox control to the navigation panel
        }

        // Event handler for when the ProjectItem control loads
        private void ProjectItem_Load(object sender, EventArgs e)
        {
            Name.Text = name; // Set the text of the Name label to the project name
        }
    }
}