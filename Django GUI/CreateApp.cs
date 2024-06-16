using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Django_GUI
{
    public partial class CreateApp : Form
    {
        private string path = ""; // Variable to store the path

        // Constructor to initialize the form with the specified path
        public CreateApp(string path)
        {
            InitializeComponent();
            this.path = path; // Set the path
        }

        // Event handler for when the AppName text box gains focus
        private void AppName_Enter(object sender, EventArgs e)
        {
            if (AppName.Text == "Click to add name...")
                AppName.Text = ""; // Clear the text box if the placeholder text is present
        }

        // Event handler for when the AppName text box loses focus
        private void AppName_Leave(object sender, EventArgs e)
        {
            if (AppName.Text == "")
                AppName.Text = "Click to add name..."; // Restore the placeholder text if the text box is empty
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
                path = folderDlg.SelectedPath; // Update the path variable
            }
        }

        // Event handler for when the CreateNew button is clicked
        private async void CreateNew_Click(object sender, EventArgs e)
        {
            if (AppName.Text == "Click to add name...")
                MessageBox.Show("Please enter an app name.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (LocationPath.Text == "")
                MessageBox.Show("Please select a path for the app.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                string batchScriptPath = Path.Combine(Path.GetTempPath(), "run_commands.bat");

                // Create the batch script
                CreateBatchScript(batchScriptPath, Path.GetDirectoryName(path), "Scripts\\activate", path, "python manage.py startapp " + AppName.Text);

                // Run the batch script
                bool errorOccurred = await RunCommand(batchScriptPath, Path.GetDirectoryName(path));

                if (errorOccurred)
                {
                    // Show error message
                    MessageBox.Show("Could not run the commands. Please check your activation script and manage.py file.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("App has been created.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActiveForm.Close(); // Close the form
                }
            }
        }

        // Method to create a batch script
        private void CreateBatchScript(string scriptPath, string activateDirectory, string activateCommand, string managePyDirectory, string managePyCommand)
        {
            using (StreamWriter writer = new StreamWriter(scriptPath))
            {
                writer.WriteLine($"cd /d \"{activateDirectory}\"");
                writer.WriteLine($"{activateCommand} & cd /d \"{managePyDirectory}\" & {managePyCommand}");
            }
        }

        // Method to run a command in the command prompt
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
                        errorOccurred = true; // Set the error flag
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await Task.Run(() => process.WaitForExit()); // Wait for the process to exit
            }
            catch (Exception ex)
            {
                errorOccurred = true; // Set the error flag
            }
            finally
            {
                process?.Dispose(); // Dispose the process
            }

            return errorOccurred; // Return the error flag
        }

        // Event handler for loading the CreateApp form
        private void CreateApp_Load(object sender, EventArgs e)
        {
            LocationPath.Text = path; // Set the LocationPath text box to the initial path
            this.ActiveControl = CreateNew; // Set the CreateNew button as the active control
        }

        // Event handler for key press in the AppName text box
        private void AppName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            // Get the current text including the new character
            string currentText = AppName.Text + e.KeyChar;

            // Validate the character
            if (!IsValidDjangoAppName(currentText))
            {
                // Suppress the key press to prevent the invalid character from being entered
                e.Handled = true;
            }
        }

        // Method to validate the Django app name
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