using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class MineFieldTile_View : Button
    {
        public const int TILE_WIDTH = 50;//pixels
        public const int TILE_HEIGHT = 50;//pixels

        protected MineFieldTile_Model model;
        protected Minefield_View parent_view;

        public MineFieldTile_View(MineFieldTile_Model inModel, Minefield_View inParent_view)
        {
            model = inModel;
            parent_view = inParent_view;
            this.Width = TILE_WIDTH;
            this.Height = TILE_HEIGHT;
            this.Click += this.Btn_Click;

            //Test Code - start
            /*if (this.model.tileHasMine())
            {
                this.BackColor = System.Drawing.Color.Azure;
            }*/
            // Test Code - end
        }
        protected void Btn_Click(Object sender, EventArgs e)
        {
            MineFieldTile_View b = (MineFieldTile_View)sender;
            b.model.setToSwept();
            if (b.model.tileHasMine())
            {
                b.Text = "BOOM";
            }
            else
            {
                b.Text = "" + b.model.getNumSurroundingMines();
            }
            //b.model.updateParent();
        }
    }
}
