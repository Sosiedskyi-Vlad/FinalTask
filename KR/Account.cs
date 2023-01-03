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
            Console.WriteLine("\nГравець " + playerName + ".Для доступу до історії ваших ігор обновіть свій аккаунт до статусу Premium");          
        }
    }
}
