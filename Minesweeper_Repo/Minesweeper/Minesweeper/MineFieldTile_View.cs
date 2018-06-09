using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MineFieldTile_View : Button
    {
        public const int TILE_WIDTH = 80;//pixels
        public const int TILE_HEIGHT = 80;//pixels

        protected MineFieldTile_Model model;
        protected Minefield_View parent_view;

        public MineFieldTile_View(MineFieldTile_Model inModel, Minefield_View inParent_view)
        {
            model = inModel;
            parent_view = inParent_view;
            this.Width = TILE_WIDTH;
            this.Height = TILE_HEIGHT;
            
            this.MouseUp += this.Btn_Click;//only handles mouse clicks.  Must use Mouse Up to be compatible with right clicking
            /* //Test Code - start
            if (this.model.tileHasMine())
            {
                this.BackColor = System.Drawing.Color.Azure;
            }
            */ // Test Code - end
        }
        protected void Btn_Click(Object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ((MineFieldTile_View)sender).sweep(true);
                    break;
                case MouseButtons.Right:
                    ((MineFieldTile_View)sender).flag();
                    break;
            }
        }

        public MineFieldTile_Model getModel()
        {
            return model;
        }
        public override void Refresh()
        {
            if (this.model.tileHasBeenSwept())
            {
                if (this.model.tileHasMine())
                {
                    this.Text = "BOOM";
                }
                else if (this.model.getNumSurroundingMines() > 0)
                {
                    this.Text = "" + this.model.getNumSurroundingMines();
                }
            }
            base.Refresh();
            parent_view.Refresh();
        }
        public void sweep(bool manualSweep = true)
        {
            this.model.setToSwept();
            this.Enabled = false;
            if (this.model.getNumSurroundingMines() == 0)
                this.parent_view.autoSweep(this);
            this.Refresh();
        }
        public void flag()
        {
            this.Text = "FLAG";
            this.ForeColor = System.Drawing.Color.Red;
            this.Refresh();
        }
    }
}
