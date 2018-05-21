using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;
using BotFactory.Common.Tools;

namespace BotFactory.Common.Interface
{
    public interface ITestingUnit : IBaseUnit
    {
        double BuildTime { get; set; }
        bool IsWorking { get; }
        event EventHandler<EventArgs> UnitStatusChanged;

        Task<bool> WorkBegins();
        Task<bool> WorkEnds();

        //Coordinates CurrentPos { get; }
        //string Name { get; }
        //double Move(Coordinates wishPos);
    }
}
