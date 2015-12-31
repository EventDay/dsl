using System.Collections.Generic;

namespace EventDayDsl.EventDay.Entities
{
    public interface IMessage
    {
        string Name { get; set; }
        ISet<MarkerInterface> Interfaces { get; set; }
        ISet<MessageProperty> Properties { get; }
    }
}