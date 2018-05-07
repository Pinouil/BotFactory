using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit
    {
        public ReportingUnit(double buildTime) : base(buildTime)
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
        }
        
    }
}
