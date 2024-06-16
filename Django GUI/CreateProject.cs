using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Django_GUI
{
    public partial class CreateProject : Form
    {
        private string path = "";

        public CreateProject(string path)
        {
            InitializeComponent();

            this.path = path;
        }

        // Event handler for when the Browse button is clicked
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog(); // Create a new folder browser dialog
            folderDlg.ShowNewFolderButton = true; // Allow the user to create a new folder
            folderDlg.Description = "Select App Location"; // Set the description of the dialog

            // Show the FolderBrowserDialog and check if the user selected a folder
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                LocationPath.Text = folderDlg.SelectedPath; // Set the LocationPath text box to the selected folder path
                path = folderDlg.SelectedPath;
            }
        }

        private void ProjectName_Enter(object sender, EventArgs e)
        {
            if (ProjectName.Text == "Click to add name...")
                ProjectName.Text = "";
        }

        private void ProjectName_Leave(object sender, EventArgs e)
        {
            if (ProjectName.Text == "")
                ProjectName.Text = "Click to add name...";
        }

        private async void CreateNew_Click(object sender, EventArgs e)
        {
            if (ProjectName.Text == "Click to add name...")
                MessageBox.Show("Please enter a project name.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (LocationPath.Text == "")
                MessageBox.Show("Please select a path for the project.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                string batchScriptPath = Path.Combine(Path.GetTempPath(), "run_commands.bat");

                // Create the batch script
                CreateBatchScript(batchScriptPath, Path.GetDirectoryName(path), "Scripts\\activate", path, "python manage.py startproject " + ProjectName.Text);

                // Run the batch script
                bool errorOccurred = await RunCommand(batchScriptPath, Path.GetDirectoryName(path));

                if (errorOccurred)
                {
                    // Show error message
                    MessageBox.Show("Could not run the commands. Please check your activation script and manage.py file.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Project has been created.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActiveForm.Close();
                }
            }
        }

        private void CreateBatchScript(string scriptPath, string activateDirectory, string activateCommand, string managePyDirectory, string managePyCommand)
        {
            using (StreamWriter writer = new StreamWriter(scriptPath))
            {
                writer.WriteLine($"cd /d \"{activateDirectory}\"");
                writer.WriteLine($"{activateCommand} & cd /d \"{managePyDirectory}\" & {managePyCommand}");
            }
        }

        private async Task<bool> RunCommand(string command, string workingDirectory)
        {
            bool errorOccurred = false;
            Process process = null;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = workingDirectory
                };

                process = new Process
                {
                    StartInfo = processStartInfo
                };

                process.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        Console.WriteLine(e.Data); // For debugging purposes
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        Console.WriteLine(e.Data); // For debugging purposes

                        errorOccurred = true;
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await Task.Run(() => process.WaitForExit());
            }
            catch (Exception ex)
            {
                errorOccurred = true;
            }
            finally
            {
                process?.Dispose();
            }

            return errorOccurred;
        }

        private void ProjectName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

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

        private void CreateProject_Load(object sender, EventArgs e)
        {
            LocationPath.Text = path;

            this.ActiveControl = CreateNew;
        }
    }
}
