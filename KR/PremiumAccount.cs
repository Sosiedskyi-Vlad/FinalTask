using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    internal class PremiumAccount : Account
    {
        public PremiumAccount(string playerName) : base(playerName) { }
        public override void LoseGame(Game game)
        {
            gamesCount++;
            int ratingForGame = game.GetRatingForGame(Players.Player1) / 2;
            if (ratingForGame < 0)
            {
                Console.WriteLine(" " + game.Player1.gamesCount + ". " + "Рейтинг гри повинен бути менше 0");
                game.Player1.gamesCount--;
                return;
            }
            this.rating -= ratingForGame;
            if (this.rating < 0)
                this.rating = 1;
            GameResults.Add(new GameHistory(game.Player1, game.Player2, false, ratingForGame));
        }
        public override void GetStats()
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
                    if (PlayerHistory.FirstPlayer == this)
                    {
                        Console.WriteLine(PlayerHistory.FirstPlayer.playerName + ". Гравець виграв " + PlayerHistory.RatingForGame);
                    }
                    else
                    {
                        Console.WriteLine(PlayerHistory.SecondPlayer.playerName + ". Гравець виграв " + PlayerHistory.RatingForGame);
                    }
                }
                else
                {
                    if (PlayerHistory.SecondPlayer != this)
                    {
                        Console.WriteLine(PlayerHistory.SecondPlayer.playerName + ". Гравець програв " + PlayerHistory.RatingForGame);
                    }
                    else
                    {
                        Console.WriteLine(PlayerHistory.FirstPlayer.playerName + ". Гравець програв " + PlayerHistory.RatingForGame);
                    }
                }
            }
        }
    }
}
