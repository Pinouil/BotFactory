using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Models;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit , ITestingUnit
    {
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        public bool IsWorking { get; set; }
        Action<object, EventArgs> ITestingUnit.UnitStatusChanged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WorkingUnit(string name, double speed = 1)
            :base(name, speed)
        {
            _name = name;
            _speed = speed;

        }
        //BaseUnit = new BaseUnit();
        public virtual void  WorkBegins()
        {
            if (!CurrentPos.Equals(WorkingPos))
                Move(WorkingPos);

            //lancer le travail
            // ....

        }
        public virtual void WorkEnds()
        {
            if (!CurrentPos.Equals(ParkingPos))
                Move(ParkingPos);
            
                //Charge
        }

        Task<bool> ITestingUnit.WorkBegins()
        {
            throw new NotImplementedException();
        }

        Task<bool> ITestingUnit.WorkEnds()
        {
            throw new NotImplementedException();
        }
    }
}
