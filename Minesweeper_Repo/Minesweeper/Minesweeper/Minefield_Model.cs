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

        public Minefield_Model(int inHeight, int inWidth, int inNumMines = 1)
        {
            height = inHeight;
            width = inWidth;
            numMines = inNumMines;

            generateMineMap(ref mineMap);
            allTiles_Model = new MineFieldTile_Model[height][];
            for (int i = 0; i < height; i++)
            {
                allTiles_Model[i] = new MineFieldTile_Model[width];
                for (int j = 0; j < width; j++)
                {
                    allTiles_Model[i][j] = new MineFieldTile_Model(this, i, j, mineMap[i][j]);
                }
            }
        }

        protected void generateMineMap(ref bool[][] ref_mineMap)
        {
            ref_mineMap = new bool[height][];
            for (int i = 0; i < height; i++)
            {
                ref_mineMap[i] = new bool[width];
                for (int j = 0; j < width; j++)
                {
                    ref_mineMap[i][j] = false;
                }
            }
            int placedMines = 0;
            Random rand = new Random();
            while (placedMines < numMines)
            {
                int y = rand.Next(height);
                int x = rand.Next(width);
                if (ref_mineMap[y][x] == false)
                {
                    ref_mineMap[y][x] = true;
                    placedMines++;
                }
            }
        }
        public MineFieldTile_Model[][] getAllTiles_Model()
        {
            return allTiles_Model;
        }
        public MineFieldTile_Model getMineFieldTile_Model(int y, int x)
        {
            return allTiles_Model[y][x];
        }
        public int getHeight()
        {
            return height;
        }
        public int getWidth()
        {
            return width;
        }
        public int getNumMines()
        {
            return numMines;
        }
        public int getNumSurroundingMines(int y, int x)
        {
            //it can be assumed that minemap[x][y] is not a mine
            int surroundingMines = 0;
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
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
        public int totalSweptTiles()
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
