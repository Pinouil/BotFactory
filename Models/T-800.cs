using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public class T_800 : WorkingUnit
    {
        public T_800()
            : base("T_800", 3)
        {
            BuildTime = 10000;
        }
    }
}
