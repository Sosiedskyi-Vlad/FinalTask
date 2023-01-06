using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    internal class Account
    {
        const int startRating = 100;  
        public string playerName { get; }
        public int gamesCount = 0;
        public int rating { get; set; }
        //Історія гравця
        public List<GameHistory> GameResults = new List<GameHistory>();
        public Account(string playerName)
        {
            this.playerName = playerName;
            this.rating = startRating;
        }
        public virtual void WinGame(Game game)
        {
            gamesCount++;
            int ratingForGame = game.GetRatingForGame(Players.Player1);
            if (ratingForGame < 0)
            {
                Console.WriteLine("Гра " + game.Player1.gamesCount + ". " + "Рейтинг гри повинен бути більше 0");
                game.Player1.gamesCount--;
                return;
            }
            this.rating += ratingForGame;
            GameResults.Add(new GameHistory(game.Player1, game.Player2, true, ratingForGame));

        }

        public virtual void LoseGame(Game game)
        {
            gamesCount++;
            int ratingForGame = game.GetRatingForGame(Players.Player1);
            if (ratingForGame < 0)
            {
                Console.WriteLine("Гра " + game.Player1.gamesCount + ". " + "Рейтинг гри повинен бути більше 0");
                game.Player1.gamesCount--;
                return;
            }
            this.rating -= ratingForGame;
            if (this.rating < 0)
                rating = 1;
            GameResults.Add(new GameHistory(game.Player1, game.Player2, false, ratingForGame));
        }
        //Показує всі ігри гравця та їх результат
        public virtual void GetStats()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("\nРейтинг гравця " + this.playerName + ": " + this.rating);
            Console.WriteLine("\nГравець " + playerName + ". Для доступу до історії ваших ігор обновіть свій аккаунт до статусу Premium");          
        }
    }
}
