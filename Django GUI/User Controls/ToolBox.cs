using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Django_GUI.User_Controls
{
    public partial class ToolBox : UserControl
    {
        private DjangoGUI parent;

        private string name, path;

        private bool errorOccured = false;

        public ToolBox(DjangoGUI parent, string name, string path)
        {
            InitializeComponent();

            this.name = name;
            this.parent = parent;
            this.path = path;
        }

        private async void ToolBox_Load(object sender, EventArgs e)
        {
            NameLbl.Text = name;

            string batchScriptPath = Path.Combine(Path.GetTempPath(), "run_commands.bat");

            // Create the batch script
            CreateBatchScript(batchScriptPath, Path.GetDirectoryName(path), "Scripts\\activate", path, "python manage.py");

            // Run the batch script
            bool errorOccurred = await RunCommand(batchScriptPath, Path.GetDirectoryName(path));

            if (errorOccurred)
            {
                ControlsPnl.Enabled = false;

                // Show error message
                MessageBox.Show("Could not run the commands. Please check your activation script and manage.py file.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Open UpdatePath dialog
                UpdatePath update = new UpdatePath(parent, name, path);
                update.ShowDialog();
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

        // Event handler for when the PreviousStep button is clicked
        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent); // Create a new Welcome control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(welcome); // Add the Welcome control to the navigation panel
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
                        AppendTextToOutput(e.Data); // Append standard output to the output text box
                        Console.WriteLine(e.Data); // For debugging purposes
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        AppendTextToOutput("Error: " + e.Data); // Append error output to the output text box
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
                AppendTextToOutput($"Error: {ex.Message}");
            }
            finally
            {
                process?.Dispose();
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

        private void ProjectName_Enter(object sender, EventArgs e)
        {
            if (ProjectName.Text == "Write command to the terminal...")
                ProjectName.Text = "";
        }

        private void ProjectName_Leave(object sender, EventArgs e)
        {
            if (ProjectName.Text == "")
                ProjectName.Text = "Write command to the terminal...";
        }

        private async void ProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    AppendTextToOutput(ProjectName.Text);
                    await Task.Run(() => RunCommand(ProjectName.Text, path));
                }
                catch (Exception ex)
                {
                    AppendTextToOutput($"Error: {ex.Message}");
                }

                ProjectName.Text = "Write command to the terminal...";
                StartProject.Focus();
            }
        }

        private void StartProject_Click(object sender, EventArgs e)
        {

        }

        private void StartApp_Click(object sender, EventArgs e)
        {
            CreateApp create = new CreateApp(path);
            create.ShowDialog();
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
    }
}
