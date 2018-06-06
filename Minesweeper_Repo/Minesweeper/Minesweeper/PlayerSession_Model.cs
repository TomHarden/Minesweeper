using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class PlayerSession_Model
    {
        protected List<Minesweeper_Game> sessionGames;
        protected Minesweeper_Game currentGame;
        //protected List<GameRecord_Model> gameRecords;//records the moves the player makes in the order they were made.
        public PlayerSession_Model()
        {
            //gameRecords = new List<GameRecord_Model>();
            sessionGames = new List<Minesweeper_Game>();
            newGame();
        }
        public void newGame(Minesweeper_Game inCurrentGame)
        {
            currentGame = inCurrentGame;
            sessionGames.Add(currentGame);
            //gameRecords.Add(new GameRecord_Model(currentGame));
        }
        public void newGame()
        {
            newGame(new Minesweeper_Game(this));
        }
        public int getWins()
        {
            int total = 0;
            foreach(Minesweeper_Game game in sessionGames)
            {
                if (game.getStatus() == GameStatus.VICTORY)
                {
                    total++;
                }
            }
            return total;
        }
        public int getLosses()
        {
            int total = 0;
            foreach (Minesweeper_Game game in sessionGames)
            {
                if (game.getStatus() == GameStatus.LOSS)
                {
                    total++;
                }
            }
            return total;
        }
        public int getTotalGames()
        {
            return sessionGames.Count;
        }
        public Minesweeper_Game getCurrentGame()
        {
            return currentGame;
        }
    }
}
