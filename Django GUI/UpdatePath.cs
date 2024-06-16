using Django_GUI.User_Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Django_GUI.User_Controls.ProjectSetup;

namespace Django_GUI
{
    public partial class UpdatePath : Form
    {
        private string name, currentPath, newPath;
        private DjangoGUI parent;

        public UpdatePath(DjangoGUI parent, string name, string currentPath)
        {
            InitializeComponent();
            this.name = name;
            this.currentPath = currentPath;
            this.parent = parent;
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            string selectedPath = ShowFolderBrowserDialogInSTA();
            if (!string.IsNullOrEmpty(selectedPath))
            {
                LocationPath.Text = selectedPath;
                newPath = selectedPath;
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            ProjectDetails updatedProject = new ProjectDetails
            {
                ProjectName = name,
                ProjectPath = newPath
            };

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

            // Find and remove the matching record
            projects.RemoveAll(p => p.ProjectName == name && p.ProjectPath == currentPath);

            // Add the new record
            projects.Add(updatedProject);

            // Write the updated JSON back to the file
            string updatedJson = JsonConvert.SerializeObject(projects, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);

            MessageBox.Show("Path has been updated.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Update the UI on the UI thread
            if (parent.NavigationPnl.InvokeRequired)
            {
                parent.NavigationPnl.Invoke(new Action(() =>
                {
                    parent.NavigationPnl.Controls.Clear();
                    ExistingProjects existing = new ExistingProjects(parent);
                    parent.NavigationPnl.Controls.Add(existing);
                }));
            }
            else
            {
                parent.NavigationPnl.Controls.Clear();
                ExistingProjects existing = new ExistingProjects(parent);
                parent.NavigationPnl.Controls.Add(existing);
            }

            ActiveForm.Close();
        }

        private void UpdatePath_Load(object sender, EventArgs e)
        {
            ProjectName.Text = name;
            LocationPath.Text = currentPath;
        }

        private string ShowFolderBrowserDialogInSTA()
        {
            string selectedPath = null;

            Thread t = new Thread(() =>
            {
                using (FolderBrowserDialog folderDlg = new FolderBrowserDialog())
                {
                    folderDlg.ShowNewFolderButton = true;
                    folderDlg.Description = "Select Project Location";

                    if (folderDlg.ShowDialog() == DialogResult.OK)
                    {
                        selectedPath = folderDlg.SelectedPath;
                    }
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            return selectedPath;
        }
    }
}
