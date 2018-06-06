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
        protected PlayerSession_Model session;
        public Form1()
        {
            //DialogResult result = MessageBox.Show("Play a game of Minesweeper?", "Welcome!",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.None);
            //if (result == DialogResult.Yes)
            //{
                session = new PlayerSession_Model();
                InitializeComponent();
                MessageBox.Show("Left-click on all tiles without mines to win!", "Instructions");
            //}
            //else if (result == DialogResult.No)
            //{
            //    MessageBox.Show("Goodbye!");
            //    Application.Exit();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public override void Refresh()
        {
            base.Refresh();
            String outcome = "";
            if (session.getCurrentGame().playerWon())
            {
                outcome = "won";
            }
            else if (session.getCurrentGame().playerLost())
            {
                outcome = "lost";
            }
            if (session.getCurrentGame().getStatus() != GameStatus.ONGOING)
            {
                DialogResult result = MessageBox.Show("You've " + outcome + "!!  Would you like to play again?", session.getCurrentGame().getStatus().ToString(),
                MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (result == DialogResult.Yes)
                {
                    session.newGame();
                    MinefieldPanel.Dispose();
                    this.InitializeComponent();
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Thanks for playing!  Here is your performance:" +
                        "\nWins:\t\t" + session.getWins() +
                        "\nLosses:\t\t" + session.getLosses() +
                        "\nGames Played:\t" + session.getTotalGames());
                    MessageBox.Show("Goodbye!");
                    Application.Exit();
                    this.Close();
                }
            }
        }
    }
}
