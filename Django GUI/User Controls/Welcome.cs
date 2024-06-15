using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Django_GUI.User_Controls
{
    public partial class Welcome : UserControl
    {
        DjangoGUI parent;
        public Welcome(DjangoGUI _parent)
        {
            InitializeComponent();
            this.parent = _parent;
        }

        private void CreateNewProject_Click(object sender, EventArgs e)
        {
            CreateNew createNew = new CreateNew(parent);

            parent.NavigationPnl.Controls.Clear();
            parent.NavigationPnl.Controls.Add(createNew);
        }
    }
}
