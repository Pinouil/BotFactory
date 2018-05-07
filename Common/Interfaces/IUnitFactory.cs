using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Factories;
using System;
using System.Collections.Generic;

namespace BotFactory.Factories
{
    public interface IUnitFactory
    {
        Queue<IFactoryQueueElement> Queue { get; set; }
        List<ITestingUnit> Storage { get; set; }
        int QueueCapacity { get ;  }
        int StorageCapacity { get ; }
        Action<object, EventArgs> FactoryStatus { get; set; }
        int QueueFreeSlots { get; }
        int StorageFreeSlots { get; }
        TimeSpan QueueTime { get; }

        bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos);

    }
}