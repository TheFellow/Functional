using System;
using System.Diagnostics.CodeAnalysis;

namespace Functional
{
    public sealed class None<T> : Option<T>, IEquatable<None<T>>, IEquatable<None>
    {
        public override string ToString() => "None";

        public bool Equals([AllowNull] None<T> other) => !(other is null);
        public bool Equals([AllowNull] None other) => !(other is null);
        public override int GetHashCode() => 0;
        public override bool Equals(object? obj) => !(obj is null) && ((obj is None<T>) || (obj is None));
    }

    public sealed class None : IEquatable<None>
    {
        public static None Value { get; } = new None();

        private None() { }

        public override string ToString() => "None";
        
        public bool Equals([AllowNull] None other) => true;
        public override bool Equals(object? obj) =>
            !(obj is null) && ((obj is None) || this.IsGenericNone(obj.GetType()));
        public override int GetHashCode() => 0;

        private bool IsGenericNone(Type type) =>
            type.GenericTypeArguments.Length == 1 &&
            typeof(None<>).MakeGenericType(type.GenericTypeArguments[0]) == type;

    }
}
