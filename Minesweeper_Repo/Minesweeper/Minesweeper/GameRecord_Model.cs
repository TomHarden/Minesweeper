using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameRecord_Model
    {
        protected Minesweeper_Game game;
        protected List<SweepRecord> allSweepRecords;

        public GameRecord_Model(Minesweeper_Game inGame)
        {
            game = inGame;
        }
        public void record( MineFieldTile_Model affectedTile,//the tile that the user clicked
                            Minefield_Tile_Event action//what the user did to the tile:  swept, flagged, or questioned
                            )
        {
            allSweepRecords.Add(new SweepRecord(affectedTile, action));
        }
    }

    public class SweepRecord
    {
        protected MineFieldTile_Model tile;
        protected Minefield_Tile_Event action;
        public SweepRecord(MineFieldTile_Model inTile, Minefield_Tile_Event inAction)
        {
            tile = inTile;
            action = inAction;
        }
        public MineFieldTile_Model getTile()
        {
            return tile;
        }
        public Minefield_Tile_Event getAction()
        {
            return action;
        }
    }
    public enum Minefield_Tile_Event { SWEEP_MANUAL, SWEEP_AUTO, FLAG, QUESTION };
}
