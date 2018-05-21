using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Models;

namespace BotFactory.Factories
{

    public class UnitFactory : IUnitFactory
    {
        public Queue<IFactoryQueueElement> Queue { get; set; } = new Queue<IFactoryQueueElement>();
        public List<ITestingUnit> Storage { get; set; } = new List<ITestingUnit>();
        private readonly int _queueCapacity;
        private readonly int _storageCapacity;

        public event EventHandler<EventArgs> FactoryStatus;

        public int QueueCapacity { get { return _queueCapacity; } }
        public int StorageCapacity { get { return _storageCapacity; } }


        public int QueueFreeSlots
        {
            get
            {
                return QueueCapacity - Queue.Count;
            }
        }

        public int StorageFreeSlots
        {
            get
            {
                return StorageCapacity - Storage.Count;
            }
        }

        public TimeSpan QueueTime
        {
            get
            {
                int queueTime = 0;
                foreach (var element in Storage)
                {
                    queueTime += (int)element.BuildTime;
                }
                
                return new TimeSpan(0, 0, queueTime / 1000);
            }
        }

        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            _queueCapacity = queueCapacity;
            _storageCapacity = storageCapacity;

            // Mettre des listes
        }

        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos)
        {
            if (Queue.Count > QueueCapacity || Storage.Count > StorageCapacity)
            {
                // Ajouter le retour
                return false;
            }
            
            FactoryQueueElement newElement = new FactoryQueueElement();
            newElement.Name = name;
            newElement.Model = model;
            newElement.ParkingPos = parkingPos;
            newElement.WorkingPos = workingPos;

            Queue.Enqueue(newElement);
             BuildRobot(newElement);

            return true;            
        }

        private void BuildRobot(FactoryQueueElement newElement)
        {
            FactoryStatusArg factoryStatusArg = new FactoryStatusArg();
            factoryStatusArg.QueueBot = newElement;
            if (FactoryStatus != null)
            {
                FactoryStatus(this, factoryStatusArg);
            }            
            BaseUnit robot = (BaseUnit)Activator.CreateInstance(newElement.Model);
            robot.UnitStatusChanged += robotUnitStatusChanged;
            robot.Status = RobotStatus.Built;
        }

        private void robotUnitStatusChanged(object robot, EventArgs statusArgs)
        {
            StatusChangedEventArgs status = (StatusChangedEventArgs)statusArgs;
            if (status.NewStatus == RobotStatus.Built.ToString())
            {
                ITestingUnit robotCast = (ITestingUnit)robot;
                Storage.Add(robotCast);
                Queue.Dequeue();
                FactoryStatusArg factoryStatusArg = new FactoryStatusArg();
                factoryStatusArg.Robot = robotCast;
                if (FactoryStatus != null)
                {
                    FactoryStatus(this, factoryStatusArg);
                }
            }
        }
    }

    public class FactoryStatusArg : EventArgs
    {
        public IFactoryQueueElement QueueBot { get; set; }
        public ITestingUnit Robot { get; set; }
    }
}
