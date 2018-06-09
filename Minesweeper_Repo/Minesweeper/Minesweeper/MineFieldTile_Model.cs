using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class MineFieldTile_Model
    {
        protected Minefield_Model parent_field;
        protected int xPos, yPos;
        protected bool hasMine = false;
        protected bool hasBeenSwept = false;

        public MineFieldTile_Model(Minefield_Model inParent_field, int inYPos, int inXPos, bool inHasMine = false)
        {
            parent_field = inParent_field;
            yPos = inYPos;
            xPos = inXPos;
            hasMine = inHasMine;
        }

        public bool tileHasMine()
        {
            return hasMine;
        }
        public int getXPos()
        {
            return xPos;
        }
        public int getYPos()
        {
            return yPos;
        }
        public bool tileHasBeenSwept()
        {
            return hasBeenSwept;
        }
        public int getNumSurroundingMines()
        {
            return this.parent_field.getNumSurroundingMines(this.yPos, this.xPos);
        }
        public void setToSwept()
        {
            this.hasBeenSwept = true;
        }
    }
}
