﻿using System;
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
    public partial class ProjectItem : UserControl
    {
        private string name, path;

        public ProjectItem(string name, string path)
        {
            InitializeComponent();
        }


        private void ProjectItem_Load(object sender, EventArgs e)
        {
            Name.Text = name;
        }
    }
}
