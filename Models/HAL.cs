﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public class HAL : WorkingUnit
    {
        public HAL()
            : base("HAL", 0.5)
        {
            BuildTime = 7000;
        }
    }
}
