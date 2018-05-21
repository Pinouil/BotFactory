using BotFactory.Common.Interface;
using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {
        protected string _name;
        protected double _speed;
        protected Coordinates _position = new Coordinates(0, 0);
        protected Vector _vector = new Vector();
        private RobotStatus _status = RobotStatus.Building;


        public BaseUnit(string name, double speed = 1): base(5000)
        {
            _name = name;
            _speed = speed;
        }
        
        public RobotStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnStatusChanged(value.ToString());
            }
        }

        public double Move(Coordinates wishPos)
        {
            double _time = 1000*_vector.Length(CurrentPos, wishPos) / _speed;

            //Bon début de réflexion, mais pas la bonne méthode
            if (_time < int.MaxValue)
            {
                int _intTime = (int)_time;
                System.Threading.Thread.Sleep(_intTime);
            }

            return _time;
        }

        public Coordinates CurrentPos
        {
            get
            {
                return _position;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }

    }

    public enum RobotStatus
    { 
        Building, Built
    }
}
