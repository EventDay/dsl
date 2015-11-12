using System.Collections.Generic;

namespace EventDayDsl.EventDay.Entities
{
    public class StateDefinition
    {
        public string Ns { get; set; }

        public StateDefinition(string @namespace)
        {
            Ns = @namespace;
            Receives = new HashSet<string>();

        }

        public string Interface { get; set; }
        public bool GenerateInterface => !string.IsNullOrWhiteSpace(Interface);

        public string Name { get; set; }

        public ISet<string> Receives { get; set; }

        private sealed class NameEqualityComparer : IEqualityComparer<StateDefinition>
        {
            public bool Equals(StateDefinition x, StateDefinition y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(StateDefinition obj)
            {
                return obj.Name?.GetHashCode() ?? 0;
            }
        }

        public static IEqualityComparer<StateDefinition> NameComparer { get; } = new NameEqualityComparer();

        public void ReceiveMessage(string messageName)
        {
            Receives.Add(messageName);
        }
    }
}