using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.NetCore
{
    class Line : Figure
    {
        private List<Figure> line = new List<Figure> ();
        public Line(byte StartPos, byte EndPos, byte pos, char symb, Direction dir)
        {
            if (dir == Direction.Right)
            {
                for (int i = StartPos; i < EndPos; i++)
                {
                    line.Add(new Figure((byte)i, pos, symb));
                }
            }
            else
            {
                for (int i = StartPos; i < EndPos; i++)
                {
                    line.Add(new Figure(pos, (byte)i, symb));
                }
            }
        }

        public override void Draw()
        {
            foreach (var i in line)
            {
                i.Draw();
            }
        }
    }
}
