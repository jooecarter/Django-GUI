using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Django_GUI.User_Controls.ProjectSetup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Django_GUI.User_Controls
{
    public partial class ExistingProjects : UserControl
    {
        private DjangoGUI parent;

        public ExistingProjects(DjangoGUI parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void ExistingProjects_Load(object sender, EventArgs e)
        {
            string startupPath = Application.StartupPath;
            string jsonFilePath = Path.Combine(startupPath, "DjangoProjects.json");

            // Check if the JSON file exists
            if (!File.Exists(jsonFilePath))
            {
                MessageBox.Show("Projects file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Read the JSON file
            string json = File.ReadAllText(jsonFilePath);
            List<ProjectDetails> projects = JsonConvert.DeserializeObject<List<ProjectDetails>>(json);

            // Clear existing controls
            ProjectsPnl.Controls.Clear();

            // Add a user control for each project
            foreach (var project in projects)
            {
                ProjectItem projectControl = new ProjectItem(parent, this, project.ProjectName, project.ProjectPath);
                ProjectsPnl.Controls.Add(projectControl);
            }

            if (ProjectsPnl.Controls.Count > 3)
            {
                foreach (Control cntrl in ProjectsPnl.Controls)
                    cntrl.Width = 430;
            }
        }

        // Event handler for when the PreviousStep button is clicked
        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent); // Create a new Welcome control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(welcome); // Add the Welcome control to the navigation panel
        }

        private void AddExistingProject_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog(); // Create a new folder browser dialog
            folderDlg.ShowNewFolderButton = true; // Allow the user to create a new folder
            folderDlg.Description = "Please select the directory for your project which contains the manage.py file."; // Set the description of the dialog

            // Show the FolderBrowserDialog and check if the user selected a folder
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string startupPath = Application.StartupPath;
                string jsonFilePath = Path.Combine(startupPath, "DjangoProjects.json");

                List<ProjectDetails> projects;

                if (File.Exists(jsonFilePath))
                {
                    // Read existing JSON file
                    string json = File.ReadAllText(jsonFilePath);
                    projects = JsonConvert.DeserializeObject<List<ProjectDetails>>(json);
                }
                else
                {
                    // Create a new list if the file does not exist
                    projects = new List<ProjectDetails>();
                }

                // Add the new project details
                projects.Add(new ProjectDetails
                {
                    ProjectName = Path.GetFileName(folderDlg.SelectedPath),
                    ProjectPath = folderDlg.SelectedPath
                });

                // Write the updated list to the JSON file
                string updatedJson = JsonConvert.SerializeObject(projects, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFilePath, updatedJson);

                ProjectItem item = new ProjectItem(parent, this, Path.GetFileName(folderDlg.SelectedPath), folderDlg.SelectedPath);
                ProjectsPnl.Controls.Add(item);

                if (ProjectsPnl.Controls.Count > 3)
                {
                    foreach (Control cntrl in ProjectsPnl.Controls)
                        cntrl.Width = 430;
                }
            }
        }
    }
}
