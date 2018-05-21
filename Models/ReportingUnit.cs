using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common;

namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit
    {
        public ReportingUnit(double buildTime) : base(buildTime)
        {
        }


        //public delegate void OnStatusEventHandler(object sender, EventArgs e);

        //public event OnStatusEventHandler UnitStatusChanged;

        public event EventHandler<EventArgs> UnitStatusChanged;

        public virtual void OnStatusChanged(string newStatus)
        {
            if (UnitStatusChanged != null)
            {
                UnitStatusChanged(this, new StatusChangedEventArgs { NewStatus = newStatus });
            }
        }
        


























        /*public event EventHandler<StatusChangedEventArgs> UnitStatusChanged;

        public virtual void OnStatusChanged(StatusChangedEventArgs args)
        {
            if (_status != value)
            {
                _status = value;
                if (UnitStatusChanged != null)
                {
                    UnitStatusChanged(this, args);
                }
            }
        }*/













        /*public ReportingUnit(double buildTime) : base(buildTime)
        {
        }

        public virtual void OnStatusChanged(EventArgs args)
        {
            if (OnUnitStatusChanged != null)
            {
                OnUnitStatusChanged("new status");
            }
        }

        public event UnitStatusChanged OnUnitStatusChanged;

        public delegate void UnitStatusChanged(string status);

        public void Test()
        {
            if (OnUnitStatusChanged != null)
                OnUnitStatusChanged("Statut modifié");
        }*/

    }
}
