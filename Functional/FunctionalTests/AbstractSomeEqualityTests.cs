using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTests
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
    }

    [TestClass]
    public class SomeOfIntTests : AbstractSomeEqualityTests<int>
    {
        protected override Some<int> GetOtherValue() => new Some<int>(4);
        protected override Some<int> GetSampleValue1() => new Some<int>(5);
        protected override Some<int> GetSampleValue2() => new Some<int>(5);
    }

    [TestClass]
    public class SomeOfObjectTests : AbstractSomeEqualityTests<MyClass>
    {
        protected override Some<MyClass> GetOtherValue() => new MyClass(4);
        protected override Some<MyClass> GetSampleValue1() => new MyClass(8);
        protected override Some<MyClass> GetSampleValue2() => new MyClass(8);
    }

    public class MyClass : IEquatable<MyClass>
    {
        public int Value { get; }
        public MyClass(int value) => Value = value;

        public bool Equals([AllowNull] MyClass other) => Value.Equals(other.Value);
    }
}
