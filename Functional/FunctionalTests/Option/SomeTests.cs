using Functional.Option;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Option
{
    [TestClass]
    public partial class SomeTests
    {
        [TestMethod]
        public void SomeOfT_BehavesAsAValueTypeForEquality()
        {
            var some1 = new Some<int>(5);
            var some2 = new Some<int>(5);

            Assert.AreEqual(some1, some2);
            Assert.IsTrue(some1.Equals(some2));
            Assert.IsTrue(some1 == some2);
            Assert.IsTrue(some2 == some1);
            Assert.IsTrue(some1.GetHashCode() == some2.GetHashCode());
            Assert.IsFalse(some1 != some2);
            Assert.IsFalse(some2 != some1);
        }

        [TestMethod]
        public void SomeOfT_DoesNotEqualSomeOfT_WhenDifferentContent()
        {
            var some1 = new Some<int>(5);
            var some2 = new Some<int>(4);

            Assert.AreNotEqual(some1, some2);
            Assert.IsFalse(some1.Equals(some2));
            Assert.IsFalse(some1 == some2);
            Assert.IsFalse(some2 == some1);
            Assert.IsTrue(some1 != some2);
            Assert.IsTrue(some2 != some1);
        }

        [TestMethod]
        public void SomeOfT1_DoesNotEqual_SomeOfT2()
        {
            var some1 = new Some<MyType1>(new MyType1 { Value = 4 });
            var some2 = new Some<MyType2>(new MyType2 { Value = 4 });

            Assert.AreNotEqual(some1, some2);
            Assert.IsFalse(some1.Equals(some2));
            Assert.IsFalse(some2.Equals(some1));
        }

        [TestMethod]
        public void SomeOfT_EqualsOption_WhenSome()
        {
            Some<int> some = 5;
            Option<int> option = 5;

            Assert.IsTrue(some.Equals(option));
            Assert.IsTrue(option.Equals(some));
            Assert.IsTrue(some == option);
            Assert.IsTrue(option == some);
            Assert.IsFalse(some != option);
            Assert.IsFalse(option != some);
        }

        [TestMethod]
        public void SomeOfT_DoesNotEqualOption_WhenNone()
        {
            Some<int> some = 5;
            Option<int> option = None.Value;

            Assert.IsFalse(some.Equals(option));
            Assert.IsFalse(option.Equals(some));
            Assert.IsFalse(some == option);
            Assert.IsFalse(option == some);
            Assert.IsTrue(some != option);
            Assert.IsTrue(option != some);
        }
    }
}
