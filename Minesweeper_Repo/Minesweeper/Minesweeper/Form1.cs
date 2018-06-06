using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DialogResult result = MessageBox.Show("Play a game of Minesweeper?", "Welcome!",
                MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                InitializeComponent();
                MessageBox.Show("Left-click on all tiles without mines to win!", "Instructions");
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Goodbye!");
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
