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
        private string _model = "Missing Model";
        public double BuildTime
        {
            get { return _buildTime; }
            set { _buildTime = value; }
        }

        public string Model
        {
            get
            {
                _model = this.GetType().Name;
                return _model;
            }
            set { _model = value; }
        }

        public BuildableUnit(double buildTime)
        {
            BuildTime = buildTime;
            Console.WriteLine("c'est parti!");
            System.Threading.Thread.Sleep((int)BuildTime);
            Console.WriteLine("Le robot a été terminé");
        }
    }
}
