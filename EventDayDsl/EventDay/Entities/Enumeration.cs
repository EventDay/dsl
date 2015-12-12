// Copyright (C) 2015 EventDay, Inc

using System.Collections.Generic;

namespace EventDayDsl.EventDay.Entities
{
    public class Enumeration
    {
        public Enumeration(string name)
        {
            Name = name;
            Values = new HashSet<EnumerationValue>(EnumerationValue.ValueComparer);
        }

        public string Name { get; set; }
        public ISet<EnumerationValue> Values { get; set; }

        public static IEqualityComparer<Enumeration> NameComparer { get; } = new NameEqualityComparer();

        private sealed class NameEqualityComparer : IEqualityComparer<Enumeration>
        {
            public bool Equals(Enumeration x, Enumeration y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Enumeration obj)
            {
                return obj.Name?.GetHashCode() ?? 0;
            }
        }
    }

    public class EnumerationValue
    {
        public EnumerationValue(string name, int value)
        {
            Value = value;
            Name = name;
        }

        public int Value { get; set; }
        public string Name { get; set; }

        public static IEqualityComparer<EnumerationValue> ValueComparer { get; } = new ValueEqualityComparer();

        private sealed class ValueEqualityComparer : IEqualityComparer<EnumerationValue>
        {
            public bool Equals(EnumerationValue x, EnumerationValue y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(EnumerationValue obj)
            {
                return obj.Value.GetHashCode();
            }
        }
    }
}