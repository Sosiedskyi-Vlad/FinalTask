using System;

namespace KR
{
    class Program
    {
        private const int ratingForGame = 20;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("Введіть ім'я першого гравця: ");
            string firstPlayerName = Console.ReadLine();
            Console.Write("Введіть ім'я другого гравця: ");
            string secondPlayerName = Console.ReadLine();
            WinStreakAccount Player_1 = new WinStreakAccount(firstPlayerName);
            PremiumAccount Player_2 = new PremiumAccount(secondPlayerName);
            
            
            Game game = new Game(Player_1, Player_2, ratingForGame);
            game.StartGame(game);

            while (true)
            {
                Console.Write("Оберіть:\n1 - Продовжити грати\n2 - Переглянути історія гравців\n3 - Автоматична перемога першого гравця\n");
                Console.Write("4 - Автоматична перемога другого гравця\n5 - Закінчити виконання програми\nВибір: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    game.StartGame(new Game(Player_1, Player_2, ratingForGame));
                }
                if(choice == 2)
                {
                    Player_1.GetStats();
                    Player_2.GetStats();
                }
                if(choice == 3)
                {
                    game.StartAutoGame(new Game(Player_1, Player_2, ratingForGame), Player_1, Player_2);
                }
                if(choice == 4)
                {
                    game.StartAutoGame(new Game(Player_1, Player_2, ratingForGame), Player_2, Player_1);
                }
                if(choice == 5)
                {
                    break;
                }
                
            }
        }
    }
}   