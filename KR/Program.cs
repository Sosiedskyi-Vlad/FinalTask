using System;

namespace KR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть ім'я першого гравця: ");
            string firstPlayerName = Console.ReadLine();
            Console.Write("Введіть ім'я другого гравця: ");
            string secondPlayerName = Console.ReadLine();
            Account Player_1 = new Account(firstPlayerName);
            PremiumAccount Player_2 = new PremiumAccount(secondPlayerName);
            Game game = new Game(Player_1, Player_2);
            Game.StartGame(game);
            
            while (true)
            {
                Console.Write("Оберіть:\n1 - Продовжити грати\n2 - Переглянути історія гравців\n3 - Закінчити виконання програми\nВибір: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Game.StartGame(new Game(Player_1, Player_2));
                }
                if(choice == 2)
                {
                    Player_1.GetStats();
                    Player_2.GetStats();
                }
                if(choice == 3)
                {
                    break;
                }
            }
        }
    }
}   