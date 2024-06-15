using System;
using System.Windows.Forms;

namespace Django_GUI.User_Controls
{
    public partial class Welcome : UserControl
    {
        DjangoGUI parent; // Reference to the parent form

        public Welcome(DjangoGUI _parent)
        {
            InitializeComponent();
            this.parent = _parent; // Set the parent reference
        }

        // Event handler for the CreateNewProject button click event
        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            CreateNew createNew = new CreateNew(parent); // Create a new CreateNew control with the parent reference

            parent.NavigationPnl.Controls.Clear(); // Clear the current controls in the navigation panel
            parent.NavigationPnl.Controls.Add(createNew); // Add the CreateNew control to the navigation panel
        }
    }
}
