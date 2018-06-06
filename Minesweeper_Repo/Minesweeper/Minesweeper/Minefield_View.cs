using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class Minefield_View : FlowLayoutPanel
    {
        Minefield_Model model;
        MineFieldTile_View[][] field;//extends button
        public Minefield_View(Minefield_Model inModel)
        {
            model = inModel;
            field = new MineFieldTile_View[model.getWidth()][];
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = new MineFieldTile_View[model.getHeight()];
            }
            for(int i = 0; i < model.getWidth(); i++)
            {
                for (int j = 0; j < model.getHeight(); j++)
                {
                    field[i][j] = new MineFieldTile_View(model.getMineFieldTile_Model(i, j), this);
                    field[i][j].Margin = new Padding(0);
                    this.Controls.Add(field[i][j]);
                }
            }
            this.Width = model.getWidth() * MineFieldTile_View.TILE_WIDTH;
            this.Height = model.getHeight() * MineFieldTile_View.TILE_HEIGHT;
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);

  
        }

    }
}
