using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Snake.NetCore
{
    class Snake : Figure
    {
        private List<Figure> bodySnake = new List<Figure>();
        private Point startPos;
        private static Random rnd = new Random();
        private Direction ?dir = null;
        private Figure empty = new Figure(0, 0, ' ');
        private Figure tempNew = new Figure(0, 0, '>');
        private Figure tempLast = new Figure(0, 0, '<');
        public bool IsLife = true; // Жива ли змейка ? true - жива, false - мертва

        internal Direction ?Dir { get => dir; set => dir = value; }

        public Snake (byte length, char body)
        {
            // Змейка не может быть короче 2-х (голова и туловище)
            if (length < 2)
            {
                length = 2;
            }

            // Генерируем ей место на поле
            Position(length, ref startPos);

            // Создаем голову и туловище змейке в конце очищаем
            bodySnake.Add(new Figure((byte)(startPos.X ), (byte)startPos.Y, '@'));
            for (byte i = 1; i < length; i++)
            {
                bodySnake.Add(new Figure((byte)(startPos.X - i), (byte)startPos.Y, body));
            }
        }

        private void Position (byte length, ref Point startPos) // Генератор места появления змейки
        {
            byte tempX = (byte)(length + 3);
            byte tempY = (byte)rnd.Next(5, 20);
            startPos = new Point(tempX, tempY);
        }

        private void GetPosition ()
        {
            // Переменные для задания новой позиции следующего элемента
            tempNew.PosX = bodySnake[0].PosX;
            tempNew.PosY = bodySnake[0].PosY;

            if (dir == Direction.Right)
                bodySnake[0].PosX++;
            else if (dir == Direction.Left)
                bodySnake[0].PosX--;
            else if (dir == Direction.Up)
                bodySnake[0].PosY--;
            else if (dir == Direction.Down)
                bodySnake[0].PosY++;
            else
                return;

            // Переменные для проверки на не совпадение значений нового элемента
            tempLast.PosX = bodySnake[0].PosX;
            tempLast.PosY = bodySnake[0].PosY;

            Touch(); // Проверяем на соприкосновение с объектами

            // Действия для увеличения туловища и прорисовки только когда длинна вышла за приделы нового экземпляра туловища
            for (int i = 1; i < bodySnake.Count; i++) // Проверяем не совпадает ли следующая часть туловища с предыдущей
            {
                
                    empty.PosX = bodySnake[i].PosX;
                    empty.PosY = bodySnake[i].PosY;

                    tempLast.PosX = tempNew.PosX;
                    tempLast.PosY = tempNew.PosY;

                    bodySnake[i].PosX = tempNew.PosX;
                    bodySnake[i].PosY = tempNew.PosY;

                    tempNew.PosX = empty.PosX;
                    tempNew.PosY = empty.PosY;
            }
            empty.Draw(); // Очищаем последнее место передвижения
        }
        public override void Draw()
        {
            GetPosition(); // Определяем места прорисовки
            for (int i = 0; i < bodySnake.Count; i++) // Прорисовываем каждый экземпляр змейки
            {
                bodySnake[i].Draw();
            }
        }

        private void Touch ()
        {
            if (bodySnake[0].PosX == Program.food.PosX && bodySnake[0].PosY == Program.food.PosY)
            {
                bodySnake.Add(new Figure((bodySnake[bodySnake.Count - 1].PosX), (bodySnake[bodySnake.Count - 1].PosY), '#'));
                Program.food.Create();
            }
            else if (bodySnake[0].PosX > 88 || bodySnake[0].PosX < 2 || bodySnake[0].PosY > 28 || bodySnake[0].PosY < 2)
            {
                dir = null;
                IsLife = false;
            }
        }
    }
}
