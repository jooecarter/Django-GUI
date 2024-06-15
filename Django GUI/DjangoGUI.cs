using Django_GUI.User_Controls;
using System;
using System.Windows.Forms;

namespace Django_GUI
{
    public partial class DjangoGUI : Form
    {
        public DjangoGUI()
        {
            InitializeComponent();
        }

        // Event handler for loading the DjangoGUI form
        private void DjangoGUI_Load(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome(this); // Create a new Welcome control with the current form as the parent
            NavigationPnl.Controls.Add(welcome); // Add the Welcome control to the NavigationPnl
        }
    }
}