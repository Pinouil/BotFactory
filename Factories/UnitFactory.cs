using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotFactory.Common.Interface;
using BotFactory.Common.Tools;

namespace BotFactory.Factories
{

    public class UnitFactory : IUnitFactory
    {
        public Queue<IFactoryQueueElement> Queue { get; set; } = new Queue<IFactoryQueueElement>();
        public List<ITestingUnit> Storage { get; set; } = new List<ITestingUnit>();
        private readonly int _queueCapacity;
        private readonly int _storageCapacity;
        public int QueueCapacity { get { return _queueCapacity; } }
        public int StorageCapacity { get { return _storageCapacity; } }

        public Action<object, EventArgs> FactoryStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

            ITestingUnit robot = BuildRobot(newElement);

            Storage.Add(robot);

            /*var task = new Task(() => {
                BuildRobot(newElement);
                Queue.Dequeue();
            });
            
            */

            return true;            
        }

        private ITestingUnit BuildRobot(FactoryQueueElement newElement)
        {
            ITestingUnit robot = (ITestingUnit)Activator.CreateInstance(newElement.Model);
            Console.WriteLine("c'est parti!");
            System.Threading.Thread.Sleep((int)robot.BuildTime);
            Console.WriteLine("Le robot {0} a été terminé", newElement.Model);
            return robot;
        }
    }
}
