using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Game
    {
        private char[,] board;

        public char currentPlayer;

        public Account Player1 { get; set; }
        public Account Player2 { get; set; }
        public Game(Account player1, Account player2)
        {
            Player1 = player1;
            Player2 = player2;
            board = new char[3, 3];
            currentPlayer = 'X';
            

            //Заповнює поле пустими клітинками
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
        public char getCurrentPlayer()
        {
            return currentPlayer;
        }

        //Робить хід у вказану позицію
        public void MakeMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Недійсний хід. Спробуйте знову.");
                return;
            }
            if (board[row, col] != ' ')
            {
                Console.WriteLine("Клітинка вже зайнята. Спробуйте знову.");
                return;
            }

            board[row, col] = currentPlayer;

            //Переключається на іншого гравця
            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';
            }
        }

        //Повертає true, якщо гра закінчилася (перемога або нічия)
        public bool IsGameOver()
        {
            //Перевірка на виграш у рядках
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
            }

            //Перевірка на виграш на колонках
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true;
                }
            }

            //Перевірка на виграш по діагоналях
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            //Перевірка на нічию
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Повертає переможця гри ("X", "O" або " " для нічиєї)
        public char GetWinner()
        {
            //Перевірте виграш у рядках
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return board[i, 0];
                }
            }
            //Перевірка на виграш у колонках
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return board[0, i];
                }
            }

            //Перевірка на виграш по діагоналях
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }

            //Якщо гра закінчилася і немає переможця, вона повинна бути нічиєю
            return ' ';
        }

        //Повертає рядкове представлення ігрового поля
        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < 3; i++)
            {
                result += "     |     |     \n";
                for (int j = 0; j < 3; j++)
                {
                    result += "  ";
                    result += board[i, j];
                    if (j < 2)
                    {
                        result += "  |";
                    }
                    else
                    {
                        result += "  \n";
                    }
                }
                result += "     |     |     \n";
                if (i < 2)
                {
                    result += "-----------------\n";
                }
                
            }
            return result;
        }

        public static void StartGame(Game game)
        {
            while (!game.IsGameOver())
            {
                Console.WriteLine(game);
                Console.WriteLine("Гравець " + game.currentPlayer + ", введіть рядок і стовпець:");
                var input = Console.ReadLine();
                var parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Неправильні дані. Спробуйте знову.");
                    continue;
                }
                if (!int.TryParse(parts[0], out int row) || !int.TryParse(parts[1], out int col))
                {
                    Console.WriteLine("Неправильні дані. Спробуйте знову.");
                    continue;
                }


                game.MakeMove(row, col);
                Console.Clear();
            }
            Console.WriteLine(game);
            if(game.GetWinner() == 'X')
            {
                game.Player1.WinGame(game);
                game.Player2.LoseGame(game);
            }
            else
            {
                game.Player2.WinGame(game);
                game.Player1.LoseGame(game);
            }
            if (game.GetWinner() == ' ')
            {
                Console.WriteLine("Це нічия!");
            }
            else
            {
                if (game.GetWinner() == 'X')
                    Console.WriteLine("Гравець " + game.Player1.playerName + " переміг!");
                else
                    Console.WriteLine("Гравець " + game.Player2.playerName + " переміг!");
            }

        }
    }
}
