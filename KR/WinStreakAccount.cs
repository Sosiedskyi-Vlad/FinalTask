using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class WinStreakAccount : PremiumAccount
    {
        private const int winStreakPoins = 10;
        private int winStreak = 0;
        public WinStreakAccount(string playerName) : base(playerName) { }
        //обліковий запис серії виграшів отримує бонусні бали, коли гравець виграє 3 або більше разів поспіль
        public override void WinGame(Game game)
        {
            gamesCount++;
            winStreak++;
            int ratingForGame;
            if (winStreak >= 3)
            {
                ratingForGame = winStreakPoins + game.GetRatingForGame(Players.Player1);
                if (ratingForGame < 0)
                {
                    Console.WriteLine("Гра " + game.Player1.gamesCount + ". " + "Рейтинг гри повинен бути більше 0");
                    game.Player1.gamesCount--;
                    return;
                }
                Console.WriteLine(game.Player1.playerName + " отримав 10 очків за низку перемог!");
            }
            else
            {
                ratingForGame = game.GetRatingForGame(Players.Player1);
                if (ratingForGame < 0)
                {
                    Console.WriteLine("Гра " + game.Player1.gamesCount + ". " + "Рейтинг гри повинен бути більше 0");
                    game.Player1.gamesCount--;
                    return;
                } 
            }
            this.rating += ratingForGame;
            GameResults.Add(new GameHistory(game.Player1, game.Player2, true, ratingForGame));
        }
        //Крім того, обліковий запис із серією виграшів втрачає вдвічі менше очок (привілей преміум облікового запису)
        public override void LoseGame(Game game)
        {
            gamesCount++;
            if (winStreak >= 3)
                Console.WriteLine("Серія перемог граця " + this.playerName + " обірвалася. Всього перемог поспіль було " + winStreak);
            winStreak = 0;
            int ratingForGame = game.GetRatingForGame(Players.Player1) / 2;
            if (ratingForGame < 0)
            {
                Console.WriteLine("Гра " + game.Player1.gamesCount + ". " + "Рейтинг гри повинен бути більше 0");
                game.Player1.gamesCount--;
                return;
            }
            this.rating -= ratingForGame;
            if (this.rating < 0)
                this.rating = 1;
            GameResults.Add(new GameHistory(game.Player1, game.Player2, false, ratingForGame));
        }
    }
}
