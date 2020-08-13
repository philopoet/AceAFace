using System;

namespace Framework.Game
{
    public interface  IGame
    {
        Guid Id { get; set; }
        DateTime? StartTime { get; set; }
        DateTime? EndTime { get; set; }

    }
}
