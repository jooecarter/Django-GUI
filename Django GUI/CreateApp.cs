﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Django_GUI
{
    public partial class CreateApp : Form
    {
        private string path = "";

        private bool errorEncountered = false;

        public CreateApp(string path)
        {
            InitializeComponent();

            this.path = path;
        }

        private void AppName_Enter(object sender, EventArgs e)
        {
            if (AppName.Text == "Click to add name...")
                AppName.Text = "";
        }

        private void AppName_Leave(object sender, EventArgs e)
        {
            if (AppName.Text == "")
                AppName.Text = "Click to add name...";
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

        private async void CreateNew_Click(object sender, EventArgs e)
        {
            if (AppName.Text == "Click to add name...")
                MessageBox.Show("Please enter an app name.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (LocationPath.Text == "")
                MessageBox.Show("Please select a location for the path.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                await RunCommand("python manage.py startapp " + AppName.Text, path);

                if (!errorEncountered)
                {
                    MessageBox.Show("App has been created.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActiveForm.Close();
                }
                else
                {
                    MessageBox.Show("Sorry, something went wrong.\nPlease check you are creating a new app in the right directory.", "DjangoGUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task RunCommand(string command, string workingDirectory)
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
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                errorEncountered = false; // Reset error flag before starting the process

                StringBuilder outputBuilder = new StringBuilder();
                StringBuilder errorBuilder = new StringBuilder();

                process.StartInfo = processStartInfo;
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        outputBuilder.AppendLine(e.Data);
                    }
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        errorBuilder.AppendLine(e.Data);
                        errorEncountered = true;
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await Task.Run(() => process.WaitForExit());

                // For debugging purposes, log output and errors
                string output = outputBuilder.ToString();
                string error = errorBuilder.ToString();
                Console.WriteLine("Output: " + output);
                Console.WriteLine("Error: " + error);
            }
        }

        private void CreateApp_Load(object sender, EventArgs e)
        {
            LocationPath.Text = path;

            this.ActiveControl = CreateNew;
        }

        private void AppName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Get the current text including the new character
            string currentText = AppName.Text + e.KeyChar;

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
    }
}
