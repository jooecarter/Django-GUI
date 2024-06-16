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

namespace Django_GUI.User_Controls
{
    public partial class ProjectItem : UserControl
    {
        private ExistingProjects existing;

        private DjangoGUI parent;

        private string name, path;

        public ProjectItem(DjangoGUI parent, ExistingProjects existing, string name, string path)
        {
            InitializeComponent();

            this.existing = existing;
            this.parent = parent;
            this.name = name;
            this.path = path;
        }

        private void Name_MouseEnter(object sender, EventArgs e)
        {
            Name.ForeColor = Color.Gray;
        }

        private void Name_MouseLeave(object sender, EventArgs e)
        {
            Name.ForeColor = Color.White;
        }

        private void DeleteProject_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this project?" +
                "\nThis action can not be undone.", "DjangoGUI", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dlg == DialogResult.Yes)
            {
                Directory.Delete(path, true);

                // Remove project from JSON file
                string jsonFilePath = Path.Combine(Application.StartupPath, "DjangoProjects.json");

                if (File.Exists(jsonFilePath))
                {
                    string json = File.ReadAllText(jsonFilePath);
                    List<ProjectDetails> projects = JsonConvert.DeserializeObject<List<ProjectDetails>>(json);

                    // Find and remove the project
                    ProjectDetails projectToRemove = projects.FirstOrDefault(p => p.ProjectName == name && p.ProjectPath == path);

                    if (projectToRemove != null)
                    {
                        projects.Remove(projectToRemove);

                        // Save the updated list back to the JSON file
                        string updatedJson = JsonConvert.SerializeObject(projects, Formatting.Indented);
                        File.WriteAllText(jsonFilePath, updatedJson);

                        MessageBox.Show("Project has been deleted.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        existing.ProjectsPnl.Controls.Remove(this);
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

        private void Name_Click(object sender, EventArgs e)
        {
            parent.NavigationPnl.Controls.Clear();

            ToolBox toolBox = new ToolBox(parent, name, path);
            parent.NavigationPnl.Controls.Add(toolBox);
        }

        private void ProjectItem_Load(object sender, EventArgs e)
        {
            Name.Text = name;
        }
    }
}
