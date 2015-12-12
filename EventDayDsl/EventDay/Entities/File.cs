// Copyright (C) 2015 EventDay, Inc

using System;
using System.Collections.Generic;
using System.Linq;

namespace EventDayDsl.EventDay.Entities
{
    public class File
    {
        private readonly Dictionary<string, Tuple<string, string, bool>> _propertyDefinitions;

        public File(string name)
        {
            _propertyDefinitions = new Dictionary<string, Tuple<string, string, bool>>();

            Name = name;
            Messages = new HashSet<Message>(Message.NameComparer);
            MarkerInterfaces = new HashSet<MarkerInterface>();
            Usings = new HashSet<string>
            {
                "System",
                "System.Collections.Generic",
                "Newtonsoft.Json",
                "Akka"
            };
            StateDefinitions = new HashSet<StateDefinition>(StateDefinition.NameComparer);
            Enums = new HashSet<Enumeration>(Enumeration.NameComparer);
            Entities = new HashSet<Entity>(Entity.NameComparer);
        }

        public string Name { get; set; }

        public string Namespace { get; set; }
        public ISet<string> Usings { get; set; }
        public ISet<Message> Messages { get; set; }
        public ISet<Entity> Entities { get; set; }
        public ISet<MarkerInterface> MarkerInterfaces { get; set; }
        public ISet<StateDefinition> StateDefinitions { get; set; }
        public ISet<Enumeration> Enums { get; set; }

        public static IEqualityComparer<File> NameComparer { get; } = new NameEqualityComparer();

        public Tuple<string, string, bool> FindPropertyDefinition(string name)
        {
            var definition =
                _propertyDefinitions.FirstOrDefault(p => p.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            return definition.Key == null ? null : definition.Value;
        }

        public void AddPropertyDefinition(string name, string type, bool optional = false)
        {
            AddPropertyDefinition(name, name, type, optional);
        }

        public void AddPropertyDefinition(string identifier, string name, string type, bool optional = false)
        {
            _propertyDefinitions.Add(identifier, Tuple.Create(name, type.SafeTypeName(), optional));
        }

        public bool ContainsStateDefintion(string name)
        {
            return StateDefinitions.Any(x => x.Name == name);
        }

        public void StateDefintionReceive(string stateName, string currentMessageName)
        {
            var definition = StateDefinitions.FirstOrDefault(x => x.Name == stateName);

            definition?.ReceiveMessage(currentMessageName);
        }

        private sealed class NameEqualityComparer : IEqualityComparer<File>
        {
            public bool Equals(File x, File y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(File obj)
            {
                return obj.Name?.GetHashCode() ?? 0;
            }
        }
    }
}