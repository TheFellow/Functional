using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests
{
    [TestClass]
    public abstract class AbstractNoneEqualityTest<T>
    {
        protected abstract None<T> GetSampleValue1();
        protected abstract None<T> GetSampleValue2();

        [TestMethod]
        public void Equals_SameInstance_IsTrue()
        {
            var none = GetSampleValue1();

            Assert.AreEqual(none, none);
            Assert.IsTrue(none.Equals(none));
#pragma warning disable CS1718 // Comparison made to same variable
            Assert.IsTrue(none == none);
            Assert.IsFalse(none != none);
#pragma warning restore CS1718 // Comparison made to same variable
        }

        [TestMethod]
        public void Equals_EquivalentInstance_IsTrue()
        {
            var none1 = GetSampleValue1();
            var none2 = GetSampleValue2();

            Assert.AreEqual(none1, none2);
            Assert.IsTrue(none1.Equals(none2));
            Assert.IsTrue(none1 == none2);
            Assert.IsTrue(none2 == none1);
            Assert.IsFalse(none1 != none2);
            Assert.IsFalse(none2 != none1);
        }
    }

    [TestClass]
    public class NoneOfIntTests : AbstractNoneEqualityTest<int>
    {
        protected override None<int> GetSampleValue1() => new None<int>();
        protected override None<int> GetSampleValue2() => new None<int>();
    }

    [TestClass]
    public class NoneOfObjectTests : AbstractNoneEqualityTest<object>
    {
        protected override None<object> GetSampleValue1() => new None<object>();
        protected override None<object> GetSampleValue2() => new None<object>();
    }
}
