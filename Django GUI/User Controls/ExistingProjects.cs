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
    public partial class ExistingProjects : UserControl
    {
        public ExistingProjects()
        {
            InitializeComponent();
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
                ProjectItem projectControl = new ProjectItem(project.ProjectName, project.ProjectPath);
                ProjectsPnl.Controls.Add(projectControl);
            }
        }
    }
}
