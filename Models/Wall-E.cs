using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public class Wall_E : WorkingUnit
    {
        public Wall_E()
            : base("Wall_E", 2)
        {
             BuildTime = 4000;
        }
    }
}
