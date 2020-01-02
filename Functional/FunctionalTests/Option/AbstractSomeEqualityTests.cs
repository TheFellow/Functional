using Functional.Optional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FunctionalTests.Option
{
    [TestClass]
    public abstract class AbstractSomeEqualityTests<T>
    {
        protected abstract Some<T> GetSampleValue1();
        protected abstract Some<T> GetSampleValue2();
        protected abstract Some<T> GetOtherValue();

        [TestMethod]
        public void Equals_Null_IsFalse()
        {
            var some = GetSampleValue1();

            Assert.AreNotEqual(some, null!);
            Assert.IsFalse(some.Equals(null));
            Assert.IsFalse(some! == null!);
            Assert.IsFalse(null! == some!);
            Assert.IsTrue(some! != null!);
            Assert.IsTrue(null! != some!);
        }

        [TestMethod]
        public void Equals_SameInstance_IsTrue()
        {
            var some1 = GetSampleValue1();
            var some2 = some1;

            Assert.AreEqual(some1, some2);
            Assert.IsTrue(some1.Equals(some2));
            Assert.IsTrue(some1 == some2);
            Assert.IsFalse(some1 != some2);
        }

        [TestMethod]
        public void Equals_EquivalentInstance_IsTrue()
        {
            var some1 = GetSampleValue1();
            var some2 = GetSampleValue2();

            Assert.AreEqual(some1, some2);
            Assert.IsTrue(some1.Equals(some2));
            Assert.IsTrue(some1 == some2);
            Assert.IsFalse(some1 != some2);
        }

        [TestMethod]
        public void Equals_NonEquivalentInstance_IsFalse()
        {
            var some1 = GetSampleValue1();
            var some2 = GetOtherValue();

            Assert.AreNotEqual(some1, some2);
            Assert.IsFalse(some1.Equals(some2));
            Assert.IsFalse(some1 == some2);
            Assert.IsTrue(some1 != some2);
        }
    }

    [TestClass]
    public class SomeOfIntTests : AbstractSomeEqualityTests<int>
    {
        protected override Some<int> GetOtherValue() => new Some<int>(4);
        protected override Some<int> GetSampleValue1() => new Some<int>(5);
        protected override Some<int> GetSampleValue2() => new Some<int>(5);
    }

    [TestClass]
    public class SomeOfObjectTests : AbstractSomeEqualityTests<MyEquatableType>
    {
        protected override Some<MyEquatableType> GetOtherValue() => new MyEquatableType(4);
        protected override Some<MyEquatableType> GetSampleValue1() => new MyEquatableType(8);
        protected override Some<MyEquatableType> GetSampleValue2() => new MyEquatableType(8);
    }

    public class MyEquatableType : IEquatable<MyEquatableType>
    {
        public int Value { get; }
        public MyEquatableType(int value) => Value = value;

        public bool Equals([AllowNull] MyEquatableType other) => Value.Equals(other.Value);
    }
}
