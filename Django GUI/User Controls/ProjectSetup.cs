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

namespace Django_GUI.User_Controls
{
    public partial class ProjectSetup : UserControl
    {
        private DjangoGUI parent;

        private string projectName, projectPath, projectVersion;

        public ProjectSetup(DjangoGUI parent, string projectName, string projectPath, string projectVersion)
        {
            InitializeComponent();

            this.parent = parent;

            this.projectName = projectName;
            this.projectPath = projectPath;
            this.projectVersion = projectVersion;
        }

        private async void ProjectSetup_Load(object sender, EventArgs e)
        {
            rtbOutput.Clear();
            await Task.Run(() => CreateDjangoProject(projectName, projectPath, projectVersion));

            OpenFiles.Visible = true;
            OpenIDE.Visible = true;
            RunServer.Visible = true;
            PreviousStep.Visible = true;
        }

        private bool IsPythonInstalled()
        {
            try
            {
                RunCommand("python --version", Directory.GetCurrentDirectory());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void InstallPython()
        {
            string pythonInstallerUrl = "https://www.python.org/ftp/python/3.9.1/python-3.9.1-amd64.exe";
            string installerPath = Path.Combine(Path.GetTempPath(), "python-installer.exe");

            using (var client = new WebClient())
            {
                client.DownloadFile(pythonInstallerUrl, installerPath);
            }

            RunCommand(installerPath + " /quiet InstallAllUsers=1 PrependPath=1", Path.GetTempPath());
        }

        private bool IsPipInstalled()
        {
            try
            {
                RunCommand("pip --version", Directory.GetCurrentDirectory());
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void InstallPip()
        {
            RunCommand("python -m ensurepip", Directory.GetCurrentDirectory());
            RunCommand("pip install --upgrade pip", Directory.GetCurrentDirectory());
        }


        private void CreateDjangoProject(string projectName, string directory, string version)
        {
            try
            {
                // Ensure Python is installed
                if (!IsPythonInstalled())
                {
                    AppendTextToOutput("Python is not installed. Installing Python...");
                    InstallPython();
                    AppendTextToOutput("Python installed successfully.");
                }

                // Ensure pip is installed
                if (!IsPipInstalled())
                {
                    AppendTextToOutput("pip is not installed. Installing pip...");
                    InstallPip();
                    AppendTextToOutput("pip installed successfully.");
                }

                // Install virtualenv
                RunCommand("pip install virtualenv", directory);

                // Navigate to the desired folder and setup a new virtual environment
                RunCommand($"cd \"{directory}\" && virtualenv {projectName}", directory);
                AppendTextToOutput($"Virtual environment '{projectName}' created successfully.");

                // Activate the virtual environment
                string activateCommand = $"cd \"{Path.Combine(directory, projectName)}\" && Scripts\\activate";
                AppendTextToOutput($"Activating virtual environment '{projectName}'.");

                // Install Django inside the virtual environment
                string installDjangoCommand = $"{activateCommand} && pip install django=={version}";
                RunCommand(installDjangoCommand, directory);
                AppendTextToOutput($"Django {version} installed successfully.");

                // Create a new Django project
                string projectDirectory = Path.Combine(directory, projectName);
                string djangoAdminCommand = $"{activateCommand} && django-admin startproject {projectName}";
                RunCommand(djangoAdminCommand, projectDirectory);
                AppendTextToOutput($"Django project '{projectName}' created successfully.");

                // Create a Project Specification.txt file
                string createRequirementsFileCommand = $"{activateCommand} && pip freeze > Project Specification.txt";
                RunCommand(createRequirementsFileCommand, projectDirectory);
                AppendTextToOutput("Project Specification.txt file created successfully.");

                AppendTextToOutput("Setup Complete.");
            }
            catch (Exception ex)
            {
                AppendTextToOutput($"Error: {ex.Message}");
            }
        }

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
                        AppendTextToOutput(e.Data);
                        Console.WriteLine(e.Data); // For debugging purposes
                    }
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        AppendTextToOutput("Error: " + e.Data);
                        Console.WriteLine(e.Data); // For debugging purposes
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }

        private void RunServerCmd(string projectName, string directory)
        {
            // Run the Django development server
            string projectPath = Path.Combine(directory, projectName);
            string managePyDirectory = Path.Combine(projectPath, projectName);
            string activateCommand = $"cd \"{projectPath}\"";
            string runServerCommand = $"{activateCommand} && Scripts\\activate && python manage.py runserver";
            RunCommand(runServerCommand, managePyDirectory);
            AppendTextToOutput("Django development server is running.");
        }

        private async void RunServer_Click(object sender, EventArgs e)
        {
            // Run the Django development server in a background task
            await Task.Run(() => RunServerCmd(projectName, projectPath));

            // Launch the URL in the default browser
            OpenUrlInBrowser("http://127.0.0.1:8000");
        }

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

        private void PreviousStep_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(parent);

            parent.NavigationPnl.Controls.Clear();
            parent.NavigationPnl.Controls.Add(welcome);
        }

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
