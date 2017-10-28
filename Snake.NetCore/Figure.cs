using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.NetCore
{
    class Figure
    {
        private byte posX;
        private byte posY;
        private char symb;

        public Figure()
        {
        }
        public Figure (byte posX, byte posY, char symb)
        {
            this.posX = posX;
            this.posY = posY;
            this.symb = symb;
        }

        public byte PosX { get => posX; set => posX = value; }
        public byte PosY { get => posY; set => posY = value; }

        public virtual void Draw ()
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(symb);
        }
    }
}
