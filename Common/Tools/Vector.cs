using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector
    {

        public double X;
        public double Y;

        public Vector()
        {

        }

        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector vector = new Vector();
            vector.X = end.X - begin.X;
            vector.Y = end.Y - begin.Y;

            return vector;
        }

        public double Length (Coordinates begin, Coordinates end)
        {
            double _length = Math.Sqrt((end.X - begin.X) * (end.X - begin.X) + (end.Y - begin.Y) * (end.Y - begin.Y));
            return _length;
        }
    }
}

