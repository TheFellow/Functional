using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests
{
    [TestClass]
    public class NoneTests
    {
        [TestMethod]
        public void None_BehavesAsAValueTypeForEquality()
        {
            var none1 = None.Value;
            var none2 = None.Value;

            Assert.AreEqual(none1, none2);
            Assert.IsTrue(none1.Equals(none2));
            Assert.IsTrue(none1 == none2);
            Assert.IsTrue(none2 == none1);
            Assert.IsFalse(none1 != none2);
            Assert.IsFalse(none2 != none1);
        }

        [TestMethod]
        public void None_DoesNotEqualNull()
        {
            var none = None.Value;

            Assert.IsFalse(none.Equals(null));
            Assert.IsFalse(none! == null!);
            Assert.IsFalse(null! == none!);
            Assert.IsTrue(none! != null!);
            Assert.IsTrue(null! != none!);
        }

        [TestMethod]
        public void NoneOfT_BehavesAsAValueTypeForEquality()
        {
            var none1 = new None<int>();
            var none2 = new None<int>();

            Assert.AreEqual(none1, none2);
            Assert.IsTrue(none1.Equals(none2));
            Assert.IsTrue(none1 == none2);
            Assert.IsTrue(none2 == none1);
            Assert.IsFalse(none1 != none2);
            Assert.IsFalse(none2 != none1);
        }

        [TestMethod]
        public void NoneOfT_DoesNotEqualNull()
        {
            var none = None.Value;

            Assert.IsFalse(none.Equals(null));
            Assert.IsFalse(none! == null!);
            Assert.IsFalse(null! == none!);
            Assert.IsTrue(none! != null!);
            Assert.IsTrue(null! != none!);
        }

        [TestMethod]
        public void NoneOfT_Equals_None()
        {
            var none1 = None.Value;
            var none2 = new None<int>();

            Assert.AreEqual(none1, none2);
            Assert.IsTrue(none1.Equals(none2));
            Assert.IsTrue(none2.Equals(none1));
            Assert.IsTrue(none1 == none2);
            Assert.IsTrue(none2 == none1);
            Assert.IsFalse(none1 != none2);
            Assert.IsFalse(none2 != none1);
        }

        [TestMethod]
        public void NoneOfT1_DoesNotEquals_NoneOfT2()
        {
            var none1 = new None<int>();
            var none2 = new None<double>();

            Assert.AreNotEqual(none1, none2);
            Assert.IsFalse(none1.Equals(none2));
            Assert.IsFalse(none2.Equals(none1));
        }
    }
}
