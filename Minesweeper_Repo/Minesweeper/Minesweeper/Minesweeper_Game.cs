using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public enum GameStatus { ONGOING, VICTORY, LOSS};
    public class Minesweeper_Game
    {
        protected GameStatus status = GameStatus.ONGOING;
        protected Minefield_Model game;
        protected PlayerSession_Model parentSession;
        protected GameRecord_Model gameRecord;
        public Minesweeper_Game(PlayerSession_Model inParentSession)
        {
            parentSession = inParentSession;
            game = new Minefield_Model(4, 4, 1);//test+_+
            gameRecord = new GameRecord_Model(this);
        }
        public Minefield_Model getMinefield_Model()
        {
            return game;
        }
        public GameStatus getStatus()
        {
            return status;
        }
        public bool playerWon() //checks if the number of tiles swept equals the number of sweepable tiles.  Assumes a square board.
        {
            if (game.totalSweptTiles() + game.getNumMines() == game.getHeight() * game.getWidth())
            {
                this.status = GameStatus.VICTORY;
                return true;
            }
            return false;
        }
        public bool playerLost() //if the player swept a tile with a mine, game over
        {
            foreach (MineFieldTile_Model[] mftm_arr in game.getAllTiles_Model())
                foreach (MineFieldTile_Model mftm in mftm_arr)
                    if (mftm.tileHasBeenSwept() && mftm.tileHasMine())
                    {
                        this.status = GameStatus.LOSS;
                        return true;
                    }
            return false;
        }
    }
}
