using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.NetCore
{
    class Food : Figure
    {
        private Random rnd = new Random();

        public Food (byte posX, byte posY, char symb) :base (posX,posY,symb)
        {

        }
        public void Create ()
        {
            PosX = (byte)rnd.Next(2, 87);
            PosY = (byte)rnd.Next(2, 27);
            Draw();
        }
    }
}
