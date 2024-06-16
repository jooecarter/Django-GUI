using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Django_GUI.User_Controls
{
    public partial class ToolBox : UserControl
    {
        private DjangoGUI parent; // Reference to the main application form
        private string name, path; // Variables to store project name and path
        private Process serverProcess; // Variable to store the server process

        // Constructor to initialize the user control with project details
        public ToolBox(DjangoGUI parent, string name, string path)
        {
            InitializeComponent();
            this.name = name; // Set the project name
            this.parent = parent; // Set the parent reference
            this.path = path; // Set the project path
        }

        // Event handler for loading the ToolBox control
        private async void ToolBox_Load(object sender, EventArgs e)
        {
            NameLbl.Text = name; // Set the text of the Name label to the project name

            string batchScriptPath = Path.Combine(Path.GetTempPath(), "run_commands.bat");

            // Create the batch script
            CreateBatchScript(batchScriptPath, Path.GetDirectoryName(path), "Scripts\\activate", path, "python manage.py");

            // Run the batch script
            bool errorOccurred = await RunCommand(batchScriptPath, Path.GetDirectoryName(path));

            if (errorOccurred)
            {
                ControlsPnl.Enabled = false; // Disable the controls panel

                // Show error message
                MessageBox.Show("Could not run the commands. Please check your activation script and manage.py file.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Open UpdatePath dialog
                UpdatePath update = new UpdatePath(parent, name, path);
                update.ShowDialog();
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
                        AppendTextToOutput(e.Data); // Append standard output to the output text box
                        Console.WriteLine(e.Data); // For debugging purposes
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        if (e.Data.Contains("Watching for file changes with StatReloader"))
                        {
                            AppendTextToOutput("Server is active on port 8000");
                            AppendTextToOutput("Url: http://127.0.0.1:8000");
                            AppendTextToOutput("Type 'kill' in the prompt to end the process.");

                            errorOccurred = false;
                            serverProcess = process; // Store the server process
                        }
                        else
                        {
                            AppendTextToOutput("Error: " + e.Data); // Append error output to the output text box
                            Console.WriteLine(e.Data); // For debugging purposes

                            errorOccurred = true;
                        }
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
                AppendTextToOutput($"Error: {ex.Message}");
            }
            finally
            {
                if (process != serverProcess) // Don't dispose the server process
                {
                    process?.Dispose();
                }
            }

            return errorOccurred;
        }

        // Scroll to the bottom of the output text box
        private void ScrollToBottom()
        {
            if (rtbOutput.InvokeRequired)
            {
                rtbOutput.Invoke(new Action(ScrollToBottom));
            }
            else
            {
                rtbOutput.SelectionStart = rtbOutput.Text.Length;
                rtbOutput.ScrollToCaret();
            }
        }

        // Event handler for starting a new Django project
        private void StartProject_Click(object sender, EventArgs e)
        {
            CreateProject create = new CreateProject(path);
            create.ShowDialog();
        }

        // Event handler for starting a new Django app
        private void StartApp_Click(object sender, EventArgs e)
        {
            CreateApp create = new CreateApp(path);
            create.ShowDialog();
        }

        // Event handler for running the Django development server
        private async void RunServer_Click(object sender, EventArgs e)
        {
            string batchScriptPath = Path.Combine(Path.GetTempPath(), "run_commands.bat");

            // Create the batch script
            CreateBatchScript(batchScriptPath, Path.GetDirectoryName(path), "Scripts\\activate", path, "python manage.py runserver");

            // Run the batch script
            bool errorOccurred = await RunCommand(batchScriptPath, Path.GetDirectoryName(path));

            if (!errorOccurred)
                MessageBox.Show("Server has been activated.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handler for handling commands in the command prompt
        private async void CmdPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmdPrompt.Text.Trim().ToLower() == "kill")
                {
                    KillServerByPort(8000); // Kill the server process on port 8000

                    CmdPrompt.Text = "Write command to the terminal...";
                    StartProject.Focus();
                }
                else
                {
                    string batchScriptPath = Path.Combine(Path.GetTempPath(), "run_commands.bat");

                    // Create the batch script
                    CreateBatchScript(batchScriptPath, Path.GetDirectoryName(path), "Scripts\\activate", path, "python manage.py " + CmdPrompt.Text);

                    // Run the batch script
                    bool errorOccurred = await RunCommand(batchScriptPath, Path.GetDirectoryName(path));

                    if (!errorOccurred)
                    {
                        CmdPrompt.Text = "Write command to the terminal...";
                        StartProject.Focus();
                    }
                }
            }
        }

        // Event handler for entering the command prompt
        private void CmdPrompt_Enter(object sender, EventArgs e)
        {
            if (CmdPrompt.Text == "Write command to the terminal...")
                CmdPrompt.Text = "";
        }

        // Event handler for leaving the command prompt
        private void CmdPrompt_Leave(object sender, EventArgs e)
        {
            if (CmdPrompt.Text == "")
                CmdPrompt.Text = "Write command to the terminal...";
        }

        // Append text to the output text box
        private void AppendTextToOutput(string text)
        {
            if (rtbOutput.InvokeRequired)
            {
                rtbOutput.Invoke(new Action<string>(AppendTextToOutput), new object[] { text });
            }
            else
            {
                rtbOutput.AppendText(text + Environment.NewLine);
                ScrollToBottom();
            }
        }

        // Method to kill the server process by port
        private void KillServerByPort(int port)
        {
            try
            {
                // Find the PID using the port
                ProcessStartInfo netstatInfo = new ProcessStartInfo("cmd.exe", "/c netstat -ano | findstr :" + port)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process netstatProcess = Process.Start(netstatInfo);
                StreamReader reader = netstatProcess.StandardOutput;
                string output = reader.ReadToEnd();
                netstatProcess.WaitForExit();

                string[] lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length > 0)
                {
                    string[] parts = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string pid = parts[parts.Length - 1];

                    // Kill the process using the PID
                    ProcessStartInfo taskkillInfo = new ProcessStartInfo("cmd.exe", "/c taskkill /PID " + pid + " /F")
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process taskkillProcess = Process.Start(taskkillInfo);
                    taskkillProcess.WaitForExit();

                    AppendTextToOutput($"Server process with PID {pid} has been terminated.");
                }
                else
                {
                    AppendTextToOutput("No process found using the specified port.");
                }
            }
            catch (Exception ex)
            {
                AppendTextToOutput($"Error: {ex.Message}");
            }
        }

        // Event handler for going back to the previous step
        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent); // Create a new Welcome control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(welcome); // Add the Welcome control to the navigation panel
        }
    }
}