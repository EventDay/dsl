// Copyright (C) 2015 EventDay, Inc

using System;
using System.Collections.Generic;

namespace EventDayDsl.EventDay.Entities
{
    public class Message : IMessage
    {
        public Message(string name, IEnumerable<MarkerInterface> interfaces)
        {
            Name = name;
            Interfaces = new HashSet<MarkerInterface>(interfaces);
            Properties = new HashSet<MessageProperty>(MessageProperty.NameComparer);
        }

        public string Name { get; set; }
        public ISet<MarkerInterface> Interfaces { get; set; }

        public ISet<MessageProperty> Properties { get; }

        public static IEqualityComparer<Message> NameComparer { get; } = new NameEqualityComparer();

        public string StringFormat { get; set; }

        public void AddProperty(string name, string type, bool optional = false)
        {
            var property = new MessageProperty {Name = name, Type = type.SafeTypeName(), Optional = optional};
            if (Properties.Contains(property))
                throw new Exception($"Can not overwrite property '{name}'");

            Properties.Add(property);
        }

        private sealed class NameEqualityComparer : IEqualityComparer<Message>
        {
            public bool Equals(Message x, Message y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Message obj)
            {
                return obj.Name?.GetHashCode() ?? 0;
            }
        }
    }

    public class MarkerInterface
    {
        public MarkerInterface(string name)
        {
            Name = name;
            Properties = new HashSet<MessageProperty>(MessageProperty.NameComparer);
        }

        public string Name { get; }

        public ISet<MessageProperty> Properties { get; }

        public static IEqualityComparer<MarkerInterface> NameComparer { get; } = new NameEqualityComparer();

        public void AddProperty(string name, string type, bool optional = false)
        {
            var property = new MessageProperty {Name = name, Type = type.SafeTypeName(), Optional = optional};
            if (Properties.Contains(property))
                throw new Exception($"Can not overwrite property '{name}'");

            Properties.Add(property);
        }

        private sealed class NameEqualityComparer : IEqualityComparer<MarkerInterface>
        {
            public bool Equals(MarkerInterface x, MarkerInterface y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(MarkerInterface obj)
            {
                return obj.Name?.GetHashCode() ?? 0;
            }
        }
    }

    public class MessageProperty
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Optional { get; set; }

        public static IEqualityComparer<MessageProperty> NameComparer { get; } = new NameEqualityComparer();

        private sealed class NameEqualityComparer : IEqualityComparer<MessageProperty>
        {
            public bool Equals(MessageProperty x, MessageProperty y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(MessageProperty obj)
            {
                return obj.Name?.GetHashCode() ?? 0;
            }
        }
    }
}