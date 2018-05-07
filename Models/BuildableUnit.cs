using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class BuildableUnit
    {
        private double _buildTime = 5000;
        public double BuildTime
        {
            get { return _buildTime; }
            set { _buildTime = value; }
        }

        public BuildableUnit(double buildTime)
        {
            BuildTime = buildTime;
        }
    }
}
