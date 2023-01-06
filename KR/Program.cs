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
            string playerName = Console.ReadLine();
            Console.Write("Оберіть тип аккаунту(1 - звичайний, 2 - преміум, 3 - з низкою перемог): ");
            int typeOfAccount = Convert.ToInt32(Console.ReadLine());
            Account Player_1 = null;
            if (typeOfAccount == 1)
            {
                Player_1 = new Account(playerName);
            }
            if (typeOfAccount == 2)
            {
                Player_1 = new PremiumAccount(playerName);
            }
            if (typeOfAccount == 3)
            {
                Player_1 = new WinStreakAccount(playerName);
            }
            Console.Write("\n\nВведіть ім'я другого гравця: ");
            playerName = Console.ReadLine();
            Console.Write("Оберіть тип аккаунту(1 - звичайний, 2 - преміум, 3 - з низкою перемог): ");
            typeOfAccount = Convert.ToInt32(Console.ReadLine());
            Account Player_2 = null;
            if (typeOfAccount == 1)
            {
                Player_2 = new Account(playerName);
            }
            if (typeOfAccount == 2)
            {
                Player_2 = new PremiumAccount(playerName);
            }
            if (typeOfAccount == 3)
            {
                Player_2 = new WinStreakAccount(playerName);
            }
            Game game = new Game(Player_1, Player_2, ratingForGame);


            while (true)
            {
                Console.Write("\n\nОберіть:\n1 - Почати грати\n2 - Переглянути історію гравців\n");
                Console.Write("3 - Автоматична перемога першого гравця\n4 - Автоматична перемога другого гравця\n");
                Console.Write("5 - Закінчити виконання програми\nВибір: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
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
                    game.StartAutoGame(new Game(Player_1, Player_2, ratingForGame), Player_1);
                }
                if(choice == 4)
                {
                    game.StartAutoGame(new Game(Player_1, Player_2, ratingForGame), Player_2);
                }
                if(choice == 5)
                {
                    break;
                }
            }
        }
    }
}   