using Django_GUI.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Django_GUI
{
    public partial class DjangoGUI : Form
    {
        public DjangoGUI()
        {
            InitializeComponent();
        }

        private void DjangoGUI_Load(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            NavigationPnl.Controls.Add(welcome);
        }
    }
}
