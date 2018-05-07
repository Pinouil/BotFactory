using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common
{

    public class StatusChangedEventArgs : EventArgs
    {
        public string NewStatus { get; set; }
        //public override void OnStatusChanged(EventArgs e)
        //{
        //    object ee = new object();
        //    e = (StatusChangedEventArgs) ee;

        //}
    }
}
