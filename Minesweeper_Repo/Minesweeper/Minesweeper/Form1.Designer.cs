namespace Minesweeper
{
    partial class Form1
    {
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

        private Minefield_View MinefieldPanel;
    }
}

