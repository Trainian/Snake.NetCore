using System;
using System.Threading;

namespace Snake.NetCore
{
    class Program
    {
        public static Food food;
        static void Main(string[] args)
        {
            Settings();
            Snake snake = new Snake(3, '#');
            food = new Food (0, 0, '&');
            snake.Draw();
            food.Create();
            while (snake.IsLife)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo btn = Console.ReadKey();
                    if (btn.Key == ConsoleKey.LeftArrow && snake.Dir != Direction.Right)
                    {
                        snake.Dir = Direction.Left;
                    }
                    if (btn.Key == ConsoleKey.RightArrow && snake.Dir != Direction.Left)
                    {
                        snake.Dir = Direction.Right;
                    }
                    if (btn.Key == ConsoleKey.DownArrow && snake.Dir != Direction.Up)
                    {
                        snake.Dir = Direction.Down;
                    }
                    if (btn.Key == ConsoleKey.UpArrow && snake.Dir != Direction.Down)
                    {
                        snake.Dir = Direction.Up;
                    }
                }
                snake.Draw();
                Thread.Sleep(200);
            }
            
            Console.WriteLine("The End.");
            Console.ReadKey();
        }

        private static void Settings ()
        {
            // Работаем с консолькой
            Console.SetWindowSize(90, 30);
            Console.SetBufferSize(90, 30);
            Console.CursorVisible = false;

            // Генерируем поля игровой зоны
            Line l = new Line(1, 89, 1, '*', Direction.Right);
            Line l2 = new Line(1, 29, 1, '+', Direction.Down);        
            Line l3 = new Line(1, 89, 29, '*', Direction.Right);          
            Line l4 = new Line(1, 29, 89, '+', Direction.Down);

            // Отрисовываем поля игрового поля
            l.Draw();
            l2.Draw();
            l3.Draw();
            l4.Draw();
        }
    }
}