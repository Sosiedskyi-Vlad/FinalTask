using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    internal class GameHistory
    {
        public Account FirstPlayer;
        public Account SecondPlayer;
        public static int Games = 0;
        public static int temp = 0;
        public int GameID;
        public bool IsFirstPlayerWon;

        public GameHistory(Account firstPlayer, Account secondPlayer, bool isFirstPlayerWon)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            IsFirstPlayerWon = isFirstPlayerWon;
            if (temp % 2 == 1)
                Games--;
            GameID = Games;
            Games++;
            temp++;
        }
    }
}
