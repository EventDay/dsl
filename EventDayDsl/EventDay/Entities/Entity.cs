using System;
using System.Collections.Generic;

namespace EventDayDsl.EventDay.Entities
{
    public class Entity
    {
        public Entity(string name)
        {
            Name = name;
            Properties = new HashSet<MessageProperty>(MessageProperty.NameComparer);
        }

        public string Name { get; set; }
        public ISet<MessageProperty> Properties { get; }

        public void AddProperty(string name, string type, bool optional = false)
        {
            var property = new MessageProperty { Name = name, Type = type.SafeTypeName(), Optional = optional };
            if (Properties.Contains(property))
                throw new Exception($"Can not overwrite property '{name}'");

            Properties.Add(property);
        }

        private sealed class NameEqualityComparer : IEqualityComparer<Entity>
        {
            public bool Equals(Entity x, Entity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Entity obj)
            {
                return (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<Entity> NameComparerInstance = new NameEqualityComparer();

        public static IEqualityComparer<Entity> NameComparer
        {
            get { return NameComparerInstance; }
        }
    }
}