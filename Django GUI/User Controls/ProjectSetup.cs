using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Django_GUI.User_Controls
{
    public partial class ProjectSetup : UserControl
    {
        private DjangoGUI parent; // Reference to the parent form

        private string projectName, projectPath, projectVersion; // Variables to store project details

        private bool pythonInstalled = false, shouldRetry = false;

        public ProjectSetup(DjangoGUI parent, string projectName, string projectPath, string projectVersion)
        {
            InitializeComponent();

            this.parent = parent;

            // Initialize project details
            this.projectName = projectName;
            this.projectPath = projectPath;
            this.projectVersion = projectVersion;
        }

        private void AddToPath(string directory)
        {
            string path = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
            if (!path.Split(';').Contains(directory))
            {
                path = string.Join(";", path, directory);
                Environment.SetEnvironmentVariable("PATH", path, EnvironmentVariableTarget.User);
            }
        }

        // Event handler for loading the ProjectSetup control
        private async void ProjectSetup_Load(object sender, EventArgs e)
        {
            rtbOutput.Clear(); // Clear the output text box
            await Task.Run(() => CreateDjangoProject(projectName, projectPath, projectVersion)); // Create the Django project

            if (pythonInstalled == false)
            {
                PreviousStep.Location = new Point(300, 190);
                InstallPython.Visible = true;
            }
            else
            {
                // Show buttons for next actions after the project setup is complete
                OpenFiles.Visible = true;
                OpenIDE.Visible = true;
                RunServer.Visible = true;
            }

            PreviousStep.Visible = true;
        }

        private bool IsPythonInstalled()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c python --version")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = Directory.GetCurrentDirectory()
                };

                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (error.Contains("Python was not found"))
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch
            {
                // Ignore exceptions and return false
            }

            return false;
        }

        private bool IsPipInstalled()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c python -m pip --version")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = Directory.GetCurrentDirectory()
                };

                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (output.Contains("pip") || error.Contains("pip"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // Ignore exceptions and return false
            }

            return false;
        }

        private void InstallPip()
        {
            // Ensure pip is installed
            RunCommand("python -m ensurepip --default-pip", Directory.GetCurrentDirectory());

            // Upgrade pip to the latest version
            RunCommand("python -m pip install --upgrade pip", Directory.GetCurrentDirectory());
        }

        // Create a new Django project
        private void CreateDjangoProject(string projectName, string directory, string version)
        {
            try
            {
                // Ensure Python is installed
                if (!IsPythonInstalled())
                {
                    pythonInstalled = false;

                    AppendTextToOutput("Python is not installed. Please install Python before setting up the Django project.");
                    return;
                }
                else { pythonInstalled = true; }

                // Ensure pip is installed
                if (!IsPipInstalled())
                {
                    AppendTextToOutput("pip is not installed. Installing pip...");
                    InstallPip();
                    AppendTextToOutput("pip installed successfully.");
                }

                // Install virtualenv
                RunCommand("python -m pip install virtualenv", directory);

                // Navigate to the desired folder and setup a new virtual environment
                RunCommand($"cd \"{directory}\" && python -m virtualenv {projectName}", directory);
                AppendTextToOutput($"Virtual environment '{projectName}' created successfully.");

                // Activate the virtual environment
                string activateCommand = $"cd \"{Path.Combine(directory, projectName)}\" && Scripts\\activate";
                AppendTextToOutput($"Activating virtual environment '{projectName}'.");

                // Install Django inside the virtual environment
                string installDjangoCommand = $"{activateCommand} && python -m pip install django=={version}";
                RunCommand(installDjangoCommand, directory);
                AppendTextToOutput($"Django {version} installed successfully.");

                // Create a new Django project
                string projectDirectory = Path.Combine(directory, projectName);
                string djangoAdminCommand = $"{activateCommand} && django-admin startproject {projectName}";
                RunCommand(djangoAdminCommand, projectDirectory);
                AppendTextToOutput($"Django project '{projectName}' created successfully.");

                // Create a requirements.txt file
                string createRequirementsFileCommand = $"{activateCommand} && python -m pip freeze > requirements.txt";
                RunCommand(createRequirementsFileCommand, projectDirectory);
                AppendTextToOutput("requirements.txt file created successfully.");

                AppendTextToOutput("Setup Complete.");

                // Write project details to JSON file
                WriteProjectDetailsToJson(projectName, directory);
            }
            catch (Exception ex)
            {
                AppendTextToOutput($"Error: {ex.Message}");

                // Check if the error contains the PATH warning
                if (ex.Message.Contains("which is not on PATH"))
                {
                    string pathToAdd = ExtractPathFromWarning(ex.Message);
                    AddToPath(pathToAdd);
                    AppendTextToOutput($"Added {pathToAdd} to PATH.");
                    shouldRetry = true;
                }
            }
        }

        private string ExtractPathFromWarning(string message)
        {
            var start = message.IndexOf("installed in '") + "installed in '".Length;
            var end = message.IndexOf("'", start);
            return message.Substring(start, end - start);
        }


        // Run a command in the command prompt
        private void RunCommand(string command, string workingDirectory)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
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
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }

        // Run the Django development server
        private void RunServerCmd(string projectName, string directory)
        {
            // Construct the paths and commands to run the server
            string projectPath = Path.Combine(directory, projectName);
            string managePyDirectory = Path.Combine(projectPath, projectName);
            string activateCommand = $"cd \"{projectPath}\"";
            string runServerCommand = $"{activateCommand} && Scripts\\activate && python manage.py runserver";
            RunCommand(runServerCommand, managePyDirectory);
            AppendTextToOutput("Django development server is running.");
        }

        // Event handler for running the Django development server
        private async void RunServer_Click(object sender, EventArgs e)
        {
            await Task.Run(() => RunServerCmd(projectName, projectPath)); // Run the server in a background task

            // Launch the URL in the default browser
            OpenUrlInBrowser("http://127.0.0.1:8000");
        }

        // Open a URL in the default browser
        private void OpenUrlInBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                AppendTextToOutput($"Failed to open URL: {ex.Message}");
            }
        }

        // Event handler for opening project files in Windows Explorer
        private void OpenFiles_Click(object sender, EventArgs e)
        {
            string projectPath = Path.Combine(this.projectPath, projectName);

            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", $"\"{projectPath}\"") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                AppendTextToOutput($"Failed to open project in Explorer: {ex.Message}");
            }
        }

        // Event handler for opening the project in the IDE
        private void OpenIDE_Click(object sender, EventArgs e)
        {
            string projectPath = Path.Combine(this.projectPath, projectName);

            try
            {
                // Assuming Visual Studio Code is the IDE
                Process.Start(new ProcessStartInfo("code", $"\"{projectPath}\"") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                AppendTextToOutput($"Failed to open project in IDE: {ex.Message}");
            }
        }

        // Event handler for going back to the previous step
        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent); // Create a new Welcome control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(welcome); // Add the Welcome control to the navigation panel
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

        private void InstallPython_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.python.org/downloads/");
        }

        // Method to write project details to a JSON file
        private void WriteProjectDetailsToJson(string projectName, string directory)
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
                ProjectName = projectName,
                ProjectPath = Path.Combine(directory, projectName) + "\\" + projectName
            });

            // Write the updated list to the JSON file
            string updatedJson = JsonConvert.SerializeObject(projects, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);
        }

        // Class to hold project details
        public class ProjectDetails
        {
            public string ProjectName { get; set; }
            public string ProjectPath { get; set; }
        }
    }
}