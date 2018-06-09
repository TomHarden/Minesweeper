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

            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.MinefieldPanel = new Minefield_View(session.getCurrentGame().getMinefield_Model(), this);
                this.SuspendLayout();
                // 
                // flowLayoutPanel1
                // 
                this.MinefieldPanel.Location = new System.Drawing.Point(this.DefaultMargin.Left, this.DefaultMargin.Top);
                this.MinefieldPanel.Name = "Minefield";
                this.MinefieldPanel.TabIndex = 0;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = MinefieldPanel.Size;
                this.Padding = new System.Windows.Forms.Padding(1);
                this.Controls.Add(this.MinefieldPanel);
                this.Name = "Form1";
                this.Text = "MINESWEEPER";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);


            }

            #endregion

            protected Minefield_View MinefieldPanel;
    }
}
