using System;
using System.Windows.Forms;

namespace Django_GUI.User_Controls
{
    public partial class Welcome : UserControl
    {
        DjangoGUI parent; // Reference to the parent form

        // Constructor to initialize the user control with the parent reference
        public Welcome(DjangoGUI _parent)
        {
            InitializeComponent(); // Initialize the user control components
            this.parent = _parent; // Set the parent reference
        }

        // Event handler for the CreateNewProject button click event
        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            CreateNew createNew = new CreateNew(parent); // Create a new CreateNew control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(createNew); // Add the CreateNew control to the navigation panel
        }

        // Event handler for the OpenExisting button click event
        private void OpenExisting_Click(object sender, EventArgs e)
        {
            ExistingProjects existing = new ExistingProjects(parent); // Create a new ExistingProjects control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(existing); // Add the ExistingProjects control to the navigation panel
        }
    }
}
