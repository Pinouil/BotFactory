using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public double X;
        public double Y;
        public int hash = 0;

        public Coordinates(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(Object obj)
        {            
            Coordinates _obj = (Coordinates)obj;
            if (this.X == _obj.X && this.Y == _obj.Y)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
            //Implémentée car nécessaire si override d'Equals.
        {
            return hash;
            // /!\ faux hash
        }
    }
}
