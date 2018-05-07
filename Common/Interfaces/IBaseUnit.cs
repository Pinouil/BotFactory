

using BotFactory.Common.Tools;

namespace BotFactory.Common.Interface
{
    public interface IBaseUnit
    {
        Coordinates CurrentPos { get; }
        string Name { get; }
        double Move(Coordinates wishPos);
    }
}
