using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrozenCandy
{
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
            {
                Game.name = "anonymous player";
            }
            else
            {
                Game.name = NameBox.Text;
            }
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (NameBox.Text == "")
                {
                    Game.name = "anonymous player";
                }
                else
                {
                    Game.name = NameBox.Text;
                }
                Close();
            }
        }
    }
}
