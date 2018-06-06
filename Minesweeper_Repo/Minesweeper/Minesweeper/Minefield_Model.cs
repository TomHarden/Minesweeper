using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Minefield_Model
    {
        protected int height, width, numMines;
        protected MineFieldTile_Model[][] allTiles_Model;
        protected bool[][] mineMap;


        public Minefield_Model(int inHeight, int inWidth)
        {
            height = inHeight;
            width = inWidth;
            numMines = inHeight;

            allTiles_Model = new MineFieldTile_Model[width][];
            for (int i = 0; i < allTiles_Model.Length; i++)
            {
                allTiles_Model[i] = new MineFieldTile_Model[height];
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allTiles_Model[i][j] = new MineFieldTile_Model(this, i, j);
                }
            }
        }
        public Minefield_Model(int inHeight, int inWidth, int inNumMines)
        {
            height = inHeight;
            width = inWidth;
            numMines = inNumMines;
            mineMap = new bool[inWidth][];
            for (int i = 0; i < width; i++)
            {
                mineMap[i] = new bool[height];
                for(int j = 0; j < height; j++)
                {
                    mineMap[i][j] = false;
                }
            }
            //mineMap[width / 2][height / 2] = true;//test code

            int placedMines = 0;
            Random rand = new Random();
            while (placedMines < numMines)
            {
                int x = rand.Next(width);
                int y = rand.Next(height);
                if (mineMap[x][y] == false)
                {
                    mineMap[x][y] = true;
                    placedMines++;
                }
            }
           

            allTiles_Model = new MineFieldTile_Model[width][];
            for (int i = 0; i < allTiles_Model.Length; i++)
            {
                allTiles_Model[i] = new MineFieldTile_Model[height];
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allTiles_Model[i][j] = new MineFieldTile_Model(this, i, j, mineMap[i][j]);
                }
            }
        }

        public MineFieldTile_Model[][] getAllTiles_Model()
        {
            return allTiles_Model;
        }
        public MineFieldTile_Model getMineFieldTile_Model(int x, int y)
        {
            return allTiles_Model[x][y];
        }
        public int getHeight()
        {
            return height;
        }
        public int getWidth()
        {
            return width;
        }
        public int getNumSurroundingMines(int x, int y)
        {
            //it can be assumed that minemap[x][y] is not a mine
            int surroundingMines = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    try
                    {
                        if (mineMap[i][j])
                        {
                            surroundingMines++;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return surroundingMines;
        }
        protected int totalSweptTiles()
        {
            int total = 0;
            foreach (MineFieldTile_Model[] mftm_arr in allTiles_Model)
                foreach (MineFieldTile_Model mftm in mftm_arr)
                    if (mftm.tileHasBeenSwept())
                        total++;
            return total;
        }
    }
}
