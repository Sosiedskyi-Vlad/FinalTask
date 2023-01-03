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
                        Console.WriteLine(PlayerHistory.FirstPlayer.playerName);
                    }
                    else
                    {
                        Console.WriteLine(PlayerHistory.SecondPlayer.playerName);
                    }
                }
                else
                {
                    if (PlayerHistory.SecondPlayer != this)
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
