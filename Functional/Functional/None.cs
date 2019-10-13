using System;
using System.Diagnostics.CodeAnalysis;

namespace Functional
{
    public sealed class None<T> : Option<T>, IEquatable<None<T>>, IEquatable<None>
    {
        public override string ToString() => "None";

        public bool Equals([AllowNull] None<T> other) => !(other is null);
        public bool Equals([AllowNull] None other) => !(other is null);
        public override bool Equals(object? obj) => !(obj is null) && ((obj is None<T>) || (obj is None));
        public override int GetHashCode() => 0;

        public static bool operator ==([AllowNull] None<T> a, [AllowNull] None<T> b) => (a is null && b is null) || (a?.Equals(b) ?? false);
        public static bool operator !=([AllowNull] None<T> a, [AllowNull] None<T> b) => !(a == b);
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

        public static bool operator ==([AllowNull] None a, [AllowNull] None b) => (a is null && b is null) || (a?.Equals(b) ?? false);
        public static bool operator !=([AllowNull] None a, [AllowNull] None b) => !(a == b);
    }
}
