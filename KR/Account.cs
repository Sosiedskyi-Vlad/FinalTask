using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    internal class Account
    {
        public string playerName { get; }
        public int gamesCount = 0;

        public Account(string playerName)
        {
            this.playerName = playerName;
        }
        //Історія гравця
        public List<GameHistory> GameResults = new List<GameHistory>();

        public virtual void WinGame(Game game)
        {
            gamesCount++;
            GameResults.Add(new GameHistory(game.Player1, game.Player2, true));

        }

        public virtual void LoseGame(Game game)
        {
            gamesCount++;
            GameResults.Add(new GameHistory(game.Player1, game.Player2, false));
        }
        //Показує всі ігри гравця та їх результат
        public virtual void GetStats()
        {
            Console.WriteLine("\n" + playerName + " зіграв:\t" + gamesCount);
            Console.WriteLine("Історія ігор гравця " + playerName + ": ");
            foreach (GameHistory PlayerHistory in GameResults)
            {
                Console.Write("ID гри: " + PlayerHistory.GameID + "| Опонент - " +
                (PlayerHistory.FirstPlayer == this ? PlayerHistory.SecondPlayer.playerName : PlayerHistory.FirstPlayer.playerName) +
                ". Переможець гри - ");
                if (PlayerHistory.IsFirstPlayerWon)
                {
                    if(PlayerHistory.FirstPlayer == this)
                    {
                        Console.WriteLine(PlayerHistory.FirstPlayer.playerName);
                    }
                    else
                    {
                        Console.WriteLine(PlayerHistory.SecondPlayer.playerName);
                    }
                }
                else
                {
                    if(PlayerHistory.SecondPlayer != this)
                    {
                        Console.WriteLine(PlayerHistory.SecondPlayer.playerName);
                    }
                    else
                    {
                        Console.WriteLine(PlayerHistory.FirstPlayer.playerName);
                    }
                }                
            }
        }
    }
}
